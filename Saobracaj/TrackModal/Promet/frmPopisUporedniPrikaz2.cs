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

namespace Testiranje.Promet
{
    public partial class frmPopisUporedniPrikaz2 : Form
    {
        public frmPopisUporedniPrikaz2()
        {
            InitializeComponent();
        }

        public frmPopisUporedniPrikaz2(int broj)
        {
            InitializeComponent();
            txtSifra.Text = broj.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertPopis ins = new InsertPopis();
            ins.InsertPopisStavkeUporedni(Convert.ToInt32(txtSifra.Text));
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            var select = " SELECT [ID]  ,[IDNadredjenog] ,[BrojKontejnera] " +
       " ,[SkladisteUNaziv]  ,[LokacijaUOznaka] " +
      " ,[SkladistePUNaziv],[LokacijaIzOznaka],[SkladistePIZNaziv]  ,[LokacijaPIZOznaka] " +
       " ,[PrOznSled] " + 
      "  FROM[dbo].[PopisStavkeUporedni] ";
          
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
            dataGridView1.Columns[1].HeaderText = "Broj popisa";
            dataGridView1.Columns[1].Width = 50;
           
            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Skladište popisa";
            dataGridView1.Columns[3].Width = 90;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Lokacija popisa";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Sklad pre U";
            dataGridView1.Columns[5].Width = 90;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Lokac pre U";
            dataGridView1.Columns[6].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Sklad pre IZ";
            dataGridView1.Columns[7].Width = 90;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Lok pre IZ";
            dataGridView1.Columns[8].Width = 70;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Oznaka sledivosti";
            dataGridView1.Columns[9].Width = 70;


        }
    }
}
