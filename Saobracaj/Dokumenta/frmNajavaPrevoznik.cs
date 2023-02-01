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
    public partial class frmNajavaPrevoznik : Form
    {
        bool status = false;
        public frmNajavaPrevoznik()
        {
            InitializeComponent();
        }

        public frmNajavaPrevoznik(string BrojNajave)
        {
            InitializeComponent();
            txtSifraNajave.Text = BrojNajave;
        }

        private void frmNajavaPrevoznik_Load(object sender, EventArgs e)
        {
            var select = " Select PaSifra, Rtrim(PaNaziv) as PaNaziv from Partnerji where Prevoznik = 1";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboPartneri.DataSource = ds.Tables[0];
            cboPartneri.DisplayMember = "PaNaziv";
            cboPartneri.ValueMember = "PaSifra";


            var select2 = " Select Distinct ID, RTrim(Voz) as Voz From Trase";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cmbVoz.DataSource = ds2.Tables[0];
            cmbVoz.DisplayMember = "Voz";
            cmbVoz.ValueMember = "ID";

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboPartneri_Leave(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand command = new SqlCommand(" Select PaSifra, Rtrim(PaNaziv) as PaNaziv, Rtrim(UIC) as UIC, (CASE WHEN Prevoznik > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  as Prevoznik, (CASE WHEN Posiljalac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  as Posiljalac, (CASE WHEN Primalac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  as Primalac from Partnerji where PaNaziv=@NAZIV", conn);
            command.Parameters.AddWithValue("@NAZIV", cboPartneri.Text);
            int result = (Int32)(command.ExecuteScalar());
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                txtOpis.Text = dr[1].ToString();
                txtUIC.Text = dr[2].ToString();
            }
            conn.Close();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            txtOpis.Text = "";
            txtRedosled.Text = "";
            cboPartneri.Text = "";
            txtUIC.Text = "";

            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertNajavaPrevoznik ins = new InsertNajavaPrevoznik();
                // ins.DeleteSaloni();
                ins.InsNajPrevoznik(Convert.ToInt32(txtSifraNajave.Text), Convert.ToInt32(cboPartneri.SelectedValue), cmbVoz.Text);
                RefreshDataGrid();
                status = false;
            }
            else
            {
                InsertNajavaPrevoznik upd = new InsertNajavaPrevoznik();
               /*
                upd.UpdStanice(Convert.ToInt32(txtSifra.Text), txtOpis.Text, chkGranicna.Checked, txtKod.Text, cboDrzava.Text);
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid();
                * */
            }
        }
        private void RefreshDataGrid()
        {
            int pomNaj = Convert.ToInt32(txtSifraNajave.Text);
            var select = "select NajavaPrevoznik.ID,NajavaPrevoznik.IDNajave,  NajavaPrevoznik.Red, NajavaPrevoznik.IDPrevoznik, NajavaPrevoznik.PaNaziv, Partnerji.UIC, NajavaPrevoznik.Voz  from NajavaPrevoznik inner join Partnerji on " +
            " NajavaPrevoznik.IDPrevoznik = Partnerji.PaSifra where NajavaPrevoznik.IDNajave =  " + pomNaj +  "  order by NajavaPrevoznik.Red";
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

            //NajavaPrevoznik.ID,NajavaPrevoznik.IDNajave, NajavaPrevoznik.IDPrevoznik, NajavaPrevoznik.Red, NajavaPrevoznik.PaNaziv, Partnerji.UIC


            string value = dataGridView1.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

          
            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Najava";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "RB";
            dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Šifra partnera";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Naziv";
            dataGridView1.Columns[4].Width = 150;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "UIC";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Voz";
            dataGridView1.Columns[6].Width = 50;
            
        }
    }
}
