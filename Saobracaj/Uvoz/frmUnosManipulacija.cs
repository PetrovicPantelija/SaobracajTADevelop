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
using Microsoft.Office.Interop.Excel;

namespace Saobracaj.Uvoz
{
    public partial class frmUnosManipulacija : Form
    {
        public string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        public frmUnosManipulacija()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void FillDG6()
        {

            var select = "select Cene.ID, VrstaManipulacije.Naziv, Cene.Cena, VrstaManipulacije.ID from Cene " +
            " inner join VrstaManipulacije on VrstaManipulacije.ID = Cene.VrstaManipulacije " +
            " where TipCenovnika = 1 order by VrstaManipulacije.Naziv ";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView6.ReadOnly = true;
            dataGridView6.DataSource = ds.Tables[0];


            dataGridView6.BorderStyle = BorderStyle.None;
            dataGridView6.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView6.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView6.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView6.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView6.BackgroundColor = Color.White;

            dataGridView6.EnableHeadersVisualStyles = false;
            dataGridView6.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView6.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView6.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView6.Columns[0];
            dataGridView6.Columns[0].HeaderText = "ID";
            dataGridView6.Columns[0].Width = 20;

            DataGridViewColumn column2 = dataGridView6.Columns[1];
            dataGridView6.Columns[1].HeaderText = "Man";
            dataGridView6.Columns[1].Width = 120;

            DataGridViewColumn column3 = dataGridView6.Columns[2];
            dataGridView6.Columns[2].HeaderText = "Cena";
            dataGridView6.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView6.Columns[3];
            dataGridView6.Columns[3].HeaderText = "IDVM";
            dataGridView6.Columns[3].Width = 50;
            dataGridView6.Columns[3].Visible = false;
        }
        private void FillDG7()
        {

            var select = "select Cene.ID, VrstaManipulacije.Naziv, Cene.Cena, VrstaManipulacije.ID, 1 as Kolicina from Cene " +
            " inner join VrstaManipulacije on VrstaManipulacije.ID = Cene.VrstaManipulacije " +
            " where TipCenovnika <> 1 and Cene.PostupakSaRobom = "  + " and Cene.Uvoznik = " + Convert.ToInt32(cboNalogodavac1.SelectedValue) + "  order by VrstaManipulacije.Naziv ";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView6.ReadOnly = true;
            dataGridView6.DataSource = ds.Tables[0];


            dataGridView6.BorderStyle = BorderStyle.None;
            dataGridView6.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView6.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView6.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView6.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView6.BackgroundColor = Color.White;

            dataGridView6.EnableHeadersVisualStyles = false;
            dataGridView6.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView6.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView6.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView6.Columns[0];
            dataGridView6.Columns[0].HeaderText = "ID";
            dataGridView6.Columns[0].Width = 20;

            DataGridViewColumn column2 = dataGridView6.Columns[1];
            dataGridView6.Columns[1].HeaderText = "Man";
            dataGridView6.Columns[1].Width = 120;

            DataGridViewColumn column3 = dataGridView6.Columns[2];
            dataGridView6.Columns[2].HeaderText = "Cena";
            dataGridView6.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView6.Columns[3];
            dataGridView6.Columns[3].HeaderText = "IDVM";
            dataGridView6.Columns[3].Width = 50;
            dataGridView6.Columns[3].Visible = false;
        }


        private void button13_Click(object sender, EventArgs e)
        {
            FillDG7();
        }

        private void UbaciStavkuUsluge(int ID, int Manipulacija, double Cena, double Kolicina)
        {
            InsertUvozKonacna uvK = new InsertUvozKonacna();
            uvK.InsUbaciUsluguKonacna(Convert.ToInt32(txtID.Text), Manipulacija, Cena, Kolicina);
            FillDG8();
        }

        private void FillDG8()
        {
            var select = "select  UvozKonacnaVrstaManipulacije.ID, VrstaManipulacije.Naziv, UvozKonacnaVrstaManipulacije.Cena, VrstaManipulacije.ID from UvozKonacnaVrstaManipulacije " +
            " inner join VrstaManipulacije on VrstaManipulacije.ID = UvozKonacnaVrstaManipulacije.IDVrstaManipulacije " +
                " where UvozKonacnaVrstaManipulacije.IDNadredjena = " + Convert.ToInt32(txtID.Text);
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView7.ReadOnly = true;
            dataGridView7.DataSource = ds.Tables[0];


            dataGridView7.BorderStyle = BorderStyle.None;
            dataGridView7.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView7.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView7.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView7.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView7.BackgroundColor = Color.White;

            dataGridView7.EnableHeadersVisualStyles = false;
            dataGridView7.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView7.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView7.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView7.Columns[0];
            dataGridView7.Columns[0].HeaderText = "ID";
            dataGridView7.Columns[0].Width = 20;

            DataGridViewColumn column2 = dataGridView7.Columns[1];
            dataGridView7.Columns[1].HeaderText = "Man";
            dataGridView7.Columns[1].Width = 120;

            DataGridViewColumn column3 = dataGridView7.Columns[2];
            dataGridView7.Columns[2].HeaderText = "Cena";
            dataGridView7.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView7.Columns[3];
            dataGridView7.Columns[3].HeaderText = "IDVM";
            dataGridView7.Columns[3].Width = 50;
            dataGridView7.Columns[3].Visible = false;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int pomID = 0;
            int pomManupulacija = 0;
            double pomCena = 0;
            double pomkolicina = 1;
            try
            {
                foreach (DataGridViewRow row in dataGridView6.Rows)
                {
                    if (row.Selected)
                    {
                        pomID = Convert.ToInt32(row.Cells[0].Value.ToString());
                        pomManupulacija = Convert.ToInt32(row.Cells[3].Value.ToString());
                        pomCena = Convert.ToDouble(row.Cells[2].Value.ToString());
                        pomkolicina= Convert.ToDouble(row.Cells[4].Value.ToString());
                        UbaciStavkuUsluge(pomID, pomManupulacija, pomCena, pomkolicina);
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void frmUnosManipulacija_Load(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void FillCombo()
        {
            SqlConnection conn = new SqlConnection(connection);
            
            var partner8 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD8 = new SqlDataAdapter(partner8, conn);
            var partDS8 = new DataSet();
            partAD8.Fill(partDS8);
            cboNalogodavac1.DataSource = partDS8.Tables[0];
            cboNalogodavac1.DisplayMember = "PaNaziv";
            cboNalogodavac1.ValueMember = "PaSifra";

            var partner9 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD9 = new SqlDataAdapter(partner9, conn);
            var partDS9 = new DataSet();
            partAD9.Fill(partDS9);
            cboNalogodavac2.DataSource = partDS9.Tables[0];
            cboNalogodavac2.DisplayMember = "PaNaziv";
            cboNalogodavac2.ValueMember = "PaSifra";

            var partner10 = "Select PaSifra,PaNaziv From Partnerji order by PaSifra";
            var partAD10 = new SqlDataAdapter(partner10, conn);
            var partDS10 = new DataSet();
            partAD9.Fill(partDS10);
            cboNalogodavac3.DataSource = partDS10.Tables[0];
            cboNalogodavac3.DisplayMember = "PaNaziv";
            cboNalogodavac3.ValueMember = "PaSifra";
        }
    }
}
