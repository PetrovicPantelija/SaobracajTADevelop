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
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace Saobracaj.Dokumenta
{
    public partial class frmNajava : Syncfusion.Windows.Forms.Office2010Form
    {
        

        string niz = "";
        public static string code = "frmNajava";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();

        Boolean status = false;
        int PomRID = 0;
        int PomImaPovrat = 0;
       // ArrayList alAttachments;
        MailMessage mailMessage;
        string KorisnikNajava = "";
        int loadStatus = 1;
        int Arhiv = 0;
        string NacinD = "";

        public frmNajava()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");

            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
            RefreshDataGrid();
           
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
        public frmNajava(string Korisnik, int ArhivskiPodaci)
        {
            InitializeComponent();
           
            KorisnikNajava = Korisnik;
            Arhiv = ArhivskiPodaci;
            IdGrupe();
            IdForme();
            PravoPristupa();
            RefreshDataGrid();
        }

        public frmNajava(string Sifra)
        {
            InitializeComponent();
            txtSifra.Text = Sifra;
            VratiPodatke(txtSifra.Text);
            RefreshDataGrid();
            
        }

        private void RefreshDataGrid()
        {
            var select = "  SELECT    najava.ID, stanice_4.opis as Granicna, " +
            " Najava.BrojNajave, Najava.Voz, Partnerji_1.PaNaziv as Posiljalac, " +
            " Partnerji.PaNaziv AS Prevoznik, Partnerji_2.PaNaziv AS Primalac, " +
            " stanice.Opis AS Uputna, stanice_1.Opis AS Otpravna,  Najava.PrevozniPut as Relacija , " +
            "  Najava.PredvidjenoPrimanje, Najava.StvarnoPrimanje, " +
            "  Najava.PredvidjenaPredaja, Najava.StvarnaPredaja, " +
     "   CASE WHEN Najava.RID > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as StatusN , " +
      "     Najava.ONBroj,  Najava.Status, Najava.Tezina, Najava.Duzina, " +
       "   Najava.BrojKola, Najava.NetoTezinaM, Najava.DatumUnosa, Partnerji_3.PaNaziv as PrevoznikZa, Najava.Faktura, Najava.Korisnik " +
        "   FROM  Najava INNER JOIN Partnerji AS Partnerji_1 ON " +
         "  Najava.Posiljalac = Partnerji_1.PaSifra " +
          " INNER JOIN Partnerji ON Najava.Prevoznik = Partnerji.PaSifra " +
         "  INNER JOIN Partnerji AS Partnerji_2 ON Najava.Primalac = Partnerji_2.PaSifra " +
          "  INNER JOIN  stanice ON Najava.Uputna = stanice.ID " +
          "  INNER JOIN  stanice AS stanice_1 ON Najava.Otpravna = stanice_1.ID  " +
  " inner JOIN  stanice AS stanice_4 ON Najava.Granicna = stanice_4.ID  " +
  " INNER JOIN Partnerji as Partnerji_3 ON Najava.PrevoznikZa = Partnerji_3.PaSifra ";
            if (Arhiv == 0)
            {
                select = select + " WHERE (Status <> 7 ) or (Status = 7 and Faktura ='') order by Najava.ID desc";
            }
            else
            {
                select = select + " WHERE (Status = 7 ) or Status = 8 order by Najava.ID desc";
            }
          
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 70;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Granična";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Broj";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Voz";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Posiljalac";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Prevoznik";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Primalac";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Uputna";
            dataGridView1.Columns[7].Width = 50;

             DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Otpravna";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Relacija";
            dataGridView1.Columns[9].Width = 150;


            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Predviđeno Primanje";
            dataGridView1.Columns[10].Width = 100;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Stvarno primanje";
            dataGridView1.Columns[11].Width = 100;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Predviđena predaja";
            dataGridView1.Columns[12].Width = 100;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Stvarna predaja";
            dataGridView1.Columns[13].Width = 100;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "RID";
            dataGridView1.Columns[14].Width = 50;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "RID broj";
            dataGridView1.Columns[15].Width = 50;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Status";
            dataGridView1.Columns[16].Width = 50;

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Težina";
            dataGridView1.Columns[17].Width = 50;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Dužina";
            dataGridView1.Columns[18].Width = 50;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Broj kola";
            dataGridView1.Columns[19].Width = 50;

            DataGridViewColumn column21 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Neto";
            dataGridView1.Columns[20].Width = 50;

            DataGridViewColumn column22 = dataGridView1.Columns[21];
            dataGridView1.Columns[21].HeaderText = "Datum promene";
            dataGridView1.Columns[21].Width = 100;

            DataGridViewColumn column23 = dataGridView1.Columns[22];
            dataGridView1.Columns[22].HeaderText = "Prevoznik za";
            dataGridView1.Columns[22].Width = 100;

            DataGridViewColumn column24 = dataGridView1.Columns[23];
            dataGridView1.Columns[23].HeaderText = "Faktura";
            dataGridView1.Columns[23].Width = 80;

        }

        private void RefreshDataGrid4()
        {
            var select = "  Select NajavaDodatneUsluge.IDPorudzbinaID, " +
                " NajavaDodatneUsluge.IDNajava, " +
" NaPSifra,NarociloPostav.NaPNaziv from NajavaDodatneUsluge inner join NarociloPostav " +
" on NajavaDodatneUsluge.IDPorudzbinaID = NarociloPostav.NaPNarZap where NajavaDodatneUsluge.IDNajava = " + Convert.ToInt32(txtSifra.Text);
          

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];

            dataGridView4.BorderStyle = BorderStyle.None;
            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView4.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView4.BackgroundColor = Color.White;

            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewColumn column = dataGridView4.Columns[0];
            dataGridView4.Columns[0].HeaderText = "Porudzbina stavka";
            dataGridView4.Columns[0].Width = 70;

            DataGridViewColumn column2 = dataGridView4.Columns[1];
            dataGridView4.Columns[1].HeaderText = "Najava ID";
            dataGridView4.Columns[1].Width = 70;

            DataGridViewColumn column3 = dataGridView4.Columns[2];
            dataGridView4.Columns[2].HeaderText = "Šifra MP";
            dataGridView4.Columns[2].Width = 70;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Usluga";
            dataGridView1.Columns[3].Width = 150;

           

        }


        private void RefreshDataGrid5()
        {
            if (txtSifra.Text == "")
                txtSifra.Text = "0";
            var select = "  Select NajavaDeljenjeVoza.IDPorudzbinaID, " +
                " NajavaDeljenjeVoza.IDNajava, " +
" NaPSifra,NarociloPostav.NaPNaziv, NajavaDeljenjeVoza.BrojKola, NajavaDeljenjeVoza.Tezina from NajavaDeljenjeVoza inner join NarociloPostav " +
" on NajavaDeljenjeVoza.IDPorudzbinaID = NarociloPostav.NaPNarZap where NajavaDeljenjeVoza.IDNajava = " + Convert.ToInt32(txtSifra.Text);


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];

            dataGridView4.BorderStyle = BorderStyle.None;
            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView4.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView4.BackgroundColor = Color.White;

            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewColumn column = dataGridView4.Columns[0];
            dataGridView4.Columns[0].HeaderText = "Porudzbina stavka";
            dataGridView4.Columns[0].Width = 70;

            DataGridViewColumn column2 = dataGridView4.Columns[1];
            dataGridView4.Columns[1].HeaderText = "Najava ID";
            dataGridView4.Columns[1].Width = 70;

            DataGridViewColumn column3 = dataGridView4.Columns[2];
            dataGridView4.Columns[2].HeaderText = "Šifra MP";
            dataGridView4.Columns[2].Width = 70;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Usluga";
            dataGridView1.Columns[3].Width = 150;



        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            txtOpis.Text = "";

          
            cmbVoz.SelectedValue = 0;
            cboPosiljalac.SelectedValue = 0;
            cboPrevoznik.SelectedValue = 0;
            cboOtpravna.SelectedValue = 0;
            cboUputna.SelectedValue =0;
            cboPrimalac.SelectedValue = 0;
            //Obraditi checked
            cboNHM.SelectedValue = 0;
            txtRelacija.Text = "";
            txtNetoTezina.Value = 0;
            txtDuzinaM.Value = 0;
            txtBrojKola.Value = 0;
            txtNetoTezinaM.Value = 0;

            chkRID.Checked = false;
                txtRID.Enabled = false;
                txtRIDBroj.Enabled = false;
            
            dtpPredvidjenoPrimanje.Value = DateTime.Now;
            dtpStvarnoPrimanje.Value = DateTime.Now;
            dtpPredvidjenaPredaja.Value = DateTime.Now;
            dtpStvarnaPredaja.Value = DateTime.Now;
            //cboStatusPredaje.Text, 
            cboStatusPredaje.SelectedValue =1;
            txtRID.Text = "";
            txtRIDBroj.Text = "";
            txtKomentar.Text = "";
            cboVozP.SelectedValue = 0;
            cboGranicna.SelectedValue = 0;
           
                chkAdHoc.Checked = false;
                chkCIM.Checked = false;
            
            cboPlatilac.SelectedValue = 0;
            cboPrevoznikZa.SelectedValue = 0;
            txtUgovor.Text = "";
            txtZadatak.Text = "";
          

   /*
   Napisati kod
   */


            status = true;
        }

        private void frmNajava_Load(object sender, EventArgs e)
        {
            var select = " Select Distinct ID, RTrim(Voz) as Voz From Trase";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cmbVoz.DataSource = ds.Tables[0];
            cmbVoz.DisplayMember = "Voz";
            cmbVoz.ValueMember = "ID";

            var selectL = " Select Distinct ID, RTrim(Naziv) as TipPrevoza From TipSaobPrevoza";
            var s_connectionL = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnectionL = new SqlConnection(s_connectionL);
            var cL = new SqlConnection(s_connectionL);
            var dataAdapterL = new SqlDataAdapter(selectL, cL);

            var commandBuilderL = new SqlCommandBuilder(dataAdapterL);
            var dsL = new DataSet();
            dataAdapterL.Fill(dsL);
            cboTipPrevoza.DataSource = dsL.Tables[0];
            cboTipPrevoza.DisplayMember = "TipPrevoza";
            cboTipPrevoza.ValueMember = "ID";

            var select2 = " Select Distinct ID, RTrim(Opis) as Opis From StatusVoza";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboStatusPredaje.DataSource = ds2.Tables[0];
            cboStatusPredaje.DisplayMember = "Opis";
            cboStatusPredaje.ValueMember = "ID";

            var select3 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Posiljalac = 1 order by PaNaziv";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboPosiljalac.DataSource = ds3.Tables[0];
            cboPosiljalac.DisplayMember = "Partner";
            cboPosiljalac.ValueMember = "PaSifra";

            var select4 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Prevoznik = 1 order by PaNaziv";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPrevoznik.DataSource = ds4.Tables[0];
            cboPrevoznik.DisplayMember = "Partner";
            cboPrevoznik.ValueMember = "PaSifra";

            var select5 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Primalac = 1 order By PaNaziv";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboPrimalac.DataSource = ds5.Tables[0];
            cboPrimalac.DisplayMember = "Partner";
            cboPrimalac.ValueMember = "PaSifra";


            var select6 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboOtpravna.DataSource = ds6.Tables[0];
            cboOtpravna.DisplayMember = "Stanica";
            cboOtpravna.ValueMember = "ID";

            var select7 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboUputna.DataSource = ds7.Tables[0];
            cboUputna.DisplayMember = "Stanica";
            cboUputna.ValueMember = "ID";
            
            var select8 = " Select ID, RTrim(Broj) as NHM From NHM order by Broj";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboNHM.DataSource = ds8.Tables[0];
            cboNHM.DisplayMember = "NHM";
            cboNHM.ValueMember = "ID";

            var select9 = " Select Distinct ID, RTrim(Opis) as Razlog From Razlozi";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection9);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);
            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            txtRazlog.DataSource = ds9.Tables[0];
            txtRazlog.DisplayMember = "Razlog";
            txtRazlog.ValueMember = "ID";


            var select10 = " Select Distinct ID, RTrim(Voz) as Voz From Trase";
            var s_connection10 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection10 = new SqlConnection(s_connection10);
            var c10 = new SqlConnection(s_connection10);
            var dataAdapter10 = new SqlDataAdapter(select10, c10);

            var commandBuilder10 = new SqlCommandBuilder(dataAdapter10);
            var ds10 = new DataSet();
            dataAdapter10.Fill(ds10);
            cboVozP.DataSource = ds10.Tables[0];
            cboVozP.DisplayMember = "Voz";
            cboVozP.ValueMember = "ID";


            var select11 = " Select ID, RTrim(Opis) as Stanica From Stanice order by Opis";
            var s_connection11 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection11 = new SqlConnection(s_connection11);
            var c11 = new SqlConnection(s_connection11);
            var dataAdapter11 = new SqlDataAdapter(select11, c11);

            var commandBuilder11 = new SqlCommandBuilder(dataAdapter11);
            var ds11 = new DataSet();
            dataAdapter11.Fill(ds11);
            cboGranicna.DataSource = ds11.Tables[0];
            cboGranicna.DisplayMember = "Stanica";
            cboGranicna.ValueMember = "ID";

            var select12 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Primalac = 1 order By PaNaziv";
            var s_connection12 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection12 = new SqlConnection(s_connection12);
            var c12 = new SqlConnection(s_connection12);
            var dataAdapter12 = new SqlDataAdapter(select12, c12);

            var commandBuilder12 = new SqlCommandBuilder(dataAdapter12);
            var ds12 = new DataSet();
            dataAdapter12.Fill(ds12);
            cboPlatilac.DataSource = ds12.Tables[0];
            cboPlatilac.DisplayMember = "Partner";
            cboPlatilac.ValueMember = "PaSifra";

            var select13 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Primalac = 1 order By PaNaziv";
            var s_connection13 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection13 = new SqlConnection(s_connection13);
            var c13 = new SqlConnection(s_connection12);
            var dataAdapter13 = new SqlDataAdapter(select13, c13);

            var commandBuilder13 = new SqlCommandBuilder(dataAdapter13);
            var ds13 = new DataSet();
            dataAdapter13.Fill(ds13);
            cboPrevoznikZa.DataSource = ds13.Tables[0];
            cboPrevoznikZa.DisplayMember = "Partner";
            cboPrevoznikZa.ValueMember = "PaSifra";


            var select15 = " Select ID, RTrim(Broj) as NHM From NHM order by Broj";
            var s_connection15 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection15 = new SqlConnection(s_connection15);
            var c15 = new SqlConnection(s_connection15);
            var dataAdapter15 = new SqlDataAdapter(select15, c15);

            var commandBuilder15 = new SqlCommandBuilder(dataAdapter15);
            var ds15 = new DataSet();
            dataAdapter15.Fill(ds15);
            cboNHM2.DataSource = ds15.Tables[0];
            cboNHM2.DisplayMember = "NHM";
            cboNHM2.ValueMember = "ID";


            //Tehnologija

            var select14 = "    select ID, PorudzbinaID as MP, MaticniPodatki.MpNaziv, Tonaza, TonazaPovratak from Tehnologija " +
            " inner join MaticniPodatki on Tehnologija.PorudzbinaID = MaticniPodatki.MpSifra ";
            var s_connection14 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection14 = new SqlConnection(s_connection14);
            var c14 = new SqlConnection(s_connection14);
            var dataAdapter14 = new SqlDataAdapter(select14, c14);

            var commandBuilder14 = new SqlCommandBuilder(dataAdapter14);
            var ds14 = new DataSet();
            dataAdapter14.Fill(ds14);


            DataView view = new DataView(ds14.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            cboTehnologijaID.DataSource = view;
            cboTehnologijaID.DisplayMember = "MpNaziv";
            cboTehnologijaID.ValueMember = "ID";
           
            //Panta
            loadStatus = 0;
        }

      

        int ProveraUnosa()
        { 
        if (cmbVoz.SelectedValue == null)
        {
            MessageBox.Show("Nije unet voz");
            return 0;
        }
        if (cboPosiljalac.SelectedValue == null)
        {
            MessageBox.Show("Nije unet Pošiljalac");
            return 0;
        }
        if (cboVozP.SelectedValue == null)
        {
            MessageBox.Show("Nije unet prijemni voz");
            return 0;
        }

        if (cboPrevoznik.SelectedValue == null)
        {
            MessageBox.Show("Nije unet prevoznik");
            return 0;
        }
        if (cboOtpravna.SelectedValue == null)
        {
            MessageBox.Show("Nije unet otpravna stanica");
            return 0;
        }
        if (cboUputna.SelectedValue == null)
        {
            MessageBox.Show("Nije unet uputna stanica");
            return 0;
        }
        if (cboPrimalac.SelectedValue == null)
        {
            MessageBox.Show("Nije unet primalac");
            return 0;
        }

        if (cboPrevoznikZa.SelectedValue == null)
        {
            MessageBox.Show("Nije unet Prevoznik za");
            return 0;
        }

        if (cboPlatilac.SelectedValue == null)
        {
            MessageBox.Show("Nije unet Platilac");
            return 0;
        }

        if (cboStatusPredaje.SelectedValue == null)
        {
            MessageBox.Show("Nije unet Status najave");
            return 0;
        }

        return 1;




        
        }
        private void LogInsert()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            string query = "SELECT TOP 1 * FROM Najava ORDER BY ID DESC";
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                int id = Convert.ToInt32(dr["ID"].ToString());
                string brNajave = dr["BrojNajave"].ToString().TrimEnd();
                int voz = Convert.ToInt32(dr["Voz"].ToString());
                int posiljalac = Convert.ToInt32(dr["Posiljalac"].ToString());
                int prevoznik = Convert.ToInt32(dr["Prevoznik"].ToString());
                int otpravna = Convert.ToInt32(dr["Otpravna"].ToString());
                int uputna = Convert.ToInt32(dr["Uputna"].ToString());
                int primalac = Convert.ToInt32(dr["Primalac"].ToString());
                int roba = Convert.ToInt32(dr["RobaNHM"].ToString());
                string put = dr["PrevozniPut"].ToString().TrimEnd();
                decimal tezina = Convert.ToDecimal(dr["Tezina"].ToString());
                decimal duzina = Convert.ToDecimal(dr["Duzina"].ToString());
                int kola = Convert.ToInt32(dr["BrojKola"].ToString());
                int rid = Convert.ToInt32(dr["RID"].ToString());
                DateTime pPrimanje = Convert.ToDateTime(dr["PredvidjenoPrimanje"].ToString());
                DateTime sPrimanje = Convert.ToDateTime(dr["StvarnoPrimanje"].ToString());
                DateTime pPredaja = Convert.ToDateTime(dr["PredvidjenaPredaja"].ToString());
                DateTime sPredaja = Convert.ToDateTime(dr["StvarnaPredaja"].ToString());
                int status = Convert.ToInt32(dr["Status"].ToString());
                string onB = dr["OnBroj"].ToString().TrimEnd();
                int verzija = Convert.ToInt32(dr["Verzija"].ToString());
                int razlog = Convert.ToInt32(dr["Razlog"].ToString());
                //DateTime datumU = Convert.ToDateTime(dr["DatumUnosa"].ToString());
                string ridB = dr["RIDBroj"].ToString().TrimEnd();
                string komentar = dr["Komentar"].ToString().TrimEnd();
                int vozP = Convert.ToInt32(dr["VozP"].ToString());
                int granicna = Convert.ToInt32(dr["Granicna"].ToString());
                int platilac = Convert.ToInt32(dr["Platilac"].ToString());
                int ad = Convert.ToInt32(dr["AdHoc"].ToString());
                int prevoznikZa = Convert.ToInt32(dr["PrevoznikZa"].ToString());
                string faktura = dr["Faktura"].ToString().TrimEnd();
                string zadatak = dr["Zadatak"].ToString().TrimEnd();
                int cim = Convert.ToInt32(dr["CIM"].ToString());
                string korisnik = dr["Korisnik"].ToString();
                string disp = dr["DispecerRID"].ToString();
                int tip = Convert.ToInt32(dr["TipPrevoza"].ToString());
                decimal neto = Convert.ToDecimal(dr["NetoTezinaM"].ToString());
                int por = Convert.ToInt32(dr["PorudzbinaID"].ToString());
                int povrat = Convert.ToInt32(dr["ImaPovrat"].ToString());
                int teh = Convert.ToInt32(dr["TehnologijaID"].ToString());
                int roba2 = Convert.ToInt32(dr["RobaNhm2"].ToString());
                string dodatno = dr["DodatnoPorudznina"].ToString();
                //DateTime pomDat = Convert.ToDateTime(dr["PomocniDatum"].ToString());

                InsertNajavaLog log = new InsertNajavaLog();
                DateTime date = new DateTime(1900, 1, 1);
                log.insNajavaLog(Kor.ToString().TrimEnd(), "Unos novog zapisa", DateTime.Now, id, brNajave, voz, posiljalac, prevoznik, otpravna, uputna, primalac, roba, put, tezina
                    , duzina, kola, rid, pPrimanje, sPrimanje, pPredaja, sPredaja, status, onB, verzija, razlog, date, ridB, komentar, vozP, granicna, platilac, ad, prevoznikZa, faktura,
                    zadatak, cim, korisnik, disp, tip, neto, por, povrat, teh, roba2, dodatno, date) ;

            }
            conn.Close();
        }
        private void tsSave_Click(object sender, EventArgs e)
        {
            if (chkImaPovrat.Checked)
            {

                PomImaPovrat = 1;
            }
            else
            {
                PomImaPovrat = 0;
            }
            if (ProveraUnosa() == 0)
            {
               // MessageBox.Show("Niste uneli sve podatke");
                return;
            }
            if (status == true)
            {
                InsertNajava ins = new InsertNajava();
                if (chkRID.Checked)
                {
                    PomRID = 1;
                }
                else
                {
                    PomRID = 0;
                }



                ins.InsNaj(txtOpis.Text, Convert.ToInt32(cmbVoz.SelectedValue), Convert.ToInt32(cboPosiljalac.SelectedValue), Convert.ToInt32(cboPrevoznik.SelectedValue), Convert.ToInt32(cboOtpravna.SelectedValue), Convert.ToInt32(cboUputna.SelectedValue), Convert.ToInt32(cboPrimalac.SelectedValue), Convert.ToInt32(cboNHM.SelectedValue), txtRelacija.Text, Convert.ToDouble(txtNetoTezina.Text), Convert.ToDouble(txtDuzinaM.Text), Convert.ToInt32(txtBrojKola.Text), chkRID.Checked, Convert.ToDateTime(dtpPredvidjenoPrimanje.Value), Convert.ToDateTime(dtpStvarnoPrimanje.Value), Convert.ToDateTime(dtpPredvidjenaPredaja.Value), Convert.ToDateTime(dtpStvarnaPredaja.Value), Convert.ToInt32(cboStatusPredaje.SelectedValue), txtRID.Text.TrimEnd(), txtRIDBroj.Text.Trim(), txtKomentar.Text, Convert.ToInt32(cboVozP.SelectedValue), Convert.ToInt32(cboGranicna.SelectedValue), Convert.ToInt32(cboPlatilac.SelectedValue), chkAdHoc.Checked, Convert.ToInt32(cboPrevoznikZa.SelectedValue), txtUgovor.Text, txtZadatak.Text, chkCIM.Checked, KorisnikNajava, txtDispecerRID.Text, Convert.ToInt32(cboTipPrevoza.SelectedValue), Convert.ToDouble(txtNetoTezinaM.Value), Convert.ToInt32(multiColumnComboBox1.SelectedValue), PomImaPovrat, Convert.ToInt32(cboTehnologijaID.SelectedValue), Convert.ToInt32(cboNHM2.SelectedValue), txtPorDodatno.Text);


                if (chkRID.Checked == true && txtRIDBroj.Text.TrimEnd() == "")
                {
                    PosaljiMailOdjavaDisp("milica.p.s@kprevoz.co.rs");
                    // PosaljiMailOdjavaDisp("ivana.randjelovic@kprevoz.co.rs");
                    PosaljiMailOdjavaDisp("priprema@kprevoz.co.rs");
                    PosaljiMailOdjavaDisp("disp@kprevoz.co.rs");
                    PosaljiMailOdjavaDisp("milos.cpajak@kprevoz.co.rs");
                    PosaljiMailOdjavaDisp("uros.gligorijevic@kprevoz.co.rs");
                    //PosaljiMail("ivana.randjelovic@kprevoz.co.rs");
                    //PosaljiMail("vladeta.milosavljevic@kprevoz.co.rs");
                }
                LogInsert();
                RefreshDataGrid();
                status = false;
            }
            else
            {
                //PPPPP 
                int sp = Convert.ToInt32(cboStatusPredaje.SelectedValue);
                InsertNajava upd = new InsertNajava();
                upd.UpdNaj(Convert.ToInt32(txtSifra.Text), txtOpis.Text, Convert.ToInt32(cmbVoz.SelectedValue), Convert.ToInt32(cboPosiljalac.SelectedValue),
                    Convert.ToInt32(cboPrevoznik.SelectedValue), Convert.ToInt32(cboOtpravna.SelectedValue),
                    Convert.ToInt32(cboUputna.SelectedValue), Convert.ToInt32(cboPrimalac.SelectedValue), Convert.ToInt32(cboNHM.SelectedValue),
                    txtRelacija.Text, Convert.ToDouble(txtNetoTezina.Text), Convert.ToDouble(txtDuzinaM.Text), Convert.ToInt32(txtBrojKola.Text),
                    chkRID.Checked, Convert.ToDateTime(dtpPredvidjenoPrimanje.Value),
                    Convert.ToDateTime(dtpStvarnoPrimanje.Value), Convert.ToDateTime(dtpPredvidjenaPredaja.Value),
                    Convert.ToDateTime(dtpStvarnaPredaja.Value), Convert.ToInt32(cboStatusPredaje.SelectedValue),
                    txtRID.Text.TrimEnd(), txtRIDBroj.Text.TrimEnd(), txtKomentar.Text, Convert.ToInt32(cboVozP.SelectedValue),
                    Convert.ToInt32(cboGranicna.SelectedValue), Convert.ToInt32(cboPlatilac.SelectedValue), chkAdHoc.Checked,
                    Convert.ToInt32(cboPrevoznikZa.SelectedValue), txtUgovor.Text, txtZadatak.Text, chkCIM.Checked, KorisnikNajava, txtDispecerRID.Text,
                    Convert.ToInt32(cboTipPrevoza.SelectedValue), Convert.ToDouble(txtNetoTezinaM.Value), Convert.ToInt32(multiColumnComboBox1.Text),
                    PomImaPovrat, Convert.ToInt32(cboTehnologijaID.SelectedValue), Convert.ToInt32(cboNHM2.SelectedValue), txtPorDodatno.Text);
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid();
                if (chkRID.Checked == true && txtUgovor.Text == "" && Convert.ToInt32(cboStatusPredaje.SelectedValue) == 7)
                {
                    PosaljiMailOdjava("milica.p.s@kprevoz.co.rs");
                    PosaljiMailOdjava("ivana.randjelovic@kprevoz.co.rs");
                    PosaljiMailOdjava("teodora.novakovic@kprevoz.co.rs");

                }
                int rid = 0;
                int ad = 0;
                int cim = 0;
                if (chkRID.Checked) { rid = 1; }
                if (chkAdHoc.Checked) { ad = 1; }
                if (chkCIM.Checked) { cim = 1; }
                InsertNajavaLog log = new InsertNajavaLog();
                DateTime date = new DateTime(1900, 1, 1);
                log.insNajavaLog(Kor.ToString().TrimEnd(), "Promena zapisa", DateTime.Now, Convert.ToInt32(txtSifra.Text), txtOpis.Text,
                        Convert.ToInt32(cmbVoz.SelectedValue), Convert.ToInt32(cboPosiljalac.SelectedValue), Convert.ToInt32(cboPrevoznik.SelectedValue),
                        Convert.ToInt32(cboOtpravna.SelectedValue), Convert.ToInt32(cboUputna.SelectedValue), Convert.ToInt32(cboPrimalac.SelectedValue),
                        Convert.ToInt32(cboNHM.SelectedValue), txtRelacija.Text.TrimEnd(), Convert.ToDecimal(txtNetoTezina.Text), Convert.ToDecimal(txtDuzinaM.Text),
                        Convert.ToInt32(txtBrojKola.Text), rid, Convert.ToDateTime(dtpPredvidjenoPrimanje.Value), Convert.ToDateTime(dtpStvarnoPrimanje.Value),
                        Convert.ToDateTime(dtpPredvidjenaPredaja.Value), Convert.ToDateTime(dtpStvarnaPredaja.Value), Convert.ToInt32(cboStatusPredaje.SelectedValue),
                        txtRIDBroj.Text, 0, Convert.ToInt32(txtRazlog.SelectedValue), date, txtRID.Text.TrimEnd(), txtKomentar.Text,
                        Convert.ToInt32(cboVozP.SelectedValue), Convert.ToInt32(cboGranicna.SelectedValue), Convert.ToInt32(cboPlatilac.SelectedValue), ad,
                        Convert.ToInt32(cboPrevoznikZa.SelectedValue), txtUgovor.Text, txtZadatak.Text, cim, KorisnikNajava, txtDispecerRID.Text,
                        Convert.ToInt32(cboTipPrevoza.SelectedValue), Convert.ToDecimal(txtNetoTezinaM.Value), Convert.ToInt32(multiColumnComboBox1.Text),
                        PomImaPovrat, Convert.ToInt32(cboTehnologijaID.SelectedValue), Convert.ToInt32(cboNHM2.SelectedValue), txtPorDodatno.Text, date);
            }
        }

        private void PosaljiMail(string Kome)
        {
            try
            {
                string zadnjibroj = "";
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(s_connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Max(ID) as zadnji from Najava", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    zadnjibroj = dr["zadnji"].ToString();
                }
                con.Close();    
                
                    mailMessage = new MailMessage("pantelija.petrovic@kprevoz.co.rs", Kome);

                    mailMessage.Subject = "Najava: " + zadnjibroj + " zahteva OM broj. ";
                    mailMessage.Body = "Zahtev za OM brojem za Najavu: " + zadnjibroj + "  !!!!!!!";
                    mailMessage.IsBodyHtml = true;

                    /* Set the SMTP server and send the email with attachment */

                    SmtpClient smtpClient = new SmtpClient();

                    // smtpClient.Host = emailServerInfo.MailServerIP;
                    //this will be the host in case of gamil and it varies from the service provider

                    smtpClient.Host = "mail.kprevoz.co.rs";
                    //smtpClient.Port = Convert.ToInt32(emailServerInfo.MailServerPortNumber);
                    //this will be the port in case of gamil for dotnet and it varies from the service provider

                    smtpClient.Port = 25;
                    smtpClient.UseDefaultCredentials = true;

                    //smtpClient.Credentials = new System.Net.NetworkCredential(emailServerInfo.MailServerUserName, emailServerInfo.MailServerPassword);
                    smtpClient.Credentials = new NetworkCredential("pantelija.petrovic@kprevoz.co.rs", "pele1616");

                    //Attachment
                    /*
                    Attachment attachment = new Attachment(txtAttacment.Text);
                    if (attachment != null)
                    {
                        mailMessage.Attachments.Add(attachment);
                    }
                    */

                    //this will be the true in case of gamil and it varies from the service provider
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void PosaljiMailOdjava(string Kome)
        {
            try
            {
                string zadnjibroj = txtSifra.Text;
                /*
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(s_connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Max(ID) as zadnji from Najava", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    zadnjibroj = dr["zadnji"].ToString();
                }
                con.Close();
                */
                mailMessage = new MailMessage("pantelija.petrovic@kprevoz.co.rs", Kome);

                mailMessage.Subject = "Najava: " + zadnjibroj + " odjava OM  BROJA. ";
                mailMessage.Body = "Prevoz za Najavu je završen proveriti odjavu OM broja za Najavu: " + zadnjibroj + "  !!!!";
                mailMessage.IsBodyHtml = true;

                /* Set the SMTP server and send the email with attachment */

                SmtpClient smtpClient = new SmtpClient();

                // smtpClient.Host = emailServerInfo.MailServerIP;
                //this will be the host in case of gamil and it varies from the service provider

                smtpClient.Host = "mail.kprevoz.co.rs";
                //smtpClient.Port = Convert.ToInt32(emailServerInfo.MailServerPortNumber);
                //this will be the port in case of gamil for dotnet and it varies from the service provider

                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = true;

                //smtpClient.Credentials = new System.Net.NetworkCredential(emailServerInfo.MailServerUserName, emailServerInfo.MailServerPassword);
                smtpClient.Credentials = new NetworkCredential("pantelija.petrovic@kprevoz.co.rs", "pele1616");

                //Attachment
                /*
                Attachment attachment = new Attachment(txtAttacment.Text);
                if (attachment != null)
                {
                    mailMessage.Attachments.Add(attachment);
                }
                */

                //this will be the true in case of gamil and it varies from the service provider
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void PosaljiMailOdjavaDisp(string Kome)
        {
            try
            {
                string zadnjibroj = txtSifra.Text;
               
                mailMessage = new MailMessage("pantelija.petrovic@kprevoz.co.rs", Kome);

                mailMessage.Subject = "OM broj RTC LUKA LEGET: " + zadnjibroj + " odjava OM  BROJA. ";

                var select = " Select ROW_NUMBER() OVER(ORDER BY n1.ID DESC) AS Row, n1.ID as NajavaID, " +
               " n1.PrevozniPut, " +
               " n1.BrojKola, " +
               "  n1.OnBroj, n1.RIDBroj, pos.PaNaziv as Posiljac, pri.PaNaziv as Primalac, " +
               " (Rtrim(NHM.Broj) + '-' + RTRIM(NHM.Naziv)) as NHM, " +
               " (  SELECT  STUFF(  (  SELECT distinct   ', ' + Cast(ts.BrojKola as nvarchar(20))  " +
              " FROM TeretnicaStavke ts where n1.ID = ts.IDNajave " +
              " FOR XML PATH('')   ), 1, 1, ''  ) As Skupljen) " +
              " as Vagoni, (Cast(n1.StvarnoPrimanje as nvarchar(20)) + ' do ' +  Cast(n1.StvarnaPredaja as nvarchar(20))) as VremeRealizacije, " +
              " n1.StvarnaPredaja,  n1.OnBroj + '\'+ n1.DispecerRID as DispecerRID," +
              " (select SUM(neto) from TeretnicaStavke inner join Teretnica on TeretnicaStavke.BrojTeretnice = Teretnica.ID " +
              " where TeretnicaStavke.IDNajave = n1.ID) as Neto  " +
             " from Najava n1 " +
             " inner join stanice so on so.ID = n1.Otpravna " +
             " inner join stanice su on su.ID = n1.Uputna " +
             " inner join Partnerji pos on pos.PaSifra = n1.Posiljalac " +
             " inner join Partnerji pri on pri.PaSifra = n1.Primalac " +
             " inner join NHM on NHM.ID = n1.RobaNhm " +
             " inner join (Select Distinct BrojTeretnice from TeretnicaStavke ) ts on n1.ID = ts.BrojTeretnice " +
             " inner join Teretnica ter on ts.BrojTeretnice = ter.ID " +
             " where Ter.Prijemna = 1 and n1.ID = " + txtSifra.Text;

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                 string body = "Poštovani, molim vas da obezbedite OM broj za:  <br />";

                 body = body + "Ovo je testni majl koji treba da se šalje infrastrukturi kada se promeni status u 2, uneta teretnica i RID prazan <br /> <br /> <br />";
                 body = body + "Proverite tačnost i oblik maila !!!!!! <br />";
                foreach (DataRow myRow in ds.Tables[0].Rows)
                {
                    body = body + "Relacija: " + myRow["Prevozniput"].ToString() + "<br />" + "<br />" + "<br />";
                    body = body + "Broj kola: " + myRow["BrojKola"].ToString() + "<br />";
                    body = body + "Neto: " + myRow["Neto"].ToString() + "<br />";
                    body = body + "RID: " + myRow["OnBroj"].ToString() + "<br />";
                    body = body + "Spisak kola: " + myRow["Vagoni"].ToString() + "<br />";
                    body = body + "Pošiljalac: " + myRow["Posiljac"].ToString() + "<br />";
                    body = body + "Primalac: " + myRow["Primalac"].ToString() + "<br />";
                    body = body + "S poštovanjem" + "<br />";
                    body = body + "Dispičerska služba RTC LUKA LEGET" + "<br />" + "<br />" + "<br />";
                    body = body + "DODELJENI BROJ JE: _______________________ " + "<br />";

                }

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

        private void tsDelete_Click(object sender, EventArgs e)
        {
            const string message =
            "Da li ste baš baš sigurni da će te da obrišete Najavu?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                return;
            }
            else
            {
                int rid = 0;
                int ad = 0;
                int cim = 0;
                if (chkRID.Checked) { rid = 1; }
                if (chkAdHoc.Checked) { ad = 1; }
                if (chkCIM.Checked) { cim = 1; }
                InsertNajavaLog log = new InsertNajavaLog();
                DateTime date = new DateTime(1900, 1, 1);
                log.insNajavaLog(Kor.ToString().TrimEnd(), "Brisanje zapisa", DateTime.Now, Convert.ToInt32(txtSifra.Text), txtOpis.Text,
                        Convert.ToInt32(cmbVoz.SelectedValue), Convert.ToInt32(cboPosiljalac.SelectedValue), Convert.ToInt32(cboPrevoznik.SelectedValue),
                        Convert.ToInt32(cboOtpravna.SelectedValue), Convert.ToInt32(cboUputna.SelectedValue), Convert.ToInt32(cboPrimalac.SelectedValue),
                        Convert.ToInt32(cboNHM.SelectedValue), txtRelacija.Text.TrimEnd(), Convert.ToDecimal(txtNetoTezina.Text), Convert.ToDecimal(txtDuzinaM.Text),
                        Convert.ToInt32(txtBrojKola.Text), rid, Convert.ToDateTime(dtpPredvidjenoPrimanje.Value), Convert.ToDateTime(dtpStvarnoPrimanje.Value),
                        Convert.ToDateTime(dtpPredvidjenaPredaja.Value), Convert.ToDateTime(dtpStvarnaPredaja.Value), Convert.ToInt32(cboStatusPredaje.SelectedValue),
                        txtRIDBroj.Text, 0, Convert.ToInt32(txtRazlog.SelectedValue), date, txtRID.Text.TrimEnd(), txtKomentar.Text,
                        Convert.ToInt32(cboVozP.SelectedValue), Convert.ToInt32(cboGranicna.SelectedValue), Convert.ToInt32(cboPlatilac.SelectedValue), ad,
                        Convert.ToInt32(cboPrevoznikZa.SelectedValue), txtUgovor.Text, txtZadatak.Text, cim, KorisnikNajava, txtDispecerRID.Text,
                        Convert.ToInt32(cboTipPrevoza.SelectedValue), Convert.ToDecimal(txtNetoTezinaM.Value), Convert.ToInt32(multiColumnComboBox1.Text),
                        PomImaPovrat, Convert.ToInt32(cboTehnologijaID.SelectedValue), Convert.ToInt32(cboNHM2.SelectedValue), txtPorDodatno.Text, date);

                InsertNajava del = new InsertNajava();
                del.DeleteNaj(Convert.ToInt32(txtSifra.Text));
                status = false;
                txtSifra.Enabled = false;
            }
            
           
        }

        private void chkRID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRID.Checked == true)
            {
                txtRID.Enabled = true;
                txtRIDBroj.Enabled = true;

            }
            else
            {
                txtRID.Enabled = false;
                txtRIDBroj.Enabled = false;
                txtRID.Text = "";
            }
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
                        VratiPodatkeSelect(txtSifra.Text);
                       // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNajavaPrevoznik najprev = new frmNajavaPrevoznik(txtSifra.Text);
            najprev.Show();
        }

        private void tabNajave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabNajave.SelectedIndex == 1)
            {  
            int pomNaj = 0;
            if (txtSifra.Text == "")
            {
                pomNaj = 0;
            }
            else
            { 
                pomNaj = Convert.ToInt32(txtSifra.Text);
            }
               
                var select = "select NajavaPrevoznik.ID,NajavaPrevoznik.IDNajave, NajavaPrevoznik.IDPrevoznik, NajavaPrevoznik.Red, NajavaPrevoznik.PaNaziv, Partnerji.UIC from NajavaPrevoznik inner join Partnerji on " +
                " NajavaPrevoznik.IDPrevoznik = Partnerji.PaSifra where NajavaPrevoznik.IDNajave =  " + pomNaj + " order by NajavaPrevoznik.Red";
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView2.ReadOnly = true;
                dataGridView2.DataSource = ds.Tables[0];
            }
            else if (tabNajave.SelectedIndex == 2)
            { 
            //Verzije
                int pomNaj = 0;
                if (txtSifra.Text == "")
                {
                    pomNaj = 0;
                }
                else
                {
                    pomNaj = Convert.ToInt32(txtSifra.Text);
                }
                /*
                var select = " SELECT  top 30  najava.ID, Verzija, Najava.BrojNajave, Trase.Voz, Partnerji_1.PaNaziv as Posiljalac, Partnerji.PaNaziv AS Prevoznik, Partnerji_2.PaNaziv AS Primalac, Trase.Pocetna, Trase.Krajnja, Trase.Relacija, " +
                      " Trase.OpisRelacije, Najava.PredvidjenoPrimanje, Najava.StvarnoPrimanje, " +
                      " Najava.PredvidjenaPredaja, Najava.StvarnaPredaja, " +
                      " CASE WHEN Najava.RobaNHM > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as StatusN ," +
                      " Najava.OnBroj," +
                      " Najava.Status, " +
                      " Najava.Tezina, Najava.Duzina, Najava.BrojKola" +
                      " Najava.Razlog " + 
                      " FROM  Najava INNER JOIN" +
                      " Partnerji AS Partnerji_1 ON Najava.Posiljalac = Partnerji_1.PaSifra INNER JOIN" +
                      " Partnerji ON Najava.Prevoznik = Partnerji.PaSifra INNER JOIN" +
                      " Partnerji AS Partnerji_2 ON Najava.Primalac = Partnerji_2.PaSifra INNER JOIN" +
                      " Trase ON Najava.Voz = Trase.ID inner join Razlozi ON " +  
                      " WHERE  Najava.ID = " + pomNaj;
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet(); 
                dataAdapter.Fill(ds);
                dataGridView2.ReadOnly = true;
                dataGridView2.DataSource = ds.Tables[0];
                 */
            }
            else if (tabNajave.SelectedIndex == 2)
            { 
            //Poziv izvestaja
            
            }
            else if (tabNajave.SelectedIndex == 3)
            {
                //Vagoni sa teretnica
                var select = " SELECT     TeretnicaStavke.ID, TeretnicaStavke.RB, TeretnicaStavke.IDNajave, stanice.Opis as Uvrstena, stanice_1.Opis AS Otkacena, TeretnicaStavke.BrojKola, TeretnicaStavke.Serija, "
                          + " TeretnicaStavke.BrojOsovina, TeretnicaStavke.Duzina, TeretnicaStavke.Tara, TeretnicaStavke.Neto, TeretnicaStavke.G, TeretnicaStavke.P, TeretnicaStavke.R, "
                          + " TeretnicaStavke.RR, TeretnicaStavke.VRNP, stanice_3.Opis AS Otpravna, stanice_2.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, "
                          + " TeretnicaStavke.RucKoc "
                          + " FROM   TeretnicaStavke INNER JOIN "
                          + " stanice ON TeretnicaStavke.Uvrstena = stanice.ID INNER JOIN "
                          + " stanice AS stanice_1 ON TeretnicaStavke.Otkacena = stanice_1.ID INNER JOIN "
                          + " stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN "
                          + " stanice AS stanice_2 ON TeretnicaStavke.Otpravna = stanice_2.ID " +
                          " WHERE  TeretnicaStavke.IDNajave = " + txtSifra.Text;
                   
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView3.ReadOnly = true;
                dataGridView3.DataSource = ds.Tables[0];

                dataGridView3.BorderStyle = BorderStyle.None;
                dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView3.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView3.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dataGridView3.BackgroundColor = Color.White;

                dataGridView3.EnableHeadersVisualStyles = false;
                dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
            else if (tabNajave.SelectedIndex == 7)
            {
                //if (status == false)
                //{ RefreshDataGrid5(); }
                    
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            switch (cboTipPrevoza.Text)
            {
                case "Unutrašnji prazan":
                       frmDokumentaNajava frmd = new frmDokumentaNajava(txtSifra.Text, cboTipPrevoza.Text);
                       frmd.Show();
                        break;
                case "Unutrašnji pun":
                        frmDokumentaNajava frmd2 = new frmDokumentaNajava(txtSifra.Text, cboTipPrevoza.Text);
                        frmd2.Show();
                    break;
                case "Uvoz/Izvoz/Tranzit prazno":
                        frmDokumentaNajava frmd3 = new frmDokumentaNajava(txtSifra.Text, cboTipPrevoza.Text);
                        frmd3.Show();
                    // CIM
                    break;
                case "Uvoz/Tranzit tovareno":
                    frmDokumentaNajava frmd4 = new frmDokumentaNajava(txtSifra.Text, cboTipPrevoza.Text);
                    frmd4.Show();
                    break;
                case "Izvoz tovareno":
                    frmDokumentaNajava frmd5 = new frmDokumentaNajava(txtSifra.Text, cboTipPrevoza.Text);
                    frmd5.Show();
                    break;
                default:
                    MessageBox.Show("Odrediti prvo tip prevoza");


                    break;


            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmSendEmailWithAttacment frmWAtt = new frmSendEmailWithAttacment();
            frmWAtt.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Štampaj prijem?", "Prijem / Predaja", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
                NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
                ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet3";
                rds.Value = dt;
                ReportParameter[] par = new ReportParameter[1];
                par[0] = new ReportParameter("ID", txtSifra.Text);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = "Najava.rdlc";
                reportViewer1.LocalReport.SetParameters(par);
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();

            }
            else if (dialogResult == DialogResult.No)
            {
                NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
                NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
                ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet3";
                rds.Value = dt;
                ReportParameter[] par = new ReportParameter[1];
                par[0] = new ReportParameter("ID", txtSifra.Text);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = "NajavaPrim.rdlc";
                reportViewer1.LocalReport.SetParameters(par);
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
        }

        private void VratiPodatkeSelect(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[BrojNajave] ,[Voz] ,[Posiljalac] ,[Prevoznik],[Otpravna] ,[Uputna] ,[Primalac] ,[RobaNHM] ,[PrevozniPut] " +
            " ,[Tezina] ,[Duzina] ,[BrojKola] ,[RID] ,[PredvidjenoPrimanje] ,[StvarnoPrimanje] ,[PredvidjenaPredaja] ,[StvarnaPredaja] " +
            " ,[Status] ,[OnBroj] ,[Verzija] ,[Razlog] ,[DatumUnosa] ,[RIDBroj] ,[Komentar], [VozP], [Granicna], Platilac, AdHoc, PrevoznikZa, Faktura, Zadatak, CIM, DispecerRID, TipPrevoza, NetoTezinaM, PorudzbinaID, ImaPovrat, TehnologijaID, RobaNHM2, DodatnoPorudznina FROM [TESTIRANJE].[dbo].[Najava] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                txtOpis.Text = dr["BrojNajave"].ToString();
                cmbVoz.SelectedValue = Convert.ToInt32(dr["Voz"].ToString());
                cboPosiljalac.SelectedValue = Convert.ToInt32(dr["Posiljalac"].ToString());
                cboPrevoznik.SelectedValue = Convert.ToInt32(dr["Prevoznik"].ToString());
                cboOtpravna.SelectedValue = Convert.ToInt32(dr["Otpravna"].ToString());
                cboUputna.SelectedValue = Convert.ToInt32(dr["Uputna"].ToString());
                cboPrimalac.SelectedValue = Convert.ToInt32(dr["Primalac"].ToString());
                //Obraditi checked
                cboNHM.SelectedValue = Convert.ToInt32(dr["RobaNHM"].ToString());
                txtRelacija.Text = dr["PrevozniPut"].ToString();
                txtNetoTezina.Value = Convert.ToDecimal(dr["Tezina"].ToString());
                txtDuzinaM.Value = Convert.ToDecimal(dr["Duzina"].ToString());
                txtBrojKola.Value = Convert.ToDecimal(dr["BrojKola"].ToString());
                txtNetoTezinaM.Value = Convert.ToDecimal(dr["NetoTezinaM"].ToString());

                //Nemamo Iz Najave polje

                if (dr["ImaPovrat"].ToString() == "1")
                {
                    chkImaPovrat.Checked = true;
                    VratiPodatkePorudzbinaSelect(Convert.ToInt32(dr["PorudzbinaID"].ToString()));
                    chkIzNajave.Checked = false;
                }
                else
                {
                    chkImaPovrat.Checked = false;
                    chkIzNajave.Checked = true;
                    VratiPodatkeNajavaSelect(Convert.ToInt32(dr["PorudzbinaID"].ToString()));

                }




                if (dr["RID"].ToString() == "1")
                {
                    chkRID.Checked = true;
                }
                else
                {
                    chkRID.Checked = false;
                    txtRID.Enabled = false;
                    txtRIDBroj.Enabled = false;
                }
                dtpPredvidjenoPrimanje.Value = Convert.ToDateTime(dr["PredvidjenoPrimanje"].ToString());
                dtpStvarnoPrimanje.Value = Convert.ToDateTime(dr["StvarnoPrimanje"].ToString());
                dtpPredvidjenaPredaja.Value = Convert.ToDateTime(dr["PredvidjenaPredaja"].ToString());
                dtpStvarnaPredaja.Value = Convert.ToDateTime(dr["StvarnaPredaja"].ToString());
                //cboStatusPredaje.Text, 
                cboStatusPredaje.SelectedValue = Convert.ToInt32(dr["Status"].ToString());
                txtRID.Text = dr["OnBroj"].ToString();
                txtRIDBroj.Text = dr["RIDBroj"].ToString();
                txtKomentar.Text = dr["Komentar"].ToString();
                cboVozP.SelectedValue = Convert.ToInt32(dr["VozP"].ToString());
                cboGranicna.SelectedValue = Convert.ToInt32(dr["Granicna"].ToString());
                if (dr["AdHoc"].ToString() == "1")
                {
                    chkAdHoc.Checked = true;
                }
                else
                {
                    chkAdHoc.Checked = false;
                }
                cboPlatilac.SelectedValue = Convert.ToInt32(dr["Platilac"].ToString());
                cboPrevoznikZa.SelectedValue = Convert.ToInt32(dr["PrevoznikZa"].ToString());
                txtUgovor.Text = dr["Faktura"].ToString();
                txtZadatak.Text = dr["Zadatak"].ToString();

                if (dr["CIM"].ToString() == "1")
                {
                    chkCIM.Checked = true;
                }
                else
                {
                    chkCIM.Checked = false;
                }

                txtDispecerRID.Text = dr["DispecerRID"].ToString();
                cboTipPrevoza.SelectedValue = Convert.ToInt32(dr["TipPrevoza"].ToString());



                cboTehnologijaID.SelectedValue = Convert.ToInt32(dr["TehnologijaID"].ToString());
                cboNHM2.SelectedValue = Convert.ToInt32(dr["RobaNHM2"].ToString());
                txtPorDodatno.Text = dr["DodatnoPorudznina"].ToString();
            }

            con.Close();
        }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[BrojNajave] ,[Voz] ,[Posiljalac] ,[Prevoznik],[Otpravna] ,[Uputna] ,[Primalac] ,[RobaNHM] ,[PrevozniPut] " +
            " ,[Tezina] ,[Duzina] ,[BrojKola] ,[RID] ,[PredvidjenoPrimanje] ,[StvarnoPrimanje] ,[PredvidjenaPredaja] ,[StvarnaPredaja] " +
            " ,[Status] ,[OnBroj] ,[Verzija] ,[Razlog] ,[DatumUnosa] ,[RIDBroj] ,[Komentar], [VozP], [Granicna], Platilac, AdHoc, PrevoznikZa, Faktura, Zadatak, CIM, DispecerRID, TipPrevoza, NetoTezinaM, PorudzbinaID, ImaPovrat, TehnologijaID, RobaNHM2, DodatnoPorudznina FROM [TESTIRANJE].[dbo].[Najava] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
               
                txtOpis.Text = dr["BrojNajave"].ToString();
                cmbVoz.SelectedValue = Convert.ToInt32(dr["Voz"].ToString());
                cboPosiljalac.SelectedValue = Convert.ToInt32(dr["Posiljalac"].ToString());
                cboPrevoznik.SelectedValue = Convert.ToInt32(dr["Prevoznik"].ToString());
                cboOtpravna.SelectedValue = Convert.ToInt32(dr["Otpravna"].ToString());
                cboUputna.SelectedValue = Convert.ToInt32(dr["Uputna"].ToString());
                cboPrimalac.SelectedValue = Convert.ToInt32(dr["Primalac"].ToString());
               //Obraditi checked
                cboNHM.SelectedValue = Convert.ToInt32(dr["RobaNHM"].ToString());
                txtRelacija.Text = dr["PrevozniPut"].ToString();
                txtNetoTezina.Value =  Convert.ToDecimal(dr["Tezina"].ToString());
                txtDuzinaM.Value =  Convert.ToDecimal(dr["Duzina"].ToString()); 
                txtBrojKola.Value = Convert.ToDecimal(dr["BrojKola"].ToString());
                txtNetoTezinaM.Value = Convert.ToDecimal(dr["NetoTezinaM"].ToString());
               
                //Nemamo Iz Najave polje
                
                if (dr["ImaPovrat"].ToString() == "1")
                {
                    chkImaPovrat.Checked = true;
                    VratiPodatkePorudzbina();
                    chkIzNajave.Checked = false;
                }
                else
                {
                    chkImaPovrat.Checked = false;
                    chkIzNajave.Checked = true;
                    VratiPodatkeNajava();
               
                }

               


                if (dr["RID"].ToString() == "1")
                {
                    chkRID.Checked = true;
                }
                else
                {
                    chkRID.Checked = false;
                    txtRID.Enabled = false;
                    txtRIDBroj.Enabled = false;
                }
                dtpPredvidjenoPrimanje.Value = Convert.ToDateTime(dr["PredvidjenoPrimanje"].ToString()); 
                dtpStvarnoPrimanje.Value  = Convert.ToDateTime(dr["StvarnoPrimanje"].ToString()); 
                dtpPredvidjenaPredaja.Value =  Convert.ToDateTime(dr["PredvidjenaPredaja"].ToString()); 
                dtpStvarnaPredaja.Value  =  Convert.ToDateTime(dr["StvarnaPredaja"].ToString());
                //cboStatusPredaje.Text, 
                cboStatusPredaje.SelectedValue = Convert.ToInt32(dr["Status"].ToString());
                txtRID.Text = dr["OnBroj"].ToString();
                txtRIDBroj.Text = dr["RIDBroj"].ToString();
                txtKomentar.Text = dr["Komentar"].ToString();
                cboVozP.SelectedValue = Convert.ToInt32(dr["VozP"].ToString());
                cboGranicna.SelectedValue = Convert.ToInt32(dr["Granicna"].ToString());
                if (dr["AdHoc"].ToString() == "1")
                {
                    chkAdHoc.Checked = true;
                }
                else
                {
                    chkAdHoc.Checked = false;
                }
                cboPlatilac.SelectedValue = Convert.ToInt32(dr["Platilac"].ToString());
                cboPrevoznikZa.SelectedValue = Convert.ToInt32(dr["PrevoznikZa"].ToString());
                txtUgovor.Text = dr["Faktura"].ToString();
                txtZadatak.Text = dr["Zadatak"].ToString();

                if (dr["CIM"].ToString() == "1")
                {
                    chkCIM.Checked = true;
                }
                else
                {
                    chkCIM.Checked = false;
                }

                txtDispecerRID.Text = dr["DispecerRID"].ToString();
                cboTipPrevoza.SelectedValue = Convert.ToInt32(dr["TipPrevoza"].ToString());
               
                
                
                cboTehnologijaID.SelectedValue = Convert.ToInt32(dr["TehnologijaID"].ToString());
                cboNHM2.SelectedValue = Convert.ToInt32(dr["RobaNHM2"].ToString());
                txtPorDodatno.Text = dr["DodatnoPorudznina"].ToString();
            }

            con.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbVoz_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sifarnici.frmTrase tr = new Sifarnici.frmTrase(Convert.ToInt32(cmbVoz.SelectedValue));
            tr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var select3 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Posiljalac = 1 order by PaNaziv";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboPosiljalac.DataSource = ds3.Tables[0];
            cboPosiljalac.DisplayMember = "Partner";
            cboPosiljalac.ValueMember = "PaSifra";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var select4 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Prevoznik = 1 order by PaNaziv";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPrevoznik.DataSource = ds4.Tables[0];
            cboPrevoznik.DisplayMember = "Partner";
            cboPrevoznik.ValueMember = "PaSifra";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var select6 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboOtpravna.DataSource = ds6.Tables[0];
            cboOtpravna.DisplayMember = "Stanica";
            cboOtpravna.ValueMember = "ID";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var select7 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboUputna.DataSource = ds7.Tables[0];
            cboUputna.DisplayMember = "Stanica";
            cboUputna.ValueMember = "ID";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var select11 = " Select ID, RTrim(Opis) as Stanica From Stanice order by Opis";
            var s_connection11 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection11 = new SqlConnection(s_connection11);
            var c11 = new SqlConnection(s_connection11);
            var dataAdapter11 = new SqlDataAdapter(select11, c11);

            var commandBuilder11 = new SqlCommandBuilder(dataAdapter11);
            var ds11 = new DataSet();
            dataAdapter11.Fill(ds11);
            cboGranicna.DataSource = ds11.Tables[0];
            cboGranicna.DisplayMember = "Stanica";
            cboGranicna.ValueMember = "ID";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var select5 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Primalac = 1 order By PaNaziv";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboPrimalac.DataSource = ds5.Tables[0];
            cboPrimalac.DisplayMember = "Partner";
            cboPrimalac.ValueMember = "PaSifra";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var select12 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Primalac = 1 order By PaNaziv";
            var s_connection12 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection12 = new SqlConnection(s_connection12);
            var c12 = new SqlConnection(s_connection12);
            var dataAdapter12 = new SqlDataAdapter(select12, c12);

            var commandBuilder12 = new SqlCommandBuilder(dataAdapter12);
            var ds12 = new DataSet();
            dataAdapter12.Fill(ds12);
            cboPlatilac.DataSource = ds12.Tables[0];
            cboPlatilac.DisplayMember = "Partner";
            cboPlatilac.ValueMember = "PaSifra";
        }

        private void cboStatusPredaje_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cboStatusPredaje_Validated(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void button11_Click(object sender, EventArgs e)
        {
         /*
                using (var f = new frmNajavaStavkePorudzbine(Convert.ToInt32(cboPlatilac.SelectedValue)))
                {
                  txtPorudzbinaID.Text = 
                    f.buttonOK.DialogResult = DialogResult.OK;
                    f.buttonCancel.DialogResult = DialogResult.Cancel;

                    var result = new ResultFromFrmMain();
                    result.Result = f.ShowDialog();

                    if (result.Result == DialogResult.OK)
                    {
                        // fill other values
                    }
                    return result;
                }
         */
            }

        private void multiColumnComboBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void multiColumnComboBox1_Enter(object sender, EventArgs e)
        {
            if (chkIzNajave.Checked == true)
            {

                var select = "   Select PorudzbinaID, ID as NajavaID, StvarnaPredaja, PrevozniPut, RobaNHM, RobaNHM2 from Najava " +
                "  where Faktura = '' and ImaPovrat = 1 and Status = 9 and Platilac = " + Convert.ToInt32(cboPlatilac.SelectedValue);
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);

                DataView view = new DataView(ds.Tables[0]);
                //multiColumnComboBox1.ReadOnly = true;
                multiColumnComboBox1.DataSource = view;
                multiColumnComboBox1.DisplayMember = "NajavaID";
                multiColumnComboBox1.ValueMember = "NajavaID";

            }
            else
            {
                //Selektovanje stavki u prvi kombo
                var select = "  select NarociloPostav.NaPNarZap ,NaPstNar as Porudzbina,NaPartPlac as Partner, " +
                 "NaDatNar as DatumNarudzbine, NaPNaziv as Naziv, NaPEM As JM, NaPem2 as JM2," +
                 " NaPKolNar as Kolicina, NaPKolNar2 as KolicinaJM2, NaPOpomba as NHM, " +
                 "NaPNote as Napomena   from Narocilo inner join NarociloPostav " +
    " on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
    " inner join MaticniPodatki  on MaticniPodatki.MpSifra = NarociloPostav.NaPSifra " +
    " where MpSifProdSkup in (1) and Narocilo.NaStNar > 542 and NaStatus = 'PO' and NaPartPlac = " + Convert.ToInt32(cboPlatilac.SelectedValue);
                //Uslov porucbine

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);

                DataView view = new DataView(ds.Tables[0]);
                //multiColumnComboBox1.ReadOnly = true;
                multiColumnComboBox1.DataSource = view;
                multiColumnComboBox1.DisplayMember = "NaPNarZap";
                multiColumnComboBox1.ValueMember = "NaPNarZap";






                //Proveriti ImaPovrat

                //Vratiti NHM

            }
        }
        private void ProveriImaPovrat()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);
            int ImaPovrat = 0;
            
            con.Open();

            SqlCommand cmd = new SqlCommand("Select Top 1 NaNacinDobave from Narocilo " +
            "   inner join NarociloPostav " +
            " on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
            " where NarociloPostav.NaPNarZap =" + Convert.ToInt32(multiColumnComboBox1.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                NacinD = dr["NaNacinDobave"].ToString();
                if (NacinD == "7")
                {
                    chkImaPovrat.Checked = true;
                    ImaPovrat = 1;
                }
                else if (NacinD == "8")
                {
                    chkImaPovrat.Checked = true;
                    ImaPovrat = 1;
                }
                else if (NacinD == "9")
                {
                    chkImaPovrat.Checked = true;
                    ImaPovrat = 1;
                }
                else if (NacinD == "10")
                {
                    chkImaPovrat.Checked = true;
                    ImaPovrat = 1;
                }
                else
                {
                    chkImaPovrat.Checked = false;
                    ImaPovrat = 0;
                }

               
                /*
                  if (dr["NaPKolNar2"].ToString() != null)
                  { 
                      txtNetoTezina.Value = Convert.ToDecimal(dr["NaPKolNar2"].ToString());
                  }
                  else
                  {
                      txtNetoTezina.Value = 0;
                  }
                */
                
            }

            con.Close();
            ProveriNHMOve(ImaPovrat);




        }

        private void ProveriNHMNajave()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

           
            con.Open();

            SqlCommand cmd = new SqlCommand("select RobaNHM, RobaNHM2 " +
            "  from Najava " +
            " where PorudzbinaID =" + Convert.ToInt32(multiColumnComboBox1.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cboNHM.SelectedValue = Convert.ToInt32(dr["RobaNHM2"].ToString());
                cboNHM2.SelectedValue = Convert.ToInt32(dr["RobaNHM"].ToString());
            }

            con.Close();

            
        }

        int VratiBrojPor()
        {
            int BrPor = 0;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);


            con.Open();

            SqlCommand cmd = new SqlCommand("select NaPStNar " +
            "  from NarociloPostav " +
            " where NaPNarZap =" + Convert.ToInt32(multiColumnComboBox1.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                BrPor = Convert.ToInt32(dr["NaPStNar"].ToString());
               
            }

            con.Close();

            return BrPor;
        }

        private void ProveriImaDodatneUsluge()
        {

            int VratiBrojPorudzbine = VratiBrojPor();
            
            var select = "  select NarociloPostav.NaPNarZap , " +
            " NaPNaziv,MpSifra " +
            "  from Narocilo inner join NarociloPostav " +
            " on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
            " inner join MaticniPodatki  on MaticniPodatki.MpSifra = NarociloPostav.NaPSifra " +
            " where NarociloPostav.NaPStNar =" + VratiBrojPorudzbine + " and MpSifProdSkup in (2, 3) ";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView5.ReadOnly = true;
            dataGridView5.DataSource = ds.Tables[0];

            dataGridView5.BorderStyle = BorderStyle.None;
            dataGridView5.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView5.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView5.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView5.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView5.BackgroundColor = Color.White;

            dataGridView5.EnableHeadersVisualStyles = false;
            dataGridView5.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView5.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewColumn column = dataGridView5.Columns[0];
            dataGridView5.Columns[0].HeaderText = "Porudzbina stavka";
            dataGridView5.Columns[0].Width = 70;

            DataGridViewColumn column2 = dataGridView5.Columns[1];
            dataGridView5.Columns[1].HeaderText = "Mp Naziv";
            dataGridView5.Columns[1].Width = 170;

            DataGridViewColumn column3 = dataGridView5.Columns[2];
            dataGridView5.Columns[2].HeaderText = "Šifra MP";
            dataGridView5.Columns[2].Width = 70;



        }
        private void NapunicboNHM1(string NHMOvi)
        {
            String str = NHMOvi;
            string NHMZaLike = "";
            String[] spearator = { "/" };
            Int32 count = 2;

            // using the method
            String[] strlist = str.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);
            int pom = 1;
            foreach (String s in strlist)
            {
                if (pom == 1)
                {
                    NHMZaLike = "'" + s  + "'";
                    pom = pom + 1; ;
                }
                else
                {
                    NHMZaLike = NHMZaLike + "," + "'" + s + "'" ;
                }
            }
           // NHMZaLike = NHMZaLike + "'";
            var select8 = " Select ID, RTrim(Broj) as NHM From NHM where Broj in (" + NHMZaLike + " ) order by Broj";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboNHM.DataSource = ds8.Tables[0];
            cboNHM.DisplayMember = "NHM";
            cboNHM.ValueMember = "ID";


        }

        private void NapunicboNHM2(string NHMOvi)
        {
            String str = NHMOvi;
            string NHMZaLike = "";
            String[] spearator = { "/" };
            Int32 count = 2;

            // using the method
            String[] strlist = str.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);
            int pom = 1;
            foreach (String s in strlist)
            {
                if (pom == 1)
                {
                    NHMZaLike = "'" + s + "'";
                    pom = pom + 1; ;
                }
                else
                {
                    NHMZaLike = NHMZaLike + "," + "'" + s + "'";
                }
            }
            //NHMZaLike = NHMZaLike + "'";
            var select8 = " Select ID, RTrim(Broj) as NHM From NHM where Broj in (" + NHMZaLike + " ) order by Broj";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboNHM2.DataSource = ds8.Tables[0];
            cboNHM2.DisplayMember = "NHM";
            cboNHM2.ValueMember = "ID";


        }

        private void ProveriNHMOve(int ImaPovrat)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            string NHMOvi = "";
            con.Open();

            SqlCommand cmd = new SqlCommand("select NarociloPostav.NaPNarZap , " +
            " NaPNaziv, NaPKolNar2 , NaPOpomba, NaIntOpomba3,NaOpomba1 " +
            "  from Narocilo inner join NarociloPostav " +
            " on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
            " where NaStatus = 'PO' and NarociloPostav.NaPNarZap =" + Convert.ToInt32(multiColumnComboBox1.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                NHMOvi = dr["NaPOpomba"].ToString();
                txtPorDodatno.Text = dr["NaOpomba1"].ToString();
            }

            con.Close();

            NHMOvi = NHMOvi.Remove(0, 5);
            if (ImaPovrat == 0)
            {
                //Nema povrat ali treba upisati u sve NHM ove koji se pojave
                if (NacinD == "5")
                {
                    NapunicboNHM1(NHMOvi);
                }
                else
                {
                    NapunicboNHM1("9920");
                }
                // cboNHM.SelectedValue = NHMOvi;
                cboNHM2.SelectedValue = 0;
                cboNHM2.Enabled = false;
            }
            else
            {
                if (NacinD == "7")
                {
                    //Prazno - Puno
                    NapunicboNHM1("9920");
                    NapunicboNHM2(NHMOvi);

                }
                else if (NacinD == "8")
                {
                    NapunicboNHM2("9920");
                    NapunicboNHM1(NHMOvi);

                }
                else if (NacinD == "9")
                {
                    NapunicboNHM2("9920");
                    NapunicboNHM1("9920");

                }
                else if (NacinD == "10")
                {
                    // "PUNO / PUNO"
                    String str = NHMOvi;

                    String[] spearator = { "-" };
                    Int32 count = 2;

                    // using the method
                    String[] strlist = str.Split(spearator, count,
                           StringSplitOptions.RemoveEmptyEntries);
                    int pom = 1;
                    foreach (String s in strlist)
                    {
                        if (pom == 1)
                        {
                            NapunicboNHM1(s);
                            
                            pom = 2;
                        }
                        else
                        {
                            NapunicboNHM2(s);
                        }
                    }
                }

                //Ima povrat i trba videti koji je nacin otpreme ako je PUNO-PUNO crtica
                
            }
        }

        private void PronadjiIDNhma(string s, int Prvi)
        {
            int ID = 0;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select ID " +
            "  from NHM  " +
            " where Broj =  '" + s + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ID = Convert.ToInt32(dr["ID"].ToString());
                if (Prvi == 1)
                {
                    cboNHM.SelectedValue = ID;                
                
                }
                else
                {
                    cboNHM2.SelectedValue = ID;
                }

            }

            con.Close();

        }

        private void VratiPodatkePorudzbinaSelect(int PorudzbinaID)
        {
            


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select NarociloPostav.NaPNarZap , " +
            " NaPNaziv, NaPKolNar2 , NaPOpomba, NaSifObjekt, NaOpomba1 " +
            "  from Narocilo inner join NarociloPostav " +
            " on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
            " where NaStatus = 'PO' and NarociloPostav.NaPNarZap =" + PorudzbinaID, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtRelacija.Text = dr["NaPNaziv"].ToString();
                /*
                  if (dr["NaPKolNar2"].ToString() != null)
                  { 
                      txtNetoTezina.Value = Convert.ToDecimal(dr["NaPKolNar2"].ToString());
                  }
                  else
                  {
                      txtNetoTezina.Value = 0;
                  }
                */
                txtPorDodatno.Text = dr["NaOpomba1"].ToString();
                txtNHMPorudzbina.Text = dr["NaPOpomba"].ToString();
                cboTipPrevoza.SelectedValue = Convert.ToInt32(dr["NaSifObjekt"].ToString());
                VratiTMPPor(PorudzbinaID);
            }

            con.Close();


        }
        private void VratiTMPPor(int PorudzbinaID)
        {
            var select = "   Select PorudzbinaID, Najava.ID as NajavaID, StvarnaPredaja, PrevozniPut, RobaNHM, NHM.Broj, RobaNHM2, N2.Broj from Najava " +
                   "  inner join NHM on NHM.ID = RobaNHM " +
                    " left join NHM as n2 on n2.ID = RobaNHM2" +
                "  where PorudzbinaID = " + PorudzbinaID;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            multiColumnComboBox1.DataSource = view;
            multiColumnComboBox1.DisplayMember = "PorudzbinaID";
            multiColumnComboBox1.ValueMember = "PorudzbinaID";


        }

        private void VratiPodatkePorudzbina()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select NarociloPostav.NaPNarZap , " +
            " NaPNaziv, NaPKolNar2 , NaPOpomba, NaSifObjekt, NaOpomba1 " +
            "  from Narocilo inner join NarociloPostav " +
            " on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
            " where NaStatus = 'PO' and NarociloPostav.NaPNarZap =" + Convert.ToInt32(multiColumnComboBox1.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtRelacija.Text = dr["NaPNaziv"].ToString();
                /*
                  if (dr["NaPKolNar2"].ToString() != null)
                  { 
                      txtNetoTezina.Value = Convert.ToDecimal(dr["NaPKolNar2"].ToString());
                  }
                  else
                  {
                      txtNetoTezina.Value = 0;
                  }
                */
                txtPorDodatno.Text = dr["NaOpomba1"].ToString(); 
                txtNHMPorudzbina.Text = dr["NaPOpomba"].ToString();
                cboTipPrevoza.SelectedValue =Convert.ToInt32(dr["NaSifObjekt"].ToString()) ;
            }

            con.Close();


        }

        private void VratiPodatkeNajavaSelect(int NajavaID)
        {
            //Iz Najava

            var select = "   Select PorudzbinaID, Najava.ID as NajavaID, StvarnaPredaja, PrevozniPut, RobaNHM, NHM.Broj, RobaNHM2, N2.Broj from Najava " +
              "  Left join NHM on NHM.ID = RobaNHM " +
               " left join NHM as n2 on n2.ID = RobaNHM2" +
           "  where PorudzbinaID = " + NajavaID;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            multiColumnComboBox1.DataSource = view;
            multiColumnComboBox1.DisplayMember = "PorudzbinaID";
            multiColumnComboBox1.ValueMember = "PorudzbinaID";

            //Ovde vratiti Vrednosti Iz Porudzbine


        }

        private void VratiPodatkeNajava()
        {
            var select = "   Select PorudzbinaID, Najava.ID as NajavaID, StvarnaPredaja, PrevozniPut, RobaNHM, NHM.Broj, RobaNHM2, N2.Broj from Najava " +
              "  left join NHM on NHM.ID = RobaNHM " +
               " left join NHM as n2 on n2.ID = RobaNHM2" +
           "  where Faktura = '' and ImaPovrat = 1 and Status = 9 and Platilac = " + Convert.ToInt32(cboPlatilac.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            multiColumnComboBox1.DataSource = view;
            multiColumnComboBox1.DisplayMember = "NajavaID";
            multiColumnComboBox1.ValueMember = "NajavaID";

            VratiTMPNajava(Convert.ToInt32(multiColumnComboBox1.Text));


        }


        private void VratiPodatkePromenaNajavaUpdate()
        {


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT " +
     "   [RobaNHM]       ,[PrevozniPut] " +
     "       ,[Platilac]  ,[TipPrevoza] " +
    "  ,[RobaNhm2]      ,[DodatnoPorudznina] " +
 "  FROM [TESTIRANJE].[dbo].Najava where [ID] = " + Convert.ToInt32(multiColumnComboBox1.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtRelacija.Text = dr["PrevozniPut"].ToString();
                /*
                  if (dr["NaPKolNar2"].ToString() != null)
                  { 
                      txtNetoTezina.Value = Convert.ToDecimal(dr["NaPKolNar2"].ToString());
                  }
                  else
                  {
                      txtNetoTezina.Value = 0;
                  }
                */
               // cboPosiljalac.SelectedValue = Convert.ToInt32(dr["Posiljalac"].ToString());
               // cboPrimalac.SelectedValue = Convert.ToInt32(dr["Primalac"].ToString());
               // cboGranicna.SelectedValue = Convert.ToInt32(dr["Granicna"].ToString());
               // cboPrimalac.SelectedValue = Convert.ToInt32(dr["Primalac"].ToString());
                cboPlatilac.SelectedValue = Convert.ToInt32(dr["Platilac"].ToString());
               // cboPrevoznik.SelectedValue = Convert.ToInt32(dr["Prevoznik"].ToString());
               // cboPosiljalac.SelectedValue = Convert.ToInt32(dr["Posiljalac"].ToString());
               // cboUputna.SelectedValue = Convert.ToInt32(dr["Uputna"].ToString());
               // cboOtpravna.SelectedValue = Convert.ToInt32(dr["Otpravna"].ToString());
                cboNHM2.SelectedValue = Convert.ToInt32(dr["RobaNhm"].ToString());
                cboNHM.SelectedValue = Convert.ToInt32(dr["RobaNhm2"].ToString());
                txtPorDodatno.Text = dr["DodatnoPorudznina"].ToString();
                // txtNHMPorudzbina.Text = dr["NaPOpomba"].ToString();
                cboTipPrevoza.SelectedValue = Convert.ToInt32(dr["TipPrevoza"].ToString());
            }

            con.Close();


        }

        private void VratiTMPNajavaSelect(int NajavaID)
        {
            
               
               

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[BrojNajave] ,[Voz] ,[Posiljalac] ,[Prevoznik],[Otpravna] ,[Uputna] ,[Primalac] ,[RobaNHM] ,[PrevozniPut] " +
            " ,[Tezina] ,[Duzina] ,[BrojKola] ,[RID] ,[PredvidjenoPrimanje] ,[StvarnoPrimanje] ,[PredvidjenaPredaja] ,[StvarnaPredaja] " +
            " ,[Status] ,[OnBroj] ,[Verzija] ,[Razlog] ,[DatumUnosa] ,[RIDBroj] ,[Komentar], [VozP], [Granicna], Platilac, AdHoc, PrevoznikZa, Faktura, Zadatak, CIM, DispecerRID, TipPrevoza, NetoTezinaM, PorudzbinaID, ImaPovrat, TehnologijaID, RobaNHM2, DodatnoPorudznina FROM [TESTIRANJE].[dbo].[Najava] where [ID] = " + Convert.ToInt32(multiColumnComboBox1.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                txtOpis.Text = dr["BrojNajave"].ToString();
                cmbVoz.SelectedValue = Convert.ToInt32(dr["Voz"].ToString());
                cboPosiljalac.SelectedValue = Convert.ToInt32(dr["Posiljalac"].ToString());
                cboPrevoznik.SelectedValue = Convert.ToInt32(dr["Prevoznik"].ToString());
                cboOtpravna.SelectedValue = Convert.ToInt32(dr["Otpravna"].ToString());
                cboUputna.SelectedValue = Convert.ToInt32(dr["Uputna"].ToString());
                cboPrimalac.SelectedValue = Convert.ToInt32(dr["Primalac"].ToString());
                //Obraditi checked
                cboNHM.SelectedValue = Convert.ToInt32(dr["RobaNhm"].ToString());
                cboNHM2.SelectedValue = Convert.ToInt32(dr["RobaNhm2"].ToString());
                txtRelacija.Text = dr["PrevozniPut"].ToString();
                txtNetoTezina.Value = Convert.ToDecimal(dr["Tezina"].ToString());
                txtDuzinaM.Value = Convert.ToDecimal(dr["Duzina"].ToString());
                txtBrojKola.Value = Convert.ToDecimal(dr["BrojKola"].ToString());
                txtNetoTezinaM.Value = Convert.ToDecimal(dr["NetoTezinaM"].ToString());
                if (dr["RID"].ToString() == "1")
                {
                    chkRID.Checked = true;
                }
                else
                {
                    chkRID.Checked = false;
                    txtRID.Enabled = false;
                    txtRIDBroj.Enabled = false;
                }
                dtpPredvidjenoPrimanje.Value = Convert.ToDateTime(dr["PredvidjenoPrimanje"].ToString());
                dtpStvarnoPrimanje.Value = Convert.ToDateTime(dr["StvarnoPrimanje"].ToString());
                dtpPredvidjenaPredaja.Value = Convert.ToDateTime(dr["PredvidjenaPredaja"].ToString());
                dtpStvarnaPredaja.Value = Convert.ToDateTime(dr["StvarnaPredaja"].ToString());
                //cboStatusPredaje.Text, 
                cboStatusPredaje.SelectedValue = Convert.ToInt32(dr["Status"].ToString());
                txtRID.Text = dr["OnBroj"].ToString();
                txtRIDBroj.Text = dr["RIDBroj"].ToString();
                txtKomentar.Text = dr["Komentar"].ToString();
                cboVozP.SelectedValue = Convert.ToInt32(dr["VozP"].ToString());
                cboGranicna.SelectedValue = Convert.ToInt32(dr["Granicna"].ToString());
                if (dr["AdHoc"].ToString() == "1")
                {
                    chkAdHoc.Checked = true;
                }
                else
                {
                    chkAdHoc.Checked = false;
                }
                cboPlatilac.SelectedValue = Convert.ToInt32(dr["Platilac"].ToString());
                cboPrevoznikZa.SelectedValue = Convert.ToInt32(dr["PrevoznikZa"].ToString());
                txtUgovor.Text = dr["Faktura"].ToString();
                txtZadatak.Text = dr["Zadatak"].ToString();

                if (dr["CIM"].ToString() == "1")
                {
                    chkCIM.Checked = true;
                }
                else
                {
                    chkCIM.Checked = false;
                }

                txtDispecerRID.Text = dr["DispecerRID"].ToString();
                cboTipPrevoza.SelectedValue = Convert.ToInt32(dr["TipPrevoza"].ToString()) - 1;
                cboTehnologijaID.SelectedValue = Convert.ToInt32(dr["TehnologijaID"].ToString());
                txtPorDodatno.Text = dr["DodatnoPorudznina"].ToString();
            }

            con.Close();


        }

        private void VratiTMPNajava(int NajavaID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT " +
          " [Posiljalac]      ,[Prevoznik]       ,[Otpravna] " +
     " ,[Uputna]  ,[Primalac]      ,[RobaNHM]       ,[PrevozniPut] "+   
     " ,[Granicna]       ,[Platilac]      ,[PrevoznikZa]      ,[TipPrevoza] " +
    "  ,[RobaNhm2]      ,[DodatnoPorudznina] " +
 "  FROM [TESTIRANJE].[dbo].Najava where [ID] = " + Convert.ToInt32(multiColumnComboBox1.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtRelacija.Text = dr["PrevozniPut"].ToString();
                /*
                  if (dr["NaPKolNar2"].ToString() != null)
                  { 
                      txtNetoTezina.Value = Convert.ToDecimal(dr["NaPKolNar2"].ToString());
                  }
                  else
                  {
                      txtNetoTezina.Value = 0;
                  }
                */
                cboPosiljalac.SelectedValue = Convert.ToInt32(dr["Posiljalac"].ToString());
                cboPrimalac.SelectedValue = Convert.ToInt32(dr["Primalac"].ToString());
                cboGranicna.SelectedValue = Convert.ToInt32(dr["Granicna"].ToString());
                cboPrimalac.SelectedValue = Convert.ToInt32(dr["Primalac"].ToString());
                cboPrevoznikZa.SelectedValue = Convert.ToInt32(dr["PrevoznikZa"].ToString());
                cboPrevoznik.SelectedValue = Convert.ToInt32(dr["Prevoznik"].ToString());
                cboPosiljalac.SelectedValue = Convert.ToInt32(dr["Posiljalac"].ToString());
                cboUputna.SelectedValue = Convert.ToInt32(dr["Uputna"].ToString());
                cboOtpravna.SelectedValue = Convert.ToInt32(dr["Otpravna"].ToString());
                cboNHM2.SelectedValue = Convert.ToInt32(dr["RobaNhm"].ToString());
                cboNHM.SelectedValue = Convert.ToInt32(dr["RobaNhm2"].ToString());
                txtPorDodatno.Text = dr["DodatnoPorudznina"].ToString();
               // txtNHMPorudzbina.Text = dr["NaPOpomba"].ToString();
                cboTipPrevoza.SelectedIndex = Convert.ToInt32(dr["TipPrevoza"].ToString());
            }

            con.Close();


        }

        private void multiColumnComboBox2_Click(object sender, EventArgs e)
        {
            var select = "  select NarociloPostav.NaPNarZap ,NaPartPlac as Partner, " +
            "NaDatNar as DatumNarudzbine, NaPNaziv as Naziv, NaPEM As JM, NaPem2 as JM2," +
            " NaPKolNar as Kolicina, NaPKolNar2 as KolicinaJM2, NaPOpomba as NHM, " +
            "NaPNote as Napomena   from Narocilo inner join NarociloPostav " +
" on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
" inner join MaticniPodatki  on MaticniPodatki.MpSifra = NarociloPostav.NaPSifra " +
" where MpSifProdSkup in (2, 3) and NaStatus = 'PO' and NaPartPlac = " + Convert.ToInt32(cboPlatilac.SelectedValue);


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            multiColumnComboBox2.DataSource = view;
            multiColumnComboBox2.DisplayMember = "NaPNarZap";
            multiColumnComboBox2.ValueMember = "NaPNarZap";
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            InsertNajava ins = new InsertNajava();
            if (txtSifra.Text == "")
            {
                MessageBox.Show("Morate prvo sačuvati zaglavlje pa onda dodati stavku");
            }
            else
            {
                ins.InsNajDodatneUSluge(Convert.ToInt32(multiColumnComboBox2.SelectedValue), Convert.ToInt32(txtSifra.Text));
                RefreshDataGrid4();
            }
          
        }

        private void multiColumnComboBox1_Leave(object sender, EventArgs e)
        {
           
            if (chkIzNajave.Checked == false)
            {
                VratiPodatkePorudzbina();

                ProveriImaPovrat();
                ProveriImaDodatneUsluge();
            }
            else
            {
                if (status == false)
                {
                    //Ako je update
                    VratiPodatkePromenaNajavaUpdate();
                   // ProveriNHMNajave();
                }
                else
                {
                    VratiPodatkeNajava();
                    ProveriNHMNajave();
                }
                

                // VratiPodatke();
            }
            //ProveriNHMOve();
        }

        private void multiColumnComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
           
        }

        private void chkIzNajave_Click(object sender, EventArgs e)
        {
           if (chkIzNajave.Checked == true)
                {
                chkImaPovrat.Checked = false;
            }
            else
            {
                chkImaPovrat.Checked = true;
            }
        }

        private void button11_Click_2(object sender, EventArgs e)
        {
            InsertNajava ins = new InsertNajava();
            ins.InsNajDeljenjeVoza(Convert.ToInt32(multiColumnComboBox2.SelectedValue), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtBrojKolaDodatni.Text), Convert.ToDouble(txtTezinaDodatno.TextAlign));
            RefreshDataGrid5();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var select2 = "  select NarociloPostav.NaPNarZap ,NaPstNar as Porudzbina,NaPartPlac as Partner, " +
 "NaDatNar as DatumNarudzbine, NaPNaziv as Naziv, NaPEM As JM, NaPem2 as JM2," +
 " NaPKolNar as Kolicina, NaPKolNar2 as KolicinaJM2, NaPOpomba as NHM, " +
 "NaPNote as Napomena   from Narocilo inner join NarociloPostav " +
" on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
" inner join MaticniPodatki  on MaticniPodatki.MpSifra = NarociloPostav.NaPSifra " +
" where MpSifProdSkup in (1) and Narocilo.NaStNar > 542 and NaStatus = 'PO' and NaPartPlac = " + Convert.ToInt32(cboPlatilac.SelectedValue);
            //Uslov porucbine

            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);

            DataView view2 = new DataView(ds2.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            multiColumnComboBox3.DataSource = view2;
            multiColumnComboBox3.DisplayMember = "NaPNarZap";
            multiColumnComboBox3.ValueMember = "NaPNarZap";


            RefreshDataGrid5();
        }

        private void cboPlatilac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmNajavaLog log = new frmNajavaLog();
            log.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPronadjiVagon pv = new Dokumenta.frmPronadjiVagon();
           
        }

        private void chkAdHoc_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void txtDispecerRID_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void chkIzNajave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkImaPovrat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtZadatak_TextChanged(object sender, EventArgs e)
        {

        }

        /*
        frmNajavaStavkePorudzbine nsp = new frmNajavaStavkePorudzbine(Convert.ToInt32(cboPlatilac.SelectedValue));
        nsp.Show();
       */
    }
    }

