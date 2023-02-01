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
    public partial class frmMUPDozvola : Form
    {
        public static string code = "frmMUPDozvola";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";

        MailMessage mailMessage;
        Boolean status = false;
        public frmMUPDozvola()
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
                        tsNew.Enabled = false;
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
        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            dtpVremeOd.Value = DateTime.Now;
            dtpVremeDo.Value = DateTime.Now;
            txtRelacija.Text = "";
          
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from MUPDozvola", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertMUPDozvola ins = new InsertMUPDozvola();
            ins.InsMUPDozvola(Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, txtJMBG.Text, txtRadnoMesto.Text, txtRelacija.Text, cboLokacija.Text,txtAdresa.Text,Convert.ToInt32(cboAutomobili.SelectedValue));
            status = false;
            prikazisvedozvole();
            VratiPodatkeMax();
            
        }

        private void frmMUPDozvola_Load(object sender, EventArgs e)
        {
            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboZaposleni.DataSource = ds3.Tables[0];
            cboZaposleni.DisplayMember = "Opis";
            cboZaposleni.ValueMember = "ID";

            prikazisvedozvole();
        }

        private void prikazisvedozvole()
        {
            var select = "";

        
            select = " select top 100 MUPDozvola.ID,  MUPDozvola.Zaposleni, (RTRIM(Delavci.DePriimek) + ' ' + RTrim(Delavci.DeIme)) as ImeIPrezime, Delavci.DeEMail as Email,  MUPDozvola.VremeOd, MUPDozvola.VremeDo, MUPDozvola.JMBG, MUPDozvola.RadnoMesto, MUPDozvola.Relacija  from MupDozvola " +
 " inner join Delavci on Delavci.DeSifra = MUPDozvola.Zaposleni order by MUPDozvola.ID desc";

     
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
            dataGridView1.Columns[2].HeaderText = "Zaposleni";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Vreme od";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme do";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Ukupno";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupni troškovi";
            dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Opis";
            dataGridView1.Columns[7].Width = 120;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "RN";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Poslat Email";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Plaćeno";
            dataGridView1.Columns[10].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Računi";
            dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Kartice";
            dataGridView1.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Masinovodja";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Mesto";
            dataGridView1.Columns[14].Width = 100;

            DataGridViewColumn column15 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Pregledano računi";
            dataGridView1.Columns[15].Width = 50;

            DataGridViewColumn column16 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Pregledano kartice";
            dataGridView1.Columns[16].Width = 50;

            DataGridViewColumn column17 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Milšped";
            dataGridView1.Columns[17].Width = 50;

            DataGridViewColumn column18 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Zapisa";
            dataGridView1.Columns[18].Width = 50;
             * */
        
        }

        private void cboZaposleni_Leave(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

          


            SqlCommand cmd = new SqlCommand("  select  DeEMSO as JMBG,  DelovnaMesta.DmNaziv as RadnoMesto, DeEmail as Email   from Delavci " + 
            " inner join DelovnaMesta on DelovnaMesta.DmSifra = Delavci.DeSifDelMes " +
            " where  DeSifStat = 'A' and DeSifra =" + Convert.ToInt32(cboZaposleni.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtEmail.Text = dr["Email"].ToString();
                txtJMBG.Text = dr["JMBG"].ToString();
                txtRadnoMesto.Text = dr["RadnoMesto"].ToString();
               // txtJMBG.Text = dr["JMBG"].ToString();
            }

            con.Close();

            cboAutomobili.Text = "";
            var select3 = " select ID, (Rtrim(RegBr) + ' ' + RTrim(Marka)) as Opis from Automobili where Sluzbeni = 0 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) + " order by opis";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboAutomobili.DataSource = ds3.Tables[0];
            cboAutomobili.DisplayMember = "Opis";
            cboAutomobili.ValueMember = "ID";

            chkSluzbeni.Checked = false;
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
           

            TESTIRANJEDataSet11TableAdapters.SelectMUPDozvolaTableAdapter ta = new TESTIRANJEDataSet11TableAdapters.SelectMUPDozvolaTableAdapter();
            TESTIRANJEDataSet11.SelectMUPDozvolaDataTable dt = new TESTIRANJEDataSet11.SelectMUPDozvolaDataTable();

            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet2";
            rds.Value = dt;
            DateTime dtStartDate = dtpVremeOd.Value;
            DateTime dtEndDate = dtpVremeDo.Value;

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text.ToString());
          

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptMUPDozvola.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
             
        }

        private void btnPosaljiMail_Click(object sender, EventArgs e)
        {
            try
            {
                string zadnjibroj = txtSifra.Text;

                string mail = txtEmail.Text.TrimEnd();

                mailMessage = new MailMessage("zaposleni@kprevoz.co.rs", mail);

                mailMessage.Subject = "Uneti podaci za smenu ";

                var select = "select top 100 MUPDozvola.ID,  MUPDozvola.Zaposleni, " +
                    " (RTRIM(Delavci.DePriimek) + ' ' + RTrim(Delavci.DeIme)) as ImeIPrezime, Delavci.DeEMail as Email,  MUPDozvola.VremeOd, MUPDozvola.VremeDo, MUPDozvola.JMBG, MUPDozvola.RadnoMesto, MUPDozvola.Relacija  from MupDozvola  inner join Delavci on Delavci.DeSifra = MUPDozvola.Zaposleni " +
                " where ID = " + Convert.ToInt32(txtSifra.Text);

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                string body = " Nalog o obavljanju radnih zadataka i poslova u periodu od 20:00 h do 05:00 h " + "<br /> <br />";
                body = body + "Ovim putem privredno društvo KOMBINOVANI PREVOZ d.o.o Prokuplje, sa registrovanim sedištem" + "<br /> ";;
                body = body + "na adresi: Milena Jovanovića 15, 18400 Prokuplje, u svojstvu Poslodavca, izdaje Nalog zaposlenom:   " + "<br /> ";

                foreach (DataRow myRow in ds.Tables[0].Rows)
                {
                    body = body + myRow["ImeIPrezime"].ToString() + ", JMBG:  " + myRow["JMBG"].ToString() + " o obavljanju poslova i radnih zadataka na radnom mestu: " + "<br /> ";
                    body = body +  myRow["RadnoMesto"].ToString() + " a prema utvrđenom rasporedu u periodu od 20:00 h do 05:00 h u dane  " + myRow["VremeOd"].ToString() +  "<br /> ";
                    body = body +  "na relaciji - u stanici:  "  + myRow["Relacija"].ToString() +  "<br /> ";
                }
                body = body + "Ovaj nalog se izdaje u svrhu dokazivanja nadležnim organima Republike Srbije da predmetni zaposleni " + "<br /> ";
                body = body + "Oobavlja poslove i radne zadatke u periodu od 20:00 h do 05:00 h za privredno društvo KOMBINOVANI  " + "<br /> ";
                body = body + "PREVOZ d.o.o. Prokuplje, kao Poslodavca, a sve s obzirom na novouvedene mere Vlade Republike Srbije  " + "<br /> ";
                body = body + "o zabrani kretanja za sva lica u gore pomenutom periodu. " + "<br /> ";
                body = body + " " + "<br /> <br />";
                body = body + "KONTAKTI:" + "<br /> <br />";
                body = body + "DEŽURNI DISPEČER: " + "<br /> ";
                body = body + "062/572-017" + "<br /> <br />";
                body = body + "Ivan Petković, zam.gen.dir." + "<br /> ";
                body = body + "063/478-534 " + "<br /> <br />";
                body = body + "Pantelija Petrović, pom.gen.dir." + "<br /> ";
                body = body + "064/855-0089" + "<br /> <br />";
                body = body + "Branko Petković, gen.dir. " + "<br /> ";
                body = body + "063/478-535 " + "<br /> <br />";
                body = body + "NAPOMENA: Nalog važi bez pečata i potpisa ako je poslat zaposlenom na službeni telefon sa službenog " + "<br /> ";
                body = body + "e-maila koji sadrži “@kprevoz.co.rs" + "<br /> ";


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

        private void chkSluzbeni_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSluzbeni.Checked == true)
            {
                var select3 = " select ID, (Rtrim(RegBr) + ' ' + RTrim(Marka)) as Opis from Automobili where Sluzbeni = 1 order by opis";
                var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection3 = new SqlConnection(s_connection3);
                var c3 = new SqlConnection(s_connection3);
                var dataAdapter3 = new SqlDataAdapter(select3, c3);

                var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
                var ds3 = new DataSet();
                dataAdapter3.Fill(ds3);
                cboAutomobili.DataSource = ds3.Tables[0];
                cboAutomobili.DisplayMember = "Opis";
                cboAutomobili.ValueMember = "ID";
            }
            else
            {
                cboAutomobili.Text = "";
                var select3 = " select ID, (Rtrim(RegBr) + ' ' + RTrim(Marka)) as Opis from Automobili where Sluzbeni = 0 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) + " order by opis";
                var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection3 = new SqlConnection(s_connection3);
                var c3 = new SqlConnection(s_connection3);
                var dataAdapter3 = new SqlDataAdapter(select3, c3);

                var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
                var ds3 = new DataSet();
                dataAdapter3.Fill(ds3);
                cboAutomobili.DataSource = ds3.Tables[0];
                cboAutomobili.DisplayMember = "Opis";
                cboAutomobili.ValueMember = "ID";
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
         /*   Firma
Zrenjanin Šinvoz
Pruga*/
            if (cboLokacija.Text == "Firma")
            {
                txtAdresa.Text = "M.Milankovića 108/BEOGRAD lokal";
            }
            if (cboLokacija.Text == "Zrenjanin Šinvoz")
            {
                txtAdresa.Text = "BEOGRAD - ZRENJANJIN – BEOGRAD";
            }
            if (cboLokacija.Text == "Pruga")
            {
                txtAdresa.Text = "";
            }
            if (cboLokacija.Text == "HBIS")
            {
                txtAdresa.Text = "SMEDEREVO - RADINAC – SMEDEREVO";
            }
            if (cboLokacija.Text == "Skladište")
            {
                txtAdresa.Text = "Batajnički drum bb/BEOGRAD lokal";
            }

        }

        private void chkStan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStan.Checked == true)
            {
            ///Ako je stan
                var select3 = " select ID, AdresaStana as Opis from MUPMesto where Stan = 1  order by opis";
                var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection3 = new SqlConnection(s_connection3);
                var c3 = new SqlConnection(s_connection3);
                var dataAdapter3 = new SqlDataAdapter(select3, c3);

                var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
                var ds3 = new DataSet();
                dataAdapter3.Fill(ds3);
                txtRelacija.DataSource = ds3.Tables[0];
                txtRelacija.DisplayMember = "Opis";
                txtRelacija.ValueMember = "ID";

            }
            else
            {
                var select3 = " select ID, AdresaStanovanja as Opis from MUPMesto where Stan = 0 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) + " order by opis";
                var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection3 = new SqlConnection(s_connection3);
                var c3 = new SqlConnection(s_connection3);
                var dataAdapter3 = new SqlDataAdapter(select3, c3);

                var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
                var ds3 = new DataSet();
                dataAdapter3.Fill(ds3);
                txtRelacija.DataSource = ds3.Tables[0];
                txtRelacija.DisplayMember = "Opis";
                txtRelacija.ValueMember = "ID";
            }
        }

        private void cboLokacija_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
