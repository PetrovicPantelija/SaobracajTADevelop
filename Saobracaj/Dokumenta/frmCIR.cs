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

namespace TrackModal.Dokumeta
{
    public partial class frmCIR : Form
    {
        string KorisnikCene;
        bool status = false;
        int Dokument = 0;
        int Prijem = 0;

        DataTable ndt;
        int tk = 0;
        public frmCIR()
        {
            InitializeComponent();
        }

        public frmCIR(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

        public frmCIR(string Korisnik, int dDokument, int dPrijem, string Kontejner, string Vagon, double Tara, string BrojKamiona, double Neto, int TipKon, DateTime DatumUlaza, string sPlomba, string sPlomba2)
        {
            InitializeComponent();
            dtpDatumIn.Value = DatumUlaza;
            tk = TipKon;
            KorisnikCene = Korisnik;
            Dokument = dDokument;
            txtDokument.Text = Dokument.ToString();
            txtBrojKontejnera.Text = Kontejner;
            txtVagon.Text = Vagon;
            txtTara.Value = Convert.ToDecimal(Tara);
            txtNeto.Value = Convert.ToDecimal(Neto);
            txtBruto.Value = Convert.ToDecimal(Tara) + Convert.ToDecimal(Neto);
            txtTruckIn.Text = BrojKamiona;
            txtPlomba.Text = sPlomba;
            txtPlomba2.Text = sPlomba2;
            Prijem = dPrijem;
            if (Prijem == 0)
            {
                chkPrijem.Checked = true;
                chkincoming.Checked = false;
                VratiPodatkeZadnjiCIR(0);
            }
            else
            {
                chkincoming.Checked = true;
                chkPrijem.Checked = false;
                VratiPodatkeZadnjiCIR(1);
            }

            if (Neto > 0)
            {
                chkPun.Checked = true;
                chkPrazan.Checked = false;
            }
            else
            {
                chkPun.Checked = false;
                chkPrazan.Checked = true;
            }
            txtDelivery.Text = Korisnik;
        }
        //Panta vrati podatke zadnji
        private void VratiPodatkeZadnjiCIR(int prijem)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();
            string upit = "";
            if (prijem == 0)
            {
                upit = " SELECT top 1 [ID] ,[Size] " +
                      " ,[MaterijalCelik] ,[MaterijalAlumini]  " +
                      "  ,[Tezina] ,[Plomba1] " +
                      " ,[Plomba2],[DatumIn]  " +
                      " ,[Damaged],[Ispravan] ,[Prevoz],[Containerresponsible] " +
                      " ,[primedbe] ,[Received] ,[Inspected] ,[Delivery] " +
                      "   FROM [dbo].[CIR] " +
                      "  where Prijem = 1   order by ID desc";
            }
            else
            {
                upit = " SELECT top 1 [ID] ,[Size] " +
                   " ,[MaterijalCelik] ,[MaterijalAlumini]  " +
                   "  ,[Tezina] ,[Plomba1] " +
                   " ,[Plomba2],[DatumIn]  " +
                   " ,[Damaged],[Ispravan] ,[Prevoz],[Containerresponsible] " +
                   " ,[primedbe] ,[Received] ,[Inspected] ,[Delivery] " +
                   "   FROM [dbo].[CIR] " +
                   "  where Prijem <> 1   order by ID desc";
            }
            SqlCommand cmd = new SqlCommand(upit, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSize.Value = Convert.ToInt32(dr["Size"].ToString());
                // txtContainerresponsible.Text = dr["Containerresponsible"].ToString();

                txtprimedbe.Text = dr["Primedbe"].ToString();
                txtReceived.Text = dr["Received"].ToString();
                txtInspected.Text = dr["Inspected"].ToString();
                txtDelivery.Text = dr["Delivery"].ToString();
                //  dtpDatumIn.Value = Convert.ToDateTime(dr["DatumIn"].ToString());
                if (Convert.ToInt32(dr["Plomba2"].ToString()) == 1)
                {
                    chkPlomba2.Checked = true;
                }
                else
                {
                    chkPlomba2.Checked = false;
                }

                if (Convert.ToInt32(dr["Plomba1"].ToString()) == 1)
                {
                    chkPlomba1.Checked = true;
                }
                else
                {
                    chkPlomba1.Checked = false;
                }

                if (Convert.ToInt32(dr["Prevoz"].ToString()) == 1)
                {
                    chkPrevoz.Checked = true;
                }
                else
                {
                    chkPrevoz.Checked = false;
                }

                if (Convert.ToInt32(dr["Ispravan"].ToString()) == 1)
                {
                    chkIspravan.Checked = true;
                }
                else
                {
                    chkIspravan.Checked = false;
                }

                if (Convert.ToInt32(dr["Damaged"].ToString()) == 1)
                {
                    chkDemaged.Checked = true;
                }
                else
                {
                    chkDemaged.Checked = false;
                }
                if (Convert.ToInt32(dr["MaterijalCelik"].ToString()) == 1)
                {
                    chkMaterijalCelik.Checked = true;
                }
                else
                {
                    chkMaterijalCelik.Checked = false;
                }

                if (Convert.ToInt32(dr["MaterijalAlumini"].ToString()) == 1)
                {
                    chkAlumini.Checked = true;
                }
                else
                {
                    chkAlumini.Checked = false;
                }



            }

            con.Close();
        }

        private void dtpDatumOtpreme_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmCIR_Load(object sender, EventArgs e)
        {
            var select3 = " Select Distinct ID, Naziv   From Greske";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboOstecenja.DataSource = ds3.Tables[0];
            cboOstecenja.DisplayMember = "Naziv";
            cboOstecenja.ValueMember = "ID";

            var select4 = " Select Distinct ID, Naziv From TipKontenjera order by Naziv";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboTipKontejnera.DataSource = ds4.Tables[0];
            cboTipKontejnera.DisplayMember = "Naziv";
            cboTipKontejnera.ValueMember = "ID";

            var select5 = " Select Distinct ID, Naziv   From Delovi";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboDeo.DataSource = ds5.Tables[0];
            cboDeo.DisplayMember = "Naziv";
            cboDeo.ValueMember = "ID";

            VratiPodatkeTipKontejnera();
        }

        private void label5_Click(object sender, EventArgs e)
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

                Sifarnici.InsertCIR ins = new Sifarnici.InsertCIR();
                int MaterijalCelik = 0;
                int MaterijalAlumni = 0;
                int incoming = 0;
                int Pun = 0;
                int Plomba1 = 0;
                int Plomba2 = 0;
                int Damaged = 0;
                int Ispravan = 0;
                int Prevoz = 0;
                int Prijem = 0;

                if (chkMaterijalCelik.Checked == true)
                {
                    MaterijalCelik = 1;
                }

                if (chkAlumini.Checked == true)
                {
                    MaterijalAlumni = 1;
                }
                if (chkincoming.Checked == true)
                {
                    incoming = 1;
                }
                if (chkPun.Checked == true)
                {
                    Pun = 1;
                }
                if (chkPlomba1.Checked == true)
                {
                    Plomba1 = 1;
                }
                if (chkPlomba2.Checked == true)
                {
                    Plomba2 = 1;
                }
                if (chkDemaged.Checked == true)
                {
                    Damaged = 1;
                }
                if (chkIspravan.Checked == true)
                {
                    Ispravan = 1;
                }
                if (chkPrevoz.Checked == true)
                {
                    Prevoz = 1;
                }
                if (chkPrijem.Checked == true)
                {
                    Prijem = 1;
                }
                double TezinaPom = 0;
                TezinaPom = Convert.ToDouble(txtBruto.Text);

                ins.InsCIR(Convert.ToInt32(txtSize.Value), Convert.ToInt32(cboTipKontejnera.SelectedValue), MaterijalCelik, MaterijalAlumni, incoming, Pun, Convert.ToDouble(txtBruto.Text), txtBrojKontejnera.Text, Plomba1, Plomba2, Convert.ToDateTime(dtpDatumIn.Value), txtVagon.Text, txtTruckIn.Text, Damaged, Ispravan, Prevoz, txtContainerresponsible.Text, txtprimedbe.Text, txtReceived.Text, txtInspected.Text, txtDelivery.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, Prijem, Convert.ToInt32(txtDokument.Text), Convert.ToDouble(txtDuzina.Value), Convert.ToDouble(txtSirina.Value), Convert.ToDouble(txtDuzina.Value), txtPlomba.Text, txtPlomba2.Text);
                if (Prijem == 1)
                {
                    ins.UpdateCIRPrijem(Convert.ToInt32(txtDokument.Text));
                }
                else
                {
                    ins.UpdateCIROtprema(Convert.ToInt32(txtDokument.Text));
                }
                status = false;
                VratiPodatkeMax();
            }
            else
            {
                Sifarnici.InsertCIR upd = new Sifarnici.InsertCIR();
                int MaterijalCelik = 0;
                int MaterijalAlumni = 0;
                int incoming = 0;
                int Pun = 0;
                int Plomba1 = 0;
                int Plomba2 = 0;
                int Damaged = 0;
                int Ispravan = 0;
                int Prevoz = 0;
                int Prijem = 0;

                if (chkMaterijalCelik.Checked == true)
                {
                    MaterijalCelik = 1;
                }

                if (chkAlumini.Checked == true)
                {
                    MaterijalAlumni = 1;
                }
                if (chkincoming.Checked == true)
                {
                    incoming = 1;
                }
                if (chkPun.Checked == true)
                {
                    Pun = 1;
                }
                if (chkPlomba1.Checked == true)
                {
                    Plomba1 = 1;
                }
                if (chkPlomba2.Checked == true)
                {
                    Plomba2 = 1;
                }
                if (chkDemaged.Checked == true)
                {
                    Damaged = 1;
                }
                if (chkIspravan.Checked == true)
                {
                    Ispravan = 1;
                }
                if (chkPrevoz.Checked == true)
                {
                    Prevoz = 1;
                }
                if (chkPrijem.Checked == true)
                {
                    Prijem = 1;
                }
                double TezinaPom = 0;
                TezinaPom = Convert.ToDouble(txtBruto.Text);

                upd.UpdCIR(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtSize.Value), Convert.ToInt32(cboTipKontejnera.SelectedValue), MaterijalCelik, MaterijalAlumni, incoming, Pun, Convert.ToDouble(txtBruto.Text), txtBrojKontejnera.Text, Plomba1, Plomba2, Convert.ToDateTime(dtpDatumIn.Value), txtVagon.Text, txtTruckIn.Text, Damaged, Ispravan, Prevoz, txtContainerresponsible.Text, txtprimedbe.Text, txtReceived.Text, txtInspected.Text, txtDelivery.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, Prijem, Convert.ToInt32(txtDokument.Text), Convert.ToDouble(txtDuzina.Value), Convert.ToDouble(txtSirina.Value), Convert.ToDouble(txtDuzina.Value), txtPlomba.Text, txtPlomba2.Text);

                status = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSifra.Text == "")
            {
                MessageBox.Show("Niste uneli zaglavlje");
            }
            else
            {
                Sifarnici.InsertCIR ins = new Sifarnici.InsertCIR();
                ins.InsCIRGreske(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboOstecenja.SelectedValue), Convert.ToInt32(cboDeo.SelectedValue), Convert.ToDateTime(DateTime.Now), KorisnikCene);
                //RefreshDataGrid();
            }

            var select = "  select CIrGreske.ID as ID, Greske.Naziv as GreskaNaziv,  Delovi.Naziv as DeoNaziv from CIRGreske inner join Greske " +
            " on Greske.ID = CIrGreske.IDGreske " +
            "inner join Delovi on CIRGreske.IDDela = Delovi.ID" +
            " where IDNadredjenog = " + txtSifra.Text;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = false;
            dataGridView2.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 50;
            // dataGridView2.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Greška";
            dataGridView2.Columns[1].Width = 140;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Deo";
            dataGridView2.Columns[2].Width = 140;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (txtSifra.Text.Trim() == "")
            {
                MessageBox.Show("Niste sačuvali CIR");
                return;
            }

            Saobracaj.TrackModal.TestiranjeDataSet3TableAdapters.SelectCIRTableAdapter ta = new Saobracaj.TrackModal.TestiranjeDataSet3TableAdapters.SelectCIRTableAdapter();
            Saobracaj.TrackModal.TestiranjeDataSet3.SelectCIRDataTable dt = new Saobracaj.TrackModal.TestiranjeDataSet3.SelectCIRDataTable();


            Saobracaj.TrackModal.TestiranjeDataSet3TableAdapters.SelectCIRGreskeTableAdapter tal = new Saobracaj.TrackModal.TestiranjeDataSet3TableAdapters.SelectCIRGreskeTableAdapter();
            Saobracaj.TrackModal.TestiranjeDataSet3.SelectCIRGreskeDataTable dtl = new Saobracaj.TrackModal.TestiranjeDataSet3.SelectCIRGreskeDataTable();


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
            reportViewer1.LocalReport.ReportPath = "rptCIR.rdlc";
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

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from CIR ", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void VratiPodatkeTipKontejnera()
        {
            cboTipKontejnera.SelectedValue = tk;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Duzina,Sirina, Visina  from TipKontenjera where ID = " + Convert.ToInt32(cboTipKontejnera.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtDuzina.Text = dr["Duzina"].ToString();
                txtSirina.Text = dr["Sirina"].ToString();
                txtVisina.Text = dr["Visina"].ToString();
            }

            con.Close();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }

        private void chkPun_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPun.Checked == true)
            {
                chkPrazan.Checked = false;
            }
            else
            {
                chkPrazan.Checked = true;
                chkPun.Checked = false;
            }
        }

        private void chkMaterijalCelik_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaterijalCelik.Checked == true)
            {
                chkAlumini.Checked = false;
            }
        }

        private void chkAlumini_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlumini.Checked == true)
            {
                chkMaterijalCelik.Checked = false;
            }
            else
            {
                chkMaterijalCelik.Checked = true;
            }
        }

        private void chkDemaged_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDemaged.Checked == true)
            {
                chkIspravan.Checked = false;
            }
            else
            {
                chkIspravan.Checked = true;
            }
        }

        private void chkIspravan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIspravan.Checked == true)
            {
                chkDemaged.Checked = false;
            }
            else
            {
                chkDemaged.Checked = true;
            }
        }

        private void chkPrijem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrijem.Checked == true)
            {
                chkincoming.Checked = false;
            }
            else
            { chkincoming.Checked = true; }
        }

        private void chkPrazan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrazan.Checked == true)
            { chkPun.Checked = false; }
            else
            { chkPun.Checked = true; }
        }

        private void chkincoming_CheckedChanged(object sender, EventArgs e)
        {
            if (chkincoming.Checked == true)
            { chkPrijem.Checked = false; }
            else
            { chkPrijem.Checked = true; }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

            VratiPodatkeCIR(Convert.ToInt32(txtDokument.Text));
        }

        private void VratiPodatkeCIR(int dokument)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            string upit = "";
            if (chkPrijem.Checked == true)
            {
                upit = " select  CIR.[ID]      ,CIR.[Size]      ,CIR.[TiKontejnera] " +
             " ,CIR.[MaterijalCelik]      ,CIR.[MaterijalAlumini]      ,CIR.[incoming] " +
             " ,CIR.[Pun]      ,CIR.[Tezina]      ,CIR.[BrKontejnera] " +
             " ,CIR.[Plomba1]      ,CIR.[Plomba2]      ,CIR.[DatumIn] " +
             " ,CIR.[Vagon]      ,CIR.[TruckNo]      ,CIR.[Damaged] " +
             " ,CIR.[Ispravan]      ,CIR.[Prevoz]      ,CIR.[Containerresponsible] " +
             " ,CIR.[primedbe]      ,CIR.[Received]      ,CIR.[Inspected] " +
             " ,CIR.[Delivery]      ,CIR.[Datum]      ,CIR.[Korisnik] " +
             " ,CIR.[Prijem]      ,CIR.[Dokument]	  ,CIR.Duzina " +
             " ,CIR.Sirina	  ,CIR.Visina, CIR.sPlomba, CIR.sPlomba2      from CIR " +
             " where CIR.[Dokument] = " + dokument + "and Prijem = 1 Order by ID desc";
            }
            else
            {
                upit = " select  CIR.[ID]      ,CIR.[Size]      ,CIR.[TiKontejnera] " +
           " ,CIR.[MaterijalCelik]      ,CIR.[MaterijalAlumini]      ,CIR.[incoming] " +
           " ,CIR.[Pun]      ,CIR.[Tezina]      ,CIR.[BrKontejnera] " +
           " ,CIR.[Plomba1]      ,CIR.[Plomba2]      ,CIR.[DatumIn] " +
           " ,CIR.[Vagon]      ,CIR.[TruckNo]      ,CIR.[Damaged] " +
           " ,CIR.[Ispravan]      ,CIR.[Prevoz]      ,CIR.[Containerresponsible] " +
           " ,CIR.[primedbe]      ,CIR.[Received]      ,CIR.[Inspected] " +
           " ,CIR.[Delivery]      ,CIR.[Datum]      ,CIR.[Korisnik] " +
           " ,CIR.[Prijem]      ,CIR.[Dokument]	  ,CIR.Duzina " +
           " ,CIR.Sirina	  ,CIR.Visina, CIR.sPlomba, CIR.sPlomba2      from CIR " +
           " where CIR.[Dokument] = " + dokument + "and Prijem = 0 Order by ID desc";
            }

            SqlCommand cmd = new SqlCommand(upit, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    txtSifra.Text = dr["ID"].ToString();
                    txtVagon.Text = dr["Vagon"].ToString();
                    txtTruckIn.Text = dr["TruckNo"].ToString();
                    txtBruto.Value = Convert.ToDecimal(dr["Tezina"].ToString());
                    dtpDatumIn.Value = Convert.ToDateTime(dr["DatumIn"].ToString());
                    txtBrojKontejnera.Text = dr["BrKontejnera"].ToString();
                    txtSize.Value = Convert.ToInt32(dr["Size"].ToString());
                    txtSirina.Value = Convert.ToDecimal(dr["Sirina"].ToString());
                    txtVisina.Value = Convert.ToDecimal(dr["Visina"].ToString());
                    txtDuzina.Value = Convert.ToDecimal(dr["Duzina"].ToString());
                    txtContainerresponsible.Text = dr["Containerresponsible"].ToString();
                    txtprimedbe.Text = dr["Primedbe"].ToString();
                    txtReceived.Text = dr["Received"].ToString();
                    txtInspected.Text = dr["Inspected"].ToString();
                    txtDelivery.Text = dr["Delivery"].ToString();
                    txtPlomba.Text = dr["sPlomba"].ToString();
                    txtPlomba2.Text = dr["sPlomba2"].ToString();
                    cboTipKontejnera.SelectedValue = Convert.ToInt32(dr["TiKontejnera"].ToString());
                    //  dtpDatumIn.Value = Convert.ToDateTime(dr["DatumIn"].ToString());
                    if (Convert.ToInt32(dr["Plomba2"].ToString()) == 1)
                    {
                        chkPlomba2.Checked = true;
                    }
                    else
                    {
                        chkPlomba2.Checked = false;
                    }

                    if (Convert.ToInt32(dr["Plomba1"].ToString()) == 1)
                    {
                        chkPlomba1.Checked = true;
                    }
                    else
                    {
                        chkPlomba1.Checked = false;
                    }

                    if (Convert.ToInt32(dr["Prevoz"].ToString()) == 1)
                    {
                        chkPrevoz.Checked = true;
                    }
                    else
                    {
                        chkPrevoz.Checked = false;
                    }

                    if (Convert.ToInt32(dr["Ispravan"].ToString()) == 1)
                    {
                        chkIspravan.Checked = true;
                    }
                    else
                    {
                        chkIspravan.Checked = false;
                    }

                    if (Convert.ToInt32(dr["Damaged"].ToString()) == 1)
                    {
                        chkDemaged.Checked = true;
                    }
                    else
                    {
                        chkDemaged.Checked = false;
                    }
                    if (Convert.ToInt32(dr["MaterijalCelik"].ToString()) == 1)
                    {
                        chkMaterijalCelik.Checked = true;
                    }
                    else
                    {
                        chkMaterijalCelik.Checked = false;
                    }

                    if (Convert.ToInt32(dr["MaterijalAlumini"].ToString()) == 1)
                    {
                        chkAlumini.Checked = true;
                    }
                    else
                    {
                        chkAlumini.Checked = false;
                    }

                    if (Convert.ToInt32(dr["Incoming"].ToString()) == 1)
                    {
                        chkincoming.Checked = true;
                        chkPrijem.Checked = false;
                    }
                    else
                    {
                        chkincoming.Checked = false;
                        chkPrijem.Checked = true;
                    }
                    if (Convert.ToInt32(dr["Pun"].ToString()) == 1)
                    {
                        chkPun.Checked = true;
                        chkPrazan.Checked = false;
                    }
                    else
                    {
                        chkPun.Checked = false;
                        chkPrazan.Checked = true;
                    }





                }
                VratiPodatkeCirPostoje();
            }
            con.Close();

        }

        private void VratiPodatkeCirPostoje()
        {
            var select = "  select CIrGreske.ID as ID, Greske.Naziv as GreskaNaziv,  Delovi.Naziv as DeoNaziv from CIRGreske inner join Greske " +
            " on Greske.ID = CIrGreske.IDGreske " +
            "inner join Delovi on CIRGreske.IDDela = Delovi.ID" +
            " where IDNadredjenog = " + txtSifra.Text;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = false;
            dataGridView2.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 50;
            // dataGridView2.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Greška";
            dataGridView2.Columns[1].Width = 140;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Deo";
            dataGridView2.Columns[2].Width = 140;







        }

        private void txtPlomba_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Sifarnici.InsertCIR ins = new Sifarnici.InsertCIR();
                ins.DelCIRGreske(Convert.ToInt32(txtIDGreske.Text));

                var select = "  select CIrGreske.ID as ID, Greske.Naziv as GreskaNaziv,  Delovi.Naziv as DeoNaziv from CIRGreske inner join Greske " +
                " on Greske.ID = CIrGreske.IDGreske " +
                "inner join Delovi on CIRGreske.IDDela = Delovi.ID" +
                " where IDNadredjenog = " + txtSifra.Text;

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView2.ReadOnly = false;
                dataGridView2.DataSource = ds.Tables[0];

                DataGridViewColumn column = dataGridView2.Columns[0];
                dataGridView2.Columns[0].HeaderText = "ID";
                dataGridView2.Columns[0].Width = 50;
                // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView2.Columns[1];
                dataGridView2.Columns[1].HeaderText = "Greška";
                dataGridView2.Columns[1].Width = 140;

                DataGridViewColumn column3 = dataGridView2.Columns[2];
                dataGridView2.Columns[2].HeaderText = "Deo";
                dataGridView2.Columns[2].Width = 140;

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                        txtIDGreske.Text = row.Cells[0].Value.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        int VratiDaLiVozPrijem()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("Select Vozom from PrijemKontejneraVoz " +
                " inner join PrijemKontejneraVozStavke on PrijemKontejneraVoz.ID = PrijemKontejneraVozStavke.IDNadredjenog where PrijemKontejneraVozStavke.ID = " + Convert.ToInt32(txtDokument.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                return  Convert.ToInt32(dr["Vozom"].ToString());
            }

            con.Close();
            return 1;
        }

        int VratiDalijeVozOtprema()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("Select NacinOtpreme from OtpremaKontejnera " +
                " inner join OtpremaKontejneraVozStavke on OtpremaKontejnera.ID = OtpremaKontejneraVozStavke.IDNadredjenog where OtpremaKontejneraVozStavke.ID = " + Convert.ToInt32(txtDokument.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                return Convert.ToInt32(dr["NAcinOtpreme"].ToString());
            }

            con.Close();

            return 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int pomPrijem = 0;
            int pomVozom = 0;
            if (chkPrijem.Checked == true)
            {
                pomPrijem = 1;
                pomVozom = VratiDaLiVozPrijem();
            }
            else
            {
                pomPrijem = 0;
                pomVozom = VratiDalijeVozOtprema();

                
            }
            if (pomPrijem == 1)
            {
                //Prijem
                if (pomVozom == 0)
                {
                    txtContainerresponsible.Text = NapomenaPrijemKamionom();

                    //Kamionom
                }
                else
                {
                    txtContainerresponsible.Text = NapomenaPrijemVozom();
                    //Vozom

                }
            }
            else
            {
                if (pomVozom == 0)
                {
                    //Kamionom
                    txtContainerresponsible.Text = NapomenaOtpremaKamionom();
                }
                else
                {
                    txtContainerresponsible.Text = NapomenaOtpremaVozom();
                    //Vozom

                }

            }

             //txtBrojKontejnera   
            /*
        Select SUBSTRING(
            (
                 SELECT ';' + t1.Naziv AS 'data()'
                     FROM(Select VrstaManipulacije.Naziv from NaruceneManipulacije
            inner join VrstaManipulacije on VrstaManipulacije.ID = NaruceneManipulacije.VrstaManipulacije
            Where IDPrijemaVoza = 12091 and BrojKontejnera = 'PAGU3570180' and IzPrijema = 1)  t1 FOR XML PATH('') 
            ), 2 , 9999) As Manipulacije

        */
        }

        int VratiBrojPrijemnica()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("Select PrijemKontejneraVoz.ID as Broj from PrijemKontejneraVoz " +
                " inner join PrijemKontejneraVozStavke on PrijemKontejneraVoz.ID = PrijemKontejneraVozStavke.IDNadredjenog where PrijemKontejneraVozStavke.ID = " + Convert.ToInt32(txtDokument.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                return Convert.ToInt32(dr["Broj"].ToString());
            }

            con.Close();
            return 1;



        }


        int VratiBrojOtpreme()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("Select OtpremaKontejneraVoz.ID as Broj from OtpremaKontejneraVozz " +
                " inner join OtpremaKontejneraVozStavke on OtpremaKontejneraVoz.ID = OtpremaKontejneraVozStavke.IDNadredjenog where OtpremaKontejneraVozStavke.ID = " + Convert.ToInt32(txtDokument.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                return Convert.ToInt32(dr["Broj"].ToString());
            }

            con.Close();
            return 1;
        }

        string NapomenaPrijemVozom()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("  Select SUBSTRING( " +
           " ( " +
               "  SELECT ';' + t1.Naziv AS 'data()' " +
             "        FROM(Select VrstaManipulacije.Naziv from NaruceneManipulacije " +
           " inner join VrstaManipulacije on VrstaManipulacije.ID = NaruceneManipulacije.VrstaManipulacije " +
          "  Where IDPrijemaVoza =  " + VratiBrojPrijemnica() + "  and BrojKontejnera = '" + txtBrojKontejnera.Text + "' and IzPrijema = 1)  t1 FOR XML PATH('') " +
          "  ), 2, 9999) As Manipulacije ", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                return dr["Manipulacije"].ToString();
            }

            con.Close();

            return "";

        }

        string NapomenaPrijemKamionom()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("  Select SUBSTRING( " +
           " ( " +
               "  SELECT ';' + t1.Naziv AS 'data()' " +
             "        FROM(Select VrstaManipulacije.Naziv from NaruceneManipulacije " +
           " inner join VrstaManipulacije on VrstaManipulacije.ID = NaruceneManipulacije.VrstaManipulacije " +
          "  Where IDPrijemaKamionom =  " + VratiBrojPrijemnica() + "  and BrojKontejnera = '" + txtBrojKontejnera.Text + "' and IzPrijema = 1)  t1 FOR XML PATH('') " +
          "  ), 2, 9999) As Manipulacije ", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                return dr["Manipulacije"].ToString();
            }

            con.Close();

            return "";

        }


        string NapomenaOtpremaVozom()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("  Select SUBSTRING( " +
           " ( " +
               "  SELECT ';' + t1.Naziv AS 'data()' " +
             "        FROM(Select VrstaManipulacije.Naziv from NaruceneManipulacije " +
           " inner join VrstaManipulacije on VrstaManipulacije.ID = NaruceneManipulacije.VrstaManipulacije " +
          "  Where IDPrijemaVoza =  " + VratiBrojOtpreme() + "  and BrojKontejnera = '" + txtBrojKontejnera.Text + "' and IzPrijema = 0)  t1 FOR XML PATH('') " +
          "  ), 2, 9999) As Manipulacije ", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                return dr["Manipulacije"].ToString();
            }

            con.Close();

            return "";

        }

        string NapomenaOtpremaKamionom()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("  Select SUBSTRING( " +
           " ( " +
               "  SELECT ';' + t1.Naziv AS 'data()' " +
             "        FROM(Select VrstaManipulacije.Naziv from NaruceneManipulacije " +
           " inner join VrstaManipulacije on VrstaManipulacije.ID = NaruceneManipulacije.VrstaManipulacije " +
          "  Where IDPrijemaKamionom =  " + VratiBrojOtpreme() + "  and BrojKontejnera = '" + txtBrojKontejnera.Text + "' and IzPrijema = 0)  t1 FOR XML PATH('') " +
          "  ), 2, 9999) As Manipulacije ", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                return dr["Manipulacije"].ToString();
            }

            con.Close();

            return "";

        }

        private void tsDelete_Click_1(object sender, EventArgs e)
        {
            //za dodavanje
        }
    }
}
