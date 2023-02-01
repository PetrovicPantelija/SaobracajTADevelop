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

namespace Saobracaj.Testiranje
{
    public partial class TestiranjeStampa : Form
    {
        public TestiranjeStampa()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "TestiranjeStampa";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
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
        private void sfButton1_Click(object sender, EventArgs e)
        {
            TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter ta = new TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter();
            TESTIRANJEDataSet15.TestoviViewDataTable dt = new TESTIRANJEDataSet15.TestoviViewDataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;
            ReportParameter[] par = new ReportParameter[2];
            par[0] = new ReportParameter("Test", pom);
            par[1] = new ReportParameter("Korisnik", cboKorisnik.SelectedValue.ToString());
         
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptTestiranjeIzvestaj.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void TestiranjeStampa_Load(object sender, EventArgs e)
        {
            var select = "select ID, Naziv from Testovi";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            cboGrupaTesta.DataSource = view;
            cboGrupaTesta.DisplayMember = "Naziv";
            cboGrupaTesta.ValueMember = "ID";



            var select2 = "Select DeSifra, Korisnik from Korisnici order by Korisnik";

            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);

            DataView view2 = new DataView(ds2.Tables[0]);
        
            cboKorisnik.DataSource = view2;
            cboKorisnik.DisplayMember = "Korisnik";
            cboKorisnik.ValueMember = "DeSifra";
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            TESTIRANJEDataSet16TableAdapters.TestoviZ8TableAdapter ta = new TESTIRANJEDataSet16TableAdapters.TestoviZ8TableAdapter();
            TESTIRANJEDataSet16.TestoviZ8DataTable dt = new TESTIRANJEDataSet16.TestoviZ8DataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;
            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("Test", pom);
          

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptZ8.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
