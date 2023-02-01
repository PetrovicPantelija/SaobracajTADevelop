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

namespace Saobracaj.Dokumenta
{
    public partial class frmTraseRadniNalog : Form
    {
        bool status = false;
        public frmTraseRadniNalog()
        {
            InitializeComponent();
        }
        public frmTraseRadniNalog(string RadniNalog, string Voznja)
        {
            InitializeComponent();
            txtSifraRN.Text = RadniNalog;
            txtBrojNajave.Text = Voznja;
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
        }

        private void frmTraseRadniNalog_Load(object sender, EventArgs e)
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
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            /*
            InsertRadniNalogTrase ins = new InsertRadniNalogTrase();
            ins.InsRNT(Convert.ToInt32(txtSifraRN.Text), Convert.ToInt32(cboTrase.SelectedValue));
                RefreshDataGrid();
                status = false;
            */
        }

        private void RefreshDataGrid()
        {

            // int pomNaj = Convert.ToInt32(txtSifraNajave.Text);
            var select = "SELECT     RadniNalogTrase.IDRadnogNaloga, RadniNalogTrase.RB, RadniNalogTrase.IDTrase, stanice.Opis AS Pocetna, stanice_1.Opis AS Krajnja, Trase.Relacija, " +
                      " Trase.OpisRelacije, Trase.Voz, Trase.TezinaVoza, Trase.TezinaLokomotive, Trase.DuzinaVoza, Trase.ProcenatKocenja, Trase.Rastojanje, Trase.DuzinaTrajanja, " +
                      " Trase.VremePolaska, Trase.VremeDolaska " +
                        " FROM         RadniNalogTrase INNER JOIN " +
                     " Trase ON RadniNalogTrase.IDTrase = Trase.ID INNER JOIN " +
                     " stanice ON Trase.Pocetna = stanice.ID INNER JOIN " +
                      " stanice AS stanice_1 ON Trase.Krajnja = stanice_1.ID where RadniNalogTrase.IDRadnogNaloga =  " + Convert.ToInt32(txtSifraRN.Text) + " order by IDRadnogNaloga";
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

        }
         

    }
}
