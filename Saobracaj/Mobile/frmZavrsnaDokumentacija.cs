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
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace Saobracaj.Mobile
{
    public partial class frmZavrsnaDokumentacija : Form
    {
        private List<PictureBox> PictureBoxes = new List<PictureBox>();
        private const int ThumbWidth = 500;
        private const int ThumbHeight = 500;
        private int usao = 0;

        string niz = "";
        public static string code = "frmZavrsnaDokumentacija";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        public frmZavrsnaDokumentacija()
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
        private void RefreshDataGrid()
        {
            var select = "select ZavrsnaDokumenta.ID, ZavrsnaDokumenta.Napomena, " +
            " ZavrsnaDokumenta.DatumVazenja, ZavrsnaDokumenta.NajavaID, ZavrsnaDokumenta.Kreirano, ZavrsnaDokumenta.Kreirao, " +
            " TipZavrsnogDokumentaID.Naziv as TipDokumenta, " +
            " (Delavci.DePriimek + ' ' + DeIme) as RadnikKreirao " +
            " from ZavrsnaDokumenta " +
            " inner join TipZavrsnogDokumentaID on ZavrsnaDokumenta.TipZavrsnogDokumentaID = TipZavrsnogDokumentaID.ID " +
            " inner " +
            " join Delavci on Delavci.DeSifra = ZavrsnaDokumenta.Kreirao  order by ZavrsnaDokumenta.ID";

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

        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            // Get the file's information.
            /* PictureBox pic = sender as PictureBox;
             FileInfo file_into = pic.Tag as FileInfo;

             // "Start" the file.
             Process.Start(file_into.FullName);
            */
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void txtDirectory_TextChanged(object sender, EventArgs e)
        {
            foreach (PictureBox pic in PictureBoxes)
            {
                pic.DoubleClick -= PictureBox_DoubleClick;
                pic.Dispose();
            }
            flpThumbnails.Controls.Clear();
            PictureBoxes = new List<PictureBox>();

            // If the directory doesn't exist, do nothing else.
            if (!Directory.Exists(txtDirectory.Text)) return;

            // Get the names of the files in the directory.
            List<string> filenames = new List<string>();
            string[] patterns = { "*.png", "*.gif", "*.jpg", "*.bmp", "*.tif" };
            foreach (string pattern in patterns)
            {
                filenames.AddRange(Directory.GetFiles(txtDirectory.Text,
                    pattern, SearchOption.TopDirectoryOnly));
            }
            filenames.Sort();

            // Load the files.
            foreach (string filename in filenames)
            {
                // Load the picture into a PictureBox.
                PictureBox pic = new PictureBox();

                pic.ClientSize = new Size(ThumbWidth, ThumbHeight);
                pic.Image = new Bitmap(filename);

                // If the image is too big, zoom.
                if ((pic.Image.Width > ThumbWidth) ||
                    (pic.Image.Height > ThumbHeight))
                {
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pic.SizeMode = PictureBoxSizeMode.Normal;
                }

                // Add the DoubleClick event handler.
                pic.DoubleClick += PictureBox_DoubleClick;

                // Add a tooltip.
                FileInfo file_info = new FileInfo(filename);
                /*  tipPicture.SetToolTip(pic, file_info.Name +
                      "\nCreated: " + file_info.CreationTime.ToShortDateString() +
                      "\n(" + pic.Image.Width + " x " + pic.Image.Height + ") " +
                      ToFileSizeApi(file_info.Length));
                  pic.Tag = file_info;
                */
                // Add the PictureBox to the FlowLayoutPanel.
                pic.Parent = flpThumbnails;
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
                        txtSifra.Text = row.Cells[0].Value.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
            string path = Path.Combine(@"//192.168.1.6/ZavrsnaDokumenta/", txtSifra.Text + "/");
            DirectoryInfo dir_info = new DirectoryInfo(path);
            txtDirectory.Text = dir_info.FullName;
        }
    }
}
