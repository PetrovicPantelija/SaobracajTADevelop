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

namespace Saobracaj.Dokumenta
{
    public partial class frmDokumentaRadniNalog : Form
    {
        bool status = false;
      

        public frmDokumentaRadniNalog()
        {
            InitializeComponent();
        }

        public frmDokumentaRadniNalog(string sifra)
        {
            InitializeComponent();
            txtSifraNajave.Text = sifra;
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            int pomNaj = Convert.ToInt32(txtSifraNajave.Text);
            var select = "select * from RadniNalogDokumenta  where RadniNalogDokumenta.IDRadniNalog =  " + pomNaj;
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
            dataGridView1.Columns[1].HeaderText = "Radni nalog";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Putanja";
            dataGridView1.Columns[2].Width = 550;
        }

        private void frmDokumentaRadniNalog_Load(object sender, EventArgs e)
        {

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            txtPutanja.Text = "";
            status = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanjaCIM.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPutanjaCIM.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void KopirajFajl(string putanja, string FolderDestinacije, bool CIM)
        {
            string fileName = ofd1.FileName; //Ovde ce trebati promena
            fileName = fileName.Replace(" ", "_");
            string sourcePath = fbd.SelectedPath.ToString();
            string result = Path.GetFileName(fileName);
            string targetPath = "";

            if (CIM == true)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\RN\" + FolderDestinacije + @"\CIM";
            }
            else
            {
                targetPath = @"\\192.168.1.6\Saobracaj\RN\" + FolderDestinacije;
            }

            //string targetPath = @"\\192.168.1.9\Saobracaj\" + FolderDestinacije;

            // \\192.168.1.9\\C$\Saobracaj\
            // string targetPath = @"\WSS";
            //targetPath = targetPath.Replace("""", "");
            // Use Path class to manipulate file and directory paths.
            //String putanja2 = String.Format(@"C:\Temp\data_{0}.txt", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            string sourceFile = putanja;
            string destFile = System.IO.Path.Combine(targetPath, result);

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.


            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            // var remote = Path.Combine(@"\\192.168.1.9\Saobracaj\", result);
            var remote = Path.Combine(targetPath, result);
            File.Copy(sourceFile, remote);
            if (CIM == true)
            {
                txtPutanjaCIM.Text = remote;
            }
            else
            {
                txtPutanja.Text = remote;
            }


            // System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
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

        private void KopirajFajl2(string putanja, string FolderDestinacije, int tip)
        {
            string fileName = ofd1.FileName; //Ovde ce trebati promena
            fileName = fileName.Replace(" ", "_");
            string sourcePath = fbd.SelectedPath.ToString();
            string result = Path.GetFileName(fileName);
            string targetPath = "";

            if (tip == 1)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\RN\Teretnica\" + FolderDestinacije + "";
            }
            else if (tip == 2)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\RN\k65\" + FolderDestinacije + "";
            }
            else if (tip == 3)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\RN\kol200\" + FolderDestinacije + "";
            }

            else if (tip == 4)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\RN\C56\" + FolderDestinacije + "";
            }
            else if (tip == 5)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\RN\CIT23\" + FolderDestinacije + "";
            }
            else if (tip == 6)
            {
                targetPath = @"\\192.168.1.6\Saobracaj\RN\CIM\" + FolderDestinacije + "";
            }
            else 
            {
                targetPath = @"\\192.168.1.6\Saobracaj\RN\" + FolderDestinacije + "";
            }

        
            string sourceFile = putanja;
            string destFile = System.IO.Path.Combine(targetPath, result);

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

          
            var remote = Path.Combine(targetPath, result);
            File.Copy(sourceFile, remote);
            if (tip == 1)
            {
                txtPutanjaTeretnica.Text = remote;
            }
            else if (tip == 2)
            {
                txtPutanjak65.Text = remote;
            }
            else if (tip == 3)
            {
                txtPutanjakol200.Text = remote;
            }

            else if (tip == 4)
            {
                txtPutanjaC56.Text = remote;
            }
            else if (tip == 5)
            {
                txtputanjaCIT23.Text = remote;
            }
            else if (tip == 6)
            {
                txtPutanjaCIM.Text = remote;
            }
            else
            {
                txtPutanja.Text = remote;
            }


            // System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRadniNalogDokumenta ins = new InsertRadniNalogDokumenta();
                KopirajFajl(txtPutanjaCIM.Text, txtSifraNajave.Text, true);
                //ins.InsRNDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanjaCIM.Text);
               //RN PANTA KOMENTARISAO ins.UpdateNajavaCIM(Convert.ToInt32(txtSifraNajave.Text));
                RefreshDataGrid();
                status = true;
            }
            else
            {
                /*
                  InsertNajavaDokumenta ins = new InsertNajavaDokumenta();
                  KopirajFajl(txtPutanja2.Text, txtSifraNajave.Text, true);
                  ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanja2.Text);
                  RefreshDataGrid();
                  status = false;
                 */
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanja.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPutanja.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                txtPutanja.Text = txtPutanja.Text.Replace("192.168.1.6", "WSS");
                System.Diagnostics.Process.Start(txtPutanja.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRadniNalogDokumenta ins = new InsertRadniNalogDokumenta();
                KopirajFajl(txtPutanja.Text, txtSifraNajave.Text, false);
                ins.InsRNDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanja.Text, 0);
                RefreshDataGrid();

                status = true;
            }
            else
            {
                /*
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();

                KopirajFajl(txtPutanja.Text, txtSifraNajave.Text, false);
                ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanja.Text);
                RefreshDataGrid();
                 * */
                /*
                 upd.UpdStanice(Convert.ToInt32(txtSifra.Text), txtOpis.Text, chkGranicna.Checked, txtKod.Text, cboDrzava.Text);
                 status = false;
                 txtSifra.Enabled = false;
                 RefreshDataGrid();
                 * */
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

        private void button5_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanja.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPutanjaTeretnica.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanja.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPutanjak65.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanja.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPutanjakol200.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanja.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPutanjaC56.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanja.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtputanjaCIT23.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                txtPutanjaCIM.Text = txtPutanjaCIM.Text.Replace("192.168.1.6", "WSS");
                System.Diagnostics.Process.Start(txtPutanjaCIM.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                txtPutanjaTeretnica.Text = txtPutanjaTeretnica.Text.Replace("192.168.1.6", "WSS");
                System.Diagnostics.Process.Start(txtPutanjaTeretnica.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                txtPutanjak65.Text = txtPutanjak65.Text.Replace("192.168.1.6", "WSS");
                System.Diagnostics.Process.Start(txtPutanjak65.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                txtPutanjakol200.Text = txtPutanjakol200.Text.Replace("192.168.1.6", "WSS");
                System.Diagnostics.Process.Start(txtPutanjakol200.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                txtPutanjaC56.Text = txtPutanjaC56.Text.Replace("192.168.1.6", "WSS");
                System.Diagnostics.Process.Start(txtPutanjaC56.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                txtputanjaCIT23.Text = txtputanjaCIT23.Text.Replace("192.168.1.6", "WSS");
                System.Diagnostics.Process.Start(txtputanjaCIT23.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRadniNalogDokumenta ins = new InsertRadniNalogDokumenta();
                KopirajFajl2(txtPutanjaTeretnica.Text, txtSifraNajave.Text, 1);
                ins.InsRNDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanjaTeretnica.Text, 1);
                RefreshDataGrid();

                status = true;
            }
            else
            {
                /*
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();

                KopirajFajl(txtPutanja.Text, txtSifraNajave.Text, false);
                ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanja.Text);
                RefreshDataGrid();
                 * */
                /*
                 upd.UpdStanice(Convert.ToInt32(txtSifra.Text), txtOpis.Text, chkGranicna.Checked, txtKod.Text, cboDrzava.Text);
                 status = false;
                 txtSifra.Enabled = false;
                 RefreshDataGrid();
                 * */
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRadniNalogDokumenta ins = new InsertRadniNalogDokumenta();
                KopirajFajl2(txtPutanjak65.Text, txtSifraNajave.Text, 2);
                ins.InsRNDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanjak65.Text, 2);
                RefreshDataGrid();
                status = true;
            }
            else
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRadniNalogDokumenta ins = new InsertRadniNalogDokumenta();
                KopirajFajl2(txtPutanjakol200.Text, txtSifraNajave.Text, 3);
                ins.InsRNDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanjakol200.Text, 3);
                RefreshDataGrid();
                status = true;
            }
            else
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRadniNalogDokumenta ins = new InsertRadniNalogDokumenta();
                KopirajFajl2(txtPutanjaC56.Text, txtSifraNajave.Text, 4);
                ins.InsRNDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanjaC56.Text, 4);
                RefreshDataGrid();
                status = true;
            }
            else
            {

            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRadniNalogDokumenta ins = new InsertRadniNalogDokumenta();
                KopirajFajl2(txtputanjaCIT23.Text, txtSifraNajave.Text, 5);
                ins.InsRNDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtputanjaCIT23.Text, 5);
                RefreshDataGrid();
                status = true;
            }
            else
            {

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRadniNalogDokumenta ins = new InsertRadniNalogDokumenta();
                KopirajFajl2(txtPutanjaCIM.Text, txtSifraNajave.Text, 6);
                ins.InsRNDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanjaCIM.Text, 6);
                RefreshDataGrid();
                status = true;
            }
            else
            {

            }
        }
   
    }
}
