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

using Microsoft.Reporting.WinForms;

namespace Saobracaj.Dokumenta
{
    public partial class frmPutniNaloziPregled : Form
    {
        public frmPutniNaloziPregled()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        string niz = "";
        public static string code = "frmPutniNaloziPregled";
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
        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            var select = "";

            if (chkLokomotiva.Checked == true)
            {
                select = "Select Distinct Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, DElavci.DeSifra,  " +
                " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, MestoUpucivanja, Aktivnosti.Opis, " +
                 " CASE WHEN Aktivnosti.PNKreiran > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PutniNalog, Mesto, KrNaziv " +
                " from Aktivnosti  " +
                " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
                " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                  " inner Join AktivnostiStavke " +
                " on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
                " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
                "  where KrNaziv<>'0' and  Aktivnosti.PNKreiran = 0 and Ukupno>0 and VremeOd > '2020-01-01 00:00:00.000' and VrstaAktivnosti.ID<>41 order by Zaposleni, Aktivnosti.ID desc";
            }
            else
            {
                select = "Select Distinct Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, DElavci.DeSifra,  " +
              " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, MestoUpucivanja, Aktivnosti.Opis, " +
                " CASE WHEN Aktivnosti.PNKreiran > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PutniNalog, Mesto, KrNaziv " +
              " from Aktivnosti  " +
              " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
              " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
               " inner Join AktivnostiStavke " +
                " on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
              " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
              "  where  KrNaziv<>'0' and  Aktivnosti.PNKreiran = 0  and Ukupno>0 and VremeOd > '2020-01-01 00:00:00.000' and VrstaAktivnosti.ID<>41 order by Zaposleni, Aktivnosti.ID desc";
            }
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Oznaka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme od";
            dataGridView1.Columns[4].Width = 120;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme do";
            dataGridView1.Columns[5].Width = 120;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupno";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Mesto Upućenja";
            dataGridView1.Columns[7].Width = 150;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Opis aktivnosti";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Putni nal";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Mesto";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Mesto up naziv";
            dataGridView1.Columns[11].Width = 80;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Convert.ToInt32(row.Cells[15].Value.ToString()), row.Cells[1].Value.ToString())
            progressBar1.Maximum = dataGridView1.Rows.Count;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            double Cena = 0;

            InsertPotNal PotNal = new InsertPotNal();
            //Skupiti sve parametre
           
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // porudzbina.InsertPorudzbinaPostav(Convert.ToInt32(LargoPaketID), Convert.ToDecimal(Kolicina));
                if (row.Selected == true)
                {
                    int Puna = 1;
                    int Vreme = Convert.ToInt32(row.Cells[6].Value);
                    if (Vreme >= 18)
                    {
                        Puna = 1;
                        Cena = 3637.5;
                      
                    }
                    
                        
                    if (Vreme >= 12)
                    {
                        Puna = 1;
                        Cena = 2425;
                    }
                   
                    
                    else
                    {
                        Puna = 0;
                        Cena = 1212.5;
                    }
                    PotNal.InsPotNal(Convert.ToInt32(row.Cells[2].Value.ToString()), Convert.ToInt32(row.Cells[7].Value.ToString()), 1, txtMestoTroska.Text, Convert.ToDateTime(row.Cells[4].Value.ToString()), Convert.ToDateTime(row.Cells[5].Value.ToString()), Convert.ToInt32(1), Cena, "");
                    PotNal.InsPotNalRelacije(Convert.ToInt32(row.Cells[2].Value.ToString()), Convert.ToInt32(row.Cells[7].Value.ToString()), 1, Convert.ToInt32(1), Convert.ToDateTime(row.Cells[4].Value.ToString()), Convert.ToDateTime(row.Cells[5].Value.ToString()));
                    PotNal.InsPotNalStavke(Convert.ToInt32(1), Cena, Cena, Puna);
                    PotNal.UpdPotNal(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }
                progressBar1.Value = progressBar1.Value + 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var select = "";

                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, DElavci.DeSifra,  " +
                " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, MestoUpucivanja, Aktivnosti.Opis, " +
                  " CASE WHEN Aktivnosti.PNKreiran > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PutniNalog, Mesto, KrNaziv  " +
                " from Aktivnosti  " +
                " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
                " inner Join AktivnostiStavke " +
                " on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
                " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
                 " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                " where Smederevo = 1 and VremeOd > '2020-01-01 00:00:00.000' and VrstaAktivnosti.ID<>41";

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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Oznaka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme od";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme do";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupno";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Mesto Upućenja";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Opis aktivnosti";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Putni nal";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Mesto";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Mesto up naziv";
            dataGridView1.Columns[11].Width = 80;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var select = "";

            select = "Select Distinct Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, DElavci.DeSifra,  " +
            " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, MestoUpucivanja, Aktivnosti.Opis, " +
              " CASE WHEN Aktivnosti.PNKreiran > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PutniNalog, Mesto, KrNaziv  " +
            " from Aktivnosti  " +
            " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
            " inner Join AktivnostiStavke " +
            " on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
            " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
             " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
            " where Kragujevac = 1 and VremeOd > '2020-01-01 00:00:00.000' and VrstaAktivnosti.ID<>41";

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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Oznaka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme od";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme do";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupno";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Mesto Upućenja";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Opis aktivnosti";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Putni nal";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Mesto";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Mesto up naziv";
            dataGridView1.Columns[11].Width = 80;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var select = "";

            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, DElavci.DeSifra,  " +
            " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, MestoUpucivanja, Aktivnosti.Opis, " +
              " CASE WHEN Aktivnosti.PNKreiran > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PutniNalog, Mesto, KrNaziv  " +
            " from Aktivnosti  " +
            " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
            " inner Join AktivnostiStavke " +
            " on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
            " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
             " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
            " where CG = 1 and VremeOd > '2020-01-01 00:00:00.000' and VrstaAktivnosti.ID<>41";

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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Oznaka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme od";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme do";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupno";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Mesto Upućenja";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Opis aktivnosti";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Putni nal";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Mesto";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Mesto up naziv";
            dataGridView1.Columns[11].Width = 80;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var select = "";

            select = "Select Distinct Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, DElavci.DeSifra,  " +
            " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, MestoUpucivanja, Aktivnosti.Opis, " +
              " CASE WHEN Aktivnosti.PNKreiran > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PutniNalog, Mesto, KrNaziv  " +
            " from Aktivnosti  " +
            " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
            " inner Join AktivnostiStavke " +
            " on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
            " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
             " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
            " where Remont = 1 and VremeOd > '2020-01-01 00:00:00.000' and VrstaAktivnosti.ID<>41";

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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Oznaka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme od";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme do";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupno";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Mesto Upućenja";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Opis aktivnosti";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Putni nal";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Mesto";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Mesto up naziv";
            dataGridView1.Columns[11].Width = 80;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            double Cena = 0;

            InsertPotNal PotNal = new InsertPotNal();
            //Skupiti sve parametre

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // porudzbina.InsertPorudzbinaPostav(Convert.ToInt32(LargoPaketID), Convert.ToDecimal(Kolicina));
                if (row.Selected == true)
                {
                    int Puna = 1;
                    int Vreme = Convert.ToInt32(row.Cells[6].Value);
                    if (Vreme >= 18)
                    {
                        Puna = 1;
                        Cena = 3523;

                    }


                    if (Vreme >= 12)
                    {
                        Puna = 1;
                        Cena = 2349;
                    }


                    else
                    {
                        Puna = 0;
                        Cena = 1174;
                    }
                //    PotNal.InsPotNal(Convert.ToInt32(row.Cells[2].Value.ToString()), Convert.ToInt32(row.Cells[7].Value.ToString()), 1, txtMestoTroska.Text, Convert.ToDateTime(row.Cells[4].Value.ToString()), Convert.ToDateTime(row.Cells[5].Value.ToString()), Convert.ToInt32(1), Cena, "");
                 //   PotNal.InsPotNalRelacije(Convert.ToInt32(row.Cells[2].Value.ToString()), Convert.ToInt32(row.Cells[7].Value.ToString()), 1, Convert.ToInt32(1), Convert.ToDateTime(row.Cells[4].Value.ToString()), Convert.ToDateTime(row.Cells[5].Value.ToString()));
                 //   PotNal.InsPotNalStavke(Convert.ToInt32(1), Cena, Cena, Puna);
                    PotNal.UpdPotNal(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }
                //progressBar1.Value = progressBar1.Value + 1;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var select = "";

            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, DElavci.DeSifra,  " +
            " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, MestoUpucivanja, Aktivnosti.Opis, " +
              " CASE WHEN Aktivnosti.PNKreiran > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PutniNalog, Mesto, KrNaziv  " +
            " from Aktivnosti  " +
            " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
            " inner Join AktivnostiStavke " +
            " on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
            " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
             " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
            " where VremeOd > '2020-01-01 00:00:00.000' and VrstaAktivnosti.ID=41";

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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Oznaka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme od";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme do";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupno";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Mesto Upućenja";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Opis aktivnosti";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Putni nal";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Mesto";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Mesto up naziv";
            dataGridView1.Columns[11].Width = 80;
        }
    
    }
}