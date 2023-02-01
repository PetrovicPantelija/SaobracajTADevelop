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
using Microsoft.Reporting.WinForms;

namespace Saobracaj.Dokumenta
{
    public partial class frmKasnjenja : Form
    {
         int pomTrasa = 0;
        public frmKasnjenja()
        {
            InitializeComponent();

        }


        public frmKasnjenja(string RadniNalog, Int32 Trasa)
        {
            InitializeComponent();
            txtSifraRN.Text = RadniNalog;
            pomTrasa = Trasa;
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertUzrociKasnjenjaLok ins = new InsertUzrociKasnjenjaLok();
            ins.InsRNTLU(Convert.ToInt32(txtSifraRN.Text), Convert.ToInt32(cboTrase.SelectedValue), "", dtpVremeKasnjenjaOd.Value, dtpVremeKasnjenjaDo.Value, Convert.ToInt32(txtVremeKasnjenja.Text), Convert.ToInt32(cboUzroci.SelectedValue), txtNapomena.Text);
            RefreshDataGrid1();
            //status = false;
        }

        private void frmKasnjenja_Load(object sender, EventArgs e)
        {
            var select = " Select ID, (Rtrim(Voz) + '-' + Rtrim(Relacija)) as Opis from Trase";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboTrase.DataSource = ds.Tables[0];
            cboTrase.DisplayMember = "Opis";
            cboTrase.ValueMember = "ID";

            cboTrase.SelectedValue = pomTrasa;

            var select2 = " Select ID,  RTrim(Opis) as Opis from Razlozi order by opis";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboUzroci.DataSource = ds2.Tables[0];
            cboUzroci.DisplayMember = "Opis";
            cboUzroci.ValueMember = "ID";
        }

        private void RefreshDataGrid1()
        {
            var select = " select IDRadnogNaloga, RB, IDTrase, IDUzrokaKasnjenja,Razlozi.Tip, Rtrim(Razlozi.Opis) , DatumPolaska, DatumDolaska, " +
            " Vreme, Napomena from RadniNalogTraseLokUzr " +
            " inner join Razlozi on Razlozi.ID = RadniNalogTraseLokUzr.IDUzrokaKasnjenja " +
            " where IDRadnogNaloga =" + Convert.ToInt32(txtSifraRN.Text) + " and IDTrase = " + Convert.ToInt32(cboTrase.SelectedValue) + " Order by RB";

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
            dataGridView1.Columns[0].HeaderText = "RN";
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "ID Trase";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "ID uzroka";
            dataGridView1.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Tip";
            dataGridView1.Columns[4].Width = 120;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Uzrok";
            dataGridView1.Columns[5].Width = 120;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Vreme od";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Vreme do";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Vreme(min)";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Napomena";
            dataGridView1.Columns[9].Width = 120;

        }

        private void dtpVremeKasnjenjaDo_Leave(object sender, EventArgs e)
        {
            TimeSpan span = dtpVremeKasnjenjaDo.Value.Subtract(dtpVremeKasnjenjaOd.Value);
            txtVremeKasnjenja.Text = Convert.ToString(Convert.ToInt32(span.TotalMinutes));
        }
    }
}
