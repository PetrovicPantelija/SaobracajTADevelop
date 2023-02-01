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
using System.Globalization;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms;

using MetroFramework.Forms;


namespace Saobracaj.Testiranje
{
    public partial class frmGenerisanjeTestaKorisnik : Form
    {
        int usao = 0;
        public frmGenerisanjeTestaKorisnik()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "frmGenerisanjeTestaKorisnik";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
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
                        //tsSave.Enabled = false;
                    }
                    delete = Convert.ToBoolean(reader["Brisanje"]);
                    if (delete == false)
                    {
                        //tsDelete.Enabled = false;
                    }
                }
            }

            conn.Close();
        }
        private void frmGenerisanjeTestaKorisnik_Load(object sender, EventArgs e)
        {
            var select = "select ID, Naziv from Testovi";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            cboGrupaTesta.DataSource = view;
            cboGrupaTesta.DisplayMember = "Naziv";
            cboGrupaTesta.ValueMember = "ID";

            IzbaciKorisnike();
            usao = 1;
        }

        private void IzbaciKorisnike()
        {
            var select = "  select Korisnici.Korisnik, Rtrim(DePriimek) + ' ' + Rtrim(DeIme) as Zaposleni, Delavci.DeSifra, DelovnaMesta.DmNaziv as RadnoMesto  from Korisnici " +
" inner join Delavci on Korisnici.DeSifra = Delavci.DeSifra " +
" inner join DelovnaMesta on DelovnaMesta.DmSifra = Delavci.DeSifDelMes " +
" order by DelovnaMesta.DmNaziv";


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
            dataGridView1.Columns[0].HeaderText = "Korisnik";
            dataGridView1.Columns[0].Width = 70;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni";
            dataGridView1.Columns[1].Width = 135;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Šifra";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Radno mesto";
            dataGridView1.Columns[3].Width = 250;

        }
        private void GenerisiPitanja(string Zaposleni)
        {
            var select = "SELECT TOP 20 TestoviPitanja.ID " +
                " FROM TestoviPitanja " +
                " where IDStavke = " + cboGrupaTesta.SelectedValue +  
                " ORDER BY NEWID() ";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];
            Tehnologija.InsertTestoviPitanja ins = new Tehnologija.InsertTestoviPitanja();

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                ins.InsGenerisaniTestoviPitanja(Zaposleni, Convert.ToInt32(cboGrupaTesta.SelectedValue), Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(0));
                
            }

            RefreshDataGrid2();

        }

        private void IzbaciPitanja(string Zaposleni)
        {
            
            Tehnologija.InsertTestoviPitanja ins = new Tehnologija.InsertTestoviPitanja();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ins.InsGenerisaniTestoviPitanja(Zaposleni, Convert.ToInt32(cboGrupaTesta.SelectedValue), Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(0));

            }

            RefreshDataGrid2();

        }

        private void RefreshDataGrid2()
        {
            if (usao == 1)
            { 
            var select = "  select TestoviGenerisanjaPitanja.Korisnik,Testovi.ID as IDTesta, Testovi.Naziv, TestoviPitanja.ID, TestoviPitanja.Pitanje, TestoviPitanja.OdgovorYes as TacanOdgovor, TestoviGenerisanjaPitanja.KorisnikOdgovor " +
" from TestoviGenerisanjaPitanja " +
" inner join Testovi on Testovi.ID = TestoviGenerisanjaPitanja.Test " +
" inner join TestoviPitanja on TestoviGenerisanjaPitanja.Pitanje = TestoviPitanja.ID " +
" where Testovi.ID = " + Convert.ToInt32(cboGrupaTesta.SelectedValue);


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "Korisnik";
            dataGridView2.Columns[0].Width = 70;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "ID Testa";
            dataGridView2.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Test";
            dataGridView2.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "ID pitanje";
            dataGridView2.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Pitanje";
            dataGridView2.Columns[4].Width = 340;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Tačan";
            dataGridView2.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Korisnik";
            dataGridView2.Columns[5].Width = 50;

            }



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string Zaposleni = "";
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        Zaposleni = row.Cells[0].Value.ToString();
                        GenerisiPitanja(Zaposleni);
                        // txtPutanja.Text = row.Cells[2].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }




            //Petlja za svakog selektovanog korisnika
            // Stavi kaunter na 20
            //Od svih pitanja selektuj random 1 pa proveri da li postoji ako ne upisi / povecaj caunter
            //ako da nista traži novo 
        }

        private void btnIzbaciTrasa_Click(object sender, EventArgs e)
        {
            string Zaposleni = "";
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        Zaposleni = row.Cells[0].Value.ToString();
                        IzbaciPitanja(Zaposleni);
                        // txtPutanja.Text = row.Cells[2].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void cboGrupaTesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGrid2();
        }
    }
}
