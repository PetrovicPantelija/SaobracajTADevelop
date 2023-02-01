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



namespace Testiranje.Dokumeta
{
    public partial class frmVoz : Form
    {


        string KorisnikCene = "Panta";
        bool status = false;
      //  int VozID = 1;
        public frmVoz()
        {
            InitializeComponent();
            KorisnikCene = "Panta";
        }

        public frmVoz(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
            KorisnikCene = "Panta";
            RefreshDataGrid();
        }

        public frmVoz(int Voz, string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
            KorisnikCene = "Panta";
            txtSifra.Text = Voz.ToString();
            RefreshDataGrid2();
            VratiUkupanBrojKontejnera();
            
        }
        private void tsSave_Click(object sender, EventArgs e)
        {
            int Dolazeci = 0;
            int Ponedeljak = 0;
			int Utorak = 0;
			int Sreda = 0;
			int Cetvrtak = 0;
			int Petak = 0;
			int Subota = 0;
			int Nedelja = 0;
            
            if (chkDolazeci.Checked ==true)  
            Dolazeci = 1;
             if (chkPonedeljak.Checked ==true)  
            Ponedeljak = 1;
             if (chkUtorak.Checked ==true)  
            Utorak = 1;
              if (chkSreda.Checked ==true)  
            Sreda = 1;
                if (chkCetvrtak.Checked ==true)  
            Cetvrtak = 1;
              if (chkPetak.Checked ==true)  
            Petak = 1;
             if (chkSubota.Checked ==true)  
            Subota = 1;
              if (chkNedelja.Checked ==true)  
            Nedelja = 1;
         
			
            
            
            if (status == true)
            {
                InsertVoz ins = new InsertVoz();
                ins.InsVoz(Convert.ToInt32(txtBrVoza.Text), txtRelacija.Text, txtKalendarSaobracaja.Text, Convert.ToDateTime(dtpVremePolaska.Value), Convert.ToDateTime(dtpVremeDolaska.Value), Convert.ToDouble(txtMaksBruto.Text), Convert.ToDouble(txtDuzina.Text), Convert.ToDouble(txtMaksBrojKola.Text), Convert.ToDateTime(dtpVremeZavrsetkaUtovara.Value), Convert.ToDateTime(dtpVremeZavrsetkaKP.Value), Convert.ToDateTime(dtpVremePrimopredaje.Value), txtNapomena.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, Dolazeci, Convert.ToInt32(txtPostNaTerminalD.Value), Convert.ToInt32(txtKontrolniPregledD.Value), Convert.ToInt32(txtVremeIstovaraD.Value), Convert.ToInt32(txtVremePrimopredajeD.Value), Ponedeljak, Utorak, Sreda, Cetvrtak, Petak, Subota, Nedelja, Convert.ToInt32(txtPostNaTerminalO.Value), Convert.ToInt32(txtVremeUtovaraO.Value), Convert.ToInt32(txtVremeKontrolnogO.Value), Convert.ToInt32(txtVremeIzvlacenjaO.Value), dtpVremePolaskaO.Value, dtpVremeDolaskaO.Value, Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue));
                status = false;
                VratiPodatkeMax();
            }
            else
            {
                //int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik
                InsertVoz upd = new InsertVoz();
                upd.UpdVoz(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtBrVoza.Text), txtRelacija.Text, txtKalendarSaobracaja.Text, Convert.ToDateTime(dtpVremePolaska.Value), Convert.ToDateTime(dtpVremeDolaska.Value), Convert.ToDouble(txtMaksBruto.Text), Convert.ToDouble(txtDuzina.Text), Convert.ToDouble(txtMaksBrojKola.Text), Convert.ToDateTime(dtpVremeZavrsetkaUtovara.Value), Convert.ToDateTime(dtpVremeZavrsetkaKP.Value), Convert.ToDateTime(dtpVremePrimopredaje.Value), txtNapomena.Text, Convert.ToDateTime(DateTime.Now),KorisnikCene, Dolazeci, Convert.ToInt32(txtPostNaTerminalD.Value), Convert.ToInt32(txtKontrolniPregledD.Value), Convert.ToInt32(txtVremeIstovaraD.Value), Convert.ToInt32(txtVremePrimopredajeD.Value), Ponedeljak, Utorak, Sreda, Cetvrtak, Petak, Subota, Nedelja, Convert.ToInt32(txtPostNaTerminalO.Value), Convert.ToInt32(txtVremeUtovaraO.Value), Convert.ToInt32(txtVremeKontrolnogO.Value), Convert.ToInt32(txtVremeIzvlacenjaO.Value), dtpVremePolaskaO.Value, dtpVremeDolaskaO.Value, Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue));
                status = false;
            }
            RefreshDataGrid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertVoz upd = new InsertVoz();
                upd.DeleteVoz(Convert.ToInt32(txtSifra.Text));
                RefreshDataGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
        }

        private void RefreshDataGrid()
        {

            var select = "  SELECT [ID],[BrVoza],[Relacija],[KalendarSaobracaja],[VremePolaska],[VremeDolaska],[MaksimalnaBruto],[MaksimalnaDuzina],[MaksimalanBrojKola],[VremeZavrsetkaUtovara],[VremeZavrsetkaKP],[VremePrimopredaje],[Napomena],[Datum],[Korisnik] ,Dolazeci,PostNaTerminalD ,KontrolniPregledD,VremeIstovaraD ,VremePrimopredajeD,Ponedeljak ,Utorak	,Sreda,Cetvrtak,Petak	,Subota ,Nedelja,PostNaTerminalO,VremeUtovaraO ,VremeKontrolnogO ,VremeIzvlacenjaO	,VremePolaskaO ,VremeDolaskaO, StanicaOd,StanicaDo  FROM [dbo].[Voz] order by ID desc";
           
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

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Br voza";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Relacija";
            dataGridView1.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Kalendar saobracaja";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme polaska";
            dataGridView1.Columns[4].Width = 50;


            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme dolaska";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Maksimalna bruto";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Maksimalna dužina";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Maksimalni broj kola";
            dataGridView1.Columns[8].Width = 100;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Vreme Zavrsetka Utovara";
            dataGridView1.Columns[9].Width = 100;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Vreme Zavrsetka KP";
            dataGridView1.Columns[10].Width = 100;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Vreme primopredaje";
            dataGridView1.Columns[11].Width = 100;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Napomena";
            dataGridView1.Columns[12].Width = 100;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Datum unosa";
            dataGridView1.Columns[13].Width = 100;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Korisnik";
            dataGridView1.Columns[14].Width = 100;

            VratiPodatke(txtSifra.Text);
        }

        public void VratiPodatke(string ID)
        {
            if (ID == "")
            {
                return;
            }
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();
           
            SqlCommand cmd = new SqlCommand("SELECT [ID],[BrVoza],[Relacija],[KalendarSaobracaja],[VremePolaska],[VremeDolaska],[MaksimalnaBruto],[MaksimalnaDuzina],[MaksimalanBrojKola],[VremeZavrsetkaUtovara],[VremeZavrsetkaKP],[VremePrimopredaje],[Napomena],[Datum],[Korisnik] ,Dolazeci,PostNaTerminalD ,KontrolniPregledD,VremeIstovaraD ,VremePrimopredajeD,Ponedeljak ,Utorak	,Sreda,Cetvrtak,Petak	,Subota ,Nedelja,PostNaTerminalO,VremeUtovaraO ,VremeKontrolnogO ,VremeIzvlacenjaO	,VremePolaskaO ,VremeDolaskaO, StanicaOd, StanicaDo, Napomena  FROM [dbo].[Voz] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                // Convert.ToInt32(cboTipCenovnika.SelectedValue), Convert.ToInt32(cboKomitent.SelectedValue), Convert.ToDouble(txtCena.Text), Convert.ToInt32(cboVrstaManipulacije.SelectedValue), Convert.ToDateTime(DateTime.Now), KorisnikCene
                txtBrVoza.Text = dr["BrVoza"].ToString();
                txtRelacija.Text = dr["Relacija"].ToString();
                txtKalendarSaobracaja.Text = dr["KalendarSaobracaja"].ToString();
                txtNapomena.Text = dr["Napomena"].ToString();
                dtpVremePolaska.Value = Convert.ToDateTime(dr["VremePolaska"].ToString()); 
                dtpVremeDolaska.Value = Convert.ToDateTime(dr["VremeDolaska"].ToString()); 
                dtpVremeZavrsetkaUtovara.Value = Convert.ToDateTime(dr["VremeZavrsetkaUtovara"].ToString()); 
                dtpVremeZavrsetkaKP.Value = Convert.ToDateTime(dr["VremeZavrsetkaKP"].ToString());
                dtpVremePrimopredaje.Value = Convert.ToDateTime(dr["VremePrimopredaje"].ToString());
                txtMaksBruto.Value = Convert.ToDecimal(dr["MaksimalnaBruto"].ToString());
                txtDuzina.Value = Convert.ToDecimal(dr["MaksimalnaDuzina"].ToString());
                txtMaksBrojKola.Value = Convert.ToDecimal(dr["MaksimalanBrojKola"].ToString());
                if (dr["Dolazeci"].ToString() == "1")
                { chkDolazeci.Checked = true;
                }
                else
                {
                    chkDolazeci.Checked = false;
                }
                if (dr["Ponedeljak"].ToString() == "1")
                { chkPonedeljak.Checked = true; }
                else { chkPonedeljak.Checked = false; }
                if (dr["Utorak"].ToString() == "1")
                { chkUtorak.Checked = true; }
                else { chkUtorak.Checked = false; }
                if (dr["Sreda"].ToString() == "1")
                { chkSreda.Checked = true; }
                else { chkSreda.Checked = false; }
                if (dr["Cetvrtak"].ToString() == "1")
                { chkCetvrtak.Checked = true; }
                else { chkCetvrtak.Checked = false; }
                if (dr["Petak"].ToString() == "1")
                { chkPetak.Checked = true; }
                else { chkPetak.Checked = false; }
                if (dr["Subota"].ToString() == "1")
                { chkSubota.Checked = true; }
                else { chkSubota.Checked = false; }
                if (dr["Nedelja"].ToString() == "1")
                { chkNedelja.Checked = true; }
                else { chkNedelja.Checked = false; }
                txtPostNaTerminalD.Value = Convert.ToInt32(dr["PostNaTerminalD"].ToString());
                txtKontrolniPregledD.Value = Convert.ToInt32(dr["KontrolniPregledD"].ToString());
                txtVremeIstovaraD.Value = Convert.ToInt32(dr["VremeIstovaraD"].ToString());
                 txtVremePrimopredajeD.Value = Convert.ToInt32(dr["VremePrimopredajeD"].ToString());
                 txtPostNaTerminalO.Value = Convert.ToInt32(dr["PostNaTerminalO"].ToString());
                txtPostNaTerminalO.Value = Convert.ToInt32(dr["PostNaTerminalO"].ToString());
                 txtVremeUtovaraO.Value = Convert.ToInt32(dr["VremeUtovaraO"].ToString());
                 txtVremeKontrolnogO.Value = Convert.ToInt32(dr["VremeKontrolnogO"].ToString());
                 txtVremeIzvlacenjaO.Value = Convert.ToInt32(dr["VremeIzvlacenjaO"].ToString());
                 if (dr["VremePolaskaO"].ToString() == "")
                    dtpVremePolaskaO.Value = dtpVremePolaskaO.MinDate;
                else
                dtpVremePolaskaO.Value = Convert.ToDateTime(dr["VremePolaskaO"].ToString());
                 if (dr["VremeDolaskaO"].ToString() == "")
                    dtpVremeDolaskaO.Value = dtpVremeDolaskaO.MinDate;
                else
                dtpVremeDolaskaO.Value = Convert.ToDateTime(dr["VremeDolaskaO"].ToString());

                cboStanicaOd.SelectedValue = Convert.ToInt32(dr["StanicaOd"].ToString());
                cboStanicaDo.SelectedValue = Convert.ToInt32(dr["StanicaDo"].ToString());
            }
            if (chkDolazeci.Checked == true)
            {
                dtpVremePolaska.Enabled = true;
                dtpVremeDolaska.Enabled = true;
                txtPostNaTerminalD.Enabled = true;
                txtKontrolniPregledD.Enabled = true;
                txtVremeIstovaraD.Enabled = true;
                txtVremePrimopredajeD.Enabled = true;
                txtPostNaTerminalO.Enabled = false;
                txtPostNaTerminalO.Enabled = false;
                txtVremeUtovaraO.Enabled = false;
                txtVremeKontrolnogO.Enabled = false;
                txtVremeIzvlacenjaO.Enabled = false;
                dtpVremePolaskaO.Enabled = false;
                dtpVremeDolaskaO.Enabled = false;
            }
            else
            {
                dtpVremePolaska.Enabled = false;
                dtpVremeDolaska.Enabled = false;
                txtPostNaTerminalD.Enabled = false;
                txtKontrolniPregledD.Enabled = false;
                txtVremeIstovaraD.Enabled = false;
                txtVremePrimopredajeD.Enabled = false;
                txtPostNaTerminalO.Enabled = true;
                txtPostNaTerminalO.Enabled = true;
                txtVremeUtovaraO.Enabled = true;
                txtVremeKontrolnogO.Enabled = true;
                txtVremeIzvlacenjaO.Enabled = true;
                dtpVremePolaskaO.Enabled = true;
                dtpVremeDolaskaO.Enabled = true;
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
                        VratiUkupanBrojKontejnera();
                        RefreshDataGrid2();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Voz", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }
        private void frmVoz_Load(object sender, EventArgs e)
        {
            var select = " Select Distinct ID, Rtrim(Opis) as Opis  From Stanice";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboStanicaOd.DataSource = ds.Tables[0];
            cboStanicaOd.DisplayMember = "Opis";
            cboStanicaOd.ValueMember = "ID";

            var select2 = " Select Distinct ID, Rtrim(Opis) as Opis  From Stanice";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboStanicaDo.DataSource = ds2.Tables[0];
            cboStanicaDo.DisplayMember = "Opis";
            cboStanicaDo.ValueMember = "ID";


            var select3 = "  Select Distinct ID, (Naziv + ' BRK: ' + Cast(Broj20 as nvarchar(10))) as Naziv  From SerijeKola";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection2);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboSerijaKola.DataSource = ds3.Tables[0];
            cboSerijaKola.DisplayMember = "Naziv";
            cboSerijaKola.ValueMember = "ID";

            //cboSerijaKola

            RefreshDataGrid();
        }

        private void btnUbaciRelaciju_Click(object sender, EventArgs e)
        {
            txtRelacija.Text = cboStanicaOd.Text + '-' + cboStanicaDo.Text;
        }

        private void chkDolazeci_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDolazeci.Checked == true)
            {
                dtpVremePolaska.Enabled = true;
                dtpVremeDolaska.Enabled = true;
                txtPostNaTerminalD.Enabled = true;
                txtKontrolniPregledD.Enabled = true;
                txtVremeIstovaraD.Enabled = true;
                txtVremePrimopredajeD.Enabled = true;
                txtPostNaTerminalO.Enabled = false;
                txtPostNaTerminalO.Enabled = false;
                txtVremeUtovaraO.Enabled = false;
                txtVremeKontrolnogO.Enabled = false;
                txtVremeIzvlacenjaO.Enabled = false;
                dtpVremePolaskaO.Enabled = false;
                dtpVremeDolaskaO.Enabled = false;
                }
                else
	            {
                dtpVremePolaska.Enabled = false;
                dtpVremeDolaska.Enabled = false;
                txtPostNaTerminalD.Enabled = false;
                txtKontrolniPregledD.Enabled = false;
                txtVremeIstovaraD.Enabled = false;
                txtVremePrimopredajeD.Enabled = false;
                txtPostNaTerminalO.Enabled = true;
                txtPostNaTerminalO.Enabled = true;
                txtVremeUtovaraO.Enabled = true;
                txtVremeKontrolnogO.Enabled = true;
                txtVremeIzvlacenjaO.Enabled = true;
                dtpVremePolaskaO.Enabled = true;
                dtpVremeDolaskaO.Enabled = true;
	            } 
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            status = true;
            dtpVremePolaska.Value = DateTime.Today;
            dtpVremeDolaska.Value = DateTime.Today;
            dtpVremePolaskaO.Value = DateTime.Today;
            dtpVremeDolaskaO.Value = DateTime.Today;
            dtpVremePrimopredaje.Value = DateTime.Today;
            dtpVremeZavrsetkaKP.Value = DateTime.Today;
            dtpVremeZavrsetkaUtovara.Value = DateTime.Today;
            txtSifra.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpVremePolaska.Value = DateTime.Today;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dtpVremeDolaska.Value = DateTime.Today;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtpVremePolaskaO.Value = DateTime.Today;
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtpVremeDolaskaO.Value = DateTime.Today;
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InsertVoz ins = new InsertVoz();
            ins.InsSerijeKola(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboSerijaKola.SelectedValue),  Convert.ToInt32(nmBrojSerija.Value));
            RefreshDataGrid2();
            VratiUkupanBrojKontejnera();
        }
        private void RefreshDataGrid2()
        {
            var select = "  select SerijeKola.ID as Zapis, IDVoza, VozSerijeKola.TipKontejnera as IDT, Naziv, Broj20 as Nosivost20, BrojSerija from VozSerijeKola " + 
 " inner join SerijeKola on SerijeKola.Id = VozSerijeKola.TipKontejnera where IDVoza = " + Convert.ToInt32(txtSifra.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

         
            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "ID Voza";
            dataGridView2.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "TSV";
            dataGridView2.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Naziv serije";
            dataGridView2.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Nosivost 20 ST";
            dataGridView2.Columns[4].Width = 50;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            InsertVoz ins = new InsertVoz();
            ins.DelSerijeKola(Convert.ToInt32(txtSifraSerijeKola.Text));
            RefreshDataGrid2();
            VratiUkupanBrojKontejnera();
        }

        private void VratiUkupanBrojKontejnera()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select isnull(SUM(Broj20 * VozSerijeKola.BrojSerija),0) as BrojKontejnera from VozSerijeKola " +
            " inner join SerijeKola on SerijeKola.Id = VozSerijeKola.TipKontejnera where IDVoza = " + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                nmrUkupanBrojKontejnera.Value = Convert.ToInt32(dr["BrojKontejnera"].ToString());
            }

            con.Close();

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifraSerijeKola.Text = row.Cells[0].Value.ToString();
                        cboSerijaKola.SelectedValue = Convert.ToInt32(row.Cells[2].Value.ToString());
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {

        }
    }
}
