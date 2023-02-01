using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Administracija
{
    public partial class frmPolozenePruge : Form
    {
        string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        bool status = false;
        public frmPolozenePruge()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "frmPolozenePruge";
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
        private void frmPolozenePruge_Load(object sender, EventArgs e)
        {
            FillCombo();
            FillGV();
        }
        private void FillCombo()
        {
            var select = "Select DeSifra, Rtrim(DeIme) + ' ' + Rtrim(DePriimek) as Zaposleni From Delavci Order By DeIme";
            var conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            combo_Zaposleni.DataSource = ds.Tables[0];
            combo_Zaposleni.DisplayMember = "Zaposleni";
            combo_Zaposleni.ValueMember = "DeSifra";

            var query = "Select ID,Oznaka,Opis From Pruga";
            var da = new SqlDataAdapter(query, conn);
            var ds2 = new DataSet();
            da.Fill(ds2);
            combo_Pruga.DataSource = ds2.Tables[0];
            combo_Pruga.DisplayMember = "Opis";
            combo_Pruga.ValueMember = "ID";
        }
        private void FillGV()
        {
            var select = "select PolozenePruge.ID,PolozenePruge.DeSifra as SifraZaposlenog, Rtrim(Delavci.DeIme) + ' ' + Rtrim(Delavci.DePriimek) as Zaposleni," +
                "IDPruga,Pruga.Oznaka,Pruga.Opis,Pruga.Elektrificirana,DatumPolozen " +
                "from PolozenePruge " +
                "Inner join Delavci on Delavci.DeSifra=PolozenePruge.DeSifra " +
                "inner join Pruga on Pruga.ID=PolozenePruge.IDPruga";
            var conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(select, conn);
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

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Zaposleni_ID";
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].HeaderText = "Pruga_ID";
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 55;
            dataGridView1.Columns[5].Width = 220;
            dataGridView1.Columns[6].Width = 80;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txt_Sifra.Text = row.Cells[0].Value.ToString();
                        combo_Zaposleni.Text = row.Cells[2].Value.ToString();
                        combo_Pruga.Text = row.Cells[5].Value.ToString();
                    }
                }
            }
            catch
            {
            }
        }

        private void btn_zapolseni_Click(object sender, EventArgs e)
        {
            var select = "select PolozenePruge.ID,PolozenePruge.DeSifra as SifraZaposlenog, Rtrim(Delavci.DeIme) + ' ' + Rtrim(Delavci.DePriimek) as Zaposleni," +
                "IDPruga,Pruga.Oznaka,Pruga.Opis,Pruga.Elektrificirana,DatumPolozen " +
                "from PolozenePruge " +
                "Inner join Delavci on Delavci.DeSifra=PolozenePruge.DeSifra " +
                "inner join Pruga on Pruga.ID=PolozenePruge.IDPruga " +
                "where Rtrim(Delavci.DeIme) + ' ' + Rtrim(Delavci.DePriimek)='"+combo_Zaposleni.Text+"'";
            var conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(select, conn);
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

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Zaposleni_ID";
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].HeaderText = "Pruga_ID";
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 55;
            dataGridView1.Columns[5].Width = 220;
            dataGridView1.Columns[6].Width = 80;
        }

        private void btn_pruga_Click(object sender, EventArgs e)
        {
            var select = "select PolozenePruge.ID,PolozenePruge.DeSifra as SifraZaposlenog, Rtrim(Delavci.DeIme) + ' ' + Rtrim(Delavci.DePriimek) as Zaposleni," +
                "IDPruga,Pruga.Oznaka,Pruga.Opis,Pruga.Elektrificirana,DatumPolozen " +
                "from PolozenePruge " +
                "Inner join Delavci on Delavci.DeSifra=PolozenePruge.DeSifra " +
                "inner join Pruga on Pruga.ID=PolozenePruge.IDPruga " +
                "where Pruga.Opis='" + combo_Pruga.Text + "'";
            var conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(select, conn);
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

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Zaposleni_ID";
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].HeaderText = "Pruga_ID";
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 55;
            dataGridView1.Columns[5].Width = 220;
            dataGridView1.Columns[6].Width = 80;
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txt_Sifra.Text = "";
            status = true;
            tsNew.Checked = true;
            tsNew.Enabled = false;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertPolozenePruge pruge = new InsertPolozenePruge();
            if (status == true)
            {
                pruge.InsPolozenePruge(Convert.ToInt32(combo_Zaposleni.SelectedValue), Convert.ToInt32(combo_Pruga.SelectedValue), Convert.ToDateTime(dateTimePicker1.Value));
                FillGV();
                status = false;
                tsNew.Checked = false;
                tsNew.Enabled = true;
            }
            else
            {
                pruge.UpdPolozenePruge(Convert.ToInt32(txt_Sifra.Text), Convert.ToInt32(combo_Zaposleni.SelectedValue), Convert.ToInt32(combo_Pruga.SelectedValue), Convert.ToDateTime(dateTimePicker1.Value));
                FillGV();
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertPolozenePruge pruge = new InsertPolozenePruge();
            pruge.DelPolozenePruge(Convert.ToInt32(txt_Sifra.Text));
            FillGV();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmPolozeneLokomotive lokomotive = new frmPolozeneLokomotive();
            lokomotive.Show();
        }
    }
}
