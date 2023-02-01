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
    public partial class frmFinansije : Form
    {
        public frmFinansije()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        string niz = "";
        public static string code = "frmFinansije";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
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
        private void btnStampa_Click(object sender, EventArgs e)
        {
            if (txtSifra.Text == "DejanIvan")
            {
            TESTIRANJEDataSet6TableAdapters.SelectAktivnostiFinasijeTableAdapter ta = new TESTIRANJEDataSet6TableAdapters.SelectAktivnostiFinasijeTableAdapter();
            TESTIRANJEDataSet6.SelectAktivnostiFinasijeDataTable dt = new TESTIRANJEDataSet6.SelectAktivnostiFinasijeDataTable();

            ta.Fill(dt, Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeDo.Value));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet10";
            rds.Value = dt;
            DateTime dtStartDate = dtpVremeOd.Value;
            DateTime dtEndDate = dtpVremeDo.Value;

            ReportParameter[] par = new ReportParameter[2];
          
            par[0] = new ReportParameter("DatumOd", dtStartDate.ToLongDateString(), false);
            par[1] = new ReportParameter("DatumDo", dtEndDate.ToLongDateString(), false);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "Troskovi.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();

            RefreshDataGrid1();
        }
        }
        private void RefreshDataGrid1()
        {

            var select = "";

            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Pregledao ,Aktivnosti.Oznaka,  (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,     CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,   CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica,  CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Mesto, CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni, CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano,  CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa  from Aktivnosti   inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni    where Aktivnosti.Placeno = 0 and (Aktivnosti.PlacenoRacun = 1) and (UkupniTroskovi + RAcun) > 0 " +
            " And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' order by Aktivnosti.ID desc";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Pregledao";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Oznaka";
            dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme od";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme do";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupno";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Ukupni troškovi";
            dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridView1.Columns[7].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Opis";
            dataGridView1.Columns[8].Width = 120;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "RN";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Poslat Email";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Plaćeno";
            dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Računi";
            dataGridView1.Columns[12].DefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView1.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Kartice";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Masinovodja";
            dataGridView1.Columns[14].Width = 50;

            DataGridViewColumn column15 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Mesto";
            dataGridView1.Columns[15].Width = 100;

            DataGridViewColumn column16 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Pregledano računi";
            dataGridView1.Columns[16].Width = 50;

            DataGridViewColumn column17 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Pregledano kartice";
            dataGridView1.Columns[17].Width = 50;

            DataGridViewColumn column18 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Milšped";
            dataGridView1.Columns[18].Width = 50;

            DataGridViewColumn column19 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Zapisa";
            dataGridView1.Columns[19].Width = 50;
        
        
      
        
        
        }

        private void RefreshDataGrid1Zaposleni()
        {

            var select = "";

            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Pregledao, Aktivnosti.Oznaka,  (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,     CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,   CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica,  CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Mesto, CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni, CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano,  CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa  from Aktivnosti   inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni    where Aktivnosti.Placeno = 0 and (Aktivnosti.PlacenoRacun = 1) and (UkupniTroskovi + RAcun) > 0 " +
            " And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' and Aktivnosti.Zaposleni = " + cboZaposleni.SelectedValue + " order by Aktivnosti.ID desc";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Pregledao";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Oznaka";
            dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme od";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme do";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupno";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Ukupni troškovi";
            dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridView1.Columns[7].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Opis";
            dataGridView1.Columns[8].Width = 120;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "RN";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Poslat Email";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Plaćeno";
            dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Računi";
            dataGridView1.Columns[12].DefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView1.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Kartice";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Masinovodja";
            dataGridView1.Columns[14].Width = 50;

            DataGridViewColumn column15 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Mesto";
            dataGridView1.Columns[15].Width = 100;

            DataGridViewColumn column16 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Pregledano računi";
            dataGridView1.Columns[16].Width = 50;

            DataGridViewColumn column17 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Pregledano kartice";
            dataGridView1.Columns[17].Width = 50;

            DataGridViewColumn column18 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Milšped";
            dataGridView1.Columns[18].Width = 50;

            DataGridViewColumn column19 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Zapisa";
            dataGridView1.Columns[19].Width = 50;





        }

        private void RefreshDataGrid2()
        {

            var select = "";

            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.VremePlaceno,  (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,     CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,   CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica,  CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Mesto, CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni, CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano,  CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa  from Aktivnosti   inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni    where Aktivnosti.Placeno = 1 and (Aktivnosti.PlacenoRacun = 1) and (UkupniTroskovi + RAcun) > 0 " +
            " And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' order by Aktivnosti.ID desc";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Vreme placeno";
            dataGridView2.Columns[1].Width = 130;

            DataGridViewColumn column2 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Zaposleni";
            dataGridView2.Columns[2].Width = 100;

            DataGridViewColumn column3 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Vreme od";
            dataGridView2.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Vreme do";
            dataGridView2.Columns[4].Width = 100;

            DataGridViewColumn column5 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Ukupno";
            dataGridView2.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "Ukupni troškovi";
            dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridView2.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "Opis";
            dataGridView2.Columns[7].Width = 120;

            DataGridViewColumn column8 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "RN";
            dataGridView2.Columns[8].Width = 50;

            DataGridViewColumn column9 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "Poslat Email";
            dataGridView2.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView2.Columns[10];
            dataGridView2.Columns[10].HeaderText = "Plaćeno";
            dataGridView2.Columns[10].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView2.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView2.Columns[11];
            dataGridView2.Columns[11].HeaderText = "Računi";
            dataGridView2.Columns[11].DefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView2.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView2.Columns[12];
            dataGridView2.Columns[12].HeaderText = "Kartice";
            dataGridView2.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView2.Columns[13];
            dataGridView2.Columns[13].HeaderText = "Masinovodja";
            dataGridView2.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView2.Columns[14];
            dataGridView2.Columns[14].HeaderText = "Mesto";
            dataGridView2.Columns[14].Width = 100;

            DataGridViewColumn column15 = dataGridView2.Columns[15];
            dataGridView2.Columns[15].HeaderText = "Pregledano računi";
            dataGridView2.Columns[15].Width = 50;

            DataGridViewColumn column16 = dataGridView2.Columns[16];
            dataGridView2.Columns[16].HeaderText = "Pregledano kartice";
            dataGridView2.Columns[16].Width = 50;

            DataGridViewColumn column17 = dataGridView2.Columns[17];
            dataGridView2.Columns[17].HeaderText = "Milšped";
            dataGridView2.Columns[17].Width = 50;

            DataGridViewColumn column18 = dataGridView2.Columns[18];
            dataGridView2.Columns[18].HeaderText = "Zapisa";
            dataGridView2.Columns[18].Width = 50;

        }

        private void RefreshDataGrid2Zaposleni()
        {

            var select = "";

            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.VremePlaceno,  (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,     CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,   CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica,  CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Mesto, CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni, CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano,  CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa  from Aktivnosti   inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni    where Aktivnosti.Placeno = 1 and (Aktivnosti.PlacenoRacun = 1) and (UkupniTroskovi + RAcun) > 0 " +
            " And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' and Aktivnosti.Zaposleni = " + cboZaposleni.SelectedValue + " order by Aktivnosti.ID desc";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Vreme placeno";
            dataGridView2.Columns[1].Width = 130;

            DataGridViewColumn column2 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Zaposleni";
            dataGridView2.Columns[2].Width = 100;

            DataGridViewColumn column3 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Vreme od";
            dataGridView2.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Vreme do";
            dataGridView2.Columns[4].Width = 100;

            DataGridViewColumn column5 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Ukupno";
            dataGridView2.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "Ukupni troškovi";
            dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridView2.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "Opis";
            dataGridView2.Columns[7].Width = 120;

            DataGridViewColumn column8 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "RN";
            dataGridView2.Columns[8].Width = 50;

            DataGridViewColumn column9 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "Poslat Email";
            dataGridView2.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView2.Columns[10];
            dataGridView2.Columns[10].HeaderText = "Plaćeno";
            dataGridView2.Columns[10].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView2.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView2.Columns[11];
            dataGridView2.Columns[11].HeaderText = "Računi";
            dataGridView2.Columns[11].DefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView2.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView2.Columns[12];
            dataGridView2.Columns[12].HeaderText = "Kartice";
            dataGridView2.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView2.Columns[13];
            dataGridView2.Columns[13].HeaderText = "Masinovodja";
            dataGridView2.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView2.Columns[14];
            dataGridView2.Columns[14].HeaderText = "Mesto";
            dataGridView2.Columns[14].Width = 100;

            DataGridViewColumn column15 = dataGridView2.Columns[15];
            dataGridView2.Columns[15].HeaderText = "Pregledano računi";
            dataGridView2.Columns[15].Width = 50;

            DataGridViewColumn column16 = dataGridView2.Columns[16];
            dataGridView2.Columns[16].HeaderText = "Pregledano kartice";
            dataGridView2.Columns[16].Width = 50;

            DataGridViewColumn column17 = dataGridView2.Columns[17];
            dataGridView2.Columns[17].HeaderText = "Milšped";
            dataGridView2.Columns[17].Width = 50;

            DataGridViewColumn column18 = dataGridView2.Columns[18];
            dataGridView2.Columns[18].HeaderText = "Zapisa";
            dataGridView2.Columns[18].Width = 50;

        }

        private void RefreshDataGrid3()
        {

            var select = "";

            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.VremePlaceno,  (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,     CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,   CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica,  CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Mesto, CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni, CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano,  CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa  from Aktivnosti   inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni    where Aktivnosti.Placeno = 1 and (Aktivnosti.PlacenoRacun = 0) and (UkupniTroskovi + RAcun) > 0 " +
            " And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' order by Aktivnosti.ID desc";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Vreme placeno";
            dataGridView3.Columns[1].Width = 130;

            DataGridViewColumn column2 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Zaposleni";
            dataGridView3.Columns[2].Width = 100;

            DataGridViewColumn column3 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Vreme od";
            dataGridView3.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Vreme do";
            dataGridView3.Columns[4].Width = 100;

            DataGridViewColumn column5 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Ukupno";
            dataGridView3.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Ukupni troškovi";
            dataGridView3.Columns[6].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridView3.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Opis";
            dataGridView3.Columns[7].Width = 120;

            DataGridViewColumn column8 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "RN";
            dataGridView3.Columns[8].Width = 50;

            DataGridViewColumn column9 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "Poslat Email";
            dataGridView3.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Plaćeno";
            dataGridView3.Columns[10].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView3.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Računi";
            dataGridView3.Columns[11].DefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView3.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Kartice";
            dataGridView3.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "Masinovodja";
            dataGridView3.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView3.Columns[14];
            dataGridView3.Columns[14].HeaderText = "Mesto";
            dataGridView3.Columns[14].Width = 100;

            DataGridViewColumn column15 = dataGridView3.Columns[15];
            dataGridView3.Columns[15].HeaderText = "Pregledano računi";
            dataGridView3.Columns[15].Width = 50;

            DataGridViewColumn column16 = dataGridView3.Columns[16];
            dataGridView3.Columns[16].HeaderText = "Pregledano kartice";
            dataGridView3.Columns[16].Width = 50;

            DataGridViewColumn column17 = dataGridView3.Columns[17];
            dataGridView3.Columns[17].HeaderText = "Milšped";
            dataGridView3.Columns[17].Width = 50;

            DataGridViewColumn column18 = dataGridView3.Columns[18];
            dataGridView3.Columns[18].HeaderText = "Zapisa";
            dataGridView3.Columns[18].Width = 50;

        }

        private void RefreshDataGrid3Zaposleni()
        {

            var select = "";

            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.VremePlaceno,  (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,     CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,   CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica,  CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Mesto, CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni, CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano,  CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa  from Aktivnosti   inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni    where Aktivnosti.Placeno = 1 and (Aktivnosti.PlacenoRacun = 0) and (UkupniTroskovi + RAcun) > 0 " +
            " And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' and Aktivnosti.Zaposleni = " + cboZaposleni.SelectedValue + " order by Aktivnosti.ID desc";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Vreme placeno";
            dataGridView3.Columns[1].Width = 130;

            DataGridViewColumn column2 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Zaposleni";
            dataGridView3.Columns[2].Width = 100;

            DataGridViewColumn column3 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Vreme od";
            dataGridView3.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Vreme do";
            dataGridView3.Columns[4].Width = 100;

            DataGridViewColumn column5 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Ukupno";
            dataGridView3.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Ukupni troškovi";
            dataGridView3.Columns[6].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridView3.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Opis";
            dataGridView3.Columns[7].Width = 120;

            DataGridViewColumn column8 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "RN";
            dataGridView3.Columns[8].Width = 50;

            DataGridViewColumn column9 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "Poslat Email";
            dataGridView3.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Plaćeno";
            dataGridView3.Columns[10].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView3.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Računi";
            dataGridView3.Columns[11].DefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView3.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Kartice";
            dataGridView3.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "Masinovodja";
            dataGridView3.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView3.Columns[14];
            dataGridView3.Columns[14].HeaderText = "Mesto";
            dataGridView3.Columns[14].Width = 100;

            DataGridViewColumn column15 = dataGridView3.Columns[15];
            dataGridView3.Columns[15].HeaderText = "Pregledano računi";
            dataGridView3.Columns[15].Width = 50;

            DataGridViewColumn column16 = dataGridView3.Columns[16];
            dataGridView3.Columns[16].HeaderText = "Pregledano kartice";
            dataGridView3.Columns[16].Width = 50;

            DataGridViewColumn column17 = dataGridView3.Columns[17];
            dataGridView3.Columns[17].HeaderText = "Milšped";
            dataGridView3.Columns[17].Width = 50;

            DataGridViewColumn column18 = dataGridView3.Columns[18];
            dataGridView3.Columns[18].HeaderText = "Zapisa";
            dataGridView3.Columns[18].Width = 50;

        }

        private void frmFinansije_Load(object sender, EventArgs e)
        {
            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci  order by opis";
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
           // this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSifra.Text == "DejanIvan")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected == true)
                    {
                        InsertAktivnosti ins = new InsertAktivnosti();
                        ins.UpdateAktivnostiPlaceno(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToDateTime(dtpVremePlaceno.Value));

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshDataGrid3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshDataGrid2Zaposleni();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1Zaposleni();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RefreshDataGrid3Zaposleni();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                        frmEvidencijaRada er = new frmEvidencijaRada(Convert.ToInt32(row.Cells[0].Value.ToString()), "");
                        er.Show();
                }
            }
        }
    }
}
