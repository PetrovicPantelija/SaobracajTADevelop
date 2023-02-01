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

namespace TrackModal.Izvestaji
{
    public partial class frmSelectTransport3 : Form
    {
        public frmSelectTransport3()
        {
            InitializeComponent();
        }

        private void frmSelectTransport3_Load(object sender, EventArgs e)
        {

        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            Saobracaj.TrackModal.TestiranjeDataSet20TableAdapters.SelectTransport3TableAdapter ta = new Saobracaj.TrackModal.TestiranjeDataSet20TableAdapters.SelectTransport3TableAdapter();
            Saobracaj.TrackModal.TestiranjeDataSet20.SelectTransport3DataTable dt = new Saobracaj.TrackModal.TestiranjeDataSet20.SelectTransport3DataTable();

            ta.Fill(dt, Convert.ToDateTime(dtpDatumOd.Value), Convert.ToDateTime(dtpDatumDo.Value));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[2];
            par[0] = new ReportParameter("VremeOd", dtpDatumOd.Value.ToString());
            par[1] = new ReportParameter("VremeDo", dtpDatumDo.Value.ToString());
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptSelectTransport3.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
