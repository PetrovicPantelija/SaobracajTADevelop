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
    public partial class frmStampaRadnogNaloga : Form
    {
        public static string code = "frmStampaRadnogNaloga";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";

        DataTable ndt;
        DataTable ndtz;
        DataTable ndtu;
        DataTable ndte;
      
        public frmStampaRadnogNaloga()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public string IdGrupe()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            //Sifarnici.frmLogovanje frm = new Sifarnici.frmLogovanje();         
            string query = "Select IdGrupe from KorisnikGrupa Where Korisnik = " + "'" + Kor.TrimEnd() + "'";
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;

            while (dr.Read())
            {
                if (count == 0)
                {
                    niz = dr["IdGrupe"].ToString();
                    count++;
                }
                else
                {
                    niz = niz + "," + dr["IdGrupe"].ToString();
                    count++;
                }

            }
            conn.Close();
            return niz;
        }
        private int IdForme()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            string query = "Select IdForme from Forme where Rtrim(Code)=" + "'" + code + "'";
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idForme = Convert.ToInt32(dr["IdForme"].ToString());
            }
            conn.Close();
            return idForme;
        }

        private void PravoPristupa()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            string query = "Select * From GrupeForme Where IdGrupe in (" + niz + ") and IdForme=" + idForme;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == false)
            {
                MessageBox.Show("Nemate prava za pristup ovoj formi", code);
                Pravo = false;
            }
            else
            {
                Pravo = true;
                while (reader.Read())
                {
                    insert = Convert.ToBoolean(reader["Upis"]);
                    if (insert == false)
                    {
                        //tsNew.Enabled = false;
                    }
                    update = Convert.ToBoolean(reader["Izmena"]);
                    if (update == false)
                    {
                        //tsSave.Enabled = false;
                    }
                    delete = Convert.ToBoolean(reader["Brisanje"]);
                    if (delete == false)
                    {
                        //tsDelete.Enabled = false;
                    }
                }
            }

            conn.Close();
        }
        private void btnStampa_Click(object sender, EventArgs e)
        {

            TESTIRANJEDataSet2TableAdapters.SelectRadniNalogPosaoTableAdapter ta = new TESTIRANJEDataSet2TableAdapters.SelectRadniNalogPosaoTableAdapter();
            TESTIRANJEDataSet2.SelectRadniNalogPosaoDataTable dt = new TESTIRANJEDataSet2.SelectRadniNalogPosaoDataTable();

            TESTIRANJEDataSet2TableAdapters.SelectRadniNalogPosaoLokTableAdapter tal = new TESTIRANJEDataSet2TableAdapters.SelectRadniNalogPosaoLokTableAdapter();
            TESTIRANJEDataSet2.SelectRadniNalogPosaoLokDataTable dtl = new TESTIRANJEDataSet2.SelectRadniNalogPosaoLokDataTable();

            TESTIRANJEDataSet2TableAdapters.SelectRadniNalogPosaoZapTableAdapter taz = new TESTIRANJEDataSet2TableAdapters.SelectRadniNalogPosaoZapTableAdapter();
            TESTIRANJEDataSet2.SelectRadniNalogPosaoZapDataTable dtz = new TESTIRANJEDataSet2.SelectRadniNalogPosaoZapDataTable();

            TESTIRANJEDataSet2TableAdapters.SelectRadniNalogPosaoUzrTableAdapter tau = new TESTIRANJEDataSet2TableAdapters.SelectRadniNalogPosaoUzrTableAdapter();
            TESTIRANJEDataSet2.SelectRadniNalogPosaoUzrDataTable dtu = new TESTIRANJEDataSet2.SelectRadniNalogPosaoUzrDataTable();

            TESTIRANJEDataSet2TableAdapters.SelectRadniNalogTraseLokZapEvidTableAdapter tae = new TESTIRANJEDataSet2TableAdapters.SelectRadniNalogTraseLokZapEvidTableAdapter();
            TESTIRANJEDataSet2.SelectRadniNalogTraseLokZapEvidDataTable dte = new TESTIRANJEDataSet2.SelectRadniNalogTraseLokZapEvidDataTable();
       


            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet5";
            rds.Value = dt;

            tal.Fill(dtl);
            ReportDataSource rdsl = new ReportDataSource();
            rdsl.Name = "DataSet6";
            rdsl.Value = dtl;
            ndt = dtl;

            taz.Fill(dtz);
            ReportDataSource rdsz = new ReportDataSource();
            rdsz.Name = "DataSet7";
            rdsz.Value = dtz;
            ndtz = dtz;

            tau.Fill(dtu);
            ReportDataSource rdsu = new ReportDataSource();
            rdsu.Name = "DataSet8";
            rdsu.Value = dtu;
            ndtu = dtu;

            tae.Fill(dte);
            ReportDataSource rdse = new ReportDataSource();
            rdse.Name = "DataSet9";
            rdse.Value = dte;
            ndte = dte;


            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "frmStampaRadnogNaloga.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
           // reportViewer1.LocalReport.DataSources.Add(rdsl);
            reportViewer1.LocalReport.SubreportProcessing += new
                            SubreportProcessingEventHandler(SetSubDataSource);
            reportViewer1.LocalReport.SubreportProcessing += new
                           SubreportProcessingEventHandler(SetSubDataSourceZap);

            reportViewer1.LocalReport.SubreportProcessing += new
                          SubreportProcessingEventHandler(SetSubDataSourceUzr);

            reportViewer1.LocalReport.SubreportProcessing += new
                         SubreportProcessingEventHandler(SetSubDataSourceEvid);
            //SetSubDataSource
            reportViewer1.RefreshReport();

            
            /*
             Aziriraj Najavu
             
             */
        }
        public void SetSubDataSource(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet6", ndt));
        }

        public void SetSubDataSourceZap(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet7", ndtz));
        }

        public void SetSubDataSourceUzr(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet8", ndtu));
        }

        public void SetSubDataSourceEvid(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet9", ndte));
        }

        private void frmStampaRadnogNaloga_Load(object sender, EventArgs e)
        {

        }
    }
}
