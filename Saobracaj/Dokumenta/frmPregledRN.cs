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

namespace Saobracaj.Dokumenta
{
    public partial class frmPregledRN : Form
    {
        public static string code = "frmPregledRN";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        public frmPregledRN()
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
        private void frmPregledRN_Load(object sender, EventArgs e)
        {
            RefreshNajave();
            RefreshBruto();
            RefreshRNPL();
            RefreshRNLA();
        }
        private void RefreshRNPL()
        {

            // Potrebno procitati duzinu sa teretnice
            var select = " Select RadniNalog.ID, RadniNalogTrase.Rezi, RadniNalogLokNaTrasi.SMSifra,  " +
                " Trase.Voz,IDTeretnice, IDNajave,  st.opis ,prijemna, prevozna, predajna, " +
                " COUNT(BrojKola) as BrojKola, SUM(Duzina) as Duzina, Teretnica.VremeOd as VremeOdTeretnica, Teretnica.VremeDo as VremeDoTeretnica, " +
                " SUM(tara) as Tara, SUM(neto) as Neto, SUM(p) as P " +
                " from RadniNalog " +
                " inner join RadniNalogTrase on RadniNalog.ID = RadniNalogTrase.IDRadnogNaloga " +
                " inner " +
                " join RadniNalogLokNaTrasi on RadniNalog.ID = RadniNalogLokNaTrasi.IDRadnogNaloga " +
                " inner " +
                " join RadniNalogTeretnice on RadniNalog.ID = RadniNalogTeretnice.IDRadnogNaloga " +
                " inner " +
                " join Trase On RadniNalogTrase.IDTrase = Trase.ID " +
                " inner join Teretnica " +
                " on RadniNalogTeretnice.IDTeretnice = Teretnica.ID " +
                " inner " +
                " join stanice as st on st.ID = Teretnica.StanicaPopisa " +
                " inner " +
                " join TeretnicaStavke ts on ts.BrojTeretnice = Teretnica.ID where RadniNalog.StatusRN = 'PL' " +
                " group by RadniNalog.ID,Trase.Voz, IDTeretnice,st.Opis, RadniNalogTrase.Rezi,RAdniNalog.ID,prijemna, prevozna, predajna, IDNajave, RadniNalogLokNaTrasi.SMSifra " +
                " , Teretnica.VremeOd , Teretnica.VremeDo ";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            datagridview3.ReadOnly = true;
            datagridview3.DataSource = ds.Tables[0];
            /*
            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID Najave";
            dataGridView2.Columns[0].Width = 55;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Iskljucena";
            dataGridView2.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Otpravna";
            dataGridView2.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Uputna";
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
            dataGridView2.Columns[7].HeaderText = "ATA";
            dataGridView2.Columns[7].Width = 80;

            /*

               foreach (DataGridViewRow row in dataGridView1.Rows)
               {
                   string Pakerista = row.Cells[9].Value.ToString();

                   if ((Pakerista == "True"))
                   {
                       row.DefaultCellStyle.BackColor = Color.Green;
                       row.DefaultCellStyle.SelectionBackColor = Color.Green;
                       row.DefaultCellStyle.ForeColor = Color.White;
                   }
                   else
                   {
                       row.DefaultCellStyle.BackColor = Color.Yellow;
                       row.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                       row.DefaultCellStyle.ForeColor = Color.Black;

                   }
               }

               */


        }

        private void RefreshRNLA()
        {

            // Potrebno procitati duzinu sa teretnice
            var select = " Select RadniNalog.ID, RadniNalogTrase.Rezi, RadniNalogLokNaTrasi.SMSifra,  " +
                " Trase.Voz,IDTeretnice, IDNajave,  st.opis ,prijemna, prevozna, predajna, " +
                " COUNT(BrojKola) as BrojKola, SUM(Duzina) as Duzina, Teretnica.VremeOd as VremeOdTeretnica, Teretnica.VremeDo as VremeDoTeretnica, " +
                " SUM(tara) as Tara, SUM(neto) as Neto, SUM(p) as P " +
                " from RadniNalog " +
                " inner join RadniNalogTrase on RadniNalog.ID = RadniNalogTrase.IDRadnogNaloga " +
                " inner " +
                " join RadniNalogLokNaTrasi on RadniNalog.ID = RadniNalogLokNaTrasi.IDRadnogNaloga " +
                " inner " +
                " join RadniNalogTeretnice on RadniNalog.ID = RadniNalogTeretnice.IDRadnogNaloga " +
                " inner " +
                " join Trase On RadniNalogTrase.IDTrase = Trase.ID " +
                " inner join Teretnica " +
                " on RadniNalogTeretnice.IDTeretnice = Teretnica.ID " +
                " inner " +
                " join stanice as st on st.ID = Teretnica.StanicaPopisa " +
                " inner " +
                " join TeretnicaStavke ts on ts.BrojTeretnice = Teretnica.ID where RadniNalog.StatusRN = 'LA' " +
                " group by RadniNalog.ID,Trase.Voz, IDTeretnice,st.Opis, RadniNalogTrase.Rezi,RAdniNalog.ID,prijemna, prevozna, predajna, IDNajave, RadniNalogLokNaTrasi.SMSifra " +
                " , Teretnica.VremeOd , Teretnica.VremeDo ";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            datagridview4.ReadOnly = true;
            datagridview4.DataSource = ds.Tables[0];
            /*
            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID Najave";
            dataGridView2.Columns[0].Width = 55;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Iskljucena";
            dataGridView2.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Otpravna";
            dataGridView2.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Uputna";
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
            dataGridView2.Columns[7].HeaderText = "ATA";
            dataGridView2.Columns[7].Width = 80;

            /*

               foreach (DataGridViewRow row in dataGridView1.Rows)
               {
                   string Pakerista = row.Cells[9].Value.ToString();

                   if ((Pakerista == "True"))
                   {
                       row.DefaultCellStyle.BackColor = Color.Green;
                       row.DefaultCellStyle.SelectionBackColor = Color.Green;
                       row.DefaultCellStyle.ForeColor = Color.White;
                   }
                   else
                   {
                       row.DefaultCellStyle.BackColor = Color.Yellow;
                       row.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                       row.DefaultCellStyle.ForeColor = Color.Black;

                   }
               }

               */


        }


        private void RefreshBruto()
        {

            // Potrebno procitati duzinu sa teretnice
            var select = " Select f1.IDNajave as NajavaID ,Iskljucena, min(Otpravna) as Otpravna, Min(Uputna) as Uputna,COUNT(ID) as BrojVagona, SUM(Bruto) as Bruto, SUM(Duzina) as Duzina,  min(ATA) as ATA from ( " +
   " Select ts.IDNajave, TIV.ID, TIV.StanicaIskljucenja, s1.Opis as Iskljucena,s2.Opis as Otpravna, s3.Opis as Uputna, ts.Duzina, (ts.Tara + ts.Neto) as Bruto, Najava.StvarnoPrimanje as ATA " +
   " from TeretnicaIskljuceniVagoni TIV inner join stanice s1 on TIV.StanicaIskljucenja = s1.ID " +
   " inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id " +
   " inner join stanice s2 on ts.Otpravna = s2.ID " +
   " inner join stanice s3 on ts.Uputna = s3.ID " +
   " inner join Najava on Najava.ID = ts.IDNajave ) f1 " +
   " group by Iskljucena, IDNajave";

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
            dataGridView2.Columns[1].HeaderText = "Iskljucena";
            dataGridView2.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Otpravna";
            dataGridView2.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Uputna";
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
            dataGridView2.Columns[7].HeaderText = "ATA";
            dataGridView2.Columns[7].Width = 80;

         /*

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string Pakerista = row.Cells[9].Value.ToString();

                if ((Pakerista == "True"))
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;

                }
            }

            */


        }

        /*
          var select = " Select f1.IDNajave as NajavaID ,Iskljucena, min(Otpravna) as Otpravna, Min(Uputna) as Uputna,COUNT(ID) as BrojVagona, SUM(Bruto) as Neto, SUM(Duzina) as Tara, sum(Duzina) as Duzina, min(ATA) as ATA from ( " +
" Select ts.IDNajave, TIV.ID, TIV.StanicaIskljucenja, s1.Opis as Iskljucena,s2.Opis as Otpravna, s3.Opis as Uputna, ts.Duzina, (ts.Tara + ts.Neto) as Bruto, Najava.StvarnoPrimanje as ATA " +
" from TeretnicaIskljuceniVagoni TIV inner join stanice s1 on TIV.StanicaIskljucenja = s1.ID " +
" inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id " +
" inner join stanice s2 on ts.Otpravna = s2.ID " +
" inner join stanice s3 on ts.Uputna = s3.ID " +
" inner join Najava on Najava.ID = ts.IDNajave ) f1 " +
" group by Iskljucena, IDNajave";
        */
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
          " WHERE (Status = 1 ) or (Status = 2) order by  stanice_1.Opis, Najava.PredvidjenoPrimanje desc";
          
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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string Pakerista = row.Cells[9].Value.ToString();
              
                if ((Pakerista == "True"))
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else 
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;

                }
            }




            }
    }
}
