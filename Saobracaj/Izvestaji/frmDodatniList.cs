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
    public partial class frmDodatniList : Form
    {
        public frmDodatniList()
        {
            InitializeComponent();
        }

        public frmDodatniList(int broj)
        {
            InitializeComponent();
            txtSifra.Text = broj.ToString();
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            Saobracaj.TrackModal.TestiranjeDataSetTableAdapters.SelectDodatniListTableAdapter ta = new Saobracaj.TrackModal.TestiranjeDataSetTableAdapters.SelectDodatniListTableAdapter();

            Saobracaj.TrackModal.TestiranjeDataSet.SelectDodatniListDataTable dt = new Saobracaj.TrackModal.TestiranjeDataSet.SelectDodatniListDataTable();

            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptDodatniList.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void frmDodatniList_Load(object sender, EventArgs e)
        {

        }
    }
}
