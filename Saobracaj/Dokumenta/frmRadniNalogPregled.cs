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
    public partial class frmRadniNalogPregled : Form
    {
        public static string code = "frmRadniNalogPregled";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        MailMessage mailMessage;
        public frmRadniNalogPregled()
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
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void RefreshDataGrid1()
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
"   inner Join Delavci del on (RadniNalogTraseLokZap.DeSifra = del.DeSifra) "+
"   where RadniNalogTraseLokZap.IDRadnogNaloga = d1.IDRadnogNaloga "+
"   and  RadniNalogTraseLokZap.IdTrase = d1.IDTrase " +
"   FOR XML PATH('')   ), 1, 1, ''  ) As Skupljen2) " +
"   as Zaposleni2, " +  
" d1.DatumPolaska ,d1.DatumDolaska , " +
" d1.Vreme ,d1.DatumPolaskaReal , " +
" d1.DatumDolaskaReal ,d1.VremeReal , " +
" stanice.Opis AS TRPocetna ,stanice_1.Opis AS TRKrajnja,  Trase.Relacija " +
" FROM RadniNalogTrase d1 INNER JOIN  Trase " +
" ON d1.IDTrase = Trase.ID " +
" INNER JOIN  stanice ON Trase.Pocetna = stanice.ID " +
" INNER JOIN  stanice AS stanice_2 ON d1.StanicaOd = stanice_2.ID " +
" INNER JOIN  stanice AS stanice_3 ON d1.StanicaDo = stanice_3.ID " +
" INNER JOIN  stanice AS stanice_1 ON Trase.Krajnja = stanice_1.ID " +
" inner Join RadniNalog as RN ON d1.IDRadnogNaloga = RN.ID " +
" inner Join Delavci as Zaposleni ON RN.Planer = Zaposleni.DeSifra ";


            if (chkLA.Checked == true)
            {
                pom = pom + ",'RA'";
            }
            if (chkOD.Checked == true)
            {
                pom = pom + ",'OD'";
            }

            if (chkPL.Checked == true)
            {
                pom = pom + ",'PL'";
            }

            if (chkPR.Checked == true)
            {
                pom = pom + ",'PR'";
            }

            if (chkST.Checked == true)
            {
                pom = pom + ",'ST'";
            }
            if (chkZA.Checked == true)
            {
                pom = pom + ",'ZA'";
            }

            select = select + "where RN.StatusRN in ( " + pom + ")" + " order by IDRadnogNaloga, d1.RB ";;


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
            dataGridView1.Columns[0].HeaderText = "RN";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].Visible = false;
          //  dataGridView1.Columns[2].HeaderText = "ID Trase";
          //  dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Trase";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "St";
            dataGridView1.Columns[4].Width = 30;

            //Rezi

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Rezi";
            dataGridView1.Columns[5].Width = 30;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Stanica od";
            dataGridView1.Columns[6].Width = 90;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Stanica do";
            dataGridView1.Columns[7].Width = 90;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Planer";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Lokomotive";
            dataGridView1.Columns[9].Width = 120;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Osoblje";
            dataGridView1.Columns[10].Width = 220;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Pl polazak";
            dataGridView1.Columns[11].Width = 90;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Pl Dolazak";
            dataGridView1.Columns[12].Width = 90;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Pl vreme";
            dataGridView1.Columns[13].Width = 40;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Rel. polazak";
            dataGridView1.Columns[14].Width = 90;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Rel dolazak";
            dataGridView1.Columns[15].Width = 90;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Real vreme";
            dataGridView1.Columns[16].Width = 40;

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Tr Stanica od";
            dataGridView1.Columns[17].Width = 90;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Tr Stanica do";
            dataGridView1.Columns[18].Width = 90;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Trasa relacija";
            dataGridView1.Columns[19].Width = 150;

        }

        private void frmRadniNalogPregled_Load(object sender, EventArgs e)
        {
            RefreshDataGrid1();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            frmRadniNalog ter = new frmRadniNalog(txtSifra.Text);
            ter.Show();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void chkPR_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void chkLA_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void chkOD_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void chkPL_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void chkST_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void chkZA_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmRadniNalog ter = new frmRadniNalog();
            ter.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
             try
            {
                string zadnjibroj = txtSifra.Text;

                mailMessage = new MailMessage("disp@kprevoz.co.rs", "panta0307@yahoo.com");

                mailMessage.Subject = "Najava infrastruktiri automatski generisan primer sve planirano";

                var select = " select d1.IDRadnogNaloga, d1.RB, Trase.Voz as Trasa , d1.statustrase as StatusTrase, DatumPolaskaReal as PlaniranOd, DatumDolaskaReal as PlaniranDo, " +
                " stanice.Opis as StanicaOd ,Stanice1.Opis as StanicaDo,  d1.Rezi, "+
                " (  SELECT  STUFF(  (  SELECT distinct   '/' + Cast(SmSifra as nvarchar(8)) " +
                "  FROM RadniNalogLokNaTrasi " +
                " where RadniNalogLokNaTrasi.IDRadnogNaloga = d1.IDRadnogNaloga and  RadniNalogLokNaTrasi.IdTrase = d1.IDTrase " + 
                "  FOR XML PATH('')   ), 1, 1, '' " +
                " ) As Skupljen) as Lokom, " +
                " Napomena from RadniNalogTrase d1 " +
                " inner join Trase on Trase.ID = d1.IDTrase " +
                " inner join stanice on Stanice.ID = d1.StanicaOd " + 
                " inner join stanice as Stanice1 on Stanice1.ID = d1.StanicaDo " +
                " where DatumDolaska = '1900-01-01 00:00:00.000' and d1.Poslato = 0";

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                 string body = "SAOBRAĆA:  <br />";

                 body = body + "Ovo je testni majl koji treba da se šalje infrastrukturi nakon planiranja mail je generisan iz Larga nije ograničen na 12 sati<br /> <br /> <br />";
                 body = body + "Proverite tačnost i oblik maila !!!!!! <br />";
                 body = body + "PLANIRANI PREVOZI" + "<br /> " + "<br />" + "  <br />";
                
                 foreach (DataRow myRow in ds.Tables[0].Rows)
                {
                    body = body + "Trasa: " + myRow["Trasa"].ToString() + " " + myRow["StanicaOd"].ToString() + "-" + myRow["StanicaDo"].ToString() + "<br /> ";
                    if (myRow["StatusTrase"].ToString() == "2")
                    {
                        body = body  + "<br />";
                        body = body + "OTKAZAN !!! " + "<br />";
                        //Ovde treba update
                    }
                    else if (myRow["StatusTrase"].ToString() == "3")
                    {
                        body = body + "<br />";
                        body = body + "IZMENA !!!";
                        body = body + "Vreme od: " + myRow["PlaniranOd"].ToString() + " ";
                        body = body + "Vreme do: " + myRow["PlaniranDo"].ToString() + "<br />";
                        if (myRow["Rezi"].ToString() == "1")
                            body = body + "Reži" + "<br />";

                        body = body + "LOK: " + myRow["Lokom"].ToString() + "<br />";
                        body = body + " " + myRow["Napomena"].ToString() + "<br /> + <br />";
                    }
                    else
                    {
                        body = body + "Vreme od: " + myRow["PlaniranOd"].ToString() + " ";
                        body = body + "Vreme do: " + myRow["PlaniranDo"].ToString() + "<br />";
                        if (myRow["Rezi"].ToString() == "1")
                            body = body + "Reži" + "<br />";

                        body = body + "LOK: " + myRow["Lokom"].ToString() + "<br />";
                        body = body + " " + myRow["Napomena"].ToString() + "<br />  <br />";
                    }
                    InsertRadniNalogTrase upd = new InsertRadniNalogTrase();
                    upd.UpdRNTStatusIzMaila(Convert.ToInt32(myRow["IDRadnogNaloga"].ToString()), Convert.ToInt32(myRow["RB"].ToString()));

                }

                body = body + "S poštovanjem" + "<br />";
                body = body + "Dispičerska služba RTC LUKA LEGET" + "<br />" + "<br />" + "<br />";

                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "mail.kprevoz.co.rs";
               
                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("pantelija.petrovic@kprevoz.co.rs", "pele1616");

                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        }
    }

