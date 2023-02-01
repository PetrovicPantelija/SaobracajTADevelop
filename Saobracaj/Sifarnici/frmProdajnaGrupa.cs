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
using System.Globalization;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms;

namespace Saobracaj.Sifarnici
{
    public partial class frmProdajnaGrupa : Form
    {
        bool status = false;
        public frmProdajnaGrupa()
        {
            InitializeComponent();
        }

        private void frmProdajnaGrupa_Load(object sender, EventArgs e)
        {
            RefreshDataGRid();
        }

        private void RefreshDataGRid()
        {

            var select = "  select PsSifra, PsNaziv  from ProdSkup";

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
            dataGridView1.Columns[1].HeaderText = "Naziv";
            dataGridView1.Columns[1].Width = 250;

          

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
            txtSifra.Text = "";
            txtNaziv.Text = "";
        }

        private void tsSave_Click(object sender, EventArgs e)
        {

            if (status == true)
            {
                InsertProdSkup ins = new InsertProdSkup();
                ins.InsProdSkup(txtNaziv.Text);
                status = false;
            }
            else
            {
                InsertProdSkup upd = new InsertProdSkup();
                upd.UpdProdSkup(Convert.ToInt32(txtSifra.Text), txtNaziv.Text);
            }
            RefreshDataGRid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertProdSkup ins = new InsertProdSkup();
            ins.DeleteProdSkup(Convert.ToInt32(txtSifra.Text));
            status = false;
            RefreshDataGRid();
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
                        txtNaziv.Text = row.Cells[1].Value.ToString();
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
