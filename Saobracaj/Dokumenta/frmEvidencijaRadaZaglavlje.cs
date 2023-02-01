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
    public partial class frmEvidencijaRadaZaglavlje : Form
    {
        string TekuciKorisnik = "";
        public frmEvidencijaRadaZaglavlje(string Korisnik)
        {
            InitializeComponent();
            TekuciKorisnik = Korisnik;
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        string niz = "";
        public static string code = "frmEvidencijaRadaZaglavlje";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
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
        public frmEvidencijaRadaZaglavlje()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }

        private void frmEvidencijaRadaZaglavlje_Load(object sender, EventArgs e)
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

            // RefreshDataGrid();

        }

        private void RefreshDataGrid()
        {
            var select = "";

            if (chkUnosMasinovođa.Checked == true)
            {
                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                             " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                             "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                              "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                               " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
                                 " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Kraji.KrNaziv as Mesto," +
                                  " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                   " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano," +
                                   " Aktivnosti.DatumInserta" +
                             " from Aktivnosti  " +
                             " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                               " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                              "  where Aktivnosti.Masinovodja = 1 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                    //  " and VremeOd>= "  + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                    // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +

                               " order by Aktivnosti.ID desc";
            }
            else
            {
                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                                 " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                                 "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                                  "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                                   " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica," +
                                " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja, Kraji.KrNaziv as Mesto," +
                                 " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                  " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano, " +
                                   " Aktivnosti.DatumInserta" +
                                  " from Aktivnosti  " +
                                 " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                                   " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                                  "  where Aktivnosti.Masinovodja = 0 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                    //   " and VremeOd>= " + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                    // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +
                                  " order by Aktivnosti.ID desc";
            }

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
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Računi";
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


            RefreshTroskovi();

        }

        private void RefreshTroskovi()
        {
            // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
            double UkupniTroskovi = 0;
            double Placeno = 0;
            double Neplaceno = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Selected == true)
                {

                    UkupniTroskovi = UkupniTroskovi + Convert.ToDouble(row.Cells[6].Value.ToString());
                    if (Convert.ToBoolean(row.Cells[7].Value) == true)
                    {
                        Placeno = Placeno + Convert.ToDouble(row.Cells[7].Value.ToString());
                    }
                    else
                    {
                        Neplaceno = Neplaceno + Convert.ToDouble(row.Cells[7].Value.ToString());
                    }
                }
            }

            txtUkupniTrosak.Text = UkupniTroskovi.ToString();
            txtPlaceno.Text = Placeno.ToString();
            txtNeplaceno.Text = Neplaceno.ToString();


            double UkupniTroskoviRacuni = 0;
            double PlacenoRacuni = 0;
            double NeplacenoRacuni = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    UkupniTroskoviRacuni = UkupniTroskoviRacuni + Convert.ToDouble(row.Cells[11].Value.ToString());
                    if (Convert.ToBoolean(row.Cells[12].Value) == true)
                    {
                        PlacenoRacuni = PlacenoRacuni + Convert.ToDouble(row.Cells[11].Value.ToString());
                    }
                    else
                    {
                        NeplacenoRacuni = NeplacenoRacuni + Convert.ToDouble(row.Cells[11].Value.ToString());
                    }
                }
            }

            txtUkupniTrosakRacuni.Text = UkupniTroskoviRacuni.ToString();
            txtPlacenoRAcuni.Text = PlacenoRacuni.ToString();
            txtNeplacenoRacuni.Text = NeplacenoRacuni.ToString();



        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            var select = "";
            DateTime outputDateTimeValue;


            if (chkUnosMasinovođa.Checked == true && chkSpolja.Checked == false)
            {
                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
 " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, "+
 " UkupniTroskovi, Aktivnosti.Opis, RN,     CASE WHEN Aktivnosti.PoslatEmail > 0 "+
 " THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,   CASE WHEN Aktivnosti.Placeno > 0 "+
 " THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
 " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja," +
 "  Kraji.KrNaziv as Mesto, CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) " +
 "  END as PlaceniRacuni, CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) " +
 "  END as Pregledano, CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped , " +
 "   (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa , Outside" +
 "    from Aktivnosti   inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " + 
  "   inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja  " +
                              "  where  Aktivnosti.Masinovodja = 1 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) + " order by Aktivnosti.ID desc";
                    //  " and VremeOd>= "  + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                    // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +

                             
            }
            else if (chkUnosMasinovođa.Checked == false && chkSpolja.Checked == false)
            {
                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                                 " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                                 "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                                  "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                                   " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica," +
                                " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja, Kraji.KrNaziv as Mesto," +
                                 " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                  " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano," +
                                   " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                                  " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa, Outside " +
                                   " from Aktivnosti  " +
                                 " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                                   " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                                  "  where Aktivnosti.Masinovodja = 0 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                    //   " and VremeOd>= " + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                    // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +
                                  " order by Aktivnosti.ID desc";
            }
            else
            {
                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                                 " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                                 "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                                  "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                                   " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica," +
                                " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja, Kraji.KrNaziv as Mesto," +
                                 " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                  " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano," +
                                   " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                                  " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa, Outside " +
                                   " from Aktivnosti  " +
                                 " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                                   " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                                  "  where Aktivnosti.outside = 1 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                                  //   " and VremeOd>= " + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                                  // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +
                                  " order by Aktivnosti.ID desc";
            }
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
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Računi";
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

            RefreshTroskovi();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                InsertAktivnosti delAkt = new InsertAktivnosti();
                InsertAktivnostiStavke delAktStav = new InsertAktivnostiStavke();

                if (row.Selected == true)
                {
                    delAkt.DeleteAktivnosti(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    delAktStav.DeleteAktivnostiStavkePoNadredjenom(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }


                // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
            }
            RefreshDataGrid();
            RefreshTroskovi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlFormattedDate = "'" + dtpPredvidjenoPrimanje.Value.Date.ToString("yyyy-MM-dd") + "'";

            string sqlFormattedDate2 = "'" + dtpVremeDo.Value.Date.ToString("yyyy-MM-dd") + "'";
            var select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                        " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                        "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                          "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                              " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno, Racun, Kartica " +
                        " from Aktivnosti  " +
                        " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                         "  where VremeOD  >= " + sqlFormattedDate + " and  VremeOd <= " + sqlFormattedDate2 +
                         " order by Aktivnosti.ID desc";

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

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Oznaka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni";
            dataGridView1.Columns[2].Width = 130;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Vreme od";
            dataGridView1.Columns[3].Width = 130;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme do";
            dataGridView1.Columns[4].Width = 130;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Ukupno";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Ukupni troškovi";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Opis";
            dataGridView1.Columns[7].Width = 250;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "RN";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Poslat Email";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Plaćeno";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Racuni";
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Kartice";
            dataGridView1.Columns[12].Width = 50;

            RefreshTroskovi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    if (chkKragujevac.Checked == true)
                    {
                        frmEvidencijaRadaKragujevac er = new frmEvidencijaRadaKragujevac(Convert.ToInt32(row.Cells[0].Value.ToString()));
                        er.Show();

                    }
                    else if (chkSmederevo1.Checked == true)
                    {
                        frmEvidencijaRadaSmederevo er = new frmEvidencijaRadaSmederevo(Convert.ToInt32(row.Cells[0].Value.ToString()));
                        er.Show();
                    
                    }
                    else if (chkSmederevo1.Checked == true)
                    {
                        frmEvidencijaRadaCG er = new frmEvidencijaRadaCG(Convert.ToInt32(row.Cells[0].Value.ToString()));
                        er.Show();

                    }
                    else if (chkSmederevo1.Checked == true)
                    {
                        frmEvidencijaRadaRemont er = new frmEvidencijaRadaRemont(Convert.ToInt32(row.Cells[0].Value.ToString()));
                        er.Show();

                    }
                    else
                    {
                    
                    frmEvidencijaRada er = new frmEvidencijaRada(Convert.ToInt32(row.Cells[0].Value.ToString()), TekuciKorisnik);
                    er.Show();
                    }
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
            RefreshTroskovi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {


                if (row.Selected == true)
                {
                    InsertAktivnosti ins = new InsertAktivnosti();
                   // ins.UpdateAktivnostiPlaceno(Convert.ToInt32(row.Cells[0].Value.ToString()));

                }
            }


            /*
            InsertAktivnosti ins = new InsertAktivnosti();
            ins.UpdateAktivnostiPlaceno(Convert.ToInt32(txtSifra.Text));
            chkPlaceno.Checked = true;
             * */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {


                if (row.Selected == true)
                {
                    InsertAktivnosti ins = new InsertAktivnosti();
                    ins.UpdateMasinovodja(Convert.ToInt32(row.Cells[0].Value.ToString()));

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
                    ins.UpdateAktivnostiPlacenoRacuni(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboZaposleni.SelectedValue));
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {



            // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());



        }

        private void button7_Click(object sender, EventArgs e)
        {


            double UkupniTroskovi = 0;
            double Placeno = 0;
            double Neplaceno = 0;
            double UkupniTroskoviRacuni = 0;
            double PlacenoRacuni = 0;
            double NeplacenoRacuni = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Selected == true)
                {

                    UkupniTroskovi = UkupniTroskovi + Convert.ToDouble(row.Cells[6].Value.ToString());
                    if (Convert.ToBoolean(row.Cells[10].Value) == true)
                    {
                        Placeno = Placeno + Convert.ToDouble(row.Cells[6].Value.ToString());
                    }
                    else
                    {
                        Neplaceno = Neplaceno + Convert.ToDouble(row.Cells[6].Value.ToString());
                    }
                }
            }

            txtUkupniTrosak.Text = UkupniTroskovi.ToString();
            txtPlaceno.Text = Placeno.ToString();
            txtNeplaceno.Text = Neplaceno.ToString();



            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    UkupniTroskoviRacuni = UkupniTroskoviRacuni + Convert.ToDouble(row.Cells[11].Value.ToString());
                    if (Convert.ToBoolean(row.Cells[10].Value) == true)
                    {
                        PlacenoRacuni = PlacenoRacuni + Convert.ToDouble(row.Cells[11].Value.ToString());
                    }
                    else
                    {
                        NeplacenoRacuni = NeplacenoRacuni + Convert.ToDouble(row.Cells[11].Value.ToString());
                    }
                }
            }

            txtUkupniTrosakRacuni.Text = UkupniTroskoviRacuni.ToString();
            txtPlacenoRAcuni.Text = PlacenoRacuni.ToString();
            txtNeplacenoRacuni.Text = NeplacenoRacuni.ToString();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    InsertAktivnosti ins = new InsertAktivnosti();
                    ins.UpdateAktivnostiPregledano(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var select = "";
            DateTime outputDateTimeValue;


            if (chkSmederevo1.Checked == true)
            {
                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                             " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                             "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                              "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                               " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
                                 " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Kraji.KrNaziv as Mesto," +
                                  " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                   " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano, " +
                                    " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                                " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa " +
                                    " from Aktivnosti  " +
                             " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
                              "  inner Join AktivnostiStavke " +
                             "  on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
                               " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
                                 " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                              "  where Smederevo = 1 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                    //  " and VremeOd>= "  + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                    // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +

                               " order by Aktivnosti.ID desc";
            }
            else if (chkKragujevac.Checked == true)
            {
                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                             " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                             "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                              "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                               " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
                                 " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Kraji.KrNaziv as Mesto," +
                                  " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                   " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano, " +
                                   " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                              " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa " +
                                   " from Aktivnosti  " +
                             " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
                              "  inner Join AktivnostiStavke " +
                             "  on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
                               " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
                                 " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                              "  where Kragujevac = 1 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                    //  " and VremeOd>= "  + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                    // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +
                    
                               " order by Aktivnosti.ID desc";
                }
            else if (chkCG.Checked == true)
            {
                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                             " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                             "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                              "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                               " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
                                 " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Kraji.KrNaziv as Mesto," +
                                  " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                   " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano," +
                                    " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                               " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa " +
                                    " from Aktivnosti  " +
                             " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
                              "  inner Join AktivnostiStavke " +
                             "  on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
                               " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
                                 " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                              "  where CG = 1 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                    //  " and VremeOd>= "  + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                    // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +

                               " order by Aktivnosti.ID desc";
            }
            else if (chkRemont.Checked == true)
            {
                select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                             " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                             "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                              "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                               " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
                                 " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja , Kraji.KrNaziv as Mesto," +
                                  " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                   " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano, " +
                                    " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                               " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa " +
                                    " from Aktivnosti  " +
                             " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
                              "  inner Join AktivnostiStavke " +
                             "  on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
                               " inner Join  VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
                                 " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                              "  where Remont = 1 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                    //  " and VremeOd>= "  + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                    // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +

                               " order by Aktivnosti.ID desc";
            }
               
            
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
                dataGridView1.Columns[10].Width = 50;

                DataGridViewColumn column11 = dataGridView1.Columns[11];
                dataGridView1.Columns[11].HeaderText = "Računi";
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

                RefreshTroskovi();
            }

        private void button10_Click(object sender, EventArgs e)
        {
            var select = "";
            DateTime outputDateTimeValue;


            //  if (chkUnosMasinovođa.Checked == true)
            // {
            select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
" (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,    VremeOD, VremeDo, Ukupno, " +
" UkupniTroskovi, Aktivnosti.Opis, RN,     CASE WHEN Aktivnosti.PoslatEmail > 0 " +
" THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,   CASE WHEN Aktivnosti.Placeno > 0 " +
" THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica, " +
" CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja," +
"  Kraji.KrNaziv as Mesto, CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) " +
"  END as PlaceniRacuni, CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) " +
"  END as Pregledano, CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped , " +
"   (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa , Outside, DatumInserta" +
"    from Aktivnosti   inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
"   inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja  " +
                          "  where  outside = 1 order by Aktivnosti.ID desc";
            //  " and VremeOd>= "  + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
            // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +


            /* }
             else
             {
                 select = "Select Aktivnosti.ID as Zapis,  Aktivnosti.Oznaka, " +
                                  " (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                                  "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN,  " +
                                   "   CASE WHEN Aktivnosti.PoslatEmail > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PoslatEmail,  " +
                                    " CASE WHEN Aktivnosti.Placeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Placeno,   RAcun, Kartica," +
                                 " CASE WHEN Aktivnosti.Masinovodja > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Masinovodja, Kraji.KrNaziv as Mesto," +
                                  " CASE WHEN Aktivnosti.PlacenoRacun > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PlaceniRacuni," +
                                   " CASE WHEN Aktivnosti.Pregledano > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Pregledano," +
                                    " CASE WHEN Aktivnosti.Milsped > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped" +
                                   " , (SELECT COUNT(*) FROM AktivnostiDokumenta where AktivnostiDokumenta.IDAktivnosti = Aktivnosti.ID) as Zapisa " +
                                    " from Aktivnosti  " +
                                  " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                                    " inner join Kraji on Kraji.KrSifra = Aktivnosti.MestoUpucivanja" +
                                   "  where Aktivnosti.Masinovodja = 0 and Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                     //   " and VremeOd>= " + DateTime.ParseExact(dtpPredvidjenoPrimanje.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) +
                     // " and  VremeDo<= " + DateTime.ParseExact(dtpVremeDo.Value.ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture) + Convert.ToDateTime(dtpVremeDo.Value) +
                                   " order by Aktivnosti.ID desc";
             }
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
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Računi";
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

            DataGridViewColumn column19 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Outside";
            dataGridView1.Columns[19].Width = 50;

            DataGridViewColumn column20 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Datum Inserta";
            dataGridView1.Columns[20].Width = 80;

            RefreshTroskovi();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            InsertAktivnosti ins = new InsertAktivnosti();
            ins.DeleteID();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected == true)
                {
                    ins.InsID(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }
            }
            ins.InsAktivnotiZaglavlje();
            MessageBox.Show("TO TI JE ZAVRŠENO!!!! Uradi refresh");
        }
    }
    }

