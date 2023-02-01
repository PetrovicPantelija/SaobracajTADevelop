using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;



namespace Testiranje.Dokumeta
{
    public partial class frmBukingVoza : Form
    {


        string KorisnikCene;
        bool status = false;
        int usao = 0;
        public frmBukingVoza()
        {
            InitializeComponent();
        }

        public frmBukingVoza(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
            
        }

        public frmBukingVoza(string Sifra, string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
            
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
        }

        private void RefreshDataGridDugme()
        {

            var select = "  Select PrijemKontejneraVozStavke.BrojKontejnera, 'Voz' as Tip, PrijemKontejneraVozStavke.ID , PrijemKontejneraVozStavke.IDNadredjenog, TipKontenjera.Naziv,  PrijemKontejneraVozStavke.Tara,  PrijemKontejneraVozStavke.Neto,  (PrijemKontejneraVozStavke.Tara +  PrijemKontejneraVozStavke.Neto) as Bruto from PrijemKontejneraVozStavke " +
            " inner Join TipKontenjera on PrijemKontejneraVozStavke.TipKontejnera = TipKontenjera.ID where PrijemKontejneraVozStavke.Buking = " + Convert.ToInt32(cboVoz.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[0].Width = 170;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Tip";
            dataGridView1.Columns[1].Width = 70;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "ID stavke";
            dataGridView1.Columns[2].Width = 70;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Broj";
            dataGridView1.Columns[3].Width = 70;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Tip kontejnera";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Tara";
            dataGridView1.Columns[5].Width = 70;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Neto";
            dataGridView1.Columns[6].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Bruto";
            dataGridView1.Columns[7].Width = 70;

          
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from BukingVoza", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertBukingVoza ins = new InsertBukingVoza();
                ins.InsertBuk(Convert.ToInt32(cboVoz.SelectedValue), Convert.ToDateTime(dtpDatumOtpreme.Value), txtStanicaOtpreme.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToInt32(txtUkupno2.Value), Convert.ToDouble(txtSopstvenaMasa2.Value) );
                VratiPodatkeMax();
                status = false;

            }
            else
            {
                //int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik
                InsertBukingVoza upd = new InsertBukingVoza();
                upd.UpdVoz(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboVoz.SelectedValue), Convert.ToDateTime(dtpDatumOtpreme.Value), txtStanicaOtpreme.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToInt32(txtUkupno2.Value), Convert.ToDouble(txtSopstvenaMasa2.Value));
                status = false;
            }
            RefreshDataGrid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertBukingVoza upd = new InsertBukingVoza();
                upd.DeleteVoz(Convert.ToInt32(txtSifra.Text));
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
        }

        private void RefreshKontejneri()
        {
            var select = "  SELECT  PrijemKontejneraVozStavke.ID as ID, PrijemKontejneraVozStavke.RB as RB, PrijemKontejneraVozStavke.IDNadredjenog as IDNadredjenog,  PrijemKontejneraVozStavke.BrojKontejnera as BrojKontejnera, PrijemKontejneraVozStavke.BrojVagona as VagonKamion, "
                      + " PrijemKontejneraVozStavke.VremeOdlaska  "
                      + " FROM    "
                      + "  PrijemKontejneraVozStavke inner join  "
                        + " BukingVoza AS BukingVoza_1 ON PrijemKontejneraVozStavke.Buking = BukingVoza_1.ID  "
                       + " where PrijemKontejneraVozStavke.Buking = " + Convert.ToInt32(txtSifra.Text)

+ " union  "
        + " SELECT  PrijemKontejnera.ID as ID, 1 as RB, PrijemKontejnera.ID as IDNadredjenog,  PrijemKontejnera.BrojKontejnera as BrojKontejnera, PrijemKontejnera.RegBrojKamiona as VagonKamion,  "
                     + " PrijemKontejnera.VremeOdlaska  "
                     + " FROM   "
                     + " PrijemKontejnera inner join  "
                    + "	BukingVoza AS BukingVoza_1 ON PrijemKontejnera.Buking = BukingVoza_1.ID  "
                     + " where PrijemKontejneraVozStavke.Buking = " + Convert.ToInt32(txtSifra.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = false;
            dataGridView1.DataSource = ds.Tables[0];



            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "ID Prijema";
            dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[3].Width = 90;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Broj Vagona / Kamion";
            dataGridView1.Columns[4].Width = 90;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme odlaska";
            dataGridView1.Columns[5].Width = 90;

           
        
        
        
        
        }

        private void RefreshDataGrid()
        {
            /*
            var select = "  SELECT [ID],[IdVoza],[DatumOtpreme],[StanicaOtpreme],[Datum],[Korisnik]  FROM [dbo].[BukingVoza]  ";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Voz";
            dataGridView2.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Datum otpreme";
            dataGridView2.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Stanica otpreme";
            dataGridView2.Columns[3].Width = 150;

          

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Datum unosa";
            dataGridView2.Columns[4].Width = 100;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Korisnik";
            dataGridView2.Columns[5].Width = 100;
             * */
        }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID],[IdVoza],[DatumOtpreme],[StanicaOtpreme],[Datum],[Korisnik]  FROM [dbo].[BukingVoza] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                // Convert.ToInt32(cboTipCenovnika.SelectedValue), Convert.ToInt32(cboKomitent.SelectedValue), Convert.ToDouble(txtCena.Text), Convert.ToInt32(cboVrstaManipulacije.SelectedValue), Convert.ToDateTime(DateTime.Now), KorisnikCene
                txtStanicaOtpreme.Text = dr["StanicaOtpreme"].ToString();
                cboVoz.SelectedValue = Convert.ToInt32(dr["IdVoza"].ToString());

                dtpDatumOtpreme.Value = Convert.ToDateTime(dr["DatumOtpreme"].ToString()); 
                
          
            }

            con.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void frmBukingVoza_Load(object sender, EventArgs e)
       {
           var select = "Select Distinct ID, (Cast(id as nvarchar(6))+ '-' + Cast(BrVoza as nvarchar(6)) + '-' + Relacija + '-' + Cast(Cast(VremePolaskaO as DateTime) as Nvarchar(12))) as BrVoza From Voz where dolazeci = 0 ";
           // var select = " Select Distinct ID, (Cast(id as nvarchar(5))+ '-' + Cast(BrVoza as nvarchar(5)) + '-' + Relacija + '-' + Cast(Cast(VremePolaskaO as DateTime) as Nvarchar(12)) ) as BrVoza From Voz where dolazeci = 1";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboVoz.DataSource = ds.Tables[0];
            cboVoz.DisplayMember = "BrVoza";
            cboVoz.ValueMember = "ID";

            var select3 = " Select Distinct ID, Naziv From Skladista";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboSkladiste.DataSource = ds3.Tables[0];
            cboSkladiste.DisplayMember = "Naziv";
            cboSkladiste.ValueMember = "ID";

            var select4 = " Select Distinct OtpremaKontejnera.ID as ID, (Cast(OtpremaKontejnera.id as nvarchar(5))+ '-' + Cast(BrVoza as nvarchar(5)) + '-' + Relacija + '-' + Cast(Cast(VremePolaskaO as DateTime) as Nvarchar(12))) as BrVoza From OtpremaKontejnera inner join Voz on Voz.ID = OtpremaKontejnera.IdVoza where StatusOtpreme = 0";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboOtpremnica.DataSource = ds4.Tables[0];
            cboOtpremnica.DisplayMember = "BrVoza";
            cboOtpremnica.ValueMember = "ID";

            RefreshDataGrid();
            usao = 1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGridDugme();
        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            var select = "  SELECT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
        " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
        " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
        " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
        " ,Promet.[Datum] ,Promet.[Korisnik], TipKontenjera.Naziv, VrstaRobe.Nkm as NHM, VrstaRobe.Naziv  " +
        " FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
        " inner join Pozicija on Promet.LokacijaU = Pozicija.ID " +
       "   inner join PrijemKontejneraVozStavke on Promet.[PrOznSled] = PrijemKontejneraVozStavke.Id " +
       " inner join TipKontenjera on TipKontenjera.Id = PrijemKontejneraVozStavke.TipKontejnera " +
       " inner join VrstaRobe on VrstaRobe.Id = PrijemKontejneraVozStavke.VrstaRobe" +
        "  where Zatvoren = 0 and SkladisteU = " + Convert.ToInt32(cboSkladiste.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "Šifra";
            dataGridView3.Columns[0].Width = 40;
            // dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Datum Transakcije";
            dataGridView3.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Vrsta Dokumenta";
            dataGridView3.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Br Dokumenta";
            dataGridView3.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Vrsta Prometa";
            dataGridView3.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Broj kontejnera";
            dataGridView3.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "PrPrimKol";
            dataGridView3.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "SkladID ";
            dataGridView3.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Skladiste u";
            dataGridView3.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "LokacID ";
            dataGridView3.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Lokac U";
            dataGridView3.Columns[10].Width = 80;

            DataGridViewColumn column12 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Oznaka sled";
            dataGridView3.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Datum";
            dataGridView3.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "Korisnik";
            dataGridView3.Columns[13].Width = 80;

            DataGridViewColumn column15 = dataGridView3.Columns[14];
            dataGridView3.Columns[14].HeaderText = "Tip kontejnera";
            dataGridView3.Columns[14].Width = 80;

            DataGridViewColumn column16 = dataGridView3.Columns[15];
            dataGridView3.Columns[15].HeaderText = "NHM";
            dataGridView3.Columns[15].Width = 80;

            DataGridViewColumn column17 = dataGridView3.Columns[16];
            dataGridView3.Columns[16].HeaderText = "Roba";
            dataGridView3.Columns[16].Width = 80;
        }

       /*private void RefreshDataGrid()
        {
            var select = "  SELECT OtpremaKontejneraVozStavke.ID, OtpremaKontejneraVozStavke.RB, OtpremaKontejneraVozStavke.IDNadredjenog,  OtpremaKontejneraVozStavke.BrojKontejnera, OtpremaKontejneraVozStavke.Granica, "
                        + " OtpremaKontejneraVozStavke.BrojOsovina, OtpremaKontejneraVozStavke.SopstvenaMasa, OtpremaKontejneraVozStavke.Tara, OtpremaKontejneraVozStavke.Neto, Komitenti.Naziv AS Posiljalac, Komitenti_1.Naziv AS primalac, "
                        + " Komitenti_2.Naziv AS Vlasnikkontejnera, " +
                          " Komitenti_3.Naziv AS Organizator, " +
                        "  TipKontenjera.Naziv AS TipKontejnera, VrstaRobe.Naziv AS VrstaRobe, OtpremaKontejneraVozStavke.Buking , OtpremaKontejneraVozStavke.StatusKontejnera, "
                        + " OtpremaKontejneraVozStavke.BrojPlombe, OtpremaKontejneraVozStavke.BrojPlombe2, OtpremaKontejneraVozStavke.PlaniraniLager,"
                        + " OtpremaKontejneraVozStavke.Datum, OtpremaKontejneraVozStavke.Korisnik "
                        + "FROM  Komitenti INNER JOIN "
                        + " OtpremaKontejneraVozStavke ON Komitenti.ID = OtpremaKontejneraVozStavke.Posiljalac INNER JOIN "
                        + " Komitenti AS Komitenti_1 ON OtpremaKontejneraVozStavke.Primalac = Komitenti_1.ID INNER JOIN "
                        + " Komitenti AS Komitenti_2 ON OtpremaKontejneraVozStavke.VlasnikKontejnera = Komitenti_2.ID INNER JOIN "
                          + " Komitenti AS Komitenti_3 ON OtpremaKontejneraVozStavke.Organizator = Komitenti_3.ID INNER JOIN "
                         + "TipKontenjera ON OtpremaKontejneraVozStavke.TipKontejnera = TipKontenjera.ID INNER JOIN "
                        + " VrstaRobe ON OtpremaKontejneraVozStavke.VrstaRobe = VrstaRobe.ID "
                          + " where IdNadredjenog = " + txtSifra.Text + " order by RB";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = false;
            dataGridView1.DataSource = ds.Tables[0];



            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Br otp";
            dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[3].Width = 90;



            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Granica";
            dataGridView1.Columns[4].Width = 90;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Broj osovina";
            dataGridView1.Columns[5].Width = 20;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Sopstvena masa";
            dataGridView1.Columns[6].Width = 30;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Tara";
            dataGridView1.Columns[7].Width = 50;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Neto";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Posiljalac";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Primalac";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Vlasnik kontejnera";
            dataGridView1.Columns[11].Width = 40;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Organizator";
            dataGridView1.Columns[12].Width = 40;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Tip kontejnera";
            dataGridView1.Columns[13].Width = 30;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Vrsta robe";
            dataGridView1.Columns[14].Width = 30;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Buking";
            dataGridView1.Columns[15].Width = 30;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = " Status Kontejnera";
            dataGridView1.Columns[16].Width = 90;

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Broj plombe";
            dataGridView1.Columns[17].Width = 90;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Br plombe 2";
            dataGridView1.Columns[18].Width = 70;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Pl lager";
            dataGridView1.Columns[19].Width = 70;


            DataGridViewColumn column21 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Datum";
            dataGridView1.Columns[20].Width = 70;

            DataGridViewColumn column22 = dataGridView1.Columns[21];
            dataGridView1.Columns[21].HeaderText = "Korisnik";
            dataGridView1.Columns[21].Width = 70;



        }
        */
        /*
         * select  Count(*) as Broj, substring(Naziv,1,3) as Tip,min(TipKontenjera.Naziv) from OtpremaKontejneraVozStavke
inner join TipKontenjera on OtpremaKontejneraVozStavke.TipKontejnera = TipKontenjera.ID
group by substring(Naziv,1,3)
         */

        private void VratiPodatkeTipKontejneraBroj()
        {
            //
            var select = "select  Count(*) as Broj, substring(Naziv,1,3) as Tip from OtpremaKontejneraVozStavke " +
" inner join TipKontenjera on OtpremaKontejneraVozStavke.TipKontejnera = TipKontenjera.ID " +
" where IDNadredjenog = " + Convert.ToInt32(cboOtpremnica.SelectedValue) + " group by substring(Naziv,1,3) ";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];


            DataGridViewColumn column = dataGridView4.Columns[0];
            dataGridView4.Columns[0].HeaderText = "Broj";
            dataGridView4.Columns[0].Width = 50;
            dataGridView4.Columns[0].Visible = true;

           // con.Close();
        }

        private void VratiPodatkeMaseOtpremnica()
        {
            //
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select sum(SopstvenaMasa) as SopM, sum(Tara) as Tara, Sum(Neto) as Neto, (sum(SopstvenaMasa)+sum(Tara)+Sum(Neto))  as Bruto from OtpremaKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboOtpremnica.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //Izmenjeno
               // txtSopstvenaMasa2.Value = Convert.ToDecimal(dr["SopM"].ToString());
                txtSopstvenaMasa2.Value = 0;
                txtTara2.Value = Convert.ToDecimal(dr["Tara"].ToString());
                txtNeto2.Value = Convert.ToDecimal(dr["Neto"].ToString());
               // txtUkupno2.Value = Convert.ToDecimal(dr["Bruto"].ToString());
                txtUkupno2.Value = 0;
                // txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void   RefreshOtpremnicaStavke()
        {
            if (usao == 1)
            {
                var select = "  SELECT OtpremaKontejneraVozStavke.ID, OtpremaKontejneraVozStavke.RB, OtpremaKontejneraVozStavke.IDNadredjenog,  OtpremaKontejneraVozStavke.BrojKontejnera, OtpremaKontejneraVozStavke.Granica, "
                         + " OtpremaKontejneraVozStavke.BrojOsovina, OtpremaKontejneraVozStavke.SopstvenaMasa, OtpremaKontejneraVozStavke.Tara, OtpremaKontejneraVozStavke.Neto, Komitenti.Naziv AS Posiljalac, Komitenti_1.Naziv AS primalac, "
                         + " Komitenti_2.Naziv AS Vlasnikkontejnera, " +
                           " Komitenti_3.Naziv AS Organizator, " +
                         "  TipKontenjera.Naziv AS TipKontejnera, VrstaRobe.Naziv AS VrstaRobe, OtpremaKontejneraVozStavke.Buking , OtpremaKontejneraVozStavke.StatusKontejnera, "
                         + " OtpremaKontejneraVozStavke.BrojPlombe, OtpremaKontejneraVozStavke.BrojPlombe2, OtpremaKontejneraVozStavke.PlaniraniLager,"
                         + " OtpremaKontejneraVozStavke.Datum, OtpremaKontejneraVozStavke.Korisnik "
                         + "FROM  Komitenti INNER JOIN "
                         + " OtpremaKontejneraVozStavke ON Komitenti.ID = OtpremaKontejneraVozStavke.Posiljalac INNER JOIN "
                         + " Komitenti AS Komitenti_1 ON OtpremaKontejneraVozStavke.Primalac = Komitenti_1.ID INNER JOIN "
                         + " Komitenti AS Komitenti_2 ON OtpremaKontejneraVozStavke.VlasnikKontejnera = Komitenti_2.ID INNER JOIN "
                           + " Komitenti AS Komitenti_3 ON OtpremaKontejneraVozStavke.Organizator = Komitenti_3.ID INNER JOIN "
                          + "TipKontenjera ON OtpremaKontejneraVozStavke.TipKontejnera = TipKontenjera.ID INNER JOIN "
                         + " VrstaRobe ON OtpremaKontejneraVozStavke.VrstaRobe = VrstaRobe.ID "
                                 + " where IdNadredjenog = " + Convert.ToInt32(cboOtpremnica.SelectedValue) + " order by RB";

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView2.ReadOnly = false;
                dataGridView2.DataSource = ds.Tables[0];



                DataGridViewColumn column = dataGridView2.Columns[0];
                dataGridView2.Columns[0].HeaderText = "ID";
                dataGridView2.Columns[0].Width = 40;
                dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView2.Columns[1];
                dataGridView2.Columns[1].HeaderText = "RB";
                dataGridView2.Columns[1].Width = 30;

                DataGridViewColumn column3 = dataGridView2.Columns[2];
                dataGridView2.Columns[2].HeaderText = "Br otp";
                dataGridView2.Columns[2].Width = 30;

                DataGridViewColumn column4 = dataGridView2.Columns[3];
                dataGridView2.Columns[3].HeaderText = "Broj kontejnera";
                dataGridView2.Columns[3].Width = 90;



                DataGridViewColumn column5 = dataGridView2.Columns[4];
                dataGridView2.Columns[4].HeaderText = "Granica";
                dataGridView2.Columns[4].Width = 90;

                DataGridViewColumn column6 = dataGridView2.Columns[5];
                dataGridView2.Columns[5].HeaderText = "Broj osovina";
                dataGridView2.Columns[5].Width = 20;

                DataGridViewColumn column7 = dataGridView2.Columns[6];
                dataGridView2.Columns[6].HeaderText = "Sopstvena masa";
                dataGridView2.Columns[6].Width = 30;

                DataGridViewColumn column8 = dataGridView2.Columns[7];
                dataGridView2.Columns[7].HeaderText = "Tara";
                dataGridView2.Columns[7].Width = 50;

                DataGridViewColumn column9 = dataGridView2.Columns[8];
                dataGridView2.Columns[8].HeaderText = "Neto";
                dataGridView2.Columns[8].Width = 50;

                DataGridViewColumn column10 = dataGridView2.Columns[9];
                dataGridView2.Columns[9].HeaderText = "Posiljalac";
                dataGridView2.Columns[9].Width = 50;

                DataGridViewColumn column11 = dataGridView2.Columns[10];
                dataGridView2.Columns[10].HeaderText = "Primalac";
                dataGridView2.Columns[10].Width = 50;

                DataGridViewColumn column12 = dataGridView2.Columns[11];
                dataGridView2.Columns[11].HeaderText = "Vlasnik kontejnera";
                dataGridView2.Columns[11].Width = 40;

                DataGridViewColumn column13 = dataGridView2.Columns[12];
                dataGridView2.Columns[12].HeaderText = "Organizator";
                dataGridView2.Columns[12].Width = 40;

                DataGridViewColumn column14 = dataGridView2.Columns[13];
                dataGridView2.Columns[13].HeaderText = "Tip kontejnera";
                dataGridView2.Columns[13].Width = 30;

                DataGridViewColumn column15 = dataGridView2.Columns[14];
                dataGridView2.Columns[14].HeaderText = "Vrsta robe";
                dataGridView2.Columns[14].Width = 30;

                DataGridViewColumn column16 = dataGridView2.Columns[15];
                dataGridView2.Columns[15].HeaderText = "Buking";
                dataGridView2.Columns[15].Width = 30;

                DataGridViewColumn column17 = dataGridView2.Columns[16];
                dataGridView2.Columns[16].HeaderText = " Status Kontejnera";
                dataGridView2.Columns[16].Width = 90;

                DataGridViewColumn column18 = dataGridView2.Columns[17];
                dataGridView2.Columns[17].HeaderText = "Broj plombe";
                dataGridView2.Columns[17].Width = 90;

                DataGridViewColumn column19 = dataGridView2.Columns[18];
                dataGridView2.Columns[18].HeaderText = "Br plombe 2";
                dataGridView2.Columns[18].Width = 70;

                DataGridViewColumn column20 = dataGridView2.Columns[19];
                dataGridView2.Columns[19].HeaderText = "Pl lager";
                dataGridView2.Columns[19].Width = 70;


                DataGridViewColumn column21 = dataGridView2.Columns[20];
                dataGridView2.Columns[20].HeaderText = "Datum";
                dataGridView2.Columns[20].Width = 70;

                DataGridViewColumn column22 = dataGridView2.Columns[21];
                dataGridView2.Columns[21].HeaderText = "Korisnik";
                dataGridView2.Columns[21].Width = 70;

                VratiPodatkeMaseOtpremnica();
                VratiPodatkeTipKontejneraBroj();
            }
        }

        private void cboOtpremnica_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOtpremnicaStavke();
           
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                      InsertOtpremaKontejneraStavke ins = new InsertOtpremaKontejneraStavke();
                      ins.InsertOtpremaKontejneraStavBuking(Convert.ToInt32(row.Cells[3].Value.ToString()),row.Cells[0].Value.ToString(),Convert.ToInt32(cboOtpremnica.SelectedValue) );
                }
            }

            RefreshOtpremnicaStavke();

          }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Selected)
                {
                    InsertOtpremaKontejneraStavke ins = new InsertOtpremaKontejneraStavke();
                    ins.InsertOtpremaKontejneraStavBuking(Convert.ToInt32(row.Cells[11].Value.ToString()), row.Cells[5].Value.ToString(), Convert.ToInt32(cboOtpremnica.SelectedValue));
                }
            }

            RefreshOtpremnicaStavke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            frmOtpremaKontejnera otpr = new frmOtpremaKontejnera(Convert.ToInt32(cboOtpremnica.SelectedValue), KorisnikCene);
            otpr.Show();
        }
      
           // RefreshDataGrid();
       /* private void VratiPodatkeMase()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select sum(SopstvenaMasa) as SopM, sum(Tara) as Tara, Sum(Neto) as Neto, (sum(SopstvenaMasa)+sum(Tara)+Sum(Neto))  as Bruto from PrijemKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboPrijemVozom.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
               // txtSopstvenaMasa.Value = Convert.ToDecimal(dr["SopM"].ToString());
                txtTara.Value = Convert.ToDecimal(dr["Tara"].ToString());
                txtNeto.Value = Convert.ToDecimal(dr["Neto"].ToString());
                txtBruto.Value = Convert.ToDecimal(dr["Bruto"].ToString());
                // txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }*/

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            txtTara.Text = "0";
            txtNeto.Text = "0";
            txtBruto.Text = "0";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Selected)
                {
                    //Panta1
                    txtTara.Text = (Convert.ToDecimal(txtTara.Text) + Convert.ToDecimal(row.Cells[5].Value.ToString())).ToString();
                    txtNeto.Text = (Convert.ToDecimal(txtNeto.Text) + Convert.ToDecimal(row.Cells[6].Value.ToString())).ToString();
                    txtBruto.Text = (Convert.ToDecimal(txtBruto.Text) + Convert.ToDecimal(row.Cells[7].Value.ToString())).ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var select = "  SELECT DISTINCT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
      " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
      " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
      " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
      " ,Promet.[Datum] ,Promet.[Korisnik], TipKontenjera.Naziv, VrstaRobe.Nkm as NHM, VrstaRobe.Naziv  " +
      " FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
      " inner join Pozicija on Promet.LokacijaU = Pozicija.ID " +
     "   inner join PrijemKontejneraVozStavke on Promet.[PrOznSled] = PrijemKontejneraVozStavke.Id " +
     " inner join TipKontenjera on TipKontenjera.Id = PrijemKontejneraVozStavke.TipKontejnera " +
     " inner join VrstaRobe on VrstaRobe.Id = PrijemKontejneraVozStavke.VrstaRobe" +
      "  where Zatvoren = 0 and Promet.[BrojKontejnera] = " + "'" + txtBrojKontejnera.Text + "'";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "Šifra";
            dataGridView3.Columns[0].Width = 40;
            // dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Datum Transakcije";
            dataGridView3.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Vrsta Dokumenta";
            dataGridView3.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Br Dokumenta";
            dataGridView3.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Vrsta Prometa";
            dataGridView3.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Broj kontejnera";
            dataGridView3.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "PrPrimKol";
            dataGridView3.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "SkladID ";
            dataGridView3.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Skladiste u";
            dataGridView3.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "LokacID ";
            dataGridView3.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Lokac U";
            dataGridView3.Columns[10].Width = 80;

            DataGridViewColumn column12 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Oznaka sled";
            dataGridView3.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Datum";
            dataGridView3.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "Korisnik";
            dataGridView3.Columns[13].Width = 80;

            DataGridViewColumn column15 = dataGridView3.Columns[14];
            dataGridView3.Columns[14].HeaderText = "Tip kontejnera";
            dataGridView3.Columns[14].Width = 80;

            DataGridViewColumn column16 = dataGridView3.Columns[15];
            dataGridView3.Columns[15].HeaderText = "NHM";
            dataGridView3.Columns[15].Width = 80;

            DataGridViewColumn column17 = dataGridView3.Columns[16];
            dataGridView3.Columns[16].HeaderText = "Roba";
            dataGridView3.Columns[16].Width = 80;
        }

        private void tsNazad_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmBukingKolaKontrejner buk = new frmBukingKolaKontrejner();
            buk.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Selected)
                        {
                            InsertOtpremaKontejneraStavke ins = new InsertOtpremaKontejneraStavke();
                            ins.DeleteOtpremaKontejneraVozStav(Convert.ToInt32(row.Cells[0].Value.ToString()));
                        }
                    }
                    RefreshOtpremnicaStavke();

                }
                catch
                {
                    MessageBox.Show("Nije uspela selekcija stavki");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }
    }
        
    }


