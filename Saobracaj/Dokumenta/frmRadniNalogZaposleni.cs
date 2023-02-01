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
    public partial class frmRadniNalogZaposleni : Form
    {
        bool status = false;
        int pomTrasa = 0;
        int pomMasinovodja = 0;
        int pomPomocnik = 0;
        int pomVozovodja = 0;
        int pomPregledac = 0;

        public frmRadniNalogZaposleni()
        {
            InitializeComponent();
        }

        public frmRadniNalogZaposleni(string RadniNalog, string Voznja, Int32 Trasa)
        {
            InitializeComponent();
            txtSifraRN.Text = RadniNalog;
            txtBrojNajave.Text = Voznja;
            //Ubaciti popunjavanje trasa
            pomTrasa = Trasa;

            RefreshDataGridLoad();
            RefreshDataGrid2Load();
        }

        private void frmRadniNalogZaposleni_Load(object sender, EventArgs e)
        {
            var select = " Select ID, (Rtrim(Voz) + '-' + Rtrim(Relacija)) as Opis from Trase";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboTrase.DataSource = ds.Tables[0];
            cboTrase.DisplayMember = "Opis";
            cboTrase.ValueMember = "ID";

            cboTrase.SelectedValue = pomTrasa;

          

            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci order by opis";
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


            var select4 = "  select ID, Naziv from VrstaAktivnosti " +
          " inner join PravoAktivnosti on VrstaAktivnosti.ID = PravoAktivnosti.VrstaAktivnostiID " +
          " where  PravoAktivnosti.Zaposleni = " + cboZaposleni.SelectedValue;


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

        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (chkMasinovodja.Checked == true)
            { pomMasinovodja = 1; }
            else { pomMasinovodja = 0; }

            if (chkPomocnik.Checked == true)
            { pomPomocnik = 1; }
            else { pomPomocnik = 0; }

            if (chkVozovodja.Checked == true)
            { pomVozovodja = 1; }
            else { pomVozovodja = 0; }

            if (chkPregledac.Checked == true)
            { pomPregledac = 1; }
            else { pomPregledac = 0; }
            InsertRadniNalogZaposleni ins = new InsertRadniNalogZaposleni();
            ins.InsRNTLZ(Convert.ToInt32(txtSifraRN.Text), Convert.ToInt32(cboTrase.SelectedValue), "1", dtpVremeOd.Value, dtpVremeDo.Value, Convert.ToInt32(txtVreme.Text), Convert.ToInt32(cboZaposleni.SelectedValue), pomMasinovodja, pomPomocnik, pomVozovodja, pomPregledac, Convert.ToInt32(cboAktivnost.SelectedValue), txtNapomena.Text);
            RefreshDataGrid();
            status = false;
        }
       
        private void RefreshDataGrid()
        { 
            /*
            SELECT     RadniNalogTraseLokZap.IDRadnogNaloga, RadniNalogTraseLokZap.RB, RadniNalogTraseLokZap.SMSifra, RadniNalogTraseLokZap.DeSifra, 
                      RadniNalogTraseLokZap.DatumPolaska, RadniNalogTraseLokZap.DatumDolaska, RadniNalogTraseLokZap.PlaniranoVreme, Trase.Voz, Delavci.DeSifra AS Expr1, 
                      Delavci.DePriimek, Delavci.DeIme
            FROM         RadniNalogTraseLokZap INNER JOIN
                      Trase ON RadniNalogTraseLokZap.IDTrase = Trase.ID INNER JOIN
                      Delavci ON RadniNalogTraseLokZap.DeSifra = Delavci.DeSifra
            */
            var select = " SELECT     RadniNalogTraseLokZap.IDRadnogNaloga as RN, RadniNalogTraseLokZap.IDTrase as Trasa, RadniNalogTraseLokZap.RB as RB, RadniNalogTraseLokZap.SMSifra, RadniNalogTraseLokZap.DeSifra, Delavci.DePriimek as Prezime, Delavci.DeIme as Ime,  RadniNalogTraseLokZap.DatumPolaska as VremeOd, RadniNalogTraseLokZap.DatumDolaska as VremeDo, RadniNalogTraseLokZap.PlaniranoVreme as Vreme, Trase.Voz  , " +
"  CASE WHEN RadniNalogTraseLokZap.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja, " +
 " (CASE WHEN RadniNalogTraseLokZap.Pomocnik > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  ,  " +
 " (CASE WHEN RadniNalogTraseLokZap.Vozovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END) ,  " +
 " (CASE WHEN RadniNalogTraseLokZap.Pregledac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END), VrstaAktivnosti.Naziv   " +
            " FROM         RadniNalogTraseLokZap INNER JOIN " +
              "        Trase ON RadniNalogTraseLokZap.IDTrase = Trase.ID " +
              "Inner join VrstaAktivnosti On VrstaAktivnosti.ID = RadniNalogTraseLokZap. AktivnostID " +
              "INNER JOIN " +
               "       Delavci ON RadniNalogTraseLokZap.DeSifra = Delavci.DeSifra where RadniNalogTraseLokZap.IDRadnogNaloga =  " + Convert.ToInt32(txtSifraRN.Text) + " and RadniNalogTraseLokZap.IDTrase = " + Convert.ToInt32(cboTrase.SelectedValue) + " order by Delavci.DeSifra";
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
            dataGridView1.Columns[1].HeaderText = "Trasa";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "RB";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Lokomotiva";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Radnik";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Prezime";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ime";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Vreme od";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Vreme do";
            dataGridView1.Columns[8].Width = 100;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Trajanje";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Voz";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Mašinovođa";
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Pomoćnik";
            dataGridView1.Columns[12].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Vozovođa";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Pregledač";
            dataGridView1.Columns[14].Width = 50;

        }

        private void RefreshDataGridLoad()
        {
            /*
            SELECT     RadniNalogTraseLokZap.IDRadnogNaloga, RadniNalogTraseLokZap.RB, RadniNalogTraseLokZap.SMSifra, RadniNalogTraseLokZap.DeSifra, 
                      RadniNalogTraseLokZap.DatumPolaska, RadniNalogTraseLokZap.DatumDolaska, RadniNalogTraseLokZap.PlaniranoVreme, Trase.Voz, Delavci.DeSifra AS Expr1, 
                      Delavci.DePriimek, Delavci.DeIme
            FROM         RadniNalogTraseLokZap INNER JOIN
                      Trase ON RadniNalogTraseLokZap.IDTrase = Trase.ID INNER JOIN
                      Delavci ON RadniNalogTraseLokZap.DeSifra = Delavci.DeSifra
            */
            var select = " SELECT     RadniNalogTraseLokZap.IDRadnogNaloga as RN, RadniNalogTraseLokZap.IDTrase as Trasa, RadniNalogTraseLokZap.RB as RB, RadniNalogTraseLokZap.SMSifra, RadniNalogTraseLokZap.DeSifra, Delavci.DePriimek as Prezime, Delavci.DeIme as Ime,  RadniNalogTraseLokZap.DatumPolaska as VremeOd, RadniNalogTraseLokZap.DatumDolaska as VremeDo, RadniNalogTraseLokZap.PlaniranoVreme as Vreme, Trase.Voz  , " +
            "  CASE WHEN RadniNalogTraseLokZap.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja, " +
             " (CASE WHEN RadniNalogTraseLokZap.Pomocnik > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  ,  " +
            " (CASE WHEN RadniNalogTraseLokZap.Vozovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END) ,  " +
            " (CASE WHEN RadniNalogTraseLokZap.Pregledac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END) , VrstaAktivnosti.Naziv   " +
            " FROM         RadniNalogTraseLokZap " +
            "Inner join VrstaAktivnosti On VrstaAktivnosti.ID = RadniNalogTraseLokZap. AktivnostID " +
            "INNER JOIN " +
              "        Trase ON RadniNalogTraseLokZap.IDTrase = Trase.ID INNER JOIN " +
               "       Delavci ON RadniNalogTraseLokZap.DeSifra = Delavci.DeSifra where RadniNalogTraseLokZap.IDRadnogNaloga =  " + Convert.ToInt32(txtSifraRN.Text) + " and RadniNalogTraseLokZap.IDTrase = " + pomTrasa + " order by Delavci.DeSifra";
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
            dataGridView1.Columns[1].HeaderText = "Trasa";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "RB";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Lokomotiva";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[3].Visible = false;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Radnik";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Prezime";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ime";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Vreme od";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Vreme do";
            dataGridView1.Columns[8].Width = 100;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Trajanje";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Voz";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Mašinovođa";
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Pomoćnik";
            dataGridView1.Columns[12].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Vozovođa";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Pregledač";
            dataGridView1.Columns[14].Width = 50;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUbaci_Click(object sender, EventArgs e)
        {
            int pomDirektna = 0;
            if (chkDirektnaPrimopredaja.Checked == true)
            {
                pomDirektna = 1;
                txtVoznoVreme.Text = Convert.ToString((Convert.ToInt32(txtVoznoVreme.Text) + 60));
                txtJalovoVreme.Text = Convert.ToString((Convert.ToInt32(txtJalovoVreme.Text) - 60));
            }
            InsertRadniNalogZaposleniEvid ins = new InsertRadniNalogZaposleniEvid();
            ins.InsRNTLZEVID(Convert.ToInt32(txtSifraRN.Text), Convert.ToInt32(cboTrase.SelectedValue), "", Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeJavljanja.Value, dtpVremePocetka.Value, pomDirektna,dtpVremePrimopredaja.Value, dtpVremeZavrsetka.Value, Convert.ToInt32(txtVoznoVreme.Text), Convert.ToInt32(txtUkupnoVreme.Text), Convert.ToInt32(txtJalovoVreme.Text), Convert.ToInt32(txtJalovoVremeVV.Text));
            RefreshDataGrid2();
            status = false;
            
        }

        private void RefreshDataGrid2()
        {
            var select = "   SELECT [IDRadnogNaloga] " +
             " ,[RB] ,[IDTrase] ,[SMSifra] ,RadniNalogTraseLokZapEvid.DeSifra,  Delavci.DePriimek as Prezime, Delavci.DeIme as Ime, " +
             " [VremeJavljanja] ,[VremePocetka] " +
             " ,[DirektnaPrimopredaja] ,[VremePrimopredaja] " +
             " ,[VremeZavrsetka] ,[VoznoVreme] " +
             " ,[UkupnoVreme] ,[JalovoVreme] " +
             " ,[JalovoVremeVanVoznje]   FROM [TESTIRANJE].[dbo].[RadniNalogTraseLokZapEvid] " +
            " inner join Delavci on Delavci.DeSifra = RadniNalogTraseLokZapEvid.DeSifra where RadniNalogTraseLokZapEvid.IDRadnogNaloga =  " + Convert.ToInt32(txtSifraRN.Text) + " and RadniNalogTraseLokZapEvid.IDTrase = " + Convert.ToInt32(cboTrase.SelectedValue) + " order by Delavci.DeSifra";
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
            dataGridView2.Columns[0].HeaderText = "RN";
            dataGridView2.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "RB";
            dataGridView2.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Trasa";
            dataGridView2.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Lokomotiva";
            dataGridView2.Columns[3].Width = 70;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Radnik";
            dataGridView2.Columns[4].Width = 30;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Prezime";
            dataGridView2.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "Ime";
            dataGridView2.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "Vreme Javljanja u OJ";
            dataGridView2.Columns[7].Width = 90;

            DataGridViewColumn column9 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "Vreme početka vožnje";
            dataGridView2.Columns[8].Width = 90;

            DataGridViewColumn column10 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "DP";
            dataGridView2.Columns[9].Width = 30;

            DataGridViewColumn column11 = dataGridView2.Columns[10];
            dataGridView2.Columns[10].HeaderText = "Vreme završetka vožnje";
            dataGridView2.Columns[10].Width = 90;

            DataGridViewColumn column12 = dataGridView2.Columns[11];
            dataGridView2.Columns[11].HeaderText = "Vreme povratka u OJ";
            dataGridView2.Columns[11].Width = 90;

            DataGridViewColumn column13 = dataGridView2.Columns[12];
            dataGridView2.Columns[12].HeaderText = "Vozno vreme";
            dataGridView2.Columns[12].Width = 40;

            DataGridViewColumn column14 = dataGridView2.Columns[13];
            dataGridView2.Columns[13].HeaderText = "Vreme trajanja smene";
            dataGridView2.Columns[13].Width = 40;

            DataGridViewColumn column15 = dataGridView2.Columns[14];
            dataGridView2.Columns[14].HeaderText = "Jalovo tokom vožnje";
            dataGridView2.Columns[14].Width = 40;

            DataGridViewColumn column16 = dataGridView2.Columns[15];
            dataGridView2.Columns[15].HeaderText = "Jalovo van vožnje";
            dataGridView2.Columns[15].Width = 40;


           /*
            SELECT [IDRadnogNaloga]
      ,[RB]
      ,[IDTrase]
      ,[SMSifra]
      ,RadniNalogTraseLokZapEvid.DeSifra
      ,[VremeJavljanja]
      ,[VremePocetka]
      ,[DirektnaPrimopredaja]
      ,[VremePrimopredaja]
      ,[VremeZavrsetka]
      ,[VoznoVreme]
      ,[UkupnoVreme]
      ,[JalovoVreme]
      ,[JalovoVremeVanVoznje]
  FROM [TESTIRANJE].[dbo].[RadniNalogTraseLokZapEvid]
  inner join Delavci on Delavci.DeSifra = RadniNalogTraseLokZapEvid.DeSifra

            */


        }

        private void RefreshDataGrid2Load()
        {
            var select = "   SELECT [IDRadnogNaloga] " +
             " ,[RB] ,[IDTrase] ,[SMSifra] ,RadniNalogTraseLokZapEvid.DeSifra,  Delavci.DePriimek as Prezime, Delavci.DeIme as Ime, " +
             " [VremeJavljanja] ,[VremePocetka] " +
             " ,[DirektnaPrimopredaja] ,[VremePrimopredaja] " +
             " ,[VremeZavrsetka] ,[VoznoVreme] " +
             " ,[UkupnoVreme] ,[JalovoVreme] " +
             " ,[JalovoVremeVanVoznje]   FROM [TESTIRANJE].[dbo].[RadniNalogTraseLokZapEvid] " +
            " inner join Delavci on Delavci.DeSifra = RadniNalogTraseLokZapEvid.DeSifra where RadniNalogTraseLokZapEvid.IDRadnogNaloga =  " + Convert.ToInt32(txtSifraRN.Text) + " and RadniNalogTraseLokZapEvid.IDTrase = " + pomTrasa + " order by Delavci.DeSifra";
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
            dataGridView2.Columns[0].HeaderText = "RN";
            dataGridView2.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "RB";
            dataGridView2.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Trasa";
            dataGridView2.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Lokomotiva";
            dataGridView2.Columns[3].Width = 70;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Radnik";
            dataGridView2.Columns[4].Width = 30;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Prezime";
            dataGridView2.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "Ime";
            dataGridView2.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "Vreme Javljanja u OJ";
            dataGridView2.Columns[7].Width = 90;

            DataGridViewColumn column9 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "Vreme početka vožnje";
            dataGridView2.Columns[8].Width = 90;

            DataGridViewColumn column10 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "DP";
            dataGridView2.Columns[9].Width = 30;

            DataGridViewColumn column11 = dataGridView2.Columns[10];
            dataGridView2.Columns[10].HeaderText = "Vreme završetka vožnje";
            dataGridView2.Columns[10].Width = 90;

            DataGridViewColumn column12 = dataGridView2.Columns[11];
            dataGridView2.Columns[11].HeaderText = "Vreme povratka u OJ";
            dataGridView2.Columns[11].Width = 90;

            DataGridViewColumn column13 = dataGridView2.Columns[12];
            dataGridView2.Columns[12].HeaderText = "Vozno vreme";
            dataGridView2.Columns[12].Width = 40;

            DataGridViewColumn column14 = dataGridView2.Columns[13];
            dataGridView2.Columns[13].HeaderText = "Vreme trajanja smene";
            dataGridView2.Columns[13].Width = 40;

            DataGridViewColumn column15 = dataGridView2.Columns[14];
            dataGridView2.Columns[14].HeaderText = "Jalovo tokom vožnje";
            dataGridView2.Columns[14].Width = 40;

            DataGridViewColumn column16 = dataGridView2.Columns[15];
            dataGridView2.Columns[15].HeaderText = "Jalovo van vožnje";
            dataGridView2.Columns[15].Width = 40;
        }

        private void dtpVremeDo_Leave(object sender, EventArgs e)
        {
            TimeSpan span = dtpVremeDo.Value.Subtract(dtpVremeOd.Value);
            txtVreme.Text = Convert.ToString(Convert.ToInt32(span.TotalMinutes));
        }

        private void dtpVremePrimopredaja_Leave(object sender, EventArgs e)
        {
            TimeSpan span = dtpVremePrimopredaja.Value.Subtract(dtpVremePocetka.Value);
            txtUkupnoVreme.Text = Convert.ToString(Convert.ToInt32(span.TotalMinutes));
        }

        private void dtpVremeZavrsetka_Leave(object sender, EventArgs e)
        {
            TimeSpan pom1 = dtpVremePocetka.Value.Subtract(dtpVremeJavljanja.Value);
            int Jalovo1 = Convert.ToInt32(pom1.TotalMinutes);

            TimeSpan pom2 = dtpVremeZavrsetka.Value.Subtract(dtpVremePrimopredaja.Value);
            int Jalovo2 = Convert.ToInt32(pom2.TotalMinutes);


            int UkupnoJalovo = Jalovo1 + Jalovo2;
            txtJalovoVremeVV.Text = Convert.ToString(UkupnoJalovo);
        }

        private void VratiPodatke(int RN, int RB)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [IDRadnogNaloga] ,[RB] ,[IDTrase] ,[SMSifra] " +
            " ,[DeSifra] ,[DatumPolaska] ,[DatumDolaska] ,[PlaniranoVreme], Masinovodja, Pomocnik, Vozovodja, Pregledac " +
            " FROM [TESTIRANJE].[dbo].[RadniNalogTraseLokZap] where IDRadnogNaloga=" + RN + " and RB = " + RB, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cboTrase.SelectedValue = Convert.ToInt32(dr["IDTrase"].ToString());
                txtRB.Text = dr["RB"].ToString();
               // cboLokomotiva.SelectedValue = Convert.ToInt32(dr["SmSifra"].ToString());
                cboZaposleni.SelectedValue = Convert.ToInt32(dr["DeSifra"].ToString());
                dtpVremeOd.Value = Convert.ToDateTime(dr["DatumPolaska"].ToString());
                dtpVremeDo.Value = Convert.ToDateTime(dr["DatumDolaska"].ToString());
                txtVreme.Text = dr["PlaniranoVreme"].ToString();

                if (dr["Masinovodja"].ToString() == "1")
                {
                    chkMasinovodja.Checked = true;
                }
                else
                {
                    chkMasinovodja.Checked = false;
                
                }

                if (dr["Pomocnik"].ToString() == "1")
                {
                    chkPomocnik.Checked = true;
                }
                else
                {
                    chkPomocnik.Checked = false;

                }


                if (dr["Vozovodja"].ToString() == "1")
                {
                    chkVozovodja.Checked = true;
                }
                else
                {
                    chkVozovodja.Checked = false;

                }

                if (dr["Pregledac"].ToString() == "1")
                {
                    chkPregledac.Checked = true;
                }
                else
                {
                    chkPregledac.Checked = false;

                }


            }

            con.Close();
        
        
        }

        private void txtVoznoVreme_Leave(object sender, EventArgs e)
        {
            int pom1 = Convert.ToInt32(txtUkupnoVreme.Text) - Convert.ToInt32(txtVoznoVreme.Text);
            txtJalovoVreme.Text = Convert.ToString(pom1);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        int RN = Convert.ToInt32(row.Cells[0].Value.ToString());
                        int RB = Convert.ToInt32(row.Cells[2].Value.ToString()); ;
                       // txtSifra.Text = row.Cells[0].Value.ToString();
                        VratiPodatke(RN, RB);
                       // txtSifra.Text = row.Cells[0].Value.ToString();
                       // VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertRadniNalogZaposleni ins = new InsertRadniNalogZaposleni();
            ins.DelRNTLZ(Convert.ToInt32(txtSifraRN.Text), Convert.ToInt32(cboTrase.SelectedValue), Convert.ToInt32(txtRB.Text));
            RefreshDataGrid();
            status = false;
        }

        private void tsNew_Click(object sender, EventArgs e)
        {

        }

        private void chkPregledac_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
