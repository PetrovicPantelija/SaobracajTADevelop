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
namespace Saobracaj.Dokumenta
{
    public partial class frmNajava20 : Form
    {
        bool go = false;
        int count = 1;
        int tag = 1;
         System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
         System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public static string code = "frmNajava20";
        string niz = "";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        public frmNajava20()
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
                       // tsSave.Enabled = false;
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
        private void frmNajava20_Load(object sender, EventArgs e)
        {
            IdGrupe();
            IdForme();
            PravoPristupa();

            timer.Interval = 50000;
            timer.Tick += new System.EventHandler(timer_Tick);
            timer.Start();
           // t.Interval = 500; // specify interval time as you want
           // t.Tick += new EventHandler(timer_Tick);
           // t.Start();
           
          
/*
            timer1.Start();
            System.Threading.Thread thread = new System.Threading.Thread(Blink);
            thread.Start();
           */
            /*
             else if ((Pakerista == "0") && (Kontrolisao == "1"))
                {
                    row.DefaultCellStyle.BackColor = Color.GreenYellow;
                    row.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
                }
                else if ((Pakerista == "1") && (Kontrolisao == "0"))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                }
            */

        }

        void timer_Tick(object sender, EventArgs e)
        {
            int Broj = 0;
            //Izbrisati drugu tablu
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection2);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Count(*) as Broj  FROM [TESTIRANJE].[dbo].[Najava] where Status <> 7", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                Broj = Convert.ToInt32(dr["Broj"].ToString());
                
            }

            con.Close();


            //End of broj
           var select = "";
          // var select2 = ""; 
          if (tag == 1)
           {


               select = " select * from (select *,  " +
        "  (ROW_NUMBER() OVER (ORDER BY t1.Granicna)) as kolona   from (SELECT  top 60  najava.ID,  stanice_4.opis as Granicna, " +
 " Najava.BrojNajave , Trase.Voz, " +
 "  Partnerji.PaNaziv AS Prevoznik, " +
  "  Partnerji_3.PaNaziv AS PrevoznikZa,  " +
  "   stanice_1.Opis AS Uputna, stanice.Opis AS Otpravna, " +
   "   Najava.PrevozniPut, Najava.PredvidjenoPrimanje, " +
    "   Najava.StvarnoPrimanje,  Najava.PredvidjenaPredaja, " +
     "   Najava.StvarnaPredaja,  CASE WHEN Najava.RID > 0 THEN Cast('R' as Char) " +
      "   ELSE Cast('' as CHAR) END as RID,    Najava.Status,  Najava.Tezina, " +
      "   Najava.Duzina,    Najava.BrojKola, Najava.DatumUnosa " +
      "     FROM  Najava INNER JOIN Partnerji AS Partnerji_1 ON   " +
       "    Najava.Posiljalac = Partnerji_1.PaSifra   INNER JOIN Partnerji  " +
       "    ON Najava.Prevoznik = Partnerji.PaSifra     INNER JOIN Partnerji AS " +
       "    Partnerji_2 ON Najava.Primalac = Partnerji_2.PaSifra  INNER JOIN Partnerji " +
       "    AS Partnerji_3 ON Najava.PrevoznikZa = Partnerji_3.PaSifra  " +  
       "    INNER JOIN  stanice ON Najava.Uputna = stanice.ID  " + 
       "    INNER JOIN  stanice AS stanice_1 ON Najava.Otpravna = stanice_1.ID  " + 
       "    inner join Trase on Najava.Voz = Trase.ID  " + 
       "    inner JOIN  stanice AS stanice_4 ON Najava.Granicna = stanice_4.ID " +
       "     where Status in (1,2,3,4,5,6) " +             
       "      order by Najava.Granicna, Najava.ID, Najava.PredvidjenoPrimanje) t1  ) t2 " +
       "  where t2.kolona <31 ";

             //  "     where Status <> 7 or Faktura = ''   " +
               if (Broj > 30)
               {
                   tag = 2;
               }
               else
               {
                   tag = 1;
               }
           }
           else
           {
               select = " select * from (select *,  " +
       "  (ROW_NUMBER() OVER (ORDER BY t1.Granicna)) as kolona   from (SELECT  top 60  najava.ID,  stanice_4.opis as Granicna, " +
" Najava.BrojNajave , Trase.Voz, " +
"  Partnerji.PaNaziv AS Prevoznik, " +
 "  Partnerji_3.PaNaziv AS PrevoznikZa,  " +
 "   stanice_1.Opis AS Uputna, stanice.Opis AS Otpravna, " +
  "   Najava.PrevozniPut, Najava.PredvidjenoPrimanje, " +
   "   Najava.StvarnoPrimanje,  Najava.PredvidjenaPredaja, " +
    "   Najava.StvarnaPredaja,  CASE WHEN Najava.RID > 0 THEN Cast('R' as Char) " +
     "   ELSE Cast('' as CHAR) END as RID,    Najava.Status,  Najava.Tezina, " +
     "   Najava.Duzina,    Najava.BrojKola, Najava.DatumUnosa " +
     "     FROM  Najava INNER JOIN Partnerji AS Partnerji_1 ON   " +
      "    Najava.Posiljalac = Partnerji_1.PaSifra   INNER JOIN Partnerji  " +
      "    ON Najava.Prevoznik = Partnerji.PaSifra     INNER JOIN Partnerji AS " +
      "    Partnerji_2 ON Najava.Primalac = Partnerji_2.PaSifra  INNER JOIN Partnerji " +
      "    AS Partnerji_3 ON Najava.PrevoznikZa = Partnerji_3.PaSifra  " +
      "    INNER JOIN  stanice ON Najava.Uputna = stanice.ID  " +
      "    INNER JOIN  stanice AS stanice_1 ON Najava.Otpravna = stanice_1.ID  " +
      "    inner join Trase on Najava.Voz = Trase.ID  " +
      "    inner JOIN  stanice AS stanice_4 ON Najava.Granicna = stanice_4.ID " +
      "     where Status in (1,2,3,4,5,6) " +
      "      order by Najava.Granicna, Najava.ID, Najava.PredvidjenoPrimanje) t1  ) t2 " +
      "  where t2.kolona >30 ";

          //     "     where Status <> 7 or Faktura = ''   " +
               
              tag = 1;
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
            dataGridView1.Columns[1].HeaderText = "Granična / Otpravna";
            dataGridView1.Columns[1].Width = 120;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].Visible = false;
           // dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
           // dataGridView1.Columns[3].HeaderText = "Voz";
           // dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[3].Visible = false;


            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Preuzima od";
            dataGridView1.Columns[4].Width = 120;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Predaje za";
            dataGridView1.Columns[5].Width = 120;


            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Otpravna";
            dataGridView1.Columns[6].Width = 130;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Uputna";
            dataGridView1.Columns[7].Width = 130;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].Visible = false;

           

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "ETA";
            dataGridView1.Columns[9].Width = 150;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "ATA";
            dataGridView1.Columns[10].Width = 150;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "ETD";
            dataGridView1.Columns[11].Width = 150;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].Visible = false;
           // dataGridView1.Columns[12].HeaderText = "ATD";
          //  dataGridView1.Columns[12].Width = 120;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "RID";
            dataGridView1.Columns[13].Width = 20;


            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "";
            dataGridView1.Columns[14].Width = 0;
            dataGridView1.Columns[14].Visible = false;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Težina";
            dataGridView1.Columns[15].Width = 80;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Dužina";
            dataGridView1.Columns[16].Width = 80;

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Br kola";
            dataGridView1.Columns[17].Width = 50;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[19].Visible = false;
           // dataGridView1.Columns[18].HeaderText = "Zadnja promena";
          //  dataGridView1.Columns[18].Width = 120;
            
            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].Visible = false;
           // dataGridView1.Columns[18].Width = 100;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // string statusRid = row.Cells[11].Value.ToString();
                string StatusNajave = row.Cells[14].Value.ToString();
                if (StatusNajave == "1")
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                }
                else if ((StatusNajave == "2"))
                {
                    row.DefaultCellStyle.BackColor = Color.BlueViolet;
                    row.DefaultCellStyle.SelectionBackColor = Color.BlueViolet;
                }
                else if ((StatusNajave == "3"))
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                    row.DefaultCellStyle.SelectionBackColor = Color.Orange;
                }
                else if ((StatusNajave == "4"))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
                else if ((StatusNajave == "5"))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                }
                else if ((StatusNajave == "6"))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                }
                else if ((StatusNajave == "7"))
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                }
               
                else
                {
                    row.DefaultCellStyle.BackColor = Color.HotPink;
                    row.DefaultCellStyle.SelectionBackColor = Color.HotPink;
                }
            }

           

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                /*
                DateTime pom = Convert.ToDateTime(row.Cells[19].Value.ToString());
                TimeSpan span = DateTime.Now.Subtract(pom);
                double minuta = span.TotalMinutes;
                if (minuta < 15)
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                }
                 * */
            }
               dataGridView1.Refresh();
              
        }

        int mod(int a, int n)
        {
            int result = a % n;
            if ((result < 0 && n > 0) || (result > 0 && n < 0))
            {
                result += n;
            }
            return result;
        }
        
        private void Blink(object o)
        {
            int pomRefresh = 0;
            while (count < 100)
            {

                pomRefresh = pomRefresh + 1;
                if (pomRefresh == 10)
                {
                    pomRefresh = 0;
                    //Panta
                  



                    //End of panta
                   // RefreshDataGrid();
                }
                while (!go)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        DateTime pom = Convert.ToDateTime(row.Cells[18].Value.ToString());
                        TimeSpan span = DateTime.Now.Subtract(pom);
                        double minuta = span.TotalMinutes;
                        if (minuta < 15)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                    go = true;
                    System.Threading.Thread.Sleep(500);
                }

                while (go)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        DateTime pom = Convert.ToDateTime(row.Cells[18].Value.ToString());
                        TimeSpan span = DateTime.Now.Subtract(pom); // pom.Subtract(DateTime.Now);
                        double minuta = span.TotalMinutes;
                        if (minuta < 15)
                        {
                            row.DefaultCellStyle.BackColor = Color.Green;
                        }
                    }
                    go = false;
                    System.Threading.Thread.Sleep(500);
                }
               
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void RefreshDataGrid()
        {
           
            
        }
    }
}
