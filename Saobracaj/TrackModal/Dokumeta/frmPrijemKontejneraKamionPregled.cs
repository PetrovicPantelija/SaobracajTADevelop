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



namespace Testiranje.Dokumeta
{
    public partial class frmPrijemKontejneraKamionPregled : Form
    {
        string KorisnikCene;
        public frmPrijemKontejneraKamionPregled()
        {
            InitializeComponent();
        }
        public frmPrijemKontejneraKamionPregled(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void RefreshDataGrid()
        {
            /*
            var select = "SELECT [ID]," +
                 " CONVERT(varchar,DatumPrijema,104)      + ' '      + SUBSTRING(CONVERT(varchar,DatumPrijema,108),1,5) as DatumPrijema, " +
                 " CASE WHEN n1.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
                " REgBrKamiona, ImeVozaca, " +
                " CONVERT(varchar,VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,VremeDolaska,108),1,5) as VremeDolaska, " +
               " [Datum] ,[Korisnik]," +
               
" (  SELECT  STUFF((SELECT distinct   '/ ' + Cast(ts.BrojKontejnera as nvarchar(20)) " +
 "  FROM PrijemKontejneraVozStavke ts where n1.ID = ts.IDNadredjenog " +
 " FOR XML PATH('')), 1, 1, ''  ) As Skupljen) " +
 " as Kontejner "+
               " FROM [dbo].[PrijemKontejneraVoz] as n1 where Vozom = 0";
            */

            var select = "SELECT [ID]," +
                " DatumPrijema as DatumPrijema, " +
                " CASE WHEN n1.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
               " REgBrKamiona, ImeVozaca, " +
               " VremeDolaska as VremeDolaska, " +
              " [Datum] ,[Korisnik]," +

" (  SELECT  STUFF((SELECT distinct   '/ ' + Cast(ts.BrojKontejnera as nvarchar(20)) " +
"  FROM PrijemKontejneraVozStavke ts where n1.ID = ts.IDNadredjenog " +
" FOR XML PATH('')), 1, 1, ''  ) As Skupljen) " +
" as Kontejner " +
              " FROM [dbo].[PrijemKontejneraVoz] as n1 where Vozom = 0";



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
            dataGridView1.Columns[1].HeaderText = "ETA";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Status prijema";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Reg. br. vozila";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Ime vozača";
            dataGridView1.Columns[4].Width = 150;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "ATA";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Datum unosa";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Korisnik";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Kontejneri";
            dataGridView1.Columns[8].Width = 200;


        }

        private void RefreshDataGridNajave()
        {
            var select = "SELECT [ID]," +
                 " CONVERT(varchar,DatumPrijema,104)      + ' '      + SUBSTRING(CONVERT(varchar,DatumPrijema,108),1,5) as DatumPrijema, " +
                 " CASE WHEN n1.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
                " REgBrKamiona, ImeVozaca, " +
                " CONVERT(varchar,VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,VremeDolaska,108),1,5) as VremeDolaska, " +
               " [Datum] ,[Korisnik] ," +


" (  SELECT  STUFF((SELECT distinct   '/ ' + Cast(ts.BrojKontejnera as nvarchar(20)) " +
 "  FROM PrijemKontejneraVozStavke ts where n1.ID = ts.IDNadredjenog " +
 " FOR XML PATH('')), 1, 1, ''  ) As Skupljen) " +
 " as Kontejner " +
               "FROM [dbo].[PrijemKontejneraVoz] as n1 where Vozom = 0 and n1.StatusPrijema = 0";
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
            dataGridView1.Columns[1].HeaderText = "ETA";
            dataGridView1.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Status prijema";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Reg. br. vozila";
            dataGridView1.Columns[3].Width = 200;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Ime vozača";
            dataGridView1.Columns[4].Width = 300;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "ATA";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Datum unosa";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Korisnik";
            dataGridView1.Columns[7].Width = 100;


        }

        private void RefreshDataGridPrijemi()
        {
            var select = "SELECT [ID]," +
                 " CONVERT(varchar,DatumPrijema,104)      + ' '      + SUBSTRING(CONVERT(varchar,DatumPrijema,108),1,5) as DatumPrijema, " +
                 " CASE WHEN n1.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
                " REgBrKamiona, ImeVozaca, " +
                " CONVERT(varchar,VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,VremeDolaska,108),1,5) as VremeDolaska, " +
               " [Datum] ,[Korisnik] ," +
" (  SELECT  STUFF((SELECT distinct   '/ ' + Cast(ts.BrojKontejnera as nvarchar(20)) " +
 "  FROM PrijemKontejneraVozStavke ts where n1.ID = ts.IDNadredjenog " +
 " FOR XML PATH('')), 1, 1, ''  ) As Skupljen) " +
 " as Kontejner " +
               " FROM [dbo].[PrijemKontejneraVoz] as n1 where Vozom = 0 and n1.StatusPrijema = 1";
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
            dataGridView1.Columns[1].HeaderText = "ETA";
            dataGridView1.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Status prijema";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Reg. br. vozila";
            dataGridView1.Columns[3].Width = 200;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Ime vozača";
            dataGridView1.Columns[4].Width = 300;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "ATA";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Datum unosa";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Korisnik";
            dataGridView1.Columns[7].Width = 100;


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
            frmPrijemKontejneraVoz ter = new frmPrijemKontejneraVoz(Convert.ToInt32(txtSifra.Text), KorisnikCene, 0);
            ter.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void frmPrijemKontejneraKamionPregled_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmPrijemKontejneraVoz ter = new frmPrijemKontejneraVoz(KorisnikCene, 0);
            ter.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            RefreshDataGridPrijemi();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            RefreshDataGridNajave();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGridPoREgBr();
        }

        private void RefreshDataGridPoREgBr()
        {
            var select = "SELECT [ID]," +
                 " CONVERT(varchar,DatumPrijema,104)      + ' '      + SUBSTRING(CONVERT(varchar,DatumPrijema,108),1,5) as DatumPrijema, " +
                 " CASE WHEN n1.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
                " REgBrKamiona, ImeVozaca, " +
                " CONVERT(varchar,VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,VremeDolaska,108),1,5) as VremeDolaska, " +
               " [Datum] ,[Korisnik]," +

" (  SELECT  STUFF((SELECT distinct   '/ ' + Cast(ts.BrojKontejnera as nvarchar(20)) " +
 "  FROM PrijemKontejneraVozStavke ts where n1.ID = ts.IDNadredjenog " +
 " FOR XML PATH('')), 1, 1, ''  ) As Skupljen) " +
 " as Kontejner " +
               " FROM [dbo].[PrijemKontejneraVoz] as n1 where Vozom = 0 and n1.REgBrKamiona = '" + txtRegBrKamiona.Text + "'";
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
            dataGridView1.Columns[1].HeaderText = "ETA";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Status prijema";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Reg. br. vozila";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Ime vozača";
            dataGridView1.Columns[4].Width = 150;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "ATA";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Datum unosa";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Korisnik";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Kontejneri";
            dataGridView1.Columns[8].Width = 200;


        }

        private void RefreshDataGridPoKontejneru()
        {
            var select = "SELECT n1.[ID], CONVERT(varchar,DatumPrijema,104)      + ' '      + " +
" SUBSTRING(CONVERT(varchar, DatumPrijema, 108), 1, 5) as DatumPrijema,  CASE WHEN n1.StatusPrijema = 0 " +
" THEN '1-Najava' ELSE '2-Prijem' END as Status,  REgBrKamiona, ImeVozaca,  CONVERT(varchar, n1.VremeDolaska, 104) " +
" + ' ' + SUBSTRING(CONVERT(varchar, n1.VremeDolaska, 108), 1, 5) as VremeDolaska,  n1.[Datum] ,n1.[Korisnik], " +
"  (SELECT  STUFF((SELECT distinct   '/ ' + Cast(ts.BrojKontejnera as nvarchar(20)) " +
 " FROM PrijemKontejneraVozStavke ts where n1.ID = ts.IDNadredjenog  FOR XML PATH('')), 1, 1, ''  ) As Skupljen) " +
  "    as Kontejner " +
  "  FROM[dbo].[PrijemKontejneraVoz] as n1 inner join PrijemKontejneraVozStavke as vs on n1.ID = vs.IDNadredjenog" +
  " where Vozom = 0 and vs.BrojKontejnera = '" + txtBrojKontejnera.Text + "'";
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
            dataGridView1.Columns[1].HeaderText = "ETA";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Status prijema";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Reg. br. vozila";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Ime vozača";
            dataGridView1.Columns[4].Width = 150;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "ATA";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Datum unosa";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Korisnik";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Kontejneri";
            dataGridView1.Columns[8].Width = 200;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshDataGridPoKontejneru();
        }

        private void RefreshDataGridPoBukinguBrodara()
        {
            var select = "SELECT n1.[ID], CONVERT(varchar,DatumPrijema,104)      + ' '      + " +
" SUBSTRING(CONVERT(varchar, DatumPrijema, 108), 1, 5) as DatumPrijema,  CASE WHEN n1.StatusPrijema = 0 " +
" THEN '1-Najava' ELSE '2-Prijem' END as Status,  REgBrKamiona, ImeVozaca,  CONVERT(varchar, n1.VremeDolaska, 104) " +
" + ' ' + SUBSTRING(CONVERT(varchar, n1.VremeDolaska, 108), 1, 5) as VremeDolaska,  n1.[Datum] ,n1.[Korisnik], " +
"  (SELECT  STUFF((SELECT distinct   '/ ' + Cast(ts.BrojKontejnera as nvarchar(20)) " +
 " FROM PrijemKontejneraVozStavke ts where n1.ID = ts.IDNadredjenog  FOR XML PATH('')), 1, 1, ''  ) As Skupljen) " +
  "    as Kontejner " +
  "  FROM[dbo].[PrijemKontejneraVoz] as n1 inner join PrijemKontejneraVozStavke as vs on n1.ID = vs.IDNadredjenog" +
  " where Vozom = 0 and vs.BukingBrodar = '" + txtBukingBrodar.Text + "'";
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
            dataGridView1.Columns[1].HeaderText = "ETA";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Status prijema";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Reg. br. vozila";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Ime vozača";
            dataGridView1.Columns[4].Width = 150;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "ATA";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Datum unosa";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Korisnik";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Kontejneri";
            dataGridView1.Columns[8].Width = 200;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGridPoBukinguBrodara();
        }
    }
}

