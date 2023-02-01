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

namespace Saobracaj.Sifarnici
{
    public partial class frmOsoblje : Form
    {
        public static string code = "frmOsoblje";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";

        public frmOsoblje()
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
                       // tsNew.Enabled = false;
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
        private void cboPartneri_Leave(object sender, EventArgs e)
        {
           



            /*
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand command = new SqlCommand(" Select PaSifra, Rtrim(PaNaziv) as PaNaziv, Rtrim(UIC) as UIC, (CASE WHEN Prevoznik > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  as Prevoznik, (CASE WHEN Posiljalac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  as Posiljalac, (CASE WHEN Primalac > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END)  as Primalac from Partnerji where PaNaziv=@NAZIV", conn);
            //
            // Add new SqlParameter to the command.
            //
            command.Parameters.AddWithValue("@NAZIV", cboPartneri.Text);
            int result = (Int32)(command.ExecuteScalar());
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                //txtSifra.Text = dr[0].ToString();
                // read data for first record here
            } 
           */
        }

        private void frmOsoblje_Load(object sender, EventArgs e)
        {

            RefreshDataGrid();

            var select2 = " Select SmSifra, SmSifra as Opis from Mesta where Lokomotiva=1";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboLokomotiva.DataSource = ds2.Tables[0];
            cboLokomotiva.DisplayMember = "Opis";
            cboLokomotiva.ValueMember = "SmSifra";

            var select3 = " select ID, (Rtrim(Oznaka) + '-' + Rtrim(opis)) as Opis from Pruga";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboPruga.DataSource = ds3.Tables[0];
            cboPruga.DisplayMember = "Opis";
            cboPruga.ValueMember = "ID";

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Dokumenta.InsertOsobljeLok iol = new Dokumenta.InsertOsobljeLok();
            iol.InsOsobLok(Convert.ToInt32(cboPartneri.SelectedValue), cboLokomotiva.SelectedValue.ToString());
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int PomManevrista, PomPomocnik, PomVozovodja, PomPregledacKola, PomMasinovodja; 
            
            if (chkManevrista.Checked)
            {
                PomManevrista = 1;
            }
            else
            {
                PomManevrista = 0;
            }

            if (chkPomocnik.Checked)
            {
                PomPomocnik = 1;
            }
            else
            {
                PomPomocnik = 0;
            }

            if (chkVozovodja.Checked)
            {
                PomVozovodja = 1;
            }
            else
            {
                PomVozovodja = 0;
            }

            if (chkPregledacKola.Checked)
            {
                PomPregledacKola = 1;
            }
            else
            {
                PomPregledacKola = 0;
            }

            if (chkMasinovodja.Checked)
            {
                PomMasinovodja = 1;
            }
            else
            {
                PomMasinovodja = 0;
            }

            Dokumenta.InsertOsobljeLok iol = new Dokumenta.InsertOsobljeLok();
            iol.UpdDelavci(Convert.ToInt32(cboPartneri.SelectedValue), PomManevrista, PomPomocnik, PomVozovodja, PomPregledacKola, PomMasinovodja);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Dokumenta.InsertOsobljeLok iol = new Dokumenta.InsertOsobljeLok();
            iol.InsOsobPruga(Convert.ToInt32(cboPartneri.SelectedValue), Convert.ToInt32(cboPruga.SelectedValue));
        }

        private void RefreshDataGrid()
        {
            var select = " SELECT     Delavci.DeSifra, RTRIM(Delavci.DePriimek) + ' ' + RTRIM(Delavci.DeIme) AS Naziv, Delavci.DeTelefon1, Delavci.DeTelefon2, Delavci.DeEMail, " +
                    "   CASE WHEN Delavci.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , " +
                     "   CASE WHEN Delavci.Pregledac  > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pomocnik , " +
                       "   CASE WHEN Delavci.Vozovodja   > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Vozovodja  , " +
                        "   CASE WHEN Delavci.PregledacKola   > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PregledacKola  , " +
                        "   CASE WHEN Delavci.Manevrista   > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Manevrista  , " +
                   "   DelovnaMesta.DmNaziv, Delavci.DeUlHisStBivS, Delavci.DeKrajBivS " +
                   " FROM         Delavci INNER JOIN " +
                   "  DelovnaMesta ON Delavci.DeSifDelMes = DelovnaMesta.DmSifra where DeSifStat <> 'P'";



            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboPartneri.DataSource = ds.Tables[0];
            cboPartneri.DisplayMember = "Naziv";
            cboPartneri.ValueMember = "DeSifra";

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
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Naziv";
            dataGridView1.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Telefon - 1";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Telefon - 2";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "E-mail";
            dataGridView1.Columns[4].Width = 150;



            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Masinovodja";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Pomocnik";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Vozovođa";
            dataGridView1.Columns[7].Width = 50;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Preg kola";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Manevrista";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Radno mesto";
            dataGridView1.Columns[10].Width = 100;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Ulica";
            dataGridView1.Columns[11].Width = 100;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Mesto";
            dataGridView1.Columns[12].Width = 100;

        
        }

        private void cboPartneri_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                RefreshDataGrid2();
                RefreshDataGrid3();

            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void RefreshDataGrid2()
        {
            var select = " select * from DelavciLokMasin where DeSifra = " + Convert.ToInt32(cboPartneri.SelectedValue);

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
        }

        private void RefreshDataGrid3()
        {
            var select = " select * from DelavciPrugaMasin inner join Pruga on DelavciPrugaMasin.Pruga = Pruga.ID " +
            " where DeSifra = " + Convert.ToInt32(cboPartneri.SelectedValue);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView3.BackgroundColor = Color.White;

            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
