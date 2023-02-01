using MetroFramework.Forms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Saobracaj.Servis
{
    public partial class frmPrijavaMasinovodje : Form
    {
        public frmPrijavaMasinovodje()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        string niz = "";
        public static string code = "frmPrijavaMasinovodje";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
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
        private void RefreshDataGrid()
        {
            var select = "select Lokomotivaprijava.ID as ID, Lokomotiva, (select case when Smer = 1 then 'ODJAVA' else 'PRIJAVA' end) as Smer,Stanice.Opis as Stanica," +
                " LokomotivaPrijava.Datum, Rtrim(Delavci.DeIme)+ ' ' + Rtrim(Delavci.DePriimek) as Zaposleni," +
                " MotoSati, KM, Gorivo, Napomena, AktivnostID  from LokomotivaPrijava " +
                " inner join Delavci on Delavci.DeSifra = LokomotivaPrijava.Zaposleni " +
                " inner join Stanice on Stanice.ID = LokomotivaPrijava.Stanica order by LokomotivaPrijava.ID desc ";

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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int pom = Convert.ToInt32(row.Cells[0].Value.ToString());
                int Postoji = 0;
                //Proveri zadnjih 48 sati
                //Convert.ToDateTime(row.Cells[4].Value.ToString())
                TimeSpan span = Convert.ToDateTime(row.Cells[4].Value.ToString()).Subtract(DateTime.Now);
                if (span.Days > Convert.ToInt32(txtDana.Text))
                {
                    Postoji = ProveriIDZeleno(pom);
                    if (Postoji == 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                    }
                    dataGridView1.Refresh();
                }
            }


            /*
             Select t1.Zaposleni, t1.ID from (
select 
 sum(case when smer = 0 then 1 else 0 end) Prijave,
  sum(case when smer <> 0 then 1 else 0 end) Odjave,
  LokomotivaPrijava.Zaposleni,Max(LokomotivaPrijava.ID) as ID 
  from LokomotivaPrijava
  group by  LokomotivaPrijava.Zaposleni) t1
  where t1.Prijave > t1.Odjave
            */

        }

        private void frmPrijavaMasinovodje_Load(object sender, EventArgs e)
        {
            var select = " Select Distinct ID, Opis From Stanice";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboStanica.DataSource = ds.Tables[0];
            cboStanica.DisplayMember = "Opis";
            cboStanica.ValueMember = "ID";


            var select2 = " Select Distinct DeSifra, Rtrim(DeIme) + ' ' + Rtrim(DePriimek) as Zaposleni From Delavci";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboZaposleni.DataSource = ds2.Tables[0];
            cboZaposleni.DisplayMember = "Zaposleni";
            cboZaposleni.ValueMember = "DeSifra";



            var select3 = " select SmSifra, (SmSifra + SmNaziv) as Naziv from Mesta where Lokomotiva = 1";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            txtLokomotiva.DataSource = ds3.Tables[0];
            txtLokomotiva.DisplayMember = "Naziv";
            txtLokomotiva.ValueMember = "SmSifra";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int ProveriIDZeleno(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand(
                " select count(0) as Postoji from " +
                " (Select t1.Zaposleni, t1.ID from " +
                " (select  sum(case when smer = 0 then 1 else 0 end) Prijave,  " +
                " sum(case when smer <> 0 then 1 else 0 end) Odjave, " +
                 " LokomotivaPrijava.Zaposleni,Max(LokomotivaPrijava.ID) as ID " +
                 " from LokomotivaPrijava  group by LokomotivaPrijava.Zaposleni) t1 " +
                " where t1.Prijave > t1.Odjave) t2 where t2.ID = " + ID, con);
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                if (dr["Postoji"].ToString() == "1")
                {
                    con.Close();
                    return 1;
                }
                else
                {
                    return 0;
                    con.Close();

                }
            }
            return 0;
            con.Close();
        }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [id] ,[Lokomotiva] " +
             " ,[Smer] ,[Zaposleni] ,[Datum] " +
             " ,[Stanica] ,[MotoSati] " +
             " ,[KM] ,[Gorivo],[Napomena], AktivnostID " +
             "  FROM [TESTIRANJE].[dbo].[LokomotivaPrijava] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                txtSifra.Text = dr["ID"].ToString();
                txtLokomotiva.SelectedValue = dr["Lokomotiva"].ToString();

                if (dr["smer"].ToString() == "1")
                {
                    chkPrijava.Checked = true;
                }
                else
                {
                    chkPrijava.Checked = false;
                }
                cboZaposleni.SelectedValue = Convert.ToInt32(dr["Zaposleni"].ToString());
                dtpDatum.Value = Convert.ToDateTime(dr["Datum"].ToString());
                cboStanica.SelectedValue = Convert.ToInt32(dr["Stanica"].ToString());
                txtMotoSati.Text = dr["MotoSati"].ToString();
                txtKM.Text = dr["KM"].ToString();
                txtGorivo.Text = dr["Gorivo"].ToString();
                txtNapomena.Text = dr["Napomena"].ToString();
                txtAktivnostID.Text = dr["AktivnostID"].ToString();
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            InsertPrijavaMasinovodje del = new InsertPrijavaMasinovodje();
            del.DeletePrijavaMasinovodje(Convert.ToInt32(txtSifra.Text));
            RefreshDataGrid();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            InsertPrijavaMasinovodje upd = new InsertPrijavaMasinovodje();

            int pomsmer = 0;
            if (chkPrijava.Checked == true)
            {

                pomsmer = 1;
            }
            upd.UpdatePrijavaMasinovodje(Convert.ToInt32(txtSifra.Text), txtLokomotiva.SelectedValue.ToString(), pomsmer,Convert.ToInt32(cboZaposleni.SelectedValue), dtpDatum.Value, Convert.ToInt32(cboStanica.SelectedValue), Convert.ToDouble(txtMotoSati.Text), Convert.ToDouble(txtKM.Text), Convert.ToDouble(txtGorivo.Text), txtNapomena.Text);
            RefreshDataGrid();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            InsertPrijavaMasinovodje upd = new InsertPrijavaMasinovodje();

            int pomsmer = 0;
            if (chkPrijava.Checked == true)
            {

                pomsmer = 1;
            }
            upd.InsertPrijavaMasin(txtLokomotiva.SelectedValue.ToString(), pomsmer, Convert.ToInt32(cboZaposleni.SelectedValue), dtpDatum.Value, Convert.ToInt32(cboStanica.SelectedValue), Convert.ToDouble(txtMotoSati.Text), Convert.ToDouble(txtKM.Text), Convert.ToDouble(txtGorivo.Text), txtNapomena.Text);
            RefreshDataGrid();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            InsertPrijavaMasinovodje upd = new InsertPrijavaMasinovodje();
            upd.InsertPrijavaMasin(txtLokomotiva.SelectedValue.ToString(), 1, Convert.ToInt32(cboZaposleni.SelectedValue), dtpDatum.Value, Convert.ToInt32(cboStanica.SelectedValue), Convert.ToDouble(txtMotoSati.Text), Convert.ToDouble(txtKM.Text), Convert.ToDouble(txtGorivo.Text), txtNapomena.Text);
            RefreshDataGrid();
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
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
    }
}

