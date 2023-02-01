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

namespace Saobracaj.Sifarnici
{
    public partial class frmDelovnaMesta : Form
    {
        bool status = false;
        public frmDelovnaMesta()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            var select = " SELECT DmSifra, DmNaziv " +
                     " FROM  DelovnaMesta ";



            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);


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
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Naziv";
            dataGridView1.Columns[1].Width = 150;

          



        }

        private void frmDelovnaMesta_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtDmSifra.Enabled = false;
            txtDmNaziv.Text = "";
          
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
 
          
            if (status == true)
            {
                // txtDeSifra.Text,  txtDePriimek.Text,  txtDeIme.Text, txtDeTelefon1.Text,  txtDeTelefon2.Text ,  txtDeEMail.Text , txtDeUlHisStBivS.Text , txtDeKrajBivS.Text , txtDeSifDelMes.Text ,  txtDeSifStat.Text ,  PomManevrista, PomPomocnik, PomVozovodja, PomPregledacKola, PomMasinovodja)
                //  txtNaziv.Text,  txtUlica.Text,  txtMesto.Text,  txtOblast.Text, txtPosta.Text ,txtDrzava.Text, txtTelefon.Text, txtTR.Text ,  txtNapomena.Text,txtMaticniBroj.Text,  txtEmail.Text,  txtPIB.Text
                InsertDelovnaMesta ins = new InsertDelovnaMesta();
                ins.InsDelovnaMesta(txtDmNaziv.Text);
            }
            else
            {
                InsertDelovnaMesta upd = new InsertDelovnaMesta();
                upd.UpdDelovnaMesta(Convert.ToInt32(txtDmSifra.Text), txtDmNaziv.Text);
            }
            RefreshDataGrid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertDelovnaMesta del = new InsertDelovnaMesta();
            del.DelDelovnaMesta(Convert.ToInt32(txtDmSifra.Text));
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtDmSifra.Text = row.Cells[0].Value.ToString();
                        txtDmNaziv.Text = row.Cells[1].Value.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void tsPoslednja_Click(object sender, EventArgs e)
        {

        }
    }
}
