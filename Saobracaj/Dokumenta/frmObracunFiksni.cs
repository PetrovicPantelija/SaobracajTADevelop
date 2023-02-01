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
using System.Net;
using System.Net.Mail;

using Microsoft.Reporting.WinForms;


namespace Saobracaj.Dokumenta
{
    public partial class frmObracunFiksni : Form
    {
        public frmObracunFiksni()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "frmObracunFiksni";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
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
                       // tsNew.Enabled = false;
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
        private void btnPostaviPrviDeo_Click(object sender, EventArgs e)
        {
            var select = " select Zaposleni, (Rtrim(DePriimek) + ' ' + Rtrim(DeIme)) as Radnik , Osnovna, Parametar1 as Nocni," +
                " Benificirani, TipRadnika, '0' as SatiNocni, '0' as SatiPraznik, '0' as OdmorSati, '0' as BolovanjeSati65," +
                " '0' as BolovanjeSati100, " +
                " '0' as SatiRedovan, Smena as Smenski, Parametar2 as TerenskiRad, '0' as IznosBolovanje, " +
                " '0' as IznosRedovan, '1000' as Regres, '2200' as TopliObrok, '0' as NocniIznos, '0' as RadniPraznikomIznos, " +
                "'0' as SmenskiRadIznos,  '0' as TerenskiRadIznos, '0' as Stimulacija " +
                "  from Zarada " + 
           " inner join Delavci on DeSifra = Zarada.Zaposleni where Fiksna = 1";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = false;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni";
            dataGridView1.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Osnovna";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Nocni";
            dataGridView1.Columns[3].Width = 30;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Benificirani";
            dataGridView1.Columns[4].Width = 30;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Tip radnika";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Sati noćni";
            dataGridView1.Columns[6].Width = 40;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Sati praznik";
            dataGridView1.Columns[7].Width = 40;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Sati GO";
            dataGridView1.Columns[8].Width = 40;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Sati Bol65";
            dataGridView1.Columns[9].Width = 40;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Sati Bol100";
            dataGridView1.Columns[10].Width = 40;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Sati Redovan";
            dataGridView1.Columns[11].Width = 40;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Smenski";
            dataGridView1.Columns[12].Width = 40;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Terenski";
            dataGridView1.Columns[13].Width = 40;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Bolovanje";
            dataGridView1.Columns[14].Width = 60;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Redovan";
            dataGridView1.Columns[15].Width = 60;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Regres";
            dataGridView1.Columns[16].Width = 60;

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Topli obrok";
            dataGridView1.Columns[17].Width = 60;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Noćni";
            dataGridView1.Columns[18].Width = 60;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Praznik";
            dataGridView1.Columns[19].Width = 60;

            DataGridViewColumn column21 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Smenski dodatak";
            dataGridView1.Columns[20].Width = 60;

            DataGridViewColumn column22 = dataGridView1.Columns[21];
            dataGridView1.Columns[21].HeaderText = "Terenski dodatak";
            dataGridView1.Columns[21].Width = 60;


            DataGridViewColumn column23 = dataGridView1.Columns[22];
            dataGridView1.Columns[22].HeaderText = "Stimulacija";
            dataGridView1.Columns[22].Width = 100;



        }

        private void SatiNocni()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[3].Value.ToString() == "1")
                    {
                        row.Cells[6].Value = ((Convert.ToInt32(txtBrojSati.Value) / 2)).ToString();
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
          
        }
        private void PovuciRadPraznikom()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(s_connection);

                    con.Open();

                    SqlCommand cmd = new SqlCommand("Select (isnull(Sum(Ukupno),0) * 8) as UK from PrekovremeniRad where ZaposleniID = " + row.Cells[0].Value +
                        " and Convert(nvarchar(10), DatumOd, 126) > '" + dtpVremeOd.Text + "' and Convert(nvarchar(10), DatumDo, 126) < '" + dtpVremeDo.Text + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        row.Cells[7].Value = dr["UK"].ToString();
                    }
                    con.Close();
                }


            }
            catch
            {
                MessageBox.Show("Nije uspelo povlacenje rada praznikom");
            }

    }

        private void PovuciSateGodisnjiOdmor()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(s_connection);

                    con.Open();

                    SqlCommand cmd = new SqlCommand("Select (isnull(Sum(Ukupno),0) * 8) as UK from DopustStavke " +
                    " inner join Dopust on Dopust.DoStZapisa = DopustStavke.IdNadredjena  where  Convert(nvarchar(10), VremeOd, 126) > '" + dtpVremeOd.Text + "' and Convert(nvarchar(10), VremeDo, 126) < '"+ dtpVremeDo.Text + "'  And Dopust.DoSifDe = " + row.Cells[0].Value, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        row.Cells[8].Value = dr["UK"].ToString();
                    }
                    con.Close();
                }


            }
            catch
            {
                MessageBox.Show("Nije uspelo odmora");
            }

        }

        private void PovuciBolovanje65()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(s_connection);

                    con.Open();

                   
                    SqlCommand cmd = new SqlCommand("Select (isnull(Sum(Ukupno),0)) as UK from Bolovanje where ZaposleniID = " + row.Cells[0].Value +
                        " and Convert(nvarchar(10), DatumOd, 126) > '" + dtpVremeOd.Text + "' and Convert(nvarchar(10), DatumDo, 126) < '" + dtpVremeDo.Text + "' and TipBolovanja = '65'", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        row.Cells[9].Value = dr["UK"].ToString();
                    }
                    con.Close();
                }


            }
            catch
            {
                MessageBox.Show("Nije uspelo povlacenje rada praznikom");
            }

        }

        private void PovuciBolovanje100()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(s_connection);

                    con.Open();


                    SqlCommand cmd = new SqlCommand("Select (isnull(Sum(Ukupno),0) ) as UK from Bolovanje where ZaposleniID = " + row.Cells[0].Value +
                        " and Convert(nvarchar(10), DatumOd, 126) > '" + dtpVremeOd.Text + "' and Convert(nvarchar(10), DatumDo, 126) < '" + dtpVremeDo.Text + "' and TipBolovanja = '100'", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        row.Cells[10].Value = dr["UK"].ToString();
                    }
                    con.Close();
                }


            }
            catch
            {
                MessageBox.Show("Nije uspelo povlacenje rada praznikom");
            }

        }

        private void RedovanRadSati()
        {
            //row.Cells[6].Value

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //input = input.Remove(input.IndexOf("/") + 1);
                    int UKSati = Convert.ToInt32(txtBrojSati.Value);
                    int OD1 = Convert.ToInt32(row.Cells[6].Value.ToString());
                    string s2 = row.Cells[7].Value.ToString();
                    s2 = s2.Remove(s2.IndexOf(","));
                    int OD2 = Convert.ToInt32(s2);

                    string s3 = row.Cells[8].Value.ToString();
                    //s3 = s3.Remove(s3.IndexOf(","));
                    int OD3 = Convert.ToInt32(s3);

                    string s4 = row.Cells[9].Value.ToString();
                    s4 = s4.Remove(s4.IndexOf(","));
                    int OD4 = Convert.ToInt32(s4);

                    string s5 = row.Cells[10].Value.ToString();
                    s5 = s5.Remove(s5.IndexOf(","));
                    int OD5 = Convert.ToInt32(s5);

                    //int Oduzeti = Convert.ToInt32(row.Cells[6].Value.ToString()) + Convert.ToInt32(row.Cells[7].Value.ToString()) + Convert.ToInt32(row.Cells[8].Value.ToString()) + Convert.ToInt32(row.Cells[9].Value.ToString()) + Convert.ToInt32(row.Cells[10].Value.ToString());
                    row.Cells[11].Value = (UKSati - (OD1 + OD2 + OD3+ OD4+OD5)).ToString();
                    // Iyracun sati
                    double Bol1 = OD5 * Convert.ToDouble(txtCenaSata.Value);
                    double Bol2 = OD4 * Convert.ToDouble(txtCenaSata.Value) * 65 / 100;
                    row.Cells[14].Value = (Bol1 + Bol2).ToString();
                    row.Cells[15].Value = ((UKSati - (OD1 + OD2 + OD3 + OD4 + OD5)) * txtCenaSata.Value).ToString();

                    double Noc = OD1 * Convert.ToDouble(txtCenaSata.Value) * 126 / 100;
                    row.Cells[18].Value = Noc.ToString();//Iyracun iznosa

                    double Praznik = OD2 * Convert.ToDouble(txtCenaSata.Value) * 110 / 100;
                    row.Cells[19].Value = Praznik.ToString();//Iyracun iznosa

                    //Smenski
                    string s6 = row.Cells[15].Value.ToString();
                    s6 = s6.Remove(s6.IndexOf(","));
                    int OD6 = Convert.ToInt32(s6);
                    double Smen = 0;
                    if (row.Cells[12].Value.ToString() == "1")
                    {
                        Smen = Convert.ToDouble(row.Cells[15].Value.ToString()) * 26 / 100;
                        row.Cells[20].Value = Smen.ToString();
                    }
                       
                   
                    
                    //Terenski
                    string s7 = row.Cells[12].Value.ToString();
                   // s7 = s7.Remove(s7.IndexOf(","));
                    int OD7 = Convert.ToInt32(s7);
                    double Ter = 0;
                    if (row.Cells[13].Value.ToString() == "1")
                    {
                        Ter = Convert.ToDouble(row.Cells[15].Value.ToString()) * 5 / 100;
                        row.Cells[21].Value = Ter.ToString();
                    }
                  
                    //Obracun stimulacije
                    
                    double Osnovna = Convert.ToDouble(row.Cells[2].Value); //osnovna
                    double St1 = Convert.ToDouble(row.Cells[20].Value);
                    double St2 = Convert.ToDouble(row.Cells[19].Value);
                    double St3 = Convert.ToDouble(row.Cells[18].Value);
                    double St4 = Convert.ToDouble(row.Cells[17].Value);
                    double St5 = Convert.ToDouble(row.Cells[16].Value);
                    double St6 = Convert.ToDouble(row.Cells[15].Value);
                    double St7 = Convert.ToDouble(row.Cells[14].Value);
                    double St8 = Convert.ToDouble(row.Cells[20].Value);
                    double St9 = Convert.ToDouble(row.Cells[21].Value);
                    double Stimulacija = Osnovna - (St1 + St2 + St3 + St4 + St5 + St6 + St7 + St8 + St9);
                    row.Cells[22].Value = Stimulacija.ToString();
                }

            }
            catch
            {
                MessageBox.Show("Nije uspelo iyracun Redovnog rada");
            }

        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
        SatiNocni();
        PovuciRadPraznikom();
        PovuciSateGodisnjiOdmor();
        PovuciBolovanje65();
        PovuciBolovanje100();
        RedovanRadSati();
        }
            
    }
}
