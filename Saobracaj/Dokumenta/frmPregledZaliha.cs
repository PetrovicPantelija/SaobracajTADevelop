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
    public partial class frmPrikazSkladista : Form
    {
        public frmPrikazSkladista()
        {
            InitializeComponent();
        }

        private void txtLokacija_Leave(object sender, EventArgs e)
        {
            RefreshDataGrid1();
            
        }

        private void RefreshDataGrid1()
        {
           

            var select = " select  ZlLok,  ZlSifMP,  MaticniPodatki.MpStaraSif as Artikal, ZlDejanskaKol from ZalogaLokacija inner join MaticniPodatki on MaticniPodatki.MpSifra = ZaLogaLokacija.ZlSifMp";
            select = select + " where ZlSifSklad = " + cboSkladiste.SelectedValue + " and ZlLok like ( '" + txtLokacija.Text + "%' )" + " order by ZlLok  "; ;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Lokacija";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Artikal";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Kod";
            dataGridView1.Columns[2].Width = 130;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Količina";
            dataGridView1.Columns[3].Width = 50;

           

        }

        private void RefreshDataGrid2()
        {
            var select = " select  ZlLok,  ZlSifMP,  MaticniPodatki.MpStaraSif as Artikal, ZlDejanskaKol from ZalogaLokacija inner join MaticniPodatki on MaticniPodatki.MpSifra = ZaLogaLokacija.ZlSifMp";
            select = select + " where ZlSifSklad = " + cboSkladiste2.SelectedValue + " and ZlLok like ( '" + txtLokacija2.Text + "%' )" + " order by ZlLok  "; ;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView2.Columns[0].HeaderText = "Lokacija";
            dataGridView2.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Artikal";
            dataGridView2.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Kod";
            dataGridView2.Columns[2].Width = 130;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Količina";
            dataGridView2.Columns[3].Width = 50;



        }

        private void RefreshDataGrid3()
        {
            var select = " select  ZlLok,  ZlSifMP,  MaticniPodatki.MpStaraSif as Artikal, ZlDejanskaKol from ZalogaLokacija inner join MaticniPodatki on MaticniPodatki.MpSifra = ZaLogaLokacija.ZlSifMp";
            select = select + " where ZlSifSklad = " + cboSkladiste2.SelectedValue + " and ZlLok like ( '" + txtLokacija2.Text + "%' )" + " order by ZlLok  "; ;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView3.Columns[0].HeaderText = "Lokacija";
            dataGridView3.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Artikal";
            dataGridView3.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Kod";
            dataGridView3.Columns[2].Width = 130;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Količina";
            dataGridView3.Columns[3].Width = 50;

        }

        private void RefreshDataGrid4()
        {
            var select = " select  ZlLok,  ZlSifMP,  MaticniPodatki.MpStaraSif as Artikal, ZlDejanskaKol from ZalogaLokacija inner join MaticniPodatki on MaticniPodatki.MpSifra = ZaLogaLokacija.ZlSifMp";
            select = select + " where ZlSifSklad = " + cboSkladiste2.SelectedValue + " and ZlLok like ( '" + txtLokacija2.Text + "%' )" + " order by ZlLok  "; ;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView4.Columns[0].HeaderText = "Lokacija";
            dataGridView4.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView4.Columns[1].HeaderText = "Artikal";
            dataGridView4.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView4.Columns[2].HeaderText = "Kod";
            dataGridView4.Columns[2].Width = 130;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView4.Columns[3].HeaderText = "Količina";
            dataGridView4.Columns[3].Width = 50;

        }

        private void frmPrikazSkladista_Load(object sender, EventArgs e)
        {

            var select2 = " Select SkSifra, SkNaziv from Sklad order by SkSifra";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboSkladiste.DataSource = ds2.Tables[0];
            cboSkladiste.DisplayMember = "SkNaziv";
            cboSkladiste.ValueMember = "SkSifra";

            ///

            var select3 = " Select SkSifra, SkNaziv from Sklad order by SkSifra";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboSkladiste2.DataSource = ds3.Tables[0];
            cboSkladiste2.DisplayMember = "SkNaziv";
            cboSkladiste2.ValueMember = "SkSifra";

            ///
            ///

            var select4 = " Select SkSifra, SkNaziv from Sklad order by SkSifra";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4= new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection3);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboSkladiste3.DataSource = ds4.Tables[0];
            cboSkladiste3.DisplayMember = "SkNaziv";
            cboSkladiste3.ValueMember = "SkSifra";
            //
            var select5 = " Select SkSifra, SkNaziv from Sklad order by SkSifra";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection4);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboSkladiste4.DataSource = ds5.Tables[0];
            cboSkladiste4.DisplayMember = "SkNaziv";
            cboSkladiste4.ValueMember = "SkSifra";
        }

        private void txtLokacija2_Leave(object sender, EventArgs e)
        {
            RefreshDataGrid2();
        }

        private void txtLokacija3_Leave(object sender, EventArgs e)
        {
            RefreshDataGrid3();
        }

        private void txtLokacija4_Leave(object sender, EventArgs e)
        {
            RefreshDataGrid4();
        }
    
    }
}
