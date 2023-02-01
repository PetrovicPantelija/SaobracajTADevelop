using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Saobracaj.Izvoz
{
    public partial class frmIzvozKonacna : Form
    {
        public string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public frmIzvozKonacna()
        {
            InitializeComponent();
        }

        public frmIzvozKonacna(int ID)
        {
            InitializeComponent();
            FillGV();

            FillCombo();
            VratiPodatke(ID);
            FillDG2();
            FillDG3();
            //  FillDG4();

        }

        private void FillDG2()
        {
            var select = " SELECT     IzvozKonacnaNHM.ID, NHM.Broj, IzvozKonacnaNHM.IDNHM, NHM.Naziv FROM NHM INNER JOIN " +
                      " IzvozKonacnaNHM ON NHM.ID = IzvozKonacnaNHM.IDNHM where IzvozKonacnanhm.idnadredjena = " + Convert.ToInt32(txtID.Text) + " order by IzvozKonacnanhm.ID desc ";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];


            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 20;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Broj";
            dataGridView2.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "ID";
            dataGridView2.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "NHM";
            dataGridView2.Columns[3].Width = 150;



        }

        private void FillDG3()
        {
            var select = "select IzvozKonacnaVrstaRobeHS.ID, IDVrstaRobeHS, VrstaRobeHS.HSKod as Kod,VrstaRobeHS.Naziv as HS from IzvozKonacnaVrstaRobeHS " +
            " inner join  VrstaRobeHS on VrstaRobeHS.ID = IzvozKonacnaVrstaRobeHS.IDVrstaRobeHS where idnadredjena = " + Convert.ToInt32(txtID.Text) + " order by IzvozVrstaRobeHS.ID desc ";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView3.BackgroundColor = Color.White;

            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[0].Width = 20;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "HSID";
            dataGridView3.Columns[1].Width = 20;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "HSKOD";
            dataGridView3.Columns[2].Width = 80;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "HS";
            dataGridView3.Columns[3].Width = 180;

        }


        private void VratiPodatke(int ID)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID]      ,[BrojVagona] " +
             " ,[BrojKontejnera]      ,[VrstaKontejnera]      ,[BrodskaPlomba], [OstalePlombe] , [BookingBrodara] " +
             " ,[Brodar]      ,[CutOffPort]      ,[NetoRobe]      ,[BrutoRobe] " +
             " ,[BrutoRobeO]      ,[BrojKoleta]      ,[BrojKoletaO]      ,[CBM] " +
             " ,[CBMO]      ,[VrednostRobeFaktura]      ,[Valuta]      ,[KrajnaDestinacija] " +
             " ,[Postupanje]      ,[MestoPreuzimanja]      ,[Cirada]      ,[PlaniraniDatumUtovara] " +
             " ,[MesoUtovara]      ,[KontaktOsoba]      ,[MestoCarinjenja]      ,[Spedicija] " +
             " ,[AdresaSlanjaStatusa]      ,[NaslovSlanjaStatusa]      ,[EtaLeget]      ,[NapomenaReexport] " +
             " ,[Inspekcija]      ,[AutoDana]      ,[NajavaVozila]      ,[NacinPakovanja] " +
             " ,[NacinPretovara]      ,[DodatneNapomeneDrumski]      ,[Vaganje]      ,[VGMTezina] " +
             " ,[Tara]      ,[VGMBrod]      ,[Izvoznik]      ,[Klijent1] " +
             " ,[Napomena1REf]      ,[DobijenNalogKlijent1]      ,[Klijent2]      ,[Napomena2REf] " +
             " ,[Klijent3]      ,[Napomena3REf]      ,[SpediterRijeka] , ADR   " +
             "  FROM [IzvozKonacna] where ID=" + ID, con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtID.Text = dr["ID"].ToString();
                txtBrojVagona.Text = dr["BrojVagona"].ToString();
                txtBrKont.Text = dr["BrojKontejnera"].ToString();
                txtTipKont.SelectedValue = Convert.ToInt32(dr["VrstaKontejnera"].ToString());
                txtBrodskaPlomba.Text = dr["BrodskaPlomba"].ToString();
                txtOstalePlombe.Text = dr["OstalePlombe"].ToString();
                txtBokingBrodara.Value = Convert.ToInt32(dr["BookingBrodara"].ToString());
                cboBrodar.SelectedValue = Convert.ToInt32(dr["Brodar"].ToString());
                dtpCutOffPort.Value = Convert.ToDateTime(dr["CutOffPort"].ToString());
                txtNetoR.Value = Convert.ToDecimal(dr["NetoRobe"].ToString());
                txtBrutoR.Value = Convert.ToDecimal(dr["BrutoRobe"].ToString());
                txtBrutoO.Value = Convert.ToDecimal(dr["BrutoRobeO"].ToString());
                txtKoleta.Value = Convert.ToInt32(dr["BrojKoleta"].ToString());
                txtKoletaO.Value = Convert.ToInt32(dr["BrojKoletaO"].ToString());
                txtCBM.Value = Convert.ToDecimal(dr["CBM"].ToString());
                txtCBMO.Value = Convert.ToDecimal(dr["CBMO"].ToString());
                txtADR.SelectedValue = Convert.ToInt32(dr["ADR"].ToString());
                txtVrednostRobeFaktura.Value = Convert.ToDecimal(dr["VrednostRobeFaktura"].ToString());
                txtValuta.Text = dr["Valuta"].ToString();
                cboKrajnjaDestinacija.SelectedValue = Convert.ToInt32(dr["KrajnaDestinacija"].ToString());
                cboPostupanjeSaRobom.SelectedValue = Convert.ToInt32(dr["Postupanje"].ToString());
                cboPPCNT.SelectedValue = Convert.ToInt32(dr["MestoPreuzimanja"].ToString());

                if (dr["Cirada"].ToString() == "1")
                { chkCirada.Checked = true; }
                else
                { chkCirada.Checked = false; }

                dtpPlanUtovara.Value = Convert.ToDateTime(dr["PlaniraniDatumUtovara"].ToString());
                cboMestoUtovara.SelectedValue = Convert.ToInt32(dr["MesoUtovara"].ToString());
                txtKontaktOsoba.Text = dr["KontaktOsoba"].ToString();
                cboCarina.SelectedValue = Convert.ToInt32(dr["MestoCarinjenja"].ToString());
                cboSpedicija.SelectedValue = Convert.ToInt32(dr["Spedicija"].ToString());
                // txtKontaktSpeditera
                cboAdresaStatusVozila.SelectedValue = Convert.ToInt32(dr["AdresaSlanjaStatusa"].ToString());
                cboNaslovStatusaVozila.SelectedValue = Convert.ToInt32(dr["NaslovSlanjaStatusa"].ToString());
                dtpEtaLeget.Value = Convert.ToDateTime(dr["EtaLeget"].ToString());
                cboReexport.SelectedValue = Convert.ToInt32(dr["NapomenaReexport"].ToString());
                cboInspekciskiTretman.SelectedValue = Convert.ToInt32(dr["Inspekcija"].ToString());
                txtAutoDana.Value = Convert.ToDecimal(dr["AutoDana"].ToString());


                if (dr["NajavaVozila"].ToString() == "1")
                { chkNajavaVozila.Checked = true; }
                else
                { chkNajavaVozila.Checked = false; }
                cbNacinPakovanja.SelectedValue = Convert.ToInt32(dr["NacinPakovanja"].ToString());
                if (dr["NacinPretovara"].ToString() == "1")
                { chkNacinPretovara.Checked = true; }
                else
                { chkNacinPretovara.Checked = false; }

                txtDodatneNapomene.Text = dr["DodatneNapomeneDrumski"].ToString();

                if (dr["Vaganje"].ToString() == "1")
                { chkVaganje.Checked = true; }
                else
                { chkVaganje.Checked = false; }

                txtOdvaganaTezina.Value = Convert.ToDecimal(dr["VGMTezina"].ToString());
                txtTaraKontejnera.Value = Convert.ToDecimal(dr["Tara"].ToString());
                txVGMBrodBruto.Value = Convert.ToDecimal(dr["VGMBrod"].ToString());
                cboIzvoznik.SelectedValue = Convert.ToInt32(dr["Izvoznik"].ToString());
                cboKlijent1.SelectedValue = Convert.ToInt32(dr["Klijent1"].ToString());
                txtRef1.Text = dr["Napomena1REf"].ToString();
                cboKlijent2.SelectedValue = Convert.ToInt32(dr["Klijent2"].ToString());
                txtRef2.Text = dr["Napomena2REf"].ToString();
                cboKlijent3.SelectedValue = Convert.ToInt32(dr["Klijent3"].ToString());
                txtRef3.Text = dr["Napomena3REf"].ToString();
                cboSpediterURijeci.SelectedValue = Convert.ToInt32(dr["SpediterRijeka"].ToString());









            }
            con.Close();
        }

        private void FillCombo()
        {
            SqlConnection conn = new SqlConnection(connection);

            var tipkontejnera = "Select ID, SkNaziv From TipKontenjera order by SkNaziv";
            var tkAD = new SqlDataAdapter(tipkontejnera, conn);
            var tkDS = new DataSet();
            tkAD.Fill(tkDS);
            txtTipKont.DataSource = tkDS.Tables[0];
            txtTipKont.DisplayMember = "SkNaziv";
            txtTipKont.ValueMember = "ID";

            var bro = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var broAD = new SqlDataAdapter(bro, conn);
            var broDS = new DataSet();
            broAD.Fill(broDS);
            cboBrodar.DataSource = broDS.Tables[0];
            cboBrodar.DisplayMember = "PaNaziv";
            cboBrodar.ValueMember = "PaSifra";


            var adr = "Select ID, (Naziv + ' - ' + UNKod) as Naziv From VrstaRobeADR order by (UNKod + ' ' + Naziv)";
            var adrSAD = new SqlDataAdapter(adr, conn);
            var adrSDS = new DataSet();
            adrSAD.Fill(adrSDS);
            txtADR.DataSource = adrSDS.Tables[0];
            txtADR.DisplayMember = "Naziv";
            txtADR.ValueMember = "ID";

            //Krajnja destinacija - Kad napravim sifarnik
            var kd = "Select ID, Naziv as Naziv From KrajnjaDestinacija order by ID";
            var kdSAD = new SqlDataAdapter(kd, conn);
            var kdSDS = new DataSet();
            kdSAD.Fill(kdSDS);
            cboKrajnjaDestinacija.DataSource = kdSDS.Tables[0];
            cboKrajnjaDestinacija.DisplayMember = "Naziv";
            cboKrajnjaDestinacija.ValueMember = "ID";

            var dir3 = "Select ID,Naziv from VrstePostupakaUvoz order by Naziv";
            var dirAD3 = new SqlDataAdapter(dir3, conn);
            var dirDS3 = new DataSet();
            dirAD3.Fill(dirDS3);
            cboPostupanjeSaRobom.DataSource = dirDS3.Tables[0];
            cboPostupanjeSaRobom.DisplayMember = "Naziv";
            cboPostupanjeSaRobom.ValueMember = "ID";

            var rl = "Select ID, (Naziv + ' - ' + Oznaka) as Naziv From KontejnerskiTerminali order by (Naziv + ' ' + Oznaka)";
            var rlSAD = new SqlDataAdapter(rl, conn);
            var rlSDS = new DataSet();
            rlSAD.Fill(rlSDS);
            cboPPCNT.DataSource = rlSDS.Tables[0];
            cboPPCNT.DisplayMember = "Naziv";
            cboPPCNT.ValueMember = "ID";


            //Mesta utovara u Srbiji - Dodati
            var dir = "Select ID,Naziv from MestaUtovara order by Naziv";
            var dirAD = new SqlDataAdapter(dir, conn);
            var dirDS = new DataSet();
            dirAD.Fill(dirDS);
            cboMestoUtovara.DataSource = dirDS.Tables[0];
            cboMestoUtovara.DisplayMember = "Naziv";
            cboMestoUtovara.ValueMember = "ID";

            var car = "Select ID, Naziv From Carinarnice order by Naziv";
            var carAD = new SqlDataAdapter(car, conn);
            var carDS = new DataSet();
            carAD.Fill(carDS);
            cboCarina.DataSource = carDS.Tables[0];
            cboCarina.DisplayMember = "Naziv";
            cboCarina.ValueMember = "ID";

            var partner3 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var partAD3 = new SqlDataAdapter(partner3, conn);
            var partDS3 = new DataSet();
            partAD3.Fill(partDS3);
            cboSpedicija.DataSource = partDS3.Tables[0];
            cboSpedicija.DisplayMember = "PaNaziv";
            cboSpedicija.ValueMember = "PaSifra";

            //Adresa statusa vozila
            var dir5 = "Select ID,Naziv from AdresaStatusVozila order by Naziv";
            var dirAD5 = new SqlDataAdapter(dir5, conn);
            var dirDS5 = new DataSet();
            dirAD5.Fill(dirDS5);
            cboAdresaStatusVozila.DataSource = dirDS5.Tables[0];
            cboAdresaStatusVozila.DisplayMember = "Naziv";
            cboAdresaStatusVozila.ValueMember = "ID";

            //Naslov statusa vozila
            var partner4 = "Select ID,Naziv from NaslovStatusaVozila order by Naziv";
            var partAD4 = new SqlDataAdapter(partner4, conn);
            var partDS4 = new DataSet();
            partAD4.Fill(partDS4);
            cboNaslovStatusaVozila.DataSource = partDS4.Tables[0];
            cboNaslovStatusaVozila.DisplayMember = "Naziv";
            cboNaslovStatusaVozila.ValueMember = "ID";




            //carinski postupak
            var dir2 = "Select ID, (Oznaka + ' ' + Naziv) as Naziv from VrstaCarinskogPostupka order by Naziv";
            var dirAD2 = new SqlDataAdapter(dir2, conn);
            var dirDS2 = new DataSet();
            dirAD2.Fill(dirDS2);
            cboReexport.DataSource = dirDS2.Tables[0];
            cboReexport.DisplayMember = "Naziv";
            cboReexport.ValueMember = "ID";

            //Novi sifarnik Inpekciski tretman
            var dir4 = "Select ID,Naziv from InspekciskiTretman order by Naziv";
            var dirAD4 = new SqlDataAdapter(dir4, conn);
            var dirDS4 = new DataSet();
            dirAD4.Fill(dirDS4);
            cboInspekciskiTretman.DataSource = dirDS4.Tables[0];
            cboInspekciskiTretman.DisplayMember = "Naziv";
            cboInspekciskiTretman.ValueMember = "ID";


            var np4 = "Select ID,(Oznaka + ' ' + Naziv) as Naziv from uvNacinPakovanja order by Naziv";
            var npAD4 = new SqlDataAdapter(np4, conn);
            var npDS4 = new DataSet();
            npAD4.Fill(npDS4);
            cbNacinPakovanja.DataSource = npDS4.Tables[0];
            cbNacinPakovanja.DisplayMember = "Naziv";
            cbNacinPakovanja.ValueMember = "ID";

            var partner = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var partAD = new SqlDataAdapter(partner, conn);
            var partDS = new DataSet();
            partAD.Fill(partDS);
            cboIzvoznik.DataSource = partDS.Tables[0];
            cboIzvoznik.DisplayMember = "PaNaziv";
            cboIzvoznik.ValueMember = "PaSifra";

            var nalogodavac1 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var nal1AD = new SqlDataAdapter(nalogodavac1, conn);
            var nal1DS = new DataSet();
            nal1AD.Fill(nal1DS);
            cboKlijent1.DataSource = nal1DS.Tables[0];
            cboKlijent1.DisplayMember = "PaNaziv";
            cboKlijent1.ValueMember = "PaSifra";

            var nalogodavac2 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var nal2AD = new SqlDataAdapter(nalogodavac2, conn);
            var nal2DS = new DataSet();
            nal2AD.Fill(nal2DS);
            cboKlijent2.DataSource = nal2DS.Tables[0];
            cboKlijent2.DisplayMember = "PaNaziv";
            cboKlijent2.ValueMember = "PaSifra";

            var nalogodavac3 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var nal3AD = new SqlDataAdapter(nalogodavac3, conn);
            var nal3DS = new DataSet();
            nal3AD.Fill(nal3DS);
            cboKlijent3.DataSource = nal3DS.Tables[0];
            cboKlijent3.DisplayMember = "PaNaziv";
            cboKlijent3.ValueMember = "PaSifra";

            var nalogodavac4 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var nal4AD = new SqlDataAdapter(nalogodavac4, conn);
            var nal4DS = new DataSet();
            nal4AD.Fill(nal4DS);
            cboSpediterURijeci.DataSource = nal4DS.Tables[0];
            cboSpediterURijeci.DisplayMember = "PaNaziv";
            cboSpediterURijeci.ValueMember = "PaSifra";






            //Panta
            var VRHS = "Select ID,(HSKod + '   ' + Rtrim(Naziv)) as Naziv from VrstaRobeHS order by HSKod";
            var VRHSAD = new SqlDataAdapter(VRHS, conn);
            var VRHSDS = new DataSet();
            VRHSAD.Fill(VRHSDS);
            cboNazivRobe.DataSource = VRHSDS.Tables[0];
            cboNazivRobe.DisplayMember = "Naziv";
            cboNazivRobe.ValueMember = "ID";


            var nhm = "Select ID,(Naziv + '-' + Rtrim(Broj)) as Naziv from NHM order by Broj";
            var nhmSAD = new SqlDataAdapter(nhm, conn);
            var nhmSDS = new DataSet();
            nhmSAD.Fill(nhmSDS);
            cboNHM.DataSource = nhmSDS.Tables[0];
            cboNHM.DisplayMember = "Naziv";
            cboNHM.ValueMember = "ID";


        }

        private void FillGV()
        {
            var select = " SELECT     IzvozKonacna.VrstaKontejnera, TipKontenjera.Naziv, IzvozKonacna.ID, IzvozKonacna.BrojVagona, IzvozKonacna.BrojKontejnera, IzvozKonacna.BrodskaPlomba, IzvozKonacna.OstalePlombe, IzvozKonacna.BookingBrodara, Partnerji.PaNaziv, " +
                  "    IzvozKonacna.CutOffPort, IzvozKonacna.NetoRobe, IzvozKonacna.BrutoRobe, IzvozKonacna.BrutoRobeO, IzvozKonacna.BrojKoleta, IzvozKonacna.BrojKoletaO, IzvozKonacna.CBM, IzvozKonacna.CBMO, IzvozKonacna.VrednostRobeFaktura, " +
                   "  (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaManipulacije.Naziv as nvarchar(20))   FROM IzvozKonacnaVrstaManipulacije " +
   "       inner join VrstaManipulacije on VrstaManipulacije.ID = IzvozKonacnaVrstaManipulacije.IDVrstaManipulacije   where IzvozKonacnaVrstaManipulacije.IDNadredjena = Izvoz.ID " +
   "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as VrsteUsluga,   " +
   "     (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20))   FROM IzvozKonacnaVrstaRobeHS " +
   "       inner join VrstaRobeHS on IzvozKonacnaVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID   where IzvozKonacnaVrstaRobeHS.IDNadredjena = Izvoz.ID " +
   "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as HS,   " +
   "    (SELECT  STUFF((SELECT distinct    '/' + Cast(NHM.Broj as nvarchar(20)) " +
  "            FROM IzvozKonacnaNHM  inner join NHM on IzvozKonacnaNHM.IDNHM = NHM.ID  where IzvozKonacnaNHM.IDNadredjena = IzvozKonacna.ID   FOR XML PATH('')), 1, 1, ''  ) As Skupljen) as NHM, " +
                  "        IzvozKonacna.Valuta, KrajnjaDestinacija.Naziv AS KrajnjaDestinacija, VrstePostupakaUvoz.Naziv AS Postupak, KontejnerskiTerminali.Naziv AS PPCNT, " +
                  "        KontejnerskiTerminali.Oznaka, IzvozKonacna.Cirada, IzvozKonacna.PlaniraniDatumUtovara, MestaUtovara.Naziv AS MestoUtovara, IzvozKonacna.KontaktOsoba,  " +
                  "        Carinarnice.Naziv AS Carinarnica, Carinarnice.CIOznaka, Partnerji_1.PaNaziv AS Spedicija, AdresaStatusVozila.Naziv AS AdresaStatusVozila, " +
                  "        NaslovStatusaVozila.Naziv AS NaslovStatusaVozila, IzvozKonacna.EtaLeget, VrstaCarinskogPostupka.Naziv AS Reexport, InspekciskiTretman.Naziv AS InspekciskiTretman, " +
                  "        IzvozKonacna.AutoDana, IzvozKonacna.NajavaVozila, IzvozKonacna.DodatneNapomeneDrumski, IzvozKonacna.Vaganje, IzvozKonacna.VGMTezina, IzvozKonacna.Tara, IzvozKonacna.VGMBrod, " +
                  "        Partnerji_2.PaNaziv AS Izvoznik, Partnerji_3.PaNaziv AS Klijent1, IzvozKonacna.Napomena1REf, IzvozKonacna.DobijenNalogKlijent1, Partnerji_4.PaNaziv AS klijent2, " +
                  "        IzvozKonacna.Napomena2REf, Partnerji_5.PaNaziv AS Klijent3, IzvozKonacna.Napomena3REf, Partnerji_6.PaNaziv AS SpediterRijeka, uvNacinPakovanja.Naziv AS NacinPakovanja, " +
                  "        IzvozKonacna.NacinPretovara " +
"    FROM         IzvozKonacna INNER JOIN " +
                   "       TipKontenjera ON Izvoz.VrstaKontejnera = TipKontenjera.ID INNER JOIN " +
                  "        Partnerji ON Izvoz.Brodar = Partnerji.PaSifra INNER JOIN " +
                  "        KrajnjaDestinacija ON IzvozKonacna.KrajnaDestinacija = KrajnjaDestinacija.ID INNER JOIN " +
                  "        VrstePostupakaUvoz ON IzvozKonacna.Postupanje = VrstePostupakaUvoz.ID INNER JOIN " +
                  "        KontejnerskiTerminali ON IzvozKonacna.MestoPreuzimanja = KontejnerskiTerminali.id INNER JOIN " +
                  "        MestaUtovara ON IzvozKonacna.MesoUtovara = MestaUtovara.ID INNER JOIN " +
                  "        Carinarnice ON IzvozKonacna.MestoCarinjenja = Carinarnice.ID INNER JOIN " +
                   "       Partnerji AS Partnerji_1 ON IzvozKonacna.Spedicija = Partnerji_1.PaSifra INNER JOIN " +
                   "       AdresaStatusVozila ON IzvozKonacna.AdresaSlanjaStatusa = AdresaStatusVozila.ID INNER JOIN " +
                   "       NaslovStatusaVozila ON IzvozKonacna.NaslovSlanjaStatusa = NaslovStatusaVozila.ID INNER JOIN " +
                  "        VrstaCarinskogPostupka ON IzvozKonacna.NapomenaReexport = VrstaCarinskogPostupka.id INNER JOIN " +
                   "       InspekciskiTretman ON IzvozKonacna.Inspekcija = InspekciskiTretman.ID INNER JOIN " +
                   "       Partnerji AS Partnerji_2 ON IzvozKonacna.Izvoznik = Partnerji_2.PaSifra INNER JOIN " +
                   "       Partnerji AS Partnerji_3 ON IzvozKonacna.Klijent1 = Partnerji_3.PaSifra INNER JOIN " +
                    "      Partnerji AS Partnerji_4 ON IzvozKonacna.Klijent2 = Partnerji_4.PaSifra INNER JOIN " +
                  "        Partnerji AS Partnerji_5 ON IzvozKonacna.Klijent3 = Partnerji_5.PaSifra INNER JOIN " +
                 "         Partnerji AS Partnerji_6 ON IzvozKonacna.SpediterRijeka = Partnerji_6.PaSifra INNER JOIN " +
                  "        uvNacinPakovanja ON IzvozKonacna.NacinPakovanja = uvNacinPakovanja.ID order by IzvozKonacna.ID desc ";

            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Frozen = true;
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "BrojKontejnera";
            dataGridView1.Columns[1].Frozen = true;
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "BL";
            dataGridView1.Columns[2].Frozen = true;
            dataGridView1.Columns[2].Width = 90;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Dobijen_Nalog_Brodara";
            // dataGridView1.Columns[1].Frozen = true;
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "ATABroda";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Brod";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Napomena";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "DatumBZ";
            dataGridView1.Columns[7].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "PIN";
            dataGridView1.Columns[8].Width = 60;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "BrojKontejnera";
            //   dataGridView1.Columns[7].Frozen = true;
            dataGridView1.Columns[9].Width = 100;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Vrsta kontejnera";
            dataGridView1.Columns[10].Width = 120;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "R_L_SRB";
            dataGridView1.Columns[11].Width = 120;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Dirigacija_Kontejnera_Za";
            dataGridView1.Columns[12].Width = 100;

            DataGridViewColumn column13 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "BL";
            // dataGridView1.Columns[13].Frozen = true;
            dataGridView1.Columns[13].Width = 90;

            // RefreshDataGridColor();


        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertIzvoz ins = new InsertIzvoz();
            int pomCirada = 0;
            if (chkCirada.Checked == true)
            {
                pomCirada = 1;
            }

            int pomNajavaVozila = 0;
            if (chkNajavaVozila.Checked == true)
            {
                pomNajavaVozila = 1;
            }

            int pomNacinPretovara = 0;
            if (chkNacinPretovara.Checked == true)
            {
                pomNacinPretovara = 1;
            }

            int pomVaganje = 0;
            if (chkVaganje.Checked == true)
            {
                pomVaganje = 1;
            }

            int pomDobijenNalog = 0;

            if (cboDobijenNalog.Checked == true)
            {
                pomDobijenNalog = 1;
            }

            ins.UpdIzvozKonacna(Convert.ToInt32(txtID.Text), txtBrojVagona.Text, txtBrKont.Text, Convert.ToInt32(txtTipKont.SelectedValue),
                txtBrodskaPlomba.Text, Convert.ToInt32(txtBokingBrodara.Value), Convert.ToInt32(cboBrodar.SelectedValue), Convert.ToDateTime(dtpCutOffPort.Value),
                Convert.ToDecimal(txtNetoR.Value), Convert.ToDecimal(txtBrutoR.Value), Convert.ToDecimal(txtBrutoO.Value), Convert.ToInt32(txtKoleta.Value),
                Convert.ToInt32(txtKoletaO.Value), Convert.ToDecimal(txtCBM.Value), Convert.ToDecimal(txtCBMO.Value), Convert.ToDecimal(txtVrednostRobeFaktura.Value),
                txtValuta.Text, Convert.ToInt32(cboKrajnjaDestinacija.SelectedValue), Convert.ToInt32(cboPostupanjeSaRobom.SelectedValue),
                Convert.ToInt32(cboPPCNT.SelectedValue), pomCirada, Convert.ToDateTime(dtpPlanUtovara.Value), Convert.ToInt32(cboMestoUtovara.SelectedValue),
                txtKontaktOsoba.Text, Convert.ToInt32(cboCarina.SelectedValue), Convert.ToInt32(cboSpedicija.SelectedValue),
                Convert.ToInt32(cboAdresaStatusVozila.SelectedValue), Convert.ToInt32(cboNaslovStatusaVozila.SelectedValue), Convert.ToDateTime(dtpEtaLeget.Value),
                Convert.ToInt32(cboReexport.SelectedValue), Convert.ToInt32(cboInspekciskiTretman.SelectedValue), Convert.ToDecimal(txtAutoDana.Value),
                pomNajavaVozila, Convert.ToInt32(cbNacinPakovanja.SelectedValue), pomNacinPretovara, txtDodatneNapomene.Text, pomVaganje, Convert.ToDecimal(txtOdvaganaTezina.Value),
                Convert.ToDecimal(txtTaraKontejnera.Value), Convert.ToDecimal(txVGMBrodBruto.Value), Convert.ToInt32(cboIzvoznik.SelectedValue),
                Convert.ToInt32(cboKlijent1.SelectedValue), Convert.ToInt32(txtRef1.Text), pomDobijenNalog,
                Convert.ToInt32(cboKlijent2.SelectedValue), Convert.ToInt32(txtRef2.Text),
                Convert.ToInt32(cboKlijent3.SelectedValue), Convert.ToInt32(txtRef3.Text),
                 Convert.ToInt32(cboSpediterURijeci.SelectedValue), txtOstalePlombe.Text, Convert.ToInt32(txtADR.SelectedValue), Convert.ToInt32(cboNadredjena.SelectedValue));
            //Fale ostale plombe
            // Convert.ToDecimal(txtDodatneNapomene.Text -- treba staviti nvarchar

            /*
            ins.UpdUvoz(Convert.ToInt32(txtID.Text), Convert.ToDateTime(dtEtaRijeka.Value.ToString()),
                Convert.ToDateTime(dtAtaRijeka.Value.ToString()), txtStatus.Text.ToString().TrimEnd(), txtBrKont.Text,
                Convert.ToInt32(txtTipKont.SelectedValue), Convert.ToDateTime(dtNalogBrodara.Value.ToString()), txtBZ.Text.ToString().TrimEnd(),
                txtNapomena.Text.ToString().TrimEnd(), txtPIN.Text.ToString().TrimEnd(), Convert.ToInt32(cbDirigacija.SelectedValue), Convert.ToInt32(cbBrod.SelectedValue),
                txtTeretnica.Text, Convert.ToInt32(txtADR.SelectedValue), Convert.ToInt32(cbVlasnikKont.SelectedValue), Convert.ToInt32(txtBuking.Text), nalogodavci,
                usluge, Convert.ToInt32(cboUvoznik.SelectedValue), Convert.ToInt32(cboNHM.SelectedValue), cboNazivRobe.SelectedValue.ToString(), Convert.ToInt32(cboSpedicijaG.SelectedValue),
                Convert.ToInt32(cboSpedicijaRTC.SelectedValue), Convert.ToInt32(cboCarinskiPostupak.SelectedValue), Convert.ToInt32(cbPostupak.SelectedValue),
                Convert.ToInt32(cbNacinPakovanja.SelectedValue), Convert.ToInt32(cbOcarina.SelectedValue), Convert.ToInt32(cbOspedicija.SelectedValue),
                txtMesto.Text.ToString().TrimEnd(), txtKontaktOsoba.Text.ToString().TrimEnd(), txtMail.Text.ToString(), txtPlomba1.Text,
                txtPlomba2.Text, Convert.ToDecimal(txtNetoR.Value), Convert.ToDecimal(txtBrutoR.Value), Convert.ToDecimal(txtTaraK.Value),
                Convert.ToDecimal(txtBrutoK.Value), Convert.ToInt32(cbNapomenaPoz.SelectedValue), Convert.ToDateTime(dtAtaOtprema.Value.ToString()),
                Convert.ToInt32(txtBrojVoza.Text), txtRelacija.Text.ToString().TrimEnd(), Convert.ToDateTime(dtAtaDolazak.Value.ToString()), Convert.ToDecimal(txtKoleta.Value), Convert.ToInt32(cboRLTerminal.SelectedValue), txtNapomena1.Text, txtVrstaPregleda.Text,
                Convert.ToInt32(cboNalogodavac1.SelectedValue), txtRef1.Text,
                Convert.ToInt32(cboNalogodavac2.SelectedValue), txtRef2.Text,
                Convert.ToInt32(cboNalogodavac3.SelectedValue), txtRef3.Text, Convert.ToInt32(cboBrodar.SelectedValue));
            */
            // FillGV();
            //  RefreshDataGridColor();
            
            txtID.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertIzvoz uvK = new InsertIzvoz();
            uvK.InsIzvozKonacnaNHM(Convert.ToInt32(txtID.Text), Convert.ToInt32(cboNHM.SelectedValue));
            FillDG2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertIzvoz uvK = new InsertIzvoz();
            uvK.DelIzvozKonacnaNHM(Convert.ToInt32(cboNHM.SelectedValue));
            FillDG2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertIzvoz uvK = new InsertIzvoz();
            uvK.InsIzvozKonacnaVrstaRobeHS(Convert.ToInt32(txtID.Text), Convert.ToInt32(cboNHM.SelectedValue));
            FillDG3();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertIzvoz uvK = new InsertIzvoz();
            uvK.DelIzvozKonacnaVrstaRobeHS(Convert.ToInt32(cboNHM.SelectedValue));
            FillDG3();
        }
        private void FillDG6()
        {

            var select = "select Cene.ID, VrstaManipulacije.Naziv, Cene.Cena, VrstaManipulacije.ID from Cene " +
            " inner join VrstaManipulacije on VrstaManipulacije.ID = Cene.VrstaManipulacije " +
            " where TipCenovnika = 1 order by VrstaManipulacije.Naziv ";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView6.ReadOnly = true;
            dataGridView6.DataSource = ds.Tables[0];


            dataGridView6.BorderStyle = BorderStyle.None;
            dataGridView6.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView6.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView6.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView6.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView6.BackgroundColor = Color.White;

            dataGridView6.EnableHeadersVisualStyles = false;
            dataGridView6.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView6.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView6.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView6.Columns[0];
            dataGridView6.Columns[0].HeaderText = "ID";
            dataGridView6.Columns[0].Width = 20;

            DataGridViewColumn column2 = dataGridView6.Columns[1];
            dataGridView6.Columns[1].HeaderText = "Man";
            dataGridView6.Columns[1].Width = 120;

            DataGridViewColumn column3 = dataGridView6.Columns[2];
            dataGridView6.Columns[2].HeaderText = "Cena";
            dataGridView6.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView6.Columns[3];
            dataGridView6.Columns[3].HeaderText = "IDVM";
            dataGridView6.Columns[3].Width = 50;
            dataGridView6.Columns[3].Visible = false;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            FillDG6();
        }
        private void FillDG7()
        {

            var select = "select Cene.ID, VrstaManipulacije.Naziv, Cene.Cena, VrstaManipulacije.ID from Cene " +
            " inner join VrstaManipulacije on VrstaManipulacije.ID = Cene.VrstaManipulacije " +
            " where TipCenovnika <> 1 and Cene.PostupakSaRobom = " + Convert.ToInt32(cboPostupanjeSaRobom.SelectedValue) + " and Cene.Uvoznik = " + Convert.ToInt32(cboIzvoznik.SelectedValue) + "  order by VrstaManipulacije.Naziv ";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView6.ReadOnly = true;
            dataGridView6.DataSource = ds.Tables[0];


            dataGridView6.BorderStyle = BorderStyle.None;
            dataGridView6.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView6.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView6.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView6.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView6.BackgroundColor = Color.White;

            dataGridView6.EnableHeadersVisualStyles = false;
            dataGridView6.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView6.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView6.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView6.Columns[0];
            dataGridView6.Columns[0].HeaderText = "ID";
            dataGridView6.Columns[0].Width = 20;

            DataGridViewColumn column2 = dataGridView6.Columns[1];
            dataGridView6.Columns[1].HeaderText = "Man";
            dataGridView6.Columns[1].Width = 120;

            DataGridViewColumn column3 = dataGridView6.Columns[2];
            dataGridView6.Columns[2].HeaderText = "Cena";
            dataGridView6.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView6.Columns[3];
            dataGridView6.Columns[3].HeaderText = "IDVM";
            dataGridView6.Columns[3].Width = 50;
            dataGridView6.Columns[3].Visible = false;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FillDG7();
        }

        private void UbaciStavkuUsluge(int ID, int Manipulacija, double Cena)
        {
            InsertIzvoz uvK = new InsertIzvoz();
            uvK.InsUbaciUsluguKonacna(Convert.ToInt32(txtID.Text), Manipulacija, Cena);
            FillDG8();
        }

        private void FillDG8()
        {
            var select = "select  IzvozKonacnaVrstaManipulacije.ID, VrstaManipulacije.Naziv, IzvozKonacnaVrstaManipulacije.Cena, VrstaManipulacije.ID from IzvozKonacnaVrstaManipulacije " +
            " inner join VrstaManipulacije on VrstaManipulacije.ID = UvozVrstaManipulacije.IDVrstaManipulacije " +
                " where IzvozKonacnaVrstaManipulacije.IDNadredjena = " + Convert.ToInt32(txtID.Text);
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView5.ReadOnly = true;
            dataGridView5.DataSource = ds.Tables[0];


            dataGridView5.BorderStyle = BorderStyle.None;
            dataGridView5.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView5.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView5.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView5.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView5.BackgroundColor = Color.White;

            dataGridView5.EnableHeadersVisualStyles = false;
            dataGridView5.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView5.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView5.Columns[0];
            dataGridView5.Columns[0].HeaderText = "ID";
            dataGridView5.Columns[0].Width = 20;

            DataGridViewColumn column2 = dataGridView5.Columns[1];
            dataGridView5.Columns[1].HeaderText = "Man";
            dataGridView5.Columns[1].Width = 120;

            DataGridViewColumn column3 = dataGridView5.Columns[2];
            dataGridView5.Columns[2].HeaderText = "Cena";
            dataGridView5.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView5.Columns[3];
            dataGridView5.Columns[3].HeaderText = "IDVM";
            dataGridView5.Columns[3].Width = 50;
            dataGridView5.Columns[3].Visible = false;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int pomID = 0;
            int pomManupulacija = 0;
            double pomCena = 0;
            try
            {
                foreach (DataGridViewRow row in dataGridView6.Rows)
                {
                    if (row.Selected)
                    {
                        pomID = Convert.ToInt32(row.Cells[0].Value.ToString());
                        pomManupulacija = Convert.ToInt32(row.Cells[3].Value.ToString());
                        pomCena = Convert.ToDouble(row.Cells[2].Value.ToString());
                        UbaciStavkuUsluge(pomID, pomManupulacija, pomCena);
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                        txtIDNHM.Text = row.Cells[0].Value.ToString();

                    }
                }
            }
            catch { }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        txtVrstaRobeHS.Text = row.Cells[0].Value.ToString();

                    }
                }
            }
            catch { }
        }
    }
}
