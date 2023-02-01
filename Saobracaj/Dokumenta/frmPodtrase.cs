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
    public partial class frmPodtrase : Form
    {
        int RN = 0;
        int Trasa = 0;
        bool status = false;
        public frmPodtrase()
        {
            InitializeComponent();
        }

        public frmPodtrase(string RadniNalog, string Trasa, string RB)
        {
            InitializeComponent();
            txtRN.Text = RadniNalog;
            txtTrase.Text = Trasa;
            txtRB.Text = RB;
        }

        private void frmPodtrase_Load(object sender, EventArgs e)
        {
            var select = "   Select ID, Oznaka, RTRIM(Opis) as Opis, Elektrificirana from Pruga ";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            cboPruge.DataSource = view;
            cboPruge.DisplayMember = "Opis";
            cboPruge.ValueMember = "Oznaka";
        }

        private void cboPruge_Leave(object sender, EventArgs e)
        {
            var select = "   select StanicaOD, RTRIM((Cast(PrugaStavke.RB as nvarchar(4)) + '-' + stanice.Opis)) as Opis from PrugaStavke " +
            " inner join stanice on PrugaStavke.StanicaOd = Stanice.ID " +
            " where IDPruge = ' " +  cboPruge.SelectedValue +  " ' " +
            " order by PrugaStavke.RB ";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

           

           
            //multiColumnComboBox1.ReadOnly = true;
            cboStanicaOd.DataSource = ds.Tables[0]; ;
            cboStanicaOd.DisplayMember = "Opis";
            cboStanicaOd.ValueMember = "StanicaOd";

            


          
        }

        private void cboStanicaOd_Leave(object sender, EventArgs e)
        {
            var select2 = "   select StanicaOD, RTRIM((Cast(PrugaStavke.RB as nvarchar(4)) + '-' + stanice.Opis)) as Opis from PrugaStavke " +
                " inner join stanice on PrugaStavke.StanicaOd = Stanice.ID " +
                " where IDPruge = ' " + cboPruge.SelectedValue + " ' " +
                " order by PrugaStavke.RB ";


            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);

            cboStanicaDo.DataSource = ds2.Tables[0];
            cboStanicaDo.DisplayMember = "Opis";
            cboStanicaDo.ValueMember = "StanicaOd";
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
           // txtSifra.Text = "";
           // txtSifra.Enabled = false;
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int Elektrificirana = 0;
            if (chkElektrificirana.Checked == true)
            {

                Elektrificirana = 1;
            }


            if (status == true)
            {
                Sifarnici.InsertTrase ins = new Sifarnici.InsertTrase();
                // ins.DeleteSaloni();
                ins.InsPodTras(Convert.ToInt32(txtRN.Text), Convert.ToInt32(txtTrase.Text), Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToDouble(txtRastojanjeKM.Value), Elektrificirana, cboPruge.SelectedValue.ToString().Trim(), cmbKlasa.Text, Convert.ToInt32(txtRB.Text)  );
                //MessageBox.Show("Uspešno uneta stanica");
              //  RefreshDataGrid();
                status = false;
            }
            else
            {
                /*
                InsertGrupaKvarova upd = new InsertGrupaKvarova();
                upd.UpdGRKvarova(Convert.ToInt32(txtSifra.Text), txtOpis.Text);
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid();
                */
            }

            RefreshDataGrid();
        }

        private void cboStanicaDo_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void RefreshDataGrid()
        {
            var select = " SELECT [IDRadnogNaloga]      ,[IDTrase]      ,[IDPodtrase]      ,[StanicaOD] " +
              " ,[StanicaDO]      ,[Rastojanje]      ,[Elektrificirana]      ,[PrugaOznaka] " +
              " ,[TipPruge]      ,[RB]  FROM[TESTIRANJE].[dbo].[PodTrase] " +
              " where IDRadnogNaloga = " + Convert.ToInt32(txtRN.Text) + " and IDTrase = " + Convert.ToInt32(txtTrase.Text) + " and RB =  " + Convert.ToInt32(txtRB.Text) + 
              " order by RB ";


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
            dataGridView1.Columns[0].HeaderText = "ID RN";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "ID Trase";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "ID PodTrase";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Stanica od";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Stanica Do";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Rastojanje";
            dataGridView1.Columns[5].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Elektrificirna";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Pruga ozn";
            dataGridView1.Columns[7].Width = 90;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Tip pruge";
            dataGridView1.Columns[8].Width = 70;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "RB";
            dataGridView1.Columns[9].Width = 50;

        }

        private void cboStanicaDo_Leave(object sender, EventArgs e)
        {
            double StacionazaOd = 0;
            double StacionazaDo = 0; 
            
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("Select StacionazaKM, Klasa from PrugaStavke where StanicaOd = " + Convert.ToInt32(cboStanicaOd.SelectedValue) + " and IdPruge = Rtrim('" + cboPruge.SelectedValue + "')", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
               StacionazaOd = Convert.ToDouble(dr["StacionazaKM"].ToString());
               cmbKlasa.Text = dr["Klasa"].ToString();
            }

            con.Close();

            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con2 = new SqlConnection(s_connection2);

            con2.Open();

            SqlCommand cmd2 = new SqlCommand("Select StacionazaKM, Klasa from PrugaStavke where StanicaOd = " + Convert.ToInt32(cboStanicaDo.SelectedValue) + " and IdPruge = RTrim('" + cboPruge.SelectedValue + "')", con2);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                StacionazaDo = Convert.ToDouble(dr2["StacionazaKM"].ToString());
            }

            con2.Close();
            txtRastojanjeKM.Text = (StacionazaDo - StacionazaOd).ToString();

        }
    }
}
