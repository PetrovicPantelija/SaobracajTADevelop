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
using Saobracaj.TrackModal;
namespace Testiranje.Dokumeta
{
    public partial class frmTovarniList : Form
    {
        string KorisnikCene = "";
        bool status = false;

        DataTable ndt;

        public frmTovarniList()
        {
            InitializeComponent();

            var select4 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPosiljalac.DataSource = ds4.Tables[0];
            cboPosiljalac.DisplayMember = "Naziv";
            cboPosiljalac.ValueMember = "ID";

            var select5 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboPrimalac.DataSource = ds5.Tables[0];
            cboPrimalac.DisplayMember = "Naziv";
            cboPrimalac.ValueMember = "ID";
        }

        public frmTovarniList(int Sifra)
        {
            InitializeComponent();
            txtSifra.Text = Sifra.ToString();

            var select4 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPosiljalac.DataSource = ds4.Tables[0];
            cboPosiljalac.DisplayMember = "Naziv";
            cboPosiljalac.ValueMember = "ID";

            var select5 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboPrimalac.DataSource = ds5.Tables[0];
            cboPrimalac.DisplayMember = "Naziv";
            cboPrimalac.ValueMember = "ID";


            VratiPodatke(Sifra);
          


        }

        private void VratiPodatke(int Sifra)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] " +
              " ,[Posiljalac],[Primalac]      ,[KorisnickaSIfraPosiljalac],[KorisnickaSifraPrimalac] " +
              " ,[FrankiraneTroskove],[NeFrankiraneTroskove]      ,[IzjavePosiljaoca] ,[ObavestenjePosiljaoca] " +
              " ,[Prilozi],[MestoIzdavanja]      ,[SifraMestaIzdavanja],[SifraStaniceMestaIzdavanja] " +
              " ,[KomercijalniUslovi],[KorisnickiSporazum]      ,[ObavestenjePrimaocu],[PreuzimanjeNaPrevoz] " +
              " ,[BrojKola],[FakturisanjeTranzita]      ,[PlacanjeTroskova],[NarocitaPosiljka] " +
              " ,[RID],[Vrednost]      ,[BrutoMasaRobe],[NetoRobe] " +
              " ,[BrutoMasaVoza],[ObezbedjenjeIsporuke]      ,[Pouzece],[MestoIspostavljanja] " +
              " ,[DatumIspostavljanja],[OznakaDokumenta]      ,[CIMBroj],[VrstaRobe] " +
              " ,[NHM] ,[MestoPreuzimanja]      ,[DrugiPrevoznici] " +
                " FROM [dbo].[TovarniList] where ID = " + Convert.ToInt32(Sifra), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtDrugiPrevoznici.Text = dr["DrugiPrevoznici"].ToString();
                txtMestoPreuzimanja.Text = dr["MestoPreuzimanja"].ToString();
                txtNHM.Text = dr["NHM"].ToString();
                txtVrstaRobe.Text = dr["VrstaRobe"].ToString();
                txtOznakaDokumenta.Text = dr["OznakaDokumenta"].ToString();
                dtpDatumIspostavljanja.Value = Convert.ToDateTime(dr["DatumIspostavljanja"].ToString());
                txtMestoIspostavljanja.Text = dr["MestoIspostavljanja"].ToString();
                txtPouzece.Text = dr["Pouzece"].ToString();
                txtObezbedjenjeIsporuke.Text = dr["ObezbedjenjeIsporuke"].ToString();
                txtBrutoMasaVoza.Value = Convert.ToDecimal(dr["BrutoMasaVoza"].ToString());
                txtNetoRobe.Value = Convert.ToDecimal(dr["NetoRobe"].ToString());
                txtBrutoMasaRobe.Value = Convert.ToDecimal(dr["BrutoMasaRobe"].ToString());
                txtVrednost.Value = Convert.ToDecimal(dr["Vrednost"].ToString());
                txtRID.Text = dr["RID"].ToString();
                txtNarocitaPosiljka.Text = dr["NarocitaPosiljka"].ToString();
                txtPlacanjeTroskova.Text = dr["PlacanjeTroskova"].ToString();
                txtFakturisanjeTranzita.Text = dr["FakturisanjeTranzita"].ToString();
                txtBrojKola.Text = dr["BrojKola"].ToString();
                txtPreuzimanjeNaPrevoz.Text = dr["PreuzimanjeNaPrevoz"].ToString();
                txtObavestenjePrimaocu.Text = dr["ObavestenjePrimaocu"].ToString();
                txtKorisnickiSporazum.Text = dr["KorisnickiSporazum"].ToString();
                txtKomercijalniUslovi.Text = dr["KomercijalniUslovi"].ToString();
                txtSifraStaniceMestaIzdavanja.Text = dr["SifraStaniceMestaIzdavanja"].ToString();
                txtSifraMestaIzdavanja.Text = dr["SifraMestaIzdavanja"].ToString();
                cboMestoIzdavanja.Text = dr["MestoIzdavanja"].ToString();
                txtPrilozi.Text = dr["Prilozi"].ToString();
                txtObavestenjePosiljaoca.Text = dr["ObavestenjePosiljaoca"].ToString();
                txtIzjavePosiljaoca.Text = dr["IzjavePosiljaoca"].ToString();
                txtNeFrankiraneTroskove.Text = dr["NeFrankiraneTroskove"].ToString();
              //  txtFrankiraneTroskove.Text = dr["FrankiraneTroskove"].ToString();
                txtKorisnickaSifraPrimalac.Text = dr["KorisnickaSifraPrimalac"].ToString();
                txtKorisnickaSIfraPosiljalac.Text = dr["KorisnickaSIfraPosiljalac"].ToString();
                txtCIMBroj.Text = dr["CIMBroj"].ToString();
                cboPosiljalac.SelectedValue = Convert.ToInt32(dr["Posiljalac"].ToString());
              cboPrimalac.SelectedValue = Convert.ToInt32(dr["Primalac"].ToString());

            }

            con.Close();

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from TovarniList", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                Dokumeta.InsertTovarniList ins = new Dokumeta.InsertTovarniList();
                ins.InsTovarniList(Convert.ToInt32(cboPosiljalac.SelectedValue), Convert.ToInt32(cboPrimalac.SelectedValue), txtKorisnickaSIfraPosiljalac.Text, txtKorisnickaSifraPrimalac.Text, txtFrankiraneTroskove.Text, txtNeFrankiraneTroskove.Text, txtIzjavePosiljaoca.Text, txtObavestenjePosiljaoca.Text, txtPrilozi.Text, Convert.ToInt32(cboMestoIzdavanja.SelectedValue), txtSifraMestaIzdavanja.Text, txtSifraStaniceMestaIzdavanja.Text, txtKomercijalniUslovi.Text, txtKorisnickiSporazum.Text, txtObavestenjePrimaocu.Text, txtPreuzimanjeNaPrevoz.Text, txtBrojKola.Text, txtFakturisanjeTranzita.Text, txtPlacanjeTroskova.Text, txtNarocitaPosiljka.Text, txtRID.Text, Convert.ToDouble(txtVrednost.Value), Convert.ToDouble(txtBrutoMasaRobe.Value), Convert.ToDouble(txtNetoRobe.Value), Convert.ToDouble(txtBrutoMasaVoza.Value), txtObezbedjenjeIsporuke.Text, txtPouzece.Text, txtMestoIspostavljanja.Text, dtpDatumIspostavljanja.Value, txtOznakaDokumenta.Text, txtCIMBroj.Text, txtVrstaRobe.Text, txtNHM.Text, txtMestoPreuzimanja.Text);
                status = false;
                VratiPodatkeMax();
            }
            else
            {
                    Dokumeta.InsertTovarniList upd = new Dokumeta.InsertTovarniList();
                    upd.UpdTovarniList(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboPosiljalac.SelectedValue), Convert.ToInt32(cboPrimalac.SelectedValue), txtKorisnickaSIfraPosiljalac.Text, txtKorisnickaSifraPrimalac.Text, txtFrankiraneTroskove.Text, txtNeFrankiraneTroskove.Text, txtIzjavePosiljaoca.Text, txtObavestenjePosiljaoca.Text, txtPrilozi.Text, Convert.ToInt32(cboMestoIzdavanja.SelectedValue), txtSifraMestaIzdavanja.Text, txtSifraStaniceMestaIzdavanja.Text, txtKomercijalniUslovi.Text, txtKorisnickiSporazum.Text, txtObavestenjePrimaocu.Text, txtPreuzimanjeNaPrevoz.Text, txtBrojKola.Text, txtFakturisanjeTranzita.Text, txtPlacanjeTroskova.Text, txtNarocitaPosiljka.Text, txtRID.Text, Convert.ToDouble(txtVrednost.Value), Convert.ToDouble(txtBrutoMasaRobe.Value), Convert.ToDouble(txtNetoRobe.Value), Convert.ToDouble(txtBrutoMasaVoza.Value), txtObezbedjenjeIsporuke.Text, txtPouzece.Text, txtMestoIspostavljanja.Text, dtpDatumIspostavljanja.Value, txtOznakaDokumenta.Text, txtCIMBroj.Text, txtVrstaRobe.Text, txtNHM.Text, txtMestoPreuzimanja.Text);
                    status = false;
              
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Saobracaj.TrackModal.TestiranjeDataSet16TableAdapters.SelectTovarniListTableAdapter ta = new Saobracaj.TrackModal.TestiranjeDataSet16TableAdapters.SelectTovarniListTableAdapter();
            TestiranjeDataSet16.SelectTovarniListDataTable dt = new TestiranjeDataSet16.SelectTovarniListDataTable();


            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;


            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptTovarniList.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmTovarniList_Load(object sender, EventArgs e)
        {
         
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
