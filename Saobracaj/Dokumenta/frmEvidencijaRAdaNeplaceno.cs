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

using Microsoft.Reporting.WinForms;

namespace Saobracaj.Dokumenta
{
    public partial class frmEvidencijaRAdaNeplaceno : Form
    {
        public frmEvidencijaRAdaNeplaceno()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "frmEvidencijaRAdaNeplaceno";
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
                     //   tsNew.Enabled = false;
                    }
                    update = Convert.ToBoolean(reader["Izmena"]);
                    if (update == false)
                    {
                       // tsSave.Enabled = false;
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
        private void btnPretrazi_Click(object sender, EventArgs e)
        {

            var select = "";

            /*
            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                           " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                           "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                            "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                             " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
                               " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Mesto," +
                                " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                 " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano, " +
                                  " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                            " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa " +
                                  " from Aktivnosti  " +
                           " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                            "  where Aktivnosti.Placeno = 0 and (Aktivnosti.PlacenoRacun = 0) and (UkupniTroskovi + RAcun) > 0 " +
                              " and CONVERT(varchar,VremeOd,104)      + ' '      + SUBSTRING(CONVERT(varchar,VremeOd,108),1,5)  <=  " +
            " CONVERT(varchar, '" + Convert.ToDateTime(dtpVremeDo.Value) + "',104)      + ' '      + SUBSTRING(CONVERT(varchar,'" + Convert.ToDateTime(dtpVremeDo.Value) + "',108),1,5) " +
                            " order by Aktivnosti.ID desc";
            */
           select = " Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
            "    (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni, " +
            " VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN, " +
            " CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail, " +
            " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica,  CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Mesto, " +
            " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni, CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano,  CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped ," +
            "    (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa  from Aktivnosti " +
            " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni    where Aktivnosti.Placeno = 0 and (Aktivnosti.PlacenoRacun = 0) and (UkupniTroskovi + RAcun + Kartica) > 0 " +
            " And  Convert(nvarchar(10),VremeDo,126) <=  '" + dtpVremeDo.Text + "' order by Aktivnosti.ID desc";

/*
            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                     " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                     "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                      "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                       " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
                         " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Mesto," +
                          " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                           " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano, " +
                            " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                      " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa " +
                            " from Aktivnosti  " +
                     " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                      "  where Aktivnosti.Placeno = 0 and (Aktivnosti.PlacenoRacun = 0) and (UkupniTroskovi + RAcun) > 0 " +
                      " And  VremeOd <=  '" +
                       dtpVremeDo.Text +
                      "' order by Aktivnosti.ID desc";
*/
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

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Oznaka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Vreme od";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme do";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Ukupno";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupni troškovi";
            dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Opis";
            dataGridView1.Columns[7].Width = 120;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "RN";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Poslat Email";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Plaćeno";
            dataGridView1.Columns[10].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Računi";
            dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Kartice";
            dataGridView1.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Masinovodja";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Mesto";
            dataGridView1.Columns[14].Width = 100;

            DataGridViewColumn column15 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Pregledano računi";
            dataGridView1.Columns[15].Width = 50;

            DataGridViewColumn column16 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Pregledano kartice";
            dataGridView1.Columns[16].Width = 50;

            DataGridViewColumn column17 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Milšped";
            dataGridView1.Columns[17].Width = 50;

            DataGridViewColumn column18 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Zapisa";
            dataGridView1.Columns[18].Width = 50;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var select = "";

            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                           " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                           "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                            "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                             " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
                               " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , MestoUpucivanja," +
                                " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                 " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano, " +
                                  " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                            " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa " +
                                  " from Aktivnosti  " +
                           " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                            "  where Aktivnosti.Placeno = 0 and (Aktivnosti.PlacenoRacun = 0) and (UkupniTroskovi + RAcun) > 0 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                             " And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' order by Aktivnosti.ID desc";
           

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

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Oznaka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Vreme od";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme do";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Ukupno";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupni troškovi";
            dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.Aqua;
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Opis";
            dataGridView1.Columns[7].Width = 120;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "RN";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Poslat Email";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Plaćeno";
            dataGridView1.Columns[10].DefaultCellStyle.BackColor = Color.OrangeRed;
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Računi";
            dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.CadetBlue;
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Kartice";
            dataGridView1.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Masinovodja";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Mesto";
            dataGridView1.Columns[14].Width = 100;

            DataGridViewColumn column15 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Pregledano računi";
            dataGridView1.Columns[15].Width = 50;

            DataGridViewColumn column16 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Pregledano kartice";
            dataGridView1.Columns[16].Width = 50;

            DataGridViewColumn column17 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Milšped";
            dataGridView1.Columns[17].Width = 50;

            DataGridViewColumn column18 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Zapisa";
            dataGridView1.Columns[18].Width = 50;
        }

        private void frmEvidencijaRAdaNeplaceno_Load(object sender, EventArgs e)
        {
            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci  order by opis";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboZaposleni.DataSource = ds3.Tables[0];
            cboZaposleni.DisplayMember = "Opis";
            cboZaposleni.ValueMember = "ID";


            var select4 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPregledac.DataSource = ds4.Tables[0];
            cboPregledac.DisplayMember = "Opis";
            cboPregledac.ValueMember = "ID";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtSifra.Text == "DejanIvan")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected == true)
                    {
                        InsertAktivnosti ins = new InsertAktivnosti();
                        ins.UpdateAktivnostiPlaceno(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToDateTime(dtpVremePlaceno.Value));

                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    InsertAktivnosti ins = new InsertAktivnosti();
                    ins.UpdateAktivnostiPlacenoRacuni(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboPregledac.SelectedValue));
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    {
                        frmEvidencijaRada er = new frmEvidencijaRada(Convert.ToInt32(row.Cells[0].Value.ToString()), "");
                        er.Show();
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}