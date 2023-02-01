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

namespace Testiranje.Izvestaji
{
    public partial class frmFakturisanjeMan : Form
    {
        public frmFakturisanjeMan()
        {
            InitializeComponent();
        }

        private void frmFakturisanjeMan_Load(object sender, EventArgs e)
        {
            var select = "SELECT ID, Naziv from Komitenti";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboKomitent.DataSource = ds.Tables[0];
            cboKomitent.DisplayMember = "Naziv";
            cboKomitent.ValueMember = "ID";

            //this.reportViewer1.RefreshReport();
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            Saobracaj.TrackModal.Izvestaji.DataSetFaktursanjeManTableAdapters.FakturisanjeManipulacijamaViewTableAdapter ta = new Saobracaj.TrackModal.Izvestaji.DataSetFaktursanjeManTableAdapters.FakturisanjeManipulacijamaViewTableAdapter();
            Saobracaj.TrackModal.Izvestaji.DataSetFaktursanjeMan.FakturisanjeManipulacijamaViewDataTable dt = new Saobracaj.TrackModal.Izvestaji.DataSetFaktursanjeMan.FakturisanjeManipulacijamaViewDataTable();
           // TestiranjeDataSet5TableAdapters.SelectNalogZaRAdPrometTableAdapter ta = new TestiranjeDataSet5TableAdapters.SelectNalogZaRAdPrometTableAdapter();
           // TestiranjeDataSet5.SelectNalogZaRAdPrometDataTable dt = new TestiranjeDataSet5.SelectNalogZaRAdPrometDataTable();

            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;


            ReportParameter[] par = new ReportParameter[3];
           // par[0] = new ReportParameter("Komitenti", cboKomitent.Text.ToString());
            par[0] = new ReportParameter("VremePrijema", txtDatumOd.Value.Date.ToShortDateString());
            par[1] = new ReportParameter("VremeOtpreme", txtDatumDo.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Naziv", cboKomitent.Text.ToString());

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptFakturisanjeManipulacija.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
