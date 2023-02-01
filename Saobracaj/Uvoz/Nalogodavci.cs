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

namespace Saobracaj.Uvoz
{
    public partial class Nalogodavci : Form
    {
        bool status = false;
        string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public Nalogodavci()
        {
            InitializeComponent();
            FillGV();
            FillCombo();
        }
        private void FillGV()
        {
            var select = "Select * From Nalogodavci order by ID desc";
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
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Kod";
            dataGridView1.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Naziv";
            dataGridView1.Columns[2].Width = 280;
        }
        private void FillCombo()
        {
            var select = "Select PaSifra,PaNaziv From Partnerji order by PaNaziv";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            cboPartner.DataSource = ds.Tables[0];
            cboPartner.DisplayMember = "PaNaziv";
            cboPartner.ValueMember = "PaSifra";
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            tsNew.Enabled = false;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertNalogodavci ins = new InsertNalogodavci();
            if (status == true)
            {
                ins.InsNalogodavci(Convert.ToInt32(cboPartner.SelectedValue.ToString()), cboPartner.SelectedText.ToString());
            }
            else
            {
                ins.UpdNalogodavci(Convert.ToInt32(txtID.Text.ToString()), Convert.ToInt32(cboPartner.SelectedValue.ToString()), cboPartner.SelectedText.ToString());
            }
            FillGV();
            tsNew.Enabled = true;
            status = false;
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertNalogodavci ins = new InsertNalogodavci();
            ins.DelNalogodavci(Convert.ToInt32(txtID.Text));
            FillGV();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtID.Text = row.Cells[0].Value.ToString();
                    }
                }
            }
            catch { }
        }
    
    }
}
