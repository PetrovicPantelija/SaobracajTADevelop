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
    public partial class frmEvidencijaKvarova : Form
    {
        private List<PictureBox> PictureBoxes = new List<PictureBox>();

        // Thumbnail sizes.
        private const int ThumbWidth = 500;
        private const int ThumbHeight = 500;
        private int usao = 0;
        public frmEvidencijaKvarova()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        string niz = "";
        public static string code = "frmEvidencijaKvarova";
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
            var select = "select EvidencijaKvarova.ID, Kvarovi.ID, Lokomotiva, Kvarovi.Naziv as Kvar, GrupaKvarova.Naziv as GrupaKvarova, DatumPrijave, Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme) as Prijavio,  StatusKvara.Naziv as Status, Rtrim(D2.DePriimek) + ' ' + Rtrim(D2.DeIme) as Prijavio, DatumPromene, Napomena  from EvidencijaKvarova " +
             " inner join Delavci on Delavci.DeSifra = EvidencijaKvarova.Prijavio " +
             " inner join Delavci d2 on d2.DeSifra = EvidencijaKvarova.Promenio " +
             " inner join Kvarovi on Kvarovi.ID = EvidencijaKvarova.Kvar " +
             " inner join StatusKvara on EvidencijaKvarova.StatusKvara = StatusKvara.ID " +
             " inner join GrupaKvarova on Kvarovi.GrupaKvarovaID = GrupaKvarova.ID ";

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
            var select = "select EvidencijaKvarova.ID, Kvarovi.ID, Lokomotiva, Kvarovi.Naziv as Kvar, GrupaKvarova.Naziv as GrupaKvarova, DatumPrijave, Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme) as Prijavio,  StatusKvara.Naziv as Status, Rtrim(D2.DePriimek) + ' ' + Rtrim(D2.DeIme) as Prijavio, DatumPromene, Napomena  from EvidencijaKvarova " +
             " inner join Delavci on Delavci.DeSifra = EvidencijaKvarova.Prijavio " +
             " inner join Delavci d2 on d2.DeSifra = EvidencijaKvarova.Promenio " +
             " inner join Kvarovi on Kvarovi.ID = EvidencijaKvarova.Kvar " +
             " inner join StatusKvara on EvidencijaKvarova.StatusKvara = StatusKvara.ID " +
             " inner join GrupaKvarova on Kvarovi.GrupaKvarovaID = GrupaKvarova.ID " +
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

        private void frmEvidencijaKvarova_Load(object sender, EventArgs e)
        {
            var select3 = " select ID, naziv from StatusKvara";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboStatusi.DataSource = ds3.Tables[0];
            cboStatusi.DisplayMember = "Naziv";
            cboStatusi.ValueMember = "ID";


            var select4 = " select SmSifra, SmNaziv from Mesta where Lokomotiva = 1";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboLokomotiva.DataSource = ds4.Tables[0];
            cboLokomotiva.DisplayMember = "SmNaziv";
            cboLokomotiva.ValueMember = "SmSifra";

            var select5 = " Select DeSifra, Rtrim(DeIme) + ' ' + Rtrim(DePriimek) as Zaposleni From Delavci Order By DeIme";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboZaposleni.DataSource = ds5.Tables[0];
            cboZaposleni.DisplayMember = "Zaposleni";
            cboZaposleni.ValueMember = "DeSifra";

            var select6 = " Select ID, Naziv from GrupaKvarova";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboGrupaKvara.DataSource = ds6.Tables[0];
            cboGrupaKvara.DisplayMember = "Naziv";
            cboGrupaKvara.ValueMember = "ID";

            usao = 1;
        }

        private void RefreshDataGridLokomotiva()
        {
            var select = "select EvidencijaKvarova.ID, Kvarovi.ID, Lokomotiva, Kvarovi.Naziv as Kvar, GrupaKvarova.Naziv as GrupaKvarova, DatumPrijave, Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme) as Prijavio,  StatusKvara.Naziv as Status, Rtrim(D2.DePriimek) + ' ' + Rtrim(D2.DeIme) as Prijavio, DatumPromene, Napomena  from EvidencijaKvarova " +
             " inner join Delavci on Delavci.DeSifra = EvidencijaKvarova.Prijavio " +
             " inner join Delavci d2 on d2.DeSifra = EvidencijaKvarova.Promenio " +
             " inner join Kvarovi on Kvarovi.ID = EvidencijaKvarova.Kvar " +
             " inner join StatusKvara on EvidencijaKvarova.StatusKvara = StatusKvara.ID " +
             " inner join GrupaKvarova on Kvarovi.GrupaKvarovaID = GrupaKvarova.ID where EvidencijaKvarova.Lokomotiva = '" + cboLokomotiva.SelectedValue + "'";
            
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

        private void cboPretraziLokomotivu_Click(object sender, EventArgs e)
        {
            RefreshDataGridLokomotiva();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            InsertKvarovi ins = new InsertKvarovi();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    ins.UpdEvidenciKvarovaPoID(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboStatusi.SelectedValue), Convert.ToInt32(cboZaposleni.SelectedValue));
                    RefreshDataGrid();
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
            string path = Path.Combine(@"//192.168.1.6/KvaroviSlike/", txtSifra.Text + "/");
            //txtPutanja.Text = "\\192.168.1.6\";
            DirectoryInfo dir_info = new DirectoryInfo(path);
            txtDirectory.Text = dir_info.FullName;
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
            // Delete the old PictureBoxes.





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

        private void metroButton3_Click(object sender, EventArgs e)
        {
            InsertKvarovi ins = new InsertKvarovi();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    ins.UpdEvidenciKvarovaPromeniKvar(Convert.ToInt32(row.Cells[0].Value.ToString()),  Convert.ToInt32(cboKvar.SelectedValue));
                    RefreshDataGrid();
                }
            }
        }

        private void cboGrupaKvara_SelectedValueChanged(object sender, EventArgs e)
        {
            if (usao == 1)
            { 
            var select7 = " Select ID, Naziv from Kvarovi where GrupaKvarovaID = " + cboGrupaKvara.SelectedValue;
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboKvar.DataSource = ds7.Tables[0];
            cboKvar.DisplayMember = "Naziv";
            cboKvar.ValueMember = "ID";
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            RefreshDataGridPoStatusu();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            InsertKvarovi ins = new InsertKvarovi();
            ins.DeleteStampajKvarovi();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    ins.InsStampajKvarovi(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), Convert.ToDateTime(row.Cells[5].Value.ToString()), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[10].Value.ToString());
                }
            }

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            TESTIRANJEDataSet13TableAdapters.StampaEvidencijeKvaraTableAdapter ta = new TESTIRANJEDataSet13TableAdapters.StampaEvidencijeKvaraTableAdapter();
            TESTIRANJEDataSet13.StampaEvidencijeKvaraDataTable dt = new TESTIRANJEDataSet13.StampaEvidencijeKvaraDataTable();

            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptEvidencijaKvarova.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void btnPickDirectory_Click(object sender, EventArgs e)
        {

        }
    }
}
