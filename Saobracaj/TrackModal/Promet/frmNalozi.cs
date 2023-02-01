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
using Saobracaj.TrackModal;
using Microsoft.Reporting.WinForms;

namespace Testiranje.Promet
{
    public partial class frmNalozi : Form
    {
        DataTable ndt;
        public frmNalozi()
        {
            InitializeComponent();
        }

        public frmNalozi(string broj)
        {
            InitializeComponent();
            txtSifra.Text = broj;
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            Saobracaj.TrackModal.TestiranjeDataSet7TableAdapters.SelectNalogZaRAdPrometMSPTableAdapter ta = new Saobracaj.TrackModal.TestiranjeDataSet7TableAdapters.SelectNalogZaRAdPrometMSPTableAdapter();
            //using Saobracaj.TrackModal;
            TestiranjeDataSet7.SelectNalogZaRAdPrometMSPDataTable dt = new TestiranjeDataSet7.SelectNalogZaRAdPrometMSPDataTable();
            /*
            TestiranjeDataSet1TableAdapters.SelectZadatakPozicijaTableAdapter tal = new TestiranjeDataSet1TableAdapters.SelectZadatakPozicijaTableAdapter();
            TestiranjeDataSet1.SelectZadatakPozicijaDataTable dtl = new TestiranjeDataSet1.SelectZadatakPozicijaDataTable();
            */
            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;


            Saobracaj.TrackModal.TestiranjeDataSet6TableAdapters.SelectNalogZaRadPrometMTableAdapter taa = new Saobracaj.TrackModal.TestiranjeDataSet6TableAdapters.SelectNalogZaRadPrometMTableAdapter();

            TestiranjeDataSet6.SelectNalogZaRadPrometMDataTable dta = new TestiranjeDataSet6.SelectNalogZaRadPrometMDataTable();

            taa.Fill(dta, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rdsa = new ReportDataSource();
            rdsa.Name = "DataSet2";
            rdsa.Value = dta;



            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("Dokument", txtSifra.Text);


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptNalogZaRadMSP.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rdsa);
            /*
            reportViewer1.LocalReport.SubreportProcessing += new
                          SubreportProcessingEventHandler(SetSubDataSource);
             */
            reportViewer1.RefreshReport();

        }

        public void SetSubDataSource(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet2", ndt));
        }

        private void frmNalozi_Load(object sender, EventArgs e)
        {

        }
    }
}
