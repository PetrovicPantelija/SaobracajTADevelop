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



namespace Testiranje.Sifarnici
{
    public partial class frmZaposleni : Form
    {
        string KorisnikCene;
        public frmZaposleni()
        {
            InitializeComponent();
        }
        bool status = false;
        public frmZaposleni(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
            txtemail.Text = "";
            txtIme.Text = "";
            txtNapomena.Text  = "";
            txtPrezime.Text = "";
            txtRadnoMesto.Text = "";
            txtSifraERP.Text = "";
            txtTelefon.Text = "";
            
        }

        private void RefreshDataGrid()
        {
            var select = " SELECT [ID] ,[Prezime],[Ime] ,[email],[Telefon]      ,[Napomena] ,[TipRadnika] ,[Datum] ,[Korisnik]       ,[SkolskaSprema]       ,[OrganizacionaJedinica]      ,[SifraERP]  FROM [dbo].[Zaposleni] Order by ID";
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
            dataGridView1.Columns[1].HeaderText = "Prezime";
            dataGridView1.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Ime";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "E mail";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Telefon";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Napomena";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Tip Radnika";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Datum";
            dataGridView1.Columns[7].Width = 100;
            
            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Korisnik";
            dataGridView1.Columns[8].Width = 100;

             DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Školska sprema";
            dataGridView1.Columns[9].Width = 100;

             DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Org jedinica";
            dataGridView1.Columns[10].Width = 100;

              DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Sifra ERP";
            dataGridView1.Columns[11].Width = 100;

///,[SkolskaSprema]       ,[OrganizacionaJedinica]      ,[SifraERP]
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertZaposleni ins = new InsertZaposleni();
                ins.InsZaposleni(txtPrezime.Text, txtIme.Text, txtemail.Text, txtTelefon.Text, txtNapomena.Text, txtRadnoMesto.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToInt32(cboSkolskaSprema.SelectedValue), Convert.ToInt32(cboOrganizacionaJedinica.SelectedValue), txtSifraERP.Text);
                status = false;
            }
            else
            {
                //int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik
                InsertZaposleni upd = new InsertZaposleni();
                upd.UpdZaposleni(Convert.ToInt32(txtSifra.Text), txtPrezime.Text, txtIme.Text, txtemail.Text, txtTelefon.Text, txtNapomena.Text, txtRadnoMesto.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToInt32(cboSkolskaSprema.SelectedValue), Convert.ToInt32(cboOrganizacionaJedinica.SelectedValue), txtSifraERP.Text);
            }
            RefreshDataGrid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertZaposleni upd = new InsertZaposleni();
                upd.DeleteZaposleni(Convert.ToInt32(txtSifra.Text));
                RefreshDataGrid();
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

            SqlCommand cmd = new SqlCommand("SELECT [ID],[Prezime],[Ime] ,[email],[Telefon],[Napomena],[TipRadnika],[Datum],[Korisnik], SkolskaSprema, OrganizacionaJedinica, SifraERP  FROM [dbo].[Zaposleni] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                // Convert.ToInt32(cboTipCenovnika.SelectedValue), Convert.ToInt32(cboKomitent.SelectedValue), Convert.ToDouble(txtCena.Text), Convert.ToInt32(cboVrstaManipulacije.SelectedValue), Convert.ToDateTime(DateTime.Now), KorisnikCene
                cboOrganizacionaJedinica.SelectedValue = Convert.ToInt32(dr["OrganizacionaJedinica"].ToString());
                string ss = dr["SkolskaSprema"].ToString();
                if (ss ==  "")
                    cboSkolskaSprema.SelectedValue = 0;
                else
                cboSkolskaSprema.SelectedValue = Convert.ToInt32(dr["SkolskaSprema"].ToString());
               // cboTipRadnika.SelectedValue = Convert.ToInt32(dr["TipRadnika"].ToString());
                txtPrezime.Text =dr["Prezime"].ToString().ToString();
                txtIme.Text = dr["Ime"].ToString().ToString();
                txtemail.Text = dr["email"].ToString().ToString();
                txtTelefon.Text = dr["Telefon"].ToString().ToString();
                txtNapomena.Text = dr["Napomena"].ToString().ToString();
                txtSifraERP.Text = dr["SifraERP"].ToString().ToString();
                txtRadnoMesto.Text = dr["TipRadnika"].ToString().ToString();
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

        private void tsPrvi_Click(object sender, EventArgs e)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Min([ID]) as ID from Zaposleni", con);
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

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Zaposleni", con);
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

            SqlCommand cmd = new SqlCommand("select top 1 ID as ID from Zaposleni where ID <" + Convert.ToInt32(txtSifra.Text) + " Order by ID desc", con);
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

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Zaposleni", con);
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

            SqlCommand cmd = new SqlCommand("select top 1 ID as ID from Zaposleni where ID >" + Convert.ToInt32(txtSifra.Text) + " Order by ID", con);
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

        private void frmZaposleni_Load(object sender, EventArgs e)
        {
           
            var select = " Select Distinct ID, Naziv  From SkolskaSprema";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboSkolskaSprema.DataSource = ds.Tables[0];
            cboSkolskaSprema.DisplayMember = "Naziv";
            cboSkolskaSprema.ValueMember = "ID";

            var select2 = " Select Distinct ID, Naziv  From OrganizacioneJedinice";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboOrganizacionaJedinica.DataSource = ds2.Tables[0];
            cboOrganizacionaJedinica.DisplayMember = "Naziv";
            cboOrganizacionaJedinica.ValueMember = "ID";

            RefreshDataGrid();
            if (KorisnikCene != "Kecman" && KorisnikCene != "M.Jelisavčić" && KorisnikCene != "Dušan Bašanović")
            {
                tsNew.Enabled = false;
                tsSave.Enabled = false;
                tsDelete.Enabled = false;
            }
        }
   
    }
}

