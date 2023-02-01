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
using System.Globalization;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms;

namespace Saobracaj.Servis
{
    public partial class frmPregledPopisa1 : Syncfusion.Windows.Forms.Office2010Form
    {
        public frmPregledPopisa1()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "frmPregledPopisa1";
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
        private void PostaviCrvene()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if  (row.Cells[4].Value.ToString() != row.Cells[5].Value.ToString())
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                   // dataGridView1.Refresh();
                }
                
            }

        }

        private void RefreshDataGridZadnjiPopisi()
        {
            var select = "  Select  t1.IDLokomotivaPrijava, t1.Lokomotiva, LokomotivaPrijava.Zaposleni as ZaposleniID, (RTrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme)) as Zaposleni, LokomotivaPopis.Kolicina, " +
            " LokomotiveVrstePopisa.ReferentnaKolicina, LokomotivaPopis.Vreme, " +
            " LokomotivaPopis.Napomena, LokomotiveVrstePopisa.ID as IDVrstePopisa, " +
            " VrstaPopisa.Naziv as VrstaPopisa  from(select MAX(LokomotivaPrijava.ID) as IDLokomotivaPrijava," +
            "  LokomotivaPrijava.Lokomotiva  from LokomotivaPrijava" +
           " where LokomotivaPrijava.Smer = 0 " +
                                        "    group by LokomotivaPrijava.Lokomotiva) t1 " +
                                         "   inner join LokomotivaPrijava on LokomotivaPrijava.ID = t1.IDLokomotivaPrijava " +
           " inner join Delavci on Delavci.DeSifra = LokomotivaPrijava.Zaposleni " +
           " inner join LokomotivaPopis on t1.IDLokomotivaPrijava = LokomotivaPopis.LokomotivaPrijavaID " +
           " inner join LokomotiveVrstePopisa on LokomotiveVrstePopisa.VrstaPopisaID = LokomotivaPopis.VrstaPopisaID " +
           " inner join VrstaPopisa on VrstaPopisa.ID = LokomotiveVrstePopisa.ID ";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID Prijave";
            dataGridView1.Columns[0].Width = 25;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Lokomotiva";
            dataGridView1.Columns[1].Width = 65;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Prijavio ID";
            dataGridView1.Columns[2].Width = 40;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Prijavio";
            dataGridView1.Columns[3].Width = 200;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Količina";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Referetna kol";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Vreme";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Napomena";
            dataGridView1.Columns[7].Width = 150;


            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Vrsta ID";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Vrsta";
            dataGridView1.Columns[9].Width = 270;
            PostaviCrvene();

        }

        private void RefreshDataGrid500PoLokomotivi()
        {
           


            var select = "   Select top 500 t1.IDLokomotivaPrijava, t1.Lokomotiva, LokomotivaPrijava.Zaposleni as ZaposleniID, (RTrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme)) as Zaposleni, LokomotivaPopis.Kolicina, " +
            " LokomotiveVrstePopisa.ReferentnaKolicina, LokomotivaPopis.Vreme, " +
            " LokomotivaPopis.Napomena, LokomotiveVrstePopisa.ID as IDVrstePopisa, " +
            " VrstaPopisa.Naziv as VrstaPopisa  from(select LokomotivaPrijava.ID as IDLokomotivaPrijava," +
            "  LokomotivaPrijava.Lokomotiva  from LokomotivaPrijava" +
           " where LokomotivaPrijava.Smer = 0 and Lokomotiva = '" + cboLokomotiva.SelectedValue + "'" +
                                        "     ) t1 " +
                                         "   inner join LokomotivaPrijava on LokomotivaPrijava.ID = t1.IDLokomotivaPrijava " +
           " inner join Delavci on Delavci.DeSifra = LokomotivaPrijava.Zaposleni " +
           " inner join LokomotivaPopis on t1.IDLokomotivaPrijava = LokomotivaPopis.LokomotivaPrijavaID " +
           " inner join LokomotiveVrstePopisa on LokomotiveVrstePopisa.VrstaPopisaID = LokomotivaPopis.VrstaPopisaID " +
           " inner join VrstaPopisa on VrstaPopisa.ID = LokomotiveVrstePopisa.VrstaPopisaID" +
           " order by  t1.IDLokomotivaPrijava desc";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID Prijave";
            dataGridView1.Columns[0].Width = 25;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Lokomotiva";
            dataGridView1.Columns[1].Width = 65;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Prijavio ID";
            dataGridView1.Columns[2].Width = 40;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Prijavio";
            dataGridView1.Columns[3].Width = 200;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Količina";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Referetna kol";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Vreme";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Napomena";
            dataGridView1.Columns[7].Width = 150;


            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Vrsta ID";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Vrsta";
            dataGridView1.Columns[9].Width = 270;

            PostaviCrvene();

        }

        private void RefreshDataGrid100NeslaganjaPoLokomotivi()
        {
            var select = "  Select top 500 t1.IDLokomotivaPrijava, t1.Lokomotiva, LokomotivaPrijava.Zaposleni as ZaposleniID, (RTrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme)) as Zaposleni, LokomotivaPopis.Kolicina, " +
            " LokomotiveVrstePopisa.ReferentnaKolicina, LokomotivaPopis.Vreme, " +
            " LokomotivaPopis.Napomena, LokomotiveVrstePopisa.ID as IDVrstePopisa, " +
            " VrstaPopisa.Naziv as VrstaPopisa  from(select MAX(LokomotivaPrijava.ID) as IDLokomotivaPrijava," +
            "  LokomotivaPrijava.Lokomotiva  from LokomotivaPrijava" +
           " where LokomotivaPrijava.Smer = 0 " +
                                        "    group by LokomotivaPrijava.Lokomotiva) t1 " +
                                         "   inner join LokomotivaPrijava on LokomotivaPrijava.ID = t1.IDLokomotivaPrijava " +
           " inner join Delavci on Delavci.DeSifra = LokomotivaPrijava.Zaposleni " +
           " inner join LokomotivaPopis on t1.IDLokomotivaPrijava = LokomotivaPopis.LokomotivaPrijavaID " +
           " inner join LokomotiveVrstePopisa on LokomotiveVrstePopisa.VrstaPopisaID = LokomotivaPopis.VrstaPopisaID " +
           " inner join VrstaPopisa on VrstaPopisa.ID = LokomotiveVrstePopisa.VrstaPopisaID " +
                        " where LokomotivaPopis.Kolicina <> LokomotiveVrstePopisa.ReferentnaKolicina";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID Prijave";
            dataGridView1.Columns[0].Width = 25;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Lokomotiva";
            dataGridView1.Columns[1].Width = 65;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Prijavio ID";
            dataGridView1.Columns[2].Width = 40;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Prijavio";
            dataGridView1.Columns[3].Width = 200;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Količina";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Referetna kol";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Vreme";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Napomena";
            dataGridView1.Columns[7].Width = 150;


            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Vrsta ID";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Vrsta";
            dataGridView1.Columns[9].Width = 270;

            PostaviCrvene();
        }

        private void frmPregledPopisa1_Load(object sender, EventArgs e)
        {
            var select4 = " select SmSifra, (SmSifra + SmNaziv) as Naziv from Mesta where Lokomotiva = 1";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboLokomotiva.DataSource = ds4.Tables[0];
            cboLokomotiva.DisplayMember = "Naziv";
            cboLokomotiva.ValueMember = "SmSifra";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGridZadnjiPopisi();
            PostaviCrvene();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid500PoLokomotivi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshDataGrid100NeslaganjaPoLokomotivi();
        }
    }
}
