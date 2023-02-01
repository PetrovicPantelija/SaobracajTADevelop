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

namespace Saobracaj.Uvoz
{
    public partial class Uvoz : Form
    {
        public string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        string nalogodavci = "";
        string usluge = "";
        public Uvoz()
        {
            InitializeComponent();
            FillGV();
            FillCheck();
            FillCombo();
            RefreshDataGridColor();
        }

        public Uvoz(int sifra)
        {
            InitializeComponent();
            FillGV();
            FillCheck();
            FillCombo();
            VratiPodatke(sifra);
            FillDG2();
            FillDG3();
            FillDG4();
            RefreshDataGridColor();
        }
        private void VratiPodatke(int Sifra)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] " +
      " ,[EtaBroda] ,[AtaBroda] ,[StatusPrijema] ,[BrojKontejnera] " +
      " ,[DobijenNalogBrodara] ,[DobijeBZ] ,[Napomena] ,[PIN] " +
      " ,[DirigacijaKontejeraZa] ,[NazivBroda] ,[BrodskaTeretnica] ,[ADR] " +
      " ,[VlasnikKontejnera] ,[BukingBrodara]      ,[Nalogodavac]      ,[VrstaUsluge] " +
      " ,[Uvoznik]      ,[NHMBroj]      ,[NazivRobe]      ,[SpedicijaGranica] " +
      " ,[SpedicijaRTC]      ,[CarinskiPostupak]      ,[PostupakSaRobom]      ,[NacinPakovanja] " +
      " ,[OdredisnaCarina]      ,[OdredisnaSpedicija]      ,[MestoIstovara]      ,[KontaktOsoba] " +
      " ,[Email]      ,[BrojPlombe1]      ,[BrojPlombe2]      ,[NetoRobe] " +
      " ,[BrutoRobe]      ,[TaraKontejnera]      ,[BrutoKontejnera]      ,[NapomenaZaPozicioniranje] " +
      " ,[AtaOtpreme]      ,[BrojVoza]      ,[RelacijaVoza]      ,[AtaDolazak] " +
      " ,[TipKontejnera]      ,[Koleta], RLTerminali, " +
      " Napomena1,VrstaPregleda,Nalogodavac1 ,Ref1 ,Nalogodavac2,Ref2 ,Nalogodavac3 ,Ref3 ,Brodar " +
  " FROM [Uvoz] where ID=" + Sifra, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtID.Text = dr["ID"].ToString();
                dtEtaRijeka.Value = Convert.ToDateTime(dr["EtaBroda"].ToString());
                dtAtaRijeka.Value = Convert.ToDateTime(dr["AtaBroda"].ToString());
                txtStatus.Text = dr["StatusPrijema"].ToString();
                txtBrKont.Text = dr["BrojKontejnera"].ToString();
                txtTipKont.SelectedValue = Convert.ToInt32(dr["TipKontejnera"].ToString());
                dtNalogBrodara.Value = Convert.ToDateTime(dr["DobijenNalogBrodara"].ToString());
                txtBZ.Text = dr["DobijeBZ"].ToString();
                txtPIN.Text = dr["PIN"].ToString();
                cbDirigacija.SelectedValue = Convert.ToInt32(dr["DirigacijaKontejeraZa"].ToString());
                cbBrod.SelectedValue = Convert.ToInt32(dr["NazivBroda"].ToString());
                txtTeretnica.Text = dr["BrodskaTeretnica"].ToString();
                txtADR.SelectedValue = Convert.ToInt32(dr["ADR"].ToString());
                cbVlasnikKont.SelectedValue = Convert.ToInt32(dr["VlasnikKontejnera"].ToString());
                txtBuking.Text = dr["BukingBrodara"].ToString();
                cboUvoznik.SelectedValue = Convert.ToInt32(dr["Uvoznik"].ToString());
                cboSpedicijaG.SelectedValue =  Convert.ToInt32(dr["SpedicijaGranica"].ToString());
                //cboNHM
                // cboNazivRobe
                cboSpedicijaRTC.SelectedValue = Convert.ToInt32(dr["SpedicijaRTC"].ToString());
                cboCarinskiPostupak.SelectedValue = Convert.ToInt32(dr["CarinskiPostupak"].ToString());
                cbNacinPakovanja.SelectedValue = Convert.ToInt32(dr["NacinPakovanja"].ToString());
                cbOcarina.SelectedValue = Convert.ToInt32(dr["OdredisnaCarina"].ToString());
                cbOspedicija.SelectedValue = Convert.ToInt32(dr["OdredisnaSpedicija"].ToString());
                txtMesto.Text = dr["MestoIstovara"].ToString(); 
                cbPostupak.SelectedValue = Convert.ToInt32(dr["PostupakSaRobom"].ToString());
                txtPlomba1.Text = dr["BrojPlombe1"].ToString();
                txtPlomba2.Text = dr["BrojPlombe2"].ToString();
                txtKontaktOsoba.Text = dr["KontaktOsoba"].ToString();
                txtMail.Text = dr["Email"].ToString();
                dtAtaOtprema.Value = Convert.ToDateTime(dr["AtaOtpreme"].ToString());
                txtRelacija.Text = dr["RelacijaVoza"].ToString();
                txtBrojVoza.Text = dr["BrojVoza"].ToString();
                dtAtaDolazak.Value = Convert.ToDateTime(dr["AtaOtpreme"].ToString());
                txtKoleta.Value = Convert.ToDecimal(dr["Koleta"].ToString());
                txtNetoR.Value = Convert.ToDecimal(dr["NetoRobe"].ToString());
                txtBrutoR.Value = Convert.ToDecimal(dr["BrutoRobe"].ToString());
                txtTaraK.Value = Convert.ToDecimal(dr["TaraKontejnera"].ToString());
                txtBrutoK.Value = Convert.ToDecimal(dr["BrutoKontejnera"].ToString());
                txtNapomena.Text = dr["Napomena"].ToString();
                cbNapomenaPoz.SelectedValue =  Convert.ToInt32(dr["NapomenaZaPozicioniranje"].ToString());
                //Panta
                
                cboRLTerminal.SelectedValue = Convert.ToInt32(dr["RLTerminali"].ToString());
                cboBrodar.SelectedValue = Convert.ToInt32(dr["Brodar"].ToString());
                txtNapomena1.Text = dr["Napomena1"].ToString();
                txtVrstaPregleda.Text = dr["VrstaPregleda"].ToString();
                cboNalogodavac1.SelectedValue = Convert.ToInt32(dr["Nalogodavac1"].ToString());
                txtRef1.Text = dr["Ref1"].ToString();
                cboNalogodavac2.SelectedValue = Convert.ToInt32(dr["Nalogodavac2"].ToString());
                txtRef2.Text = dr["Ref2"].ToString();
                cboNalogodavac3.SelectedValue = Convert.ToInt32(dr["Nalogodavac3"].ToString());
                txtRef3.Text = dr["Ref3"].ToString();
            }
            con.Close();


        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Brodovi brod = new Brodovi();
            brod.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Carinarnice car = new Carinarnice();
            car.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Nalogodavci nal = new Nalogodavci();
            nal.Show();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Insert into Uvoz Default Values",conn);
                conn.Open();
                var q=cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            GetID();
            tsNew.Enabled = false;
            txtBrKont.Text = "";

        }
        private void GetID()
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Select MAX(ID) FROM Uvoz", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    int IDpom = Convert.ToInt32(dr[0].ToString());
                    txtID.Text = IDpom.ToString();
                }
            }
        }
        private void FillGV()
        {
            var select = "SELECT Uvoz.ID, [BrojKontejnera], BrodskaTeretnica as BL, DobijenNalogBrodara as Dobijen_Nalog_Brodara ,ATABroda, Brodovi.Naziv as Brod,Napomena1 as Napomena1, DobijeBZ as DatumBZ ,PIN, " +
 " [BrojKontejnera], TipKontenjera.Naziv as Vrsta_Kontejnera,  KontejnerskiTerminali.Naziv as R_L_SRB, pp1.Naziv as Dirigacija_Kontejnera_Za,  " +
 "   BrodskaTeretnica, VrstaRobeADR.Naziv as ADR, b.PaNaziv as Brodar, n1.PaNaziv as Nalogodavac1, Ref1 as Ref1, n2.PaNaziv as Nalogodavac2, Ref2 as Ref2, n3.PaNaziv as Nalogodavac3, Ref3 as Ref3, " +
  "      p1.PaNaziv as Uvoznik,   " +
  "  (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaManipulacije.Naziv as nvarchar(20))   FROM UvozVrstaManipulacije " +
   "       inner join VrstaManipulacije on VrstaManipulacije.ID = UvozVrstaManipulacije.IDVrstaManipulacije   where UvozVrstaManipulacije.IDNadredjena = Uvoz.ID " +
   "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as VrsteUsluga,   " +
   "     (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20))   FROM UvozVrstaRobeHS " +
   "       inner join VrstaRobeHS on UvozVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID   where UvozVrstaRobeHS.IDNadredjena = Uvoz.ID " +
   "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as HS,   " +
   "    (SELECT  STUFF((SELECT distinct    '/' + Cast(NHM.Broj as nvarchar(20)) " +
  "            FROM UvozNHM  inner join NHM on UvozNHM.IDNHM = NHM.ID  where UvozNHM.IDNadredjena = Uvoz.ID   FOR XML PATH('')), 1, 1, ''  ) As Skupljen) as NHM,   " +
   "              VrstaPregleda as VrstaPregleda,p2.PaNaziv as SpedicijaRTC,  p3.PaNaziv as SpedicijaGranica,      " +
   " VrstaCarinskogPostupka.Naziv as CarinskiPostupak,   " +
   "                  VrstePostupakaUvoz.Naziv as PostupakSaRobom,uvNacinPakovanja.Naziv as NacinPakovanja, Napomena as Napomena2,  " +
   "                      (Carinarnice.CINaziv + ' ' + Carinarnice.CIOznaka + ' ' + CIEmail + ' ' + CITelefon + ' / ' + p3.PaNaziv) as Carinarnica,   " +
   "                               p4.PaNaziv as OdredisnaSpedicija, MestoIstovara, KontaktOsoba, Email,        BrojPlombe1, BrojPlombe2,   " +
" PredefinisanePoruke.Naziv as NapomenaZaPozicioniranje,  " +
 " NetoRobe, BrutoRobe, TaraKontejnera, BrutoKontejnera, " +
 " Koleta, green " +
 " FROM Uvoz inner join Partnerji on PaSifra = VlasnikKontejnera " +
 " inner join Partnerji p1 on p1.PaSifra = Uvoznik " +
 " inner join Partnerji p2 on p2.PaSifra = SpedicijaRTC " +
" inner join Partnerji p3 on p3.PaSifra = SpedicijaGranica " +
 "  inner join VrstaRobeHS on VrstaRobeHS.ID = Uvoz.NazivRobe " +
"  inner join NHM on NHM.ID = NHMBroj " +
 " inner join TipKontenjera on TipKontenjera.ID = Uvoz.TipKontejnera " +
 "  inner join Carinarnice on Carinarnice.ID = Uvoz.OdredisnaCarina " +
 "  inner join VrstaCarinskogPostupka on VrstaCarinskogPostupka.ID = Uvoz.CarinskiPostupak " +
 " inner join Predefinisaneporuke on PredefinisanePoruke.ID = Uvoz.NapomenaZaPozicioniranje " +
 "  inner join KontejnerskiTerminali on KontejnerskiTerminali.ID = Uvoz.RLTErminali " +
 "  inner join Partnerji n1 on n1.PaSifra = Nalogodavac1 " +
 "  inner join Partnerji n2 on n2.PaSifra = Nalogodavac2 " +
 "  inner join Partnerji n3 on n3.PaSifra = Nalogodavac3 " +
 "  inner join Partnerji b on b.PaSifra = Uvoz.Brodar " +
  " inner join PredefinisanePoruke pp1 on pp1.ID = DirigacijaKontejeraZa   " +
 "  inner join Brodovi on Brodovi.ID = Uvoz.NazivBroda " +
                              "   inner join VrstaRobeADR on VrstaRobeADR.ID = ADR " +
                              "    inner join VrstePostupakaUvoz on VrstePostupakaUvoz.ID = PostupakSaRobom    inner join uvNacinPakovanja " +
 " on uvNacinPakovanja.ID = NacinPakovanja  inner join Partnerji p4 on p4.PaSifra = OdredisnaSpedicija  order by Uvoz.ID desc ";

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

            RefreshDataGridColor();


        }

        private void RefreshDataGridColor()
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {


                if (row.Cells[46].Value.ToString() == "1")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
                else
                {

                }
            }

            dataGridView1.Refresh();

        }
        private void FillCombo()
        {
            SqlConnection conn = new SqlConnection(connection);

            var dir = "Select ID,Naziv from DirigacijaKontejneraZa order by Naziv";
            var dirAD = new SqlDataAdapter(dir, conn);
            var dirDS = new DataSet();
            dirAD.Fill(dirDS);
            cbDirigacija.DataSource = dirDS.Tables[0];
            cbDirigacija.DisplayMember = "Naziv";
            cbDirigacija.ValueMember = "ID";
            //carinski postupak
            var dir2 = "Select ID, (Oznaka + ' ' + Naziv) as Naziv from VrstaCarinskogPostupka order by Naziv";
            var dirAD2 = new SqlDataAdapter(dir2, conn);
            var dirDS2 = new DataSet();
            dirAD2.Fill(dirDS2);
            cboCarinskiPostupak.DataSource = dirDS2.Tables[0];
            cboCarinskiPostupak.DisplayMember = "Naziv";
            cboCarinskiPostupak.ValueMember = "ID";
            //postupak roba/kont
            var dir3 = "Select ID,Naziv from VrstePostupakaUvoz order by Naziv";
            var dirAD3 = new SqlDataAdapter(dir3, conn);
            var dirDS3 = new DataSet();
            dirAD3.Fill(dirDS3);
            cbPostupak.DataSource = dirDS3.Tables[0];
            cbPostupak.DisplayMember = "Naziv";
            cbPostupak.ValueMember = "ID";
            //nacin pakovanja
            var dir4 = "Select ID,(Oznaka + ' ' + Naziv) as Naziv from uvNacinPakovanja order by Naziv";
            var dirAD4 = new SqlDataAdapter(dir4, conn);
            var dirDS4 = new DataSet();
            dirAD4.Fill(dirDS4);
            cbNacinPakovanja.DataSource = dirDS4.Tables[0];
            cbNacinPakovanja.DisplayMember = "Naziv";
            cbNacinPakovanja.ValueMember = "ID";
            //napomena pozicioniranje
            var dir5 = "Select ID,Naziv from NapomenaZaPozicioniranje order by Naziv";
            var dirAD5 = new SqlDataAdapter(dir5, conn);
            var dirDS5 = new DataSet();
            dirAD5.Fill(dirDS5);
            cbNapomenaPoz.DataSource = dirDS5.Tables[0];
            cbNapomenaPoz.DisplayMember = "Naziv";
            cbNapomenaPoz.ValueMember = "ID";

            var brod = "Select ID,Naziv From Brodovi order by Naziv";
            var brodAD = new SqlDataAdapter(brod, conn);
            var brodDS = new DataSet();
            brodAD.Fill(brodDS);
            cbBrod.DataSource = brodDS.Tables[0];
            cbBrod.DisplayMember = "Naziv";
            cbBrod.ValueMember = "ID";

            var car = "Select ID, Naziv From Carinarnice order by Naziv";
            var carAD = new SqlDataAdapter(car, conn);
            var carDS = new DataSet();
            carAD.Fill(carDS);
            cbOcarina.DataSource = carDS.Tables[0];
            cbOcarina.DisplayMember = "Naziv";
            cbOcarina.ValueMember = "ID";

            var partner = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var partAD = new SqlDataAdapter(partner, conn);
            var partDS = new DataSet();
            partAD.Fill(partDS);
            cbVlasnikKont.DataSource = partDS.Tables[0];
            cbVlasnikKont.DisplayMember = "PaNaziv";
            cbVlasnikKont.ValueMember = "PaSifra";
            //uvoznik
            var partner2 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var partAD2 = new SqlDataAdapter(partner2, conn);
            var partDS2 = new DataSet();
            partAD2.Fill(partDS2);
            cboUvoznik.DataSource = partDS2.Tables[0];
            cboUvoznik.DisplayMember = "PaNaziv";
            cboUvoznik.ValueMember = "PaSifra";
            //spedicija na granici
           
            var partner3 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var partAD3 = new SqlDataAdapter(partner3, conn);
            var partDS3 = new DataSet();
            partAD3.Fill(partDS3);
            cboSpedicijaG.DataSource = partDS3.Tables[0];
            cboSpedicijaG.DisplayMember = "PaNaziv";
            cboSpedicijaG.ValueMember = "PaSifra";
            //spedicija rtc luka leget
            
            var partner4 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var partAD4 = new SqlDataAdapter(partner4, conn);
            var partDS4 = new DataSet();
            partAD4.Fill(partDS4);
            cboSpedicijaRTC.DataSource = partDS4.Tables[0];
            cboSpedicijaRTC.DisplayMember = "PaNaziv";
            cboSpedicijaRTC.ValueMember = "PaSifra";
            //odredisna spedicija
            var partner5 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var partAD5 = new SqlDataAdapter(partner5, conn);
            var partDS5 = new DataSet();
            partAD5.Fill(partDS5);
            cbOspedicija.DataSource = partDS5.Tables[0];
            cbOspedicija.DisplayMember = "PaNaziv";
            cbOspedicija.ValueMember = "PaSifra";

            var tipkontejnera = "Select ID, SkNaziv From TipKontenjera order by SkNaziv";
            var tkAD = new SqlDataAdapter(tipkontejnera, conn);
            var tkDS = new DataSet();
            tkAD.Fill(tkDS);
            txtTipKont.DataSource = tkDS.Tables[0];
            txtTipKont.DisplayMember = "SkNaziv";
            txtTipKont.ValueMember = "ID";



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

            var planutovara = "select UvozKonacnaZaglavlje.ID,(Cast(BrVoza as nvarchar(15)) + ' '  + Relacija) as Naziv from UvozKonacnaZaglavlje " +
            " inner join Voz on Voz.Id = UvozKonacnaZaglavlje.IdVoza order by UvozKonacnaZaglavlje.ID desc";
            var planutovaraSAD = new SqlDataAdapter(planutovara, conn);
            var planutovaraSDS = new DataSet();
            planutovaraSAD.Fill(planutovaraSDS);
            cboPlanUtovara.DataSource = planutovaraSDS.Tables[0];
            cboPlanUtovara.DisplayMember = "Naziv";
            cboPlanUtovara.ValueMember = "ID";

            var adr = "Select ID, (Naziv + ' - ' + UNKod) as Naziv From VrstaRobeADR order by (UNKod + ' ' + Naziv)";
            var adrSAD = new SqlDataAdapter(adr, conn);
            var adrSDS = new DataSet();
            adrSAD.Fill(adrSDS);
            txtADR.DataSource = adrSDS.Tables[0];
            txtADR.DisplayMember = "Naziv";
            txtADR.ValueMember = "ID";

            
            //Kontejnerski terminali
            var rl = "Select ID, (Naziv + ' - ' + Oznaka) as Naziv From KontejnerskiTerminali order by (Naziv + ' ' + Oznaka)";
            var rlSAD = new SqlDataAdapter(rl, conn);
            var rlSDS = new DataSet();
            rlSAD.Fill(rlSDS);
            cboRLTerminal.DataSource = rlSDS.Tables[0];
            cboRLTerminal.DisplayMember = "Naziv";
            cboRLTerminal.ValueMember = "ID";

            var nalogodavac1 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var nal1AD = new SqlDataAdapter(nalogodavac1, conn);
            var nal1DS = new DataSet();
            nal1AD.Fill(nal1DS);
            cboNalogodavac1.DataSource = nal1DS.Tables[0];
            cboNalogodavac1.DisplayMember = "PaNaziv";
            cboNalogodavac1.ValueMember = "PaSifra";

            var nalogodavac2 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var nal2AD = new SqlDataAdapter(nalogodavac2, conn);
            var nal2DS = new DataSet();
            nal2AD.Fill(nal2DS);
            cboNalogodavac2.DataSource = nal2DS.Tables[0];
            cboNalogodavac2.DisplayMember = "PaNaziv";
            cboNalogodavac2.ValueMember = "PaSifra";

            var nalogodavac3 = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var nal3AD = new SqlDataAdapter(nalogodavac3, conn);
            var nal3DS = new DataSet();
            nal3AD.Fill(nal3DS);
            cboNalogodavac3.DataSource = nal3DS.Tables[0];
            cboNalogodavac3.DisplayMember = "PaNaziv";
            cboNalogodavac3.ValueMember = "PaSifra";

            var bro = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            var broAD = new SqlDataAdapter(bro, conn);
            var broDS = new DataSet();
            broAD.Fill(broDS);
            cboBrodar.DataSource = broDS.Tables[0];
            cboBrodar.DisplayMember = "PaNaziv";
            cboBrodar.ValueMember = "PaSifra";

        }
        private void FillCheck()
        {
            var query = "Select PaSifra,PaNaziv From Nalogodavci";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(query, conn);
            var ds = new DataSet();
            da.Fill(ds);
            clNalogodavac.DataSource = ds.Tables[0];
            clNalogodavac.DisplayMember = "PaNaziv";
            clNalogodavac.ValueMember = "PaSifra";

            var select = "Select Naziv,TipManipulacije from VrstaManipulacije";
            var da2 = new SqlDataAdapter(select, conn);
            var ds2 = new DataSet();
            da2.Fill(ds2);
            clVrstaUsluga.DataSource = ds2.Tables[0];
            clVrstaUsluga.DisplayMember = "Naziv";
            clVrstaUsluga.ValueMember = "Naziv";
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
          

            try
            {
                int temp = Convert.ToInt32(txtBrojVoza.Text);
            }
            catch (Exception h)
            {
                MessageBox.Show("Unesite numeričku vrednost Broja voza");
                return;
            }


            if (txtBuking.Text == "")
            { txtBuking.Text = "0"; }
            else
            {
                try
                {
                    int temp = Convert.ToInt32(txtBuking.Text);
                }
                catch (Exception h)
                {
                    MessageBox.Show("Unesite numeričku vrednost Bukinga");
                    return;
                }
            }
          



            for (int i = 0; i < clNalogodavac.Items.Count; i++)
            {
                if (clNalogodavac.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (i == 0)
                    {
                        clNalogodavac.SetSelected(i, true);
                        nalogodavci = clNalogodavac.SelectedValue.ToString();
                    }
                    else
                    {
                        clNalogodavac.SetSelected(i, true);
                        nalogodavci = nalogodavci + "," + clNalogodavac.SelectedValue.ToString();
                    }
                }
            }
            for(int i = 0; i < clVrstaUsluga.Items.Count; i++)
            {
                if (clVrstaUsluga.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (i == 0)
                    {
                        clVrstaUsluga.SetSelected(i, true);
                        usluge = clVrstaUsluga.SelectedValue.ToString();
                    }
                    else
                    {
                        clVrstaUsluga.SetSelected(i, true);
                        usluge = usluge + "," + clVrstaUsluga.SelectedValue.ToString();
                    }
                }
            }
            InsertUvoz ins = new InsertUvoz();
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
            FillGV();
            RefreshDataGridColor();
            tsNew.Enabled = true;
            txtID.Text = "";
        }

        private void clNalogodavac_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void VratiPodatkeSelect(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[EtaBroda] " + 
     " ,[AtaBroda] ,[StatusPrijema] ,[BrojKontejnera] " +
     "  ,[DobijenNalogBrodara]  ,[DobijeBZ]   ,[Napomena]  ,[PIN] " +
     "  ,[DirigacijaKontejeraZa]  ,[NazivBroda]   ,[BrodskaTeretnica] ,[ADR] " +
     "  ,[VlasnikKontejnera]  ,[BukingBrodara]  ,[Nalogodavac]  ,[VrstaUsluge] " +
     "  ,[Uvoznik]  ,[NHMBroj] ,[NazivRobe] ,[SpedicijaGranica] " +
     "  ,[SpedicijaRTC]  ,[CarinskiPostupak] ,[PostupakSaRobom] ,[NacinPakovanja] " +
     "  ,[OdredisnaCarina] ,[OdredisnaSpedicija]  ,[MestoIstovara]  ,[KontaktOsoba] " +
     "  ,[Email]  ,[BrojPlombe1]   ,[BrojPlombe2]  ,[NetoRobe] " +
     "  ,[BrutoRobe] ,[TaraKontejnera]   ,[BrutoKontejnera],[NapomenaZaPozicioniranje] " +
     "  ,[AtaOtpreme]  ,[BrojVoza] ,[RelacijaVoza]  ,[AtaDolazak] " +
     "  ,[TipKontejnera] ,[Koleta]," +
     " RLTErminali , Napomena1 ,VrstaPregleda ,Nalogodavac1 ,Ref1 ,Nalogodavac2 ,Ref2 ,Nalogodavac3 ,Ref3, Brodar " +
 "  FROM [Uvoz] where ID=" + ID, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                dtEtaRijeka.Value = Convert.ToDateTime(dr["EtaBroda"].ToString());
                dtAtaRijeka.Value = Convert.ToDateTime(dr["AtaBroda"].ToString());
                txtStatus.Text = dr["StatusPrijema"].ToString();
                txtBrKont.Text = dr["BrojKontejnera"].ToString();
                txtTipKont.SelectedValue = Convert.ToInt32(dr["TipKontejnera"].ToString());
                dtNalogBrodara.Value = Convert.ToDateTime(dr["DobijenNalogBrodara"].ToString());
                txtBZ.Text = dr["DobijeBZ"].ToString();
                txtNapomena.Text = dr["Napomena"].ToString();
                txtPIN.Text = dr["PIN"].ToString();
                cbDirigacija.SelectedValue = Convert.ToInt32(dr["DirigacijaKontejeraZa"].ToString());
                cbBrod.SelectedValue = Convert.ToInt32(dr["NazivBroda"].ToString());
                txtTeretnica.Text = dr["BrodskaTeretnica"].ToString();
                txtADR.SelectedValue = Convert.ToInt32(dr["ADR"].ToString());
                cbVlasnikKont.SelectedValue = Convert.ToInt32(dr["VlasnikKontejnera"].ToString());
                txtBuking.Text = dr["BukingBrodara"].ToString();
                cboUvoznik.SelectedValue = Convert.ToInt32(dr["Uvoznik"].ToString());
                cboNHM.SelectedValue = 1;
                cboSpedicijaG.SelectedValue = Convert.ToInt32(dr["SpedicijaGranica"].ToString());
                cboSpedicijaRTC.SelectedValue = Convert.ToInt32(dr["SpedicijaRTC"].ToString());
                cboCarinskiPostupak.SelectedValue = Convert.ToInt32(dr["CarinskiPostupak"].ToString());
                cbPostupak.SelectedValue = Convert.ToInt32(dr["PostupakSaRobom"].ToString());
                cbNacinPakovanja.SelectedValue = Convert.ToInt32(dr["NacinPakovanja"].ToString());
                cbOcarina.SelectedValue = Convert.ToInt32(dr["OdredisnaCarina"].ToString());
                cbOspedicija.SelectedValue = Convert.ToInt32(dr["OdredisnaSpedicija"].ToString());
                txtMesto.Text = dr["MestoIstovara"].ToString();
                txtKontaktOsoba.Text = dr["KontaktOsoba"].ToString();
                txtMail.Text = dr["Email"].ToString();
                txtPlomba1.Text = dr["BrojPlombe1"].ToString();
                txtPlomba2.Text = dr["BrojPlombe2"].ToString();
                txtNetoR.Value = Convert.ToDecimal(dr["NetoRobe"].ToString());
                txtBrutoR.Value = Convert.ToDecimal(dr["BrutoRobe"].ToString());
                txtTaraK.Value = Convert.ToDecimal(dr["TaraKontejnera"].ToString());
                txtBrutoK.Value = Convert.ToDecimal(dr["BrutoKontejnera"].ToString());
                cbNapomenaPoz.SelectedValue = Convert.ToInt32(dr["NapomenaZaPozicioniranje"].ToString());
                dtAtaOtprema.Value = Convert.ToDateTime(dr["AtaOtpreme"].ToString());
                txtBrojVoza.Text = dr["BrojVoza"].ToString();
                txtRelacija.Text = dr["RelacijaVoza"].ToString();
                dtAtaDolazak.Value = Convert.ToDateTime(dr["AtaDolazak"].ToString());
                txtKoleta.Value = Convert.ToDecimal(dr["Koleta"].ToString());
                cboRLTerminal.SelectedValue = Convert.ToInt32(dr["RLTerminali"].ToString()); 
                 txtNapomena1.Text = dr["Napomena1"].ToString();
                  txtVrstaPregleda.Text = dr["VrstaPregleda"].ToString();  
                    cboNalogodavac1.SelectedValue = Convert.ToInt32(dr["Nalogodavac1"].ToString());
                    txtRef1.Text = dr["Ref1"].ToString();   
                    cboNalogodavac2.SelectedValue = Convert.ToInt32(dr["Nalogodavac2"].ToString());
                    txtRef2.Text = dr["Ref2"].ToString();
                cboNalogodavac3.SelectedValue=  Convert.ToInt32(dr["Nalogodavac3"].ToString());
                    txtRef3.Text = dr["Ref3"].ToString();

                cboBrodar.SelectedValue = Convert.ToInt32(dr["Brodar"].ToString());
              
                string pomNal = dr["Nalogodavac"].ToString();
                string[] nal = pomNal.Split(',');
                foreach (var word in nal)
                {
                    for (int i = 0; i < nal.Length; i++)
                    {

                        //if (clNalogodavac.GetSelected(i))
                        //{
                        clNalogodavac.SetItemChecked(i, true);
                        //}

                    }
                }
                string pomRob = dr["VrstaUsluge"].ToString();
                string[] rob = pomRob.Split(',');
                foreach (var r in rob)
                {
                    for (int i = 0; i < rob.Length; i++)
                    {
                        clVrstaUsluga.SetItemChecked(i, true);
                    }
                }



            }
        
    

            con.Close();


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    txtID.Text = row.Cells[0].Value.ToString();
                    VratiPodatkeSelect(Convert.ToInt32(txtID.Text));
                    FillDG2();
                    FillDG3();
                    FillDG4();
                    FillDG8();

                }
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertUvoz uv = new InsertUvoz();
            uv.DelUvoz(Convert.ToInt32(txtID.Text));
            FillGV();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            for (int i = 0; i < clNalogodavac.Items.Count; i++)
            {
                if (clNalogodavac.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (i == 0)
                    {
                        clNalogodavac.SetSelected(i, true);
                        nalogodavci = clNalogodavac.SelectedValue.ToString();
                    }
                    else
                    {
                        clNalogodavac.SetSelected(i, true);
                        nalogodavci = nalogodavci + "," + clNalogodavac.SelectedValue.ToString();
                    }
                }
            }
            for (int i = 0; i < clVrstaUsluga.Items.Count; i++)
            {
                if (clVrstaUsluga.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (i == 0)
                    {
                        clVrstaUsluga.SetSelected(i, true);
                        usluge = clVrstaUsluga.SelectedValue.ToString();
                    }
                    else
                    {
                        clVrstaUsluga.SetSelected(i, true);
                        usluge = usluge + "," + clVrstaUsluga.SelectedValue.ToString();
                    }
                }
            }
            uvK.InsUvozKonacna(Convert.ToInt32(txtID.Text), Convert.ToInt32(cboPlanUtovara.SelectedValue),Convert.ToDateTime(dtEtaRijeka.Value.ToString()),
                Convert.ToDateTime(dtAtaRijeka.Value.ToString()), txtStatus.Text.ToString().TrimEnd(), txtBrKont.Text,
                Convert.ToInt32(txtTipKont.SelectedValue), Convert.ToDateTime(dtNalogBrodara.Value.ToString()), txtBZ.Text.ToString().TrimEnd(),
                txtNapomena.Text.ToString().TrimEnd(), txtPIN.Text.ToString().TrimEnd(), Convert.ToInt32(cbDirigacija.SelectedValue), Convert.ToInt32(cbBrod.SelectedValue),
                txtTeretnica.Text, Convert.ToInt32(txtADR.SelectedValue), Convert.ToInt32(cbVlasnikKont.SelectedValue), Convert.ToInt32(txtBuking.Text), nalogodavci,
                usluge, Convert.ToInt32(cboUvoznik.SelectedValue), Convert.ToInt32(cboNHM.SelectedValue), Convert.ToInt32(cboNazivRobe.SelectedValue), Convert.ToInt32(cboSpedicijaG.SelectedValue),
                Convert.ToInt32(cboSpedicijaRTC.SelectedValue), Convert.ToInt32(cboCarinskiPostupak.SelectedValue), Convert.ToInt32(cbPostupak.SelectedValue),
                Convert.ToInt32(cbNacinPakovanja.SelectedValue), Convert.ToInt32(cbOcarina.SelectedValue), Convert.ToInt32(cbOspedicija.SelectedValue),
                txtMesto.Text.ToString().TrimEnd(), txtKontaktOsoba.Text.ToString().TrimEnd(), txtMail.Text.ToString(), txtPlomba1.Text,
                txtPlomba2.Text, Convert.ToDecimal(txtNetoR.Value), Convert.ToDecimal(txtBrutoR.Value), Convert.ToDecimal(txtTaraK.Value),
                Convert.ToDecimal(txtBrutoK.Value), Convert.ToInt32(cbNapomenaPoz.SelectedValue), Convert.ToDateTime(dtAtaOtprema.Value.ToString()),
                Convert.ToInt32(txtBrojVoza.Text), txtRelacija.Text.ToString().TrimEnd(), Convert.ToDateTime(dtAtaDolazak.Value.ToString()), Convert.ToInt32(txtKoleta.Value)
                , Convert.ToInt32(cboRLTerminal.SelectedValue), txtNapomena1.Text, txtVrstaPregleda.Text,
                Convert.ToInt32(cboNalogodavac1.SelectedValue), txtRef1.Text,
                Convert.ToInt32(cboNalogodavac2.SelectedValue), txtRef2.Text,
                Convert.ToInt32(cboNalogodavac3.SelectedValue), txtRef3.Text, Convert.ToInt32(cboBrodar.SelectedValue));

            uvK.PrebaciNHMUvozUvozKonacna(Convert.ToInt32(txtID.Text));
            uvK.PrebaciVrsterobeHSUvozUvozKonacna(Convert.ToInt32(txtID.Text));
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Delete From Uvoz Where ID=" + Convert.ToInt32(txtID.Text), conn);
                conn.Open();
                var q = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            FillGV();
            txtID.Text = "";
            tsNew.Enabled = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmUvozKonacna frm = new frmUvozKonacna();
            frm.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            UvozDokumenta uvdok = new UvozDokumenta(txtID.Text);
            uvdok.Show();
        }

        private void cbNacinPakovanja_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FillDG2()
        {
            var select = " SELECT     UvozNHM.ID, NHM.Broj, UvozNHM.IDNHM, NHM.Naziv FROM NHM INNER JOIN " +
                      " UvozNHM ON NHM.ID = UvozNHM.IDNHM where Uvoznhm.idnadredjena = " + Convert.ToInt32(txtID.Text) + " order by Uvoznhm.ID desc ";
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
            var select = "select UvozVrstaRobeHS.ID, IDVrstaRobeHS, VrstaRobeHS.HSKod as Kod,VrstaRobeHS.Naziv as HS from UvozVrstaRobeHS " +
" inner join  VrstaRobeHS on VrstaRobeHS.ID = UvozVrstaRobeHS.IDVrstaRobeHS where idnadredjena = " + Convert.ToInt32(txtID.Text) + " order by UvozVrstaRobeHS.ID desc ";
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

        private void FillDG4()
        {
            var select = "select UvozNapomenePozicioniranja.ID, IDNapomene, PredefinisanePoruke.Naziv from UvozNapomenePozicioniranja " +
" inner join  PredefinisanePoruke on PredefinisanePoruke.ID = UvozNapomenePozicioniranja.IDNapomene where UvozNapomenePozicioniranja.IdNadredjena = " + Convert.ToInt32(txtID.Text) + " order by UvozNapomenePozicioniranja.ID desc ";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];

            dataGridView4.BorderStyle = BorderStyle.None;
            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView4.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView4.BackgroundColor = Color.White;

            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView4.Columns[0];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[0].Width = 20;

            DataGridViewColumn column2 = dataGridView4.Columns[1];
            dataGridView4.Columns[1].HeaderText = "NapomenaID";
            dataGridView4.Columns[1].Width = 20;

            DataGridViewColumn column3 = dataGridView4.Columns[2];
            dataGridView4.Columns[2].HeaderText = "Napomena";
            dataGridView4.Columns[2].Width = 100;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.InsUvozNHM(Convert.ToInt32(txtID.Text), Convert.ToInt32(cboNHM.SelectedValue));
            FillDG2();
           // refreshdataNHM doraditi
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.DelUvozNHM( Convert.ToInt32(cboNHM.SelectedValue));
            FillDG2();
            // refreshdataNHM doraditi
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

        private void button4_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.InsUvozVrstaRobeHS(Convert.ToInt32(txtID.Text), Convert.ToInt32(cboNHM.SelectedValue));
            FillDG3();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.DelUvozVrstaRobeHS(Convert.ToInt32(cboNHM.SelectedValue));
            FillDG3();
        }

        private void clVrstaUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Uvoz_Load(object sender, EventArgs e)
        {
            RefreshDataGridColor();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.InsUvozNapomenePozicioniranja(Convert.ToInt32(txtID.Text), Convert.ToInt32(cbNapomenaPoz.SelectedValue));
            FillDG4();
            RefreshDataGridColor();
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        txtNapomenaPoz.Text = row.Cells[0].Value.ToString();

                    }
                }
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.DelUvozNapomenePozicioniranja(Convert.ToInt32(txtNapomenaPoz.Text));
            FillDG4();
        }

        private void txtBrutoR_Leave(object sender, EventArgs e)
        {
            txtBrutoK.Value = txtBrutoR.Value + txtTaraK.Value;
        }

        private void txtTaraK_Leave(object sender, EventArgs e)
        {
            txtBrutoK.Value = txtBrutoR.Value + txtTaraK.Value;
        }
        private void UpdateVrednostiPolja(int IdZaPromenu)
        {
            string updatestring = "";
            switch (cboPolje.Text)
            {
                case "Naziv broda":
                    updatestring = " Update uvoz set NazivBroda = " + cbBrod.SelectedValue;
                    break;
                case "Napomena 1":
                    updatestring = " Update uvoz set Napomena1 = '" + txtNapomena1.Text + "'";
                    break;
                case "Datum BZ":
                    updatestring = " Update uvoz set DobijeBZ = '" + txtBZ.Text.ToString().TrimEnd() + "'";
                    break;
                case "PIN":
                    updatestring = " Update uvoz set PIN = '" + txtPIN.Text + "'";
                    break;
                case "Vrsta kontejnera":
                    updatestring = " Update uvoz set TaraKontejnera = " + Convert.ToInt32(txtTipKont.SelectedValue);
                    break;
                case "Relacija R\\L\\SRB":
                    updatestring = " Update uvoz set RLTerminali = " + Convert.ToInt32(cboRLTerminal.SelectedValue);
                    break;
                case "BL":
                    updatestring = " Update uvoz set BrodskaTeretnica = '" + txtTeretnica.Text + "'";
                    break;
                case "ADR":
                    updatestring = " Update uvoz set ADR = " + Convert.ToInt32(txtADR.SelectedValue);
                    break;
                case "Brodar":
                    updatestring = " Update uvoz set Brodar = " + Convert.ToInt32(cboBrodar.SelectedValue);
                    break;
                case "Vlasnik":
                    updatestring = " Update uvoz set Vlasnik = " + Convert.ToInt32(cbVlasnikKont.SelectedValue);
                    break;
                case "Uvoznik":
                    updatestring = " Update uvoz set Uvoznik = " + Convert.ToInt32(cboUvoznik.SelectedValue);
                    break;
                case "Nalogodavac 1":
                    updatestring = " Update uvoz set Nalogodavac1 = " + Convert.ToInt32(cboNalogodavac1.SelectedValue);
                    break;
                case "Ref1":
                    updatestring = " Update uvoz set Ref1 = '" + txtRef1.Text + "'";
                    break;
                case "Nalogodavac 2":
                    updatestring = " Update uvoz set Nalogodavac2 = " + Convert.ToInt32(cboNalogodavac2.SelectedValue);
                    break;
                case "Ref2":
                    updatestring = " Update uvoz set Ref2 = '" + txtRef2.Text + "'";
                    break;
                case "Nalogodavac3":
                    updatestring = " Update uvoz set Nalogodavac3 = " + Convert.ToInt32(cboNalogodavac3.SelectedValue);
                    break;
                case "Ref3":
                    updatestring = " Update uvoz set Ref3 = '" + txtRef3.Text + "'";
                    break;
                case "VrstaPregleda":
                    updatestring = " Update uvoz set VrstaPregleda = '" + txtVrstaPregleda.Text + "'";
                    break;
                case "Špedicija - RTCLeget":
                    updatestring = " Update uvoz set SpedicijaRTC = " + Convert.ToInt32(cboSpedicijaRTC.SelectedValue);
                    break;
                case "Špedicija granica":
                    updatestring = " Update uvoz set SpedicijaGranica = " + Convert.ToInt32(cboSpedicijaG.SelectedValue);
                    break;
                case "Carinski postupak":
                    updatestring = " Update uvoz set CarinskiPostupak = " + Convert.ToInt32(cboCarinskiPostupak.SelectedValue);
                    break;
                case "Postupak sa robom":
                    updatestring = " Update uvoz set PostupakSaRobom = " + Convert.ToInt32(cbPostupak.SelectedValue);
                    break;
                case "Način pakovanja":
                    updatestring = " Update uvoz set NacinPakovanja = " + Convert.ToInt32(cbNacinPakovanja.SelectedValue);
                    break;
                case "Napomena 2":
                    updatestring = " Update uvoz set Napomena2 = " + txtNapomena.Text;
                    break;
                case "Odredišna špedicija":
                    updatestring = " Update uvoz set OdredisnaSpedicija = " + Convert.ToInt32(cbOspedicija.SelectedValue);
                    break;
                case "Carinarnica":
                    updatestring = " Update uvoz set OdredisnaCarina = " + Convert.ToInt32(cbOcarina.SelectedValue);
                    break;
                case "Mesto istovara":
                    updatestring = " Update uvoz set MestoIstovara = '" + txtMesto.Text.ToString().TrimEnd() + "'";
                    break;
                case "Kontakt osoba":
                    updatestring = " Update uvoz set KontaktOsoba = '" + txtKontaktOsoba.Text.ToString().TrimEnd() + "'";
                    break;
                case "EMail":
                    updatestring = " Update uvoz set Email = '" + txtMail.Text.ToString() + "'";
                    break;
                default:
                    Console.WriteLine("Nema podatka");
                    break;

            }


            try
            {
                // 1. Create Command
                // Sql Update Statement
                string updateSql = updatestring + " where ID = " + IdZaPromenu;
               
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(updateSql, conn);
                conn.Open();
                var q = cmd.ExecuteNonQuery();
                conn.Close();

               
            }

            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }



            //FillGV();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int IDZaPromenu = 0;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        IDZaPromenu= Convert.ToInt32(row.Cells[0].Value.ToString());
                        UpdateVrednostiPolja(IDZaPromenu);    
                    }
                }
                FillGV();
                
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cboSpedicijaRTC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtNapomena1_TextChanged(object sender, EventArgs e)
        {

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

        private void button8_Click(object sender, EventArgs e)
        {
            FillDG7();
        }
        private void FillDG7()
        {

            var select = "select Cene.ID, VrstaManipulacije.Naziv, Cene.Cena, VrstaManipulacije.ID from Cene " +
            " inner join VrstaManipulacije on VrstaManipulacije.ID = Cene.VrstaManipulacije " +
            " where TipCenovnika <> 1 and Cene.PostupakSaRobom = " + Convert.ToInt32(cbPostupak.SelectedValue) + " and Cene.Uvoznik = " + Convert.ToInt32(cboUvoznik.SelectedValue) + "  order by VrstaManipulacije.Naziv ";
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

        private void UbaciStavkuUsluge(int ID, int Manipulacija, double Cena)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.InsUbaciUslugu(Convert.ToInt32(txtID.Text), Manipulacija, Cena);
            FillDG8();
        }

        private void FillDG8()
        {
            var select = "select  UvozVrstaManipulacije.ID, VrstaManipulacije.Naziv, UvozVrstaManipulacije.Cena, VrstaManipulacije.ID from UvozVrstaManipulacije "+ 
            " inner join VrstaManipulacije on VrstaManipulacije.ID = UvozVrstaManipulacije.IDVrstaManipulacije "+ 
                " where UvozVrstaManipulacije.IDNadredjena = " + Convert.ToInt32(txtID.Text);
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
    }
}
