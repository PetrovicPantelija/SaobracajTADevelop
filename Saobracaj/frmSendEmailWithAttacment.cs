using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Net.Mail; 

namespace Saobracaj
{
    public partial class frmSendEmailWithAttacment : Form
    {
       // ArrayList alAttachments;
        MailMessage mailMessage;

        public frmSendEmailWithAttacment()
        {
            InitializeComponent();
        }

        private void frmSendEmailWithAttacment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();

            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    txtAttacment.Text = ofdlg.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTo.Text != null && txtTema.Text != null)
                {
                    mailMessage = new MailMessage(txtFrom.Text, txtTo.Text);

                    mailMessage.Subject = txtTema.Text;
                    mailMessage.Body = txtBody.Text;
                    mailMessage.IsBodyHtml = true;

                    /* Set the SMTP server and send the email with attachment */

                    SmtpClient smtpClient = new SmtpClient();

                    // smtpClient.Host = emailServerInfo.MailServerIP;
                    //this will be the host in case of gamil and it varies from the service provider

                    smtpClient.Host = "mail.kprevoz.co.rs";
                    //smtpClient.Port = Convert.ToInt32(emailServerInfo.MailServerPortNumber);
                    //this will be the port in case of gamil for dotnet and it varies from the service provider

                    smtpClient.Port = 25;
                    smtpClient.UseDefaultCredentials = true;

                    //smtpClient.Credentials = new System.Net.NetworkCredential(emailServerInfo.MailServerUserName, emailServerInfo.MailServerPassword);
                    smtpClient.Credentials = new NetworkCredential("pantelija.petrovic@kprevoz.co.rs", "pele1616");

                    //Attachment
                    Attachment attachment = new Attachment(txtAttacment.Text);
                    if (attachment != null)
                    {
                        mailMessage.Attachments.Add(attachment);
                    }


                    //this will be the true in case of gamil and it varies from the service provider
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);
                }

                string msg = "Message Send Successfully:";
                msg += "\n To :" + txtTo.Text;

                MessageBox.Show(msg.ToString());

                /* clear the controls */
                txtTo.Text = string.Empty;
                txtTema.Text = string.Empty;
                txtBody.Text = string.Empty;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
