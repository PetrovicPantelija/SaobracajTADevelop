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

using MetroFramework.Forms;

namespace Saobracaj.Servis
{
    public partial class frmPrijavaKvara : Syncfusion.Windows.Forms.Office2010Form
    {
        bool status = false;
        public static string code = "frmPrijavaKvara";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";

        public frmPrijavaKvara()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
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
        private void frmPrijavaKvara_Load(object sender, EventArgs e)
        {
            var select3 = " select ID, naziv from StatusKvara";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboStatusKvara.DataSource = ds3.Tables[0];
            cboStatusKvara.DisplayMember = "Naziv";
            cboStatusKvara.ValueMember = "ID";


            var select4 = " select SmSifra, SmNaziv from Mesta where Lokomotiva = 1";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboLokomotiva.DataSource = ds4.Tables[0];
            cboLokomotiva.DisplayMember = "SmNaziv";
            cboLokomotiva.ValueMember = "SmSifra";

            var select5 = " Select DeSifra, Rtrim(DeIme) + ' ' + Rtrim(DePriimek) as Zaposleni From Delavci Order By DeIme";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboPrijavio.DataSource = ds5.Tables[0];
            cboPrijavio.DisplayMember = "Zaposleni";
            cboPrijavio.ValueMember = "DeSifra";


            var select6 = " Select DeSifra, Rtrim(DeIme) + ' ' + Rtrim(DePriimek) as Zaposleni From Delavci Order By DeIme";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboPromenio.DataSource = ds6.Tables[0];
            cboPromenio.DisplayMember = "Zaposleni";
            cboPromenio.ValueMember = "DeSifra";

            var select = " select Kvarovi.Id as ID, GrupaKvarova.Naziv, Kvarovi.Naziv as Kvar from Kvarovi " +
 " inner join GrupaKvarova on Kvarovi.GrupaKvarovaID = GrupaKvarova.ID " +
 " order by GrupaKvarova.Naziv";
           
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            cboKvar.DataSource = view;
            cboKvar.DisplayMember = "Kvar";
            cboKvar.ValueMember = "ID";

            // cboPromenio

            //  cboKvar


            /*
            var select6 = " Select ID, Naziv from GrupaKvarova";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboGrupaKvara.DataSource = ds6.Tables[0];
            cboGrupaKvara.DisplayMember = "Naziv";
            cboGrupaKvara.ValueMember = "ID";
            */
            RefreshDataGrid();

        }


        private void VratiPodatke()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID],Rtrim([Lokomotiva]) as Lokomotiva,[Prijavio],[DatumPrijave],[Kvar],[StatusKvara],[Promenio],[DatumPromene],[Napomena]  FROM [TESTIRANJE].[dbo].[EvidencijaKvarova] where ID = " + Convert.ToInt32(txtSifra.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cboLokomotiva.SelectedValue = dr["Lokomotiva"].ToString();
                cboPrijavio.SelectedValue = Convert.ToInt32(dr["Prijavio"].ToString());
                dtpDatumPrijave.Value = Convert.ToDateTime(dr["DatumPrijave"].ToString());
                cboKvar.SelectedValue = Convert.ToInt32(dr["Kvar"].ToString());
                cboStatusKvara.SelectedValue = Convert.ToInt32(dr["StatusKvara"].ToString());
                cboPromenio.SelectedValue = Convert.ToInt32(dr["Promenio"].ToString());
                dtpDatumPromene.Value = Convert.ToDateTime(dr["DatumPromene"].ToString());
                txtNapomena.Text = dr["Napomena"].ToString();
            }

            con.Close();


        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            status = true;
        }


        private void RefreshDataGrid()
        {
            var select = "  select EvidencijaKvarova.ID, Lokomotiva, Prijavio, DatumPrijave, (Rtrim(Delavci.DeIme) + ' ' + Rtrim(Delavci.DePriimek)) as Prijavio " +
            " , Kvarovi.Naziv, StatusKvara, Promenio, DatumPromene, Napomena from EvidencijaKvarova " +
            "  inner join Delavci on Delavci.DeSifra = EvidencijaKvarova.Prijavio " +
            " inner join Kvarovi on Kvarovi.ID = EvidencijaKvarova.Kvar order by EvidencijaKvarova.ID";


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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 25;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Lokomotiva";
            dataGridView1.Columns[1].Width = 65;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Prijavio";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Datum prijave";
            dataGridView1.Columns[3].Width = 60;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Zaposleni prijavio";
            dataGridView1.Columns[4].Width = 170;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Kvar naziv";
            dataGridView1.Columns[5].Width = 130;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Status kvara";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Promenio";
            dataGridView1.Columns[7].Width = 50;


            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Datum promene";
            dataGridView1.Columns[8].Width = 70;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Napomena";
            dataGridView1.Columns[9].Width = 70;


        }
        
        
        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertPrijavaKvara ins = new InsertPrijavaKvara();
            if (status == true)
            {
                ins.InsPrijavaKvarovi(cboLokomotiva.SelectedValue.ToString(), Convert.ToInt32(cboPrijavio.SelectedValue), Convert.ToDateTime(dtpDatumPrijave.Value), Convert.ToInt32(cboKvar.SelectedValue), Convert.ToInt32(cboStatusKvara.SelectedValue), Convert.ToInt32(cboPromenio.SelectedValue), txtNapomena.Text);
                RefreshDataGrid();
            }
            else
            {
                ins.UpdPrijavaKvarovi(Convert.ToInt32(txtSifra.Text), cboLokomotiva.SelectedValue.ToString(), Convert.ToInt32(cboPrijavio.SelectedValue), Convert.ToDateTime(dtpDatumPrijave.Value), Convert.ToInt32(cboKvar.SelectedValue), Convert.ToInt32(cboStatusKvara.SelectedValue), Convert.ToInt32(cboPromenio.SelectedValue), txtNapomena.Text);
                RefreshDataGrid();
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertPrijavaKvara ins = new InsertPrijavaKvara();
            ins.DeletePrijavaKvarovi(Convert.ToInt32(txtSifra.Text));
            RefreshDataGrid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        VratiPodatke();
                        
                        // VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }
    }
}
