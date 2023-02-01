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
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp;
using System.Text.RegularExpressions;

using System.Drawing.Imaging;

namespace Saobracaj.Izvoz
{
    public partial class frmIzvozDokumenta : Form
    {
        bool status = false;
        public frmIzvozDokumenta()
        {
            InitializeComponent();
        }

        public frmIzvozDokumenta(string sifra)
        {
            InitializeComponent();
            txtSifraUvoza.Text = sifra;
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            if (txtSifraUvoza.Text == "")
            {
                MessageBox.Show("Odaberite stavku");
                return;
            }
            int pomNaj = Convert.ToInt32(txtSifraUvoza.Text);
            var select = "select * from IzvozDokumenta  where IzvozDokumenta.IDIzvoz =  " + pomNaj;
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

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Izvozni zapis";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Putanja";
            dataGridView1.Columns[2].Width = 550;
        }

        private void KopirajFajlPoTipu(string putanja, string FolderDestinacije, int Tip)
        {
            string fileName = ofd1.FileName; //Ovde ce trebati promena
            fileName = fileName.Replace(" ", "_");
            string sourcePath = fbd1.SelectedPath.ToString();
            string result = Path.GetFileName(fileName);
            string targetPath = "";

            targetPath = @"\\192.168.1.6\Izvoz\" + FolderDestinacije + @"\Izvoz";

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

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanja.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPutanja.Text = fbd1.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtPutanja.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //  if (status == true)
            // {
            InsertIzvozDokumenta ins = new InsertIzvozDokumenta();
            KopirajFajlPoTipu(txtPutanja.Text, txtSifraUvoza.Text, 6);
            ins.InsIzvozDokumenta(Convert.ToInt32(txtSifraUvoza.Text), txtPutanja.Text);
            RefreshDataGrid();

            status = true;
            //  }
            //  else
            //  {

            //  }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertIzvozDokumenta ins = new InsertIzvozDokumenta();
            ins.DelIzvozDokumenta(Convert.ToInt32(txtSifra.Text));
            RefreshDataGrid();

            status = true;
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
