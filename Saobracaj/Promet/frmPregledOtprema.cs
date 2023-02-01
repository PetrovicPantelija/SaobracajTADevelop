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

namespace TrackModal.Promet
{
    public partial class frmPregledOtprema : Form
    {
        public frmPregledOtprema()
        {
            InitializeComponent();
        }

        public frmPregledOtprema(string broj)
        {
            InitializeComponent();
            txtSifra.Text = broj;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Saobracaj.TrackModal.TestiranjeDataSet5TableAdapters.SelectNalogZaRAdPrometTableAdapter ta = new Saobracaj.TrackModal.TestiranjeDataSet5TableAdapters.SelectNalogZaRAdPrometTableAdapter();

            Saobracaj.TrackModal.TestiranjeDataSet5.SelectNalogZaRAdPrometDataTable dt = new Saobracaj.TrackModal.TestiranjeDataSet5.SelectNalogZaRAdPrometDataTable();
            /*
            TrackModalDataSet1TableAdapters.SelectZadatakPozicijaTableAdapter tal = new TrackModalDataSet1TableAdapters.SelectZadatakPozicijaTableAdapter();
            TrackModalDataSet1.SelectZadatakPozicijaDataTable dtl = new TrackModalDataSet1.SelectZadatakPozicijaDataTable();
            */
            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;


            Saobracaj.TrackModal.TestiranjeDataSet8TableAdapters.SelectNalogZaRadPrometMOTableAdapter taa = new Saobracaj.TrackModal.TestiranjeDataSet8TableAdapters.SelectNalogZaRadPrometMOTableAdapter();

            Saobracaj.TrackModal.TestiranjeDataSet8.SelectNalogZaRadPrometMODataTable dta = new Saobracaj.TrackModal.TestiranjeDataSet8.SelectNalogZaRadPrometMODataTable();

            taa.Fill(dta, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rdsa = new ReportDataSource();
            rdsa.Name = "DataSet2";
            rdsa.Value = dta;



            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("Dokument", txtSifra.Text);


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptNalogZaRadMO.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rdsa);
            /*
            reportViewer1.LocalReport.SubreportProcessing += new
                          SubreportProcessingEventHandler(SetSubDataSource);
             */
            reportViewer1.RefreshReport();
        }
    }
}
