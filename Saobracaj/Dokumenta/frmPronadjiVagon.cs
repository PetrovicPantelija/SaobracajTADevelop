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
    public partial class frmPronadjiVagon : Form
    {
        public static string code = "frmPronadjiVagon";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        public frmPronadjiVagon()
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
        private void button4_Click(object sender, EventArgs e)
        {
            var select = "  select  *  " +
            "  from TeretnicaStavke t2 " +
            " where t2.BrojKola  = '" + txtSifra.Text  + "'";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            PresloUpotreba();

        }

        private void PresloUpotreba()
        {
            var select = " Select TIV.ID, TIV.RN, TIV.StatusVagona, " +
                " ts.BrojTeretnice, TS.IDNajave, stanice_3.Opis as Otpravna, stanice_2.Opis as Uputna, ts.BrojKola, ts.Serija, ts.BrojOsovina, ts.Duzina, " +
                " ts.Tara, ts.Neto, ts.G, ts.P, ts.R, ts.RR, ts.Reon, ts.VRNP, ts.RID, ts.Primedba, ts.RucKoc " +
                " from TeretnicaIskljuceniVagoni TIV " +
                " inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id " +
                 " inner join stanice AS stanice_3 ON ts.Otpravna = stanice_3.ID INNER JOIN " +
                " stanice AS stanice_2 ON ts.Uputna = stanice_2.ID " +
                " where ts.BrojKola = '" + txtSifra.Text + "' and TIV.StatusVagona in (1,2,3,4)";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "RN";
            dataGridView2.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Status Vagona";
            dataGridView2.Columns[2].Width = 20;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Prijemna teretnica";
            dataGridView2.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Najava";
            dataGridView2.Columns[4].Width = 40;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Otpravna";
            dataGridView2.Columns[5].Width = 120;

            DataGridViewColumn column7 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "Uputna";
            dataGridView2.Columns[6].Width = 120;

            DataGridViewColumn column8 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "Broj kola";
            dataGridView2.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "Serija";
            dataGridView2.Columns[8].Width = 40;

            DataGridViewColumn column10 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "Broj osovina";
            dataGridView2.Columns[9].Width = 40;

            DataGridViewColumn column11 = dataGridView2.Columns[10];
            dataGridView2.Columns[10].HeaderText = "Dužina";
            dataGridView2.Columns[10].Width = 60;

            DataGridViewColumn column12 = dataGridView2.Columns[11];
            dataGridView2.Columns[11].HeaderText = "Tara";
            dataGridView2.Columns[11].Width = 60;

            DataGridViewColumn column13 = dataGridView2.Columns[12];
            dataGridView2.Columns[12].HeaderText = "Neto";
            dataGridView2.Columns[12].Width = 60;

            DataGridViewColumn column14 = dataGridView2.Columns[13];
            dataGridView2.Columns[13].HeaderText = "G";
            dataGridView2.Columns[13].Width = 30;

            DataGridViewColumn column15 = dataGridView2.Columns[14];
            dataGridView2.Columns[14].HeaderText = "P";
            dataGridView2.Columns[14].Width = 30;

            DataGridViewColumn column16 = dataGridView2.Columns[15];
            dataGridView2.Columns[15].HeaderText = "R";
            dataGridView2.Columns[15].Width = 30;

            DataGridViewColumn column17 = dataGridView2.Columns[16];
            dataGridView2.Columns[16].HeaderText = "RR";
            dataGridView2.Columns[16].Width = 30;

            DataGridViewColumn column18 = dataGridView2.Columns[17];
            dataGridView2.Columns[17].HeaderText = "Reon";
            dataGridView2.Columns[17].Width = 60;

            DataGridViewColumn column19 = dataGridView2.Columns[18];
            dataGridView2.Columns[18].HeaderText = "VRNR";
            dataGridView2.Columns[18].Width = 60;

            DataGridViewColumn column20 = dataGridView2.Columns[19];
            dataGridView2.Columns[19].HeaderText = "RID";
            dataGridView2.Columns[19].Width = 60;

            DataGridViewColumn column21 = dataGridView2.Columns[20];
            dataGridView2.Columns[20].HeaderText = "Primedba";
            dataGridView2.Columns[20].Width = 60;

            DataGridViewColumn column22 = dataGridView2.Columns[21];
            dataGridView2.Columns[21].HeaderText = "Ruč koč";
            dataGridView2.Columns[21].Width = 60;
        
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var select = "  select IDNajave, BrojTeretnice from TeretnicaStavke " +
            " inner join Najava on TeretnicaStavke.IDNajave = Najava.ID " +
            " Where Najava.Status = 9 and TeretnicaStavke.BrojKola = '" + txtSifra.Text ; 

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            PresloUpotreba();
        }

        private void frmPronadjiVagon_Load(object sender, EventArgs e)
        {
            var select12 = " Select PaSifra, RTrim(PaNaziv) as Partner From Partnerji where Primalac = 1 order By PaNaziv";
            var s_connection12 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection12 = new SqlConnection(s_connection12);
            var c12 = new SqlConnection(s_connection12);
            var dataAdapter12 = new SqlDataAdapter(select12, c12);

            var commandBuilder12 = new SqlCommandBuilder(dataAdapter12);
            var ds12 = new DataSet();
            dataAdapter12.Fill(ds12);
            cboPlatilac.DataSource = ds12.Tables[0];
            cboPlatilac.DisplayMember = "Partner";
            cboPlatilac.ValueMember = "PaSifra";
        }
    }
}
