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

namespace Testiranje.Sifarnici
{
    public partial class frmPravoPristupaFormi : Form
    {
        string KorisnikCene;
       // bool status = true;
        public frmPravoPristupaFormi()
        {
            InitializeComponent();
        }

        public frmPravoPristupaFormi(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
           // txtSifra.Text = Sifra.ToString();
        }

        private void frmPravoPristupaFormi_Load(object sender, EventArgs e)
        {
            var select = " Select Distinct Korisnik  From Korisnici";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboKorisnik.DataSource = ds.Tables[0];
            cboKorisnik.DisplayMember = "Korisnik";
            cboKorisnik.ValueMember = "Korisnik";

        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                InsertPravoPristupaFormi ins = new InsertPravoPristupaFormi();
               
                if (row.Selected == true)
                    ins.InsPravoPristupaFormi(row.Cells[1].Value.ToString(), Convert.ToDateTime(DateTime.Now), KorisnikCene, cboKorisnik.SelectedValue.ToString(), Convert.ToInt32(row.Cells[3].Value.ToString()));
                // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
            }
           // RefreshDataGridPoAktivnostima();
            RefreshDataGridNema();
            RefreshDataGridIma();
           
        }

        private void tsSave_Click(object sender, EventArgs e)
        {

        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {

            RefreshDataGridNema();
            RefreshDataGridIma();
        }
        private void RefreshDataGridNema()
        {
            //  "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
            var select = " SELECT PravoPristupaFormi.[ID], Forma.Naziv, forma.Modul, Forma.ID as ID " +
          " FROM [dbo].[PravoPristupaFormi] " +
       " right join Forma on PravoPristupaFormi.IdForme = Forma.ID " +
       " where  Forma.Id not in (select PravoPristupaFormi.IdForme from PravoPristupaFormi where PravoPristupaFormi.KorisnikKojiImaPravo = '" + cboKorisnik.SelectedValue + "')";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = false;
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

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Pravo pristupa formi";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Forma";
            dataGridView1.Columns[1].Width = 200;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Modul";
            dataGridView1.Columns[2].Width = 100;

        }

        private void RefreshDataGridIma()
        {
            //  "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
            var select = " SELECT PravoPristupaFormi.[ID], Forma.Naziv, forma.Modul , " +
                 "   CASE WHEN PravoPristupaFormi.pInsert > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Ubaci,  " +
                  "   CASE WHEN PravoPristupaFormi.pUpdate > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Promeni,  " +
                  "   CASE WHEN PravoPristupaFormi.pDelete > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Izbrisi  " +
         "  FROM [dbo].[PravoPristupaFormi]" +
         " right join Forma on PravoPristupaFormi.IdForme = Forma.ID  where  PravoPristupaFormi.[ID] is not null and KorisnikKojiImaPravo = '" + cboKorisnik.SelectedValue + "'";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = false;
            dataGridView2.DataSource = ds.Tables[0];

            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "Pravo pristupa formi";
            dataGridView2.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Forma";
            dataGridView2.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Modul";
            dataGridView2.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Insert";
            dataGridView2.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Update";
            dataGridView2.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Delete";
            dataGridView2.Columns[5].Width = 50;

        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    int pInsert = 0;
                    int pUpdate = 0;
                    int pDelete = 0;
                    if (row.Cells[3].Value.ToString() == "True")
                        pInsert = 1;
                    if (row.Cells[4].Value.ToString() == "True")
                        pUpdate = 1;
                    if (row.Cells[5].Value.ToString() == "True")
                        pDelete = 1;
                    InsertPravoPristupaFormi insTer = new InsertPravoPristupaFormi();
                    insTer.UpdPravoPristupaFormi(Convert.ToInt32(row.Cells[0].Value.ToString()), pInsert, pUpdate,pDelete);
                }
                RefreshDataGridIma();
                RefreshDataGridNema();
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void btnIzbrisi_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    InsertPravoPristupaFormi ins = new InsertPravoPristupaFormi();

                    if (row.Selected == true)
                        ins.DeletePravoPristupaFormi(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
                }
                // RefreshDataGridPoAktivnostima();
                RefreshDataGridNema();
                RefreshDataGridIma();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }
    }
}
