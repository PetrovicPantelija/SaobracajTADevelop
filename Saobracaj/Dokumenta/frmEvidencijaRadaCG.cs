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
    public partial class frmEvidencijaRadaCG : Form
    {
        MailMessage mailMessage;
        Boolean status = false;

        public frmEvidencijaRadaCG()
        {
            InitializeComponent();
        }

        public frmEvidencijaRadaCG(int Sifra)
        {
            InitializeComponent();
            txtSifra.Text = Sifra.ToString();
        }

        private void VratiPodatkeAktivnost()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select ID, Zaposleni, VremeOd,VremeDo, Ukupno, UkupniTroskovi, Opis, RN,Oznaka, PoslatEmail, Placeno, RAcun, Kartica, Masinovodja from Aktivnosti where ID = " + Convert.ToInt32(txtSifra.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
                cboZaposleni.SelectedValue = Convert.ToInt32(dr["Zaposleni"].ToString());
                dtpVremeOd.Value = Convert.ToDateTime(dr["VremeOd"].ToString());
                dtpVremeDo.Value = Convert.ToDateTime(dr["VremeDo"].ToString());
                txtVreme.Text = dr["Ukupno"].ToString();
                txtUkupnoMašinovođa.Text = dr["Ukupno"].ToString();
                txtTrosak.Text = dr["UkupniTroskovi"].ToString();
                txtKomentar.Text = dr["Opis"].ToString();
                cboRadniNalog.SelectedValue = Convert.ToInt32(dr["RN"].ToString());
                txtOznaka.Text = dr["Oznaka"].ToString();
                txtRacun.Text = dr["Racun"].ToString();
                txtKartica.Text = dr["Kartica"].ToString();
                if (dr["PoslatEmail"].ToString() == "1")
                {
                    chkPoslatMail.Checked = true;
                }
                else
                {
                    chkPoslatMail.Checked = false;

                }
                if (dr["Placeno"].ToString() == "1")
                {
                    chkPlaceno.Checked = true;
                }
                else
                {
                    chkPlaceno.Checked = false;

                }

                if (dr["Masinovodja"].ToString() == "1")
                {
                    chkUnosMasinovođa.Checked = true;
                }
                else
                {
                    chkUnosMasinovođa.Checked = false;

                }
            }

            con.Close();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            dtpVremeOd.Value = DateTime.Now;
            dtpVremeDo.Value = DateTime.Now;
            txtKomentar.Text = "";
            txtVreme.Text = "0";
        }

        private void frmEvidencijaRada_Load(object sender, EventArgs e)
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

            var select4 = " select ID, Naziv from VrstaAktivnosti where ObracunPoSatu = 1 and CG = 1";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboAktivnost.DataSource = ds4.Tables[0];
            cboAktivnost.DisplayMember = "Naziv";
            cboAktivnost.ValueMember = "ID";

            var select5 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection3);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboNalogodavac.DataSource = ds5.Tables[0];
            cboNalogodavac.DisplayMember = "Opis";
            cboNalogodavac.ValueMember = "ID";

            cboNalogodavac.SelectedValue = 0;

            RefreshDataGrid();

            if (txtSifra.Text == "")
            {

            }
            else
            {
                VratiPodatkeAktivnost();
                RefreshDataGridPoAktivnostima();
                VratiEmail();
                // VratiTrase(txtSifra.Text);
            }
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Aktivnosti", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void VratiEmail()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select DeEmail as Email from Delavci where DeSifra =" + Convert.ToInt32(cboZaposleni.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtEmail.Text = dr["Email"].ToString();
            }

            con.Close();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            double vreme = 0;
            int masinovodja = 0;

            if (chkUnosMasinovođa.Checked == true)
            {
                vreme = Convert.ToDouble(txtUkupnoMašinovođa.Text);
                masinovodja = 1;
            }
            else
            {
                vreme = Convert.ToDouble(txtVreme.Text);
            }

            if (status == true)
            {
                InsertAktivnosti ins = new InsertAktivnosti();
                ins.InsAktivnosti(Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, vreme, Convert.ToDouble(txtTrosak.Text), txtKomentar.Text, 0, txtOznaka.Text, Convert.ToDouble(txtRacun.Text), Convert.ToDouble(txtKartica.Text), masinovodja, txtMesto.Text.Trim(),0,1,1,1,"sa", 0);
                status = false;
                VratiPodatkeMax();
            }
            else
            {
                InsertAktivnosti upd = new InsertAktivnosti();
                upd.UpdAktivnosti(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, vreme, Convert.ToDouble(txtTrosak.Text), txtKomentar.Text, 0, txtOznaka.Text, Convert.ToDouble(txtRacun.Text), Convert.ToDouble(txtKartica.Text), masinovodja, txtMesto.Text.Trim(),0,1,1);
            }
        }

        private void RefreshDataGrid()
        {
            var select = "  select ID, Naziv from VrstaAktivnosti where ObracunPoSatu=1 and CG = 1";

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
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Naziv";
            dataGridView2.Columns[1].Width = 300;


        }

        private void RefreshDataGridPoAktivnostima()
        {
            var select = "select VrstaAktivnosti.Naziv, Sati, BrojVagona, koeficijent, napomena, razlog, nalogodavac, vozilo from AktivnostiStavke " +
                " inner join VrstaAktivnosti on VrstaAktivnosti.ID = aKTIVNOSTIsTAVKE. VrstAAktivnostiID " +
                " where IDNadredjena = " + Convert.ToInt32(txtSifra.Text);

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
            dataGridView1.Columns[0].HeaderText = "Naziv";
            dataGridView1.Columns[0].Width = 200;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Sati";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Broj vagona";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Koef";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Napomena";
            dataGridView1.Columns[4].Width = 200;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Razlog";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Nalogodavac";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Vozilo";
            dataGridView1.Columns[7].Width = 100;

        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            if (txtBrojVagona.Text == "0")
            {
                MessageBox.Show("Potrebno je uneti broj vagona");
                return;
            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                InsertAktivnostiStavke ins = new InsertAktivnostiStavke();
                if (txtDodatnaNapomena.Text == "")
                    txtDodatnaNapomena.Text = " ";
                if (row.Selected == true)
                    ins.InsAktivnostiStavke(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToDouble(txtRad.Text), Convert.ToDouble(txtKoeficijent.Text), txtDodatnaNapomena.Text, Convert.ToInt32(txtBrojVagona.Text), txtRazlog.Text, Convert.ToInt32(cboNalogodavac.SelectedValue), cboVozilo.Text, 0, dtpStavke.Value,0);
                // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
            }
            RefreshDataGridPoAktivnostima();
            // ins.InsAktivnostiStavke(Convert.ToInt32(txtSifra.Text),  Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, Convert.ToDouble(txtVreme.Text), Convert.ToDouble(txtTrosak.Text), txtKomentar.Text, 0);
            status = false;
        }

        private void btnUbaciAktivnost_Click(object sender, EventArgs e)
        {
            int Nalogodavac = 0;

            InsertAktivnostiStavke ins = new InsertAktivnostiStavke();
            if (txtDodatnaNapomena.Text == "")
                txtDodatnaNapomena.Text = " ";

            if (cboNalogodavac.Text == "")
                Nalogodavac = 0;
            else
                Nalogodavac = Convert.ToInt32(cboNalogodavac.SelectedValue);


            ins.InsAktivnostiStavke(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboAktivnost.SelectedValue), Convert.ToDouble(txtRad.Text), Convert.ToDouble(txtKoeficijent.Text), txtDodatnaNapomena.Text, Convert.ToInt32(txtBrojVagona.Text), txtRazlog.Text, Nalogodavac, cboVozilo.Text,0,dtpStavke.Value,0);
            RefreshDataGridPoAktivnostima();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpVremeDo_Leave(object sender, EventArgs e)
        {
            TimeSpan span = dtpVremeDo.Value.Subtract(dtpVremeOd.Value);
            txtVreme.Text = Convert.ToString(Math.Round(Convert.ToDouble(span.TotalHours), 2));

            if (Math.Round(Convert.ToDouble(span.TotalHours), 2) < 7)
            {
                txtUkupnoMašinovođa.Text = "6";
            }

            else
            {
                txtUkupnoMašinovođa.Text = "12";
            }
            txtRad.Value = Convert.ToDecimal(txtUkupnoMašinovođa.Text);
            // Math.Round(inputValue, 2);
        }

        private void cboAktivnost_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cboAktivnost_Leave(object sender, EventArgs e)
        {

            int ObracunPoSatu = 0; int PotrebanRazlog = 0; int PotrebanNalogodavac = 0; int PotrebnoVozilo = 0; int ObaveznaNapomena = 0;
            txtRad.Text = "0";
            txtBrojVagona.Text = "0";
            cboNalogodavac.SelectedValue = 0;
            txtDodatnaNapomena.Text = "";
            cboVozilo.Text = "";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand("select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ObracunPoSatu = Convert.ToInt32(dr[0].ToString());
                    PotrebanRazlog = Convert.ToInt32(dr[1].ToString());
                    PotrebanNalogodavac = Convert.ToInt32(dr[2].ToString());
                    PotrebnoVozilo = Convert.ToInt32(dr[3].ToString());
                    ObaveznaNapomena = Convert.ToInt32(dr[4].ToString());
                }
            }
            conn.Close();
            /*
            if  (ObracunPoSatu == 1)
                txtRad.Enabled = true;
            if (PotrebanRazlog == 1)
            { 
                txtRazlog.Enabled = true;
            }    
            else
            {
                txtRazlog.Enabled = false;
            }
                 
            if (PotrebanNalogodavac == 1)
                txtDodatnaNapomena.Enabled = true;
            else
            {
                txtDodatnaNapomena.Enabled = false;
            }
            if (PotrebnoVozilo  == 1)
                cboVozilo.Enabled = true;
            else
            {
                cboVozilo.Enabled = false;
            }
             * */
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnPosaljiMail_Click(object sender, EventArgs e)
        {
            try
            {
                string zadnjibroj = txtSifra.Text;

                string mail = txtEmail.Text.TrimEnd();

                mailMessage = new MailMessage("zaposleni@kprevoz.co.rs", mail);

                mailMessage.Subject = "Uneti podaci za smenu ";

                var select = "Select ID, Rtrim(Delavci.DePriimek) + ' ' + RTrim(Delavci.DeIme) as Zaposleni, " +
                " VremeOd, VremeDo, Ukupno, UkupniTroskovi, Opis, RN, Oznaka from Aktivnosti " +
                " inner join Delavci on Aktivnosti.Zaposleni = Delavci.DeSifra " +
                " where ID = " + Convert.ToInt32(txtSifra.Text);

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                string body = "Spisak unetih aktivnosti za:  <br />";


                foreach (DataRow myRow in ds.Tables[0].Rows)
                {
                    body = body + "Zaposleni: " + myRow["Zaposleni"].ToString() + "<br /> ";
                    body = body + "Vreme: " + myRow["VremeOd"].ToString() + " - " + myRow["VremeDo"].ToString() + " Ukupno:" + myRow["Ukupno"].ToString() + "H" + "<br /> ";
                    body = body + "Dodatni troškovi: " + myRow["UkupniTroskovi"].ToString() + "<br /> ";
                    body = body + "Napomena: " + myRow["Opis"].ToString() + "<br /> <br />";
                }


                var select2 = " select VrstaAktivnosti.Naziv as Naziv, AktivnostiStavke.Sati as Sati, AktivnostiStavke.BrojVagona, " +
               " AktivnostiStavke.Razlog, Rtrim(Delavci.DePriimek) + ' ' + RTrim(Delavci.DeIme) as Nalogodavac, " +
                " AktivnostiStavke.Vozilo, AktivnostiStavke.Napomena from AktivnostiStavke " +
               " inner join VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
               " Left join Delavci on AktivnostiStavke.Nalogodavac = Delavci.DeSifra " +
               " where IDNadredjena = " + Convert.ToInt32(txtSifra.Text);


                var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection2 = new SqlConnection(s_connection2);
                var c2 = new SqlConnection(s_connection2);
                var dataAdapter2 = new SqlDataAdapter(select2, c2);

                var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
                var ds2 = new DataSet();
                dataAdapter2.Fill(ds2);

                foreach (DataRow myRow2 in ds2.Tables[0].Rows)
                {
                    body = body + "<br />";
                    body = body + "Aktivnost: " + myRow2["Naziv"].ToString() + "<br />";
                    if (Convert.ToDouble(myRow2["Sati"].ToString()) != 0)
                        body = body + "Sati: " + myRow2["Sati"].ToString() + " H " + "<br />";
                    if (Convert.ToInt32(myRow2["BrojVagona"].ToString()) != 0)
                        body = body + "Broj vagona: " + myRow2["BrojVagona"].ToString() + " VAG " + "<br />";
                    if (myRow2["Razlog"].ToString() != "")
                        body = body + "Razlog: " + myRow2["Razlog"].ToString() + "<br />";
                    if (myRow2["Nalogodavac"].ToString() != "")
                        body = body + "Nalogodavac: " + myRow2["Nalogodavac"].ToString() + "<br />";
                    if (myRow2["Vozilo"].ToString() != "")
                        body = body + "Vozilo: " + myRow2["Vozilo"].ToString() + "<br />";
                    if (myRow2["Napomena"].ToString().TrimEnd() != "")
                        body = body + "Napomena: " + myRow2["Napomena"].ToString() + "<br />  <br />"; ;

                }

                body = body + "<br /> <br /> <br />";

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


                InsertAktivnosti ins = new InsertAktivnosti();
                ins.UpdatePoslaoMailAktivnosti(Convert.ToInt32(txtSifra.Text));
                chkPoslatMail.Checked = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cboZaposleni_Leave(object sender, EventArgs e)
        {
            VratiEmail();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InsertAktivnosti ins = new InsertAktivnosti();
           // ins.UpdateAktivnostiPlaceno(Convert.ToInt32(txtSifra.Text));
            chkPlaceno.Checked = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            frmEvidencijaRadaDokumenti frmER = new frmEvidencijaRadaDokumenti(txtSifra.Text);
            frmER.Show();

        }

    }
}


