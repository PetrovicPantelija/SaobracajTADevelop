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
    public partial class frmParnerjiKontOsobe : Form
    {
        bool status = false;
        public frmParnerjiKontOsobe()
        {
            InitializeComponent();
        }

        private void frmParnerjiKontOsobe_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            var select = " SELECT  [PaKOZapSt]       ,[PaKOSifra]       ,[PaKOIme] " +
     " ,[PaKOPriimek]       ,[PaKOOddelek]      ,[PaKOTel]      ,[PaKOMail] " +
     " ,[PaKOOpomba]      ,[Operatika]  FROM [TESTIRANJE].[dbo].[partnerjiKontOseba]";
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
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Partner šifra";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Ime";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Prezime";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Odeljenje";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Telefon";
            dataGridView1.Columns[5].Width = 60;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Mail";
            dataGridView1.Columns[6].Width = 60;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Napomena";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Operatika";
            dataGridView1.Columns[8].Width = 100;

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
            txtSifra.Text = "";
            txtPaSifra.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtOdeljenje.Text = "";
            txtTelefon.Text = "";
            txtMail.Text = "";
            txtNapomena.Text = "";
            chkOperatika.Checked = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int pomOperatika = 0;
            if (chkOperatika.Checked == true)
            {
                pomOperatika = 1;
            }

            if (status == true)
            {
              //  txtPaSifra.Text,txtIme.Text ,txtPrezime.Text, txtOdeljenje.Text, txtTelefon.Text,  txtMail.Text,txtNapomena.Text, pomOperatika


                InsertKontaktOsobe ins = new InsertKontaktOsobe();
                ins.InsKontaktOsoba(Convert.ToInt32(txtPaSifra.Text), txtIme.Text, txtPrezime.Text, txtOdeljenje.Text, txtTelefon.Text, txtMail.Text, txtNapomena.Text, pomOperatika);
            }
            else
            {
                InsertKontaktOsobe upd = new InsertKontaktOsobe();
                upd.UpdKontaktOsoba(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtPaSifra.Text), txtIme.Text, txtPrezime.Text, txtOdeljenje.Text, txtTelefon.Text, txtMail.Text, txtNapomena.Text, pomOperatika);
            }
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

                        txtPaSifra.Text = row.Cells[1].Value.ToString();
                        txtIme.Text = row.Cells[2].Value.ToString();
                        txtPrezime.Text = row.Cells[3].Value.ToString();
                        txtOdeljenje.Text = row.Cells[4].Value.ToString();
                        txtTelefon.Text = row.Cells[5].Value.ToString();
                        txtMail.Text = row.Cells[6].Value.ToString();
                        txtNapomena.Text = row.Cells[7].Value.ToString();
                        if (row.Cells[7].Value.ToString() == "1")
                        {
                            chkOperatika.Checked = true;
                        
                        }
                        else
                        {
                            chkOperatika.Checked = false;
                        }
                        RefreshDataGrid();
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
