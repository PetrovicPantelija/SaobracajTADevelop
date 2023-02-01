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
using System.Diagnostics.CodeAnalysis;

namespace Saobracaj.Uvoz
{
    public partial class frmPrijemVozaIzPlana : Form
    {
        bool status = false;
        string KorisnikCene = "Panta";
        public string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        public frmPrijemVozaIzPlana()
        {
            InitializeComponent();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
          
            dtpDatumPrijema.Value = DateTime.Now;
            dtpDatumPrijema.Enabled = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                /// ,  string RegBrKamiona,   string ImeVozaca,   int Vozom
                Dokumeta.InsertPrijemKontejneraVoz ins = new Dokumeta.InsertPrijemKontejneraVoz();
                ins.InsertPrijemKontVoz(Convert.ToDateTime(dtpDatumPrijema.Text), Convert.ToInt32(cboStatusPrijema.SelectedIndex), Convert.ToInt32(cboBukingPrijema.SelectedValue), Convert.ToDateTime(dtpVremeDolaska.Value), Convert.ToDateTime(DateTime.Now), KorisnikCene, "", "", 1, txtNapomena.Text, Convert.ToInt32(cboPredefinisanePoruke.SelectedValue));
                status = false;
                VratiPodatkeMax();
            }
            else
            {
                //int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik
                Dokumeta.InsertPrijemKontejneraVoz upd = new Dokumeta.InsertPrijemKontejneraVoz();
                upd.UpdPrijemKontejneraVoz(Convert.ToInt32(txtSifra.Text), Convert.ToDateTime(dtpDatumPrijema.Text), Convert.ToInt32(cboStatusPrijema.SelectedIndex), Convert.ToInt32(cboBukingPrijema.SelectedValue), Convert.ToDateTime(dtpVremeDolaska.Value), Convert.ToDateTime(DateTime.Now), KorisnikCene, "", "", 1, txtNapomena.Text, Convert.ToInt32(cboPredefinisanePoruke.SelectedValue));
                status = false;
            }
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from PrijemKontejneraVoz", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void VratiVozIzPlana()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();



         

            SqlCommand cmd = new SqlCommand("Select Top 1 IDVoza from UvozKonacnaZaglavlje where ID = " + Convert.ToInt32(cboPlanUtovara.SelectedValue));
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cboBukingPrijema.SelectedValue = Convert.ToInt32(dr["IDVoza"].ToString());
            }

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VratiVozIzPlana();
            
        }

        private void frmPrijemVozaIzPlana_Load(object sender, EventArgs e)
        {
            var planutovara = "select UvozKonacnaZaglavlje.ID,(Cast(BrVoza as nvarchar(15)) + ' '  + Relacija) as Naziv from UvozKonacnaZaglavlje " +
          " inner join Voz on Voz.Id = UvozKonacnaZaglavlje.IdVoza order by UvozKonacnaZaglavlje.ID desc";
            var planutovaraSAD = new SqlDataAdapter(planutovara, connection);
            var planutovaraSDS = new DataSet();
            planutovaraSAD.Fill(planutovaraSDS);
            cboPlanUtovara.DataSource = planutovaraSDS.Tables[0];
            cboPlanUtovara.DisplayMember = "Naziv";
            cboPlanUtovara.ValueMember = "ID";

            var select8 = "  Select Distinct ID, (Cast(BrVoza as nvarchar(6)) + '-' + Relacija) as IdVoza   From Voz ";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboBukingPrijema.DataSource = ds8.Tables[0];
            cboBukingPrijema.DisplayMember = "IdVoza";
            cboBukingPrijema.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertUvozKonacna ins = new InsertUvozKonacna();
            ins.PrenesiPlanUtovaraUPrijemVoz(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboPlanUtovara.SelectedValue));
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            var select = "  SELECT         PrijemKontejneraVozStavke.ID, PrijemKontejneraVozStavke.RB, PrijemKontejneraVozStavke.IDNadredjenog, "+
 " PrijemKontejneraVozStavke.BrojKontejnera, PrijemKontejneraVozStavke.BrojVagona, PrijemKontejneraVozStavke.Granica, "+
  "  PrijemKontejneraVozStavke.BrojOsovina, PrijemKontejneraVozStavke.SopstvenaMasa, PrijemKontejneraVozStavke.Tara," +
  "   PrijemKontejneraVozStavke.Neto, Partnerji.PaNaziv AS Posiljalac, Partnerji_1.PaNaziv AS primalac, " +
   "   Partnerji_2.PaNaziv AS Vlasnikkontejnera, TipKontenjera.Naziv AS TipKontejnera, NHM.Naziv AS VrstaRobe," +
  "     PrijemKontejneraVozStavke.BukingBrodar AS BukingBrodar, PrijemKontejneraVozStavke.StatusKontejnera," +
   "      PrijemKontejneraVozStavke.BrojPlombe, PrijemKontejneraVozStavke.BrojPlombe2,PrijemKontejneraVozStavke.PlaniraniLager, " +
   "       PrijemKontejneraVozStavke.VremeDolaska, PrijemKontejneraVozStavke.VremePripremljen,  PrijemKontejneraVozStavke.VremeOdlaska," +
   "        PrijemKontejneraVozStavke.Datum, PrijemKontejneraVozStavke.Korisnik, PrijemKontejneraVozStavke.NapomenaS" +
   "         FROM            Partnerji INNER JOIN PrijemKontejneraVozStavke" +
    "        ON Partnerji.PaSifra = PrijemKontejneraVozStavke.Posiljalac INNER JOIN" +
    "         Partnerji AS Partnerji_1 ON PrijemKontejneraVozStavke.Primalac = " +
    "         Partnerji_1.PaSifra" +
     "        INNER JOIN  Partnerji AS Partnerji_2" +
       "      ON PrijemKontejneraVozStavke.VlasnikKontejnera = Partnerji_2.PaSifra INNER JOIN TipKontenjera" +
       "       ON PrijemKontejneraVozStavke.TipKontejnera = TipKontenjera.ID" +
      "        INNER JOIN  NHM ON PrijemKontejneraVozStavke.VrstaRobe = NHM.ID" +
       "       INNER JOIN  Voz ON PrijemKontejneraVozStavke.IdVoza = Voz.ID " + 
                           " where IdNadredjenog = " + txtSifra.Text + " order by RB";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = false;
            dataGridView1.DataSource = ds.Tables[0];

            //Panta refresh

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Br Dok";
            dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[3].Width = 110;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Broj Vagona";
            dataGridView1.Columns[4].Width = 110;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Granica";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Br os";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Sops masa";
            dataGridView1.Columns[7].Width = 50;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Tara";
            dataGridView1.Columns[8].Width = 70;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Neto";
            dataGridView1.Columns[9].Width = 70;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Posiljalac";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Primalac";
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Vlasnik";
            dataGridView1.Columns[12].Width = 40;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Tip kontejnera";
            dataGridView1.Columns[13].Width = 70;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "NHM";
            dataGridView1.Columns[14].Width = 40;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Buking broldar";
            dataGridView1.Columns[15].Width = 70;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Status Kontejnera";
            dataGridView1.Columns[16].Width = 20;

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Br plombe";
            dataGridView1.Columns[17].Width = 90;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Br plombe2";
            dataGridView1.Columns[18].Width = 9;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Plan lager";
            dataGridView1.Columns[19].Width = 30;

            DataGridViewColumn column21 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Vreme dolaska";
            dataGridView1.Columns[20].Width = 70;

            DataGridViewColumn column22 = dataGridView1.Columns[21];
            dataGridView1.Columns[21].HeaderText = "Vreme prip";
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[21].Width = 70;

            DataGridViewColumn column23 = dataGridView1.Columns[22];
            dataGridView1.Columns[22].HeaderText = "Vreme odlaska";
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[22].Width = 70;

            DataGridViewColumn column24 = dataGridView1.Columns[23];
            dataGridView1.Columns[23].HeaderText = "Datum";
            dataGridView1.Columns[23].Width = 70;

            DataGridViewColumn column25 = dataGridView1.Columns[24];
            dataGridView1.Columns[24].HeaderText = "Korisnik";
            dataGridView1.Columns[24].Width = 70;

            DataGridViewColumn column26 = dataGridView1.Columns[25];
            dataGridView1.Columns[25].HeaderText = "Napomena stav";
            dataGridView1.Columns[25].Width = 70;


        }


    }
}
