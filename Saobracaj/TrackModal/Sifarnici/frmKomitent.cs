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
    public partial class frmKomitent : Form
    {
        string KorisnikCene;
        bool status = false;
        int PomBrodar = 0;
         int PomPosiljalac = 0;
         int PomPrimalac = 0;
         int PomPlatilac = 0;
         int PomOrganizator = 0;
         int PomVlasnik = 0;
        int PomOperator = 0;
      
       
        public frmKomitent()
        {
            InitializeComponent();
        }
        public frmKomitent(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            status = true;
            txtAdresa.Text = "";
            txtemail.Text = "";
            txtKontaktOsoba.Text = "";
            //txtMaticniBroj.Text = "";
            txtNapomena.Text = "";
            txtNaziv.Text = "";
            txtPIB.Text = "";
            txtSifraERP.Text = "";
            txtTelefon.Text = "";
            txtTR.Text = "";
            chkBrodar.Checked = false;
            chkOperator.Checked = false;
            chkOrganizator.Checked = false;
            chkPlatilac.Checked = false;
            chkPosiljalac.Checked = false;
            chkPrimalac.Checked = false;
            chkVlasnik.Checked = false;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (chkBrodar.Checked)
            {
                PomBrodar = 1;
            }
            else
            {
                PomBrodar = 0;
            }
            if (chkPosiljalac.Checked)
            {
                PomPosiljalac = 1;
            }
            else
            {
                PomPosiljalac = 0;
            }
            if (chkPrimalac.Checked)
            {
                PomPrimalac = 1;
            }
            else
            {
                PomPrimalac = 0;
            }
            if (chkPlatilac.Checked)
            {
                PomPlatilac = 1;
            }
            else
            {
                PomPlatilac = 0;
            }
            if (chkOrganizator.Checked)
            {
                PomOrganizator = 1;
            }
            else
            {
                PomOrganizator = 0;
            }
            if (chkVlasnik.Checked)
            {
                PomVlasnik = 1;
            }
            else
            {
                PomVlasnik = 0;
            }
            if (chkOperator.Checked)
            {
                PomOperator = 1;
            }
            else
            {
                PomOperator = 0;
            }

            
      
            if (status == true)
            {
                InsertKomitent ins = new InsertKomitent();
                ins.InsKomitent(txtNaziv.Text, txtAdresa.Text, txtTelefon.Text, txtemail.Text, txtKontaktOsoba.Text, PomBrodar, PomPosiljalac, PomPrimalac, PomPlatilac, PomOrganizator, PomVlasnik, PomOperator, txtNapomena.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, txtPIB.Text, txtMaticniBroj.Text,txtSifraERP.Text, txtTR.Text);
                status = false;
            }
            else
            {
                //int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik
                InsertKomitent upd = new InsertKomitent();
                upd.UpdKomitent(Convert.ToInt32(txtSifra.Text), txtNaziv.Text, txtAdresa.Text, txtTelefon.Text, txtemail.Text, txtKontaktOsoba.Text, PomBrodar, PomPosiljalac, PomPrimalac, PomPlatilac, PomOrganizator, PomVlasnik, PomOperator, txtNapomena.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene,txtPIB.Text, txtMaticniBroj.Text, txtSifraERP.Text, txtTR.Text);
            }
            RefreshDataGrid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertKomitent upd = new InsertKomitent();
                upd.DeleteKomitent(Convert.ToInt32(txtSifra.Text));
                RefreshDataGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
        }

        private void RefreshDataGrid()
        {
            var select = "  SELECT [ID] ,[Naziv] ,[Adresa] ,[Telefon],[email] ,[KontaktOsoba], " +
              " CASE WHEN Brodar > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Brodar , " +
              " CASE WHEN Posiljalac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Posiljalac , " +
              " CASE WHEN Primalac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Primalac , " +
              " CASE WHEN Platilac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Platilac , " +
              " CASE WHEN Organizator > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Organizator , " +
              " CASE WHEN Vlasnik > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Vlasnik , " +
              " CASE WHEN Operator > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Operator , " +
              " [Napomena], Datum, Korisnik FROM [dbo].[Komitenti] order by ID asc";
           

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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Naziv";
            dataGridView1.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Adresa";
            dataGridView1.Columns[2].Width = 160;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[3].Width = 80;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "E-mail";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Kontakt osoba";
            dataGridView1.Columns[5].Width = 160;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Brodar";
            dataGridView1.Columns[6].Width = 40;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Špediter";
            dataGridView1.Columns[7].Width = 40;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Primalac";
            dataGridView1.Columns[8].Width = 40;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Platilac";
            dataGridView1.Columns[9].Width = 40;


            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Organizator";
            dataGridView1.Columns[10].Width = 40;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Vlasnik";
            dataGridView1.Columns[11].Width = 40;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Operator";
            dataGridView1.Columns[12].Width = 40;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Napomena";
            dataGridView1.Columns[13].Width = 180;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Datum";
            dataGridView1.Columns[14].Width = 80;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Korisnik";
            dataGridView1.Columns[15].Width = 80;

        }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID],[Naziv],[Adresa],[Telefon],[email],[KontaktOsoba] " +
          ",[Brodar] ,[Posiljalac],[Primalac],[Platilac] ,[Organizator] ,[Vlasnik] " +
          ",[Operator] ,[Napomena] ,[Datum] ,[Korisnik]  FROM [dbo].[Komitenti] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                txtNaziv.Text = dr["Naziv"].ToString();
                txtAdresa.Text = dr["Adresa"].ToString();
                txtTelefon.Text = dr["Telefon"].ToString();
                txtemail.Text = dr["email"].ToString();
                txtKontaktOsoba.Text = dr["KontaktOsoba"].ToString();
                txtNapomena.Text = dr["Napomena"].ToString();
                if (dr["Operator"].ToString() == "True")
                {
                    chkOperator.Checked = true;
                }
                else
                {
                    chkOperator.Checked = false;

                }
                if (dr["Vlasnik"].ToString() == "True")
                {
                    chkVlasnik.Checked = true;
                }
                else
                {
                    chkVlasnik.Checked = false;

                }
                if (dr["Organizator"].ToString() == "True")
                {
                    chkOrganizator.Checked = true;
                }
                else
                {
                    chkOrganizator.Checked = false;

                }

                if (dr["Platilac"].ToString() == "True")
                {
                    chkPlatilac.Checked = true;
                }
                else
                {
                    chkPlatilac.Checked = false;

                }
                if (dr["Primalac"].ToString() == "True")
                {
                    chkPrimalac.Checked = true;
                }
                else
                {
                    chkPrimalac.Checked = false;

                }
                if (dr["Posiljalac"].ToString() == "True")
                {
                    chkPosiljalac.Checked = true;
                }
                else
                {
                    chkPosiljalac.Checked = false;

                }
                if (dr["Brodar"].ToString() == "True")
                {
                    chkBrodar.Checked = true;
                }
                else
                {
                    chkBrodar.Checked = false;
                   
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
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void tsUgovor_Click(object sender, EventArgs e)
        {
            frmKomitentUgovori komug = new frmKomitentUgovori();
            komug.Show();
        }

        private void frmKomitent_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
            if (KorisnikCene != "Kecman" && KorisnikCene != "M.Jelisavčić" && KorisnikCene != "Dušan Bašanović")
            {
                tsNew.Enabled = false;
                tsSave.Enabled = false;
                tsDelete.Enabled = false;
            }
        }

        private void tsPrvi_Click(object sender, EventArgs e)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Min([ID]) as ID from Komitenti", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }
            VratiPodatke(txtSifra.Text);
            con.Close();

        }

        private void tsPoslednja_Click(object sender, EventArgs e)
        {


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Komitenti", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }
            VratiPodatke(txtSifra.Text);
            con.Close();



        }

        private void tsNazad_Click(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);
            int prvi = 0;
            con.Open();

            SqlCommand cmd = new SqlCommand("select top 1 ID as ID from Komitenti where ID <" + Convert.ToInt32(txtSifra.Text) + " Order by ID desc", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                prvi = Convert.ToInt32(dr["ID"].ToString());
                txtSifra.Text = prvi.ToString();
            }

            con.Close();
            if ((Convert.ToInt32(txtSifra.Text) - 1) > prvi)
                VratiPodatke((Convert.ToInt32(txtSifra.Text) - 1).ToString());
            else
                VratiPodatke((Convert.ToInt32(prvi)).ToString());
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Komitenti", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void tsNapred_Click(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);
            int zadnji = 0;
            con.Open();

            SqlCommand cmd = new SqlCommand("select top 1 ID as ID from Komitenti where ID >" + Convert.ToInt32(txtSifra.Text) + " Order by ID", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                zadnji = Convert.ToInt32(dr["ID"].ToString());
                txtSifra.Text = zadnji.ToString();
            }

            con.Close();

            if ((Convert.ToInt32(txtSifra.Text) + 1) == zadnji)
                VratiPodatke((Convert.ToInt32(zadnji).ToString()));
            else
                VratiPodatke((Convert.ToInt32(txtSifra.Text) + 1).ToString());

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
