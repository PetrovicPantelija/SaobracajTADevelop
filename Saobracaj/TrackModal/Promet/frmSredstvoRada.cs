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

using Microsoft.Reporting.WinForms;

namespace Testiranje.Promet
{
    public partial class frmSredstvoRada : Form
    {
        // DataTable ndt;
        public frmSredstvoRada()
        {
            InitializeComponent();
        }

        public frmSredstvoRada(string broj)
        {
            InitializeComponent();
            txtSifra.Text = broj;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Saobracaj.TrackModal.TestiranjeDataSet5TableAdapters.SelectNalogZaRAdPrometTableAdapter ta = new Saobracaj.TrackModal.TestiranjeDataSet5TableAdapters.SelectNalogZaRAdPrometTableAdapter();

            Saobracaj.TrackModal.TestiranjeDataSet5.SelectNalogZaRAdPrometDataTable dt = new Saobracaj.TrackModal.TestiranjeDataSet5.SelectNalogZaRAdPrometDataTable();
            /*
            TestiranjeDataSet1TableAdapters.SelectZadatakPozicijaTableAdapter tal = new TestiranjeDataSet1TableAdapters.SelectZadatakPozicijaTableAdapter();
            TestiranjeDataSet1.SelectZadatakPozicijaDataTable dtl = new TestiranjeDataSet1.SelectZadatakPozicijaDataTable();
            */
            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;


            Saobracaj.TrackModal.TestiranjeDataSet6TableAdapters.SelectNalogZaRadPrometMTableAdapter taa = new Saobracaj.TrackModal.TestiranjeDataSet6TableAdapters.SelectNalogZaRadPrometMTableAdapter();

            Saobracaj.TrackModal.TestiranjeDataSet6.SelectNalogZaRadPrometMDataTable dta = new Saobracaj.TrackModal.TestiranjeDataSet6.SelectNalogZaRadPrometMDataTable();
          
            taa.Fill(dta, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rdsa = new ReportDataSource();
            rdsa.Name = "DataSet2";
            rdsa.Value = dta;

         

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("Dokument", txtSifra.Text);
           

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptNalogZaRad.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rdsa);
            /*
            reportViewer1.LocalReport.SubreportProcessing += new
                          SubreportProcessingEventHandler(SetSubDataSource);
             */
            reportViewer1.RefreshReport();
        }

        private void frmSredstvoRada_Load(object sender, EventArgs e)
        {
            /*var select4 = " Select Distinct ID, (Naziv + ' RO:' +  RegistarskaOznaka + ' IB:' + IndividualniBroj) as Naziv   From Vozila";
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
            */
        }


    }
}
