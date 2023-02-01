using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Saobracaj.Uvoz
{
    public partial class frmUvozKonacna : Form
    {
        public string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        string nalogodavci = "";
        string usluge = "";
        public frmUvozKonacna()
        {
            InitializeComponent();
            FillCheck();
            FillCombo();
            // FillGV();
        }

        public frmUvozKonacna(int Sifra)
        {
            InitializeComponent(); FillCombo();
            FillZaglavlje(Sifra);
            txtNadredjeni.Text = Sifra.ToString();
            FillCheck();
           
            FillGV();
           // FillDG2(); jos nemam ID
           // FillDG3();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Uvoz uv = new Uvoz();
            uv.Show();
        }

        private void FillZaglavlje(int Sifra)
        {
          
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(s_connection);

                con.Open();

                SqlCommand cmd = new SqlCommand("select ID, idVoza,Napomena from UvozKonacnaZaglavlje where ID=" + Sifra, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                txtNadredjeni.Text = dr["ID"].ToString();
                cboVoz.SelectedValue = Convert.ToInt32(dr["idVoza"].ToString());
                txtNapomenaZaglavlje.Text = dr["Napomena"].ToString();
                  
                }
                con.Close();
            VratiVoz();
        }

        private void VratiVoz()
        {
            var select = "SELECT [ID] ,[BrVoza],[Relacija], " +
                " CONVERT(varchar,VremePolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,VremePolaska,108),1,5) as VremePolaska, " +
                " CONVERT(varchar,[VremeDolaska],104)      + ' '      + SUBSTRING(CONVERT(varchar,[VremeDolaska],108),1,5)  as VremeDolaska, " +
                " [MaksimalnaBruto],[MaksimalnaDuzina] " +
                " ,[MaksimalanBrojKola] " +
                " ,[Napomena]" +
                " ,[PostNaTerminalD] as Postavka,[KontrolniPregledD] as Kontrolni ,[VremePrimopredajeD] as Primopredaja,[VremeIstovaraD] as Istovar" +
                " ,[Datum] ,[Korisnik],[Dolazeci] " +
                " FROM [dbo].[Voz] where ID =  " + Convert.ToInt32(cboVoz.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
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



        }
        private void RefreshDataGridColor()
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {


                if (row.Cells[25].Value.ToString() == "1")
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


        private void FillGV()
        {
            var select = "    SELECT UvozKonacna.ID, BrojKontejnera, BrodskaTeretnica as BL,  DobijenNalogBrodara as Dobijen_Nalog_Brodara ,ATABroda, Brodovi.Naziv as Brod,Napomena1 as Napomena1, DobijeBZ as DatumBZ ,PIN, " +
 " [BrojKontejnera], TipKontenjera.Naziv as Vrsta_Kontejnera,  KontejnerskiTerminali.Naziv as R_L_SRB, pp1.Naziv as Dirigacija_Kontejnera_Za,  " +
 "   BrodskaTeretnica, VrstaRobeADR.Naziv as ADR, b.PaNaziv as Brodar, n1.PaNaziv as Nalogodavac1, Ref1 as Ref1, n2.PaNaziv as Nalogodavac2, Ref2 as Ref2, n3.PaNaziv as Nalogodavac3, Ref3 as Ref3, " +
  "      p1.PaNaziv as Uvoznik,   " +
  "  (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaManipulacije.Naziv as nvarchar(20))   FROM UvozKonacnaVrstaManipulacije " +
   "       inner join VrstaManipulacije on VrstaManipulacije.ID = UvozKonacnaVrstaManipulacije.IDVrstaManipulacije   where UvozKonacnaVrstaManipulacije.IDNadredjena = UvozKonacna.ID " +
   "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as VrsteUsluga,   " +
   "     (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20))   FROM UvozKonacnaVrstaRobeHS " +
   "       inner join VrstaRobeHS on UvozKonacnaVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID   where UvozKonacnaVrstaRobeHS.IDNadredjena = UvozKonacna.ID " +
   "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as HS,   " +
   "    (SELECT  STUFF((SELECT distinct    '/' + Cast(NHM.Broj as nvarchar(20)) " +
  "            FROM UvozKonacnaNHM  inner join NHM on UvozKonacnaNHM.IDNHM = NHM.ID  where UvozKonacnaNHM.IDNadredjena = UvozKOnacna.ID   FOR XML PATH('')), 1, 1, ''  ) As Skupljen) as NHM,   " +
   "              VrstaPregleda as VrstaPregleda,p2.PaNaziv as SpedicijaRTC,  p3.PaNaziv as SpedicijaGranica,      " +
   " VrstaCarinskogPostupka.Naziv as CarinskiPostupak,   " +
   "                  VrstePostupakaUvoz.Naziv as PostupakSaRobom,uvNacinPakovanja.Naziv as NacinPakovanja, Napomena as Napomena2,  " +
   "                      (Carinarnice.CINaziv + ' ' + Carinarnice.CIOznaka + ' ' + CIEmail + ' ' + CITelefon + ' / ' + p3.PaNaziv) as Carinarnica,   " +
   "                               p4.PaNaziv as OdredisnaSpedicija, MestoIstovara, KontaktOsoba, Email,        BrojPlombe1, BrojPlombe2,   " +
" PredefinisanePoruke.Naziv as NapomenaZaPozicioniranje,  " +
 " NetoRobe, BrutoRobe, TaraKontejnera, BrutoKontejnera, " +
 " Koleta" +
 " FROM UvozKonacna inner join Partnerji on PaSifra = VlasnikKontejnera " +
 " inner join Partnerji p1 on p1.PaSifra = Uvoznik " +
 " inner join Partnerji p2 on p2.PaSifra = SpedicijaRTC " +
" inner join Partnerji p3 on p3.PaSifra = SpedicijaGranica " +
 "  inner join VrstaRobeHS on VrstaRobeHS.ID = UvozKonacna.NazivRobe " +
"  inner join NHM on NHM.ID = NHMBroj " +
 " inner join TipKontenjera on TipKontenjera.ID = UvozKonacna.TipKontejnera " +
 "  inner join Carinarnice on Carinarnice.ID = UvozKonacna.OdredisnaCarina " +
 "  inner join VrstaCarinskogPostupka on VrstaCarinskogPostupka.ID = UvozKonacna.CarinskiPostupak " +
 " inner join Predefinisaneporuke on PredefinisanePoruke.ID = UvozKonacna.NapomenaZaPozicioniranje " +
 "  inner join KontejnerskiTerminali on KontejnerskiTerminali.ID = UvozKonacna.RLTErminali " +
 "  inner join Partnerji n1 on n1.PaSifra = Nalogodavac1 " +
 "  inner join Partnerji n2 on n2.PaSifra = Nalogodavac2 " +
 "  inner join Partnerji n3 on n3.PaSifra = Nalogodavac3 " +
 "  inner join Partnerji b on b.PaSifra = UvozKonacna.Brodar " +
  " inner join PredefinisanePoruke pp1 on pp1.ID = DirigacijaKontejeraZa   " +
 "  inner join Brodovi on Brodovi.ID = UvozKonacna.NazivBroda " +
                              "   inner join VrstaRobeADR on VrstaRobeADR.ID = ADR " +
                              "    inner join VrstePostupakaUvoz on VrstePostupakaUvoz.ID = PostupakSaRobom    inner join uvNacinPakovanja " +
 " on uvNacinPakovanja.ID = NacinPakovanja  inner join Partnerji p4 on p4.PaSifra = OdredisnaSpedicija " +
 " where UvozKonacna.IdNadredjeni = " + Convert.ToInt32(txtNadredjeni.Text) + "  order by UvozKonacna.ID desc "; 
          
      
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
        private void FillCombo()
        {
            SqlConnection conn = new SqlConnection(connection);

            var dir = "Select ID,Naziv from DirigacijaKontejneraZa order by ID";
            var dirAD = new SqlDataAdapter(dir, conn);
            var dirDS = new DataSet();
            dirAD.Fill(dirDS);
            cbDirigacija.DataSource = dirDS.Tables[0];
            cbDirigacija.DisplayMember = "Naziv";
            cbDirigacija.ValueMember = "ID";
            //carinski postupak
            
            var dir2 = "Select ID, (Oznaka + ' ' + Naziv) as Naziv from VrstaCarinskogPostupka order by Oznaka";
            var dirAD2 = new SqlDataAdapter(dir2, conn);
            var dirDS2 = new DataSet();
            dirAD2.Fill(dirDS2);
            cboCarinskiPostupak.DataSource = dirDS2.Tables[0];
            cboCarinskiPostupak.DisplayMember = "Naziv";
            cboCarinskiPostupak.ValueMember = "ID";
            //postupak roba/kont
            
            var dir3 = "Select ID,Naziv from VrstePostupakaUvoz order by ID";
            var dirAD3 = new SqlDataAdapter(dir3, conn);
            var dirDS3 = new DataSet();
            dirAD3.Fill(dirDS3);
            cbPostupak.DataSource = dirDS3.Tables[0];
            cbPostupak.DisplayMember = "Naziv";
            cbPostupak.ValueMember = "ID";
            //nacin pakovanja
            
            var dir4 = "Select ID,(Oznaka + ' ' + Naziv) as Naziv from uvNacinPakovanja order by ID";
            var dirAD4 = new SqlDataAdapter(dir4, conn);
            var dirDS4 = new DataSet();
            dirAD4.Fill(dirDS4);
            cbNacinPakovanja.DataSource = dirDS4.Tables[0];
            cbNacinPakovanja.DisplayMember = "Naziv";
            cbNacinPakovanja.ValueMember = "ID";
            //napomena pozicioniranje
            
            var dir5 = "Select ID,Naziv from PredefinisanePoruke order by ID";
            var dirAD5 = new SqlDataAdapter(dir5, conn);
            var dirDS5 = new DataSet();
            dirAD5.Fill(dirDS5);
            cbNapomenaPoz.DataSource = dirDS5.Tables[0];
            cbNapomenaPoz.DisplayMember = "Naziv";
            cbNapomenaPoz.ValueMember = "ID";

            var brod = "Select ID,Naziv From Brodovi order by ID";
            var brodAD = new SqlDataAdapter(brod, conn);
            var brodDS = new DataSet();
            brodAD.Fill(brodDS);
            cbBrod.DataSource = brodDS.Tables[0];
            cbBrod.DisplayMember = "Naziv";
            cbBrod.ValueMember = "ID";

            var car = "Select ID,Naziv From Carinarnice order by ID";
            var carAD = new SqlDataAdapter(car, conn);
            var carDS = new DataSet();
            carAD.Fill(carDS);
            cbOcarina.DataSource = carDS.Tables[0];
            cbOcarina.DisplayMember = "Naziv";
            cbOcarina.ValueMember = "ID";

            var partner = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD = new SqlDataAdapter(partner, conn);
            var partDS = new DataSet();
            partAD.Fill(partDS);
            cbVlasnikKont.DataSource = partDS.Tables[0];
            cbVlasnikKont.DisplayMember = "PaNaziv";
            cbVlasnikKont.ValueMember = "PaSifra";
            //uvoznik
            var partner2 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD2 = new SqlDataAdapter(partner2, conn);
            var partDS2 = new DataSet();
            partAD2.Fill(partDS2);
            cboUvoznik.DataSource = partDS2.Tables[0];
            cboUvoznik.DisplayMember = "PaNaziv";
            cboUvoznik.ValueMember = "PaSifra";
            //spedicija na granici
           
            var partner3 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD3 = new SqlDataAdapter(partner3, conn);
            var partDS3 = new DataSet();
            partAD3.Fill(partDS3);
            cboSpedicijaG.DataSource = partDS3.Tables[0];
            cboSpedicijaG.DisplayMember = "PaNaziv";
            cboSpedicijaG.ValueMember = "PaSifra";
            //spedicija rtc luka leget
           
            var partner4 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD4 = new SqlDataAdapter(partner4, conn);
            var partDS4 = new DataSet();
            partAD4.Fill(partDS4);
            cboSpedicijaRTC.DataSource = partDS4.Tables[0];
            cboSpedicijaRTC.DisplayMember = "PaNaziv";
            cboSpedicijaRTC.ValueMember = "PaSifra";
            //odredisna spedicija
            var partner5 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD5 = new SqlDataAdapter(partner5, conn);
            var partDS5 = new DataSet();
            partAD5.Fill(partDS5);
            cbOspedicija.DataSource = partDS5.Tables[0];
            cbOspedicija.DisplayMember = "PaNaziv";
            cbOspedicija.ValueMember = "PaSifra";
            //Panta
            var VRHS = "Select ID,(HSKod + ' ' + Rtrim(Naziv)) as Naziv from VrstaRobeHS order by HSKod";
            var VRHSAD = new SqlDataAdapter(VRHS, conn);
            var VRHSDS = new DataSet();
            VRHSAD.Fill(VRHSDS);
            cboNazivRobe.DataSource = VRHSDS.Tables[0];
            cboNazivRobe.DisplayMember = "Naziv";
            cboNazivRobe.ValueMember = "ID";


            var nhm = "Select ID,(Rtrim(Broj) + '-' + Naziv) as Naziv from NHM order by Broj ";
            var nhmSAD = new SqlDataAdapter(nhm, conn);
            var nhmSDS = new DataSet();
            nhmSAD.Fill(nhmSDS);
            cboNHM.DataSource = nhmSDS.Tables[0];
            cboNHM.DisplayMember = "Naziv";
            cboNHM.ValueMember = "ID";
            //Panta

            var voz = "select ID, (Cast(ID as NVarChar(10)) + '-'+Cast(BrVoza as NVarchar(15)) + '-' + Relacija + '-' + Cast(VremePolaska as nvarchar(20))) as Naziv   from Voz ";
            var vozSAD = new SqlDataAdapter(voz, conn);
            var vozSDS = new DataSet();
            vozSAD.Fill(vozSDS);
            cboVoz.DataSource = vozSDS.Tables[0];
            cboVoz.DisplayMember = "Naziv";
            cboVoz.ValueMember = "ID";

            var adr = "Select ID, (UNKod + ' ' + Naziv) as Naziv From VrstaRobeADR order by ID";
            var adrSAD = new SqlDataAdapter(adr, conn);
            var adrSDS = new DataSet();
            adrSAD.Fill(adrSDS);
            txtADR.DataSource = adrSDS.Tables[0];
            txtADR.DisplayMember = "Naziv";
            txtADR.ValueMember = "ID";

            var tipkontejnera = "Select ID, SkNaziv From TipKontenjera order by id";
            var tkAD = new SqlDataAdapter(tipkontejnera, conn);
            var tkDS = new DataSet();
            tkAD.Fill(tkDS);
            txtTipKont.DataSource = tkDS.Tables[0];
            txtTipKont.DisplayMember = "SkNaziv";
            txtTipKont.ValueMember = "ID";

            //Kontejnerski terminali
            var rl = "Select ID, (Oznaka + ' ' + Naziv) as Naziv From KontejnerskiTerminali order by ID";
            var rlSAD = new SqlDataAdapter(rl, conn);
            var rlSDS = new DataSet();
            rlSAD.Fill(rlSDS);
            cboRLTerminal.DataSource = rlSDS.Tables[0];
            cboRLTerminal.DisplayMember = "Naziv";
            cboRLTerminal.ValueMember = "ID";

            var partner7 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD7 = new SqlDataAdapter(partner7, conn);
            var partDS7 = new DataSet();
            partAD7.Fill(partDS7);
            cboBrodar.DataSource = partDS7.Tables[0];
            cboBrodar.DisplayMember = "PaNaziv";
            cboBrodar.ValueMember = "PaSifra";

            var partner8 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD8 = new SqlDataAdapter(partner8, conn);
            var partDS8 = new DataSet();
            partAD8.Fill(partDS8);
            cboNalogodavac1.DataSource = partDS8.Tables[0];
            cboNalogodavac1.DisplayMember = "PaNaziv";
            cboNalogodavac1.ValueMember = "PaSifra";

            var partner9 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD9 = new SqlDataAdapter(partner9, conn);
            var partDS9 = new DataSet();
            partAD9.Fill(partDS9);
            cboNalogodavac2.DataSource = partDS9.Tables[0];
            cboNalogodavac2.DisplayMember = "PaNaziv";
            cboNalogodavac2.ValueMember = "PaSifra";

            var partner10 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD10 = new SqlDataAdapter(partner10, conn);
            var partDS10 = new DataSet();
            partAD9.Fill(partDS10);
            cboNalogodavac3.DataSource = partDS10.Tables[0];
            cboNalogodavac3.DisplayMember = "PaNaziv";
            cboNalogodavac3.ValueMember = "PaSifra";


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

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uv = new InsertUvozKonacna();
            uv.DelUvozKonacna(Convert.ToInt32(txtID.Text));
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
     "  ,[TipKontejnera] ,[Koleta], RLTerminali, BrojKola, Napomena1 ,VrstaPregleda ,Nalogodavac1 ,Ref1 ,Nalogodavac2 ,Ref2 ,Nalogodavac3 ,Ref3, Brodar " +
 "  FROM [UvozKonacna] where ID=" + ID, con);
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
                txtBrojKola2.Text = dr["BrojKola"].ToString();

                txtNapomena1.Text = dr["Napomena1"].ToString();
                txtVrstaPregleda.Text = dr["VrstaPregleda"].ToString();
                cboNalogodavac1.SelectedValue = Convert.ToInt32(dr["Nalogodavac1"].ToString());
                txtRef1.Text = dr["Ref1"].ToString();
                cboNalogodavac2.SelectedValue = Convert.ToInt32(dr["Nalogodavac2"].ToString());
                txtRef2.Text = dr["Ref2"].ToString();
                cboNalogodavac3.SelectedValue = Convert.ToInt32(dr["Nalogodavac3"].ToString());
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

        private void tsSave_Click(object sender, EventArgs e)
        {
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
            InsertUvozKonacna ins = new InsertUvozKonacna();
            ins.UpdUvozKonacna(Convert.ToInt32(txtID.Text), Convert.ToInt32(txtNadredjeni.Text), Convert.ToDateTime(dtEtaRijeka.Value.ToString()),
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
                Convert.ToInt32(txtBrojVoza.Text), txtRelacija.Text.ToString().TrimEnd(), Convert.ToDateTime(dtAtaDolazak.Value.ToString()), Convert.ToInt32(txtKoleta.Value), Convert.ToInt32(cboRLTerminal.SelectedValue),
                txtNapomena1.Text, txtVrstaPregleda.Text,
                Convert.ToInt32(cboNalogodavac1.SelectedValue), txtRef1.Text,
                Convert.ToInt32(cboNalogodavac2.SelectedValue), txtRef2.Text,
                Convert.ToInt32(cboNalogodavac3.SelectedValue), txtRef3.Text, Convert.ToInt32(cboBrodar.SelectedValue));
            FillGV();
            RefreshDataGridColor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertUvozKonacnaZaglavlje ins = new InsertUvozKonacnaZaglavlje();
            ins.InsUvozKonacnaZaglavlje(Convert.ToInt32(cboVoz.SelectedValue), txtNapomenaZaglavlje.Text,1,"",Convert.ToDateTime("1.1.1900"),"","");
            //refreshStavke(); - Dodati
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var select = "SELECT row_number() OVER (ORDER BY UvozKonacna.ID) RB, AtaBroda, " +
     "  BrojKontejnera,TipKontenjera.Naziv as TipKontejnera,  PIN, Brodovi.Naziv as Brod, BrodskaTeretnica, " +
     " (VrstaRobeAdr.Naziv + +VrstaRobeAdr.UnKod) as ADR, " +
     "    Partnerji.PaNaziv as Primalac, Partnerji.PaEMatSt1 as PIB, (Cast(BrojPlombe1 as nvarchar(25)) + '/' + Cast(BrojPlombe2 as nvarchar(25))) as Plombe, " +
      "    (" +
 "  SELECT " +
 "  STUFF(" +
"  (" +
"  SELECT distinct " +
 "  '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20)) " +
"  FROM UvozVrstaRobeHS " +
"  inner join VrstaRobeHS on UvozVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID " +
"  where UvozVrstaRobeHS.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
"   ), 1, 1, '' " +
"  ) As Skupljen) as VrsteRobe,  " +
"  (" +
"  SELECT " +
 "  STUFF(" +
"  (" +
 "  SELECT distinct " +
 "  '/' + Cast(NHM.Broj as nvarchar(20)) " +
"  FROM UvozNHM " +
"  inner join NHM on UvozNHM.IDNHM = NHM.ID " +
"   where UvozNHM.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
"   ), 1, 1, '' " +
"   ) As Skupljen) as NHM,  " +
 "        Koleta as Koleta, TaraKontejnera as Tara, BrutoRobe as Masarobe, BrutoKontejnera as ukupnatezina, 0 as K447, 0 as tezinapok447 " +
 "        FROM UvozKonacna " +
 " inner join Brodovi on Brodovi.ID = UvozKonacna.NazivBroda " +
 "        inner join Partnerji on PaSifra = VlasnikKontejnera " +
  "        inner join TipKontenjera on TipKontenjera.Id = UvozKonacna.TipKontejnera " +
   "    left join VrstaRobeADR on VrstaRobeADR.ID = UvozKonacna.ADR " +
"  Where UvozKonacna.IDNadredjeni = " + Convert.ToInt32(txtNadredjeni.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var ds = new DataSet();
            dataAdapter.Fill(ds);

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            object missing = System.Reflection.Missing.Value;
            Workbook wBook = excel.Workbooks.Add(missing);

            Worksheet wSheet = new Worksheet();
            try
            {

                wSheet = (Worksheet)wBook.Worksheets.get_Item(1);
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        wSheet.Cells[1, 15].EntireRow.Font.Bold = true;
                        wSheet.Range["A1:Q1"].Interior.Color = System.Drawing.Color.AliceBlue;
                        wSheet.Cells[1, "A"] = "RB";
                        wSheet.Cells[1, "B"] = "Atabroda";
                        wSheet.Cells[1, "C"] = "Broj kontejnera";
                        wSheet.Cells[1, "D"] = "Tip Kontejnera";
                        wSheet.Cells[1, "E"] = "PIN";
                        wSheet.Cells[1, "F"] = "Brod";
                        wSheet.Cells[1, "G"] = "Brodska teretnica";
                        wSheet.Cells[1, "H"] = "ADR";
                        wSheet.Cells[1, "I"] = "Partner";
                        wSheet.Cells[1, "J"] = "PIB";
                        wSheet.Cells[1, "K"] = "Plombe";
                        wSheet.Cells[1, "L"] = "Roba";
                        wSheet.Cells[1, "M"] = "NHM";
                        wSheet.Cells[1, "J"] = "Koleta";
                        wSheet.Cells[1, "N"] = "Tara";
                        wSheet.Cells[1, "O"] = "MasaRobe";
                        wSheet.Cells[1, "P"] = "UkupnaTezina";
                        wSheet.Cells[1, "Q"] = "K447";
                        wSheet.Cells[1, "R"] = "P447";
                       
                        wSheet.Cells[i + 2, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        wSheet.Cells[i + 2, j + 1].EntireColumn.AutoFit();
                        Borders border = wSheet.Cells[i + 2, j + 1].Borders;
                        border.Weight = 2d;

                    }
                }

                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                object filename = @"VLeget A106" + date + ".xlsx";
                wBook.SaveAs(filename);
                wBook.Close();
                excel.Quit();
                excel = null;
                wBook = null;
                wSheet = null;


                MessageBox.Show("Dokument je kreiran");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void tsNew_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.InsUvozKonacnaNHM(Convert.ToInt32(txtID.Text), Convert.ToInt32(cboNHM.SelectedValue));
            FillDG2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.DelUvozKonacnaNHM(Convert.ToInt32(cboNHM.SelectedValue));
            FillDG2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.InsUvozKonacnaVrstaRobeHS(Convert.ToInt32(txtID.Text), Convert.ToInt32(cboNazivRobe.SelectedValue));
            FillDG3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.DelUvozKonacnaVrstaRobeHS(Convert.ToInt32(cboNHM.SelectedValue));
            FillDG3();
        }

        private void FillDG2()
        {
            var select = "  SELECT     UvozKonacnaNHM.ID, NHM.Broj, UvozKonacnaNHM.IDNHM, NHM.Naziv FROM NHM INNER JOIN " +
                      " UvozKonacnaNHM ON NHM.ID = UvozKonacnaNHM.IDNHM where UvozKonacnanhm.idnadredjena = " + Convert.ToInt32(txtID.Text) + " order by UvozKonacnanhm.ID desc"; 
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
            dataGridView2.Columns[1].HeaderText = "NHM Broj";
            dataGridView2.Columns[1].Width = 70;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "ID";
            dataGridView2.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "NHM";
            dataGridView2.Columns[3].Width = 150;


        }

        private void FillDG3()
        {
            var select = "select UvozKonacnaVrstaRobeHS.ID,  VrstaRobeHS.HSKod, IDVrstaRobeHS, VrstaRobeHS.Naziv from UvozKonacnaVrstaRobeHS " +
" inner join  VrstaRobeHS on VrstaRobeHS.ID = UvozKonacnaVrstaRobeHS.IDVrstaRobeHS where idnadredjena = " + Convert.ToInt32(txtID.Text) + " order by UvozKonacnaVrstaRobeHS.ID desc ";
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
            dataGridView3.Columns[1].HeaderText = "VRID";
            dataGridView3.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "VRKOD";
            dataGridView3.Columns[2].Width = 80;


            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "VRNaziv";
            dataGridView3.Columns[3].Width = 180;

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

        private void UvozKonacna_Load(object sender, EventArgs e)
        {
            RefreshDataGridColor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertUvozKonacnaZaglavlje upd = new InsertUvozKonacnaZaglavlje();
            upd.UpdUvozKonacnaZaglavlje(Convert.ToInt32(txtNadredjeni.Text), Convert.ToInt32(cboVoz.SelectedValue),txtNapomenaZaglavlje.Text, 1, "", Convert.ToDateTime("1.1.1900"), "", "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertUvozKonacnaZaglavlje del = new InsertUvozKonacnaZaglavlje();
            del.DelUvozKonacnaZaglavlje(Convert.ToInt32(txtNadredjeni.Text));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var select = "SELECT row_number() OVER (ORDER BY UvozKonacna.ID) RB, " +
    "    [EtaBroda],[BrojKontejnera], TipKontenjera.Naziv,UvozKonacna.Napomena, " +
    "    KontejnerskiTerminali.Naziv as RLTerminal, BrodskaTeretnica, (VrstaRobeAdr.Naziv +  + VrstaRobeAdr.UnKod) as ADR , Partnerji.PaNaziv as Vlasnik, Partnerji.PaEMatSt1 as VlasnikPIB,nalogodavac, " +
     "    p1.PaNaziv as Uvoznik, p1.PaEMatSt1 as UvoznikPIB,  " +
" ( " +
" SELECT " +
" STUFF(" +
"  (" +
"  SELECT distinct " +
"   '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20)) " +
 "  FROM UvozKonacnaVrstaRobeHS " +
 "  inner join VrstaRobeHS on UvozKonacnaVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID " +
" where UvozKonacnaVrstaRobeHS.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
"   ), 1, 1, '' " +
 " ) As Skupljen) as VrsteRobe,  " +
 " (" +
" SELECT " +
" STUFF(" +
"  (" +
"  SELECT distinct " +
"   '/' + Cast(NHM.Broj as nvarchar(20)) " +
 "  FROM UvozKonacnaNHM " +
 "  inner join NHM on UvozKonacnaNHM.IDNHM = NHM.ID " +
" where UvozKonacnaNHM.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
 "  ), 1, 1, '' " +
 " ) As Skupljen) as NHM, " +
 " p2.PaNaziv as SpedicijaRTC, " +
 " VrstaCarinskogPostupka.Naziv as CarinskiPostupak, " +
 "  PostupakSarobom, Napomena,  " +
   "     (Carinarnice.CINaziv + ' ' + Carinarnice.CIOznaka + ' ' + CIEmail + ' ' + CITelefon + ' / ' + p3.PaNaziv) as Carinarnica, " +
   "     (MestoIstovara + ' ' + KontaktOsoba) as MestoIstovara, Email, " +
   "     PredefinisanePoruke.Naziv as NapomenaZaPozicioniranje, NetoRobe, BrutoRobe, TaraKontejnera, BrutoKontejnera, Koleta " +
   "     FROM UvozKonacna " +
   "     inner join Partnerji on PaSifra = VlasnikKontejnera " +
    "    inner join Partnerji p1 on p1.PaSifra = Uvoznik " +
    "      inner join Partnerji p2 on p2.PaSifra = SpedicijaRTC " +
    "       inner join Partnerji p3 on p3.PaSifra = SpedicijaGranica " +
   "    left join VrstaRobeHS on VrstaRobeHS.ID = UvozKonacna.NazivRobe " +
   "    left join VrstaRobe on VrstaRobe.ID = NHMBroj " +
   "    left join VrstaRobeADR on VrstaRobeADR.ID = UvozKonacna.ADR " +
    "   left join TipKontenjera on TipKontenjera.ID = UvozKonacna.TipKontejnera " +
   "     left join Carinarnice on Carinarnice.ID = UvozKonacna.OdredisnaCarina " +
    "     left join KontejnerskiTerminali on KontejnerskiTerminali.ID = UvozKonacna.RLTerminali " +
   "    left join VrstaCarinskogPostupka on VrstaCarinskogPostupka.ID = UvozKonacna.CarinskiPostupak " +
   "    left join Predefinisaneporuke on PredefinisanePoruke.ID = UvozKonacna.NapomenaZaPozicioniranje " +
   "   Where UvozKonacna.IDNadredjeni = " + Convert.ToInt32(txtNadredjeni.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var ds = new DataSet();
            dataAdapter.Fill(ds);

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            object missing = System.Reflection.Missing.Value;
            Workbook wBook = excel.Workbooks.Add(missing);

            Worksheet wSheet = new Worksheet();
            try
            {

                wSheet = (Worksheet)wBook.Worksheets.get_Item(1);
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        wSheet.Cells[1, 15].EntireRow.Font.Bold = true;
                        wSheet.Range["A1:N1"].Interior.Color = System.Drawing.Color.AliceBlue;
                        wSheet.Cells[1, "A"] = "RB";
                        wSheet.Cells[1, "B"] = "ETA dolazak broda u Luku Rijeka";
                        wSheet.Cells[1, "C"] = "Broj kontejnera";
                        wSheet.Cells[1, "D"] = "Tip kontejnera";
                        wSheet.Cells[1, "E"] = "Napomena za stavku";
                        wSheet.Cells[1, "F"] = "R/L/drugi terminal";
                        wSheet.Cells[1, "G"] = "BL-brodska tertnica";
                        wSheet.Cells[1, "H"] = "ADR";
                        wSheet.Cells[1, "I"] = "Vlasnik kontejnera";
                        wSheet.Cells[1, "J"] = "Vlasnik PIB";
                        wSheet.Cells[1, "K"] = "Nalogodavaci";
                        wSheet.Cells[1, "L"] = "Uvoznik";
                        wSheet.Cells[1, "M"] = "Uvoznik PIB";
                        wSheet.Cells[1, "N"] = "Vrsta robe";
                        wSheet.Cells[1, "O"] = "NHM";
                        wSheet.Cells[1, "P"] = "Špedicija - Leget";
                        wSheet.Cells[1, "Q"] = "Carinski postupak";
                        wSheet.Cells[1, "R"] = "Postupanje sa robom/kontejeromnt";
                        wSheet.Cells[1, "S"] = "Napomena za RTC LUKA LEGET";
                        wSheet.Cells[1, "T"] = "Odredišna Carinska ispostav+špedicija";
                       
                        wSheet.Cells[1, "U"] = "Mesto istovara+kontakt osoba";
                        wSheet.Cells[1, "V"] = "e-mail adrese za slanje statusa";
                        wSheet.Cells[1, "W"] = "Napomena za pozicioniranje kontejner";
                        wSheet.Cells[1, "X"] = "Neto robe (kg)";
                        wSheet.Cells[1, "Y"] = "Bruto robe (kg)";
                        wSheet.Cells[1, "Z"] = "Tara kontejnera (kg)";
                        wSheet.Cells[1, "AA"] = "Bruto kontejnera (kg)";
                     


                        wSheet.Cells[i + 2, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        wSheet.Cells[i + 2, j + 1].EntireColumn.AutoFit();
                        Borders border = wSheet.Cells[i + 2, j + 1].Borders;
                        border.Weight = 2d;

                    }
                }

                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                object filename = @"ExportDrumski" + date+ ".xlsx";
                wBook.SaveAs(filename);
                wBook.Close();
                excel.Quit();
                excel = null;
                wBook = null;
                wSheet = null;


                MessageBox.Show("Dokument za drumski prevoz je kreiran");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
                var select = "SELECT row_number() OVER (ORDER BY UvozKonacna.ID) RB, " +
    "    [EtaBroda],[BrojKontejnera], TipKontenjera.Naziv,UvozKonacna.Napomena, " +
    "    KontejnerskiTerminali.Naziv as RLTerminal, BrodskaTeretnica, ADR, Partnerji.PaNaziv as Vlasnik, Partnerji.PaEMatSt1 as VlasnikPIB,nalogodavac, " +
     "    p1.PaNaziv as Uvoznik, p1.PaEMatSt1 as UvoznikPIB,  " +
" ( " +
" SELECT " +
" STUFF(" +
"  (" +
"  SELECT distinct " +
"   '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20)) " +
 "  FROM UvozKonacnaVrstaRobeHS " +
 "  inner join VrstaRobeHS on UvozKonacnaVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID " +
" where UvozKonacnaVrstaRobeHS.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
"   ), 1, 1, '' " +
 " ) As Skupljen) as VrsteRobe,  " +
 " (" +
" SELECT " +
" STUFF(" +
"  (" +
"  SELECT distinct " +
"   '/' + Cast(NHM.Broj as nvarchar(20)) " +
 "  FROM UvozKonacnaNHM " +
 "  inner join NHM on UvozKonacnaNHM.IDNHM = NHM.ID " +
" where UvozKonacnaNHM.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
 "  ), 1, 1, '' " +
 " ) As Skupljen) as NHM, " +
 " p2.PaNaziv as SpedicijaRTC, " +
 " VrstaCarinskogPostupka.Naziv as CarinskiPostupak, " +
 "  PostupakSarobom, Napomena,  " +
   "     (Carinarnice.CINaziv + ' ' + Carinarnice.CIOznaka + ' ' + CIEmail + ' ' + CITelefon + ' / ' + p3.PaNaziv) as Carinarnica, " +
   "     (MestoIstovara + ' ' + KontaktOsoba) as MestoIstovara, "+
   "     PredefinisanePoruke.Naziv as NapomenaZaPozicioniranje, NetoRobe, BrutoRobe, TaraKontejnera, BrutoKontejnera, Koleta " +
   "     FROM UvozKonacna " +
   "     inner join Partnerji on PaSifra = VlasnikKontejnera " +
    "    inner join Partnerji p1 on p1.PaSifra = Uvoznik " +
    "      inner join Partnerji p2 on p2.PaSifra = SpedicijaRTC " +
    "       inner join Partnerji p3 on p3.PaSifra = SpedicijaGranica " +
   "    left join VrstaRobeHS on VrstaRobeHS.ID = UvozKonacna.NazivRobe " +
   "    left join VrstaRobe on VrstaRobe.ID = NHMBroj " +
    "   left join TipKontenjera on TipKontenjera.ID = UvozKonacna.TipKontejnera " +
   "     left join Carinarnice on Carinarnice.ID = UvozKonacna.OdredisnaCarina " +
    "     left join KontejnerskiTerminali on KontejnerskiTerminali.ID = UvozKonacna.RLTerminali " +
   "    left join VrstaCarinskogPostupka on VrstaCarinskogPostupka.ID = UvozKonacna.CarinskiPostupak " +
   "    left join Predefinisaneporuke on PredefinisanePoruke.ID = UvozKonacna.NapomenaZaPozicioniranje " +
   "   Where UvozKonacna.IDNadredjeni = " + Convert.ToInt32(txtNadredjeni.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var ds = new DataSet();
            dataAdapter.Fill(ds);

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            object missing = System.Reflection.Missing.Value;
            Workbook wBook = excel.Workbooks.Add(missing);

            Worksheet wSheet = new Worksheet();
            try
            {

                wSheet = (Worksheet)wBook.Worksheets.get_Item(1);
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        wSheet.Cells[1, 15].EntireRow.Font.Bold = true;
                        wSheet.Range["A1:N1"].Interior.Color = System.Drawing.Color.AliceBlue;
                        wSheet.Cells[1, "A"] = "RB";
                        wSheet.Cells[1, "B"] = "ETA dolazak broda u Luku Rijeka";
                        wSheet.Cells[1, "C"] = "Broj kontejnera";
                        wSheet.Cells[1, "D"] = "Tip kontejnera";
                        wSheet.Cells[1, "E"] = "Napomena za stavku";
                        wSheet.Cells[1, "F"] = "R/L/drugi terminal";
                        wSheet.Cells[1, "G"] = "BL-brodska tertnica";
                        wSheet.Cells[1, "H"] = "ADR";
                        wSheet.Cells[1, "I"] = "Vlasnik kontejnera";
                        wSheet.Cells[1, "J"] = "Vlasnik PIB";
                        wSheet.Cells[1, "K"] = "Nalogodavaci";
                        wSheet.Cells[1, "L"] = "Uvoznik";
                        wSheet.Cells[1, "M"] = "Uvoznik PIB";
                        wSheet.Cells[1, "N"] = "Vrsta robe";
                        wSheet.Cells[1, "O"] = "NHM";
                        wSheet.Cells[1, "P"] = "Špedicija - Leget";
                        wSheet.Cells[1, "Q"] = "Carinski postupak";
                        wSheet.Cells[1, "R"] = "Postupanje sa robom/kontejeromnt";
                        wSheet.Cells[1, "S"] = "Napomena za RTC LUKA LEGET";
                        wSheet.Cells[1, "T"] = "Odredišna Carinska ispostav+špedicija";
                       
                        wSheet.Cells[1, "U"] = "Mesto istovara+kontakt osoba";
                        wSheet.Cells[1, "V"] = "Napomena za pozicioniranje kontejner";
                        wSheet.Cells[1, "W"] = "Neto robe (kg)";
                        wSheet.Cells[1, "X"] = "Bruto robe (kg)";
                        wSheet.Cells[1, "Y"] = "Tara kontejnera (kg)";
                        wSheet.Cells[1, "Z"] = "Bruto kontejnera (kg)";
                        wSheet.Cells[1, "AA"] = "Koleta";
                        // wSheet.Cells[1, "Z"] = "Bruto kontejnera (kg)";



                        wSheet.Cells[i + 2, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        wSheet.Cells[i + 2, j + 1].EntireColumn.AutoFit();
                        Borders border = wSheet.Cells[i + 2, j + 1].Borders;
                        border.Weight = 2d;

                    }
                }

                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                object filename = @"ExportMagacin" + date+ ".xlsx";
                wBook.SaveAs(filename);
                wBook.Close();
                excel.Quit();
                excel = null;
                wBook = null;
                wSheet = null;


                MessageBox.Show("Dokument za drumski prevoz je kreiran");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var select = "SELECT row_number() OVER (ORDER BY UvozKonacna.ID) RB, " +
 "    [EtaBroda],[BrojKontejnera], TipKontenjera.Naziv, " +
 "     BrodskaTeretnica, ADR, Partnerji.PaNaziv as Vlasnik, Partnerji.PaEMatSt1 as VlasnikPIB,nalogodavac, " +
  "    p1.PaNaziv as Uvoznik, p1.PaEMatSt1 as UvoznikPIB,  " +
" ( " +
" SELECT " +
" STUFF(" +
"  (" +
"  SELECT distinct " +
"   '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20)) " +
"  FROM UvozKonacnaVrstaRobeHS " +
"  inner join VrstaRobeHS on UvozKonacnaVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID " +
" where UvozKonacnaVrstaRobeHS.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
"   ), 1, 1, '' " +
" ) As Skupljen) as VrsteRobe,  " +
" (" +
" SELECT " +
" STUFF(" +
"  (" +
"  SELECT distinct " +
"   '/' + Cast(RTRIM(NHM.Broj) as nvarchar(20)) " +
"  FROM UvozKonacnaNHM " +
"  inner join NHM on UvozKonacnaNHM.IDNHM = NHM.ID " +
" where UvozKonacnaNHM.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
"  ), 1, 1, '' " +
" ) As Skupljen) as NHM, " +
"    NetoRobe, BrutoRobe, TaraKontejnera, BrutoKontejnera, Koleta " +
"     FROM UvozKonacna " +
"     inner join Partnerji on PaSifra = VlasnikKontejnera " +
 "    inner join Partnerji p1 on p1.PaSifra = Uvoznik " +
 "      inner join Partnerji p2 on p2.PaSifra = SpedicijaRTC " +
 "       inner join Partnerji p3 on p3.PaSifra = SpedicijaGranica " +
"    left join VrstaRobeHS on VrstaRobeHS.ID = UvozKonacna.NazivRobe " +
"    left join VrstaRobe on VrstaRobe.ID = NHMBroj " +
 "   left join TipKontenjera on TipKontenjera.ID = UvozKonacna.TipKontejnera " +
"     left join Carinarnice on Carinarnice.ID = UvozKonacna.OdredisnaCarina " +
"    left join VrstaCarinskogPostupka on VrstaCarinskogPostupka.ID = UvozKonacna.CarinskiPostupak " +
"    left join Predefinisaneporuke on PredefinisanePoruke.ID = UvozKonacna.NapomenaZaPozicioniranje " +
"   Where UvozKonacna.IDNadredjeni = " + Convert.ToInt32(txtNadredjeni.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var ds = new DataSet();
            dataAdapter.Fill(ds);

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            object missing = System.Reflection.Missing.Value;
            Workbook wBook = excel.Workbooks.Add(missing);

            Worksheet wSheet = new Worksheet();
            try
            {

                wSheet = (Worksheet)wBook.Worksheets.get_Item(1);
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        wSheet.Cells[1, 15].EntireRow.Font.Bold = true;
                        wSheet.Range["A1:N1"].Interior.Color = System.Drawing.Color.AliceBlue;
                        wSheet.Cells[1, "A"] = "RB";
                        wSheet.Cells[1, "B"] = "ETA dolazak broda u Luku Rijeka";
                        wSheet.Cells[1, "C"] = "Broj kontejnera";
                        wSheet.Cells[1, "D"] = "Tip kontejnera";
                        wSheet.Cells[1, "E"] = "BL-brodska tertnica";
                        wSheet.Cells[1, "F"] = "ADR";
                        wSheet.Cells[1, "G"] = "Vlasnik kontejnera";
                        wSheet.Cells[1, "H"] = "Vlasnik PIB";
                        wSheet.Cells[1, "I"] = "Nalogodavaci";
                        wSheet.Cells[1, "J"] = "Uvoznik";
                        wSheet.Cells[1, "K"] = "Uvoznik PIB";
                        wSheet.Cells[1, "L"] = "Vrsta robe";
                        wSheet.Cells[1, "M"] = "NHM";
                        wSheet.Cells[1, "N"] = "Neto robe (kg)";
                        wSheet.Cells[1, "O"] = "Bruto robe (kg)";
                        wSheet.Cells[1, "P"] = "Tara kontejnera (kg)";
                        wSheet.Cells[1, "Q"] = "Bruto kontejnera (kg)";
                        wSheet.Cells[1, "R"] = "Koleta";
                        // wSheet.Cells[1, "Z"] = "Bruto kontejnera (kg)";



                        wSheet.Cells[i + 2, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        wSheet.Cells[i + 2, j + 1].EntireColumn.AutoFit();
                        Borders border = wSheet.Cells[i + 2, j + 1].Borders;
                        border.Weight = 2d;

                    }
                }

                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                object filename = @"ExportBezb" + date + ".xlsx";
                wBook.SaveAs(filename);
                wBook.Close();
                excel.Quit();
                excel = null;
                wBook = null;
                wSheet = null;


                MessageBox.Show("Dokument za drumski prevoz je kreiran");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            UvozDokumenta uvdok = new UvozDokumenta(txtID.Text);
            uvdok.Show();
        }

        private void txtIDNHM_TextChanged(object sender, EventArgs e)
        {

        }
        private void FillDG4()
        {
            var select = "select UvozKonacnaNapomenePozicioniranja.ID, IDNapomene, PredefinisanePoruke.Naziv from UvozKonacnaNapomenePozicioniranja " +
" inner join  PredefinisanePoruke on PredefinisanePoruke.ID = UvozKonacnaNapomenePozicioniranja.IDNapomene where UvozKonacnaNapomenePozicioniranja.IdNadredjena  = " + Convert.ToInt32(txtID.Text) + " order by UvozKonacnaNapomenePozicioniranja.ID desc ";
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
       
        private void button9_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.InsUvozKonacnaNapomenePozicioniranja(Convert.ToInt32(txtID.Text), Convert.ToInt32(cbNapomenaPoz.SelectedValue));
            FillDG4();
            RefreshDataGridColor();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.DelUvozKonacnaNapomenePozicioniranja(Convert.ToInt32(txtNapomenaPoz.Text));
            FillDG4();
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

        private void txtBrutoK_Leave(object sender, EventArgs e)
        {
            txtBrutoK.Value = txtBrutoR.Value + txtTaraK.Value;
        }

        private void txtTaraK_Leave(object sender, EventArgs e)
        {
            txtBrutoK.Value = txtBrutoR.Value + txtTaraK.Value;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            var select = "SELECT row_number() OVER (ORDER BY UvozKonacna.ID) RB, " +
  "    [BrojKontejnera], TipKontenjera.Naziv as TipKontejnera,UvozKonacna.Napomena, " +
  "    BrodskaTeretnica, (VrstaRobeAdr.Naziv +  + VrstaRobeAdr.UnKod) as ADR ,  " +
   "    p1.PaNaziv as Uvoznik, p1.PaEMatSt1 as UvoznikPIB,  " +
" ( " +
" SELECT " +
" STUFF(" +
"  (" +
"  SELECT distinct " +
"   '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20)) " +
"  FROM UvozKonacnaVrstaRobeHS " +
"  inner join VrstaRobeHS on UvozKonacnaVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID " +
" where UvozKonacnaVrstaRobeHS.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
"   ), 1, 1, '' " +
" ) As Skupljen) as VrsteRobe,  " +
" (" +
" SELECT " +
" STUFF(" +
"  (" +
"  SELECT distinct " +
"   '/' + Cast(NHM.Broj as nvarchar(20)) " +
"  FROM UvozKonacnaNHM " +
"  inner join NHM on UvozKonacnaNHM.IDNHM = NHM.ID " +
" where UvozKonacnaNHM.IDNadredjena = UvozKonacna.ID " +
"  FOR XML PATH('') " +
"  ), 1, 1, '' " +
" ) As Skupljen) as NHM, " +
" p3.PaNaziv as SpedicijaGranica, " +
" p2.PaNaziv as SpedicijaRTC, " +
" VrstaCarinskogPostupka.Naziv as CarinskiPostupak, " +
" VrstePostupakaUvoz.Naziv as PostupakSarobom, Napomena,  " +
 "     (Carinarnice.CINaziv + ' ' + Carinarnice.CIOznaka + ' ' + CIEmail + ' ' + CITelefon + ' / ' + p3.PaNaziv) as Carinarnica, " +
 "     (MestoIstovara + ' ' + KontaktOsoba) as MestoIstovara, Email, " +
 "      BrutoRobe, TaraKontejnera, BrutoKontejnera " +
 "     FROM UvozKonacna " +
 "     inner join Partnerji on PaSifra = VlasnikKontejnera " +
  "    inner join Partnerji p1 on p1.PaSifra = Uvoznik " +
  "      inner join Partnerji p2 on p2.PaSifra = SpedicijaRTC " +
  "       inner join Partnerji p3 on p3.PaSifra = SpedicijaGranica " +
 "    left join VrstaRobeHS on VrstaRobeHS.ID = UvozKonacna.NazivRobe " +
 "    left join VrstaRobe on VrstaRobe.ID = NHMBroj " +
 "    left join VrstaRobeADR on VrstaRobeADR.ID = UvozKonacna.ADR " +
  "   left join TipKontenjera on TipKontenjera.ID = UvozKonacna.TipKontejnera " +
 "     left join Carinarnice on Carinarnice.ID = UvozKonacna.OdredisnaCarina " +
  "     left join KontejnerskiTerminali on KontejnerskiTerminali.ID = UvozKonacna.RLTerminali " +
 "    left join VrstaCarinskogPostupka on VrstaCarinskogPostupka.ID = UvozKonacna.CarinskiPostupak " +
 "    left join Predefinisaneporuke on PredefinisanePoruke.ID = UvozKonacna.NapomenaZaPozicioniranje " +
  "    left join VrstePostupakaUvoz on VrstePostupakaUvoz.ID = UvozKonacna.PostupakSaRobom " +
 "   Where UvozKonacna.IDNadredjeni = " + Convert.ToInt32(txtNadredjeni.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var ds = new DataSet();
            dataAdapter.Fill(ds);

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            object missing = System.Reflection.Missing.Value;
            Workbook wBook = excel.Workbooks.Add(missing);

            Worksheet wSheet = new Worksheet();
            try
            {

                wSheet = (Worksheet)wBook.Worksheets.get_Item(1);
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        wSheet.Cells[1, 15].EntireRow.Font.Bold = true;
                        wSheet.Range["A1:N1"].Interior.Color = System.Drawing.Color.AliceBlue;
                        wSheet.Cells[1, "A"] = "RB";
                     
                        wSheet.Cells[1, "B"] = "Broj kontejnera";
                        wSheet.Cells[1, "C"] = "Tip kontejnera";
                        wSheet.Cells[1, "D"] = "Napomena za stavku";
                  
                        wSheet.Cells[1, "E"] = "BL-brodska tertnica";
                        wSheet.Cells[1, "F"] = "ADR";
                        
                        wSheet.Cells[1, "G"] = "Uvoznik";
                        wSheet.Cells[1, "H"] = "Uvoznik PIB";
                        wSheet.Cells[1, "I"] = "Vrsta robe";
                        wSheet.Cells[1, "J"] = "NHM";
                        wSheet.Cells[1, "K"] = "Špedicija - granica";
                        wSheet.Cells[1, "L"] = "Špedicija - Leget";
                        wSheet.Cells[1, "M"] = "Carinski postupak";
                        wSheet.Cells[1, "N"] = "Postupanje sa robom/kontejeromnt";
                        wSheet.Cells[1, "O"] = "Napomena za RTC LUKA LEGET";
                        wSheet.Cells[1, "P"] = "Odredišna Carinska ispostav+špedicija";

                        wSheet.Cells[1, "R"] = "Mesto istovara+kontakt osoba";
                        wSheet.Cells[1, "S"] = "e-mail adrese za slanje statusa";
                        wSheet.Cells[1, "T"] = "Napomena za pozicioniranje kontejner";
                      
                        wSheet.Cells[1, "U"] = "Bruto robe (kg)";
                        wSheet.Cells[1, "V"] = "Tara kontejnera (kg)";
                        wSheet.Cells[1, "W"] = "Bruto kontejnera (kg)";



                        wSheet.Cells[i + 2, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        wSheet.Cells[i + 2, j + 1].EntireColumn.AutoFit();
                        Borders border = wSheet.Cells[i + 2, j + 1].Borders;
                        border.Weight = 2d;

                    }
                }

                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                object filename = @"ExportSpediter" + date + ".xlsx";
                wBook.SaveAs(filename);
                wBook.Close();
                excel.Quit();
                excel = null;
                wBook = null;
                wSheet = null;


                MessageBox.Show("Dokument za drumski prevoz je kreiran");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbPostupak_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
        {
            FillDG6();
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

        private void button13_Click(object sender, EventArgs e)
        {
            FillDG7();
        }

        private void UbaciStavkuUsluge(int ID, int Manipulacija, double Cena)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.InsUbaciUsluguKonacna(Convert.ToInt32(txtID.Text), Manipulacija, Cena);
            FillDG8();
        }

        private void FillDG8()
        {
            var select = "select  UvozKonacnaVrstaManipulacije.ID, VrstaManipulacije.Naziv, UvozKonacnaVrstaManipulacije.Cena, VrstaManipulacije.ID from UvozKonacnaVrstaManipulacije " +
            " inner join VrstaManipulacije on VrstaManipulacije.ID = UvozKonacnaVrstaManipulacije.IDVrstaManipulacije " +
                " where UvozKonacnaVrstaManipulacije.IDNadredjena = " + Convert.ToInt32(txtID.Text);
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

        private void button12_Click(object sender, EventArgs e)
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

        private void FormirajOpstiExcel()
        {
            var select = "SELECT row_number() OVER (ORDER BY UvozKonacna.ID) RB, " +
                  "ATABroda,[BrojKontejnera], TipKontenjera.Naziv as Vrsta_Kontejnera," +
                  " DobijenNalogBrodara as Dobijen_Nalog_Brodara , DobijeBZ as DatumBZ ,Napomena1 as Napomena1," +
                  "  PIN, " +
   "   KontejnerskiTerminali.Naziv as R_L_SRB, pp1.Naziv as Dirigacija_Kontejnera_Za,  " +
   "   BrodskaTeretnica as BL, VrstaRobeADR.Naziv as ADR, b.PaNaziv as Brodar, n1.PaNaziv as Nalogodavac1, Ref1 as Ref1, n2.PaNaziv as Nalogodavac2, Ref2 as Ref2,  " +
    "      p1.PaNaziv as Uvoznik,   " +
    "  (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaManipulacije.Naziv as nvarchar(20))   FROM UvozKonacnaVrstaManipulacije " +
     "       inner join VrstaManipulacije on VrstaManipulacije.ID = UvozKonacnaVrstaManipulacije.IDVrstaManipulacije   where UvozKonacnaVrstaManipulacije.IDNadredjena = UvozKonacna.ID " +
     "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as VrsteUsluga,   " +
     "     (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20))   FROM UvozKonacnaVrstaRobeHS " +
     "       inner join VrstaRobeHS on UvozKonacnaVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID   where UvozKonacnaVrstaRobeHS.IDNadredjena = UvozKonacna.ID " +
     "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as VrsteRobe,   " +
     "    (SELECT  STUFF((SELECT distinct    '/' + Cast(NHM.Broj as nvarchar(20)) " +
    "            FROM UvozKonacnaNHM  inner join NHM on UvozKonacnaNHM.IDNHM = NHM.ID  where UvozKonacnaNHM.IDNadredjena = UvozKOnacna.ID   FOR XML PATH('')), 1, 1, ''  ) As Skupljen) as NHM,   " +
     "              VrstaPregleda as VrstaPregleda,p2.PaNaziv as SpedicijaRTC,  p3.PaNaziv as SpedicijaGranica,      " +
     " VrstaCarinskogPostupka.Naziv as CarinskiPostupak,   VrstaPregleda , " +
     "                  VrstePostupakaUvoz.Naziv as PostupakSaRobom,uvNacinPakovanja.Naziv as NacinPakovanja, Napomena as Napomena2,  " +
     "                      (Carinarnice.CINaziv + ' ' + Carinarnice.CIOznaka + ' ' + CIEmail + ' ' + CITelefon + ' / ' + p3.PaNaziv) as Carinarnica,   " +
     "                               p4.PaNaziv as OdredisnaSpedicija, (MestoIstovara + ' ' + KontaktOsoba) as MestoIstovara, Email,          " +
  " PredefinisanePoruke.Naziv as NapomenaZaPozicioniranje,  " +
   " NetoRobe, BrutoRobe, TaraKontejnera, BrutoKontejnera, " +
   " Koleta " +
   " FROM UvozKonacna inner join Partnerji on PaSifra = VlasnikKontejnera " +
   " inner join Partnerji p1 on p1.PaSifra = Uvoznik " +
   " inner join Partnerji p2 on p2.PaSifra = SpedicijaRTC " +
  " inner join Partnerji p3 on p3.PaSifra = SpedicijaGranica " +
   "  inner join VrstaRobeHS on VrstaRobeHS.ID = UvozKonacna.NazivRobe " +
  "  inner join NHM on NHM.ID = NHMBroj " +
   " inner join TipKontenjera on TipKontenjera.ID = UvozKonacna.TipKontejnera " +
   "  inner join Carinarnice on Carinarnice.ID = UvozKonacna.OdredisnaCarina " +
   "  inner join VrstaCarinskogPostupka on VrstaCarinskogPostupka.ID = UvozKonacna.CarinskiPostupak " +
   " inner join Predefinisaneporuke on PredefinisanePoruke.ID = UvozKonacna.NapomenaZaPozicioniranje " +
   "  inner join KontejnerskiTerminali on KontejnerskiTerminali.ID = UvozKonacna.RLTErminali " +
   "  inner join Partnerji n1 on n1.PaSifra = Nalogodavac1 " +
   "  inner join Partnerji n2 on n2.PaSifra = Nalogodavac2 " +
   "  inner join Partnerji n3 on n3.PaSifra = Nalogodavac3 " +
   "  inner join Partnerji b on b.PaSifra = UvozKonacna.Brodar " +
    " inner join PredefinisanePoruke pp1 on pp1.ID = DirigacijaKontejeraZa   " +
   "  inner join Brodovi on Brodovi.ID = UvozKonacna.NazivBroda " +
                                "   inner join VrstaRobeADR on VrstaRobeADR.ID = ADR " +
                                "    inner join VrstePostupakaUvoz on VrstePostupakaUvoz.ID = PostupakSaRobom    inner join uvNacinPakovanja " +
   " on uvNacinPakovanja.ID = NacinPakovanja  inner join Partnerji p4 on p4.PaSifra = OdredisnaSpedicija " +
  "  Where UvozKonacna.IDNadredjeni = " + Convert.ToInt32(txtNadredjeni.Text) + "order by UvozKonacna.ID desc";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var ds = new DataSet();
            dataAdapter.Fill(ds);

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            object missing = System.Reflection.Missing.Value;
            Workbook wBook = excel.Workbooks.Add(missing);

            Worksheet wSheet = new Worksheet();
            try
            {

                wSheet = (Worksheet)wBook.Worksheets.get_Item(1);
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        wSheet.Cells[1, 15].EntireRow.Font.Bold = true;
                        wSheet.Range["A1:AM1"].Interior.Color = System.Drawing.Color.AliceBlue;
                        wSheet.Cells[1, "A"] = "RB";
                        wSheet.Cells[1, "B"] = "Atabroda";
                        wSheet.Cells[1, "C"] = "Broj kontejnera";
                        wSheet.Cells[1, "D"] = "Vrsta Kontejnera";
                        wSheet.Cells[1, "E"] = "Dobijen nalog brodara";
                        wSheet.Cells[1, "F"] = "Dobijen BZ";
                        wSheet.Cells[1, "G"] = "Napomena za stavku";
                        wSheet.Cells[1, "H"] = "PIN/Šifra";
                        wSheet.Cells[1, "I"] = "R_L_SRB";
                        wSheet.Cells[1, "J"] = "Naziv broda";
                        wSheet.Cells[1, "K"] = "BL / Brodska teretnica";
                        wSheet.Cells[1, "L"] = "ADR";
                        wSheet.Cells[1, "M"] = "Brodar";
                        wSheet.Cells[1, "N"] = "Nalogodavac 1";
                        wSheet.Cells[1, "O"] = "Ref1";
                        wSheet.Cells[1, "P"] = "Nalogodavac 2";
                        wSheet.Cells[1, "Q"] = "Ref2";
                        wSheet.Cells[1, "R"] = "Uvoznik";
                        wSheet.Cells[1, "S"] = "Vrste manipulacije";
                        wSheet.Cells[1, "T"] = "Vrsta robe";
                        wSheet.Cells[1, "U"] = "NHM";
                        wSheet.Cells[1, "V"] = "Vrsta pregleda";
                        wSheet.Cells[1, "W"] = "Špedicija RTC";
                        wSheet.Cells[1, "X"] = "Špedicija granica";
                        wSheet.Cells[1, "Y"] = "Carinski postupak";
                        wSheet.Cells[1, "Z"] = "VrstaPregleda ";
                        wSheet.Cells[1, "AA"] = "Postupak sa Robom";
                        wSheet.Cells[1, "AB"] = "Način pakovanja";
                        wSheet.Cells[1, "AC"] = "Napomena 2";
                        wSheet.Cells[1, "AD"] = "Carinarnica";
                        wSheet.Cells[1, "AE"] = "Odredišna špedicija";
                        wSheet.Cells[1, "AF"] = "Mesto istovara";
                        wSheet.Cells[1, "AG"] = "Email za slanje statusa";
                        wSheet.Cells[1, "AH"] = "Napomena za pozicioniranje";
                        wSheet.Cells[1, "AI"] = "NetoRobe";
                        wSheet.Cells[1, "AJ"] = "BrutoRobe";
                        wSheet.Cells[1, "AK"] = "TaraKontejnera";
                        wSheet.Cells[1, "AL"] = "BrutoKontejnera";
                        wSheet.Cells[1, "AM"] = "Koleta";

                        wSheet.Cells[i + 2, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        wSheet.Cells[i + 2, j + 1].EntireColumn.AutoFit();
                        Borders border = wSheet.Cells[i + 2, j + 1].Borders;
                        border.Weight = 2d;

                    }
                }

                string date = DateTime.Now.ToString("dd-MM-yyyy");
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                object filename = @"Opsti" + date + ".xlsx";
                wBook.SaveAs(filename);
                wBook.Close();
                excel.Quit();
                excel = null;
                wBook = null;
                wSheet = null;


                MessageBox.Show("Dokument je kreiran");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            FormirajOpstiExcel();
           /* DialogResult dialogResult = MessageBox.Show("Da li pravite i naloge Da/Ne", "Radni nalog", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertRadniNalogInterni ins = new InsertRadniNalogInterni();
              
                    ins.InsRadniNalogInterni(Convert.ToInt32(1), Convert.ToInt32(5), Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(DateTime.MinValue), "", Convert.ToInt32(0), "PlanUtovara", Convert.ToInt32(row.Cells[0].Value.ToString()), "sa", "sa");
                
                FormirajOpstiExcel();
            }
            else
            {
                FormirajOpstiExcel();
            }
          */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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


        private void button10_Click(object sender, EventArgs e)
        {
            int IDZaPromenu = 0;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        IDZaPromenu = Convert.ToInt32(row.Cells[0].Value.ToString());
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

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li pravite Opšte naloge za selektovane zapise Da/Ne", "Radni nalog", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        InsertRadniNalogInterni ins = new InsertRadniNalogInterni();
                        ins.InsRadniNalogInterni(Convert.ToInt32(1), Convert.ToInt32(5), Convert.ToDateTime(DateTime.Now), Convert.ToDateTime("1.1.1900. 00:00:00"), "", Convert.ToInt32(0), "PlanUtovara", Convert.ToInt32(row.Cells[0].Value.ToString()), "sa", "sa");
                    }
                }
            }
            else
            {
               // FormirajOpstiExcel();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmUnosManipulacija um = new frmUnosManipulacija();
            um.Show();
        }
    }
    }

