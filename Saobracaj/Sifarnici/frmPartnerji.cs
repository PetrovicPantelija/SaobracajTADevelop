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

namespace Saobracaj.Sifarnici
{
    public partial class frmPartnerji : Form
    {
        public static string code = "frmPartnerji";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        int PomBrodar = 0;
        int PomPosiljalac = 0;
        int PomPrimalac = 0;
        int PomPlatilac = 0;
        int PomOrganizator = 0;
        int PomVlasnik = 0;
        int PomSpediter = 0;


        bool status = false;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        public frmPartnerji()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public string IdGrupe()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            //Sifarnici.frmLogovanje frm = new Sifarnici.frmLogovanje();         
            string query = "Select IdGrupe from KorisnikGrupa Where Korisnik = " + "'" + Kor.TrimEnd() + "'";
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;

            while (dr.Read())
            {
                if (count == 0)
                {
                    niz = dr["IdGrupe"].ToString();
                    count++;
                }
                else
                {
                    niz = niz + "," + dr["IdGrupe"].ToString();
                    count++;
                }

            }
            conn.Close();
            return niz;
        }
        private int IdForme()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            string query = "Select IdForme from Forme where Rtrim(Code)=" + "'" + code + "'";
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idForme = Convert.ToInt32(dr["IdForme"].ToString());
            }
            conn.Close();
            return idForme;
        }

        private void PravoPristupa()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            string query = "Select * From GrupeForme Where IdGrupe in (" + niz + ") and IdForme=" + idForme;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == false)
            {
                MessageBox.Show("Nemate prava za pristup ovoj formi", code);
                Pravo = false;
            }
            else
            {
                Pravo = true;
                while (reader.Read())
                {
                    insert = Convert.ToBoolean(reader["Upis"]);
                    if (insert == false)
                    {
                        //tsNew.Enabled = false;
                    }
                    update = Convert.ToBoolean(reader["Izmena"]);
                    if (update == false)
                    {
                        tsSave.Enabled = false;
                    }
                    delete = Convert.ToBoolean(reader["Brisanje"]);
                    if (delete == false)
                    {
                        tsDelete.Enabled = false;
                    }
                }
            }

            conn.Close();
        }
        private void frmPartnerji_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();

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
                        txtNaziv.Text = row.Cells[1].Value.ToString();
                        txtUlica.Text = row.Cells[2].Value.ToString();
                        txtMesto.Text = row.Cells[3].Value.ToString();
                        txtOblast.Text = row.Cells[4].Value.ToString();
                        txtPosta.Text = row.Cells[5].Value.ToString();
                        txtDrzava.Text = row.Cells[6].Value.ToString();
                        txtTelefon.Text = row.Cells[7].Value.ToString();
                        txtTR.Text = row.Cells[8].Value.ToString();
                        txtNapomena.Text = row.Cells[9].Value.ToString();
                        txtMaticniBroj.Text = row.Cells[10].Value.ToString();
                        txtEmail.Text = row.Cells[11].Value.ToString();
                        txtPIB.Text = row.Cells[12].Value.ToString();
                        txtUIC.Text = row.Cells[13].Value.ToString();
                        chkPrevoznik.Checked = Convert.ToBoolean(row.Cells[14].Value.ToString());
                        chkPosiljalac.Checked = Convert.ToBoolean(row.Cells[15].Value.ToString());
                        chkPrimalac.Checked = Convert.ToBoolean(row.Cells[16].Value.ToString());
                        if (row.Cells[17].Value.ToString() == "1")
                        { chkBrodar.Checked = true; }
                        else
                        {
                            chkBrodar.Checked = false;
                        }


                        if (row.Cells[18].Value.ToString() == "1")
                        { chkVlasnik.Checked = true; }
                        else
                        {
                            chkVlasnik.Checked = false;
                        }

                        if (row.Cells[19].Value.ToString() == "1")
                        { chkSpediter.Checked = true; }
                        else
                        {
                            chkSpediter.Checked = false;
                        }

                        if (row.Cells[20].Value.ToString() == "1")
                        { chkPlatilac.Checked = true; }
                        else
                        {
                            chkPlatilac.Checked = false;
                        }

                        if (row.Cells[21].Value.ToString() == "1")
                        { chkOrganizator.Checked = true; }
                        else
                        {
                            chkOrganizator.Checked = false;
                        }
                      
                     

                        RefreshDataGrid2(txtSifra.Text);
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
         
        }

        private void RefreshDataGrid()
        {
            var select = " Select PaSifra, Rtrim(PaNaziv) as PaNaziv, PaUlicaHisnaSt , PaKraj, PaDelDrzave, PaPostnaSt, PaSifDrzave, PaTelefon1, PaZiroRac, " +
                " PaOpomba, PaDMatSt, PaEMail, PaEMatSt1, Rtrim(UIC) as UIC, (CASE WHEN Prevoznik > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  as Prevoznik, (CASE WHEN Posiljalac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  as Posiljalac, (CASE WHEN Primalac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  as Primalac ,  Brodar " +
            " , Vlasnik , Spediter , Platilac , Organizator from Partnerji";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
           
            /*
            var select4 = " Select Distinct PaSifra, RTrim(PaNaziv) as Partner From Partnerji";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPrevoznik.DataSource = ds4.Tables[0];
            cboPrevoznik.DisplayMember = "Partner";
            cboPrevoznik.ValueMember = "PaSifra";
            */


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
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Naziv";
            dataGridView1.Columns[1].Width = 250;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Ulica";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Mesto";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Oblast";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Pošta";
            dataGridView1.Columns[5].Width = 60;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Država";
            dataGridView1.Columns[6].Width = 60;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Telefon";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Tekući račun";
            dataGridView1.Columns[8].Width = 100;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Napomena";
            dataGridView1.Columns[9].Width = 250;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Matični broj";
            dataGridView1.Columns[10].Width = 70;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "E mail";
            dataGridView1.Columns[11].Width = 80;


            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "PIB";
            dataGridView1.Columns[12].Width = 70;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "UIC";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Prevoznik";
            dataGridView1.Columns[14].Width = 40;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Pošiljalac";
            dataGridView1.Columns[15].Width = 40;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Primalac";
            dataGridView1.Columns[16].Width = 40;

        }

     

        private void RefreshDataGrid2(string SifraPartnera)
        {
            var select = " Select PaKoSifra, (Rtrim(PaKOPriimek) + ' ' + Rtrim(PaKoIme)) as Naziv, PaKoOddelek as Odeljenje, PaKoTel as Telefon, PaKoMail as Mail, PaKOOpomba as Napomena  from PartnerjiKOntOseba   where PaKOSifra =" + SifraPartnera;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            /*
            var select4 = " Select Distinct PaSifra, RTrim(PaNaziv) as Partner From Partnerji";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPrevoznik.DataSource = ds4.Tables[0];
            cboPrevoznik.DisplayMember = "Partner";
            cboPrevoznik.ValueMember = "PaSifra";
            */


            dataGridView2.ReadOnly = true;
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

            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "Šifra";
            dataGridView2.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Naziv";
            dataGridView2.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Odeljenje";
            dataGridView2.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Telefon";
            dataGridView2.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Email";
            dataGridView2.Columns[4].Width = 250;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Napomena";
            dataGridView2.Columns[5].Width = 250;
        }

        private void cboPartneri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
            txtSifra.Text = "";
            txtNaziv.Text = "";
            txtUlica.Text = "";

            txtMesto.Text = "";
            txtOblast.Text = "";
            txtPosta.Text = "";
            txtDrzava.Text = "";
            txtTelefon.Text = "";
            txtTR.Text = "";
            txtNapomena.Text = "";
            txtMaticniBroj.Text = "";
            txtEmail.Text = "";
            txtPIB.Text = "";
            txtUIC.Text = "";
            chkPrevoznik.Checked = false;
            chkPosiljalac.Checked = false;
            chkPrimalac.Checked = false;
            chkBrodar.Checked = false;
            chkVlasnik.Checked = false;
            chkSpediter.Checked = false;
            chkPlatilac.Checked = false;
            chkOrganizator.Checked = false;
        }

        private void tsSave_Click_1(object sender, EventArgs e)
        {

            if (chkBrodar.Checked)
            {
                PomBrodar = 1;
            }
            else
            {
                PomBrodar = 0;
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
            if (chkOrganizator.Checked)
            {
                PomOrganizator = 1;
            }
            else
            {
                PomOrganizator = 0;
            }

            if (chkSpediter.Checked)
            {
                PomSpediter = 1;
            }
            else
            {
                PomSpediter = 0;
            }

            if (status == true)
            {
              //  txtNaziv.Text,  txtUlica.Text,  txtMesto.Text,  txtOblast.Text, txtPosta.Text ,txtDrzava.Text, txtTelefon.Text, txtTR.Text ,  txtNapomena.Text,txtMaticniBroj.Text,  txtEmail.Text,  txtPIB.Text
                InsertPartnerji ins = new InsertPartnerji();
                ins.InsPartneri( txtNaziv.Text, txtUlica.Text, txtMesto.Text, txtOblast.Text, txtPosta.Text, txtDrzava.Text, txtTelefon.Text, txtTR.Text, txtNapomena.Text, txtMaticniBroj.Text, txtEmail.Text, txtPIB.Text, txtUIC.Text, chkPrevoznik.Checked, chkPosiljalac.Checked, chkPrimalac.Checked, PomBrodar, PomVlasnik, PomSpediter, PomPlatilac, PomOrganizator );
            }
            else
            {
                InsertPartnerji upd = new InsertPartnerji();
                upd.UpdPartneri(Convert.ToInt32(txtSifra.Text), txtNaziv.Text, txtUlica.Text, txtMesto.Text, txtOblast.Text, txtPosta.Text, txtDrzava.Text, txtTelefon.Text, txtTR.Text, txtNapomena.Text, txtMaticniBroj.Text, txtEmail.Text, txtPIB.Text, txtUIC.Text, chkPrevoznik.Checked, chkPosiljalac.Checked, chkPrimalac.Checked, PomBrodar, PomVlasnik, PomSpediter, PomPlatilac, PomOrganizator);
            }
            RefreshDataGrid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertPartnerji del = new InsertPartnerji();
            del.DelPartneri(Convert.ToInt32(txtSifra.Text));
            RefreshDataGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

             Dokumenta.frmKontaktOsobe pko = new Dokumenta.frmKontaktOsobe(Convert.ToInt32(txtSifra.Text));
            pko.Show();
        }
    }
}
