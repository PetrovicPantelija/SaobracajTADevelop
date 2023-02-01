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
    public partial class frmAutomobiliServis : Form
    {
        bool status = false;
        String pomAuto = "";
        public frmAutomobiliServis()
        {
            InitializeComponent();
        }

        public frmAutomobiliServis(string Automobil)
        {
            InitializeComponent();
            pomAuto = Automobil;
        }

        private void frmAutomobiliServis_Load(object sender, EventArgs e)
        {

            var select3 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Posiljalac = 1 order by PaNaziv";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboPartneri.DataSource = ds3.Tables[0];
            cboPartneri.DisplayMember = "Partner";
            cboPartneri.ValueMember = "PaSifra";


            var select4 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboZaposleni.DataSource = ds4.Tables[0];
            cboZaposleni.DisplayMember = "Opis";
            cboZaposleni.ValueMember = "ID";

            txtAutomobilID.Text = pomAuto;
            RefreshDataGrid4();

        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int VS = 0;
            if (chkVelikiServis.Checked == true)
                VS = 1;
            if (status == true)
            {
                InsertAutomobili ins = new InsertAutomobili();
                ins.InsAutomobiliServis(Convert.ToInt32(txtAutomobilID.Text), Convert.ToDateTime(dtpDatumServisa.Value), VS, txtKM.Text, Convert.ToInt32(cboZaposleni.SelectedValue), Convert.ToInt32(cboPartneri.SelectedValue), txtNapomena.Text);
                RefreshDataGrid4();
                status = false;
            }
            else
            {
                InsertAutomobili upd = new InsertAutomobili();
                upd.UpdAutomobiliServis(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtAutomobilID.Text), Convert.ToDateTime(dtpDatumServisa.Value), VS, txtKM.Text, Convert.ToInt32(cboZaposleni.SelectedValue), Convert.ToInt32(cboPartneri.SelectedValue), txtNapomena.Text); ;
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid4();
            }
        }

        private void RefreshDataGrid4()
        {
            var select = " SELECT [ID] ,[IDAutomobila] ,[DatumServisa] ,[VelikiServis] " +
      " ,[KM] ,[Zaposleni],[Partner] ,[Napomena] " +
 "  FROM [TESTIRANJE].[dbo].[AutomobiliServis] where[IDAutomobila] = " + Convert.ToInt32(txtAutomobilID.Text);


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];

            dataGridView4.BorderStyle = BorderStyle.None;
            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView4.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView4.BackgroundColor = Color.White;

            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewColumn column = dataGridView4.Columns[0];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView4.Columns[1];
            dataGridView4.Columns[1].HeaderText = "Automobil ID";
            dataGridView4.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView4.Columns[2];
            dataGridView4.Columns[2].HeaderText = "Datum servisa";
            dataGridView4.Columns[2].Width = 70;

            DataGridViewColumn column4 = dataGridView4.Columns[3];
            dataGridView4.Columns[3].HeaderText = "VS";
            dataGridView4.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView4.Columns[4];
            dataGridView4.Columns[4].HeaderText = "KM";
            dataGridView4.Columns[4].Width = 70;


            DataGridViewColumn column6 = dataGridView4.Columns[5];
            dataGridView4.Columns[5].HeaderText = "ZapID";
            dataGridView4.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView4.Columns[6];
            dataGridView4.Columns[6].HeaderText = "PartID";
            dataGridView4.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView4.Columns[7];
            dataGridView4.Columns[7].HeaderText = "Napomena";
            dataGridView4.Columns[7].Width = 150;

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
       

            status = true;
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                       txtAutomobilID.Text = row.Cells[1].Value.ToString();
                        dtpDatumServisa.Value = Convert.ToDateTime(row.Cells[2].Value.ToString());
                        if (row.Cells[3].Value.ToString() == "1")
                        {
                            chkVelikiServis.Checked = true;
                        
                        }
                        else
                        {
                            chkVelikiServis.Checked = false;
                        }
                        txtKM.Text = row.Cells[4].Value.ToString();
                        cboZaposleni.SelectedValue = Convert.ToInt32(row.Cells[5].Value.ToString());
                        cboPartneri.SelectedValue = Convert.ToInt32(row.Cells[6].Value.ToString());
                        txtNapomena.Text = row.Cells[7].Value.ToString();
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }
    }
}
