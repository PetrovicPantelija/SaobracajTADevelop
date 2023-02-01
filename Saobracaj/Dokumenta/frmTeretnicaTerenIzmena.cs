using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Dokumenta
{
    public partial class frmTeretnicaTerenIzmena : Form
    {
        int Teretnica;
        int count1;
        int count2;
        string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        public frmTeretnicaTerenIzmena()
        {
            InitializeComponent();
        }
        public frmTeretnicaTerenIzmena(string IdTeretnice)
        {
            InitializeComponent();
            Teretnica = Convert.ToInt32(IdTeretnice);
            FillGV1();
            FillGV2();
        }
        private void FillGV2()
        {
            var select = "Select distinct RedniBroj,IdPopisaneStavkeTeretnice,BrojPopisaneTeretnice,RTrim(BrojKola) as BrojKola," +
                "Duzina,Tara,P,RucKoc,PopisTeretnica.ZaposleniId,RTrim(Korisnici.Korisnik) as Zaposleni " +
                "From PopisTeretnicaStavke,PopisTeretnica,Korisnici " +
                "Where PopisTeretnicaStavke.BrojPopisaneTeretnice=PopisTeretnica.TeretnicaId and Korisnici.DeSifra=PopisTeretnica.ZaposleniId " +
                "and BrojPopisaneTeretnice= "+Teretnica+"order by RedniBroj";
            SqlConnection conn = new SqlConnection(connect);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView2.ReadOnly = false;
            dataGridView2.DataSource = ds.Tables[0];

            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView2.Columns[1].Width = 120;
            dataGridView2.Columns[2].Width = 120;
        }
        private void FillGV1()
        {
            var select = "SELECT TeretnicaStavke.RB,TeretnicaStavke.ID,TeretnicaStavke.IDNajave, RTrim(stanice.Opis) as Uvrstena, Rtrim(stanice_1.Opis) AS Otkacena, RTrim(TeretnicaStavke.BrojKola) as BrojKola, TeretnicaStavke.Serija,TeretnicaStavke.BrojOsovina, TeretnicaStavke.Duzina, TeretnicaStavke.Tara, TeretnicaStavke.Neto, TeretnicaStavke.G,TeretnicaStavke.P, TeretnicaStavke.R,TeretnicaStavke.RR, TeretnicaStavke.VRNP, RTrim(stanice_3.Opis) AS Otpravna, RTrim(stanice_2.Opis) AS Uputna, TeretnicaStavke.Reon, Rtrim(TeretnicaStavke.Primedba)as Primedba,TeretnicaStavke.RucKoc,  Rtrim(stanice_5.Opis) as Izvozna, RTrim(stanice_4.Opis) as Uvozna, RID, Dokument"
                          + " FROM         TeretnicaStavke" +
                          " INNER JOIN "
                          + " stanice ON TeretnicaStavke.Uvrstena = stanice.ID INNER JOIN "
                          + " stanice AS stanice_1 ON TeretnicaStavke.Otkacena = stanice_1.ID INNER JOIN "
                          + " stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN "
                          + " stanice AS stanice_2 ON TeretnicaStavke.Uputna = stanice_2.ID INNER JOIN "
                           + " stanice AS stanice_4 ON TeretnicaStavke.Uvozna = stanice_4.ID INNER JOIN "
                           + " stanice AS stanice_5 ON TeretnicaStavke.Izvozna = stanice_5.ID"
                          + " where BrojTEretnice = " + Teretnica + " order by RB";

            SqlConnection myConnection = new SqlConnection(connect);
            var conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(select, conn);

            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = false;
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

            dataGridView1.Columns[0].Width = 30; //RB
            dataGridView1.Columns[1].Width = 50; //ID
            dataGridView1.Columns[2].Width = 50; //IDNajave
            dataGridView1.Columns[3].Width = 50; //Uvrstena
            dataGridView1.Columns[4].Width = 50; //Otkacena
            dataGridView1.Columns[5].Width = 90; //BrKola
            dataGridView1.Columns[6].Width = 30; //Serija
            dataGridView1.Columns[7].Width = 40; //BrojOS
            dataGridView1.Columns[8].Width = 50; //Duzina
            dataGridView1.Columns[9].Width = 50; //Tara
            dataGridView1.Columns[10].Width = 50; //Neto
            dataGridView1.Columns[11].Width = 30; //G
            dataGridView1.Columns[12].Width = 40; //P
            dataGridView1.Columns[13].Width = 30; //R
            dataGridView1.Columns[14].Width = 30; //PR
            dataGridView1.Columns[15].Width = 30; //VRN
            dataGridView1.Columns[16].Width = 70; //Otpravna
            dataGridView1.Columns[17].Width = 70; //Uputna
            dataGridView1.Columns[18].Width = 70; //Reon
            dataGridView1.Columns[19].Width = 70; //Primedba
            dataGridView1.Columns[20].Width = 70; //RucKoc
            dataGridView1.Columns[21].Width = 70; //Izvozna
            dataGridView1.Columns[22].Width = 70; //Uvozna
            dataGridView1.Columns[23].Width = 70; //RID
            dataGridView1.Columns[24].Width = 70; //Dokument
        }
        private void frmTeretnicaTerenIzmena_Load(object sender, EventArgs e)
        {

        }
        private void Proveri()
        {
            int row1 = dataGridView1.Rows.Count;
            int row2 = dataGridView2.Rows.Count;
            for (int i = 0; i < row1 - 1; i++)
            {
                bool pom = false;
                for (int j = 0; j < row2 - 1; j++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == Convert.ToInt32(dataGridView2.Rows[j].Cells[0].Value))
                    {
                        pom = true;
                        dataGridView2.Rows[j].Cells[0].Style.BackColor = Color.Blue;
                    }
                    if (pom == false)
                    {
                        dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.Red;
                    }
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) == Convert.ToInt32(dataGridView2.Rows[j].Cells[1].Value))
                    {
                        pom = true;
                        dataGridView2.Rows[j].Cells[1].Style.BackColor = Color.Blue;
                    }
                    if (pom == false)
                    {
                        dataGridView2.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    }
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString().TrimEnd().Equals(dataGridView2.Rows[j].Cells[3].Value.ToString().TrimEnd()))
                    {
                        pom = true;
                        dataGridView2.Rows[j].Cells[3].Style.BackColor = Color.Blue;
                    }
                    if (pom == false)
                    {
                        dataGridView2.Rows[i].Cells[3].Style.BackColor = Color.Red;
                    }
                    if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value) == Convert.ToDecimal(dataGridView2.Rows[j].Cells[4].Value))
                    {
                        pom = true;
                        dataGridView2.Rows[j].Cells[4].Style.BackColor = Color.Blue;
                    }
                    if (pom == false)
                    {
                        dataGridView2.Rows[i].Cells[4].Style.BackColor = Color.Red;
                    }
                    if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value) == Convert.ToDecimal(dataGridView2.Rows[j].Cells[5].Value))
                    {
                        pom = true;
                        dataGridView2.Rows[j].Cells[5].Style.BackColor = Color.Blue;
                    }
                    if (pom == false)
                    {
                        dataGridView2.Rows[i].Cells[5].Style.BackColor = Color.Red;
                    }
                    if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[12].Value) == Convert.ToDecimal(dataGridView2.Rows[j].Cells[6].Value))
                    {
                        pom = true;
                        dataGridView2.Rows[j].Cells[6].Style.BackColor = Color.Blue;
                    }
                    if (pom == false)
                    {
                        dataGridView2.Rows[i].Cells[6].Style.BackColor = Color.Red;
                    }
                    if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[20].Value) == Convert.ToDecimal(dataGridView2.Rows[j].Cells[7].Value))
                    {
                        pom = true;
                        dataGridView2.Rows[j].Cells[7].Style.BackColor = Color.Blue;
                    }
                    if (pom == false)
                    {
                        dataGridView2.Rows[i].Cells[7].Style.BackColor = Color.Red;
                    }
                }
            }
        }
        private void btn_Provera_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                count2++;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                count1++;
            }
            if (count1 != count2)
            {
                MessageBox.Show("Broj popisanih stavki se ne poklapa sa brojem najavljenih stavki", "Informacije o popisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Proveri();  
        }
        public int otpravna;
        public int uputna;
        public int uvozna;
        public int izvozna;
        private void btn_Izmena_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da potvrdite izmene", "Potvrdi Izmene", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int row1 = dataGridView1.Rows.Count;
                int row2 = dataGridView2.Rows.Count;
                for (int i = 0; i < row1 - 1; i++)
                {
                    for (int j = 0; j < row2 - 1; j++)
                    {
                        int rb = Convert.ToInt32(dataGridView1.Rows[j].Cells[0].Value);
                        int brojTeretnice = Convert.ToInt32(dataGridView2.Rows[j].Cells[2].Value);
                        int idNajave=Convert.ToInt32(dataGridView1.Rows[j].Cells[2].Value);
                        string uvrstena=dataGridView1.Rows[j].Cells[3].Value.ToString();
                        if(uvrstena.Equals(""))
                        {
                            uvrstena = 1072.ToString().TrimEnd();
                        }
                        string otkacena= dataGridView1.Rows[j].Cells[4].Value.ToString();
                        if(otkacena.Equals(""))
                        {
                            otkacena = 1072.ToString().TrimEnd();
                        }
                        string brojKola=dataGridView2.Rows[j].Cells[3].Value.ToString().TrimEnd();
                        string serija=dataGridView1.Rows[j].Cells[6].Value.ToString().TrimEnd();
                        double brojOsovina=Convert.ToDouble(dataGridView1.Rows[j].Cells[7].Value);
                        double duzina=Convert.ToDouble(dataGridView2.Rows[j].Cells[4].Value);
                        double tara=Convert.ToDouble(dataGridView2.Rows[j].Cells[5].Value);
                        double neto=Convert.ToDouble(dataGridView1.Rows[j].Cells[10].Value);
                        double g=Convert.ToDouble(dataGridView1.Rows[j].Cells[11].Value);
                        double p=Convert.ToDouble(dataGridView2.Rows[j].Cells[6].Value);
                        double r=Convert.ToDouble(dataGridView1.Rows[j].Cells[13].Value);
                        double pr=Convert.ToDouble(dataGridView1.Rows[j].Cells[14].Value);
                        string vrnp=dataGridView1.Rows[j].Cells[15].Value.ToString().TrimEnd();

                        string ot=dataGridView1.Rows[j].Cells[16].Value.ToString().TrimEnd();
                        string queryOtpravna = "Select ID from Stanice Where Opis = " + "'" + ot + "'";
                        SqlConnection connOtpravna = new SqlConnection(connect);
                        connOtpravna.Open();
                        SqlCommand cmdOtpravna = new SqlCommand(queryOtpravna, connOtpravna);
                        SqlDataReader drOtpravna = cmdOtpravna.ExecuteReader();
                        while (drOtpravna.Read())
                        {
                            otpravna = Convert.ToInt32(drOtpravna["ID"].ToString());
                        }
                        connOtpravna.Close();

                        string up= dataGridView1.Rows[j].Cells[17].Value.ToString().TrimEnd();
                        string queryUputna = "Select ID from Stanice Where Opis = " + "'" + up + "'";
                        SqlConnection connUputna = new SqlConnection(connect);
                        connUputna.Open();
                        SqlCommand cmdUputna = new SqlCommand(queryUputna, connUputna);
                        SqlDataReader drUputna = cmdUputna.ExecuteReader();
                        while (drUputna.Read())
                        {
                            uputna = Convert.ToInt32(drUputna["ID"].ToString());
                        }
                        connUputna.Close();

                        string reon=dataGridView1.Rows[j].Cells[18].Value.ToString().TrimEnd();
                        string primedba = dataGridView1.Rows[j].Cells[19].Value.ToString().TrimEnd();
                        double rucKoc=Convert.ToDouble(dataGridView2.Rows[j].Cells[7].Value);

                        string uv = dataGridView1.Rows[j].Cells[22].Value.ToString().TrimEnd();
                        string queryUvozna = "Select ID from Stanice Where Opis = " + "'" + uv + "'";
                        SqlConnection connUvozna = new SqlConnection(connect);
                        connUvozna.Open();
                        SqlCommand cmdUvozna = new SqlCommand(queryUvozna, connUvozna);
                        SqlDataReader drUvozna = cmdUvozna.ExecuteReader();
                        while (drUvozna.Read())
                        {
                            uvozna = Convert.ToInt32(drUvozna["ID"].ToString());
                        }
                        connUvozna.Close();

                        string iz = dataGridView1.Rows[j].Cells[21].Value.ToString().TrimEnd();
                        string queryIzvozna = "Select ID from Stanice Where Opis = " + "'" + iz + "'";
                        SqlConnection connIzvozna = new SqlConnection(connect);
                        connIzvozna.Open();
                        SqlCommand cmdIzvozna = new SqlCommand(queryIzvozna, connIzvozna);
                        SqlDataReader drIzvozna = cmdIzvozna.ExecuteReader();
                        while (drIzvozna.Read())
                        {
                            izvozna = Convert.ToInt32(drIzvozna["ID"].ToString());
                        }
                        connIzvozna.Close();

                        string rid=dataGridView1.Rows[j].Cells[23].Value.ToString().TrimEnd();
                        string dokument=dataGridView1.Rows[j].Cells[24].Value.ToString().TrimEnd();
                        InsertTeretnicaStavke t = new InsertTeretnicaStavke();
                        t.UpdTeretnicaStavke(rb, brojTeretnice, idNajave,Convert.ToInt32(uvrstena), Convert.ToInt32(otkacena), brojKola, serija, brojOsovina, duzina, tara, neto, g, p, r, pr, vrnp, otpravna, uputna, reon, primedba, rucKoc, uvozna, izvozna, rid, dokument);
                    }
                }
                FillGV1();
                FillGV2();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
