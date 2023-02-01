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
    public partial class frmEvidencijaGodišnjihOdmora : Form
    {
        
        bool status = false;
        int IzMobilneObrade = 0;
        int ZaposleniM;
        DateTime VremeOdM;
        DateTime VremeDoM;
        int OdobrioM;
        string NapomenaM;
        int SlobodanDanM;
        DateTime DatumZahtevaM;
        MailMessage mailMessage;
        int poslatMail = 0;
        int poslatoResenje = 0;
        string Kor = Sifarnici.frmLogovanje.user.ToString();

        public frmEvidencijaGodišnjihOdmora()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();

            tsDelete.Enabled = false;
            tsDelete.Visible = false;
            cboGodina.SelectedValue = "2021";
        }
        string niz = "";
        public static string code = "frmEvidencijaGodišnjihOdmora";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
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
                        tsNew.Enabled = false;
                    }
                    update = Convert.ToBoolean(reader["Izmena"]);
                    if (update == false)
                    {
                        tsSave.Enabled = false;
                    }
                    delete = Convert.ToBoolean(reader["Brisanje"]);
                    if (delete == false)
                    {
                        tsDelete.Enabled = false;
                    }
                }
            }

            conn.Close();
        }
        public frmEvidencijaGodišnjihOdmora(int Zaposleni, DateTime VremeOd, DateTime VremeDo, int Odobrio, string Napomena, int SlobodanDan, DateTime DatumZahteva)
        {
            InitializeComponent();
            status = true;
            IzMobilneObrade = 1;
           
            ZaposleniM = Zaposleni;
            VremeOdM = VremeOd;
            VremeDoM = VremeDo;
            OdobrioM = Odobrio;
            NapomenaM = Napomena;
            SlobodanDanM = SlobodanDan;
            DatumZahtevaM = DatumZahteva;
            cboGodina.SelectedValue = "2022";
        }

        private void cboZaposleni_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void VratiIDNadredjenog()
        {
            if (cboGodina.Text != "")
            { 
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("Select DoStZapisa  from Dopust " +
             " WHERE Dopust.DoLeto = " + Convert.ToInt32(cboGodina.Text) + " And Dopust.DoSifDe = " + Convert.ToInt32(cboZaposleni.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtNadredjeni.Text = dr["DoStZapisa"].ToString();
                
            }

            con.Close();
            }

        }

        private void VratiPodatkeDopustStavke()
        {
            if (cboGodina.Text != "")
            { 
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("Select ID, IDNadredjena, VremeOd, VremeDo, Ukupno, Napomena, Razlog, Odobrio, StatusGodmora, DatumZahteva, DatumPovratka, PoslatMail, PoslatoResenje from DopustStavke " +
            " inner join Dopust on Dopust.DoStZapisa = DopustStavke.IdNadredjena  where  + "  + " Dopust.DoLeto = " + Convert.ToInt32(cboGodina.Text) + " And Dopust.DoSifDe = " + Convert.ToInt32(cboZaposleni.SelectedValue)  , con);
            SqlDataReader dr = cmd.ExecuteReader();
            //Panta
            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
                // cboZaposleni.SelectedValue = Convert.ToInt32(dr["Zaposleni"].ToString());
                dtpVremeOd.Value = Convert.ToDateTime(dr["VremeOd"].ToString());
                dtpVremeDo.Value = Convert.ToDateTime(dr["VremeDo"].ToString());
                txtUkupno.Text = dr["Ukupno"].ToString();
                txtNapomena.Text = dr["Napomena"].ToString();
                txtRazlog.Text = dr["Razlog"].ToString();
                cboOdobrio.SelectedValue = Convert.ToInt32(dr["Odobrio"].ToString());
                txtNadredjeni.Text = dr["IDNadredjena"].ToString();
                cbostatusGOdmora.SelectedValue = Convert.ToInt32(dr["StatusGodmora"].ToString());
                dtpDatumZahteva.Value = Convert.ToDateTime(dr["DatumZahteva"].ToString());
                dtpDatumPovratka.Value = Convert.ToDateTime(dr["DatumPovratka"].ToString());
                poslatMail = Convert.ToInt32(dr["PoslatMail"].ToString());
                if (poslatMail == 1) { cbMail.Checked = true; } else { poslatMail = 0; cbMail.Checked = false; }
                poslatoResenje = Convert.ToInt32(dr["PoslatoResenje"].ToString());
                if (poslatoResenje == 1) { cbResenje.Checked = true; } else { poslatoResenje = 0; cbResenje.Checked = false; }

            }

            con.Close();
            }
        }

        private void frmEvidencijaGodišnjihOdmora_Load(object sender, EventArgs e)
        {
            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
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

            var select4 = " select Distinct(DoLeto) as Godina from Dopust";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboGodina.DataSource = ds4.Tables[0];
            cboGodina.DisplayMember = "Godina";
            cboGodina.ValueMember = "Godina";


            var select5 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboOdobrio.DataSource = ds5.Tables[0];
            cboOdobrio.DisplayMember = "Opis";
            cboOdobrio.ValueMember = "ID";

            if (IzMobilneObrade == 1)
            {
                cboZaposleni.SelectedValue = ZaposleniM ;
                dtpVremeOd.Value =  VremeOdM ;
                dtpVremeDo.Value = VremeDoM;
                cboOdobrio.SelectedValue = OdobrioM;
                txtNapomena.Text = NapomenaM;
                cboGodina.SelectedValue = dtpVremeOd.Value.Year;

                VratiPodatkeDopustStavke();
                VratiIDNadredjenog();
                RefreshDataGrid1();
                VratiPodatkeUkupnoDana();
                VratiPodatkeUkupnoKorisceno();
                VratiSlobodneDane();
                // SlobodanDanM = SlobodanDan; Funkcionalnost

                //Ovede postavljam vrdnosti

            }
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            dtpVremeOd.Value = DateTime.Now;
            dtpVremeDo.Value = DateTime.Now;
            txtNapomena.Text = "";
            InsertEvidencijaGOLog GoLog = new InsertEvidencijaGOLog();
            GoLog.InsertGoLOG(Kor, DateTime.Now, "Kreiranje novog zapisa");
           
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
           // 
            if (status == true)
            {
                InsertEvidencijaGodisnjihOdmora ins = new InsertEvidencijaGodisnjihOdmora();
                ins.InsEvidGodisnjihOdmora(Convert.ToInt32(txtNadredjeni.Text), dtpVremeOd.Value, dtpVremeDo.Value, Convert.ToInt32(txtUkupno.Text), txtNapomena.Text, txtRazlog.Text, Convert.ToInt32(cboOdobrio.SelectedValue), 3, Convert.ToDateTime(dtpDatumZahteva.Value), Convert.ToDateTime(dtpDatumPovratka.Value),poslatMail,poslatoResenje);
                status = false;
                RefreshDataGrid1();
                InsertEvidencijaGOLog GoLog = new InsertEvidencijaGOLog();
                GoLog.InsertGoLOG(Kor, DateTime.Now, "Uspesno sacuvan zapis");

            }
            else
            {
                InsertEvidencijaGodisnjihOdmora upd = new InsertEvidencijaGodisnjihOdmora();
                upd.UpdEvidGodisnjihOdmora(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtNadredjeni.Text), dtpVremeOd.Value, dtpVremeDo.Value, Convert.ToInt32(txtUkupno.Text), txtNapomena.Text, txtRazlog.Text, Convert.ToInt32(cboOdobrio.SelectedValue), Convert.ToInt32(cbostatusGOdmora.SelectedValue),  Convert.ToDateTime(dtpDatumZahteva.Value), Convert.ToDateTime(dtpDatumPovratka.Value),poslatMail,poslatoResenje);
                RefreshDataGrid1();
                InsertEvidencijaGOLog GoLog = new InsertEvidencijaGOLog();
                GoLog.InsertGoLOG(Kor, DateTime.Now, "Promena zapisa: "+ txtSifra.Text);
            }
            VratiSlobodneDane();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VratiPodatkeDopustStavke();
            VratiIDNadredjenog();
            RefreshDataGrid1();
            VratiPodatkeUkupnoDana();
            VratiPodatkeUkupnoKorisceno();
            VratiSlobodneDane();

        }

        private void VratiPodatkeUkupnoDana()
        {
            if (cboGodina.Text != "")
            { 
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("Select DoSkupaj  from Dopust " +
             " WHERE Dopust.DoLeto = " + Convert.ToInt32(cboGodina.Text) + " And Dopust.DoSifDe = " + Convert.ToInt32(cboZaposleni.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSUMUkupno.Text = dr["DoSkupaj"].ToString();

            }

            con.Close();
            }
        }

        int IspitajDaLiPostoji(int Godina, int Zaposleni)
        {
            int BrojU = 0;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Count(*) as Broj from Dopust where DoLeto = " + Godina + " and DoSifDe = " + Zaposleni, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                BrojU = Convert.ToInt32(dr["Broj"].ToString());
            }

            con.Close();


            return BrojU;
        }

        private void VratiPodatkeUkupnoKorisceno()
        {
            int Postoji = IspitajDaLiPostoji(Convert.ToInt32(cboGodina.SelectedValue), Convert.ToInt32(cboZaposleni.SelectedValue));
            if (Postoji == 0)
            {
                MessageBox.Show("Ne postoji zapis za tu godinu!!!!!");
                txtSumKorisceno.Text = "0";
                txtNekorisceno.Text = "0";
                txtSumKorisceno.Text = "0";
                return;
            }    
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select SUM(Ukupno) as Iskorisceno from DopustStavke where IDNadredjena = " + Convert.ToInt32(txtNadredjeni.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSumKorisceno.Text = dr["Iskorisceno"].ToString();
                if (txtSumKorisceno.Text == "")
                    txtSumKorisceno.Text = "0";
                txtNekorisceno.Text = (Convert.ToInt32(txtSUMUkupno.Text) - Convert.ToInt32(txtSumKorisceno.Text)).ToString();
            }

            con.Close();
        }

        private void RefreshDataGrid1()
        {
            if (cboGodina.Text != "")
            { 
            var select = " Select ID, IDNadredjena, VremeOd, VremeDo, Ukupno, Napomena, Razlog, (Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme)) as Odobrio , StatusGodmora, DatumZahteva, DatumPovratka,PoslatMail, PoslatoResenje from DopustStavke " +
            " inner join Dopust on Dopust.DoStZapisa = DopustStavke.IdNadredjena " +
             " inner join Delavci on DopustStavke.Odobrio = Delavci.DeSifra " +
            " where  + "  + " Dopust.DoLeto = " + Convert.ToInt32(cboGodina.Text) + " And Dopust.DoSifDe = " + Convert.ToInt32(cboZaposleni.SelectedValue) ;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
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

                DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "IDNAdredjena";
            dataGridView2.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Vreme Od";
            dataGridView2.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Vreme Do";
            dataGridView2.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Ukupno";
            dataGridView2.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Napomena";
            dataGridView2.Columns[5].Width = 120;

            DataGridViewColumn column7 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "Razlog";
            dataGridView2.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "Odobrio";
            dataGridView2.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "Status Odmora";
            dataGridView2.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "Zahtev";
            dataGridView2.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView2.Columns[10];
            dataGridView2.Columns[10].HeaderText = "Povratak";
            dataGridView2.Columns[10].Width = 50;

            dataGridView2.Columns[11].HeaderText = "PoslatMail";
            dataGridView2.Columns[12].HeaderText = "PoslatoResenje";
            }
        }

        private void VratiSlobodneDane()
        {
            if (cboGodina.Text != "")
            { 
            var select = " Select EvidencijaZahteva.ID, Zaposleni, (Rtrim(Delavci.DeIme) + ' ' + Rtrim(Delavci.DePriimek)) as Radnik, " +
            " EvidencujaZahtevaVrsta.Naziv as Tip, DatumOd, DatumDo, Status, Napomena, " +
            " Odobrio as OdobrioSifra, (Rtrim(o.DeIme) + ' ' + Rtrim(o.DePriimek)) as Odobrio " +
            " from EvidencijaZahteva " +
            " inner join EvidencujaZahtevaVrsta on EvidencujaZahtevaVrsta.ID = EvidencijaZahteva.VrstaZahtevaID " +
            " inner " +
            " join Delavci on Delavci.DeSifra = Zaposleni " +
            " left " +
            " join Delavci o on o.DeSifra = Odobrio " +
            " where Status = 2 and EvidencujaZahtevaVrsta.Naziv = 'Slobodni dani' and Zaposleni = " + cboZaposleni.SelectedValue + " and Year(DatumOd) =  " + cboGodina.SelectedValue +  
            " order by EvidencijaZahteva.ID desc";

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

                //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
                DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Radnik Zahtevao";
            dataGridView1.Columns[2].Width = 250;


            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Tip";
            dataGridView1.Columns[3].Width = 90;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vreme Od";
            dataGridView1.Columns[4].Width = 90;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vreme Do";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Status";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Napomena";
            dataGridView1.Columns[7].Width = 250;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Odobrio";
            dataGridView1.Columns[8].Width = 250;
            }
        }

        private void dtpVremeDo_Leave(object sender, EventArgs e)
        {
            TimeSpan span = dtpVremeDo.Value.Subtract(dtpVremeOd.Value);
            txtUkupno.Text = Convert.ToString(Math.Round(Convert.ToDouble(span.TotalDays), 2));
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertEvidencijaGodisnjihOdmora del = new InsertEvidencijaGodisnjihOdmora();
            del.DeleteDopustStavke(Convert.ToInt32(txtSifra.Text));
            RefreshDataGrid1();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        txtNadredjeni.Text = row.Cells[1].Value.ToString();
                        dtpVremeOd.Value = Convert.ToDateTime(row.Cells[2].Value.ToString());
                        dtpVremeDo.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
                        txtUkupno.Text = row.Cells[4].Value.ToString();
                        txtNapomena.Text = row.Cells[5].Value.ToString();
                        txtRazlog.Text = row.Cells[6].Value.ToString();
                        cboOdobrio.Text = row.Cells[7].Value.ToString();
                        dtpDatumZahteva.Value = Convert.ToDateTime(row.Cells[9].Value.ToString());
                        dtpDatumPovratka.Value = Convert.ToDateTime(row.Cells[10].Value.ToString());
                        poslatMail = Convert.ToInt32(row.Cells[11].Value.ToString());
                        poslatoResenje = Convert.ToInt32(row.Cells[12].Value.ToString());
                        if (poslatMail == 1) { cbMail.Checked = true; } else { poslatMail = 0; cbMail.Checked = false; }
                        if (poslatoResenje == 1) { cbResenje.Checked = true; } else { poslatoResenje = 0; cbResenje.Checked = false; }

                        RefreshDataGrid1();
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }
                

            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }
        string VratiJMBG()
        {
            /*
            DeUlHiStBivS
DePostnaStBivS
DeKrajBivS

DeEMSO

select top 1 DmNaziv from Razporeditve
inner join DelovnaMesta on DelovnaMesta.DeSifra = Razporeditve.RzSifDelMes
where RzSifDe =
order by RzStZapisa desc
*/
            string JMBG = "";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select DeEMSO as JMBG from Delavci where DeSifra = " + cboZaposleni.SelectedValue, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                JMBG = dr["JMBG"].ToString();
            }

            con.Close();


            return JMBG;

        }
        string VratiPrebivaliste()
        {
            /*
            DeUlHiStBivS
DePostnaStBivS
DeKrajBivS

DeEMSO

select top 1 DmNaziv from Razporeditve
inner join DelovnaMesta on DelovnaMesta.DeSifra = Razporeditve.RzSifDelMes
where RzSifDe =
order by RzStZapisa desc
*/
            string Prebivaliste = "";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select ( Rtrim(DePostnaStBivS) + ' '  +Rtrim(DeKrajBivS) + ' Ul. ' + DeUlHisStBivS ) as Prebivaliste from Delavci where DeSifra = " + cboZaposleni.SelectedValue, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Prebivaliste = dr["Prebivaliste"].ToString();
            }

            con.Close();


            return Prebivaliste;

        }

        string VratiRadnoMesto()
        {
            /*
            DeUlHiStBivS
DePostnaStBivS
DeKrajBivS

DeEMSO

select top 1 DmNaziv from Razporeditve
inner join DelovnaMesta on DelovnaMesta.DeSifra = Razporeditve.RzSifDelMes
where RzSifDe =
order by RzStZapisa desc
*/
            string RadnoMesto = "";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select top 1 DmNaziv from Razporeditve " +
            " inner join DelovnaMesta on DelovnaMesta.DmSifra = Razporeditve.RzSifDelMes "+ 
            " where RzSifDe =  " + cboZaposleni.SelectedValue + 
            " order by RzStZapisa desc"  , con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                RadnoMesto = dr["DmNaziv"].ToString();
            }

            con.Close();


            return RadnoMesto;

        }

        string VratiEmailAdresu()
        {

            string DeEmail = "";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select DeEmail from Delavci where DeSifra = " + cboZaposleni.SelectedValue, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DeEmail = dr["DeEmail"].ToString();
            }

            con.Close();


            return DeEmail;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtEmail.Text = VratiEmailAdresu();
            Insert1ReportGO ingo = new Insert1ReportGO();
            string Prebivaliste = VratiPrebivaliste();
            string JMBG = VratiJMBG();
            string RadnoMesto = VratiRadnoMesto();
            string DatumOD = dtpVremeOd.Value.ToString("dd.MMM.yyyy HH:mm");
            string DatumDo = dtpVremeDo.Value.ToString("dd.MMM.yyyy HH:mm");
            string DatumPovratka = dtpDatumPovratka.Value.ToString("dd.MMM.yyyy HH:mm");
            string DatumZahteva = dtpDatumZahteva.Value.ToString("dd.MMM.yyyy HH:mm");

            string Korisceno = "";
            if (txtSumKorisceno.Text == "0")
            {
                Korisceno = "nije iskoristio nijedan dan godišnjeg odmora za " + cboGodina.Text + " godinu";
            }
            else
            {
                Korisceno = "je iskoristio " + txtSumKorisceno.Text + " dana godišnjeg odmora za " + cboGodina.Text + " godinu ";
            }
            ingo.InsReportGO(cboZaposleni.Text,Prebivaliste, "", JMBG, RadnoMesto, cboGodina.Text, txtUkupno.Text,DatumOD,DatumDo,DatumPovratka, txtSUMUkupno.Text, Korisceno, DatumZahteva);
            TESTIRANJEDataSet14TableAdapters._1ReportGOTableAdapter ta = new TESTIRANJEDataSet14TableAdapters._1ReportGOTableAdapter();
            TESTIRANJEDataSet14._1ReportGODataTable dt = new TESTIRANJEDataSet14._1ReportGODataTable();
         
            ta.Fill(dt);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = dt;
          
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "rptGodisnjiOdmor.rdlc";
          
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
            poslatoResenje = 1;
            cbResenje.Checked = true;
        }

        private void PosaljiMailResenjeGO(string Kome)
        {
            try
            {
                string cuvaj = "zaposleni@kprevoz.co.rs";
                string zadnjibroj = txtSifra.Text;

                mailMessage = new MailMessage("pantelija.petrovic@kprevoz.co.rs", Kome);
                mailMessage.CC.Add(cuvaj);
                mailMessage.Subject = "Rešenje o godišnjem odmoru";
                
                var select = " SELECT [Zaposleni],[Prebivaliste],[Ulica] " +
      " ,[JMBG] ,[RadnoMesto] ,[Godina] ,[Dana] " +
      " ,[DatumOd] ,[DatumDo],[DatumPovratka] ,[DanaGodisnjeg] " +
      " ,[DanaIskoristio] ,[DatumZahteva]   FROM [TESTIRANJE].[dbo].[1ReportGO]";

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                string body = "Na osnovu člana 192 a u vezi sa članom 68, 69, 70, 72, 73 i 75 Zakona o radu Republike Srbije <br />" +
                    " ('Sl.glasnik RS', br. 24/05, 61/05, 54/09, 32/13, 75/14, 13/17 - odluka US, 113/17 i 95/18 - autentično tumačenje) <br />" +
                    " poslodavac Kombinovani prevoz d.o.o. Prokuplje, ul. Milena Jovanovića br. 15, matični broj: 07492251, PIB: 101555174, <br />" +
                    " koga zastupa direktor Branko Petković, dana " + DateTime.Now.ToString("dd.MM.yyyy.") + " godine, donosi sledeće:  <br /> <br />";
                
                body = body + "                             REŠENJE <br /> ";
                body = body + "                  O KORIŠĆENJU GODIŠNJEG ODMORA <br /> <br /> <br />";
                foreach (DataRow myRow in ds.Tables[0].Rows)
                {
                    body = body + myRow["Zaposleni"].ToString() + ", IZ " + myRow["Prebivaliste"].ToString() +
                        ", JMBG:" + myRow["JMBG"].ToString() + " , zaposlenom na radnom mestu " + myRow["RadnoMesto"].ToString() + " određuje se <br / ";
                    body = body + " korišćenje dela godišnjeg odmora za  " + myRow["Godina"].ToString() + "godinu u trajanju od" + myRow["Dana"].ToString() + "radnih dana" + "<br />";
                    body = body + "Godišnji odmor će se koristiti  u vremenu od " + myRow["DatumOd"].ToString() + " do " + myRow["DatumDo"].ToString() + " godine." + "<br />";
                    body = body + "Zaposleni je u obavezi da se na rad javi " + myRow["DatumPovratka"].ToString() + "godine. <br />";
                    body = body + "Za vreme korišćenja godišnjeg odmora zaposlenom pripada naknada zarade u visini prosečne zarade <br />";
                    body = body + "ostvarene u prethodnih dvanaest meseci u skladu sa čl. 114 Zakona o radu. <br />";
                    body = body + "Ovo rešenje postaje konačno danom dostavljanja zaposlenom. <br /><br />";
                    body = body + "'                               O b r a z l o ž e n j e: <br /><br />";
                    body = body + "U svakoj kalendarskoj godini zaposleni ima pravo na godišnji odmor u trajanju utvrđenom Pravilnikom  " + "<br />";
                    body = body + "o radu poslodavca i ugovorom o radu, a najmanje 20 radnih dana. " + "<br />";
                    body = body + "Zaposleni je u 2021. godini , ostvario pravo na " + myRow["DanaGodisnjeg"].ToString() + " dana godišnjeg odmora. " + "<br />";
                    body = body + "Do dana donošenja ovog rešenja zaposleni " + myRow["DanaIskoristio"].ToString() +  " <br /> ";
                    body = body + "Pri utvrđivanju dužine godišnjeg odmora radna nedelja računata je kao pet radnih dana." + "<br />";
                    body = body + "Praznici koji su neradni dani u skladu sa zakonom, odsustvo sa rada uz naknadu zarade i privremena " + "<br />";
                    body = body + "sprečenost za rad u skladu sa propisima o zdravstvenom osiguranju ne uračunavaju se u dane " + "<br />";
                    body = body + "godišnjeg odmora.<br />";
                    body = body + "Zaposleni se obaveštava da, u skladu sa čl. 75 st. 4 Zakona o radu, poslodavac može da izmeni vreme" + "<br />";
                    body = body + "određeno za korišćenje godišnjeg odmora ako to zahtevaju potrebe posla, najkasnije pet radnih dana " + "<br />";
                    body = body + "pre dana određenog za korišćenje godišnjeg odmora.<br />";
                    body = body + "Zaposleni je dana "  + myRow["DatumZahteva"].ToString()  + " godine dostavio poslodavcu zahtev za korišćenje godišnjeg  <br />";
                    body = body + "odmora u trajanju od radnih " + myRow["Dana"].ToString() + "dana, od " + myRow["DatumOd"].ToString()  +" do "  + myRow["DatumDo"].ToString() + " godine. <br />";
                    body = body + "Poslodavac se utvrdio da se zaposlenom može odobriti korišćenje godišnjeg odmora u navedenom " + "<br />";
                    body = body + "periodu i da je vreme korišćenja godišnjeg odmora zaposlenog u skladu sa Planom (rasporedom)  " + "<br />";
                    body = body + "korišćenja godišnjih odmora kod poslodavca." + "<br /> <br /> <br />";
                    body = body + "Pouka o pravnom leku:  Protiv ovog rešenja zaposleni podneti tužbu nadležnom sudu u roku od 60 dana " + "<br />";
                    body = body + "od dana dostavljanja rešenja. " + "<br /><br /><br />";
                    body = body + "Poslodavac: <br />";
                    body = body + "Kombinovani prevoz d.o.o. Prokuplje<br />";
                    body = body + "direktor Branko Petković" + "<br /><br /><br />";
                    body = body + "Rešenje se zaposlenom dostavlja elektronskim putem. <br />";
                    body = body + "Rešenje je važeće bez potpisa i pečata.<br />";
                    body = body + "Po pisanom zahtevu zaposlenog, Rešenje će biti dostavljeno u pisanoj formi.<br />";
                   


                }

                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "mail.kprevoz.co.rs";

                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("zaposleni@kprevoz.co.rs", "pele1616");

                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

                UpdatePoslatMail();
                cbMail.Checked = true;
                poslatMail = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void UpdatePoslatMail()
        {
            InsertEvidencijaGodisnjihOdmora upd = new InsertEvidencijaGodisnjihOdmora();
            upd.UpdateEVGOPoslaoMail(Convert.ToInt32(txtSifra.Text));
            RefreshDataGrid1();


        }

        private void btnPosaljiMail_Click(object sender, EventArgs e)
        {
            PosaljiMailResenjeGO(txtEmail.Text);
            cbMail.Checked = true;
            poslatMail = 1;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmEvidencijaGodLOG log = new frmEvidencijaGodLOG();
            log.Show();
        }

        private void cbMail_CheckedChanged(object sender, EventArgs e)
        {
            InsertEvidencijaGOLog GoLog = new InsertEvidencijaGOLog();
            GoLog.InsertGoLOG(Kor, DateTime.Now, "Poslat mail");
        }

        private void cbResenje_CheckedChanged(object sender, EventArgs e)
        {
            InsertEvidencijaGOLog GoLog = new InsertEvidencijaGOLog();
            GoLog.InsertGoLOG(Kor, DateTime.Now, "Poslato resenje");
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
                        cboZaposleni.Text = row.Cells[2].Value.ToString();
                        dtpVremeOd.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
                        dtpVremeDo.Value = Convert.ToDateTime(row.Cells[5].Value.ToString());
                        txtNapomena.Text = row.Cells[7].Value.ToString();
                        cboOdobrio.Text = row.Cells[9].Value.ToString();
                        txtUkupno.Text = "";
                        VratiSlobodneDane();
                        // txtOpis.Text = row.Cells[1].Value.ToString();
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
