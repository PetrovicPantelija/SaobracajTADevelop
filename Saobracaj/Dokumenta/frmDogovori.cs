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
    public partial class frmDogovori : Form
    {
        bool status = false;
        int BrojDogovora = 0;
        public frmDogovori()
        {
            InitializeComponent();
        }

        public frmDogovori(string NaStNar)
        {
            InitializeComponent();
            BrojDogovora = Convert.ToInt32(NaStNar);
        }

        private void frmDogovori_Load(object sender, EventArgs e)
        {
            var select3 = " select PaSifra, PaNaziv from Partnerji";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboNaPartPlac.DataSource = ds3.Tables[0];
            cboNaPartPlac.DisplayMember = "PaNaziv";
            cboNaPartPlac.ValueMember = "PaSifra";

            var select4 = " select ID, Naziv from TipSaobPrevoza";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboNaSifObjekt.DataSource = ds4.Tables[0];
            cboNaSifObjekt.DisplayMember = "Naziv";
            cboNaSifObjekt.ValueMember = "ID";


            var select5 = " select NDobSifra, NDobOpis from NacinDobave";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboNaNacinDobave.DataSource = ds5.Tables[0];
            cboNaNacinDobave.DisplayMember = "NDobOpis";
            cboNaNacinDobave.ValueMember = "NDobSifra";

            var select6 = " select MpSifra, Rtrim(MpNaziv) as MpNaziv from MaticniPOdatki";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection5);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboNaPSifra.DataSource = ds6.Tables[0];
            cboNaPSifra.DisplayMember = "MpNaziv";
            cboNaPSifra.ValueMember = "MpSifra";

            if (BrojDogovora != 0)
            {
                RefreshDataGridPoDogovoru(BrojDogovora);
                txtNaStNar.Text = BrojDogovora.ToString();
                VratiPodatke(BrojDogovora);
            }



        }

        private void VratiPodatke(int BrojDogovora)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select NaStNar, NaStatus, NaDatNar, NaPartPlac,  NaNacinDobave, NaSifObjekt,  NaOpomba1 from Narocilo where NaStNar = " + BrojDogovora, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtNaStNar.Text = dr["NaStNar"].ToString();
                dtpNaDatNar.Value = Convert.ToDateTime(dr["NaDatNar"].ToString());
                cboNaPartPlac.SelectedValue = Convert.ToInt32(dr["NaPartPlac"].ToString());
                txtNaStatus.Text = dr["NaStatus"].ToString();
                cboNaNacinDobave.SelectedValue = Convert.ToInt32(dr["NaNacinDobave"].ToString());
                cboNaSifObjekt.SelectedValue = Convert.ToInt32(dr["NaSifObjekt"].ToString());
                txtNaOpomba1.Text = dr["NaOpomba1"].ToString();
            }

            con.Close();
        }

        private void RefreshDataGridPoDogovoru(int BrojDogovora)
        {

            var select = "  Select  NaPNarZap ,  NaPStNar ,  NaPSifra ,  NaPNaziv ,  NaPEM , NaPEM2 ,   NaPKolNar , NaPKolNar2 ,   NaPOpomba ,  NaPNote  from NarociloPostav";



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
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Nadredjeni";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "MpSifra";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Mp Naziv";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "JM1";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "JM2";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Količina";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Količina 2";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Napomena";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Beleška";
            dataGridView1.Columns[9].Width = 180;

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtNaStNar.Enabled = false;
            txtNaStNar.Text = "";
            txtNaOpomba1.Text = "";
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertNarocilo ins = new InsertNarocilo();
                ins.InsNarocilo(txtNaStatus.Text, Convert.ToDateTime(dtpNaDatNar.Value), Convert.ToInt32(cboNaPartPlac.SelectedValue), Convert.ToInt32(cboNaNacinDobave.SelectedValue), Convert.ToInt32(cboNaSifObjekt.SelectedValue), txtNaOpomba1.Text);
            }
            else
            {
                InsertNarocilo upd = new InsertNarocilo();
                upd.UpdNarocilo(Convert.ToInt32(txtNaStNar.Text), txtNaStatus.Text, Convert.ToDateTime(dtpNaDatNar.Value), Convert.ToInt32(cboNaPartPlac.SelectedValue), Convert.ToInt32(cboNaNacinDobave.SelectedValue), Convert.ToInt32(cboNaSifObjekt.SelectedValue), txtNaOpomba1.Text);
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertNarocilo del = new InsertNarocilo();
            del.DeleteNarocilo(Convert.ToInt32(txtNaStNar.Text));
        }

        private void RefreshDataGrid()
        {

            var select = "  Select  NaPNarZap ,  NaPStNar ,  NaPSifra ,  NaPNaziv ,  NaPEM , NaPEM2 ,   NaPKolNar , NaPKolNar2 ,   NaPOpomba ,  NaPNote  from NarociloPostav";



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
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Nadredjeni";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "MpSifra";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Mp Naziv";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "JM1";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "JM2";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Količina";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Količina 2";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Napomena";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Beleška";
            dataGridView1.Columns[9].Width = 180;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            InsertNarocilo ins = new InsertNarocilo();
            ins.InsNarociloStavka( Convert.ToInt32(txtNaStNar.Text), Convert.ToInt32(cboNaPartPlac.SelectedValue), cboNaPartPlac.Text, txtNaPEM.Text, txtNaPem2.Text,  Convert.ToDecimal(txtNaPKolNar.Value), Convert.ToDecimal(txtNaPKolNar2.Value), txtNaPOpomba.Text, txtNaPNote.Text);
            RefreshDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            InsertNarocilo ins = new InsertNarocilo();
            ins.UpdNarociloStavka(Convert.ToInt32(txtNaPNarZap.Text), Convert.ToInt32(txtNaStNar.Text), Convert.ToInt32(cboNaPartPlac.SelectedValue), cboNaPartPlac.Text, txtNaPEM.Text, txtNaPem2.Text, Convert.ToDecimal(txtNaPKolNar.Value), Convert.ToDecimal(txtNaPKolNar2.Value), txtNaPOpomba.Text, txtNaPNote.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertNarocilo ins = new InsertNarocilo();
            ins.DeleteNarociloStavka(Convert.ToInt32(txtNaPNarZap.Text));
        }
    }
}
