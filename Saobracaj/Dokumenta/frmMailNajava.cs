using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Dokumenta
{
    public partial class frmMailNajava : Form
    {
        string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        int PaSifra;
        MailMessage mailMessage;
        public frmMailNajava()
        {
            InitializeComponent();
            FillGV();
            FillCheck();
            FillCombo();
        }
        private void FillGV()
        {
            var query = "SELECT distinct Partnerji.PaSifra,RTrim(PaNaziv) as Partner,Partnerji.Posiljalac,Najava.ID,Otpravna,RTrim(stanice.Opis)," +
                "Uputna,RTrim(stanice1.Opis),Najava.Granicna,RTrim(stanice2.Opis),Najava.Status,BrojKola,PredvidjenoPrimanje,PredvidjenaPredaja,Zadatak " +
                "FROM Partnerji " +
                "Inner join partnerjiKontOseba on Partnerji.PaSifra = partnerjiKontOseba.PaKOSifra " +
                "inner join Najava on Partnerji.PaSifra = Najava.Posiljalac " +
                "inner join stanice on Najava.Otpravna = stanice.ID " +
                "inner join stanice as stanice1 on najava.Uputna = stanice1.ID " +
                "inner join stanice as stanice2 on Najava.Granicna = stanice2.ID " +
                "WHERE Najava.Faktura = '' and Partnerji.Posiljalac = 1 and partnerjiKontOseba.PaKOTip = 1 and(status = 1 or status = 2 or status = 4 or status = 5) " +
                "order by PaSifra";

            SqlConnection conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(query, conn);
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

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Partner";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Visible = false; //posiljalac
            dataGridView1.Columns[3].HeaderText = "Najava";
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Visible = false; //otpravna
            dataGridView1.Columns[5].HeaderText = "Otpravna";
            dataGridView1.Columns[5].Width = 110;
            dataGridView1.Columns[6].Visible = false; //uputna
            dataGridView1.Columns[7].HeaderText = "Uputna";
            dataGridView1.Columns[7].Width = 110;
            dataGridView1.Columns[8].Visible = false; //granicna
            dataGridView1.Columns[9].HeaderText = "Trenutna";
            dataGridView1.Columns[9].Width = 110;
            dataGridView1.Columns[10].HeaderText = "Status";
            dataGridView1.Columns[10].Width = 50;
            dataGridView1.Columns[11].Width = 60;
            dataGridView1.Columns[14].Width = 190;
        }
        private void FillCombo()
        {
            var query = "Select distinct Status From Najava where status <>0 and status <>3 and status <>6 and status <>7 and status <>8 and status <>9";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Status";
            comboBox1.ValueMember = "Status";
        }
        private void FillCheck()
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            string query = "SELECT distinct PaSifra,RTrim(PaNaziv) as Partner " +
                "FROM Partnerji " +
                "Inner join partnerjiKontOseba on Partnerji.PaSifra = partnerjiKontOseba.PaKOSifra " +
                "inner join Najava on Partnerji.PaSifra = Najava.Posiljalac " +
                "inner join stanice on Najava.Otpravna = stanice.ID " +
                "inner join stanice as stanice1 on najava.Uputna = stanice1.ID " +
                "inner join stanice as stanice2 on Najava.Granicna = stanice2.ID " +
                "WHERE Najava.Faktura = '' and Partnerji.Posiljalac = 1 and partnerjiKontOseba.PaKOTip = 1 and(status = 1 or status = 2 or status = 4 or status = 5)";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            //cbList_Partneri.DataSource = ds.Tables[0];
            cbList_Partneri.DataSource = ds.Tables[0];
            cbList_Partneri.DisplayMember = "Partner";
            cbList_Partneri.ValueMember = "PaSifra";
        }
        private void frmMailNajava_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Left);
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            var query = "SELECT distinct Partnerji.PaSifra,RTrim(PaNaziv) as Partner,Partnerji.Posiljalac,Najava.ID,Otpravna,RTrim(stanice.Opis), " +
                "Uputna,RTrim(stanice1.Opis),Najava.Granicna,RTrim(stanice2.Opis),Najava.Status,BrojKola,PredvidjenoPrimanje,PredvidjenaPredaja,Zadatak " +
                "FROM Partnerji " +
                "Inner join partnerjiKontOseba on Partnerji.PaSifra = partnerjiKontOseba.PaKOSifra " +
                "inner join Najava on Partnerji.PaSifra = Najava.Posiljalac " +
                "inner join stanice on Najava.Otpravna = stanice.ID " +
                "inner join stanice as stanice1 on najava.Uputna = stanice1.ID " +
                "inner join stanice as stanice2 on Najava.Granicna = stanice2.ID " +
                "WHERE Najava.Faktura = '' and Partnerji.Posiljalac = 1 and partnerjiKontOseba.PaKOTip = 1 and status= "+Convert.ToInt32(comboBox1.SelectedValue) +
                "order by PaSifra";

            SqlConnection conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(query, conn);
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

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Partner";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Visible = false; //posiljalac
            dataGridView1.Columns[3].HeaderText = "Najava";
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Visible = false; //otpravna
            dataGridView1.Columns[5].HeaderText = "Otpravna";
            dataGridView1.Columns[5].Width = 110;
            dataGridView1.Columns[6].Visible = false; //uputna
            dataGridView1.Columns[7].HeaderText = "Uputna";
            dataGridView1.Columns[7].Width = 110;
            dataGridView1.Columns[8].Visible = false; //granicna
            dataGridView1.Columns[9].HeaderText = "Trenutna";
            dataGridView1.Columns[9].Width = 110;
            dataGridView1.Columns[10].HeaderText = "Status";
            dataGridView1.Columns[10].Width = 50;
            dataGridView1.Columns[11].Width = 60;
            dataGridView1.Columns[14].Width = 190;
        }

        private void btn_Svi_Click(object sender, EventArgs e)
        {
            FillGV();
        }

        private void btn_PosaljiSvi_Click(object sender, EventArgs e)
        {
            for(int i= 0; i < cbList_Partneri.Items.Count; i++)
            {
                if (cbList_Partneri.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    cbList_Partneri.SetItemChecked(i, true);
                    cbList_Partneri.SetSelected(i,true);
                    PaSifra = Convert.ToInt32(cbList_Partneri.SelectedValue);

                    string query = "Select PaKOMail From PartnerjiKontOseba Where PaKoTip=1 and PaKOSifra= "+PaSifra;
                    SqlConnection conn = new SqlConnection(connect);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    int count = 0;
                    string nizMail = "";
                    while (dr.Read())
                    {
                        if (count == 0)
                        {
                            nizMail = dr["PaKoMail"].ToString();
                            count++;
                        }
                        else
                        {
                            nizMail = nizMail + "," + dr["PaKoMail"].ToString();
                            count++;
                        }

                    }
                    if (nizMail == "")
                    {
                        MessageBox.Show("Za ovog partnera nije uneta mail adresa");
                        return;
                    }
                    conn.Close();

                    
                    try
                    {
                        string cuvaj = "disp@kprevoz.co.rs";
                        mailMessage = new MailMessage("disp@kprevoz.co.rs", "stefan.obradovic@kprevoz.co.rs,milos.cpajak@kprevoz.co.rs,pantelija.petrovic@kprevoz.co.rs");
                        mailMessage.CC.Add(cuvaj);
                        mailMessage.Subject = "Status najave";

                        var select = "SELECT distinct Partnerji.PaSifra,RTrim(PaNaziv) as Partner,Partnerji.Posiljalac,Najava.ID as Najava,Otpravna," +
                            "RTrim(stanice.Opis) as [OtpravnaStanica],Uputna,RTrim(stanice1.Opis) as [UputnaStanica],Najava.Granicna," +
                            "RTrim(stanice2.Opis) as [TrenutnaStanica],Najava.Status,BrojKola,PredvidjenoPrimanje,PredvidjenaPredaja,Zadatak " +
                            "FROM Partnerji " +
                            "Inner join partnerjiKontOseba on Partnerji.PaSifra = partnerjiKontOseba.PaKOSifra " +
                            "inner join Najava on Partnerji.PaSifra = Najava.Posiljalac " +
                            "inner join stanice on Najava.Otpravna = stanice.ID " +
                            "inner join stanice as stanice1 on najava.Uputna = stanice1.ID " +
                            "inner join stanice as stanice2 on Najava.Granicna = stanice2.ID " +
                            "WHERE Najava.Faktura = '' and Partnerji.Posiljalac = 1 and partnerjiKontOseba.PaKOTip = 1 and" +
                            "(status = 1 or status = 2 or status = 4 or status = 5) and PaSifra = "+PaSifra+" " +
                            "order by Najava.ID";
                        var dataAdapter = new SqlDataAdapter(select, conn);

                        var commandBuilder = new SqlCommandBuilder(dataAdapter);
                        var ds = new DataSet();
                        dataAdapter.Fill(ds);
                        string body = "";

                        body = body + "STATUS NAJAVE: <br/><br/>";
                        foreach (DataRow myRow in ds.Tables[0].Rows)
                        {
                            body = body + "Najava broj: " + myRow["Najava"].ToString() + "<br/>";
                            body = body + "IZ: " + myRow["OtpravnaStanica"].ToString() + "<br/>";
                            body = body + "DO: " + myRow["UputnaStanica"].ToString() + "<br/>";
                            body = body + "Status: " + myRow["Status"].ToString() + "<br/>";
                            body = body + "Trenutna stanica: " + myRow["TrenutnaStanica"].ToString() + "<br/>";
                            body = body + "Broj kola: " + myRow["BrojKola"].ToString() + "<br/>";
                            int status = Convert.ToInt32(myRow["Status"]);
                            if (cb_Eta.Checked == false && cb_pPrimanje.Checked == false)
                            {
                                if (status == 1 || status == 2)
                                {
                                    body = body + "ETA: " + myRow["PredvidjenoPrimanje"].ToString() + "<br/>";
                                }
                                else
                                {
                                    body = body + "Predviđeno primanje: " + myRow["PredvidjenoPrimanje"].ToString() + "<br/>";
                                }
                            }
                            if (cb_Eta.Checked == true)
                            {
                                body = body + "ETA: " + myRow["PredvidjenoPrimanje"].ToString() + "<br/>";
                            }
                            if (cb_pPrimanje.Checked == true)
                            {
                                body = body + "Predviđeno primanje: " + myRow["PredvidjenoPrimanje"].ToString() + "<br/>";
                            }
                            body = body + "Zadatak: " + myRow["Zadatak"].ToString() + "<br/><br/>";
                            body = body + "Salje na mail (dok je u fazi testiranja sluzi za proveru mail adresa): " + nizMail + "<br/><br/>";
                        }
                        body = body + "Srdačan pozdrav, <br/>" + "Dispečerska služba, RTC LUKA LEGET";
                        
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        SmtpClient smtpClient = new SmtpClient();
                        smtpClient.Host = "mail.kprevoz.co.rs";

                        smtpClient.Port = 25;
                        smtpClient.UseDefaultCredentials = true;
                        smtpClient.Credentials = new NetworkCredential("disp@kprevoz.co.rs", "pele1122.disp");

                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mailMessage);
                        MessageBox.Show("Uspesno poslato");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void btn_Posalji_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbList_Partneri.Items.Count; i++)
            {
                if (cbList_Partneri.GetItemCheckState(i) == CheckState.Checked)
                {
                    cbList_Partneri.SetSelected(i, true);
                    PaSifra = Convert.ToInt32(cbList_Partneri.SelectedValue);

                    string query = "Select PaKOMail From PartnerjiKontOseba Where PaKoTip=1 and PaKOSifra= " + PaSifra;
                    SqlConnection conn = new SqlConnection(connect);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    int count = 0;
                    string nizMail = "";
                    while (dr.Read())
                    {
                        if (count == 0)
                        {
                            nizMail = dr["PaKoMail"].ToString();
                            count++;
                        }
                        else
                        {
                            nizMail = nizMail + "," + dr["PaKoMail"].ToString();
                            count++;
                        }

                    }
                    if (nizMail == "")
                    {
                        MessageBox.Show("Za ovog partnera nije uneta mail adresa");
                    }
                    conn.Close();
                    MessageBox.Show(nizMail);

                    try
                    {
                        string cuvaj = "disp@kprevoz.co.rs";
                        mailMessage = new MailMessage("disp@kprevoz.co.rs", "stefan.obradovic@kprevoz.co.rs,milos.cpajak@kprevoz.co.rs,pantelija.petrovic@kprevoz.co.rs");
                        mailMessage.CC.Add(cuvaj);
                        mailMessage.Subject = "Status najave";

                        var select = "SELECT distinct Partnerji.PaSifra,RTrim(PaNaziv) as Partner,Partnerji.Posiljalac,Najava.ID as Najava,Otpravna," +
                            "RTrim(stanice.Opis) as [OtpravnaStanica],Uputna,RTrim(stanice1.Opis) as [UputnaStanica],Najava.Granicna," +
                            "RTrim(stanice2.Opis) as [TrenutnaStanica],Najava.Status,BrojKola,PredvidjenoPrimanje,PredvidjenaPredaja,Zadatak " +
                            "FROM Partnerji " +
                            "Inner join partnerjiKontOseba on Partnerji.PaSifra = partnerjiKontOseba.PaKOSifra " +
                            "inner join Najava on Partnerji.PaSifra = Najava.Posiljalac " +
                            "inner join stanice on Najava.Otpravna = stanice.ID " +
                            "inner join stanice as stanice1 on najava.Uputna = stanice1.ID " +
                            "inner join stanice as stanice2 on Najava.Granicna = stanice2.ID " +
                            "WHERE Najava.Faktura = '' and Partnerji.Posiljalac = 1 and partnerjiKontOseba.PaKOTip = 1 and" +
                            "(status = 1 or status = 2 or status = 4 or status = 5) and PaSifra = " + PaSifra + " " +
                            "order by Najava.ID";
                        var dataAdapter = new SqlDataAdapter(select, conn);

                        var commandBuilder = new SqlCommandBuilder(dataAdapter);
                        var ds = new DataSet();
                        dataAdapter.Fill(ds);
                        string body = "";

                        body = body + "                             STATUS NAJAVE \n\n<br/><br/>";
                        foreach (DataRow myRow in ds.Tables[0].Rows)
                        {
                            body = body + "Najava broj: " + myRow["Najava"].ToString() + "\n<br/>";
                            body = body + "IZ: " + myRow["OtpravnaStanica"].ToString() + "\n<br/>";
                            body = body + "DO: " + myRow["UputnaStanica"].ToString() + "\n<br/>";
                            body = body + "Status: " + myRow["Status"].ToString() + "\n<br/>";
                            body = body + "Trenutna stanica: " + myRow["TrenutnaStanica"].ToString() + "\n<br/>";
                            body = body + "Broj kola: " + myRow["BrojKola"].ToString() + "\n<br/>";
                            int status = Convert.ToInt32(myRow["Status"]);
                            if (cb_Eta.Checked == false && cb_pPrimanje.Checked == false)
                            {
                                if (status == 1 || status == 2)
                                {
                                    body = body + "ETA: " + myRow["PredvidjenoPrimanje"].ToString() + "\n<br/>";
                                }
                                else
                                {
                                    body = body + "Predviđeno primanje: " + myRow["PredvidjenoPrimanje"].ToString() + "\n<br/>";
                                }
                            }
                            if (cb_Eta.Checked == true)
                            {
                                body = body + "ETA: " + myRow["PredvidjenoPrimanje"].ToString() + "\n<br/>";
                            }
                            if (cb_pPrimanje.Checked == true)
                            {
                                body = body + "Predviđeno primanje: " + myRow["PredvidjenoPrimanje"].ToString() + "\n<br/>";
                            }
                            body = body + "Zadatak: " + myRow["Zadatak"].ToString() + "\n<br/>";
                            body = body + "Salje na mail (dok je u fazi testiranja sluzi za proveru mail adresa): " + nizMail + "<br/><br/>";
                        }
                        body = body + "<br/>Srdačan pozdrav, \n<br/>" + "Dispečerska služba, RTC LUKA LEGET";
                        
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        SmtpClient smtpClient = new SmtpClient();
                        smtpClient.Host = "mail.kprevoz.co.rs";

                        smtpClient.Port = 25;
                        smtpClient.UseDefaultCredentials = true;
                        smtpClient.Credentials = new NetworkCredential("disp@kprevoz.co.rs", "pele1122.disp");

                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mailMessage);
                        MessageBox.Show(body);
                        MessageBox.Show("Uspesno poslato");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    }
}
