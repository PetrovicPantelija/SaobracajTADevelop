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
    public partial class frmRadniNalogTransport : Form
    {
        string KorisnikCene = "";
        bool status = false;

        int VoziloS = 0;
        int PriklucjucnoVoziloS = 0;
        int transportnidispecerS = 0;
        string mestoizdavanjaS = "";
       
        

        DataTable ndt;
        public frmRadniNalogTransport(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

        public frmRadniNalogTransport()
        {
            InitializeComponent();
           
        }

        public frmRadniNalogTransport(int sifra, string Korisnik)
        {
            InitializeComponent();
            txtSifra.Text = sifra.ToString();
            KorisnikCene = Korisnik;
            VratiPodatke(sifra);
           
        }


        public frmRadniNalogTransport(string NalogZaPrevozID, string PutniNalogID, int VoziloP, string mestoizdavanjaP, int prikljucnovoziloP, int transportnidispecerP)
        {
            InitializeComponent();
            
            txtNalogZaPrevozID.Text = NalogZaPrevozID;
            txtPutniNalogID.Text = PutniNalogID;
            //////
            ///
          
            VoziloS = Convert.ToInt32(VoziloP);
            PriklucjucnoVoziloS = Convert.ToInt32(prikljucnovoziloP);
            transportnidispecerS = Convert.ToInt32(transportnidispecerP);
            mestoizdavanjaS = mestoizdavanjaP;

            dtpDatumPrevoza.Value = DateTime.Now;
            
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

            SqlCommand cmd = new SqlCommand("SELECT ID " +
             " ,[IDPutniNalog],[IDNalogZaPrevoz],[IDAutoprevoznilist],[IDVozilo] " +
             " ,[Dana],[TransportniDispecer] ,[DatumPrevoza] ,[MestoIzdavanja] " +
             " ,[PrikljucnoVoziloID] ,[RelacijaOd] " +
             " ,[RelacijaDo] ,[BrojOtpravljanja]      ,[BrojVagona] ,[NetoMasa] " +
             " ,[DatumIstovara]  FROM [dbo].[RadniNalogTransport] " +
             "   where ID = " + ID, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtPutniNalogID.Text = dr["IDPutniNalog"].ToString();
                txtNalogZaPrevozID.Text = dr["IDNalogZaPrevoz"].ToString();
                txtAutoprevozniListID.Text = dr["IDAutoprevoznilist"].ToString();
                cboVozilo.SelectedValue = Convert.ToInt32(dr["IDVozilo"].ToString());
                txtMestoIzdavanja.Text = dr["MestoIzdavanja"].ToString();
                dtpDatumPrevoza.Value = Convert.ToDateTime(dr["DatumPrevoza"].ToString());
                dtpDana.Value = Convert.ToDateTime(dr["Dana"].ToString());
                dtpDatumIstovara.Value = Convert.ToDateTime(dr["DatumIstovara"].ToString());
                cboTransportniDispičer.SelectedValue = Convert.ToInt32(dr["TransportniDispecer"].ToString());
              
                cboPrikljucnoVozilo.SelectedValue = Convert.ToInt32(dr["PrikljucnoVoziloID"].ToString());
                txtRelacija1.Text = dr["RelacijaOd"].ToString();
                txtRelacija2.Text = dr["RelacijaDo"].ToString();
                txtBrojVagona.Value = Convert.ToDecimal(dr["BrojVagona"].ToString());
                txtBrojOtpravljanja.Text = dr["BrojOtpravljanja"].ToString();
                txtNetoMasa.Value = Convert.ToDecimal(dr["NetoMasa"].ToString());
            }
            con.Close();
        }

      

        private void frmRadniNalogTransport_Load(object sender, EventArgs e)
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

            var select4 = "  select id, (Prezime + ' ' + Ime) as Naziv from Zaposleni ";
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

            if (txtSifra.Text != "")
            {
                VratiPodatke(Convert.ToInt32(txtSifra.Text));

            }
            else
            {
                cboVozilo.SelectedValue = Convert.ToInt32(VoziloS);
                cboPrikljucnoVozilo.SelectedValue = Convert.ToInt32(PriklucjucnoVoziloS);
                cboTransportniDispičer.SelectedValue = Convert.ToInt32(transportnidispecerS);
                txtMestoIzdavanja.Text = mestoizdavanjaS;
            }

            
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

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from RadniNalogTransport", con);
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
                Dokumeta.InsertRadniNalogTransport ins = new InsertRadniNalogTransport();
                ins.InsRadniNalogZaTransport(Convert.ToInt32(txtNalogZaPrevozID.Text), Convert.ToInt32(txtPutniNalogID.Text), Convert.ToInt32(txtAutoprevozniListID.Text), Convert.ToInt32(cboVozilo.SelectedValue), Convert.ToDateTime(dtpDana.Value), Convert.ToInt32(cboTransportniDispičer.SelectedValue), txtMestoIzdavanja.Text, Convert.ToDateTime(dtpDatumPrevoza.Value), DateTime.Now, KorisnikCene, Convert.ToInt32(cboPrikljucnoVozilo.SelectedValue), txtRelacija1.Text, txtRelacija2.Text, txtBrojOtpravljanja.Text, Convert.ToDouble(txtBrojVagona.Value), Convert.ToDouble(txtNetoMasa.Value), Convert.ToDateTime(dtpDatumIstovara.Value), txtRBRVoza.Text);
                status = false;
                VratiPodatkeMax();
            }
            else
            {

                if (status == true)
                {
                    Dokumeta.InsertRadniNalogTransport upd = new InsertRadniNalogTransport();
                    upd.UpdRadniNalogZaTransport(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtNalogZaPrevozID.Text), Convert.ToInt32(txtPutniNalogID.Text), Convert.ToInt32(txtAutoprevozniListID.Text), Convert.ToInt32(cboVozilo.SelectedValue), Convert.ToDateTime(dtpDana.Value), Convert.ToInt32(cboTransportniDispičer.SelectedValue), txtMestoIzdavanja.Text, Convert.ToDateTime(dtpDatumPrevoza.Value), DateTime.Now, KorisnikCene, Convert.ToInt32(cboPrikljucnoVozilo.SelectedValue), txtRelacija1.Text, txtRelacija2.Text, txtBrojOtpravljanja.Text, Convert.ToDouble(txtBrojVagona.Value), Convert.ToDouble(txtNetoMasa.Value), Convert.ToDateTime(dtpDatumIstovara.Value), txtRBRVoza.Text);
                    status = false;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (txtSifra.Text == "")
            {
                MessageBox.Show("Niste uneli zaglavlje");
            }
            else
            {
                InsertRadniNalogTransportStavke ins = new InsertRadniNalogTransportStavke();
                ins.InsRadniNalogTransportStavke(Convert.ToInt32(txtSifra.Text), txtKorisnik.Text, txtTovarniList.Text, txtRačun.Text, Convert.ToDouble(txtDencano.Value), Convert.ToDouble(txtKolsko.Value), Convert.ToDouble(txtPrihodDencano.Value), Convert.ToDouble(txtPrihodOstalo.Value), txtPrimedba.Text, txtPotpisao.Text);
                RefreshDataGridStavke();
            }
        }
        private void RefreshDataGridStavke()
        {
            var select = " SELECT [ID]      ,[IDNadredjenog]      ,[RB] " +
     " ,[Korisnik]      ,[TovList]      ,[Racun]      ,[Dencano] " +
     " ,[Kolsko]      ,[DencanoRSD]      ,[OstaloRSD]      ,[Primedba] " +
     " ,[Potpisao]  FROM[dbo].[RadniNalogTransportStavke] IdNadredjenog = " + txtSifra.Text + " order by RB";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = false;
            dataGridView1.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 40;
            // dataGridView2.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "ID nadr";
            dataGridView1.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "RB";
            dataGridView1.Columns[2].Width = 40;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Korisnik";
            dataGridView1.Columns[3].Width = 90;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Tov list";
            dataGridView1.Columns[4].Width = 60;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Račun";
            dataGridView1.Columns[5].Width = 60;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Denčano";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Kolsko";
            dataGridView1.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Denčano RSD";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Ostalo RSD";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Primedba";
            dataGridView1.Columns[10].Width = 120;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Potpisao";
            dataGridView1.Columns[11].Width = 120;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            InsertRadniNalogTransportStavke ins = new InsertRadniNalogTransportStavke();
            ins.UpdRadniNalogTransportStavke(Convert.ToInt32(txtStavka.Text), Convert.ToInt32(txtSifra.Text),  txtKorisnik.Text, txtTovarniList.Text, txtRačun.Text, Convert.ToDouble(txtDencano.Value), Convert.ToDouble(txtKolsko.Value), Convert.ToDouble(txtPrihodDencano.Value), Convert.ToDouble(txtPrihodOstalo.Value), txtPrimedba.Text, txtPotpisao.Text);
            RefreshDataGridStavke();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertRadniNalogTransportStavke del = new InsertRadniNalogTransportStavke();
                del.DeleteRadniNalogTransportStavke(Convert.ToInt32(txtStavka.Text));
                RefreshDataGridStavke();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
           Saobracaj.TrackModal.TestiranjeDataSet12TableAdapters.SelectRadniNalogTransportTableAdapter ta = new Saobracaj.TrackModal.TestiranjeDataSet12TableAdapters.SelectRadniNalogTransportTableAdapter();
            TestiranjeDataSet12.SelectRadniNalogTransportDataTable dt = new TestiranjeDataSet12.SelectRadniNalogTransportDataTable();


            Saobracaj.TrackModal.TestiranjeDataSet13TableAdapters.SelectRadniNalogTransportStavkeTableAdapter tal = new Saobracaj.TrackModal.TestiranjeDataSet13TableAdapters.SelectRadniNalogTransportStavkeTableAdapter();
            TestiranjeDataSet13.SelectRadniNalogTransportStavkeDataTable dtl = new TestiranjeDataSet13.SelectRadniNalogTransportStavkeDataTable();


            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            tal.Fill(dtl);

            ReportDataSource rdsl = new ReportDataSource();
            rdsl.Name = "DataSet1";
            rdsl.Value = dtl;
            ndt = dtl;

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptRadniNalogTransport.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SubreportProcessing += new
                       SubreportProcessingEventHandler(SetSubDataSource);
            reportViewer1.RefreshReport();
        }
        public void SetSubDataSource(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet1", ndt));
        }

        private void txtNetoMasa_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            frmAutoprevozniList2 auto = new frmAutoprevozniList2(txtNalogZaPrevozID.Text, txtPutniNalogID.Text, txtSifra.Text, Convert.ToInt32(cboVozilo.SelectedValue), txtMestoIzdavanja.Text, Convert.ToInt32(cboPrikljucnoVozilo.SelectedValue),  Convert.ToInt32(cboTransportniDispičer.SelectedValue));
            auto.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {


        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }
    }
    }

