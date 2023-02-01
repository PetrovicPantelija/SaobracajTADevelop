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
using MetroFramework.Forms;
using Syncfusion.Windows.Forms.Grid.Grouping;


namespace Saobracaj.Dokumenta
{
    public partial class frmCentralnaTablaCpajal : Syncfusion.Windows.Forms.Office2010Form
    {
        public static string code = "frmCentralnaTablaCpajal";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        public frmCentralnaTablaCpajal()
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
        private void RefreshNajave()
        {

            // Potrebno procitati duzinu sa teretnice
            var select = "  SELECT    najava.ID,  " +
          " Partnerji.PaNaziv AS Prevoznik,  " +
          " stanice.Opis AS Uputna, stanice_1.Opis AS Otpravna, " +
          "  Najava.BrojKola, Najava.Tezina, Najava.Duzina, " +
          "  Najava.PredvidjenoPrimanje as ETA, " +
          "   CASE WHEN Najava.RID > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as StatusN, " +
            " CASE WHEN Najava.CIM > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Dokumentacija " +
          "   FROM  Najava " +
          " INNER JOIN Partnerji ON Najava.Prevoznik = Partnerji.PaSifra " +
          "  INNER JOIN  stanice ON Najava.Uputna = stanice.ID " +
          "  INNER JOIN  stanice AS stanice_1 ON Najava.Otpravna = stanice_1.ID  " +
          " WHERE (Status = 1 ) or (Status = 2) or (Status = 3) order by  stanice_1.Opis, Najava.PredvidjenoPrimanje desc";

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
            dataGridView1.Columns[0].HeaderText = "ID Najave";
            dataGridView1.Columns[0].Width = 55;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Prevoznik";
            dataGridView1.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Uputna";
            dataGridView1.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Otpravna";
            dataGridView1.Columns[3].Width = 90;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vagoni";
            dataGridView1.Columns[4].Width = 40;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Težina";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Dužina";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "ETA";
            dataGridView1.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "RID";
            dataGridView1.Columns[8].Width = 35;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Dok";
            dataGridView1.Columns[9].Width = 35;

        }

        private void RefreshNajave2()
        {

            // Potrebno procitati duzinu sa teretnice
            var select = "  SELECT    najava.ID,  " +
          " Partnerji.PaNaziv AS Prevoznik,  " +
          " stanice.Opis AS Uputna, stanice_1.Opis AS Otpravna, " +
          "  Najava.BrojKola, Najava.Tezina, Najava.Duzina, " +
          "  Najava.PredvidjenoPrimanje as ETA, " +
          "   CASE WHEN Najava.RID > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as StatusN, " +
            " CASE WHEN Najava.CIM > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Dokumentacija " +
          "   FROM  Najava " +
          " INNER JOIN Partnerji ON Najava.Prevoznik = Partnerji.PaSifra " +
          "  INNER JOIN  stanice ON Najava.Uputna = stanice.ID " +
          "  INNER JOIN  stanice AS stanice_1 ON Najava.Otpravna = stanice_1.ID  " +
          " WHERE (Status = 4 ) or (Status = 6) order by  stanice_1.Opis, Najava.PredvidjenoPrimanje desc";

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
            dataGridView2.Columns[0].HeaderText = "ID Najave";
            dataGridView2.Columns[0].Width = 55;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Prevoznik";
            dataGridView2.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Uputna";
            dataGridView2.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Otpravna";
            dataGridView2.Columns[3].Width = 90;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Vagoni";
            dataGridView2.Columns[4].Width = 40;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Težina";
            dataGridView2.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "Dužina";
            dataGridView2.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "ETA";
            dataGridView2.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "RID";
            dataGridView2.Columns[8].Width = 35;

            DataGridViewColumn column10 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "Dok";
            dataGridView2.Columns[9].Width = 35;





        }



        private void RefreshDataGridRN()
        {
            string pom = "'1'";
            var select = " SELECT  d1.IDRadnogNaloga, d1.RB, d1.IDTrase, " +
" Trase.Voz, " +
" RN.StatusRN, " +
 "   CASE WHEN d1.Rezi > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Rezi, " +
" stanice_2.Opis as StanicaOd," +
" stanice_3.Opis as StanicaDo," +
" (Cast(Zaposleni.DeSifra as nvarchar(3)) + '--'  + Rtrim(Zaposleni.DeIme) + ' ' + Rtrim(Zaposleni.DePriimek)) as Planer, " +
" ( " +
" SELECT " +
" STUFF( " +
" ( " +
" SELECT distinct " +
"  '/' + Cast(SmSifra as nvarchar(8)) " +
"  FROM RadniNalogLokNaTrasi " +
" where RadniNalogLokNaTrasi.IDRadnogNaloga = d1.IDRadnogNaloga and  RadniNalogLokNaTrasi.IdTrase = d1.IDTrase " +
"  FOR XML PATH('') " +
"  ), 1, 1, '' " +
" ) As Skupljen) as Lokom, " +
"(  SELECT  STUFF(  (  SELECT distinct   '/' + (Cast(del.DeSifra as nvarchar(3)) + '--'  + Rtrim(del.DeIme) + ' ' + Rtrim(del.DePriimek))  " +
"   from RadniNalogTraseLokZap  " +
"   inner Join Delavci del on (RadniNalogTraseLokZap.DeSifra = del.DeSifra) " +
"   where RadniNalogTraseLokZap.IDRadnogNaloga = d1.IDRadnogNaloga " +
"   and  RadniNalogTraseLokZap.IdTrase = d1.IDTrase " +
"   FOR XML PATH('')   ), 1, 1, ''  ) As Skupljen2) " +
"   as Zaposleni2, " +
" d1.DatumPolaska ,d1.DatumDolaska , " +
" d1.Vreme   " +
" FROM RadniNalogTrase d1 INNER JOIN  Trase " +
" ON d1.IDTrase = Trase.ID " +
" INNER JOIN  stanice ON Trase.Pocetna = stanice.ID " +
" INNER JOIN  stanice AS stanice_2 ON d1.StanicaOd = stanice_2.ID " +
" INNER JOIN  stanice AS stanice_3 ON d1.StanicaDo = stanice_3.ID " +
" INNER JOIN  stanice AS stanice_1 ON Trase.Krajnja = stanice_1.ID " +
" inner Join RadniNalog as RN ON d1.IDRadnogNaloga = RN.ID " +
" inner Join Delavci as Zaposleni ON RN.Planer = Zaposleni.DeSifra ";


         
                pom = pom + ",'RA'";
          
                pom = pom + ",'OD'";
         
                pom = pom + ",'PL'";
         
                pom = pom + ",'PR'";

                pom = pom + ",'ZA'";


            select = select + "where RN.StatusRN in ( " + pom + ") and DatumDolaskaReal = '1900-01-01 00:00:00.000'" + " order by IDRadnogNaloga, d1.RB "; ;


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "RN";
            dataGridView3.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "RB";
            dataGridView3.Columns[1].Width = 20;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].Visible = false;
            //  dataGridView1.Columns[2].HeaderText = "ID Trase";
            //  dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Trase";
            dataGridView3.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "St";
            dataGridView3.Columns[4].Width = 20;

            //Rezi

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Rezi";
            dataGridView3.Columns[5].Width = 20;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Stanica od";
            dataGridView3.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Stanica do";
            dataGridView3.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Planer";
            dataGridView3.Columns[8].Width = 70;

            DataGridViewColumn column10 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "Lokomotive";
            dataGridView3.Columns[9].Width = 90;

            DataGridViewColumn column11 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Osoblje";
            dataGridView3.Columns[10].Width = 150;


            DataGridViewColumn column12 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Rel. polazak";
            dataGridView3.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Rel dolazak";
            dataGridView3.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "Real vreme";
            dataGridView3.Columns[13].Width = 30;

        }

        private void RefreshDataGridRN2()
        {
            string pom = "'1'";
            var select = " SELECT  d1.IDRadnogNaloga, d1.RB, d1.IDTrase, " +
" Trase.Voz, " +
" RN.StatusRN, " +
 "   CASE WHEN d1.Rezi > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Rezi, " +
" stanice_2.Opis as StanicaOd," +
" stanice_3.Opis as StanicaDo," +
" (Cast(Zaposleni.DeSifra as nvarchar(3)) + '--'  + Rtrim(Zaposleni.DeIme) + ' ' + Rtrim(Zaposleni.DePriimek)) as Planer, " +
" ( " +
" SELECT " +
" STUFF( " +
" ( " +
" SELECT distinct " +
"  '/' + Cast(SmSifra as nvarchar(8)) " +
"  FROM RadniNalogLokNaTrasi " +
" where RadniNalogLokNaTrasi.IDRadnogNaloga = d1.IDRadnogNaloga and  RadniNalogLokNaTrasi.IdTrase = d1.IDTrase " +
"  FOR XML PATH('') " +
"  ), 1, 1, '' " +
" ) As Skupljen) as Lokom, " +
"(  SELECT  STUFF(  (  SELECT distinct   '/' + (Cast(del.DeSifra as nvarchar(3)) + '--'  + Rtrim(del.DeIme) + ' ' + Rtrim(del.DePriimek))  " +
"   from RadniNalogTraseLokZap  " +
"   inner Join Delavci del on (RadniNalogTraseLokZap.DeSifra = del.DeSifra) " +
"   where RadniNalogTraseLokZap.IDRadnogNaloga = d1.IDRadnogNaloga " +
"   and  RadniNalogTraseLokZap.IdTrase = d1.IDTrase " +
"   FOR XML PATH('')   ), 1, 1, ''  ) As Skupljen2) " +
"   as Zaposleni2, " +
" d1.DatumPolaska ,d1.DatumDolaska , " +
" d1.Vreme   " +
" FROM RadniNalogTrase d1 INNER JOIN  Trase " +
" ON d1.IDTrase = Trase.ID " +
" INNER JOIN  stanice ON Trase.Pocetna = stanice.ID " +
" INNER JOIN  stanice AS stanice_2 ON d1.StanicaOd = stanice_2.ID " +
" INNER JOIN  stanice AS stanice_3 ON d1.StanicaDo = stanice_3.ID " +
" INNER JOIN  stanice AS stanice_1 ON Trase.Krajnja = stanice_1.ID " +
" inner Join RadniNalog as RN ON d1.IDRadnogNaloga = RN.ID " +
" inner Join Delavci as Zaposleni ON RN.Planer = Zaposleni.DeSifra ";



            pom = pom + ",'RA'";

            pom = pom + ",'OD'";

            pom = pom + ",'PL'";

            pom = pom + ",'PR'";

            pom = pom + ",'ZA'";


            select = select + "where RN.StatusRN in ( " + pom + ") and DatumDolaskaReal <> '1900-01-01 00:00:00.000'" + " order by IDRadnogNaloga, d1.RB "; ;


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView4.Columns[0];
            dataGridView4.Columns[0].HeaderText = "RN";
            dataGridView4.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView4.Columns[1];
            dataGridView4.Columns[1].HeaderText = "RB";
            dataGridView4.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView4.Columns[2];
            dataGridView4.Columns[2].Visible = false;
            //  dataGridView1.Columns[2].HeaderText = "ID Trase";
            //  dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView4.Columns[3];
            dataGridView4.Columns[3].HeaderText = "Trase";
            dataGridView4.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView4.Columns[4];
            dataGridView4.Columns[4].HeaderText = "St";
            dataGridView4.Columns[4].Width = 30;

            //Rezi

            DataGridViewColumn column6 = dataGridView4.Columns[5];
            dataGridView4.Columns[5].HeaderText = "Rezi";
            dataGridView4.Columns[5].Width = 30;

            DataGridViewColumn column7 = dataGridView4.Columns[6];
            dataGridView4.Columns[6].HeaderText = "Stanica od";
            dataGridView4.Columns[6].Width = 90;

            DataGridViewColumn column8 = dataGridView4.Columns[7];
            dataGridView4.Columns[7].HeaderText = "Stanica do";
            dataGridView4.Columns[7].Width = 90;

            DataGridViewColumn column9 = dataGridView4.Columns[8];
            dataGridView4.Columns[8].HeaderText = "Planer";
            dataGridView4.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView4.Columns[9];
            dataGridView4.Columns[9].HeaderText = "Lokomotive";
            dataGridView4.Columns[9].Width = 120;

            DataGridViewColumn column11 = dataGridView4.Columns[10];
            dataGridView4.Columns[10].HeaderText = "Osoblje";
            dataGridView4.Columns[10].Width = 220;


            DataGridViewColumn column12 = dataGridView4.Columns[11];
            dataGridView4.Columns[11].HeaderText = "Rel. polazak";
            dataGridView4.Columns[11].Width = 90;

            DataGridViewColumn column13 = dataGridView4.Columns[12];
            dataGridView4.Columns[12].HeaderText = "Rel dolazak";
            dataGridView4.Columns[12].Width = 90;

            DataGridViewColumn column14 = dataGridView4.Columns[13];
            dataGridView4.Columns[13].HeaderText = "Real vreme";
            dataGridView4.Columns[13].Width = 40;

        }

        private void frmCentralnaTablaCpajal_Load(object sender, EventArgs e)
        {
            RefreshNajave();
            RefreshNajave2();
            RefreshDataGridRN();
            RefreshDataGridRN2();

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void otvoriRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadniNalog ter = new frmRadniNalog(txtSifra.Text);
            ter.Show();
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
                       // VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        //VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        //VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void datagridview4_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void otvoriRNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadniNalog ter = new frmRadniNalog(txtSifra.Text);
            ter.Show();
        }

        private void otvoriNajavuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNajava ter = new frmNajava(txtSifra.Text);
            ter.Show();
        }

        private void otvoriNajavuDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNajava ter = new frmNajava(txtSifra.Text);
            ter.Show();
        }
    }
}
