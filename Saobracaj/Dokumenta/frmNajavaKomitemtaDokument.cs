using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace TrackModal.Dokumeta
{
    public partial class frmNajavaKomitemtaDokument : Form
    {
        bool status = true;
        string KorisnikCene;

        public frmNajavaKomitemtaDokument()
        {
            InitializeComponent();
        }

        public frmNajavaKomitemtaDokument(string sifra, string Korisnik)
        {
            InitializeComponent();
            txtSifraVozila.Text = sifra;
            KorisnikCene = Korisnik;

            RefreshDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanja.Text;
            ofd1.InitialDirectory = PictureFolder;

            ofd1.Filter = "PDF fajlovi (*.pdf)|*.pdf|SLike (*.jpeg)|*.jpeg";
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPutanja.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string configvalue1 = ConfigurationManager.AppSettings["ip"];
                string configvalue2 = ConfigurationManager.AppSettings["server"];
                txtPutanja.Text = txtPutanja.Text.Replace(configvalue1, configvalue2);
                System.Diagnostics.Process.Start(txtPutanja.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void RefreshDataGrid()
        {
            int pomNaj = Convert.ToInt32(txtSifraVozila.Text);
            var select = "select * from DokumentaNajavaKomitenta  where DokumentaNajavaKomitenta.IDNajave =  " + pomNaj;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Najava";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Putanja";
            dataGridView1.Columns[2].Width = 550;
        }

        private void KopirajFajlPoTipu(string putanja, string FolderDestinacije, int Tip)
        {
            string fileName = ofd1.FileName; //Ovde ce trebati promena
            fileName = fileName.Replace(" ", "_");
            string sourcePath = fbd.SelectedPath.ToString();
            string result = Path.GetFileName(fileName);
            string targetPath = "";
            /*
            if (Tip == 1)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\" + FolderDestinacije + @"\TovarniList";
            }
            else if (Tip == 2)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\" + FolderDestinacije + @"\CIM";
            }
            else if (Tip == 3)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\" + FolderDestinacije + @"\CIT23";
            }
            else if (Tip == 4)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\" + FolderDestinacije + @"\Racuni";
            }
            else if (Tip == 5)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\" + FolderDestinacije + @"\PrijemnaTeretnica";
            }
            else
            {
             * */
            string configvalue1 = ConfigurationManager.AppSettings["ip"];
            targetPath = @"\\" + configvalue1 + "\\Najava\\" + FolderDestinacije;
           // }

            string sourceFile = putanja;
            string destFile = System.IO.Path.Combine(targetPath, result);

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            var remote = Path.Combine(targetPath, result);
            File.Copy(sourceFile, remote);
         
             txtPutanja.Text = remote;
            



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

        private void button4_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertDokumentaNajava ins = new InsertDokumentaNajava();
                KopirajFajlPoTipu(txtPutanja.Text, txtSifraVozila.Text, 6);
                ins.InsNajavaDokumenta(Convert.ToInt32(txtSifraVozila.Text), txtPutanja.Text);
                RefreshDataGrid();
                status = true;
            }
            else
            {

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
                        txtPutanja.Text = row.Cells[2].Value.ToString();

                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }
    }
}



