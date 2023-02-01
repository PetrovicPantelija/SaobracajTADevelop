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
    public partial class Obrasci : Form
    {
        public Obrasci()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "Obrasci";
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
                       // tsNew.Enabled = false;
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
        private void Obrasci_Load(object sender, EventArgs e)
        {
            var select2 = "Select DeSifra, (Rtrim(DePriimek) + ' ' + Rtrim(DeIme)) as Korisnik from Delavci order by Rtrim(DePriimek)";

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

        private void StampajManevristu()
        {
            TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter ta = new TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter();
            TESTIRANJEDataSet15.TestoviViewDataTable dt = new TESTIRANJEDataSet15.TestoviViewDataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            // string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[3];

            par[0] = new ReportParameter("Zaposleni", cboKorisnik.Text.ToString());
            par[1] = new ReportParameter("Datum", dtpDatumTesta.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Dodatak", txtMesto.Text.ToString());

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptObrazac6Manevrsita.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();

        }

        private void StampajPregledacKola()
        {
            TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter ta = new TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter();
            TESTIRANJEDataSet15.TestoviViewDataTable dt = new TESTIRANJEDataSet15.TestoviViewDataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            // string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[3];

            par[0] = new ReportParameter("Zaposleni", cboKorisnik.Text.ToString());
            par[1] = new ReportParameter("Datum", dtpDatumTesta.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Dodatak", txtMesto.Text.ToString());

            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.ReportPath = "rptObrazac6PregledacKola.rdlc";
            reportViewer2.LocalReport.SetParameters(par);
            reportViewer2.LocalReport.DataSources.Add(rds);
            reportViewer2.RefreshReport();

        }

        private void StampajVozovodja()
        {
            TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter ta = new TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter();
            TESTIRANJEDataSet15.TestoviViewDataTable dt = new TESTIRANJEDataSet15.TestoviViewDataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            // string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[3];

            par[0] = new ReportParameter("Zaposleni", cboKorisnik.Text.ToString());
            par[1] = new ReportParameter("Datum", dtpDatumTesta.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Dodatak", txtMesto.Text.ToString());

            reportViewer3.LocalReport.DataSources.Clear();
            reportViewer3.LocalReport.ReportPath = "rptObrazac6Vozovodja.rdlc";
            reportViewer3.LocalReport.SetParameters(par);
            reportViewer3.LocalReport.DataSources.Add(rds);
            reportViewer3.RefreshReport();

        }

        private void StampajMasinovodjaElektroVuce()
        {
            TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter ta = new TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter();
            TESTIRANJEDataSet15.TestoviViewDataTable dt = new TESTIRANJEDataSet15.TestoviViewDataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            // string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[3];

            par[0] = new ReportParameter("Zaposleni", cboKorisnik.Text.ToString());
            par[1] = new ReportParameter("Datum", dtpDatumTesta.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Dodatak", txtMesto.Text.ToString());

            reportViewer4.LocalReport.DataSources.Clear();
            reportViewer4.LocalReport.ReportPath = "rptObrazac6MasinovodjaElektrovuce.rdlc";
            reportViewer4.LocalReport.SetParameters(par);
            reportViewer4.LocalReport.DataSources.Add(rds);
            reportViewer4.RefreshReport();

        }

        private void StampajMasinovodjaNaManevri()
        {
            TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter ta = new TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter();
            TESTIRANJEDataSet15.TestoviViewDataTable dt = new TESTIRANJEDataSet15.TestoviViewDataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            // string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[3];

            par[0] = new ReportParameter("Zaposleni", cboKorisnik.Text.ToString());
            par[1] = new ReportParameter("Datum", dtpDatumTesta.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Dodatak", txtMesto.Text.ToString());

            reportViewer5.LocalReport.DataSources.Clear();
            reportViewer5.LocalReport.ReportPath = "rptObrazac6MasinovodjaNaManevri.rdlc";
            reportViewer5.LocalReport.SetParameters(par);
            reportViewer5.LocalReport.DataSources.Add(rds);
            reportViewer5.RefreshReport();

        }

        private void StampajMasinovodja()
        {
            TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter ta = new TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter();
            TESTIRANJEDataSet15.TestoviViewDataTable dt = new TESTIRANJEDataSet15.TestoviViewDataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            // string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[3];

            par[0] = new ReportParameter("Zaposleni", cboKorisnik.Text.ToString());
            par[1] = new ReportParameter("Datum", dtpDatumTesta.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Dodatak", txtMesto.Text.ToString());

            reportViewer6.LocalReport.DataSources.Clear();
            reportViewer6.LocalReport.ReportPath = "rptObrazac6Masinovodja.rdlc";
            reportViewer6.LocalReport.SetParameters(par);
            reportViewer6.LocalReport.DataSources.Add(rds);
            reportViewer6.RefreshReport();

        }

        private void StampajPomocnikMasinovodje()
        {
            TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter ta = new TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter();
            TESTIRANJEDataSet15.TestoviViewDataTable dt = new TESTIRANJEDataSet15.TestoviViewDataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            // string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[3];

            par[0] = new ReportParameter("Zaposleni", cboKorisnik.Text.ToString());
            par[1] = new ReportParameter("Datum", dtpDatumTesta.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Dodatak", txtMesto.Text.ToString());

            reportViewer7.LocalReport.DataSources.Clear();
            reportViewer7.LocalReport.ReportPath = "rptObrazac6PomocnikMasinovodje.rdlc";
            reportViewer7.LocalReport.SetParameters(par);
            reportViewer7.LocalReport.DataSources.Add(rds);
            reportViewer7.RefreshReport();

        }

        private void StampajRukovaocManevre()
        {
            TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter ta = new TESTIRANJEDataSet15TableAdapters.TestoviViewTableAdapter();
            TESTIRANJEDataSet15.TestoviViewDataTable dt = new TESTIRANJEDataSet15.TestoviViewDataTable();
            //  NedraDataSet2TableAdapters.SelectNajavaTableAdapter ta = new NedraDataSet2TableAdapters.SelectNajavaTableAdapter();
            // NedraDataSet2.SelectNajavaDataTable dt = new NedraDataSet2.SelectNajavaDataTable();
            // string pom = cboGrupaTesta.SelectedValue.ToString();
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[3];

            par[0] = new ReportParameter("Zaposleni", cboKorisnik.Text.ToString());
            par[1] = new ReportParameter("Datum", dtpDatumTesta.Value.Date.ToShortDateString());
            par[2] = new ReportParameter("Dodatak", txtMesto.Text.ToString());

            reportViewer8.LocalReport.DataSources.Clear();
            reportViewer8.LocalReport.ReportPath = "rptObrazac6RukovaocManevre.rdlc";
            reportViewer8.LocalReport.SetParameters(par);
            reportViewer8.LocalReport.DataSources.Add(rds);
            reportViewer8.RefreshReport();

        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            StampajManevristu();
            StampajPregledacKola();
            StampajVozovodja();
            StampajMasinovodjaElektroVuce();
            StampajMasinovodjaNaManevri();
            StampajMasinovodja();
            StampajPomocnikMasinovodje();
            StampajRukovaocManevre();

        }
    }
}
