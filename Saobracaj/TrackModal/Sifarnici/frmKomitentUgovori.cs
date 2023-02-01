
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
    public partial class frmKomitentUgovori : Form
    {
        string KorisnikCene;
        bool status = false;
        public frmKomitentUgovori()
        {
            InitializeComponent();
        }
     
         public frmKomitentUgovori(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

         private void tsNew_Click(object sender, EventArgs e)
         {
             status = true;
         }

         private void RefreshDataGrid()
         {
             var select = " SELECT [ID],[Oznaka],[Komitenti],[DatumVezivanja],[Cenovnik]  FROM [dbo].[KomitentiUgovori]";
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

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
             dataGridView1.Columns[0].HeaderText = "ID";
             dataGridView1.Columns[0].Width = 50;

             DataGridViewColumn column2 = dataGridView1.Columns[1];
             dataGridView1.Columns[1].HeaderText = "Oznaka";
             dataGridView1.Columns[1].Width = 150;

             DataGridViewColumn column3 = dataGridView1.Columns[2];
             dataGridView1.Columns[2].HeaderText = "Komitent";
             dataGridView1.Columns[2].Width = 300;

             DataGridViewColumn column4 = dataGridView1.Columns[3];
             dataGridView1.Columns[3].HeaderText = "DatumVezivanja";
             dataGridView1.Columns[3].Width = 100;

             DataGridViewColumn column5 = dataGridView1.Columns[4];
             dataGridView1.Columns[4].HeaderText = "Cenovnik";
             dataGridView1.Columns[4].Width = 100;

          
         }

         private void tsSave_Click(object sender, EventArgs e)
         {
             if (status == true)
             {
                 InsertKomitentUgovori ins = new InsertKomitentUgovori();
                 ins.InsKomitentUgovori(txtOznaka.Text, Convert.ToInt32(cboKomitent.SelectedValue), Convert.ToDateTime(dtpDatumVezivanja.Value),  Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToInt32(cboCenovnik.SelectedValue));
                 status = false;
             }
             else
             {
                 //int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik
                 InsertKomitentUgovori upd = new InsertKomitentUgovori();
                 upd.UpdKomitentUgovori(Convert.ToInt32(txtSifra.Text), txtOznaka.Text, Convert.ToInt32(cboKomitent.SelectedValue), Convert.ToDateTime(dtpDatumVezivanja.Value), Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToInt32(cboCenovnik.SelectedValue));
             }
             RefreshDataGrid();
         }

         private void tsDelete_Click(object sender, EventArgs e)
         {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertKomitentUgovori upd = new InsertKomitentUgovori();
                upd.DeleteKomitentUgovori(Convert.ToInt32(txtSifra.Text));
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
         }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID],[Oznaka],[Komitenti],[DatumVezivanja],[Cenovnik]  FROM [dbo].[KomitentiUgovori] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cboKomitent.SelectedValue = Convert.ToInt32(dr["Komitent"].ToString());
                cboCenovnik.SelectedValue = Convert.ToInt32(dr["Cenovnik"].ToString());
                dtpDatumVezivanja.Value = Convert.ToDateTime(dr["DatumVezivanja"].ToString());
                txtOznaka.Text = Convert.ToDecimal(dr["Oznaka"].ToString()).ToString();
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
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        VratiPodatke(txtSifra.Text);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

         private void txtSifra_TextChanged(object sender, EventArgs e)
         {

         }

        private void frmKomitentUgovori_Load(object sender, EventArgs e)
        {
            if (KorisnikCene != "Kecman" && KorisnikCene != "U.Kecman")
            {
                tsNew.Enabled = false;
                tsSave.Enabled = false;
                tsDelete.Enabled = false;
            }
        }
    }
    }


