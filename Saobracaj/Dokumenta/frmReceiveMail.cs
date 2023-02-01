using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPop.Pop3;
using OpenPop.Common;
using OpenPop.Mime;


using System.Configuration;

using System.Data.OleDb;
using System.Data.SqlClient;


namespace Saobracaj.Dokumenta
{
    public partial class frmReceiveMail : Form
    {
       InsertReceiveMail insertrm = new InsertReceiveMail();
           
        public frmReceiveMail()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new MailRepository();
            client.Connect(hostname: "mail.kprevoz.co.rs", username: "pantelija.petrovic@kprevoz.co.rs", password: "pele1616", port: 110, isUseSsl: false);

            var allMail = client.GetMail();
       
            int pom = 0;
            foreach (var mail in allMail)
            {
              
                var subject = mail.Message.Headers.Subject;
                var to = string.Join(",", mail.Message.Headers.To.Select(m => m.Address));
                var from = mail.Message.Headers.From.Address;
                var body = "";
                var datum = mail.Message.Headers.Received;
                var id = mail.Message.Headers.MessageId;
                var datum3 = mail.Message.Headers.Date;
                var datum4 = mail.Message.Headers.DateSent;

               // MessageBox.Show("Email Subject: " + subject + " Sent To:  " + to + " Sent From: " + from);
                OpenPop.Mime.MessagePart plainText = mail.Message.FindFirstPlainTextVersion();
                StringBuilder builder = new StringBuilder();
                if (plainText != null)
                {
                    // We found some plaintext!
                   // body = builder.Append(plainText.GetBodyAsText());
                    body = plainText.GetBodyAsText();
                }
                else
                {
                    // Might include a part holding html instead
                    OpenPop.Mime.MessagePart html = mail.Message.FindFirstHtmlVersion();
                    if (html != null)
                    {
                        // We found some html!
                        //mail.Message.Append(html.GetBodyAsText());
                    }
                }




                //this.dataGridView1.Rows.Add("subject", "to", "from");
                //this.dataGridView1.Rows.Insert(pom, id, subject, from, to, datum3, datum4, body);
               
                insertrm.InsRecMail(id.ToString(), subject.ToString(), from.ToString(), to.ToString(), datum3.ToString(), datum4.ToString(), body.ToString(), "Novi");
                pom = pom + 1;
               // Console.WriteLine("Email Subject: {0}", subject);
               // Console.WriteLine("Sent To: {0}", to);
               // Console.WriteLine("Sent From: {0}", from);

               //P client.Delete(mail.MessageNumber);
            }
            /*P
            client.DeleteAll();

             * 
         
            var mailByTo = client.GetMail(fromAddress: "emailsFromFriendOne@outlook.com");

            foreach (var mail in mailByTo)
            {
                client.Delete(mail.MessageNumber);
            }

            var mailByToAndFrom = client.GetMail(fromAddress: "emailsFromFriendOne@outlook.com", toAddress: "emailsOnlyToThisAddress@outlook.com");

            foreach (var mail in mailByToAndFrom)
            {
                client.Delete(mail.MessageNumber);
            }
            */
           // var mailWithAttachments = client.GetMail(fromAddress: "pantelija.petrovic@kprevoz.co.rs");
            var mailWithAttachments = client.GetMail();

            foreach (var mail in mailWithAttachments)
            {
                var attachments = client.GetAttachments(mail.Message);

                if (attachments.Any())
                {
                    foreach (var attachment in attachments)
                    {
                       // MessageBox.Show("File Location:    " + attachment);
                       // Console.WriteLine("File Location: {0}", attachment);
                    }
                }
                else
                {
                    Console.WriteLine("Email has no attachments, if attachments are required, make sure to not delete this email");
                }
               // client.Delete(mail.MessageNumber);
            }

          //  Console.WriteLine("Press any key to exit...");
            RefreshDataGrid();
          //  Console.ReadLine();
        }
        private void RefreshDataGrid()
        {
          
            var select = "select * from ReceiveMail";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // string statusRid = row.Cells[11].Value.ToString();
                string StatusNajave = row.Cells[7].Value.ToString();
                if (StatusNajave == "Novi")
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                    row.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                }
                else if ((StatusNajave == "Odgovoren"))
                {
                    row.DefaultCellStyle.BackColor = Color.GreenYellow;
                    row.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                }


            }

        }

        /*
         *  try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
         */

        private void button2_Click(object sender, EventArgs e)
        {
            
            insertrm.UpdRecMail(txtID.Text, cboStatus.Text);
            RefreshDataGrid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtID.Text = row.Cells[0].Value.ToString();
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
