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

namespace TrackModal.Dokumeta
{
    public partial class frmPrijemKontejneraKamionom : Form
    {

        MailMessage mailMessage;
        string KorisnikCene;
        bool status = false;
        public frmPrijemKontejneraKamionom()
        {
            InitializeComponent();
        }

        public frmPrijemKontejneraKamionom(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
            RefreshDataGrid();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertPrijemKontejnera ins = new InsertPrijemKontejnera();
                ins.InsertPrijemKont(Convert.ToDateTime(dtpDatumPrijema.Text), Convert.ToInt32(cboStatusPrijema.SelectedIndex), txtBrojKontejnera.Text, txtRegBrKamiona.Text, txtImeVozaca.Text, Convert.ToInt32(cboPosiljalac.SelectedValue), Convert.ToInt32(cboPrimalac.SelectedValue), Convert.ToInt32(cboVlasnikKontejnera.SelectedValue), Convert.ToInt32(cboTipKontejnera.SelectedValue), Convert.ToInt32(cboVrstaRobe.SelectedValue), Convert.ToInt32(cboBuking.SelectedValue), Convert.ToInt32(cboStatusKontejnera.SelectedValue), txtBrojPlombe.Text, Convert.ToInt32(txtPlaniraniLager.Text), Convert.ToInt32(cboBukingOtpreme.SelectedValue), Convert.ToDateTime(dtpVremeDolaska.Value), Convert.ToDateTime(dtpDatumPrijema.Value), Convert.ToDateTime(dtpVremeOdlaska.Value), Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToDouble(txtTara.Text), Convert.ToDouble(txtNeto.Text), txtBrojPlombe2.Text, Convert.ToInt32(cboOrganizator.SelectedValue));
                status = false;
            }
            else
            {
                //int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik
                InsertPrijemKontejnera upd = new InsertPrijemKontejnera();
                upd.UpdPrijemKontejnera(Convert.ToInt32(txtSifra.Text), Convert.ToDateTime(dtpDatumPrijema.Text), Convert.ToInt32(cboStatusPrijema.SelectedValue), txtBrojKontejnera.Text, txtRegBrKamiona.Text, txtImeVozaca.Text, Convert.ToInt32(cboPosiljalac.SelectedValue), Convert.ToInt32(cboPrimalac.SelectedValue), Convert.ToInt32(cboVlasnikKontejnera.SelectedValue), Convert.ToInt32(cboTipKontejnera.SelectedValue), Convert.ToInt32(cboVrstaRobe.SelectedValue), Convert.ToInt32(cboBuking.SelectedValue), Convert.ToInt32(cboStatusKontejnera.SelectedValue), txtBrojPlombe.Text, Convert.ToInt32(txtPlaniraniLager.Text), Convert.ToInt32(cboBukingOtpreme.SelectedValue), Convert.ToDateTime(dtpVremeDolaska.Value), Convert.ToDateTime(dtpDatumPrijema.Value), Convert.ToDateTime(dtpVremeOdlaska.Value), Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToDouble(txtTara.Text), Convert.ToDouble(txtNeto.Text), txtBrojPlombe2.Text, Convert.ToInt32(cboOrganizator.SelectedValue));
                status = false;
            }
            RefreshDataGrid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertPrijemKontejnera upd = new InsertPrijemKontejnera();
                upd.DeletePrijemKontejnera(Convert.ToInt32(txtSifra.Text));
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
        }

        private void ProveraKontrolnogBroja()
        {
            string KontrolniBroj = txtBrojKontejnera.Text.TrimEnd();
            string CheckDigit = "100";
            CheckDigit = KontrolniBroj.Substring(KontrolniBroj.Length - 1, 1);
            /*
            string A = "10"; string B = "11"; string C = "12"; string D = "13"; string E = "14"; string F = "15";
            string G = "16"; string H = "17"; string I = "18"; string J = "19"; string K = "20"; string L = "21";
            string M = "22"; string N = "23"; string O = "24"; string P = "25"; string Q = "26"; string R = "27";
            string S = "28"; string T= "29"; string U = "30"; string V = "31"; string W = "32"; string X = "33";
            string Y = "34"; string Z = "35";
            */
            string foo = KontrolniBroj.ToUpper(); 
            int ukupno = 0;
            int korak = 1;
            foreach (char c in foo)
            {
                switch (c)
                {
                    case 'A':
                        // Some code here
                        ukupno = ukupno + korak * 10;
                        korak = korak * 2;
                        break; // break that closes the case

                    case 'B':
                        ukupno = ukupno + korak * 12;
                        korak = korak * 2;
                        break; // break that closes the case
                    case 'C':
                        ukupno = ukupno + korak * 13;
                        korak = korak * 2;
                        break; // 
                    case 'D':
                        ukupno = ukupno + korak * 14;
                        korak = korak * 2;
                        break; // 
                    case 'E':
                        ukupno = ukupno + korak * 15;
                        korak = korak * 2;
                        break; // 
                    case 'F':
                        ukupno = ukupno + korak * 16;
                        korak = korak * 2;
                        break; // 
                    case 'G':
                        ukupno = ukupno + korak * 17;
                        korak = korak * 2;
                        break; // 
                    case 'H':
                        ukupno = ukupno + korak * 18;
                        korak = korak * 2;
                        break; // 
                    case 'I':
                        ukupno = ukupno + korak * 19;
                        korak = korak * 2;
                        break; // 
                    case 'J':
                        ukupno = ukupno + korak * 20;
                        korak = korak * 2;
                        break; // 
                    case 'K':
                        ukupno = ukupno + korak * 21;
                        korak = korak * 2;
                        break; // 
                    case 'L':
                        ukupno = ukupno + korak * 23;
                        korak = korak * 2;
                        break; // 
                    case 'M':
                        ukupno = ukupno + korak * 24;
                        korak = korak * 2;
                        break; // 
                    case 'N':
                        ukupno = ukupno + korak * 25;
                        korak = korak * 2;
                        break; // 
                    case 'O':
                        ukupno = ukupno + korak * 26;
                        korak = korak * 2;
                        break; // 
                    case 'P':
                        ukupno = ukupno + korak * 27;
                        korak = korak * 2;
                        break; // 
                    case 'Q':
                        ukupno = ukupno + korak * 28;
                        korak = korak * 2;
                        break; // 
                    case 'R':
                        ukupno = ukupno + korak * 29;
                        korak = korak * 2;
                        break; // 
                    case 'S':
                        ukupno = ukupno + korak * 30;
                        korak = korak * 2;
                        break; // 
                    case 'T':
                        ukupno = ukupno + korak * 31;
                        korak = korak * 2;
                        break; // 
                    case 'U':
                        ukupno = ukupno + korak * 32;
                        korak = korak * 2;
                        break; // 
                    case 'V':
                        ukupno = ukupno + korak * 34;
                        korak = korak * 2;
                        break; // 
                    case 'W':
                        ukupno = ukupno + korak * 35;
                        korak = korak * 2;
                        break; // 
                    case 'X':
                        ukupno = ukupno + korak * 36;
                        korak = korak * 2;
                        break; // 
                    case 'Y':
                        ukupno = ukupno + korak * 37;
                        korak = korak * 2;
                        break; // 
                    case 'Z':
                        ukupno = ukupno + korak * 38;
                        korak = korak * 2;
                        break; // 
                    
                    default:
                        {
                            ukupno = ukupno + Convert.ToInt32(c) * korak;
                            korak = korak * 2;
                            break;
                        }
                }

              

               
            }
            int pomUkupno = ukupno / 11;
            pomUkupno = pomUkupno * 11;

            int ProveraJed = ukupno - pomUkupno;
            if (ProveraJed.ToString() == CheckDigit)
            {
               // MessageBox.Show("Ispravan kontrolni broj");
            }
            else
            {
                MessageBox.Show("Pogrešan kontrolni broj");
            }

        }    

        private void RefreshDataGrid()
        {

            var select = "  SELECT [ID],[DatumPrijema],[StatusPrijema],[BrojKontejnera],[RegBrKamiona] ,[ImeVozaca],[Posiljalac],[Primalac],[VlasnikKontejnera],[TipKontejnera],[VrstaRobe] ,[Buking],[StatusKontejnera],[BrojPlombe],[PlaniraniLager],[IdVoza],[VremeDolaska],[VremePripremljen],[VremeOdlaska],[Datum],[Korisnik]  FROM [dbo].[PrijemKontejnera]";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Datum prijema";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Status prijema";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Registarski broj";
            dataGridView1.Columns[4].Width = 100;


            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Ime vozača";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Pošiljalac";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Primalac";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Vlasnik kontejnera";
            dataGridView1.Columns[8].Width = 100;

           

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "TipKontejnera";
            dataGridView1.Columns[9].Width = 100;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Vrsta Robe";
            dataGridView1.Columns[10].Width = 100;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Buking";
            dataGridView1.Columns[11].Width = 100;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Status kontejnera";
            dataGridView1.Columns[12].Width = 100;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Broj plombe";
            dataGridView1.Columns[13].Width = 100;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Planirani Lager";
            dataGridView1.Columns[14].Width = 100;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Voz";
            dataGridView1.Columns[15].Width = 100;

             DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Vreme dolaska";
            dataGridView1.Columns[16].Width = 100;

             DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Vreme pripremljen";
            dataGridView1.Columns[17].Width = 100;

             DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Vreme odlaska";
            dataGridView1.Columns[18].Width = 100;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Datum unosa";
            dataGridView1.Columns[19].Width = 100;

            DataGridViewColumn column21 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Korisnik";
            dataGridView1.Columns[20].Width = 100;
        }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID],[DatumPrijema],[StatusPrijema],[BrojKontejnera],[RegBrKamiona] ,[ImeVozaca],[Posiljalac],[Primalac],[VlasnikKontejnera],[TipKontejnera],[VrstaRobe] ,[Buking],[StatusKontejnera],[BrojPlombe],[PlaniraniLager],[IdVoza],[VremeDolaska],[VremePripremljen],[VremeOdlaska],[Datum],[Korisnik]  FROM [dbo].[PrijemKontejnera] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cboBukingOtpreme.SelectedValue = Convert.ToInt32(dr["Voz"].ToString());
                txtPlaniraniLager.Text = dr["PlaniraniLager"].ToString();
                txtBrojPlombe.Text = dr["BrojPlombe"].ToString();
                cboStatusKontejnera.SelectedValue = Convert.ToInt32(dr["StatusKontejnera"].ToString());
                cboBuking.SelectedValue = Convert.ToInt32(dr["Buking"].ToString());
                cboVrstaRobe.SelectedValue = Convert.ToInt32(dr["VrstaRobe"].ToString());
                cboTipKontejnera.SelectedValue = Convert.ToInt32(dr["TipKontejnera"].ToString());
                cboVlasnikKontejnera.SelectedValue = Convert.ToInt32(dr["VlasnikKontejnera"].ToString());
                cboPrimalac.SelectedValue = Convert.ToInt32(dr["Primalac"].ToString());
                cboPosiljalac.SelectedValue = Convert.ToInt32(dr["Posiljalac"].ToString());
              
                txtImeVozaca.Text = dr["ImeVozaca"].ToString();
                txtRegBrKamiona.Text = dr["RegBrKamiona"].ToString();
                txtBrojKontejnera.Text = dr["BrojKontejnera"].ToString();
                dtpDatumPrijema.Value = Convert.ToDateTime(dr["DatumPrijema"].ToString());
                dtpVremeDolaska.Value = Convert.ToDateTime(dr["VremeDolaska"].ToString());
                dtpVremePripremljen.Value = Convert.ToDateTime(dr["VremePripremljen"].ToString());
                dtpVremeOdlaska.Value = Convert.ToDateTime(dr["VremeOdlaska"].ToString());
                
                // Convert.ToInt32(cboTipCenovnika.SelectedValue), Convert.ToInt32(cboKomitent.SelectedValue), Convert.ToDouble(txtCena.Text), Convert.ToInt32(cboVrstaManipulacije.SelectedValue), Convert.ToDateTime(DateTime.Now), KorisnikCene
                cboStatusPrijema.SelectedValue = Convert.ToInt32(dr["StatusVoza"].ToString());
          
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBrojKontejnera_Leave(object sender, EventArgs e)
        {
            ProveraKontrolnogBroja();
        }

        private void PosaljiMailOdjavaDisp(string Kome)
        {
            try
            {
                string zadnjibroj = txtSifra.Text;
                //drugi je kome
                mailMessage = new MailMessage("logistika@zitbgd.rs", "panta0307@yahoo.com");

                mailMessage.Subject = "Prijem kamionom : " + zadnjibroj + " . ";

                var select = " SELECT [ID],[DatumPrijema],[StatusPrijema] "
                  + " ,[BrojKontejnera] ,[RegBrKamiona] ,[Tara] " 
                  + ",[Neto],[ImeVozaca],[Posiljalac] " 
                  + ",[Primalac],[VlasnikKontejnera] ,[TipKontejnera] ,[VrstaRobe] " 
                  + ",[Buking] ,[StatusKontejnera],[BrojPlombe] ,[PlaniraniLager] "
                  + ",[IdVoza] ,[VremeDolaska] ,[VremePripremljen],[VremeOdlaska] " 
                  + " FROM [dbo].[PrijemKontejnera] where ID =  " + Convert.ToInt32(txtSifra.Text);

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                string body = "Poštovani, :  <br />";

                body = body + "Ovo je testni majl koji treba da se šalje  <br /> <br /> <br />";
                body = body + "Proverite tačnost i oblik maila !!!!!! <br />";
                foreach (DataRow myRow in ds.Tables[0].Rows)
                {

                    body = body + "Broj kontejnera: " + myRow["BrojKontejnera"].ToString() + "<br />";
                    body = body + "Status Prijema: " + myRow["StatusPrijema"].ToString() + "<br />";
                    body = body + "Datum Prijema: " + myRow["DatumPrijema"].ToString() + "<br />";
                    body = body + "Reg Br Kamiona: " + myRow["RegBrKamiona"].ToString() + "<br />";
                    body = body + "Ime vozača: " + myRow["ImeVozaca"].ToString() + "<br />";
                    body = body + "Tara: " + myRow["Tara"].ToString() + "<br />";
                    body = body + "Neto: " + myRow["Neto"].ToString() + "<br />";
                   
                    body = body + "S poštovanjem" + "<br />";
                    body = body + "RTC LUKA LEGET" + "<br />" + "<br />" + "<br />";
                   

                }

                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "mail.zitbgd.rs";

                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("logistika@zitbgd.rs", "zit2019log");

                smtpClient.EnableSsl = false;
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnPosaljiMail_Click(object sender, EventArgs e)
        {
            PosaljiMailOdjavaDisp("");
        }

        private void frmPrijemKontejneraKamionom_Load(object sender, EventArgs e)
        {
            var select = " Select Distinct ID, NKM  From VrstaRobe";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboVrstaRobe.DataSource = ds.Tables[0];
            cboVrstaRobe.DisplayMember = "NKM";
            cboVrstaRobe.ValueMember = "ID";


            var select1 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection1 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection1 = new SqlConnection(s_connection1);
            var c1 = new SqlConnection(s_connection1);
            var dataAdapter1 = new SqlDataAdapter(select1, c1);

            var commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            var ds1 = new DataSet();
            dataAdapter1.Fill(ds1);
            cboPosiljalac.DataSource = ds1.Tables[0];
            cboPosiljalac.DisplayMember = "Naziv";
            cboPosiljalac.ValueMember = "ID";

            var select2 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboPrimalac.DataSource = ds2.Tables[0];
            cboPrimalac.DisplayMember = "Naziv";
            cboPrimalac.ValueMember = "ID";

            var select3 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboVlasnikKontejnera.DataSource = ds3.Tables[0];
            cboVlasnikKontejnera.DisplayMember = "Naziv";
            cboVlasnikKontejnera.ValueMember = "ID";


            var select4 = " Select Distinct ID, Naziv From TipKontenjera order by Naziv";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboTipKontejnera.DataSource = ds4.Tables[0];
            cboTipKontejnera.DisplayMember = "Naziv";
            cboTipKontejnera.ValueMember = "ID";

            var select5 = " Select Distinct ID, IdVoza From BukingVoza ";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboBuking.DataSource = ds5.Tables[0];
            cboBuking.DisplayMember = "IdVoza";
            cboBuking.ValueMember = "ID";

            var select6 = " Select Distinct ID, Naziv From StatusRobe ";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboStatusKontejnera.DataSource = ds6.Tables[0];
            cboStatusKontejnera.DisplayMember = "Naziv";
            cboStatusKontejnera.ValueMember = "ID";

            var select7 = " Select Distinct ID, IdVoza From BukingVoza ";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboBukingOtpreme.DataSource = ds7.Tables[0];
            cboBukingOtpreme.DisplayMember = "IdVoza";
            cboBukingOtpreme.ValueMember = "ID";
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            frmDokumentaPrijemKontejneraKamion dpkk = new frmDokumentaPrijemKontejneraKamion(txtSifra.Text, KorisnikCene);
            dpkk.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboBukingOtpreme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsNazad_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}

