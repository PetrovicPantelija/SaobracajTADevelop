﻿using System;
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

namespace TrackModal.Promet
{
    public partial class frmSkladisteOtprema : Form
    {
        string KorisnikCene;
        // bool status = false;
        bool usao = false;
        public frmSkladisteOtprema()
        {
            InitializeComponent();
        }
        public frmSkladisteOtprema(string Korisnik)
        {
            KorisnikCene = Korisnik;
            InitializeComponent();
        }

        private void frmSkladisteOtprema_Load(object sender, EventArgs e)
        {
            dtpDatumOtpreme.Value = DateTime.Now;
            dtpDatumRasporeda.Value = DateTime.Now;
            var select = " select OtpremaKontejnera.ID,  (Cast(OtpremaKontejnera.ID as nvarchar(5)) + '-' + Relacija + '-' + Cast(Cast(OtpremaKontejnera.VremeOdlaska as DateTime) as Nvarchar(12))) as IDVoza from OtpremaKontejnera " +
         " inner join Voz on Voz.ID = OtpremaKontejnera.IdVoza " +
         " where OtpremaKontejnera.StatusOtpreme = 1 and OtpremaKontejnera.NacinOtpreme = 1 order by OtpremaKontejnera.VremeOdlaska desc";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboOtpremaVozom.DataSource = ds.Tables[0];
            cboOtpremaVozom.DisplayMember = "IDVoza";
            cboOtpremaVozom.ValueMember = "ID";

            var select2 = "select OtpremaKontejnera.ID,  (Cast(OtpremaKontejnera.ID as nvarchar(15)) + '-' + Cast(OtpremaKontejnera.RegBrKamiona as nvarchar(15)) + '-'  + Cast(ImeVozaca as Nvarchar(12))+ '-' + Cast(Cast(OtpremaKontejnera.VremeOdlaska as DateTime) as Nvarchar(12))) as IDVoza from OtpremaKontejnera " +
          " where OtpremaKontejnera.StatusOtpreme = 1 and NacinOtpreme = 0 order by OtpremaKontejnera.VremeOdlaska desc";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboOtpremaKamionom.DataSource = ds2.Tables[0];
            cboOtpremaKamionom.DisplayMember = "IDVoza";
            cboOtpremaKamionom.ValueMember = "ID";

            var select3 = " Select Distinct ID, Naziv   From Skladista";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboSkladiste.DataSource = ds3.Tables[0];
            cboSkladiste.DisplayMember = "Naziv";
            cboSkladiste.ValueMember = "ID";

            var select33 = " Select Distinct ID, Naziv   From Skladista";
            var s_connection33 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection33 = new SqlConnection(s_connection33);
            var c33 = new SqlConnection(s_connection33);
            var dataAdapter33 = new SqlDataAdapter(select33, c33);

            var commandBuilder33 = new SqlCommandBuilder(dataAdapter33);
            var ds33 = new DataSet();
            dataAdapter33.Fill(ds33);
            cboSkladisteU.DataSource = ds33.Tables[0];
            cboSkladisteU.DisplayMember = "Naziv";
            cboSkladisteU.ValueMember = "ID";


            var select4 = " Select Distinct ID, (Naziv + ' RB:' +  RegistarskaOznaka + ' IB:' + IndividualniBroj) as Naziv   From Vozila";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboSredstvoRada.DataSource = ds4.Tables[0];
            cboSredstvoRada.DisplayMember = "Naziv";
            cboSredstvoRada.ValueMember = "ID";


            var select5 = " Select Distinct ID, (Cast(ID as nvarchar(5)) + ' ' + Rtrim(Prezime) + ' ' + Rtrim(Ime)) as Naziv   From Zaposleni";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboZaposleni.DataSource = ds5.Tables[0];
            cboZaposleni.DisplayMember = "Naziv";
            cboZaposleni.ValueMember = "ID";

            usao = true;
            VratiPodatkeMaxSledeci();
        }

        private void VratiPodatkeMase()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select sum(SopstvenaMasa) as SopM, sum(Tara) as Tara, Sum(Neto) as Neto, (sum(SopstvenaMasa)+sum(Tara)+Sum(Neto))  as Bruto from OtpremaKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboOtpremaVozom.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSopstvenaMasa.Value = Convert.ToDecimal(dr["SopM"].ToString());
                txtTara.Value = Convert.ToDecimal(dr["Tara"].ToString());
                txtNeto.Value = Convert.ToDecimal(dr["Neto"].ToString());
                txtBruto.Value = Convert.ToDecimal(dr["Bruto"].ToString());
                // txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void VratiPodatkeMaxSledeci()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select (Max([PrStDokumenta]) + 1) as ID from Promet where VrstaDokumenta = 'PRI'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            chkVoz.Checked = true;
            var select = "   Select BrojKontejnera, IDNAdredjenog as Dokument, OtpremaKontejneraVozStavke.ID as RB, TipKontenjera.Naziv, VrstaRobe.Nkm as NHM, VrstaRobe.Naziv as BrojStavka, OtpremaKontejneraVozStavke.SopstvenaMasa, OtpremaKontejneraVozStavke.Tara, OtpremaKontejneraVozStavke.Neto, (OtpremaKontejneraVozStavke.Tara + OtpremaKontejneraVozStavke.Neto) as Bruto    From OtpremaKontejneraVozStavke " +
 " inner join TipKontenjera on TipKontenjera.Id = OtpremaKontejneraVozStavke.TipKontejnera " +
 " inner join OtpremaKontejnera on OtpremaKontejnera.Id = OtpremaKontejneraVozStavke.IDNadredjenog " +
 " inner join VrstaRobe on VrstaRobe.Id = OtpremaKontejneraVozStavke.VrstaRobe where OtpremaKontejnera.NacinOtpreme = 1 and IDNadredjenog = " + Convert.ToInt32(cboOtpremaVozom.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[0].Width = 100;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Dokument Otpreme";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Broj stavke";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Tip kont";
            dataGridView1.Columns[3].Width = 70;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "NHM";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Naziv robe";
            dataGridView1.Columns[5].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Sopstv masa";
            dataGridView1.Columns[6].Width = 70;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Tara";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Neto";
            dataGridView1.Columns[8].Width = 70;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Bruto";
            dataGridView1.Columns[9].Width = 70;

            PostaviDatumPrijemaVoz();
            VratiPodatkeMase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chkVoz.Checked = false;
            var select = "   Select BrojKontejnera, IDNAdredjenog as Dokument, OtpremaKontejneraVozStavke.ID as RB, TipKontenjera.Naziv, VrstaRobe.Nkm as NHM, VrstaRobe.Naziv as BrojStavka, OtpremaKontejneraVozStavke.SopstvenaMasa, OtpremaKontejneraVozStavke.Tara, OtpremaKontejneraVozStavke.Neto, (OtpremaKontejneraVozStavke.Tara + OtpremaKontejneraVozStavke.Neto) as Bruto    From OtpremaKontejneraVozStavke " +
             " inner join TipKontenjera on TipKontenjera.Id = OtpremaKontejneraVozStavke.TipKontejnera " +
             " inner join OtpremaKontejnera on OtpremaKontejnera.Id = OtpremaKontejneraVozStavke.IDNadredjenog " +
             " inner join VrstaRobe on VrstaRobe.Id = OtpremaKontejneraVozStavke.VrstaRobe where OtpremaKontejnera.NacinOtpreme = 0 and IDNadredjenog = " + Convert.ToInt32(cboOtpremaKamionom.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            // var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[0].Width = 100;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Dokument Otprema voza";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Broj stavke";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Tip kont";
            dataGridView1.Columns[3].Width = 70;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "NHM";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Naziv robe";
            dataGridView1.Columns[5].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Sopstv masa";
            dataGridView1.Columns[6].Width = 70;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Tara";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Neto";
            dataGridView1.Columns[8].Width = 70;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Bruto";
            dataGridView1.Columns[9].Width = 70;

            PostaviDatumPrijemaKamion();
        }

        private void PostaviDatumPrijemaVoz()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select VremeOdlaska from OtpremaKontejnera where ID = " + Convert.ToInt32(cboOtpremaVozom.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dtpDatumOtpreme.Value = Convert.ToDateTime(dr["VremeOdlaska"].ToString());
            }

            con.Close();
        }

        private void PostaviDatumPrijemaKamion()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select VremeOdlaska from OtpremaKontejnera where ID = " + Convert.ToInt32(cboOtpremaKamionom.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dtpDatumOtpreme.Value = Convert.ToDateTime(dr["VremeOdlaska"].ToString());
            }

            con.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    var select = "";
                   
                        select = "  select BrojKontejnera, VrstaManipulacije.Naziv, Komitenti.Naziv, NaruceneManipulacije.ID as NM, NaruceneManipulacije.IDPrijemaVoza, VrstaManipulacije.ID from NaruceneManipulacije " +
            " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
            " inner join Komitenti on  NaruceneManipulacije.Platilac = Komitenti.ID " +
            " where NaruceneManipulacije.IzPrijema = 0 and BrojKontejnera = '" + row.Cells[0].Value.ToString() + "'";
                   
                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection myConnection = new SqlConnection(s_connection);
                    var c = new SqlConnection(s_connection);
                    var dataAdapter = new SqlDataAdapter(select, c);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView3.ReadOnly = true;
                    dataGridView3.DataSource = ds.Tables[0];

                    //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
                    DataGridViewColumn column = dataGridView3.Columns[0];
                    dataGridView3.Columns[0].HeaderText = "Broj kontejnera";
                    dataGridView3.Columns[0].Width = 80;

                    DataGridViewColumn column1 = dataGridView3.Columns[1];
                    dataGridView3.Columns[1].HeaderText = "Manipulacija";
                    dataGridView3.Columns[1].Width = 200;

                    DataGridViewColumn column2 = dataGridView3.Columns[2];
                    dataGridView3.Columns[2].HeaderText = "Platilac";
                    dataGridView3.Columns[2].Width = 170;

                    DataGridViewColumn column3 = dataGridView3.Columns[3];
                    dataGridView3.Columns[3].HeaderText = "Naručene Man ID";
                    dataGridView3.Columns[3].Width = 60;

                    DataGridViewColumn column4 = dataGridView3.Columns[4];
                    dataGridView3.Columns[4].HeaderText = "Nar ID pr vozom";
                    dataGridView3.Columns[4].Width = 100;
                }
            }

            txtTara.Text = "0";
            txtNeto.Text = "0";
            txtBruto.Text = "0";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Selected)
                {
                    //Panta1
                    txtTara.Text = (Convert.ToDecimal(txtTara.Text) + Convert.ToDecimal(row.Cells[7].Value.ToString())).ToString();
                    txtNeto.Text = (Convert.ToDecimal(txtNeto.Text) + Convert.ToDecimal(row.Cells[8].Value.ToString())).ToString();
                    txtBruto.Text = (Convert.ToDecimal(txtBruto.Text) + Convert.ToDecimal(row.Cells[9].Value.ToString())).ToString();
                }
            }
        }

        private void cboSkladiste_SelectedValueChanged(object sender, EventArgs e)
        {
            if (usao == true)
            {
                var select = " Select ID, Oznaka From Pozicija where Skladiste = " + Convert.ToInt32(cboSkladiste.SelectedValue);
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                cboPozicija.DataSource = ds.Tables[0];
                cboPozicija.DisplayMember = "Oznaka";
                cboPozicija.ValueMember = "ID";
            }
        }

        private void cboSkladisteU_SelectedValueChanged(object sender, EventArgs e)
        {
            if (usao == true)
            {
                var select = " Select ID, Oznaka From Pozicija where Skladiste = " + Convert.ToInt32(cboSkladisteU.SelectedValue);
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                cboPozicijaU.DataSource = ds.Tables[0];
                cboPozicijaU.DisplayMember = "Oznaka";
                cboPozicijaU.ValueMember = "ID";
            }
        }
        private void RefreshDataGrid2()
        {
            var select = "  SELECT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
             " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
             " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
             " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
             " ,Promet.[Datum] ,Promet.[Korisnik] " +
             " FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
             " inner join Pozicija on Promet.LokacijaU = Pozicija.ID  where PrstDokumenta = " + Convert.ToInt32(txtSifra.Text);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "Šifra";
            dataGridView2.Columns[0].Width = 40;
            // dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Datum Transakcije";
            dataGridView2.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Vrsta Dokumenta";
            dataGridView2.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Br Dokumenta";
            dataGridView2.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Vrsta Prometa";
            dataGridView2.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Broj kontejnera";
            dataGridView2.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "PrPrimKol";
            dataGridView2.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "SkladID ";
            dataGridView2.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "Skladiste u";
            dataGridView2.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "LokacID ";
            dataGridView2.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView2.Columns[10];
            dataGridView2.Columns[10].HeaderText = "Lokac U";
            dataGridView2.Columns[10].Width = 80;

            DataGridViewColumn column12 = dataGridView2.Columns[11];
            dataGridView2.Columns[11].HeaderText = "Oznaka sled";
            dataGridView2.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView2.Columns[12];
            dataGridView2.Columns[12].HeaderText = "Datum";
            dataGridView2.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView2.Columns[13];
            dataGridView2.Columns[13].HeaderText = "Korisnik";
            dataGridView2.Columns[13].Width = 80;

        }
        private void btnUbaci_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Dokumeta.InsertPromet ins = new Dokumeta.InsertPromet();
                int pom1 = 1;
                //int pom2 = 0;
                int pom3 = 1;
                string s1 = "MSP";
                string s2 = "MSP";

                if (row.Selected == true)
                {
                    string poms = row.Cells[2].Value.ToString();
                    int pozicija = Convert.ToInt32(cboPozicija.SelectedValue);
                    int pozicija2 = Convert.ToInt32(cboPozicijaU.SelectedValue);
                    /*
                      SELECT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " + 
            " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
            " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
            " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
            " ,Promet.[Datum] ,Promet.[Korisnik]
                      */
                    ins.InsProm(Convert.ToDateTime(dtpDatumOtpreme.Value), s1, Convert.ToInt32(txtSifra.Text), row.Cells[0].Value.ToString(), s2, pom3, pom1, Convert.ToInt32(cboSkladisteU.SelectedValue), pozicija2, Convert.ToInt32(cboSkladiste.SelectedValue), pozicija, poms, Convert.ToDateTime(DateTime.Now), KorisnikCene, 0, 0, Convert.ToDateTime(dtpDatumRasporeda.Value));
                    //ins.UpdateZatvoren(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }
            }
            RefreshDataGrid2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Prevoz = "";
            if (chkVoz.Checked == true)
            {
                Prevoz = cboOtpremaVozom.Text;

            }
            else
            {
                Prevoz =  cboOtpremaKamionom.Text;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Dokumeta.InsertPromet ins = new Dokumeta.InsertPromet();
                if (row.Selected == true)
                {
                    string poms = row.Cells[2].Value.ToString();
                    int NajavaID = Convert.ToInt32(row.Cells[1].Value.ToString());

                    foreach (DataGridViewRow rowM in dataGridView3.Rows)
                    {
                        if (rowM.Selected == true)
                        {
                            ins.InsPromMan(Convert.ToInt32(txtSifra.Text), rowM.Cells[0].Value.ToString(), Convert.ToInt32(rowM.Cells[6].Value.ToString()), Convert.ToInt32(rowM.Cells[3].Value.ToString()), Convert.ToInt32(cboSredstvoRada.SelectedValue), Convert.ToInt32(cboZaposleni.SelectedValue), Convert.ToDateTime(DateTime.Now), KorisnikCene, cboSkladiste.Text, cboPozicija.Text, Prevoz, "");
                        }
                    }


                }
            }
            RefreshDataGrid4();
        }
        private void RefreshDataGrid4()
        {
            var select = "SELECT PrometManipulacije.Id AS ID, PrometManipulacije.PRStDokumenta, PrometManipulacije.BrojKontejnera AS BrojKontrejnera, PrometManipulacije.ManipulacijaID, PrometManipulacije.NajavaID, " +
                       " PrometManipulacije.Datum AS Datum, PrometManipulacije.Korisnik AS Korisnik, Zaposleni.Prezime, Zaposleni.Ime, Vozila.Naziv " +
                       " FROM  PrometManipulacije INNER JOIN " +
                      "  Zaposleni ON PrometManipulacije.Zaposleni = Zaposleni.ID INNER JOIN " +
                       " Vozila ON PrometManipulacije.SredstvoRada = Vozila.ID  and PrStDokumenta =  " + Convert.ToInt32(txtSifra.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = false;
            dataGridView4.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView4.Columns[0];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[0].Width = 40;
            // dataGridView2.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView4.Columns[1];
            dataGridView4.Columns[1].HeaderText = "Dokument";
            dataGridView4.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView4.Columns[2];
            dataGridView4.Columns[2].HeaderText = "Broj kontejnera";
            dataGridView4.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView4.Columns[3];
            dataGridView4.Columns[3].HeaderText = "MAN id";
            dataGridView4.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView4.Columns[4];
            dataGridView4.Columns[4].HeaderText = "NAJ ID";
            dataGridView4.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView4.Columns[5];
            dataGridView4.Columns[5].HeaderText = "Datum";
            dataGridView4.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView4.Columns[6];
            dataGridView4.Columns[6].HeaderText = "Korisnik";
            dataGridView4.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView4.Columns[7];
            dataGridView4.Columns[7].HeaderText = "Prezime ";
            dataGridView4.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView4.Columns[8];
            dataGridView4.Columns[8].HeaderText = "Ime";
            dataGridView4.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView4.Columns[9];
            dataGridView4.Columns[9].HeaderText = "Sredstvo rada";
            dataGridView4.Columns[9].Width = 80;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Dokumeta.InsertPromet ins = new Dokumeta.InsertPromet();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected == true)
                    {

                        ins.DeleteProm(Convert.ToInt32(row.Cells[0].Value));

                    }
                }
                RefreshDataGrid2();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Dokumeta.InsertPromet del = new Dokumeta.InsertPromet();
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.Selected == true)
                    {
                        del.DeletePromManipulacije(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                }
                RefreshDataGrid4();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string broj = txtSifra.Text;
            Promet.frmPregledOtprema sr = new Promet.frmPregledOtprema(broj);
            sr.Show();
        }
    }
}
