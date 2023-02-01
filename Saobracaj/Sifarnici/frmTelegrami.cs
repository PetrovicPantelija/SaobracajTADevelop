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
using System.IO;

namespace Saobracaj.Sifarnici
{
    public partial class frmTelegrami : Form
    {
        public static string code = "frmTelegrami";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        Label stanica, Sod,Sdo;

        OpenFileDialog ofd1 = new OpenFileDialog();
        FolderBrowserDialog fbd1 = new FolderBrowserDialog();

        bool status = false;
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public frmTelegrami()
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
        private void frmTelegrami_Load(object sender, EventArgs e)
        {

            FillCombo();

            dt_VaziDo.Value = DateTime.Now;
            dt_VaziOd.Value = DateTime.Now;
            RefreshDG();

        }
        private void FillCombo()
        {
            var query = " Select ID, (RTrim(Oznaka) + '-' + Rtrim(Opis)) as Opis From Pruga";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboPruga.DataSource = ds.Tables[0];
            cboPruga.DisplayMember = "Opis";
            cboPruga.ValueMember = "ID";

            var odStanice = "Select ID,Opis From Stanice";
            SqlDataAdapter da2 = new SqlDataAdapter(odStanice, conn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            combo_OdStanice.DataSource = ds2.Tables[0];
            combo_OdStanice.DisplayMember = "Opis";
            combo_OdStanice.ValueMember = "ID";

            var DoStanice = "Select ID,Opis From Stanice";
            SqlDataAdapter da3 = new SqlDataAdapter(DoStanice, conn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            combo_DoStanice.DataSource = ds3.Tables[0];
            combo_DoStanice.DisplayMember = "Opis";
            combo_DoStanice.ValueMember = "ID";
        }
        private void RefreshDG()
        {
            var query = "Select Telegrami.ID,BrojTelegrama,PrugaID,Rtrim(Pruga.Opis) as [Naziv], " +
                "OdStanice,Rtrim(Stanice.Opis) as [Stanica OD],DoStanice,RTrim(s.Opis) as [Stanica DO],RTrim(Kolosek) as Kolosek, " +
                "VaziOD,VaziDo,Aktivan,Napomena,PDF,NarocitaPosiljka " +
                "From Telegrami " +
                "Inner Join Pruga on Telegrami.PrugaID = Pruga.ID " +
                "Inner join Stanice on Telegrami.OdStanice = Stanice.ID " +
                "Inner join Stanice as s on Telegrami.DoStanice = s.ID " +
                "order by Telegrami.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
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
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Broj Telegrama";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Naziv";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Stanica OD";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Stanica DO";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].HeaderText = "Vazi OD";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "Vazi DO";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "Aktivan";
            dataGridView1.Columns[12].Width = 250;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].HeaderText = "Narocita posiljka";

        }
        private void tsNew_Click(object sender, EventArgs e)
        {
            txt_ID.Text = "";
            txt_ID.Enabled = false;
            status = true;
        }
        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertTelegrami insert = new InsertTelegrami();
            bool narocita = false;

            bool aktivan;
            if (cb_Aktivni.Checked == true)
            {
                aktivan = true;
            }
            else { aktivan = false; }
            if (cb_Narocita.Checked==true)
            {
                narocita = true;
            }
            else { narocita = false; }

            if (status == true)
            {
                insert.InsTelegrami(Convert.ToInt32(txt_BrTelegrama.Text), Convert.ToInt32(cboPruga.SelectedValue), Convert.ToInt32(combo_OdStanice.SelectedValue),
                    Convert.ToInt32(combo_DoStanice.SelectedValue), txt_kolosek.Text,Convert.ToDateTime(dt_VaziOd.Value),Convert.ToDateTime(dt_VaziDo.Value), dt_TrajeOd.Value, dt_TrajeDo.Value, txt_Napomena.Text, aktivan, txt_PDF.Text.ToString(),narocita);
                RefreshDG();
                txt_ID.Enabled = true;
                status = false;
            }
            else
            {
                insert.UpdTelegrami(Convert.ToInt32(txt_ID.Text), Convert.ToInt32(txt_BrTelegrama.Text), Convert.ToInt32(cboPruga.SelectedValue), Convert.ToInt32(combo_OdStanice.SelectedValue),
                    Convert.ToInt32(combo_DoStanice.SelectedValue), txt_kolosek.Text, Convert.ToDateTime(dt_VaziOd.Value), Convert.ToDateTime(dt_VaziDo.Value), dt_TrajeOd.Value, dt_TrajeDo.Value, txt_Napomena.Text, aktivan, txt_PDF.Text.ToString(),narocita);
                RefreshDG();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var query = "Select Telegrami.ID,BrojTelegrama,PrugaID,Rtrim(Pruga.Opis) as [Naziv], " +
                "OdStanice,Rtrim(Stanice.Opis) as [Stanica OD],DoStanice,RTrim(s.Opis) as [Stanica DO],RTrim(Kolosek) as Kolosek, " +
                "VaziOD,VaziDo,Aktivan,Napomena,PDF,NarocitaPosiljka " +
                "From Telegrami " +
                "Inner Join Pruga on Telegrami.PrugaID = Pruga.ID " +
                "Inner join Stanice on Telegrami.OdStanice = Stanice.ID " +
                "Inner join Stanice as s on Telegrami.DoStanice = s.ID " +
                "Where Telegrami.Aktivan = 1 " +
                "order by Telegrami.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Broj Telegrama";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Naziv";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Stanica OD";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Stanica DO";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].HeaderText = "Vazi OD";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "Vazi DO";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "Aktivan";
            dataGridView1.Columns[12].Width = 250;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].HeaderText = "Narocita posiljka";
        }

        private void btn_svi_Click(object sender, EventArgs e)
        {
            var query = "Select Telegrami.ID,BrojTelegrama,PrugaID,Rtrim(Pruga.Opis) as [Naziv], " +
                "OdStanice,Rtrim(Stanice.Opis) as [Stanica OD],DoStanice,RTrim(s.Opis) as [Stanica DO],RTrim(Kolosek) as Kolosek, " +
                "VaziOD,VaziDo,Aktivan,Napomena,PDF,NarocitaPosiljka " +
                "From Telegrami " +
                "Inner Join Pruga on Telegrami.PrugaID = Pruga.ID " +
                "Inner join Stanice on Telegrami.OdStanice = Stanice.ID " +
                "Inner join Stanice as s on Telegrami.DoStanice = s.ID " +
     "order by Telegrami.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Broj Telegrama";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Naziv";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Stanica OD";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Stanica DO";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].HeaderText = "Vazi OD";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "Vazi DO";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "Aktivan";
            dataGridView1.Columns[12].Width = 250;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].HeaderText = "Narocita posiljka";

            timer2.Enabled = true;
            timer1.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer2.Start();
        }

        private void btn_Aktivni_Click(object sender, EventArgs e)
        {
            var query = "Select Telegrami.ID,BrojTelegrama,PrugaID,Rtrim(Pruga.Opis) as [Naziv], " +
                "OdStanice,Rtrim(Stanice.Opis) as [Stanica OD],DoStanice,RTrim(s.Opis) as [Stanica DO],RTrim(Kolosek) as Kolosek, " +
                "VaziOD,VaziDo,Aktivan,Napomena,PDF,NarocitaPosiljka " +
                "From Telegrami " +
                "Inner Join Pruga on Telegrami.PrugaID = Pruga.ID " +
                "Inner join Stanice on Telegrami.OdStanice = Stanice.ID " +
                "Inner join Stanice as s on Telegrami.DoStanice = s.ID " +
                "Where Telegrami.Aktivan = 1 " +
                "order by Telegrami.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Broj Telegrama";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Naziv";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Stanica OD";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Stanica DO";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].HeaderText = "Vazi OD";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "Vazi DO";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "Aktivan";
            dataGridView1.Columns[12].Width = 250;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].HeaderText = "Narocita posiljka";

            timer1.Enabled = true;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var query = "Select Telegrami.ID,BrojTelegrama,PrugaID,Rtrim(Pruga.Opis) as [Naziv], " +
                "OdStanice,Rtrim(Stanice.Opis) as [Stanica OD],DoStanice,RTrim(s.Opis) as [Stanica DO],RTrim(Kolosek) as Kolosek, " +
                "VaziOD,VaziDo,Aktivan,Napomena,PDF,NarocitaPosiljka " +
                "From Telegrami " +
                "Inner Join Pruga on Telegrami.PrugaID = Pruga.ID " +
                "Inner join Stanice on Telegrami.OdStanice = Stanice.ID " +
                "Inner join Stanice as s on Telegrami.DoStanice = s.ID " +
     "order by Telegrami.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Broj Telegrama";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Naziv";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Stanica OD";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Stanica DO";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].HeaderText = "Vazi OD";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "Vazi DO";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "Aktivan";
            dataGridView1.Columns[12].Width = 250;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].HeaderText = "Narocita posiljka";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txt_ID.Text = row.Cells[0].Value.ToString();
                        txt_BrTelegrama.Text = row.Cells[1].Value.ToString();
                        cboPruga.SelectedValue = row.Cells[2].Value.ToString();
                        cboPruga.Text = row.Cells[3].Value.ToString();
                        combo_OdStanice.SelectedValue = row.Cells[4].Value;
                        combo_OdStanice.Text = row.Cells[5].Value.ToString();
                        combo_DoStanice.SelectedValue = row.Cells[6].Value;
                        combo_DoStanice.Text = row.Cells[7].Value.ToString();
                        txt_kolosek.Text = row.Cells[8].Value.ToString();
                        dt_VaziOd.Value = Convert.ToDateTime(row.Cells[9].Value.ToString());
                        dt_VaziDo.Value = Convert.ToDateTime(row.Cells[10].Value.ToString());
                        bool aktivan, narocita;
                        aktivan = Convert.ToBoolean(row.Cells[11].Value);
                        if (aktivan == true) { cb_Aktivni.Checked = true; } else { cb_Aktivni.Checked = false; }
                        txt_Napomena.Text = row.Cells[12].Value.ToString();
                        txt_PDF.Text = row.Cells[13].Value.ToString();
                        narocita = Convert.ToBoolean(row.Cells[14].Value.ToString());
                        if (narocita == true) { cb_Narocita.Checked = true; } else { cb_Narocita.Checked = false; }
                    }
                }
            }
            catch
            {

            }

        }

        private void btn_dani_Click(object sender, EventArgs e)
        {
            var query = "Select Telegrami.ID,BrojTelegrama,PrugaID,Rtrim(Pruga.Opis) as [Naziv], " +
                "OdStanice,Rtrim(Stanice.Opis) as [Stanica OD],DoStanice,RTrim(s.Opis) as [Stanica DO],RTrim(Kolosek) as Kolosek, " +
                "VaziOD,VaziDo,Aktivan,Napomena,PDF,NarocitaPosiljka " +
                "From Telegrami " +
                "Inner Join Pruga on Telegrami.PrugaID = Pruga.ID " +
                "Inner join Stanice on Telegrami.OdStanice = Stanice.ID " +
                "Inner join Stanice as s on Telegrami.DoStanice = s.ID " +
                "Where(VaziDo Between Convert(Date, Getdate()) and Convert(Date, GetDate() + 7)) and aktivan=1" +
                "order by Telegrami.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Broj Telegrama";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Naziv";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Stanica OD";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Stanica DO";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].HeaderText = "Vazi OD";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "Vazi DO";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "Aktivan";
            dataGridView1.Columns[12].Width = 250;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].HeaderText = "Narocita posiljka";

            timer3.Enabled = true;
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer4.Enabled = false;
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            var query = "Select Telegrami.ID,BrojTelegrama,PrugaID,Rtrim(Pruga.Opis) as [Naziv], " +
                "OdStanice,Rtrim(Stanice.Opis) as [Stanica OD],DoStanice,RTrim(s.Opis) as [Stanica DO],RTrim(Kolosek) as Kolosek, " +
                "VaziOD,VaziDo,Aktivan,Napomena,PDF,NarocitaPosiljka " +
                "From Telegrami " +
                "Inner Join Pruga on Telegrami.PrugaID = Pruga.ID " +
                "Inner join Stanice on Telegrami.OdStanice = Stanice.ID " +
                "Inner join Stanice as s on Telegrami.DoStanice = s.ID " +
                "Where(VaziDo Between Convert(Date, Getdate()) and Convert(Date, GetDate() + 7)) and aktivan=1" +
                "order by Telegrami.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Broj Telegrama";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Naziv";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Stanica OD";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Stanica DO";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].HeaderText = "Vazi OD";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "Vazi DO";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "Aktivan";
            dataGridView1.Columns[12].Width = 250;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].HeaderText = "Narocita posiljka";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmTelegramiPrikazi tel = new frmTelegramiPrikazi();
            tel.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertTelegrami telegrami = new InsertTelegrami();
            telegrami.DeleteTelegrami(Convert.ToInt32(txt_ID.Text));
            RefreshDG();
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            string folder = txt_PDF.Text;
            ofd1.InitialDirectory = folder;
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txt_PDF.Text = fbd1.SelectedPath.ToString() + ofd1.FileName;
            }

        }
        private void KopirajFajlPoTipu(string putanja, string FolderDestinacije,int ID)
        {
            string fileName = ofd1.FileName; //Ovde ce trebati promena
            fileName = fileName.Replace(" ", "_");
            string sourcePath = fbd1.SelectedPath.ToString();
            string result = Path.GetFileName(fileName);
            string targetPath = "";

            targetPath = @"\\192.168.1.6\Telegrami\" + FolderDestinacije + ID;

            string sourceFile = putanja;
            string destFile = System.IO.Path.Combine(targetPath, result);

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            var remote = Path.Combine(targetPath, result);
            File.Copy(sourceFile, remote);
            txt_PDF.Text = targetPath;

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
        }

        private void btn_prikazi_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_PDF.Text);
        }

        private void btn_Sacuvaj_Click(object sender, EventArgs e)
        {
            int ID=0;
            int id;
            if (txt_ID.Text == "")
            {
                string query = "Select top 1 ID from Telegrami order by id desc";
                SqlConnection conn = new SqlConnection(connect);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ID = Convert.ToInt32(reader["ID"].ToString());
                }
                id = ID + 1;
                conn.Close();
            }
            else
            {
                id = Convert.ToInt32(txt_ID.Text);
            }
            KopirajFajlPoTipu(txt_PDF.Text, txt_ID.Text,id);
        }

        private void btn_narocite_Click(object sender, EventArgs e)
        {
            var query = "Select Telegrami.ID,BrojTelegrama,PrugaID,Rtrim(Pruga.Opis) as [Naziv], " +
                "OdStanice,Rtrim(Stanice.Opis) as [Stanica OD],DoStanice,RTrim(s.Opis) as [Stanica DO],RTrim(Kolosek) as Kolosek, " +
                "VaziOD,VaziDo,Aktivan,Napomena,PDF,NarocitaPosiljka " +
                "From Telegrami " +
                "Inner Join Pruga on Telegrami.PrugaID = Pruga.ID " +
                "Inner join Stanice on Telegrami.OdStanice = Stanice.ID " +
                "Inner join Stanice as s on Telegrami.DoStanice = s.ID " +
               "Where NarocitaPosiljka=1 " +
               "order by Telegrami.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Broj Telegrama";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Naziv";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Stanica OD";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Stanica DO";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].HeaderText = "Vazi OD";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "Vazi DO";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "Aktivan";
            dataGridView1.Columns[12].Width = 250;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].HeaderText = "Narocita posiljka";

            timer4.Enabled = true;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer1.Enabled = false;
            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            var query = "Select Telegrami.ID,BrojTelegrama,PrugaID,Rtrim(Pruga.Opis) as [Naziv], " +
                "OdStanice,Rtrim(Stanice.Opis) as [Stanica OD],DoStanice,RTrim(s.Opis) as [Stanica DO],RTrim(Kolosek) as Kolosek, " +
                "VaziOD,VaziDo,Aktivan,Napomena,PDF,NarocitaPosiljka " +
                "From Telegrami " +
                "Inner Join Pruga on Telegrami.PrugaID = Pruga.ID " +
                "Inner join Stanice on Telegrami.OdStanice = Stanice.ID " +
                "Inner join Stanice as s on Telegrami.DoStanice = s.ID " +
    "Where narocitaPosiljka=1" +
    "order by Telegrami.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Broj Telegrama";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Naziv";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Stanica OD";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Stanica DO";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].HeaderText = "Vazi OD";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "Vazi DO";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "Aktivan";
            dataGridView1.Columns[12].Width = 250;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].HeaderText = "Narocita posiljka";
        }
    }
}
