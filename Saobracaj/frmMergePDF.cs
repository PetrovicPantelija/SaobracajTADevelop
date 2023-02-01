using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;
using System.Text.RegularExpressions;

using System.Drawing.Imaging;


namespace Saobracaj
{
    public partial class frmMergePDF : Form
    {
        public frmMergePDF()
        {
            InitializeComponent();
        }

        static void ConvertJPGToPDF()
        {
            Document document = new Document();
            using (var stream = new FileStream("test.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                using (var imageStream = new FileStream("test.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = iTextSharp.text.Image.GetInstance(imageStream);
                    document.Add(image);
                }
                document.Close();
            }
        }

        static void CreateMergedPDF(string targetPDF, string sourceDir)
        {
            using (FileStream stream = new FileStream(targetPDF, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4);
                PdfCopy pdf = new PdfCopy(pdfDoc, stream);
                pdfDoc.Open();
                var files = Directory.GetFiles(sourceDir);
                Console.WriteLine("Merging files count: " + files.Length);
                int i = 1;
                foreach (string file in files)
                {
                   // string path = "C:\\stagelist.txt";

                    // string extension = Path.GetExtension(path);
                    // string filename = Path.GetFileName(path);
                    // string filenameNoExtension = Path.GetFileNameWithoutExtension(path);
                    // string root = Path.GetPathRoot(path);
                    // Console.WriteLine(i + ". Adding: " + file);
                    var filePath = file;
                    string filenameNoExtension = Path.GetFileNameWithoutExtension(filePath);
                    //var ext = filePath.Substring(filePath.lastIndexOf('.') + 1).toLowerCase();
                    string extension = Path.GetExtension(filePath);
                    if (extension == ".pdf")
                    { 
                        pdf.AddDocument(new PdfReader(file)); 
                    }
                    if (extension == ".JPG")
                    {
                        /*
                        string imagePath = sourceDir + "\\s1.jpg";
                        // string imagePath = Server.MapPath("Images\\demo.PNG") + "";
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                        image.Alignment = Element.ALIGN_CENTER;
                        // set width and height
                        image.ScaleToFit(180f, 250f);

                        // adding image to document
                        pdfDoc.Add(image);
                         * */
                    }
                    i++;
                }
                pdfDoc.Close();
               // if (pdfDoc != null)
               //     pdfDoc.Close();

                Console.WriteLine("SpeedPASS PDF merge complete.");
            }
        }

        public void InsertImage(string targetPDF, string sourceDir)
        {
            // create filestream object
            FileStream fs = new FileStream(targetPDF, FileMode.Append);
            // create document object
            Document doc = new Document();
            // create PdfWriter instance which will write at file filestream
            PdfWriter.GetInstance(doc, fs);
            // opening the dociment
            doc.Open();
            // creating paragraph object
            Paragraph para = new Paragraph("Insert an image into pdf using C#.");
            para.Alignment = Element.ALIGN_CENTER;
            // adding pargraph to document
            ///doc.Add(para);

            // setting image path
            string imagePath =   sourceDir + "\\s1.jpg";
            // string imagePath = Server.MapPath("Images\\demo.PNG") + "";
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
            image.Alignment = Element.ALIGN_CENTER;
            // set width and height
            image.ScaleToFit(180f, 250f);

            // adding image to document
            doc.Add(image);
            // closing the document
            doc.Close();
        }

        public void InsertImage2(string targetPDF, string sourceDir, string targetpdf2, string imagePath)
        {
           
            var pdfPath = targetPDF ;

            //Panta dodao
             var pdfReader = new PdfReader(targetPDF);
             var ms = new MemoryStream();

             var stamp = new PdfStamper(pdfReader, ms);
       
            
                var size = pdfReader.GetPageSize(1);
                var page = pdfReader.NumberOfPages + 1;
                stamp.InsertPage(page, pdfReader.GetPageSize(1));

                        //load pdf file
                        var pdfBytes = File.ReadAllBytes(pdfPath);
                        var oldFile = new PdfReader(pdfBytes);

                        //load image
                        var preImage = System.Drawing.Image.FromFile(imagePath);
                        var image = iTextSharp.text.Image.GetInstance(preImage, ImageFormat.Jpeg);
                        preImage.Dispose();

                        //optional: if image is wider than the page, scale down the image to fit the page
                        var sizeWithRotation = oldFile.GetPageSizeWithRotation(1);
                        if (image.Width > sizeWithRotation.Width)
                            image.ScalePercent(sizeWithRotation.Width / image.Width * 100);

                        image.SetAbsolutePosition(0, sizeWithRotation.Height - image.ScaledHeight);

                        //in production, I use MemoryStream
                        //I put FileStream here to test the code in console application
                        using (var newFileStream = new FileStream(targetpdf2, FileMode.Create))
                        {
                            //setup PdfStamper
                            var stamper = new PdfStamper(oldFile, newFileStream);
               
                            //iterate through the pages in the original file
                            for (var i = 1; i <= oldFile.NumberOfPages; i++)
                            {
                                //get canvas for current page
                 
                            }
                            var canvas = stamper.GetOverContent(oldFile.NumberOfPages);
                            //add image with pre-set position and size
                             canvas.AddImage(image);
                            //stamper.AddImage(image);

                            stamper.Close();
                        }
                    }

        public static byte[] InsertImage3(string targetPDF, List<string> images)
        {
            var pdfReader = new PdfReader(targetPDF);
using (var ms = new MemoryStream())
{
        using (var stamp = new PdfStamper(pdfReader, ms))
        {
            foreach (var image in images)
            {

                var size = pdfReader.GetPageSize(1);
                var page = pdfReader.NumberOfPages + 1;
                stamp.InsertPage(page, pdfReader.GetPageSize(1));
                iTextSharp.text.Image imageV = iTextSharp.text.Image.GetInstance(image);
                ImageFormat format = ImageFormat.Jpeg;

                var pdfImage = imageV;
                pdfImage.Alignment = Element.ALIGN_CENTER;
                pdfImage.SetAbsolutePosition(0, size.Height - pdfImage.Height);
                pdfImage.ScaleToFit(size.Width, size.Height);
                stamp.GetOverContent(page).AddImage(pdfImage);
            }
        }
        ms.Flush();
        return ms.GetBuffer();
}
        
        
        
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateMergedPDF(@"D:\PDFIzlaz\Test.pdf", @"D:\PDFUlaz");

            var files = Directory.GetFiles("D:\\PDFUlaz", "*.*", SearchOption.AllDirectories);

            List<string> imageFiles = new List<string>();
            foreach (string filename in files)
            {
                if (Regex.IsMatch(filename, @".jpg|.png|.gif$"))
                    imageFiles.Add(filename);
            }
            string[] array = imageFiles.ToArray();
            ImagesToPdf(array, @"D:\PDFIzlaz\");
           
           

            CreateMergedPDF(@"D:\PDFIzlaz\Test.pdf", @"D:\PDFUlaz");
          
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

                    File.WriteAllBytes( slika.ToString() + ".pdf", ms.ToArray());
                }
            }
            /*
            using (var srcImage = new Bitmap(imagepaths[0].ToString()))
            {
                pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
            }
             * */
/*
            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(imagepaths[0].ToString());
                document.Add(image);
                document.Close();

                File.WriteAllBytes(pdfpath + image.ToString() +"cheque.pdf", ms.ToArray());
            }
 * */
        }
       
    }
}
