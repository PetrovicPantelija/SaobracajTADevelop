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

namespace Testiranje.Izvestaji
{
    public partial class frmZadrzavanjeKotejnera : Form
    {
        public frmZadrzavanjeKotejnera()
        {
            InitializeComponent();
        }

        private void frmZadrzavanjeKotejnera_Load(object sender, EventArgs e)
        {
            var select = "SELECT ID, Naziv from Komitenti where Vlasnik = 1";
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

            dtpDatumDo.Value = DateTime.Now;
            dtpDatumOd.Value = DateTime.Now;
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            InsertMen ins = new InsertMen();
            ins.InsZadrzavanje(Convert.ToDateTime(dtpDatumOd.Value), Convert.ToDateTime(dtpDatumDo.Value), Convert.ToInt32(cboKomitent.SelectedValue));

            Saobracaj.TrackModal.Izvestaji.DataSetZadrzavanjeKotejneraTableAdapters.ZadrzavanjeViewTableAdapter ta = new Saobracaj.TrackModal.Izvestaji.DataSetZadrzavanjeKotejneraTableAdapters.ZadrzavanjeViewTableAdapter();
            Saobracaj.TrackModal.Izvestaji.DataSetZadrzavanjeKotejnera.ZadrzavanjeViewDataTable dt = new Saobracaj.TrackModal.Izvestaji.DataSetZadrzavanjeKotejnera.ZadrzavanjeViewDataTable();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[3];
            par[0] = new ReportParameter("DatumOd", dtpDatumOd.Value.Date.ToShortDateString());
            par[1] = new ReportParameter("DatumDo", dtpDatumDo.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Vlasnik", cboKomitent.Text.ToString());



            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptZadrzavanjeKotejnera.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
