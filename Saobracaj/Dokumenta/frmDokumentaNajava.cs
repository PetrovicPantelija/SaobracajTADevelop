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


using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;
using System.Text.RegularExpressions;

using System.Drawing.Imaging;

namespace Saobracaj.Dokumenta
{
    public partial class frmDokumentaNajava : Form
    {
        bool status = false;
    
        public frmDokumentaNajava()
        {
            InitializeComponent();
        }

        public frmDokumentaNajava(string sifra, string TipPrevoza)
        {
            InitializeComponent();
            txtSifraNajave.Text = sifra;
            txtTipPrevoza.Text = TipPrevoza;
            /*
            Unutrašnji prazan
            Unutrašnji pun
            Uvoz/Izvoz/Tranzit prazno
            Uvoz/Tranzit tovareno
            Izvoz tovareno
            */
            switch (txtTipPrevoza.Text)
            {
                case "Unutrašnji prazan":
                    txtTovarniList.Enabled = true;
                    btnTovarniList.Enabled = true;
                    btnSacuvajTovarniList.Enabled = true;
                    break;
                case "Unutrašnji pun": 
                    txtTovarniList.Enabled = true;
                    btnTovarniList.Enabled = true;
                    btnSacuvajTovarniList.Enabled = true;
                    break;
                case "Uvoz/Izvoz/Tranzit prazno":
                    txtCIT23.Enabled = true;
                    txtPutanja2.Enabled = true;
                    button3.Enabled = true;
                    button6.Enabled = true;
                    btnCIT23.Enabled = true;
                    btnCIT23Sacuvaj.Enabled = true;
                    // CIM
                    break;
                case "Uvoz/Tranzit tovareno": 
                    txtCIT23.Enabled = true;
                    txtPutanja2.Enabled = true;
                    txtRacun.Enabled = true;
                    button3.Enabled = true;
                    button6.Enabled = true;  
                    btnCIT23.Enabled = true;
                    btnCIT23Sacuvaj.Enabled = true;
                    btnRacun.Enabled = true;
                    btnRacunSacuvaj.Enabled = true;
                    
                
                // CIM
                    break;
                case "Izvoz tovareno": 
                    txtCIT23.Enabled = true;
                    txtPutanja2.Enabled = true; // CIM
                    button3.Enabled = true;
                    button6.Enabled = true;
                    btnCIT23.Enabled = true;
                    btnCIT23Sacuvaj.Enabled = true;
                    break;
                default: 
                    MessageBox.Show("Odrediti prvo tip prevoza");
                    
                  
                    break;
            }

            RefreshDataGrid();
        }

        public string removeDoubleBackslashes(string input)
        {
            char[] separator = new char[1] { '\\' };
            string result = "";
            string[] subResult = input.Split(separator);
            for (int i = 0; i <= subResult.Length - 1; i++)
            {
                result = i < subResult.Length - 1 ? result + subResult[i] + "\\" : result + subResult[i];
            }
            return result;
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

        private void KopirajFajlPoTipu(string putanja, string FolderDestinacije, int Tip)
        {
            string fileName =  ofd1.FileName; //Ovde ce trebati promena
            fileName = fileName.Replace(" ", "_");
            string sourcePath = fbd.SelectedPath.ToString();
            string result = Path.GetFileName(fileName);
            string targetPath = "";

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
                targetPath = @"\\192.168.1.6\Saobracaj\" + FolderDestinacije;
            }
        
        string sourceFile = putanja;
        string destFile = System.IO.Path.Combine(targetPath, result);

        if (!System.IO.Directory.Exists(targetPath))
        {
            System.IO.Directory.CreateDirectory(targetPath);
        }

        var remote = Path.Combine(targetPath, result);
        File.Copy(sourceFile, remote);
        if (Tip == 1)
        {
            txtTovarniList.Text = remote;
        }
        else if (Tip == 2)
        {
            txtPutanja2.Text = remote;    
        }
        else if (Tip == 3)
        {
            txtCIT23.Text = remote;
        }
        else if (Tip == 4)
        {
            txtRacun.Text = remote;

        }
        else if (Tip == 5)
        {
            txtPrijemnaTeretnica.Text = remote;
        }
        else
        {
            txtPutanja.Text = remote;    
        }
            
            
          
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

        private void tsSave_Click(object sender, EventArgs e)
        {
            /*
            if (status == true)
            {
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();
                KopirajFajl(txtPutanja.Text, txtSifraNajave.Text);
                ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanja.Text);
                RefreshDataGrid();

                status = false;
            }
            else
            {
                InsertNajavaPrevoznik upd = new InsertNajavaPrevoznik();
                /*
                 upd.UpdStanice(Convert.ToInt32(txtSifra.Text), txtOpis.Text, chkGranicna.Checked, txtKod.Text, cboDrzava.Text);
                 status = false;
                 txtSifra.Enabled = false;
                 RefreshDataGrid();
                 * 
            }
       */
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            txtPutanja.Text = "";
            txtPutanja2.Text = "";
            txtCIT23.Text = "";
            txtPrijemnaTeretnica.Text = "";
            txtRacun.Text = "";
            status = true;
        }

        private void RefreshDataGrid()
        {
            int pomNaj = Convert.ToInt32(txtSifraNajave.Text);
            var select = "select * from NajavaDokumenta  where NajavaDokumenta.IDNajave =  " + pomNaj;
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
            dataGridView1.Columns[1].HeaderText = "Najava";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Putanja";
            dataGridView1.Columns[2].Width = 550;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
          //P1      txtPutanja.Text = txtPutanja.Text.Replace("192.168.1.6", "WSS");
                System.Diagnostics.Process.Start(txtPutanja.Text);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           // System.Diagnostics.Process.Start(txtPutanja.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPutanja2.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPutanja2.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
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
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();
                KopirajFajlPoTipu(txtPutanja.Text, txtSifraNajave.Text, 6);
                ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanja.Text);
                RefreshDataGrid();

                status = true;
            }
            else
            {
              
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();
                KopirajFajlPoTipu(txtPutanja2.Text, txtSifraNajave.Text, 2);
                ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPutanja2.Text);
                //  ins.UpdateNajavaCIM(Convert.ToInt32(txtSifraNajave.Text));
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

        private void tsDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();

                if (row.Selected == true)
                {
                    ins.DelNajDokumenta(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }

                RefreshDataGrid();

            }
        }

        private void frmDokumentaNajava_Load(object sender, EventArgs e)
        {

        }

        private void btnTovarniList_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtTovarniList.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtTovarniList.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void btnCIT23_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtCIT23.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtCIT23.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void btnRacun_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtRacun.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtRacun.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string PictureFolder = txtPrijemnaTeretnica.Text;
            ofd1.InitialDirectory = PictureFolder;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txtPrijemnaTeretnica.Text = fbd.SelectedPath.ToString() + ofd1.FileName;
            }
        }

        private void btnSacuvajTovarniList_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();
                KopirajFajlPoTipu(txtTovarniList.Text, txtSifraNajave.Text, 1);
                ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtTovarniList.Text);
              //  ins.UpdateNajavaCIM(Convert.ToInt32(txtSifraNajave.Text));
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

        private void btnCIT23Sacuvaj_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();
                KopirajFajlPoTipu(txtCIT23.Text, txtSifraNajave.Text, 3);
                ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtCIT23.Text);
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

        private void btnRacunSacuvaj_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();
                KopirajFajlPoTipu(txtRacun.Text, txtSifraNajave.Text, 4);
                ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtRacun.Text);
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

        private void button13_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertNajavaDokumenta ins = new InsertNajavaDokumenta();
                KopirajFajlPoTipu(txtPrijemnaTeretnica.Text, txtSifraNajave.Text, 5);
                ins.InsNajDokumenta(Convert.ToInt32(txtSifraNajave.Text), txtPrijemnaTeretnica.Text);

                RefreshDataGrid();
                status = true;
            }
            else
            {
               
            }
        }

        static void CreateMergedPDF(string targetPDF, string sourceDir)
        {
            bool exists = System.IO.Directory.Exists(sourceDir + @"\Izlaz\");

            if (!exists)
                System.IO.Directory.CreateDirectory(sourceDir + @"\Izlaz\");
            using (FileStream stream = new FileStream(targetPDF, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4);
                PdfCopy pdf = new PdfCopy(pdfDoc, stream);
                pdfDoc.Open();
                var files = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("Merging files count: " + files.Length);
                int i = 1;
                foreach (string file in files)
                {
                    var filePath = file;
                    string filenameNoExtension = Path.GetFileNameWithoutExtension(filePath);
                    string extension = Path.GetExtension(filePath);
                    if (extension == ".pdf") 
                    {
                        if (filenameNoExtension != "Objedinjen")
                          pdf.AddDocument(new PdfReader(file));
                    }
                    if (extension == ".JPG")
                    {
                     
                    }
                    i++;
                }
                pdfDoc.Close();
                Console.WriteLine("SpeedPASS PDF merge complete.");
            }
        }

        public void ImagesToPdf(string[] imagepaths, string pdfpath)
        {
            iTextSharp.text.Rectangle pageSize = null;
            foreach (string slika in imagepaths)
            {
                using (var srcImage = new Bitmap(slika.ToString()))
                {
                    pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
                }

                using (var ms = new MemoryStream())
                {
                    var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                    document.Open();
                    var image = iTextSharp.text.Image.GetInstance(slika.ToString());
                    float pageWidth = document.PageSize.Width - (35 + 35);
                    float pageHeight = document.PageSize.Height - (35 + 35);
                    image.ScaleToFit(pageWidth, pageHeight);

                    document.Add(image);
                    document.Close();

                    File.WriteAllBytes(slika.ToString() + ".pdf", ms.ToArray());
                }
            }
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
             //CreateMergedPDF(@"\\192.168.1.6\Saobracaj\" + txtSifraNajave.Text + @"\\Objedinjen.pdf", @"\\192.168.1.6\Saobracaj\" + txtSifraNajave.Text);

            var files = Directory.GetFiles(@"\\192.168.1.6\Saobracaj\" + txtSifraNajave.Text, "*.*", SearchOption.AllDirectories);

            List<string> imageFiles = new List<string>();
            foreach (string filename in files)
            {
                if (Regex.IsMatch(filename, @".jpg|.png|.gif$"))
                    imageFiles.Add(filename);
            }
            string[] array = imageFiles.ToArray();
            ImagesToPdf(array, @"\\192.168.1.6\Saobracaj\" + txtSifraNajave.Text + @"\\IzSlika");

            CreateMergedPDF(@"\\192.168.1.6\Saobracaj\" + txtSifraNajave.Text + @"\Izlaz\Objedinjen.pdf", @"\\192.168.1.6\Saobracaj\" + txtSifraNajave.Text);
            txtObjedinjen.Text = @"\\192.168.1.6\Saobracaj\" + txtSifraNajave.Text + @"\Izlaz\Objedinjen.pdf";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            txtObjedinjen.Text = txtObjedinjen.Text.Replace("192.168.1.6", "WSS");
            System.Diagnostics.Process.Start(txtObjedinjen.Text);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}
