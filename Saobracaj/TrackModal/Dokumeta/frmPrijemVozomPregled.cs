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
    public partial class frmPrijemVozomPregled : Form
    {
        string KorisnikCene;

        public frmPrijemVozomPregled()
        {
            InitializeComponent();
        }

        public frmPrijemVozomPregled(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void RefreshDataGrid()
        {
            var select = "SELECT PrijemKontejneraVoz.[ID],Voz.BrVoza, Voz.Relacija, " +
             " CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5) as ETA, " +
          " CASE WHEN PrijemKontejneraVoz.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
         " CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,108),1,5) as ATA, " +
          "  [PrijemKontejneraVoz].Korisnik,[PrijemKontejneraVoz].Datum  " +
            " FROM [dbo].[PrijemKontejneraVoz] " +
           " inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza  " +
           " where PrijemKontejneraVoz.Vozom = 1";
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

        private void RefreshDataGridNajave()
        {
            var select = "SELECT PrijemKontejneraVoz.[ID],Voz.BrVoza, Voz.Relacija, " +
             " CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5) as ETA, " +
          " CASE WHEN PrijemKontejneraVoz.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
         " CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,108),1,5) as ATA, " +
          "  [PrijemKontejneraVoz].Korisnik,[PrijemKontejneraVoz].Datum  " +
            " FROM [dbo].[PrijemKontejneraVoz] " +
           " inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza " +
           " where PrijemKontejneraVoz.StatusPrijema = 0  and PrijemKontejneraVoz.Vozom = 1 order by PrijemKontejneraVoz.[ID] desc";
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

        private void RefreshDataGridPrijemi()
        {
            /*
            var select = "SELECT PrijemKontejneraVoz.[ID],Voz.BrVoza, Voz.Relacija, " +
             " CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5) as ETA, " +
          " CASE WHEN PrijemKontejneraVoz.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
         " CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,108),1,5) as ATA, " +
          "  [PrijemKontejneraVoz].Korisnik,[PrijemKontejneraVoz].Datum  " +
            " FROM [dbo].[PrijemKontejneraVoz] " +
           " inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza " +
           " where PrijemKontejneraVoz.StatusPrijema = 1 and PrijemKontejneraVoz.Vozom = 1  order by PrijemKontejneraVoz.[ID] desc ";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);
            */

            var select = "SELECT PrijemKontejneraVoz.[ID],Voz.BrVoza, Voz.Relacija, " +
            " PrijemKontejneraVoz.[DatumPrijema] as ETA, " +
         " CASE WHEN PrijemKontejneraVoz.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
        " PrijemKontejneraVoz.VremeDolaska as ATA, " +
         "  [PrijemKontejneraVoz].Korisnik,[PrijemKontejneraVoz].Datum  " +
           " FROM [dbo].[PrijemKontejneraVoz] " +
          " inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza " +
          " where PrijemKontejneraVoz.StatusPrijema = 1 and PrijemKontejneraVoz.Vozom = 1  order by PrijemKontejneraVoz.[ID] desc ";
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
            frmPrijemKontejneraVoz ter = new frmPrijemKontejneraVoz(Convert.ToInt32(txtSifra.Text), KorisnikCene,1);
            ter.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmPrijemKontejneraVoz ter = new frmPrijemKontejneraVoz(KorisnikCene, 1);
            ter.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            RefreshDataGridNajave();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            RefreshDataGridPrijemi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGridPoBukinguBrodara();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshDataGridPoKontejneru();
        }

        private void RefreshDataGridPoKontejneru()
        {
        var select = "SELECT PrijemKontejneraVoz.[ID],Voz.BrVoza, Voz.Relacija, " +
            " CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5) as ETA, " +
         " CASE WHEN PrijemKontejneraVoz.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
        " CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,108),1,5) as ATA, " +
         "  [PrijemKontejneraVoz].Korisnik,[PrijemKontejneraVoz].Datum  " +
           " FROM [dbo].[PrijemKontejneraVoz] " +
          " inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza  " +
          " inner join prijemKontejneraVozstavke on PrijemKontejneraVozStavke.IdNadredjenog = PrijemKontejneraVoz.ID " +
          " where PrijemKontejneraVoz.Vozom = 1 and PrijemKontejneraVozStavke.BrojKontejnera = '" + txtBrojKontejnera.Text + " 'order by PrijemKontejneraVoz.[ID] desc ";
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

        private void RefreshDataGridPoBukinguBrodara()
        {
            var select = "SELECT PrijemKontejneraVoz.[ID],Voz.BrVoza, Voz.Relacija, " +
                " CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5) as ETA, " +
             " CASE WHEN PrijemKontejneraVoz.StatusPrijema = 0 THEN '1-Najava' ELSE '2-Prijem' END as Status, " +
            " CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.VremeDolaska,108),1,5) as ATA, " +
             "  [PrijemKontejneraVoz].Korisnik,[PrijemKontejneraVoz].Datum  " +
               " FROM [dbo].[PrijemKontejneraVoz] " +
              " inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza  " +
              " inner join PrijemKontejneraVozStavke on PrijemKontejneraVozStavke.IdNadredjenog = PrijemKontejneraVoz.ID " +
              " where PrijemKontejneraVoz.Vozom = 1 and PrijemKontejneraVozStavke.BukingBrodar = '" + txtBukingBrodar.Text + "' order by PrijemKontejneraVoz.[ID] desc ";
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
    }
}

