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

namespace Saobracaj.Dokumenta
{
    public partial class frmKontrola : Syncfusion.Windows.Forms.Office2010Form
    {
        bool status = false;
        string niz = "";
        int usao = 0;
        public static string code = "frmKontrola";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();

        string KorisnikP = "";
        public frmKontrola()
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
        private void frmKontrola_Load(object sender, EventArgs e)
        {
           
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            status = true;
        }

        private void RefreshDataGrid()
        {

            var select = "  Select KontrolaDokumentacije.ID, NajavaID, Delavci.DeSifra as RadnikID," +
                " (Rtrim(Delavci.DeIme) + ' ' + Rtrim(Delavci.DePriimek)) as Radnik, DatumPrijemaKoverte, " +
             "  Uradio, DatumCekiranja, Uradio2, DatumCekiranja2, Napomena from KontrolaDokumentacije " +
             " inner join Delavci on Delavci.DeSifra = KontrolaDokumentacije.RadnikID";


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
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Najava ID";
            dataGridView1.Columns[1].Width = 70;


            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Radnik ID";
            dataGridView1.Columns[2].Width = 70;


            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Ime i prezime";
            dataGridView1.Columns[3].Width = 170;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "ATA";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Uradio";
            dataGridView1.Columns[5].Width = 50;


            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Datum prijema kovertr";
            dataGridView1.Columns[6].Width = 70;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Uradio 2";
            dataGridView1.Columns[7].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Datum izvršenog pregleda";
            dataGridView1.Columns[8].Width = 70;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Napomena";
            dataGridView1.Columns[9].Width = 270;

        }


        private void RefreshDataGridGreske()
        {

            var select = "  select KontrolaDokumentacijeGreske.ID, " +
            " NAdredjeniID, KontrolaDokumentacijeGreske.RadnikID, (Rtrim(DeIme) + ' ' + RTrim(DePriimek)) as Zaposleni," +
            " KontrolaDokumentacijeGreske.GreskaID,KontrolneGreske.Naziv, KontrolaDokumentacijeGreske.Napomena from KontrolaDokumentacijeGreske " +
            " inner join Delavci on Delavci.DeSifra = KontrolaDokumentacijeGreske.RadnikID " +
            " inner join KontrolneGreske on KontrolneGreske.ID = KontrolaDokumentacijeGreske.GreskaID" +
            " where NadredjeniID =" + Convert.ToInt32(txtSifra.Text);


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

            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[0].Width = 40;

            DataGridViewColumn column1 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Nadredjeni ID";
            dataGridView3.Columns[1].Width = 50;


            DataGridViewColumn column2 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Radnik ID";
            dataGridView3.Columns[2].Width = 50;


            DataGridViewColumn column3 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Ime i prezime";
            dataGridView3.Columns[3].Width = 170;


            DataGridViewColumn column4 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Greska ID";
            dataGridView3.Columns[4].Width = 50;


            DataGridViewColumn column5 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Naziv";
            dataGridView3.Columns[5].Width = 90;

            DataGridViewColumn column6 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Napomena";
            dataGridView3.Columns[6].Width = 150;
        }


        private void tsSave_Click(object sender, EventArgs e)
        {
            int pomUradio = 0;
            int pomUradio2 = 0; 
            
            if (chkUradio.Checked == true)
            {
                pomUradio = 1;
            }
            else
            {
                pomUradio = 0;
            }

            if (chkuradio2.Checked == true)
            {
                pomUradio2 = 1;
            }
            else
            {
                pomUradio2 = 0;
            }


            if (status == true)
            {
                InsertKontrola ins = new InsertKontrola();
                ins.InsKontrola(Convert.ToInt32(cboNajavaID.SelectedValue), Convert.ToInt32(cboRadnikID.SelectedValue) ,Convert.ToDateTime(dtpDatumPrijemaKoverte.Value),pomUradio, Convert.ToDateTime(dtpDatumCekiranja.Value), pomUradio2, Convert.ToDateTime(dtpDatumCekiranja2.Value), txtNapomenaZaglavlje.Text);
                VratiSifru();
                RefreshDataGrid();
                status = false;
            }
            else
            {
                InsertKontrola upd = new InsertKontrola();
                upd.UpdKontrola(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboNajavaID.SelectedValue), Convert.ToInt32(cboRadnikID.SelectedValue), Convert.ToDateTime(dtpDatumPrijemaKoverte.Value), pomUradio, Convert.ToDateTime(dtpDatumCekiranja.Value), pomUradio2, Convert.ToDateTime(dtpDatumCekiranja2.Value), txtNapomenaZaglavlje.Text);
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid();
            }
        }

        private void VratiSifru()
        {
          
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(s_connection);

                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT Max(ID) as ID  FROM [TESTIRANJE].[dbo].[KontrolaDokumentacije]", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtSifra.Text = dr["ID"].ToString();
                }

                con.Close();
            }


       

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertKontrola del = new InsertKontrola();
            del.DeleteKontrola(Convert.ToInt32(txtSifra.Text));
            status = false;
            txtSifra.Enabled = false;
            RefreshDataGrid();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        cboNajavaID.SelectedValue = Convert.ToInt32(row.Cells[1].Value.ToString());
                        cboRadnikID.SelectedValue = Convert.ToInt32(row.Cells[2].Value.ToString());
                        dtpDatumPrijemaKoverte.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
                       if (row.Cells[5].Value.ToString() == "1")
                        { chkUradio.Checked = true; }
                       else
                        { chkUradio.Checked = false; }

                        dtpDatumCekiranja.Value = Convert.ToDateTime(row.Cells[6].Value.ToString());
                        if (row.Cells[7].Value.ToString() == "1")
                        { chkuradio2.Checked = true; }
                        else
                        { chkuradio2.Checked = false; }
                        dtpDatumCekiranja2.Value = Convert.ToDateTime(row.Cells[8].Value.ToString());
                        txtNapomenaZaglavlje.Text = row.Cells[9].Value.ToString();
                        RefreshDataGridGreske();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela promena stavki");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sifarnici.InsertKontrolneGreske ins = new Sifarnici.InsertKontrolneGreske();
            ins.InsKontrolaDokumentacijeGreske(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboGreskaRadnik.SelectedValue), Convert.ToInt32(cboGreska.SelectedValue), txtNapomenaStavka.Text);
            RefreshDataGridGreske();
            status = false;
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            Sifarnici.InsertKontrolneGreske ins = new Sifarnici.InsertKontrolneGreske();
            ins.UpdKontrolaDokumentacijeGreske(Convert.ToInt32(txtSifraGreske.Text), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboGreskaRadnik.SelectedValue), Convert.ToInt32(cboGreska.SelectedValue), txtNapomenaStavka.Text); ;
            RefreshDataGridGreske();
            status = false;
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            Sifarnici.InsertKontrolneGreske ins = new Sifarnici.InsertKontrolneGreske();
            ins.DeleteKontrolaDokumentacijeGreske(Convert.ToInt32(txtSifraGreske.Text)); ;
            RefreshDataGridGreske();
            status = false;
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                       txtSifraGreske.Text = row.Cells[0].Value.ToString();
                       txtNapomenaStavka.Text = row.Cells[6].Value.ToString();
                       cboGreska.SelectedValue = Convert.ToInt32(row.Cells[4].Value.ToString());
                       cboRadnikID.SelectedValue = Convert.ToInt32(row.Cells[2].Value.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela promena stavki");
            }
        }

        private void cboTipDokumenta_SelectedValueChanged(object sender, EventArgs e)
        {

            if (usao == 1)
            { 
            var select2 = " select ID, Naziv from KontrolneGreske where TipDokumenta = " + Convert.ToInt32(cboTipDokumenta.SelectedValue) + " order by Naziv";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboGreska.DataSource = ds2.Tables[0];
            cboGreska.DisplayMember = "Naziv";
            cboGreska.ValueMember = "ID";

            }
        }

        private void cboNajavaID_Leave(object sender, EventArgs e)
        {
            bool temp = false;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select StvarnoPrimanje from Najava where ID=" + Convert.ToInt32(cboNajavaID.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dtpDatumPrijemaKoverte.Value = Convert.ToDateTime(dr["StvarnoPrimanje"].ToString());  
            }

           
            con.Close();
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
           if (txtKontrola1.Text == "kontrola1")
            { 
            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci order by opis";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboRadnikID.DataSource = ds3.Tables[0];
            cboRadnikID.DisplayMember = "Opis";
            cboRadnikID.ValueMember = "ID";


            var select = " Select ID, PrevozniPut, StvarnoPrimanje as ATA,Tezina, Duzina, BrojKola, StvarnoPrimanje, StvarnaPredaja, Status from Najava where ID > 210001 order by ID desc";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            cboNajavaID.DataSource = view;
            cboNajavaID.DisplayMember = "ID";
            cboNajavaID.ValueMember = "ID";


            var select4 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci order by opis";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboGreskaRadnik.DataSource = ds4.Tables[0];
            cboGreskaRadnik.DisplayMember = "Opis";
            cboGreskaRadnik.ValueMember = "ID";


            var select2 = " select ID, Naziv from KontrolneGreske order by Naziv";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboGreska.DataSource = ds2.Tables[0];
            cboGreska.DisplayMember = "Naziv";
            cboGreska.ValueMember = "ID";


            var select5 = " select ID, Naziv from KontrolneGreskeTipDokumenta order by Naziv";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboTipDokumenta.DataSource = ds5.Tables[0];
            cboTipDokumenta.DisplayMember = "Naziv";
            cboTipDokumenta.ValueMember = "ID";

            RefreshDataGrid();
            usao = 1;
            }
        }
    }
}
