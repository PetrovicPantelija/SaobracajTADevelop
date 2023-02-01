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

namespace Saobracaj.Dokumenta
{
    public partial class frmIzracunZarada : Form
    {
        public frmIzracunZarada()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        string niz = "";
        public static string code = "frmIzracunZarada";
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
                       // tsNew.Enabled = false;
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
        private void dtpVremeDo_ValueChanged(object sender, EventArgs e)
        {

        }
        public void StornirajCelePN(int Zaposleni, int PNCeli, int PNPola, int PNCeliBrisanje, int PNPolaBrisanje)
        { 

            
             var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select top " + PNCeliBrisanje + "  PnStZapisa from PotNal " +
" where PnDelavec = " + Zaposleni + " and PnZnesOrg = 2349 and PnStatus = 'OD' " + 
" Order By PnStZapisa desc ", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                InsertObracunSati ins = new InsertObracunSati();
                ins.UpdPN(Convert.ToInt32(dr["PnZapisa"].ToString()));
               
            }

            con.Close();
        
        }

        private void PNZaBrisanje()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(s_connection);

                    con.Open();
                  
                    string Top1 = Convert.ToInt32(row.Cells[16].Value).ToString();
                    string Top2 = Convert.ToInt32(row.Cells[14].Value).ToString();
                    string Radnik = Convert.ToInt32(row.Cells[0].Value).ToString();
                    string sqlupit = " select Top " + Top1 + " t1.PnStZapisa as PnStZapisa, t1.Duration from ( "
 + "select top  " + Top2 + "  PnStZapisa,DATEDIFF(MINUTE,PnDatOdh, PnDatPrih) AS Duration from PotNal  where PnDelavec = " + Radnik + " and PnZnesOrg = 2425 and PnStatus = 'OD'  Order By PnStZapisa desc) t1 "
 + "order by t1.Duration asc ";

                    SqlCommand cmd = new SqlCommand(sqlupit, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        InsertObracunSati ins = new InsertObracunSati();
                        ins.UpdPN(Convert.ToInt32(dr["PnStZapisa"].ToString()));

                    }

                    con.Close();
                   // StornirajCelePN(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[14].Value.ToString()), Convert.ToInt32(row.Cells[15].Value.ToString()), Convert.ToInt32(row.Cells[16].Value.ToString()), Convert.ToInt32(row.Cells[17].Value.ToString()));
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }

        }

        private void PNZaBrisanjePola()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(s_connection);

                    con.Open();
                    string Top1 = Convert.ToInt32(row.Cells[17].Value).ToString();
                    string Top2 = Convert.ToInt32(row.Cells[15].Value).ToString();
                    string Radnik = Convert.ToInt32(row.Cells[0].Value).ToString();
                    SqlCommand cmd = new SqlCommand(" select Top " + Top1 + " t1.PnStZapisa as PnStZapisa, t1.Duration from ( "
+ "select top  " + Top2 + "  PnStZapisa,DATEDIFF(MINUTE,PnDatOdh, PnDatPrih) AS 'Duration' from PotNal  where PnDelavec = " + Radnik + " and PnZnesOrg = 1212.5 and PnStatus = 'OD'  Order By PnStZapisa desc) t1 "
+ "order by t1.Duration asc ", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        InsertObracunSati ins = new InsertObracunSati();
                        ins.UpdPN(Convert.ToInt32(dr["PnStZapisa"].ToString()));

                    }

                    con.Close();
                    // StornirajCelePN(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[14].Value.ToString()), Convert.ToInt32(row.Cells[15].Value.ToString()), Convert.ToInt32(row.Cells[16].Value.ToString()), Convert.ToInt32(row.Cells[17].Value.ToString()));
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }

        }

        private void RefreshDataGrid()
        {
            if (txtPassword.Text != "iv4321")
            {
                return;

            }
            var select = "";

            select = " SELECT [ID] ,[Zaposleni],[VanLokomotive],[Lokomotiva] " +
      " ,[Milsped]   ,[Ukupno1] ,[Ciljna] ,[Osnovna],[Kazna],[UkupnoDIN],PrimaMinimalac, KaznaMinimalac, KaznaUkupno,[PutniNalozi],[PutniNaloziBroj], PutniNaloziBrojPola, " +
      " PutniNaloziBrisanjeCeli,PutniNaloziBrisanjePola, Dodatak, [MinusPutni] ,[MinusPutniOsnovna] from ObracunZaposleni";

            /*
       SELECT [ID]
      ,[VanLokomotive]
      ,[Lokomotiva]
      ,[Milsped]
      ,[Zaposleni]
      ,[PutniNalozi]
      ,[PutniNaloziBroj]
      ,[Ukupno1]
      ,[Ciljna]
      ,[Osnovna]
       ,[Kazna]
      ,[UkupnoDIN]
      ,[MinusPutni]
      ,[MinusPutniOsnovna]
      FROM [TESTIRANJE].[dbo].[ObracunZaposleni]
             */

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            /*
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
        */
        
        
        
        }

        private void btnIzracunaj_Click(object sender, EventArgs e)
        {
            InsertObracunSati ins = new InsertObracunSati();

            ins.DelObracun();
            ins.InsObracun(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ins.UpdLokomotiva(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ins.UpdMilsped(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ins.UpdKragujevac(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ins.UpdRemont(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ins.UpdSmederevo(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ins.UpdINO(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            
            ins.UpdPutniNalozi(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ins.UpdUkupno1(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ins.UpdUkupno(Convert.ToDouble(txtKurs.Value));
           // ins.UpdUkupnoMinimalac(Convert.ToDouble(txtMinimalac.Value));
            RefreshDataGrid();
            MessageBox.Show("Gotovo, to ti je završeno");
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        InsertObracunSati ins = new InsertObracunSati();
                        ins.UpdUkupnoUEUR(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToDouble(txtZarada.Value));
                        RefreshDataGrid();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        InsertObracunSati ins = new InsertObracunSati();
                        ins.UpdUkupnoSmanjenje(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToDouble(txtSmanjenje.Value));
                        RefreshDataGrid();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertObracunSati ins = new InsertObracunSati();
            ins.UpdUkupnoMinimalac(Convert.ToDouble(txtMinimalac.Value));
            RefreshDataGrid();
            MessageBox.Show("Gotovo");
        }

        private void frmIzracunZarada_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InsertObracunSati ins = new InsertObracunSati();

           
            ins.UpdPutniNalozi(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ins.UpdPutniNaloziPola(Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
           
            RefreshDataGrid();
            MessageBox.Show("Gotovo");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InsertObracunSati ins = new InsertObracunSati();
            RefreshDataGrid();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           ///PPPP2
            
            PNZaBrisanje();
            PNZaBrisanjePola();
            MessageBox.Show("Gotovo");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //PPP
            InsertObracunSati ins = new InsertObracunSati();
            ins.SelectPNBrisanje();
            ins.SelectPNBrisanje2();
            ins.SelectPNBrisanje3();
            ins.SelectPNBrisanje4();
            ins.SelectPNBrisanje5();
           // ins.Select5();
            RefreshDataGrid();
            MessageBox.Show("Gotovo");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            InsertObracunSati ins = new InsertObracunSati();
            ins.UpdUkupnoMinimalac(Convert.ToDouble(txtMinimalac.Value));
            RefreshDataGrid();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InsertObracunSati ins = new InsertObracunSati();
            ins.UpdKazna();
            RefreshDataGrid();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            InsertObracunSati ins = new InsertObracunSati();
            ins.UpdZakljucavanjeSmene(Convert.ToDateTime(dtpZakljucavanjeSmene.Value));
            MessageBox.Show("Zaključano na zadati datum"); 
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
