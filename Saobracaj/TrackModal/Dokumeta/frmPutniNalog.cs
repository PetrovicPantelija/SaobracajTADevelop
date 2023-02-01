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
using Saobracaj.TrackModal;

using Microsoft.Reporting.WinForms;

namespace Testiranje.Dokumeta
{
    public partial class frmPutniNalog : Form
    {
        string KorisnikCene;
        bool status = false;
        MailMessage mailMessage;
        public frmPutniNalog()
        {
            InitializeComponent();
        }

        public frmPutniNalog(int sifra, string Korisnik)
        {
            InitializeComponent();
            txtSifra.Text = sifra.ToString();
            KorisnikCene = Korisnik;
            VratiPodatke(sifra);
            RefreshDataGridOsoblje();
            RefreshDataGridServis();
            RefreshDataGridGorivo();
            RefreshDataGridGume();
            RefreshDataGridRuta();
            RefreshDataGridTroskovi();
            RefreshDataGridKvarovi();
        }

        public frmPutniNalog(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

        public frmPutniNalog(string NalogZaPrevozID, string MestoUtovara, string MestoIstovara,string Korisnik, string RelacijaOd, string RelacijaDo)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
            txtNalogZaPrevozID.Text = NalogZaPrevozID;
            txtUtovarnoMesto.Text = MestoUtovara;
            txtIstovarnoMesto.Text = MestoIstovara;
            dtpDatumPrevoza.Value = DateTime.Now;
            txtRelacija1.Text = RelacijaOd;
            txtRelacija2.Text = RelacijaDo;
            if (txtSifra.Text != "")
            {
                VratiPodatke(Convert.ToInt32(txtSifra.Text));
            }
            
        }

        private void VratiPodatke(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[IDNalogZaPrevoz] " +
     " ,[MestoIzdavanja] ,[DatumPrevoza] ,[UtovarnoMesto],[IstovarnoMesto] " +
     " ,[Vozilo],[PrikljucnaVozila],[Napomena],[Dispecer] "+
     " ,[Vozac],[TehnickuIspravnost],[Datum],[Korisnik] "+
     " ,[PrikljucnoVoziloID],[Marka1],[Tip1] "+
     " ,[Tezina1],[Marka2],[Tip2],[Tezina2] ,[RelacijaOd],[RelacijaDo] " +
     "   FROM [dbo].[PutniNalog]    where ID = " + ID, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtNalogZaPrevozID.Text = dr["IDNalogZaPrevoz"].ToString();
                txtMestoIzdavanja.Text = dr["IDNalogZaPrevoz"].ToString();
                dtpDatumPrevoza.Value = Convert.ToDateTime(dr["DatumPrevoza"].ToString());
                txtUtovarnoMesto.Text = dr["UtovarnoMesto"].ToString();
                txtIstovarnoMesto.Text = dr["IstovarnoMesto"].ToString();
                cboVozilo.SelectedValue = Convert.ToInt32(dr["Vozilo"].ToString());
                cboPrikljucnoVozilo.SelectedValue = Convert.ToInt32(dr["Vozilo"].ToString());
                txtNapomena.Text = dr["Napomena"].ToString();
                cboTransportniDispičer.SelectedValue = Convert.ToInt32(dr["Dispecer"].ToString());
                cboVozac.SelectedValue = Convert.ToInt32(dr["Vozac"].ToString());
                cboTehnickaIspravnost.SelectedValue =  Convert.ToInt32(dr["Vozac"].ToString());
                cboPrikljucnoVozilo.SelectedValue = Convert.ToInt32(dr["PrikljucnoVoziloID"].ToString());
                txtMarka1.Text = dr["Marka1"].ToString();
                txtTip1.Text = dr["Tip1"].ToString();
                txtTezina1.Text = dr["Tezina1"].ToString();
                txtMarka2.Text = dr["Marka2"].ToString();
                txtTip2.Text = dr["Tip2"].ToString();
                txtTezina2.Text = dr["Tezina2"].ToString();
                txtRelacija1.Text = dr["RelacijaOd"].ToString();
                txtRelacija2.Text = dr["RelacijaDo"].ToString();
            }
            con.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {


           
            if (status == true)
            {
                Dokumeta.InsertPutniNalog ins = new InsertPutniNalog();
                ins.InsPutniNalog(Convert.ToInt32(txtNalogZaPrevozID.Text),txtMestoIzdavanja.Text, Convert.ToDateTime(dtpDatumPrevoza.Value), txtIstovarnoMesto.Text, txtUtovarnoMesto.Text,Convert.ToInt32(cboVozilo.SelectedValue), txtPrikljucnaVozila.Text,txtNapomena.Text, Convert.ToInt32(cboTransportniDispičer.SelectedValue), Convert.ToInt32(cboVozac.SelectedValue), Convert.ToInt32(cboTehnickaIspravnost.SelectedValue),DateTime.Now, KorisnikCene,Convert.ToInt32(cboPrikljucnoVozilo.SelectedValue), txtMarka1.Text, txtTip1.Text, Convert.ToDouble(txtTezina1.Text), txtMarka2.Text, txtTip2.Text, Convert.ToDouble(txtTezina2.Text),txtRelacija1.Text, txtRelacija2.Text);
                status = false;
                VratiPodatkeMax();
            }
            else
            {

                
                    Dokumeta.InsertPutniNalog upd = new InsertPutniNalog();
                    upd.UpdPutniNalog(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtNalogZaPrevozID.Text), txtMestoIzdavanja.Text, Convert.ToDateTime(dtpDatumPrevoza.Value), txtIstovarnoMesto.Text, txtUtovarnoMesto.Text, Convert.ToInt32(cboVozilo.SelectedValue), txtPrikljucnaVozila.Text, txtNapomena.Text, Convert.ToInt32(cboTransportniDispičer.SelectedValue), Convert.ToInt32(cboVozac.SelectedValue), Convert.ToInt32(cboTehnickaIspravnost.SelectedValue), DateTime.Now, KorisnikCene, Convert.ToInt32(cboPrikljucnoVozilo.SelectedValue), txtMarka1.Text, txtTip1.Text, Convert.ToDouble(txtTezina1.Text), txtMarka2.Text, txtTip2.Text, Convert.ToDouble(txtTezina2.Text), txtRelacija1.Text, txtRelacija2.Text);
                    status = false;
                

            }
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from PutniNalog", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void frmPutniNalog_Load(object sender, EventArgs e)
        {
            var select1 = "select ID, RegistarskaOznaka from Vozila where RegistarskaOznaka is not null";

            var s_connection1 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection1 = new SqlConnection(s_connection1);
            var c1 = new SqlConnection(s_connection1);
            var dataAdapter1 = new SqlDataAdapter(select1, c1);

            var commandBuilder1 = new SqlCommandBuilder(dataAdapter1);
            var ds1 = new DataSet();
            dataAdapter1.Fill(ds1);
            cboPrikljucnoVozilo.DataSource = ds1.Tables[0];
            cboPrikljucnoVozilo.DisplayMember = "RegistarskaOznaka";
            cboPrikljucnoVozilo.ValueMember = "ID";



            var select2 = "select ID, RegistarskaOznaka from Vozila where RegistarskaOznaka is not null";

            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboVozilo.DataSource = ds2.Tables[0];
            cboVozilo.DisplayMember = "RegistarskaOznaka";
            cboVozilo.ValueMember = "ID";

            var select4 = "  select id, (Ime + ' ' + Prezime) as Naziv from Zaposleni order by Naziv";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboTransportniDispičer.DataSource = ds4.Tables[0];
            cboTransportniDispičer.DisplayMember = "Naziv";
            cboTransportniDispičer.ValueMember = "ID";

            var select5 = " select id, (Ime + ' ' + Prezime) as Naziv from Zaposleni order by Naziv";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboVozac.DataSource = ds5.Tables[0];
            cboVozac.DisplayMember = "Naziv";
            cboVozac.ValueMember = "ID";

            var select6 = " select id, (Ime + ' ' + Prezime) as Naziv from Zaposleni order by Naziv";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboTehnickaIspravnost.DataSource = ds6.Tables[0];
            cboTehnickaIspravnost.DisplayMember = "Naziv";
            cboTehnickaIspravnost.ValueMember = "ID";

            var select7 = " select id, (Ime + ' ' + Prezime) as Naziv from Zaposleni order by Naziv";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            CboZaposleni.DataSource = ds7.Tables[0];
            CboZaposleni.DisplayMember = "Naziv";
            CboZaposleni.ValueMember = "ID";

           

            if (txtSifra.Text != "")
            {
                VratiPodatke(Convert.ToInt32(txtSifra.Text));
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int pomVozac = 0;
            if (chk1.Checked == true)
            {
                pomVozac = 1;
            }
            else
            {
                pomVozac = 0;
            }
            
            Dokumeta.InsertPutniNalogZaposleni ins = new InsertPutniNalogZaposleni();
            ins.InsPutniNalogZaposleni(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(CboZaposleni.SelectedValue), pomVozac);
            RefreshDataGridOsoblje();
        
        }

        private void RefreshDataGridOsoblje()
        {
            var select = "select PutniNalogZaposleni.ID, PutniNalogZaposleni.IdNadredjeni, PutniNalogZaposleni.Zaposleni, RTRIM(Zaposleni.Ime + ' ' + Zaposleni.Prezime) as Zaposleni, Vozac  from PutniNalogZaposleni inner join Zaposleni on PutniNalogZaposleni.Zaposleni = Zaposleni.ID " +
             " where PutniNalogZaposleni.IdNadredjeni = " + Convert.ToInt32(txtSifra.Text);
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
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "IdNadredjeni";
            dataGridView3.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Zaposleni id";
            dataGridView3.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Zaposleni";
            dataGridView3.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Vozač";
            dataGridView3.Columns[4].Width = 100;

        }

        private void RefreshDataGridKvarovi()
        {
            var select = "SELECT [ID] ,[IDNadredjenog] ,[PoslatEmail] ,[Tekst] " +
  " FROM [dbo].[PutniNalogKvarovi]" +
             " where PutniNalogKvarovi.IdNadredjenog = " + Convert.ToInt32(txtSifra.Text);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView7.ReadOnly = true;
            dataGridView7.DataSource = ds.Tables[0];
            DataGridViewColumn column = dataGridView7.Columns[0];
            dataGridView7.Columns[0].HeaderText = "ID";
            dataGridView7.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView7.Columns[1];
            dataGridView7.Columns[1].HeaderText = "IdNadredjeni";
            dataGridView7.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView7.Columns[2];
            dataGridView7.Columns[2].HeaderText = "Poslat email";
            dataGridView7.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView7.Columns[3];
            dataGridView7.Columns[3].HeaderText = "Tekst";
            dataGridView7.Columns[3].Width = 450;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            int pomVozac = 0;
            if (chk1.Checked == true)
            {
                pomVozac = 1;
            }
            else
            {
                pomVozac = 0;
            }

            Dokumeta.InsertPutniNalogZaposleni upd = new InsertPutniNalogZaposleni();

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Selected == true)
                {
                    upd.UpdPutniNalogZaposleni(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(CboZaposleni.SelectedValue), pomVozac);
                }
            }
            RefreshDataGridOsoblje();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                int pomVozac = 0;
                if (chk1.Checked == true)
                {
                    pomVozac = 1;
                }
                else
                {
                    pomVozac = 0;
                }

                Dokumeta.InsertPutniNalogZaposleni upd = new InsertPutniNalogZaposleni();

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected == true)
                    {
                        upd.DeletePutniNalogZaposleni(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                }
                RefreshDataGridOsoblje();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }
        //Servis
        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            Dokumeta.InsertPutniNalogServis ins = new InsertPutniNalogServis();
            ins.InsPutniNalogServis(Convert.ToInt32(txtSifra.Text), txtServis.Text, Convert.ToDouble(txtStanjeGorivaUlaz.Value), Convert.ToDouble(txtStanjeGorivaIzlaz.Value));
            RefreshDataGridServis();
        }

        private void RefreshDataGridServis()
        {
            var select = "select PutniNalogServis.ID, PutniNalogServis.IdNadredjenog, PutniNalogServis.Servis, PutniNalogServis.StanjeGorivaUlaz, PutniNalogServis.StanjeGorivaIzlaz  from PutniNalogServis " +
             " where PutniNalogServis.IdNadredjenog = " + Convert.ToInt32(txtSifra.Text);
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
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "IdNadredjeni";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Servis";
            dataGridView1.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "St goriva ulaz";
            dataGridView1.Columns[3].Width = 80;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "St goriva izlaz";
            dataGridView1.Columns[4].Width = 80;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            Dokumeta.InsertPutniNalogServis upd = new InsertPutniNalogServis();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    upd.UpdPutniNalogServis(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(txtSifra.Text), txtServis.Text, Convert.ToDouble(txtStanjeGorivaUlaz.Value), Convert.ToDouble(txtStanjeGorivaIzlaz));
                }
            }
            RefreshDataGridServis();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Dokumeta.InsertPutniNalogServis upd = new InsertPutniNalogServis();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected == true)
                    {
                        upd.DeletePutniNalogServis(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                }
                RefreshDataGridServis();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Polazak = 0;

            if (chkPolazak.Checked == true)
                {
                Polazak = 1;
                }
            else
            {
                Polazak = 2;
            }

            Dokumeta.InsertPutniNalogRuta ins = new InsertPutniNalogRuta();
            ins.InsPutniNalogRuta(Convert.ToInt32(txtSifra.Text), Polazak, Convert.ToDateTime(dtpDatumRuta.Value), Convert.ToDouble(StanjeBrojilaRuta.Value), txtServiserRuta.Text, Convert.ToInt32(cboVozacRute.SelectedValue), txtRelacijaRute.Text, txtBrojTure.Text, Convert.ToDouble(txtTezinaTure.Value));   
           
            RefreshDataGridRuta();
        }
        //Rutatxt
        private void RefreshDataGridRuta()
        {
            var select = "select PutniNalogRuta.ID, PutniNalogRuta.IdNadredjenog,  PutniNalogRuta.Polazak,PutniNalogRuta.Datum, PutniNalogRuta.StanjeBrojila, PutniNalogRuta.Serviser  from PutniNalogRuta " +
             " where PutniNalogRuta.IdNadredjenog = " + Convert.ToInt32(txtSifra.Text);
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
            dataGridView2.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "IdNadredjeni";
            dataGridView2.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Polazak";
            dataGridView2.Columns[2].Width = 40;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Datum";
            dataGridView2.Columns[3].Width = 80;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Stanje brojila";
            dataGridView2.Columns[4].Width = 80;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Serviser";
            dataGridView2.Columns[5].Width = 80;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            int Polazak = 0;

            if (chkPolazak.Checked == true)
            {
                Polazak = 1;
            }
            else
            {
                Polazak = 2;
            }

            Dokumeta.InsertPutniNalogRuta upd = new InsertPutniNalogRuta();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Selected == true)
                {
                    upd.UpdPutniNalogRuta(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(txtSifra.Text), Polazak, Convert.ToDateTime(dtpDatumRuta.Value), Convert.ToDouble(StanjeBrojilaRuta.Value), txtServiserRuta.Text);
                }
            }
            RefreshDataGridRuta();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dokumeta.InsertPutniNalogRuta upd = new InsertPutniNalogRuta();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Selected == true)
                {
                    upd.DeletePutniNalogRuta(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }
            }
            RefreshDataGridRuta();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dokumeta.InsertPutniNalogGume ins = new InsertPutniNalogGume();
            ins.InsPutniNalogGume(Convert.ToInt32(txtSifra.Text),txtBrojGume.Text, Convert.ToDateTime(dtpDatumGume.Value),Convert.ToDouble(txtStanjeBrojilaGume.Value),txtNapomenaGume.Text);

            RefreshDataGridGume();
        }

        private void RefreshDataGridGume()
        {
            var select = "select PutniNalogGume.ID, PutniNalogGume.IdNadredjenog,  PutniNalogGume.BrojGume,PutniNalogGume.Datum, PutniNalogGume.StanjeBrojila, PutniNalogGume.Napomena  from PutniNalogGume " +
                 " where PutniNalogGume.IdNadredjenog = " + Convert.ToInt32(txtSifra.Text);
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
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView4.Columns[1];
            dataGridView4.Columns[1].HeaderText = "IdNadredjeni";
            dataGridView4.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView4.Columns[2];
            dataGridView4.Columns[2].HeaderText = "Broj gume";
            dataGridView4.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView4.Columns[3];
            dataGridView4.Columns[3].HeaderText = "Datum";
            dataGridView4.Columns[3].Width = 80;

            DataGridViewColumn column5 = dataGridView4.Columns[4];
            dataGridView4.Columns[4].HeaderText = "Stanje brojila";
            dataGridView4.Columns[4].Width = 80;

            DataGridViewColumn column6 = dataGridView4.Columns[5];
            dataGridView4.Columns[5].HeaderText = "Napomena";
            dataGridView4.Columns[5].Width = 120;


        }

        private void button7_Click(object sender, EventArgs e)
        {
         

            Dokumeta.InsertPutniNalogGume upd = new InsertPutniNalogGume();

            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (row.Selected == true)
                {
                    upd.UpdPutniNalogGume(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(txtSifra.Text), txtBrojGume.Text, Convert.ToDateTime(dtpDatumGume.Value), Convert.ToDouble(txtStanjeBrojilaGume.Value), txtNapomenaGume.Text);
                }
            }
            RefreshDataGridGume();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dokumeta.InsertPutniNalogGume upd = new InsertPutniNalogGume();

            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (row.Selected == true)
                {
                    upd.DeletePutniNalogGume(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }
            }
            RefreshDataGridGume();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Dokumeta.InsertPutniNalogGorivo ins = new InsertPutniNalogGorivo();
            ins.InsPutniNalogGorivo(Convert.ToInt32(txtSifra.Text), Convert.ToDouble(txtStanjeBrojilaGorivo.Value), Convert.ToDouble(txtGorivo.Value), txtMesto.Text, txtMestoPotpis.Text);

            RefreshDataGridGorivo();
        }

        private void RefreshDataGridGorivo()
        {
            var select = "select PutniNalogGorivo.ID, PutniNalogGorivo.IdNadredjenog,  PutniNalogGorivo.StanjeBrojila,PutniNalogGorivo.Gorivo, PutniNalogGorivo.Mesto, PutniNalogGorivo.MestoPotpis  from PutniNalogGorivo " +
                 " where PutniNalogGorivo.IdNadredjenog = " + Convert.ToInt32(txtSifra.Text);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView5.ReadOnly = true;
            dataGridView5.DataSource = ds.Tables[0];
            DataGridViewColumn column = dataGridView5.Columns[0];
            dataGridView5.Columns[0].HeaderText = "ID";
            dataGridView5.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView5.Columns[1];
            dataGridView5.Columns[1].HeaderText = "IdNadredjeni";
            dataGridView5.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView5.Columns[2];
            dataGridView5.Columns[2].HeaderText = "Stanje brojila";
            dataGridView5.Columns[2].Width = 80;

            DataGridViewColumn column4 = dataGridView5.Columns[3];
            dataGridView5.Columns[3].HeaderText = "Gorivo";
            dataGridView5.Columns[3].Width = 80;

            DataGridViewColumn column5 = dataGridView5.Columns[4];
            dataGridView5.Columns[4].HeaderText = "Mesto";
            dataGridView5.Columns[4].Width = 100;

            DataGridViewColumn column6 = dataGridView5.Columns[5];
            dataGridView5.Columns[5].HeaderText = "Mesto potpisa";
            dataGridView5.Columns[5].Width = 120;


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Dokumeta.InsertPutniNalogGorivo upd = new InsertPutniNalogGorivo();

            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (row.Selected == true)
                {
                    upd.UpdPutniNalogGorivo(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(txtSifra.Text), Convert.ToDouble(txtStanjeBrojilaGorivo.Value), Convert.ToDouble(txtGorivo.Value), txtMesto.Text, txtMestoPotpis.Text);
                }
            }
            RefreshDataGridGorivo();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Dokumeta.InsertPutniNalogGorivo upd = new InsertPutniNalogGorivo();

            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (row.Selected == true)
                {
                    upd.DeletePutniNalogGorivo(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }
            }
            RefreshDataGridGume();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Dokumeta.InsertPutniNalogTroskovi ins = new InsertPutniNalogTroskovi();
            ins.InsPutniNalogTroskovi(Convert.ToInt32(txtSifra.Text), Convert.ToDateTime(dtpDatumTroskovi.Value),txtSvrha.Text, Convert.ToDouble(txtKolicina.Value), Convert.ToDateTime(dtpDatumPotpisTroskovi.Value),txtPotpisaoTroskovi.Text);

            RefreshDataGridTroskovi();
        }

        private void RefreshDataGridTroskovi()
        {
            var select = "select PutniNalogTroskovi.ID, PutniNalogTroskovi.IdNadredjenog,  PutniNalogTroskovi.Datum,PutniNalogTroskovi.Svrha, PutniNalogTroskovi.Kolicina,PutniNalogTroskovi.DatumPotpisa, PutniNalogTroskovi.Potpisao  from PutniNalogTroskovi " +
                 " where PutniNalogTroskovi.IdNadredjenog = " + Convert.ToInt32(txtSifra.Text);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView6.ReadOnly = true;
            dataGridView6.DataSource = ds.Tables[0];
            DataGridViewColumn column = dataGridView6.Columns[0];
            dataGridView6.Columns[0].HeaderText = "ID";
            dataGridView6.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView6.Columns[1];
            dataGridView6.Columns[1].HeaderText = "Datum";
            dataGridView6.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView6.Columns[2];
            dataGridView6.Columns[2].HeaderText = "Svrha";
            dataGridView6.Columns[2].Width = 80;

            DataGridViewColumn column4 = dataGridView6.Columns[3];
            dataGridView6.Columns[3].HeaderText = "Iznos";
            dataGridView6.Columns[3].Width = 80;

            DataGridViewColumn column5 = dataGridView6.Columns[4];
            dataGridView6.Columns[4].HeaderText = "Datum potpisa";
            dataGridView6.Columns[4].Width = 100;

            DataGridViewColumn column6 = dataGridView6.Columns[5];
            dataGridView6.Columns[5].HeaderText = "Potpisao";
            dataGridView6.Columns[5].Width = 120;


        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void cboVozilo_Leave(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Naziv, Namena, SopstvenaTezina " +
            " FROM [dbo].[Vozila] where ID = " + Convert.ToInt32(cboVozilo.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtMarka1.Text = dr["Naziv"].ToString();
                txtTip1.Text = dr["Namena"].ToString();
                txtTezina1.Text = dr["SopstvenaTezina"].ToString();
            }
            con.Close();
        }

        private void cboPrikljucnoVozilo_Leave(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Naziv, Namena, SopstvenaTezina " +
            " FROM [dbo].[Vozila] where ID = " + Convert.ToInt32(cboPrikljucnoVozilo.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtMarka2.Text = dr["Naziv"].ToString();
                txtTip2.Text = dr["Namena"].ToString();
                txtTezina2.Text = dr["SopstvenaTezina"].ToString();
            }
            con.Close();
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            int pom = 0;
            if (chkMail.Checked == true)
            {
                pom = 1;
              
            }
            Dokumeta.InsertPutniNalogKvarovi ins = new InsertPutniNalogKvarovi();
            ins.InsPutniNalogKvarovi(Convert.ToInt32(txtSifra.Text), txtKvar.Text, pom);
            RefreshDataGridKvarovi();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int pom = 0;
            if (chkMail.Checked == true)
            {
                pom = 1;

            }
            Dokumeta.InsertPutniNalogKvarovi ins = new InsertPutniNalogKvarovi();
            ins.UpdPutniNalogKvarovi(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtNalogZaPrevozID.Text), txtKvar.Text, pom);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Dokumeta.InsertPutniNalogKvarovi ins = new InsertPutniNalogKvarovi();
            ins.DeletePutniNalogKvarovi(Convert.ToInt32(txtSifra.Text));

        }

        private void PosaljiMailRadionica(string Kome)
        {
            try
            {
                chkMail.Checked = true;
                string zadnjibroj = txtSifra.Text;
                //drugi je kome
                

                    mailMessage = new MailMessage("logistika@zitbgd.rs", Kome);

                    mailMessage.Subject = "ŽIT TRANSPORT PUTNI NALOG BR: " + zadnjibroj + " . ";

                    var select = "  SELECT Tekst from PutniNalogKvarovi" +
                " where ID= " + Convert.ToInt32(txtSifra.Text);


                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection myConnection = new SqlConnection(s_connection);
                    var c = new SqlConnection(s_connection);
                    var dataAdapter = new SqlDataAdapter(select, c);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    string body = "TRANSPORTNA SLUŽBA:  <br /><br />";
                    body = body + " Poštovani,    <br /> <br /> <br />";


                    int countS = 0;
                    foreach (DataRow myRow in ds.Tables[0].Rows)
                    {
                        if (countS == 0)
                        {
                            body = body +  myRow["Tekst"].ToString() + "<br />";

                          
                        }
                        countS = countS + 1;

                    }
                body = body + "Potpis" + "<br />";
                body = body + cboTransportniDispičer.Text + "<br />";
                
                //  body = body + "<br /> Po izvršenom dolasku voza i prijemu kontejnera na terminal ŽIT-a u Beograd ranžirnoj obavestićemo Vas blagovremeno na e-mailom.   <br />";
                body = body + "Transportna služba <br />";
                    body = body + "Tel: <br />";
                    body = body + "Email: <br />";


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


        private void button18_Click(object sender, EventArgs e)
        {
           // PosaljiMailRadionica("zoran.milosevic@zitbgd.rs");
            PosaljiMailRadionica("panta0307@yahoo.com");

            int pom = 1;

            Dokumeta.InsertPutniNalogKvarovi ins = new InsertPutniNalogKvarovi();
            ins.UpdPutniNalogKvarovi(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtNalogZaPrevozID.Text), txtKvar.Text, pom);
            RefreshDataGridKvarovi();


        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Saobracaj.TrackModal.TestiranjeDataSet14TableAdapters.SelectPutniNalogTransportTableAdapter ta = new Saobracaj.TrackModal.TestiranjeDataSet14TableAdapters.SelectPutniNalogTransportTableAdapter();
            TestiranjeDataSet14.SelectPutniNalogTransportDataTable dt = new TestiranjeDataSet14.SelectPutniNalogTransportDataTable();


            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

         
            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptPutniNalog.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
           
            reportViewer1.RefreshReport();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            frmRadniNalogTransport rnt = new frmRadniNalogTransport(txtNalogZaPrevozID.Text, txtSifra.Text, Convert.ToInt32(cboVozilo.SelectedValue), txtMestoIzdavanja.Text, Convert.ToInt32(cboPrikljucnoVozilo.SelectedValue), Convert.ToInt32(cboTransportniDispičer.SelectedValue));
            rnt.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // cboVozacRute

            var select8 = " select Zaposleni.id, (Ime + ' ' + Prezime) as Naziv from Zaposleni " +
            " inner join PutniNalogZaposleni on PutniNalogZaposleni.Zaposleni = Zaposleni.Id" +
            " inner join PutniNalog on PutniNalogZaposleni.IdNadredjeni = PutniNalog.ID" +
            " where PutniNalog.ID = " + Convert.ToInt32(txtSifra.Text);
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboVozacRute.DataSource = ds8.Tables[0];
            cboVozacRute.DisplayMember = "Naziv";
            cboVozacRute.ValueMember = "ID";
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
