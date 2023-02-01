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
using System.Net;
using System.Net.Mail;

using Microsoft.Reporting.WinForms;

namespace Saobracaj.Dokumenta
{
    public partial class frmPrijemnica : Form
    {
        public frmPrijemnica()
        {
            InitializeComponent();
        }

        private void frmPrijemnica_Load(object sender, EventArgs e)
        {
            var select2 = " select NprStPre from NPre where NPrStatus = 'OD' order by NPrStPre";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
        
            cboPrijemnica.DataSource = ds2.Tables[0];
            cboPrijemnica.DisplayMember = "NprStPre";
            cboPrijemnica.ValueMember = "NprStPre";
        
        }

        private void cboPrijemnica_Leave(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void RefreshDataGrid1()
            {
           
            var select = " select NPrePPreZap as ID, NPrPSifra as Sifra, MaticniPodatki.MpStaraSif ,NPrPEM as JM, NPrPKolPre as KOL, kolicina2, NPrPSifSkl as Skladiste, " +
                " NPrPLokac as Lokacija from NPreP inner join MAticniPodatki on MaticniPodatki.MpSifra = nprep.nPrPSifra " +
                " where NPrPStPre = " + Convert.ToInt32(cboPrijemnica.SelectedValue);
           

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
            dataGridView1.Columns[0].HeaderText = "Sifra";
            dataGridView1.Columns[0].Width = 30;
                
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Sifra";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Kod";
            dataGridView1.Columns[2].Width = 130;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "JM";
            dataGridView1.Columns[3].Width = 30;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Kol";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Kol uneta";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Sklad";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Lokac";
            dataGridView1.Columns[7].Width = 100;

        }

        private void btnPrihvatiIzmene_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    InsertPrijemnica ins = new InsertPrijemnica();
                    ins.UpdatePrijemnicaKOlicina(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToDouble(row.Cells[5].Value.ToString()));
                
                }
            }
        }
        }
    }

