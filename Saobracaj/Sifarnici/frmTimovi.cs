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

namespace Saobracaj.Sifarnici
{
    public partial class frmTimovi : Form
    {
        bool status = false;
        public frmTimovi()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            var select = " Select * from Tim";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Naziv";
            dataGridView1.Columns[1].Width = 350;
        }

        private void DataGridView2Refresh()
        {
            var select = "select IDTima, Korisnik, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Ime from PripadnostTimu " +
            " inner join Delavci on Delavci.DeSifra = PripadnostTimu.Korisnik " +
            " inner join Tim on Tim.ID = PripadnostTimu.IdTima where PripadnostTimu.IdTima =  " + Convert.ToInt32(txtSifra.Text);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.AutoResizeColumns() ;
        }

        private void frmTimovi_Load(object sender, EventArgs e)
        {
            var select = " SELECT     Delavci.DeSifra, RTRIM(Delavci.DePriimek) + ' ' + RTRIM(Delavci.DeIme) AS Naziv from Delavci where DeSifStat <> 'P'";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboKorisnik.DataSource = ds.Tables[0];
            cboKorisnik.DisplayMember = "Naziv";
            cboKorisnik.ValueMember = "DeSifra";

            RefreshDataGrid();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            txtSifra.Text = "";
            txtOpis.Text = "";
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertTimovi ins = new InsertTimovi();
                ins.InsTim(txtOpis.Text);
                RefreshDataGrid();
                status = false;
            }
            else
            {
                InsertTimovi upd = new InsertTimovi();
                upd.UpdTim(Convert.ToInt32(txtSifra.Text), txtOpis.Text);
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertTimovi ins = new InsertTimovi();
            ins.InsPripTim(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboKorisnik.SelectedValue));
            RefreshDataGrid();
            DataGridView2Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InsertTimovi ins = new InsertTimovi();
            ins.UpdPripTim(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboKorisnik.SelectedValue));
            RefreshDataGrid();
            DataGridView2Refresh();
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
                        txtOpis.Text = row.Cells[1].Value.ToString();
                        DataGridView2Refresh();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela promena stavki");
            }
        }
    }
}
