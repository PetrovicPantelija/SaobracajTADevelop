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

namespace Saobracaj.Dokumenta
{
    public partial class frmAutomobiliRegistracija : Form
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        bool status = false;
        string pomAuto = "";

        public frmAutomobiliRegistracija()
        {
            InitializeComponent();
        }
        public frmAutomobiliRegistracija(string Automobil)
        {
            InitializeComponent();
            pomAuto = Automobil;
        }
        private void frmAutomobiliRegistracija_Load(object sender, EventArgs e)
        {
            FillCombo();
            dt_Datum.Value = DateTime.Now;
            txt_AutomobilID.Text = pomAuto;
            RefreshDG();
        }
        private void FillCombo()
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter();
            var query = "Select PaSifra,PaNaziv From Partnerji";
            da = new SqlDataAdapter(query, conn);
            var ds = new DataSet();
            da.Fill(ds);
            combo_Partner.DataSource = ds.Tables[0];
            combo_Partner.DisplayMember = "PaNaziv";
            combo_Partner.ValueMember = "PaSifra";

            var query1= "Select DeSifra, Rtrim(DeIme) + ' ' + Rtrim(DePriimek) as Zaposleni From Delavci Order By DeIme";
            da = new SqlDataAdapter(query1, conn);
            var ds1 = new DataSet();
            da.Fill(ds1);
            combo_Zaposleni.DataSource = ds1.Tables[0];
            combo_Zaposleni.DisplayMember = "Zaposleni";
            combo_Zaposleni.ValueMember = "DeSifra";
        }
        private void RefreshDG()
        {
                    var query = "Select [ID],[IDAutomobila],[DatumRegistracije],[Zaposleni],[Partner],[Napomena] FROM[AutomobiliRegistracija] Where [IDAutomobila]=" + Convert.ToInt32(txt_AutomobilID.Text);
                    SqlConnection conn = new SqlConnection(connect);
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
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

            dataGridView1.Columns[0].Width = 50;
                    dataGridView1.Columns[1].Width = 100;
                    dataGridView1.Columns[2].Width = 150;
                    dataGridView1.Columns[3].Width = 75;
                    dataGridView1.Columns[4].Width = 75;
                    dataGridView1.Columns[5].Width = 150;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
               foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txt_Sifra.Text = row.Cells[0].Value.ToString();
                        txt_AutomobilID.Text = row.Cells[1].Value.ToString();
                        combo_Zaposleni.SelectedValue = Convert.ToInt32(row.Cells[3].Value.ToString());
                        combo_Partner.SelectedValue = Convert.ToInt32(row.Cells[4].Value.ToString());
                        txt_Napomena.Text = row.Cells[5].Value.ToString();

                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }
        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertAutomobiliRegistracija reg = new InsertAutomobiliRegistracija();
            if (status == true)
            {
                reg.InsertRegistracija(Convert.ToInt32(txt_AutomobilID.Text), Convert.ToDateTime(dt_Datum.Value), Convert.ToInt32(combo_Zaposleni.SelectedValue),
                    Convert.ToInt32(combo_Partner.SelectedValue), txt_Napomena.Text);
                RefreshDG();
                status = false;
            }
            else
            {
                reg.UpdateRegistracija(Convert.ToInt32(txt_Sifra.Text), Convert.ToInt32(txt_AutomobilID.Text), Convert.ToDateTime(dt_Datum.Value), Convert.ToInt32(combo_Zaposleni.SelectedValue),
                    Convert.ToInt32(combo_Partner.SelectedValue), txt_Napomena.Text);
                RefreshDG();
            }
        }

     
        private void tsNew_Click(object sender, EventArgs e)
        {
            txt_Sifra.Text = "";
            txt_Sifra.Enabled = false;
            status = true;
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertAutomobiliRegistracija reg = new InsertAutomobiliRegistracija();
            reg.DeleteRegistracija(Convert.ToInt32(txt_Sifra.Text));
            status = false;
            RefreshDG();

        }
    }
}
