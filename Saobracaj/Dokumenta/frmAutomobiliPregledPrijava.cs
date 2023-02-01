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
using System.IO;

namespace Saobracaj.Dokumenta
{
    public partial class frmAutomobiliPregledPrijava : Form
    {
        private List<PictureBox> PictureBoxes = new List<PictureBox>();
        List<string> filenames = new List<string>();
        List<string> videos = new List<string>();
        private const int ThumbWidth = 458;
        private const int ThumbHeight = 288;
        int slika = 0;

        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        bool status = false;
        public frmAutomobiliPregledPrijava()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        string niz = "";
        public static string code = "frmAutomobiliPregledPrijava";
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
        private void frmAutomobiliPregledPrijava_Load(object sender, EventArgs e)
        {
            FillGV();
            FillData();
        }
        private void FillData()
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter();

            var query = "Select DeSifra, Rtrim(DeIme) + ' ' +Rtrim(DePriimek)as Zaposleni From Delavci Order By DeIme";
            da = new SqlDataAdapter(query, conn);
            var ds = new DataSet();
            da.Fill(ds);
            combo_Zaposleni.DataSource = ds.Tables[0];
            combo_Zaposleni.DisplayMember = "Zaposleni";
            combo_Zaposleni.ValueMember = "DeSifra";

            var query1 = "Select ID,RegBr,Marka From Automobili";
            da = new SqlDataAdapter(query1, conn);
            var ds1 = new DataSet();
            da.Fill(ds1);
            combo_Automobil.DataSource = ds1.Tables[0];
            combo_Automobil.DisplayMember = "RegBr";
            combo_Automobil.ValueMember = "ID";

            var query2 = "Select Id,CistocaVrsta From CistocaSpolja";
            da = new SqlDataAdapter(query2, conn);
            var ds2 = new DataSet();
            da.Fill(ds2);
            combo_CistocaSpoljaZad.DataSource = ds2.Tables[0];
            combo_CistocaSpoljaZad.DisplayMember = "CistocaVrsta";
            combo_CistocaSpoljaZad.ValueMember = "Id";

            var query3 = "Select Id, CistocaVrsta From CistocaIznutra";
            da = new SqlDataAdapter(query3, conn);
            var ds3 = new DataSet();
            da.Fill(ds3);
            combo_CistocaUnutraZad.DataSource = ds3.Tables[0];
            combo_CistocaUnutraZad.DisplayMember = "CistocaVrsta";
            combo_CistocaUnutraZad.ValueMember = "Id";

            var query4 = "Select Id, UljeStatus From UljeAuto";
            da = new SqlDataAdapter(query4, conn);
            var ds4 = new DataSet();
            da.Fill(ds4);
            combo_NivoUljaZad.DataSource = ds4.Tables[0];
            combo_NivoUljaZad.DisplayMember = "UljeStatus";
            combo_NivoUljaZad.ValueMember = "Id";

            var query5 = "Select Id,CistocaVrsta From CistocaSpoljaRazduzivanje";
            da = new SqlDataAdapter(query5, conn);
            var ds5 = new DataSet();
            da.Fill(ds5);
            combo_CistocaSpoljaRaz.DataSource = ds5.Tables[0];
            combo_CistocaSpoljaRaz.DisplayMember = "CistocaVrsta";
            combo_CistocaSpoljaRaz.ValueMember = "Id";

            var query6 = "Select Id, CistocaVrsta From CistocaIznutraRazduzivanje";
            da = new SqlDataAdapter(query6, conn);
            var ds6 = new DataSet();
            da.Fill(ds6);
            combo_CistocaUnutraRaz.DataSource = ds6.Tables[0];
            combo_CistocaUnutraRaz.DisplayMember = "CistocaVrsta";
            combo_CistocaUnutraRaz.ValueMember = "Id";

            var query7 = "Select Id,UljeStatus From UljeAutoRazduzivanje";
            da = new SqlDataAdapter(query7, conn);
            var ds7 = new DataSet();
            da.Fill(ds7);
            combo_NivoUljaRaz.DataSource = ds7.Tables[0];
            combo_NivoUljaRaz.DisplayMember = "UljeStatus";
            combo_NivoUljaRaz.ValueMember = "Id";
        }
        private void FillGV()
        {
            var select = "  SELECT     ZaposleniPrijavaAuto.Id, Delavci.DeStaraSif, RTRIM(Delavci.DePriimek) + '  ' + RTRIM(Delavci.DeIme) AS Zaposleni, ZaposleniPrijavaAuto.DatumPrijave, " +
      "    ZaposleniPrijavaAuto.DatumOdjave, ZaposleniPrijavaAuto.AutomobilId, Automobili.RegBr, Automobili.Marka, ZaposleniPrijavaAuto.Relacija, " +
      "    ZaposleniPrijavaAuto.DirektnaPrimopredajaZaduzivanje,ZaposleniPrijavaAuto.DirektnaPrimopredajaRazduzivanje, ZaposleniPrijavaAuto.KilometrazaZaduzivanje, ZaposleniPrijavaAuto.KilometrazaRazduzivanje, " +
      "    ZaposleniPrijavaAuto.Plomba1PotvrdaZaduzenje, ZaposleniPrijavaAuto.Plomba2PotvrdaZaduzenje, ZaposleniPrijavaAuto.Plomba1PotvrdaRazduzenje, " +
      "    ZaposleniPrijavaAuto.Plomba2PotvrdaRazduzenje, " +
      "    CistocaSpolja.CistocaVrsta as CistocaSpolja, CistocaIznutra.CistocaVrsta AS CistocaIznutra, CistocaSpoljaRazduzivanje.CistocaVrsta AS CistocaSpoljaRazduzivanje, " +
      "     CistocaIznutraRazduzivanje.CistocaVrsta AS CistocaUnutraRazduzivanje,  UljeAuto.UljeStatus as UljeZaduzivanje, UljeAutoRazduzivanje.UljeStatus AS UljeRazduzivanje " +
      "    FROM         ZaposleniPrijavaAuto INNER JOIN " +
      "    Delavci ON ZaposleniPrijavaAuto.Zaposleni = Delavci.DeSifra INNER JOIN " +
      "    Automobili ON ZaposleniPrijavaAuto.AutomobilId = Automobili.ID INNER JOIN " +
      "    UljeAuto ON ZaposleniPrijavaAuto.NivoUljaZaduzivanje = UljeAuto.Id LEFT JOIN " +
      "    UljeAutoRazduzivanje ON ZaposleniPrijavaAuto.NivoUljaRazduzivanje = UljeAutoRazduzivanje.Id " +
      "    LEFT JOIN " +
      "    CistocaSpoljaRazduzivanje ON ZaposleniPrijavaAuto.CistocaSpoljaRazduzivanje = CistocaSpoljaRazduzivanje.Id " +
      "    LEFT JOIN CistocaIznutra ON ZaposleniPrijavaAuto.CistocaIznutraZaduzivanje = CistocaIznutra.Id " +
      "    LEFT JOIN " +
      "    CistocaIznutraRazduzivanje ON ZaposleniPrijavaAuto.CistocaIznutraRazduzivanje = CistocaIznutraRazduzivanje.ID LEFT JOIN " +
      "    CistocaSpolja ON ZaposleniPrijavaAuto.CistocaSpoljaZaduzivanje = CistocaSpolja.Id " +
      "    Order by  ZaposleniPrijavaAuto.Id desc ";

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

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[2].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].HeaderText = "DatumPrijave";
            dataGridView1.Columns[6].HeaderText = "Registarski BR";
            dataGridView1.Columns[8].HeaderText = "Relacija";
            dataGridView1.Columns[11].HeaderText = "KilometrazaZaduzivanje";
            dataGridView1.Columns[12].HeaderText = "KilometrazaRazduzivanje";
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertAutomobiliPregledPrijava insert = new InsertAutomobiliPregledPrijava();
            insert.DeleteAutomobiliPregledPrijava(Convert.ToInt32(txt_Sifra.Text));
            FillGV();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txt_Sifra.Text = "";
            txt_Sifra.Enabled = false;
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertAutomobiliPregledPrijava insert = new InsertAutomobiliPregledPrijava();
            bool dirPredZad = false;
            bool dirPredRaz = false;
            bool plomba1Zad = false;
            bool plomba2Zad = false;
            bool plomba1Raz = false;
            bool plomba2Raz = false;
            if (cb_DirPredZad.Checked)
            {
                dirPredZad = true;
            }
            if (cb_DirPredRaz.Checked)
            {
                dirPredRaz = true;
            }
            if (cb_Plomba1Raz.Checked)
            {
                plomba1Raz = true;
            }
            if (cb_Plomba1Zad.Checked)
            {
                plomba1Zad = true;
            }
            if (cb_Plomba2Zad.Checked)
            {
                plomba2Zad = true;
            }
            if (cb_Plomba2Raz.Checked)
            {
                plomba2Raz = true;
            }
            if (txt_KmRazduzenje.Text.Equals(""))
            {
                txt_KmRazduzenje.Text = "0";
            }
            if (txt_KmZaduzenje.Text.Equals(""))
            {
                txt_KmZaduzenje.Text = "0";
            }
            if (status == true)
            {
                insert.InsAutomobiliPregledPrijava(Convert.ToInt32(combo_Zaposleni.SelectedValue.ToString()),
                    Convert.ToDateTime(dtpDatumPrijave.Value),
                    Convert.ToDateTime(dt_Odjava.Value), Convert.ToInt32(combo_Automobil.SelectedValue.ToString()), txt_Relacija.Text,
                    Convert.ToInt32(combo_CistocaSpoljaZad.SelectedValue.ToString()), Convert.ToInt32(combo_CistocaUnutraZad.SelectedValue.ToString()),
                    Convert.ToInt32(combo_CistocaSpoljaRaz.SelectedValue.ToString()), Convert.ToInt32(combo_CistocaUnutraRaz.SelectedValue.ToString()),
                    Convert.ToInt32(combo_NivoUljaZad.SelectedValue.ToString()), dirPredZad, Convert.ToInt32(combo_NivoUljaRaz.SelectedValue.ToString()),
                    dirPredRaz, float.Parse(txt_KmZaduzenje.Text), float.Parse(txt_KmRazduzenje.Text), plomba1Zad, plomba2Zad,
                    plomba1Raz, plomba2Raz);
                FillGV();

                txt_Sifra.Enabled = true;
                status = false;
            }
            else
            {
                insert.UpdAutomobiliPregledPrijava(Convert.ToInt32(txt_Sifra.Text), Convert.ToInt32(combo_Zaposleni.SelectedValue.ToString()),
                    Convert.ToDateTime(dtpDatumPrijave.Value),
                    Convert.ToDateTime(dt_Odjava.Value), Convert.ToInt32(combo_Automobil.SelectedValue.ToString()), txt_Relacija.Text,
                    Convert.ToInt32(combo_CistocaSpoljaZad.SelectedValue.ToString()), Convert.ToInt32(combo_CistocaUnutraZad.SelectedValue.ToString()),
                    Convert.ToInt32(combo_CistocaSpoljaRaz.SelectedValue.ToString()), Convert.ToInt32(combo_CistocaUnutraRaz.SelectedValue.ToString()),
                    Convert.ToInt32(combo_NivoUljaZad.SelectedValue.ToString()), dirPredZad, Convert.ToInt32(combo_NivoUljaRaz.SelectedValue.ToString()),
                    dirPredRaz, float.Parse(txt_KmZaduzenje.Text), float.Parse(txt_KmRazduzenje.Text), plomba1Zad, plomba2Zad,
                    plomba1Raz, plomba2Raz);
                FillGV();
            }
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
                        txt_KmZaduzenje.Text = row.Cells[11].Value.ToString();
                        txt_KmRazduzenje.Text = row.Cells[12].Value.ToString();
                        txt_Relacija.Text = row.Cells[8].Value.ToString();

                        combo_Automobil.Text = row.Cells[6].Value.ToString();
                        combo_Zaposleni.Text = row.Cells[2].Value.ToString();
                        combo_CistocaSpoljaZad.Text = row.Cells[17].Value.ToString();
                        combo_CistocaUnutraZad.Text = row.Cells[18].Value.ToString();
                        combo_NivoUljaZad.Text = row.Cells[21].Value.ToString();

                        dtpDatumPrijave.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
                        if (row.Cells[9].Value.Equals(true))
                        {
                            cb_DirPredZad.Checked = true;
                        }
                        if (row.Cells[13].Value.Equals(true))
                        {
                            cb_Plomba1Zad.Checked = true;
                        }
                        if (row.Cells[14].Value.Equals(true))
                        {
                            cb_Plomba2Zad.Checked = true;
                        }
                        PictureBoxes.Clear();
                        filenames.Clear();
                        pictureBox1.Image = null;
                       // FillGV();
                    }
                }
            }
            catch
            {

            }
        }
        private void Slike()
        {

            if (txt_Sifra.Text.Equals(""))
            {
                MessageBox.Show("Mora se izabrati zapis");
            }
            else
            {
                string folder = txt_Sifra.Text.ToString().TrimEnd();
                string path = @"\\192.168.1.6\CistocaSluzbeniAutomobili\" + folder;
                string[] files = Directory.GetFiles(path);
                if (files.Length == 0)
                {
                    MessageBox.Show("Nema dodatih slika");
                }
                else
                {
                    string[] filterVideo = { "*.heic", ".*mp4" };
                    foreach(string video in filterVideo)
                    {
                        videos.AddRange(Directory.GetFiles(path, video, SearchOption.TopDirectoryOnly));
                        if (videos.Count > 0)
                        {
                            MessageBox.Show("Video se mora otvoriti iz foldera");
                            videos.Clear();
                            System.Diagnostics.Process.Start(path);
                            return;
                        }

                    }
                    string[] paterns = { "*.png", "*.gif", "*.jpg", "*.bmp", "*.tif" };
                    
                    foreach (string pattern in paterns)
                    {
                        filenames.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
                    }
                    filenames.Sort();
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (slika < 0 || slika > files.Length-1)
                        {
                            if (slika < 0)
                            {
                                slika = 0;
                            }
                            if (slika > files.Length-1)
                            {
                                slika = files.Length - 1;
                            }
                            return;
                        }
                        else
                        {
                            //pictureBox1.ClientSize = new Size(ThumbWidth, ThumbHeight);
                            pictureBox1.Image = new Bitmap(files[slika]);

                            // If the image is too big, zoom.
                            if ((pictureBox1.Image.Width > ThumbWidth) ||
                                (pictureBox1.Image.Height > ThumbHeight))
                            {
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                            else
                            {
                                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                            }
                        }
                    }
                }
            }
        }
        private void btn_OtvoriSliku_Click(object sender, EventArgs e)
        {
            Slike();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folder = txt_Sifra.Text.ToString().TrimEnd();
            string path = @"\\192.168.1.6\CistocaSluzbeniAutomobili\" + folder;
            System.Diagnostics.Process.Start(path);
        }

        private void btn_Napred_Click(object sender, EventArgs e)
        {
            slika++;
            Slike();
        }

        private void btn_nazad_Click(object sender, EventArgs e)
        {
            slika--;
            Slike();
        }
    }
}