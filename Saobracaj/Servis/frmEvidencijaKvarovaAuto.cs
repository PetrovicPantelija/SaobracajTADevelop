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
using Microsoft.Reporting.WinForms;

namespace Saobracaj.Servis
{
    public partial class frmEvidencijaKvarovaAuto : Form
    {
        private List<PictureBox> PictureBoxes = new List<PictureBox>();

        // Thumbnail sizes.
        private const int ThumbWidth = 500;
        private const int ThumbHeight = 500;
        private int usao = 0;
        public frmEvidencijaKvarovaAuto()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            var select = "select EvidencijaKvarovaAuto.ID, KvaroviAuto.ID, Automobil, KvaroviAuto.Naziv as Kvar, GrupaKvarovaAuto.Naziv as GrupaKvarova, DatumPrijave, Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme) as Prijavio,  StatusKvara.Naziv as Status, Rtrim(D2.DePriimek) + ' ' + Rtrim(D2.DeIme) as Prijavio, DatumPromene, Napomena  from EvidencijaKvarovaAuto " +
             " inner join Delavci on Delavci.DeSifra = EvidencijaKvarovaAuto.Prijavio " +
             " inner join Delavci d2 on d2.DeSifra = EvidencijaKvarovaAuto.Promenio " +
             " inner join KvaroviAuto on KvaroviAuto.ID = EvidencijaKvarovaAuto.Kvar " +
             " inner join StatusKvara on EvidencijaKvarovaAuto.StatusKvara = StatusKvara.ID " +
             " inner join GrupaKvarovaAuto on KvaroviAuto.GrupaKvarovaID = GrupaKvarovaAuto.ID ";

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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var pom = row.Cells[7].Value.ToString();

                if (pom == "Popravljen")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                }
                else if (pom == "Kritican")
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                    row.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
                }
                dataGridView1.Refresh();
            }

        }


        private void RefreshDataGridPoStatusu()
        {
            var select = "select EvidencijaKvarovaAuto.ID, KvaroviAuto.ID, Automobil, KvaroviAuto.Naziv as Kvar, GrupaKvarovaAuto.Naziv as GrupaKvarova, DatumPrijave, Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme) as Prijavio,  StatusKvara.Naziv as Status, Rtrim(D2.DePriimek) + ' ' + Rtrim(D2.DeIme) as Prijavio, DatumPromene, Napomena  from EvidencijaKvarovaAuto " +
             " inner join Delavci on Delavci.DeSifra = EvidencijaKvarovaAuto.Prijavio " +
             " inner join Delavci d2 on d2.DeSifra = EvidencijaKvarova.Promenio " +
             " inner join KvaroviAuto on KvaroviAuto.ID = EvidencijaKvarovaAuto.Kvar " +
             " inner join StatusKvara on EvidencijaKvarovaAuto.StatusKvara = StatusKvara.ID " +
             " inner join GrupaKvarovaAuto on KvaroviAuto.GrupaKvarovaID = GrupaKvarovaAuto.ID " +
             " where StatusKvara = " + cboStatusi.SelectedValue;

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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var pom = row.Cells[7].Value.ToString();

                if (pom == "Popravljen")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                }
                else if (pom == "Kritican")
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                    row.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
                }
                dataGridView1.Refresh();
            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void cboPretraziLokomotivu_Click(object sender, EventArgs e)
        {
            RefreshDataGridLokomotiva();
        }

        private void RefreshDataGridLokomotiva()
        {
            var select = "select EvidencijaKvarovaAuto.ID, KvaroviAuto.ID, Automobil, KvaroviAuto.Naziv as Kvar, GrupaKvarovaAuto.Naziv as GrupaKvarova, DatumPrijave, Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme) as Prijavio,  StatusKvara.Naziv as Status, Rtrim(D2.DePriimek) + ' ' + Rtrim(D2.DeIme) as Prijavio, DatumPromene, Napomena  from EvidencijaKvarovaAuto " +
             " inner join Delavci on Delavci.DeSifra = EvidencijaKvarovaAuto.Prijavio " +
             " inner join Delavci d2 on d2.DeSifra = EvidencijaKvarova.Promenio " +
             " inner join KvaroviAuto on KvaroviAuto.ID = EvidencijaKvarovaAuto.Kvar " +
             " inner join StatusKvara on EvidencijaKvarovaAuto.StatusKvara = StatusKvara.ID " +
             " inner join GrupaKvarovaAuto on KvaroviAuto.GrupaKvarovaID = GrupaKvarovaAuto.ID where EvidencijaKvarovaAuto.Automobil = '" + cboLokomotiva.SelectedValue + "'";

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





            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var pom = row.Cells[7].Value.ToString();

                if (pom == "Popravljen")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                }
                else if (pom == "Kritican")
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                    row.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
                }




                dataGridView1.Refresh();

            }

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            RefreshDataGridPoStatusu();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            InsertKvarovi ins = new InsertKvarovi();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    ins.UpdEvidenciKvarovaPoIDAuto(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboStatusi.SelectedValue), Convert.ToInt32(cboZaposleni.SelectedValue));
                    RefreshDataGrid();
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            InsertKvarovi ins = new InsertKvarovi();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    ins.UpdEvidenciKvarovaPromeniKvarAuto(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboKvar.SelectedValue));
                    RefreshDataGrid();
                }
            }
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
                        // txtPutanja.Text = row.Cells[2].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
            string path = Path.Combine(@"//192.168.1.6/KvaroviSlike/", txtSifra.Text + "/");
            //txtPutanja.Text = "\\192.168.1.6\";
            DirectoryInfo dir_info = new DirectoryInfo(path);
            txtDirectory.Text = dir_info.FullName;
        }
    }
}
