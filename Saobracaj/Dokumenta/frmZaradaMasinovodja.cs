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

namespace Saobracaj.Dokumenta
{
    public partial class frmZaradaMasinovodja : Form
    {
        DataTable ndt;
        public frmZaradaMasinovodja()
        {
            InitializeComponent();
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {/*
            TESTIRANJEDataSet9TableAdapters.SelectAktivnostiNovakTableAdapter ta = new TESTIRANJEDataSet9TableAdapters.SelectAktivnostiNovakTableAdapter();
            TESTIRANJEDataSet9.SelectAktivnostiNovakDataTable dt = new TESTIRANJEDataSet9.SelectAktivnostiNovakDataTable();

   
            ta.Fill(dt, Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
        
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;
            DateTime dtStartDate = dtpVremeOd.Value;
            DateTime dtEndDate = dtpVremeDo.Value;

            



            ReportParameter[] par = new ReportParameter[2];
           
            par[0] = new ReportParameter("DatumOd", dtStartDate.ToLongDateString(), false);
            par[1] = new ReportParameter("DatumDo", dtEndDate.ToLongDateString(), false);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "frmZaradeMasinovodje.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
        
          
            reportViewer1.RefreshReport();
          * */
        }

        public void SetSubDataSource(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSetZaradaStavke", ndt));
        }

        private void frmZarade_Load(object sender, EventArgs e)
        {
           
        }
    }
}
