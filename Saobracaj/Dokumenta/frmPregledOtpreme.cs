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


namespace TrackModal.Dokumeta
{
    public partial class frmPregledOtpreme : Form
    {
        string KorisnikCene;

        public frmPregledOtpreme()
        {
            InitializeComponent();
        }

        public frmPregledOtpreme(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void RefreshDataGrid()
        {
            if (chkVoz.Checked == true)
            {
                var select = "SELECT top 500 [ID],[DatumOtpreme],[StatusOtpreme],[IdVoza],[RegBrKamiona],[ImeVozaca],[VremeOdlaska] ,[NacinOtpreme] ,[Datum] ,[Korisnik]  FROM [dbo].[OtpremaKontejnera] where NacinOtpreme = 1 order by ID desc";
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
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 50;

                DataGridViewColumn column2 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Datum otpreme";
                dataGridView1.Columns[1].Width = 150;

                DataGridViewColumn column3 = dataGridView1.Columns[2];
                dataGridView1.Columns[2].HeaderText = "Status otpreme";
                dataGridView1.Columns[2].Width = 300;

                DataGridViewColumn column4 = dataGridView1.Columns[3];
                dataGridView1.Columns[3].HeaderText = "Voz";
                dataGridView1.Columns[3].Width = 100;

                DataGridViewColumn column5 = dataGridView1.Columns[4];
                dataGridView1.Columns[4].HeaderText = "Reg Br Kamiona";
                dataGridView1.Columns[4].Width = 100;

                DataGridViewColumn column6 = dataGridView1.Columns[5];
                dataGridView1.Columns[5].HeaderText = "Ime vozača";
                dataGridView1.Columns[5].Width = 100;

                DataGridViewColumn column7 = dataGridView1.Columns[6];
                dataGridView1.Columns[6].HeaderText = "Otpremljen vozom";
                dataGridView1.Columns[6].Width = 100;

                DataGridViewColumn column8 = dataGridView1.Columns[7];
                dataGridView1.Columns[7].HeaderText = "Datum odlaska";
                dataGridView1.Columns[7].Width = 100;

                DataGridViewColumn column9 = dataGridView1.Columns[8];
                dataGridView1.Columns[8].HeaderText = "Datum";
                dataGridView1.Columns[8].Width = 100;

                DataGridViewColumn column10 = dataGridView1.Columns[9];
                dataGridView1.Columns[9].HeaderText = "Korisnik";
                dataGridView1.Columns[9].Width = 100;
            }
            else
            {
                var select = "SELECT top 500 [ID],[DatumOtpreme],[StatusOtpreme],[IdVoza],[RegBrKamiona],[ImeVozaca],[VremeOdlaska] ,[NacinOtpreme] ,[Datum] ,[Korisnik]  FROM [dbo].[OtpremaKontejnera] where NacinOtpreme = 0 order by ID desc";
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
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 50;

                DataGridViewColumn column2 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Datum otpreme";
                dataGridView1.Columns[1].Width = 150;

                DataGridViewColumn column3 = dataGridView1.Columns[2];
                dataGridView1.Columns[2].HeaderText = "Status otpreme";
                dataGridView1.Columns[2].Width = 300;

                DataGridViewColumn column4 = dataGridView1.Columns[3];
                dataGridView1.Columns[3].HeaderText = "Voz";
                dataGridView1.Columns[3].Width = 100;

                DataGridViewColumn column5 = dataGridView1.Columns[4];
                dataGridView1.Columns[4].HeaderText = "Reg Br Kamiona";
                dataGridView1.Columns[4].Width = 100;

                DataGridViewColumn column6 = dataGridView1.Columns[5];
                dataGridView1.Columns[5].HeaderText = "Ime vozača";
                dataGridView1.Columns[5].Width = 100;

                DataGridViewColumn column7 = dataGridView1.Columns[6];
                dataGridView1.Columns[6].HeaderText = "Otpremljen vozom";
                dataGridView1.Columns[6].Width = 100;

                DataGridViewColumn column8 = dataGridView1.Columns[7];
                dataGridView1.Columns[7].HeaderText = "Datum odlaska";
                dataGridView1.Columns[7].Width = 100;

                DataGridViewColumn column9 = dataGridView1.Columns[8];
                dataGridView1.Columns[8].HeaderText = "Datum";
                dataGridView1.Columns[8].Width = 100;

                DataGridViewColumn column10 = dataGridView1.Columns[9];
                dataGridView1.Columns[9].HeaderText = "Korisnik";
                dataGridView1.Columns[9].Width = 100;
            
            }
        }

        private void PrijemVozomPregled_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();

                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmOtpremaKontejnera ter = new frmOtpremaKontejnera(Convert.ToInt32(txtSifra.Text), KorisnikCene);
            ter.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void frmPregledOtpreme_Load(object sender, EventArgs e)
        {
           // RefreshDataGrid();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            frmOtpremaKontejnera otpr = new frmOtpremaKontejnera(Convert.ToInt32(txtSifra.Text), KorisnikCene);
            otpr.Show();
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmOtpremaKontejnera otpr = new frmOtpremaKontejnera(KorisnikCene, 1);
            otpr.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            REfreshDataGridOtpremaNajava();
        }
        public void REfreshDataGridOtpremaNajava()
        {
            var select = " SELECT top 500 OtpremaKontejnera.[ID],Voz.BrVoza, Voz.Relacija, " +
               " OtpremaKontejnera.DatumOtpreme as ETA, " +
                       " CASE WHEN OtpremaKontejnera.StatusOtpreme = 0 THEN '1-Najava' ELSE '2-Otpremljen' END as Status, " +
                    " OtpremaKontejnera.VremeOdlaska as ATA, " +
          "  OtpremaKontejnera.[Datum] ,OtpremaKontejnera.[Korisnik] " +
         "   FROM [dbo].[OtpremaKontejnera] " +
              " inner join Voz on Voz.ID = OtpremaKontejnera.IdVoza " +
            " where OtpremaKontejnera.StatusOtpreme = 0  " +
          " and NacinOtpreme = 1 order by OtpremaKontejnera.ID desc ";
/*
            var select = " SELECT top 500 OtpremaKontejnera.[ID],Voz.BrVoza, Voz.Relacija, " +
                " CONVERT(varchar,OtpremaKontejnera.DatumOtpreme,104)      + ' '      + SUBSTRING(CONVERT(varchar,OtpremaKontejnera.[DatumOtpreme],108),1,5) as ETA, " +
                        " CASE WHEN OtpremaKontejnera.StatusOtpreme = 0 THEN '1-Najava' ELSE '2-Otpremljen' END as Status, " +
                     " CONVERT(varchar,OtpremaKontejnera.VremeOdlaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,OtpremaKontejnera.[VremeOdlaska],108),1,5) as ATA, " +
           "  OtpremaKontejnera.[Datum] ,OtpremaKontejnera.[Korisnik] " +
          "   FROM [dbo].[OtpremaKontejnera] " +
               " inner join Voz on Voz.ID = OtpremaKontejnera.IdVoza " +
             " where OtpremaKontejnera.StatusOtpreme = 0  " +
           " and NacinOtpreme = 1 order by OtpremaKontejnera.ID desc ";
*/
           /*
            var select = "SELECT PrijemKontejneraVoz.[ID],Voz.BrVoza, Voz.Relacija, " +
               " CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5) as ETA, " +
            " CASE WHEN PrijemKontejneraVoz.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
           " CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,108),1,5) as ATA, " +
            "  [PrijemKontejneraVoz].Korisnik,[PrijemKontejneraVoz].Datum  " +
              " FROM [dbo].[PrijemKontejneraVoz] " +
             " inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza " +
             " where PrijemKontejneraVoz.StatusPrijema = 0  order by PrijemKontejneraVoz.[ID] desc";
           */
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Br Voza";
            dataGridView1.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Relacija";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "ETA";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Status";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "ATA";
            dataGridView1.Columns[5].Width = 150;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Datum";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Korisnik";
            dataGridView1.Columns[7].Width = 100;
        
        
        
        }

        public void REfreshDataGridOtpremaOtpremljen()
        {
            var select = " SELECT top 500 OtpremaKontejnera.[ID],Voz.BrVoza, Voz.Relacija, " +
                " CONVERT(varchar,OtpremaKontejnera.DatumOtpreme,104)      + ' '      + SUBSTRING(CONVERT(varchar,OtpremaKontejnera.[DatumOtpreme],108),1,5) as ETA, " +
                        " CASE WHEN OtpremaKontejnera.StatusOtpreme = 0 THEN '1-Najava' ELSE '2-Otpremljen' END as Status, " +
                     " CONVERT(varchar,OtpremaKontejnera.VremeOdlaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,OtpremaKontejnera.[VremeOdlaska],108),1,5) as ATA, " +
           "  OtpremaKontejnera.[Datum] ,OtpremaKontejnera.[Korisnik] " +
          "   FROM [dbo].[OtpremaKontejnera] " +
               " inner join Voz on Voz.ID = OtpremaKontejnera.IdVoza " +
             " where OtpremaKontejnera.StatusOtpreme = 1  " +
           " and NacinOtpreme = 1 order by OtpremaKontejnera.ID desc ";
            /*
             var select = "SELECT PrijemKontejneraVoz.[ID],Voz.BrVoza, Voz.Relacija, " +
                " CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5) as ETA, " +
             " CASE WHEN PrijemKontejneraVoz.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
            " CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,108),1,5) as ATA, " +
             "  [PrijemKontejneraVoz].Korisnik,[PrijemKontejneraVoz].Datum  " +
               " FROM [dbo].[PrijemKontejneraVoz] " +
              " inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza " +
              " where PrijemKontejneraVoz.StatusPrijema = 0  order by PrijemKontejneraVoz.[ID] desc";
            */
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Br Voza";
            dataGridView1.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Relacija";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "ETA";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Status";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "ATA";
            dataGridView1.Columns[5].Width = 150;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Korisnik";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Datum";
            dataGridView1.Columns[7].Width = 100;



        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            REfreshDataGridOtpremaOtpremljen();
        }

        private void RefreshDataGridPoKontejneru()
        {
            if (chkVoz.Checked == true)
            {
                var select = "SELECT Distinct top 500 OtpremaKontejnera.[ID],OtpremaKontejnera.[DatumOtpreme],OtpremaKontejnera.[StatusOtpreme],OtpremaKontejnera.[IdVoza],OtpremaKontejnera.[RegBrKamiona]," +
                    "OtpremaKontejnera.[ImeVozaca],OtpremaKontejnera.[VremeOdlaska] ,OtpremaKontejnera.[NacinOtpreme] ,OtpremaKontejnera.[Datum], OtpremaKontejnera.[Korisnik]  FROM [dbo].[OtpremaKontejnera]" +
                    " inner join OtpremaKontejneraVozStavke on OtpremaKontejneraVozStavke.IDNAdredjenog = [OtpremaKontejnera].ID" +
                    " where OtpremaKontejneraVozStavke.BrojKontejnera = '" + txtBrojKontejnera.Text + "' order by OtpremaKontejnera.ID desc";
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
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 50;

                DataGridViewColumn column2 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Datum otpreme";
                dataGridView1.Columns[1].Width = 150;

                DataGridViewColumn column3 = dataGridView1.Columns[2];
                dataGridView1.Columns[2].HeaderText = "Status otpreme";
                dataGridView1.Columns[2].Width = 100;

                DataGridViewColumn column4 = dataGridView1.Columns[3];
                dataGridView1.Columns[3].HeaderText = "Voz";
                dataGridView1.Columns[3].Width = 100;

                DataGridViewColumn column5 = dataGridView1.Columns[4];
                dataGridView1.Columns[4].HeaderText = "Reg Br Kamiona";
                dataGridView1.Columns[4].Width = 100;

                DataGridViewColumn column6 = dataGridView1.Columns[5];
                dataGridView1.Columns[5].HeaderText = "Ime vozača";
                dataGridView1.Columns[5].Width = 100;

                DataGridViewColumn column7 = dataGridView1.Columns[6];
                dataGridView1.Columns[6].HeaderText = "Otpremljen vozom";
                dataGridView1.Columns[6].Width = 100;

                DataGridViewColumn column8 = dataGridView1.Columns[7];
                dataGridView1.Columns[7].HeaderText = "Datum odlaska";
                dataGridView1.Columns[7].Width = 100;

                DataGridViewColumn column9 = dataGridView1.Columns[8];
                dataGridView1.Columns[8].HeaderText = "Datum";
                dataGridView1.Columns[8].Width = 100;

                DataGridViewColumn column10 = dataGridView1.Columns[9];
                dataGridView1.Columns[9].HeaderText = "Korisnik";
                dataGridView1.Columns[9].Width = 100;
            }
            else
            {
                var select = "SELECT Distinct top 500 OtpremaKontejnera.[ID],OtpremaKontejnera.[DatumOtpreme],OtpremaKontejnera.[StatusOtpreme],OtpremaKontejnera.[IdVoza],OtpremaKontejnera.[RegBrKamiona]," +
                     "OtpremaKontejnera.[ImeVozaca],OtpremaKontejnera.[VremeOdlaska] ,OtpremaKontejnera.[NacinOtpreme] ,OtpremaKontejnera.[Datum], OtpremaKontejnera.[Korisnik]  FROM [dbo].[OtpremaKontejnera]" +
                     " inner join OtpremaKontejneraVozStavke on OtpremaKontejneraVozStavke.IDNAdredjenog = [OtpremaKontejnera].ID" +
                     " where OtpremaKontejneraVozStavke.BrojKontejnera = '" + txtBrojKontejnera.Text + "' order by OtpremaKontejnera.ID desc"; var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

                DataGridViewColumn column = dataGridView1.Columns[0];
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 50;

                DataGridViewColumn column2 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Datum otpreme";
                dataGridView1.Columns[1].Width = 150;

                DataGridViewColumn column3 = dataGridView1.Columns[2];
                dataGridView1.Columns[2].HeaderText = "Status otpreme";
                dataGridView1.Columns[2].Width = 300;

                DataGridViewColumn column4 = dataGridView1.Columns[3];
                dataGridView1.Columns[3].HeaderText = "Voz";
                dataGridView1.Columns[3].Width = 100;

                DataGridViewColumn column5 = dataGridView1.Columns[4];
                dataGridView1.Columns[4].HeaderText = "Reg Br Kamiona";
                dataGridView1.Columns[4].Width = 100;

                DataGridViewColumn column6 = dataGridView1.Columns[5];
                dataGridView1.Columns[5].HeaderText = "Ime vozača";
                dataGridView1.Columns[5].Width = 100;

                DataGridViewColumn column7 = dataGridView1.Columns[6];
                dataGridView1.Columns[6].HeaderText = "Otpremljen vozom";
                dataGridView1.Columns[6].Width = 100;

                DataGridViewColumn column8 = dataGridView1.Columns[7];
                dataGridView1.Columns[7].HeaderText = "Datum odlaska";
                dataGridView1.Columns[7].Width = 100;

                DataGridViewColumn column9 = dataGridView1.Columns[8];
                dataGridView1.Columns[8].HeaderText = "Datum";
                dataGridView1.Columns[8].Width = 100;

                DataGridViewColumn column10 = dataGridView1.Columns[9];
                dataGridView1.Columns[9].HeaderText = "Korisnik";
                dataGridView1.Columns[9].Width = 100;

            }
        }

        private void RefreshDataGridPoBukingu()
        {
            if (chkVoz.Checked == true)
            {
                var select = "SELECT Distinct top 500 OtpremaKontejnera.[ID],OtpremaKontejnera.[DatumOtpreme],OtpremaKontejnera.[StatusOtpreme],OtpremaKontejnera.[IdVoza],OtpremaKontejnera.[RegBrKamiona]," +
                    "OtpremaKontejnera.[ImeVozaca],OtpremaKontejnera.[VremeOdlaska] ,OtpremaKontejnera.[NacinOtpreme] ,OtpremaKontejnera.[Datum], OtpremaKontejnera.[Korisnik]  FROM [dbo].[OtpremaKontejnera]" +
                    " inner join OtpremaKontejneraVozStavke on OtpremaKontejneraVozStavke.IDNAdredjenog = [OtpremaKontejnera].ID" +
                    " where OtpremaKontejneraVozStavke.Buking = '" + txtBukingBrodar.Text + "' order by OtpremaKontejnera.ID desc";

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
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 50;

                DataGridViewColumn column2 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Datum otpreme";
                dataGridView1.Columns[1].Width = 150;

                DataGridViewColumn column3 = dataGridView1.Columns[2];
                dataGridView1.Columns[2].HeaderText = "Status otpreme";
                dataGridView1.Columns[2].Width = 300;

                DataGridViewColumn column4 = dataGridView1.Columns[3];
                dataGridView1.Columns[3].HeaderText = "Voz";
                dataGridView1.Columns[3].Width = 100;

                DataGridViewColumn column5 = dataGridView1.Columns[4];
                dataGridView1.Columns[4].HeaderText = "Reg Br Kamiona";
                dataGridView1.Columns[4].Width = 100;

                DataGridViewColumn column6 = dataGridView1.Columns[5];
                dataGridView1.Columns[5].HeaderText = "Ime vozača";
                dataGridView1.Columns[5].Width = 100;

                DataGridViewColumn column7 = dataGridView1.Columns[6];
                dataGridView1.Columns[6].HeaderText = "Otpremljen vozom";
                dataGridView1.Columns[6].Width = 100;

                DataGridViewColumn column8 = dataGridView1.Columns[7];
                dataGridView1.Columns[7].HeaderText = "Datum odlaska";
                dataGridView1.Columns[7].Width = 100;

                DataGridViewColumn column9 = dataGridView1.Columns[8];
                dataGridView1.Columns[8].HeaderText = "Datum";
                dataGridView1.Columns[8].Width = 100;

                DataGridViewColumn column10 = dataGridView1.Columns[9];
                dataGridView1.Columns[9].HeaderText = "Korisnik";
                dataGridView1.Columns[9].Width = 100;
            }
            else
            {
                var select = "SELECT Distinct top 500 OtpremaKontejnera.[ID],OtpremaKontejnera.[DatumOtpreme],OtpremaKontejnera.[StatusOtpreme],OtpremaKontejnera.[IdVoza],OtpremaKontejnera.[RegBrKamiona]," +
                     "OtpremaKontejnera.[ImeVozaca],OtpremaKontejnera.[VremeOdlaska] ,OtpremaKontejnera.[NacinOtpreme] ,OtpremaKontejnera.[Datum], OtpremaKontejnera.[Korisnik]  FROM [dbo].[OtpremaKontejnera]" +
                     " inner join OtpremaKontejneraVozStavke on OtpremaKontejneraVozStavke.IDNAdredjenog = [OtpremaKontejnera].ID" +
                     " where OtpremaKontejneraVozStavke.Buking = '" + txtBukingBrodar.Text + "' order by OtpremaKontejnera.ID desc";

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
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 50;

                DataGridViewColumn column2 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Datum otpreme";
                dataGridView1.Columns[1].Width = 150;

                DataGridViewColumn column3 = dataGridView1.Columns[2];
                dataGridView1.Columns[2].HeaderText = "Status otpreme";
                dataGridView1.Columns[2].Width = 300;

                DataGridViewColumn column4 = dataGridView1.Columns[3];
                dataGridView1.Columns[3].HeaderText = "Voz";
                dataGridView1.Columns[3].Width = 100;

                DataGridViewColumn column5 = dataGridView1.Columns[4];
                dataGridView1.Columns[4].HeaderText = "Reg Br Kamiona";
                dataGridView1.Columns[4].Width = 100;

                DataGridViewColumn column6 = dataGridView1.Columns[5];
                dataGridView1.Columns[5].HeaderText = "Ime vozača";
                dataGridView1.Columns[5].Width = 100;

                DataGridViewColumn column7 = dataGridView1.Columns[6];
                dataGridView1.Columns[6].HeaderText = "Otpremljen vozom";
                dataGridView1.Columns[6].Width = 100;

                DataGridViewColumn column8 = dataGridView1.Columns[7];
                dataGridView1.Columns[7].HeaderText = "Datum odlaska";
                dataGridView1.Columns[7].Width = 100;

                DataGridViewColumn column9 = dataGridView1.Columns[8];
                dataGridView1.Columns[8].HeaderText = "Datum";
                dataGridView1.Columns[8].Width = 100;

                DataGridViewColumn column10 = dataGridView1.Columns[9];
                dataGridView1.Columns[9].HeaderText = "Korisnik";
                dataGridView1.Columns[9].Width = 100;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshDataGridPoKontejneru();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGridPoBukingu();
        }
    }
}


