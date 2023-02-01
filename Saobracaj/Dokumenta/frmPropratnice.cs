using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Dokumenta
{
    public partial class frmPropratnice : Form
    {
        public static string code = "frmPropratnice";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        bool status = false;
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
        public frmPropratnice()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();

            txt_ID.ReadOnly = true;
            //txt_putanjaZ.Visible = false;
            //txt_putanjaR.Visible = false;
        }
        private void frmPropratnice_Load(object sender, EventArgs e)
        {
            GVPropratince();
            GVRazduzivanje();
            GVZaduzivanje();
        }
        private void GVPropratince()
        {
            var select = "select * from Propratnica order by ID desc";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);
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
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[0].Width = 50;
            dataGridView3.Columns[1].HeaderText = "ID Najave";
            dataGridView3.Columns[1].Width = 50;
            dataGridView3.Columns[2].HeaderText = "Napomena";
            dataGridView3.Columns[2].Width = 250;
        }
        private void GVZaduzivanje()
        {
            var select = "select p.Id,p.IdNajave,p.Napomena as NapomenaNajava,z.IdPropratnica,z.ZaposleniId,RTrim(k.Korisnik) as Zaposleni,z.Napomena as NapomenaZaduzenje," +
                "z.VremeZaduzenja,s.Slika,s.Ime " +
                "From Propratnica p,PropratnicaZaduzenje z,PropratniceZaduzivanjeSlike s,Korisnici k " +
                "Where p.IDNajave=z.IdNajave and z.IdPropratnica=s.PropratnicaZaduzivanjeId and z.ZaposleniId=k.DeSifra order by p.ID desc";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[8].Width = 90;
        }
        public void filterZaduzivanje(int najava)
        {
            var select = "select p.Id,p.IdNajave,p.Napomena as NapomenaNajava,z.IdPropratnica,z.ZaposleniId,RTrim(k.Korisnik) as Zaposleni,z.Napomena as NapomenaZaduzenje," +
                "z.VremeZaduzenja,s.Slika,s.Ime " +
                "From Propratnica p,PropratnicaZaduzenje z,PropratniceZaduzivanjeSlike s,Korisnici k" +
                " Where p.IDNajave=z.IdNajave and p.IDNajave="+najava+"and z.IdPropratnica=s.PropratnicaZaduzivanjeId and z.ZaposleniId=k.DeSifra order by p.ID desc";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[8].Width = 90;
        }

        private void GVRazduzivanje()
        {
            var select = "select p.Id,p.IdNajave,p.Napomena as NapomenaNajava,z.IdPropratnica,z.ZaposleniId,RTrim(k.Korisnik) as Zaposleni,z.Napomena as NapomenaRazduzenje," +
     "z.VremeRazduzenja,s.Slika,s.Ime " +
     "From Propratnica p,PropratnicaRazduzenje z,PropratniceRazduzivanjeSlike s,Korisnici k " +
     "Where p.IDNajave=z.IdNajave and z.IdPropratnica=s.PropratnicaRazduzivanjeId and z.ZaposleniId=k.DeSifra order by p.ID desc";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

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
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 40;
            dataGridView2.Columns[1].Width = 50;
            dataGridView2.Columns[3].Width = 50;
            dataGridView2.Columns[4].Width = 50;
            dataGridView2.Columns[5].Width = 60;
            dataGridView2.Columns[8].Width = 90;
        }
        private void filterRazduzivanje(int najava)
        {
            var select = "select p.Id,p.IdNajave,p.Napomena as NapomenaNajava,z.IdPropratnica,z.ZaposleniId,RTrim(k.Korisnik) as Zaposleni,z.Napomena as NapomenaRazduzenje," +
                 "z.VremeRazduzenja,s.Slika,s.Ime " +
                 "From Propratnica p,PropratnicaRazduzenje z,PropratniceRazduzivanjeSlike s,Korisnici k" +
                 " Where p.IDNajave=z.IdNajave and p.IDNajave=" + najava + "and z.IdPropratnica=s.PropratnicaRazduzivanjeId and z.ZaposleniId=k.DeSifra order by p.ID desc";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

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
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 40;
            dataGridView2.Columns[1].Width = 50;
            dataGridView2.Columns[3].Width = 50;
            dataGridView2.Columns[4].Width = 50;
            dataGridView2.Columns[5].Width = 60;
            dataGridView2.Columns[8].Width = 90;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GVPropratince();
            GVRazduzivanje();
            GVZaduzivanje();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        txt_ID.Text = row.Cells[0].Value.ToString();
                        txt_IdNajave.Text = row.Cells[1].Value.ToString();
                        txt_Napomena.Text = row.Cells[2].Value.ToString();
                        filterZaduzivanje(Convert.ToInt32(txt_IdNajave.Text));
                        filterRazduzivanje(Convert.ToInt32(txt_IdNajave.Text));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }
        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertPropratnica ins = new InsertPropratnica();
                ins.InsPropratnica(Convert.ToInt32(txt_IdNajave.Text.ToString().TrimEnd()), txt_Napomena.Text.ToString().TrimEnd());
                status = false;
                GVPropratince();
            }
            else
            {
                InsertPropratnica upd = new InsertPropratnica();
                upd.UpdPropratnica(Convert.ToInt32(txt_ID.Text.ToString().TrimEnd()), Convert.ToInt32(txt_IdNajave.Text.ToString().TrimEnd()), txt_Napomena.Text.ToString().TrimEnd());
                GVPropratince();
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertPropratnica del = new InsertPropratnica();
            del.DeletePropratnica(Convert.ToInt32(txt_ID.Text.ToString().TrimEnd()));
            status = false;
            GVPropratince();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    TextBox pom = new TextBox();
                    pom.Text = row.Cells[3].Value.ToString().TrimEnd();

                    string query = "Select Slika from PropratniceZaduzivanjeSlike Where PropratnicaZaduzivanjeId=" + Convert.ToInt32(pom.Text);
                    var connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connect);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txt_putanjaZ.Text = dr["Slika"].ToString();
                    }
                    conn.Close();
                }
            }
        }
        private void btn_prikaziZ_Click(object sender, EventArgs e)
        {
            if (txt_putanjaZ.Text.Equals(""))
            {
                MessageBox.Show("Mora se selektovati propratnica");
            }
            else
            {
                System.Diagnostics.Process.Start(txt_putanjaZ.Text);
            }
        }


        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Selected)
                {
                    TextBox pom = new TextBox();
                    pom.Text = row.Cells[3].Value.ToString().TrimEnd();
                    string query = "Select Slika from PropratniceRazduzivanjeSlike Where PropratnicaRazduzivanjeId=" + Convert.ToInt32(pom.Text);
                    var connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connect);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txt_putanjaR.Text = dr["Slika"].ToString().TrimEnd();
                    }
                    conn.Close();
                }
            }
        }

        private void btn_prikaziR_Click(object sender, EventArgs e)
        {
            if (txt_putanjaR.Text.Equals(""))
            {
                MessageBox.Show("Mora se selektovati propratnica");
            }
            else
            {
                System.Diagnostics.Process.Start(txt_putanjaR.Text);
            }
        }
    }

}
