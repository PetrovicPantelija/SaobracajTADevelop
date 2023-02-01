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
using MetroFramework.Forms;

namespace Saobracaj.Dokumenta
{
    public partial class frmRegistator : Syncfusion.Windows.Forms.Office2010Form
    {
        bool status = false;
        public frmRegistator()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            IdGrupe();
            IdForme();
            PravoPristupa();
            InitializeComponent();
            VratiPodatke();
        }
        public static string code = "frmRegistator";
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
                        tsNew.Enabled = false;
                    }
                    update = Convert.ToBoolean(reader["Izmena"]);
                    if (update == false)
                    {
                        tsSave.Enabled = false;
                    }
                    delete = Convert.ToBoolean(reader["Brisanje"]);
                    if (delete == false)
                    {
                        tsDelete.Enabled = false;
                    }
                }
            }

            conn.Close();
        }
        public frmRegistator(int Zapis)
        {
            InitializeComponent();
            VratiPodatke(Zapis);
        }
        private void VratiPodatke()
        {
            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboZaposleni.DataSource = ds3.Tables[0];
            cboZaposleni.DisplayMember = "Opis";
            cboZaposleni.ValueMember = "ID";


            var select4 = " select PaSifra as ID, PaNaziv as Opis from Partnerji";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPartner.DataSource = ds4.Tables[0];
            cboPartner.DisplayMember = "Opis";
            cboPartner.ValueMember = "ID";



        }

        private void VratiPodatke(int ID)
        {
            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboZaposleni.DataSource = ds3.Tables[0];
            cboZaposleni.DisplayMember = "Opis";
            cboZaposleni.ValueMember = "ID";


            var select4 = " select PaSifra as ID, PaNaziv as Opis from Partnerji";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPartner.DataSource = ds4.Tables[0];
            cboPartner.DisplayMember = "Opis";
            cboPartner.ValueMember = "ID";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[Partner],[Zaposleni],[Predmet],[Datum] ,[Tekst]  FROM Registrator where ID = " + ID, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
                txtPredmet.Text = dr["Predmet"].ToString();
                txtTekst.Text = dr["Tekst"].ToString();
                cboPartner.SelectedValue = Convert.ToInt32(dr["Partner"].ToString());
                cboZaposleni.SelectedValue = Convert.ToInt32(dr["Zaposleni"].ToString());
                dtpDatum.Value = Convert.ToDateTime(dr["Datum"].ToString());
            }

            con.Close();

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            txtPredmet.Text = "";
            txtTekst.Text = "";
            status = true;
            // txtOpis.Text = "";
        }



        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRegistrator ins = new InsertRegistrator();
                ins.InsRegistrator(Convert.ToInt32(cboPartner.SelectedValue), Convert.ToInt32(cboZaposleni.SelectedValue), txtPredmet.Text, Convert.ToDateTime(dtpDatum.Value), txtTekst.Text);
                txtSifra.Text = Convert.ToString(VratiMaxPodatke());
                status = false;
            }
            else
            {
                InsertRegistrator ins = new InsertRegistrator();
                ins.UpdRegistrator(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboPartner.SelectedValue), Convert.ToInt32(cboZaposleni.SelectedValue), txtPredmet.Text, Convert.ToDateTime(dtpDatum.Value), txtTekst.Text);
                status = false;
                txtSifra.Enabled = false;
            }
        }


        private int VratiMaxPodatke()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand(" Select Max(ID) as ID from Registrator ", con);


            SqlDataReader dr = cmd.ExecuteReader();
            int SledeciBroj = 0;
            while (dr.Read())
            {
                SledeciBroj = Convert.ToInt32(dr["ID"].ToString());

            }
            con.Close();
            return SledeciBroj;
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertRegistrator ins = new InsertRegistrator();
            ins.DelRegistrator(Convert.ToInt32(txtSifra.Text));
            status = false;
            txtSifra.Enabled = false;
        }

        private void frmRegistator_Load(object sender, EventArgs e)
        {



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TESTIRANJEDataSet12TableAdapters.SelectRegistratorTableAdapter ta = new TESTIRANJEDataSet12TableAdapters.SelectRegistratorTableAdapter();

            TESTIRANJEDataSet12.SelectRegistratorDataTable dt = new TESTIRANJEDataSet12.SelectRegistratorDataTable();


            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptRegistrator.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmRegistratorDokumenta regdok = new frmRegistratorDokumenta(txtSifra.Text);
            regdok.Show();
        }
    }
}
