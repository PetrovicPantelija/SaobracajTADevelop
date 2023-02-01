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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Servis
{
    public partial class frmPrijavaKvaraAuto : Form
    {
        private List<PictureBox> PictureBoxes = new List<PictureBox>();
        List<string> filenames = new List<string>();
        List<string> videos = new List<string>();
        private const int ThumbWidth = 458;
        private const int ThumbHeight = 288;
        int slika = 0;

        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        bool status = false;
        public frmPrijavaKvaraAuto()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "frmPrijavaKvaraAuto";
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
                       // tsDelete.Enabled = false;
                    }
                }
            }

            conn.Close();
        }
        private void frmPrijavaKvaraAuto_Load(object sender, EventArgs e)
        {
            FillData();
            RefreshDG();

        }
        private void FillData()
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder cBuilder = new SqlCommandBuilder(da);

            var query = "Select RegBr,ID From Automobili";
            da = new SqlDataAdapter(query, conn);
            var ds = new DataSet();
            da.Fill(ds);
            combo_Automobil.DataSource = ds.Tables[0];
            combo_Automobil.DisplayMember = "RegBr";
            combo_Automobil.ValueMember = "ID";


            var query1 = "Select DeSifra, Rtrim(DeIme) + ' ' +Rtrim(DePriimek)as Zaposleni From Delavci Order By DeIme";
            da = new SqlDataAdapter(query1, conn);
            var ds1 = new DataSet();
            da.Fill(ds1);
            combo_Prijavio.DataSource = ds1.Tables[0];
            combo_Prijavio.DisplayMember = "Zaposleni";
            combo_Prijavio.ValueMember = "DeSifra";

            var query2 = "Select KvaroviAuto.Id as ID, GrupaKvarovaAuto.Naziv, KvaroviAuto.Naziv as Kvar From KvaroviAuto inner join GrupaKvarovaAuto on " +
                "KvaroviAuto.GrupaKvarovaID=GrupaKvarovaAuto.ID Order by GrupaKvarovaAuto.Naziv";
            da = new SqlDataAdapter(query2, conn);
            var ds2 = new DataSet();
            da.Fill(ds2);
            combo_Kvar.DataSource = ds2.Tables[0];
            combo_Kvar.DisplayMember = "Kvar";
            combo_Kvar.ValueMember = "ID";

            var query3 = "Select ID,Naziv From StatusKvaraAuto";
            da = new SqlDataAdapter(query3, conn);
            var ds3 = new DataSet();
            da.Fill(ds3);
            combo_Status.DataSource = ds3.Tables[0];
            combo_Status.DisplayMember = "Naziv";
            combo_Status.ValueMember = "ID";

            var query4 = "Select DeSifra, Rtrim(DeIme) + ' ' + Rtrim(DePriimek) as Zaposleni From Delavci Order By DeIme";
            da = new SqlDataAdapter(query4, conn);
            var ds4 = new DataSet();
            da.Fill(ds4);
            combo_Promenio.DataSource = ds4.Tables[0];
            combo_Promenio.DisplayMember = "Zaposleni";
            combo_Promenio.ValueMember = "DeSifra";




            RefreshDG();
        }
        private void FillDv()
        {
            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [ID],Rtrim([Automobil]) as Automobil,[Prijavio],[DatumPrijave],[Kvar],[StatusKvara],[Promenio],[DatumPromene],[Napomena]  FROM [TESTIRANJE].[dbo].[EvidencijaKvarovaAuto] where ID = " + Convert.ToInt32(txt_Sifra.Text), conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                combo_Automobil.SelectedValue = dr["Automobili"].ToString();
                combo_Prijavio.SelectedValue = Convert.ToInt32(dr["Prijavio"].ToString());
                dt_Prijava.Value = Convert.ToDateTime(dr["DatumPrijave"].ToString());
                combo_Kvar.SelectedValue = Convert.ToInt32(dr["Kvar"].ToString());
                combo_Promenio.SelectedValue = Convert.ToInt32(dr["Promenio"]).ToString();
                dt_Promena.Value = Convert.ToDateTime(dr["DatumPromene"].ToString());
                txt_Napomena.Text = dr["Napomena"].ToString();
            }
            conn.Close();
        }
        private void RefreshDG()
        {
            var query = "select EvidencijaKvarovaAuto.ID, Automobil, Prijavio, DatumPrijave, " +
                "(Rtrim(Delavci.DeIme) + ' ' + Rtrim(Delavci.DePriimek)) as Prijavio, EvidencijaKvarovaAuto.Kvar, " +
                "KvaroviAuto.Naziv, StatusKvara, Promenio, DatumPromene, EvidencijaKvarovaAuto.Napomena,Automobili.ID from EvidencijaKvarovaAuto " +
                "inner join Delavci on Delavci.DeSifra = EvidencijaKvarovaAuto.Prijavio " +
                "inner join KvaroviAuto on KvaroviAuto.ID = EvidencijaKvarovaAuto.Kvar " +
                "Inner join Automobili on Automobili.RegBr = EvidencijaKvarovaAuto.Automobil " +
                "order by EvidencijaKvarovaAuto.ID desc";
            SqlConnection conn = new SqlConnection(connect);
            var da = new SqlDataAdapter(query, conn);
            var ds = new DataSet();
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

            DataGridViewColumn col0 = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 45;

            DataGridViewColumn col1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Automobil";
            dataGridView1.Columns[1].Width = 95;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Prijavio";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Datum prijave";
            dataGridView1.Columns[3].Width = 70;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Zaposleni prijavio";
            dataGridView1.Columns[4].Width = 170;

            dataGridView1.Columns[5].HeaderText = "Kvar";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[6].HeaderText = "Kvar naziv";
            dataGridView1.Columns[6].Width = 170;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[7].HeaderText = "Status kvara";
            dataGridView1.Columns[7].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[8].HeaderText = "Promenio";
            dataGridView1.Columns[8].Width = 60;


            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[9].HeaderText = "Datum promene";
            dataGridView1.Columns[9].Width = 70;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[10].HeaderText = "Napomena";
            dataGridView1.Columns[10].Width = 205;
            dataGridView1.Columns[11].HeaderText = "IDAuto";
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
                        combo_Automobil.Text = row.Cells[1].Value.ToString();
                        combo_Prijavio.Text = row.Cells[4].Value.ToString();
                        dt_Prijava.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
                        combo_Kvar.Text = row.Cells[6].Value.ToString();
                        txt_Napomena.Text = row.Cells[10].Value.ToString();

                        PictureBoxes.Clear();
                        filenames.Clear();
                        pictureBox1.Image = null;
                    }
                }
            }
            catch
            {

            }
        }

        private void tsb_New_Click(object sender, EventArgs e)
        {
            txt_Sifra.Text = "";
            txt_Sifra.Enabled = false;
            status = true;
        }

        private void tsb_Save_Click(object sender, EventArgs e)
        {
            InsertPrijavaKvaraAuto prijavaKvaraAuto = new InsertPrijavaKvaraAuto();
            if (status == true)
            {
                prijavaKvaraAuto.InsertPrijava(combo_Automobil.Text.ToString(), Convert.ToInt32(combo_Prijavio.SelectedValue), Convert.ToDateTime(dt_Prijava.Value),
                Convert.ToInt32(combo_Kvar.SelectedValue), Convert.ToInt32(combo_Status.SelectedValue), Convert.ToInt32(combo_Promenio.SelectedValue), txt_Napomena.Text, Convert.ToInt32(combo_Automobil.SelectedValue.ToString()));
                RefreshDG();
                status = false;
                txt_Sifra.Enabled = true;
            }
            else
            {
                prijavaKvaraAuto.UpdatePrijava(Convert.ToInt32(txt_Sifra.Text), combo_Automobil.Text.ToString(), Convert.ToInt32(combo_Prijavio.SelectedValue), Convert.ToDateTime(dt_Prijava.Value),
                Convert.ToInt32(combo_Kvar.SelectedValue), Convert.ToInt32(combo_Status.SelectedValue), Convert.ToInt32(combo_Promenio.SelectedValue), txt_Napomena.Text, Convert.ToInt32(combo_Automobil.SelectedValue.ToString()));
                RefreshDG();
            }
        }

        private void tsb_Delete_Click(object sender, EventArgs e)
        {
            InsertPrijavaKvaraAuto prijavaKvaraAuto = new InsertPrijavaKvaraAuto();
            prijavaKvaraAuto.DeletePrijava(Convert.ToInt32(txt_Sifra.Text));
            RefreshDG();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                string path = @"\\192.168.1.6\KvaroviAutoSlike\" + folder;
                string[] files = Directory.GetFiles(path);
                if (files.Length == 0)
                {
                    MessageBox.Show("Nema dodatih slika");
                }
                else
                {
                    string[] filterVideo = { "*.heic", ".*mp4" };
                    foreach (string video in filterVideo)
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
                        if (slika < 0 || slika > files.Length - 1)
                        {
                            if (slika < 0)
                            {
                                slika = 0;
                            }
                            if (slika > files.Length - 1)
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

        private void btn_nazad_Click(object sender, EventArgs e)
        {
            slika--;
            Slike();
        }

        private void btn_Napred_Click(object sender, EventArgs e)
        {
            slika++;
            Slike();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folder = txt_Sifra.Text.ToString().TrimEnd();
            string path = @"\\192.168.1.6\KvaroviAutoSlike\" + folder;
            System.Diagnostics.Process.Start(path);
        }

        private void txt_Vise_Click(object sender, EventArgs e)
        {
            InsertPrijavaKvaraAuto prijavaKvaraAuto = new InsertPrijavaKvaraAuto();
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                        prijavaKvaraAuto.UpdatePrijava(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), Convert.ToInt32(row.Cells[2].Value.ToString()), 
                            Convert.ToDateTime(row.Cells[3].Value),Convert.ToInt32(row.Cells[5].Value), Convert.ToInt32(combo_Status.SelectedValue.ToString()), 
                            Convert.ToInt32(combo_Promenio.SelectedValue.ToString()), row.Cells[10].Value.ToString(), Convert.ToInt32(row.Cells[11].Value.ToString()));
                    
                }
                RefreshDG();
            }
            catch { }
            
        }
    }
}
