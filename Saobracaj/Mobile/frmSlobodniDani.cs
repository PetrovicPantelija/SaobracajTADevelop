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
using MetroFramework.Forms;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace Saobracaj.Mobile
{
    
    public partial class frmSlobodniDani :  Syncfusion.Windows.Forms.Office2010Form
    {
       
        public frmSlobodniDani()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        string niz = "";
        public static string code = "frmSlobodniDani";
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
        public frmSlobodniDani(string Korisnik)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
            string KorisnikL = Korisnik;
            IdGrupe();
            IdForme();
            PravoPristupa();

        }
        private void RefreshDataGrid()
        {
            var select = " Select EvidencijaZahteva.ID, Zaposleni, (Rtrim(Delavci.DeIme) + ' ' + Rtrim(Delavci.DePriimek)) as Radnik, " +
            " EvidencujaZahtevaVrsta.Naziv as Tip, DatumOd, DatumDo, Status, Napomena, " +
            " Odobrio as OdobrioSifra, (Rtrim(o.DeIme) + ' ' + Rtrim(o.DePriimek)) as Odobrio, DatumZahteva " +
            " from EvidencijaZahteva " +
            " inner join EvidencujaZahtevaVrsta on EvidencujaZahtevaVrsta.ID = EvidencijaZahteva.VrstaZahtevaID " +
            " inner " +
            " join Delavci on Delavci.DeSifra = Zaposleni " +
            " left " +
            " join Delavci o on o.DeSifra = Odobrio order by EvidencijaZahteva.ID desc";
          
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

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Radnik Zahtevao";
            dataGridView1.Columns[2].Width = 250;
           

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Tip";
            dataGridView1.Columns[3].Width = 90;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme Od";
            dataGridView1.Columns[4].Width = 90;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme Do";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Status";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Napomena";
            dataGridView1.Columns[7].Width = 250;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Odobrio";
            dataGridView1.Columns[8].Width = 250;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Vreme zahteva";
            dataGridView1.Columns[9].Width = 100;


        }

        private void frmSlobodniDani_Load(object sender, EventArgs e)
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
                        txtID.Text = row.Cells[0].Value.ToString();
                        txtNapomena.Text = row.Cells[7].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            InsertSlobodniDani ins = new InsertSlobodniDani();
            ins.UpdSlobodniDani(Convert.ToInt32(txtID.Text), txtNapomena.Text, Convert.ToInt32(cboZaposleni.SelectedValue), 2);

            DialogResult dialogResult = MessageBox.Show("Potrebno je da evidentirate GO i izdate rеšenje?", "Unos godisnjeg odmora", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int ZaposleniID = 1;
                DateTime DatumOd = DateTime.Now;
                DateTime DatumDo = DateTime.Now;
                int Odobrio = 0;
                string Napomena = "";
                DateTime DatumZahteva = DateTime.Now;
                int SlobodanDan = 1;
                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (row.Selected)
                    {
                        ZaposleniID = Convert.ToInt32(row.Cells[1].Value.ToString());
                        DatumOd = Convert.ToDateTime(row.Cells[4].Value.ToString());
                        DatumDo = Convert.ToDateTime(row.Cells[5].Value.ToString());
                        Odobrio = Convert.ToInt32(row.Cells[8].Value.ToString());
                        Napomena = row.Cells[7].Value.ToString();
                        DatumZahteva = Convert.ToDateTime(row.Cells[10].Value.ToString());
                        SlobodanDan = 1;
                        Dokumenta.frmEvidencijaGodišnjihOdmora fego = new Dokumenta.frmEvidencijaGodišnjihOdmora(ZaposleniID, DatumOd, DatumDo, Odobrio, Napomena, 1, DatumZahteva);
                        fego.Show();
                    }
                }


               
            }
           
            
        
        
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            InsertSlobodniDani ins = new InsertSlobodniDani();
            ins.UpdSlobodniDani(Convert.ToInt32(txtID.Text), txtNapomena.Text, Convert.ToInt32(cboZaposleni.SelectedValue), 1);
        }
    }
}
