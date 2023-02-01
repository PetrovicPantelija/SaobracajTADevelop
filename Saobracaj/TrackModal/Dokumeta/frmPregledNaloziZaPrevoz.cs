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
    public partial class frmPregledNaloziZaPrevoz : Form
    {
        string KorisnikTekuci = "";
        public frmPregledNaloziZaPrevoz()
        {
            InitializeComponent();
        }

        public frmPregledNaloziZaPrevoz(string Korisnik)
        {
            InitializeComponent();
            KorisnikTekuci = Korisnik;
        }

        private void frmPregledNaloziZaPrevoz_Load(object sender, EventArgs e)
        {

        }

        private void RefreshDataGrid()
        {
            if (chk1.Checked == true)
            {
                var select = "SELECT [ID] ,[BrojKontejnera1] ,[BrojKontejnera2] " +
     " ,[UkupnaMasa] ,[Relacija1],[Relacija2],[DatumPrevoza] " +
     " ,[VrstaRobe],[UkupnaMasa2],[Platilac] ,[OrganizacionaJedinica] " +
     " ,[UtovarnoMesto],[IstovarnoMesto],[KontaktOsoba],[Napomena]" +
     " ,[DatumKreiranja] ,[Primalac],[statusrn],[Datum] ,[Korisnik]  FROM [dbo].[NajavaPrevoza] where [statusrn] = 1" +
  " order by ID desc";
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
                /*
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
                dataGridView1.Columns[9].Width = 100; */
            }
            else if (chk2.Checked == true)
            {
                var select = "SELECT [ID] ,[BrojKontejnera1] ,[BrojKontejnera2] " +
     " ,[UkupnaMasa] ,[Relacija1],[Relacija2],[DatumPrevoza] " +
     " ,[VrstaRobe],[UkupnaMasa2],[Platilac] ,[OrganizacionaJedinica] " +
     " ,[UtovarnoMesto],[IstovarnoMesto],[KontaktOsoba],[Napomena]" +
     " ,[DatumKreiranja] ,[Primalac],[statusrn],[Datum] ,[Korisnik]  FROM [dbo].[NajavaPrevoza] where [statusrn] = 2" +
  " order by ID desc";
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
                /*
                DataGridViewColumn column = dataGridView1.Columns[0];
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 50;

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
                */
            }
            else
            {
                var select = "SELECT [ID] ,[BrojKontejnera1] ,[BrojKontejnera2] " +
   " ,[UkupnaMasa] ,[Relacija1],[Relacija2],[DatumPrevoza] " +
   " ,[VrstaRobe],[UkupnaMasa2],[Platilac] ,[OrganizacionaJedinica] " +
   " ,[UtovarnoMesto],[IstovarnoMesto],[KontaktOsoba],[Napomena]" +
   " ,[DatumKreiranja] ,[Primalac],[statusrn],[Datum] ,[Korisnik]  FROM [dbo].[NajavaPrevoza] where [statusrn] = 3" +
" order by ID desc";
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            }

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
           // string KorisnikCene = " ";
            frmNalogZaPrevoz nal = new frmNalogZaPrevoz(Convert.ToInt32(txtSifra.Text), KorisnikTekuci);
            nal.Show();
        }
    }
}
