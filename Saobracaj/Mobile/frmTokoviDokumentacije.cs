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
    public partial class frmTokoviDokumentacije : Form
    {
        private List<PictureBox> PictureBoxes = new List<PictureBox>();

        // Thumbnail sizes.
        private const int ThumbWidth = 400;
        private const int ThumbHeight = 400;
        public frmTokoviDokumentacije()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
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
        private void RefreshDataGrid()
        {
            var select = "select Top 500 EvidencijaTokoviDokumentacije.ID,Zaposleni as ZaposleniID, Rtrim(DePriimek) + ' ' + Rtrim(DeIme) as Zaposleni, EvidencijaTokoviDokumentacije.Datum, EvidencijaTokoviDokumentacije.Mesto, " +
            " EvidencijaTokoviDokumentacije.IDPosla, EvidencijaTokoviDokumentacije.Status, EvidencijaTokoviDokumentacije.Napomena from EvidencijaTokoviDokumentacije " +
            " inner join Delavci on DeSifra = EvidencijaTokoviDokumentacije.Zaposleni " +
            " order by EvidencijaTokoviDokumentacije.ID desc";

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
            dataGridView1.Columns[2].HeaderText = "Zaposleni";
            dataGridView1.Columns[2].Width = 250;


            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Datum";
            dataGridView1.Columns[3].Width = 90;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Mesto";
            dataGridView1.Columns[4].Width = 190;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "ID posla";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Status";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Napomena";
            dataGridView1.Columns[7].Width = 250;


        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Selected == true)
                {
                    frmTokoviDokumentacijeSlika slika = new frmTokoviDokumentacijeSlika(row.Cells[5].Value.ToString());
                    slika.Show();
                
                }

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
                        // txtPutanja.Text = row.Cells[2].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
            string path = Path.Combine(@"//192.168.1.6/TokoviDokumentacijeSlike/", txtSifra.Text + "/");
            //txtPutanja.Text = "\\192.168.1.6\";
            DirectoryInfo dir_info = new DirectoryInfo(path);
            txtDirectory.Text = dir_info.FullName;
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
                    pic.SizeMode = PictureBoxSizeMode.CenterImage;
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
    }
}
