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
    public partial class frmLokomotiveNaTrasi : Form
    {
        int pomTrasa = 0;

        bool status = true;

        public frmLokomotiveNaTrasi()
        {
            InitializeComponent();
        }

        public frmLokomotiveNaTrasi(string RadniNalog, Int32 Trasa)
        {
            InitializeComponent();
            txtSifraRN.Text = RadniNalog;
            pomTrasa = Trasa;

            
        }

        private void frmLokomotiveNaTrasi_Load(object sender, EventArgs e)
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

            var select2 = " Select SmSifra, SmSifra as Opis from Mesta where Lokomotiva=1";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboLokomotiva.DataSource = ds2.Tables[0];
            cboLokomotiva.DisplayMember = "Opis";
            cboLokomotiva.ValueMember = "SmSifra";

            var select6 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboStanicaOd.DataSource = ds6.Tables[0];
            cboStanicaOd.DisplayMember = "Stanica";
            cboStanicaOd.ValueMember = "ID";

            var select7 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboStanicaDo.DataSource = ds7.Tables[0];
            cboStanicaDo.DisplayMember = "Stanica";
            cboStanicaDo.ValueMember = "ID";


            RefreshDataGrid();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
           
          
            int pomVucna;
            pomVucna = 1;
            if (status==true)
            {
                if (chkVucna.Checked)
                {
                    pomVucna = 1;
                }
                else
                {
                    pomVucna = 0;
                }
                InsertLokomotiveNaTrasi ins = new InsertLokomotiveNaTrasi();
                ins.InsRNTL(Convert.ToInt32(txtSifraRN.Text), Convert.ToInt32(cboTrase.SelectedValue), cboLokomotiva.Text, txtKomentar.Text,chkVucna.Checked, Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToInt32(txtVreme.Value));
                RefreshDataGrid();
                status = false;
            }
            else
            {
                 
            
                if (chkVucna.Checked)
                {
                    pomVucna = 1;
                }
                else
                {
                    pomVucna = 0;
                }
                InsertLokomotiveNaTrasi upd = new InsertLokomotiveNaTrasi();
                upd.UpdRNTL(Convert.ToInt32(txtSifraRN.Text), Convert.ToInt32(cboTrase.SelectedValue), cboLokomotiva.Text, txtKomentar.Text,chkVucna.Checked, Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToInt32(txtVreme.Value));
                RefreshDataGrid();
                status = false;
            }
        }

        private void RefreshDataGrid()
        {
            var select = " SELECT IDRadnogNaloga, IDTrase, SmSifra,  CASE WHEN Vucna > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Vucna , Komentar, StanicaOd, s1.Opis as Od,  StanicaDo, s2.Opis as Do, Vreme FROM RadniNalogLokNaTrasi " +
                " inner join stanice s1 on s1.ID = StanicaOd " +
                " inner join stanice s2 on s2.ID = StanicaDo " +
                "where IDRadnogNaloga =" + txtSifraRN.Text + " and IDTrase = " + Convert.ToInt32(cboTrase.SelectedValue);

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
            dataGridView1.Columns[1].HeaderText = "Trasa";
            dataGridView1.Columns[1].Width = 60;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Lokomotiva";
            dataGridView1.Columns[2].Width = 60;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Vučna";
            dataGridView1.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Napomena";
            dataGridView1.Columns[4].Width = 260;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "St";
            dataGridView1.Columns[5].Width = 20;


            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Od";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "St";
            dataGridView1.Columns[7].Width = 20;


            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Do";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Vreme";
            dataGridView1.Columns[9].Width = 50;

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
        }

        private void VratiPodatke(string lokomotiva)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select IDRadnogNaloga, IDTrase, SMSifra, Komentar, Vucna, StanicaOd, StanicaDo, Vreme from RadniNalogLokNaTrasi where IDRadnogNaloga=" + txtSifraRN.Text + " and IDTrase = " + Convert.ToInt32(cboTrase.SelectedValue) + "and SmSifra = "  + lokomotiva, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
               cboLokomotiva.SelectedValue = Convert.ToInt32(dr["SmSifra"].ToString());
               txtKomentar.Text = dr["Komentar"].ToString();
                txtVreme.Value = Convert.ToInt32(dr["Vreme"].ToString());
                cboStanicaOd.SelectedValue = Convert.ToInt32(dr["StanicaOd"].ToString());
                cboStanicaDo.SelectedValue = Convert.ToInt32(dr["StanicaDo"].ToString());


                if (dr["Vucna"].ToString() == "1")
                {
                    chkVucna.Checked = true;
                }
                else
                {
                    chkVucna.Checked = false;
                }
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
                       cboLokomotiva.SelectedValue = row.Cells[2].Value.ToString();
                       VratiPodatke(cboLokomotiva.Text);
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
           
            InsertLokomotiveNaTrasi del = new InsertLokomotiveNaTrasi();
            del.delRNTL(Convert.ToInt32(txtSifraRN.Text), Convert.ToInt32(cboTrase.SelectedValue), cboLokomotiva.Text);
            RefreshDataGrid();
        }

    }

}