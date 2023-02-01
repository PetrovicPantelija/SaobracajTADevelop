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
    public partial class frmRadniNaloziInterni : Form
    {
        bool status = false;
        string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public frmRadniNaloziInterni()
        {
            InitializeComponent();
            FillGV();
        }

        private void FillGV()
        {
            var select = "SELECT RadniNalogInterni.[ID] " +
            ",[OJIzdavanja] , o1.Naziv as Izdao " +
            ",[OJRealizacije] ,o2.Naziv as Realizuje " +
            ",[DatumIzdavanja] ,[DatumRealizacije]" +
            ",[Napomena] ,[Uradjen]" +
            ",[Osnov] ,[BrojOsnov]" +
            ",[KorisnikIzdao] ,[KorisnikZavrsio]" +
            "     FROM [RadniNalogInterni]" +
            " inner join OrganizacioneJedinice as o1 on OjIzdavanja = O1.ID" +
            " inner join OrganizacioneJedinice as o2 on OjRealizacije = O2.ID order by RadniNalogInterni.ID desc";
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
            dataGridView1.Columns[1].HeaderText = "OJIZD";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Izdao";
            dataGridView1.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "OJ REAL";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Realizuje";
            dataGridView1.Columns[4].Width = 90;

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            tsNew.Enabled = false;
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int tmpuradjen = 0;
            
            if (chkZavrsen.Checked == true)
            {
                tmpuradjen = 1;
            }
            InsertRadniNalogInterni ins = new InsertRadniNalogInterni();
            if (status == true)
            {
                ins.InsRadniNalogInterni(Convert.ToInt32(cboIzdatOd.SelectedValue), Convert.ToInt32(cboIzdatZa.SelectedValue),Convert.ToDateTime(dtpDatumIzdavanja.Value), Convert.ToDateTime(dtpDatumRealizacije.Value), txtNapomena.Text, Convert.ToInt32(tmpuradjen), cboOsnov.Text, Convert.ToInt32(txtRefBroj.Text), "panta", "panta");
            }
            else
            {
                ins.UpdRadniNalogInterni(Convert.ToInt32(txtID.Text),Convert.ToInt32(cboIzdatOd.SelectedValue), Convert.ToInt32(cboIzdatZa.SelectedValue), Convert.ToDateTime(dtpDatumIzdavanja.Value), Convert.ToDateTime(dtpDatumRealizacije.Value), txtNapomena.Text, Convert.ToInt32(tmpuradjen), cboOsnov.Text, Convert.ToInt32(txtRefBroj.Text), "panta", "panta");
            }
            FillGV();
            tsNew.Enabled = true;
            status = false;
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertRadniNalogInterni ins = new InsertRadniNalogInterni();
            ins.DelRadniNalogInterni(Convert.ToInt32(txtID.Text));
            FillGV();
        }
        private void VratiPodatke(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID]      ,[OJIzdavanja] " +
             " ,[OJRealizacije]      ,[DatumIzdavanja] " +
             " ,[DatumRealizacije]      ,[Napomena] " +
             " ,[Uradjen]      ,[Osnov] " +
            " ,[BrojOsnov]      ,[KorisnikIzdao] " +
            " ,[KorisnikZavrsio]  FROM [RadniNalogInterni] where ID=" + ID, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cboIzdatOd.SelectedValue = Convert.ToInt32(dr["OJIzdavanja"].ToString());
                dtpDatumIzdavanja.Value = Convert.ToDateTime(dr["DatumIzdavanja"].ToString());
                dtpDatumRealizacije.Value = Convert.ToDateTime(dr["DatumRealizacije"].ToString());
                cboIzdatZa.SelectedValue = Convert.ToInt32(dr["OJRealizacije"].ToString());
                txtNapomena.Text = dr["Napomena"].ToString();
                if (dr["Uradjen"].ToString() == "1")
                {
                    chkZavrsen.Checked = true;
                }
                else
                {
                    chkZavrsen.Checked = false;
                }
                cboOsnov.Text = dr["Osnov"].ToString();
                txtRefBroj.Text = dr["BrojOsnov"].ToString();
              
            }
            con.Close();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtID.Text = row.Cells[0].Value.ToString();
                        VratiPodatke(Convert.ToInt32(txtID.Text));
                    }
                }
            }
            catch { }
        }

        private void frmRadniNaloziInterni_Load(object sender, EventArgs e)
        {
            var select8 = "  Select Distinct ID, Naziv   From OrganizacioneJedinice ";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboIzdatOd.DataSource = ds8.Tables[0];
            cboIzdatOd.DisplayMember = "Naziv";
            cboIzdatOd.ValueMember = "ID";



            var select9 = "  Select Distinct ID, Naziv   From OrganizacioneJedinice ";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection9);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);

            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            cboIzdatZa.DataSource = ds9.Tables[0];
            cboIzdatZa.DisplayMember = "Naziv";
            cboIzdatZa.ValueMember = "ID";
        }
    }
}
