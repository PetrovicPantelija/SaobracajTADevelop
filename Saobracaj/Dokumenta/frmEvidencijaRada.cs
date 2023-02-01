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
    public partial class frmEvidencijaRada : Form
    {
        string Korisnik = "";
        MailMessage mailMessage;
        Boolean status = false;
        Boolean prvinovi = true;
        int Postoji = 0;
        int PravoDnevnice = 0;
        DateTime DatumZakljucavanja;

        double tUkupniTroskovi; double tRacun; double tKartica;
        double tUkupniTroskoviPrvi; double tRacunPrvi; double tKarticaPrvi;

        public frmEvidencijaRada(string TekuciKorisnik)
        {
            InitializeComponent();
            VratiDatumZakljucavanja();
            Korisnik = TekuciKorisnik;
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "frmEvidencijaRada";
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
        public frmEvidencijaRada(int Sifra, string TekuciKorisnik)
        {
            InitializeComponent();
            txtSifra.Text = Sifra.ToString();
            prvinovi = false;
            VratiDatumZakljucavanja();
            Korisnik = TekuciKorisnik;
            IdGrupe();
            IdForme();
            PravoPristupa();

        }

        private void VratiPodatkeAktivnost()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select ID, Zaposleni, VremeOd,VremeDo, Ukupno, UkupniTroskovi, Opis, RN,Oznaka, PoslatEmail, Placeno, RAcun, Kartica, Masinovodja, Mesto,Milsped, Dnevnica, mestoUpucivanja, Izracun,Razlika,Zarada, PravoDnevnice  from Aktivnosti where ID = " + Convert.ToInt32(txtSifra.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
                cboZaposleni.SelectedValue = Convert.ToInt32(dr["Zaposleni"].ToString());
                dtpVremeOd.Value = Convert.ToDateTime(dr["VremeOd"].ToString());
                dtpVremeDo.Value = Convert.ToDateTime(dr["VremeDo"].ToString());
                txtVreme.Text = dr["Ukupno"].ToString();
                txtUkupnoMašinovođa.Text = dr["Ukupno"].ToString();
                /*
                TimeSpan span = dtpVremeDo.Value.Subtract(dtpVremeOd.Value);
                txtVreme.Text = Convert.ToString(Math.Round(Convert.ToDouble(span.TotalHours), 2));


                if (Math.Round(Convert.ToDouble(span.TotalHours), 2) < 7)
                {
                    txtUkupnoMašinovođa.Text = "6";
                    txtVreme.Text = "6";
                }

                else
                {
                    txtUkupnoMašinovođa.Text = "12";
                    txtVreme.Text = "12";
                }

                */
                txtTrosak.Text = dr["UkupniTroskovi"].ToString();
                txtKomentar.Text = dr["Opis"].ToString();
               // cboRadniNalog.SelectedValue = Convert.ToInt32(dr["RN"].ToString());
                cboRadniNalog.SelectedValue = 0;
                txtOznaka.Text = dr["Oznaka"].ToString();
                txtRacun.Text = dr["Racun"].ToString();
                txtKartica.Text = dr["Kartica"].ToString();
                txtMesto.Text = dr["Mesto"].ToString();
                txtIzracun.Text = dr["Izracun"].ToString();
                txtRazlika.Text = dr["Razlika"].ToString();
                txtZarada.Text = dr["Zarada"].ToString();
                if (dr["PoslatEmail"].ToString() == "1")
                {
                    chkPoslatMail.Checked = true;
                }
                else
                {
                    chkPoslatMail.Checked = false;
                    
                }
                if (dr["Milsped"].ToString() == "1")
                {
                    chkMilsped.Checked = true;
                }
                else
                {
                    chkMilsped.Checked = false;

                }
                if (dr["Placeno"].ToString() == "1")
                {
                    chkPlaceno.Checked = true;
                }
                else
                {
                    chkPlaceno.Checked = false;

                }

                if (dr["Masinovodja"].ToString() == "1")
                {
                    chkUnosMasinovođa.Checked = true;
                }
                else
                {
                    chkUnosMasinovođa.Checked = false;

                }

                if (dr["PravoDnevnice"].ToString() == "1")
                {
                    chkPravoDnevnice.Checked = true;
                }
                else
                {
                    chkPravoDnevnice.Checked = false;

                }
                cboTIpRada.SelectedIndex = Convert.ToInt32(dr["Dnevnica"].ToString());
               //nis
                cboMestoUpucenja.SelectedValue = Convert.ToInt32(dr["mestoUpucivanja"].ToString());
               // int BrojAktivnosti = ProveriPostojeAktivnosti();
            }

            con.Close();
        }

        private void VratiDatumZakljucavanja()
        {
            //Panta 
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Data  from Config where Code = 'DatumUnosaSmena'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DatumZakljucavanja = Convert.ToDateTime(dr["Data"].ToString());
            
            }

            con.Close();
        }

        /*
        int ProveriPostojeAktivnosti()
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Count(*) as BrojAktivnosti from AktivnostiStavke where AktivnostiStavke.IdNadredjena = " + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
               // ProveriPostojeAktivnosti = Convert.ToInt32(dr["BrojAktivnosti"].ToString());
            }

            con.Close();
        
        
        }
        */

        private void tsNew_Click(object sender, EventArgs e)
        {
           /*
            if (prvinovi == true)
            {
                chkUnetaAktivnost.Checked = false;
                prvinovi = false;
            }
            else if (chkUnetaAktivnost.Checked == true)
                chkUnetaAktivnost.Checked = false;
            else
            {
                MessageBox.Show("Niste uneli ni jednu aktivnost za predhodnu aktivnost");
                return;
            }
            */
            status = true;
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            dtpVremeOd.Value = DateTime.Now;
            dtpVremeDo.Value = DateTime.Now;
            txtKomentar.Text = "";
            txtVreme.Text = "0";
            txtRazlika.Text = "0";
            txtZarada.Text = "0";
            txtIzracun.Text = "0";
        }

        private void frmEvidencijaRada_Load(object sender, EventArgs e)
        {
            
            var select2 = "select Distinct  Rtrim(KrNaziv) as KrNaziv, Max(KrSifra) as KrSifra from Kraji " +
                          " group by KrNaziv";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboMestoUpucenja.DataSource = ds2.Tables[0];
            cboMestoUpucenja.DisplayMember = "KrNaziv";
            cboMestoUpucenja.ValueMember = "KrSifra";
            
            /*
            var select2 = " Select SmSifra, SmSifra as Opis from Mesta where Lokomotiva=1";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboLokomotiva.DataSource = ds2.Tables[0];
            cboLokomotiva.DisplayMember = "Opis";
            cboLokomotiva.ValueMember = "SmSifra";

            */
            
            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci order by opis";
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

           

            var select5 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5= new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboNalogodavac.DataSource = ds5.Tables[0];
            cboNalogodavac.DisplayMember = "Opis";
            cboNalogodavac.ValueMember = "ID";

            cboNalogodavac.SelectedValue = 0;


           // --------------------------
            var select6 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci where DeSifStat <> 'P' order by opis";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboNadlezni.DataSource = ds6.Tables[0];
            cboNadlezni.DisplayMember = "Opis";
            cboNadlezni.ValueMember = "ID";

            cboNadlezni.SelectedValue = 0;


            RefreshDataGrid();

            if (txtSifra.Text == "")
            {

            }
            else
            {

                VratiPodatkeAktivnost();
                RefreshDataGridPoAktivnostima();
                VratiEmail();
                // VratiTrase(txtSifra.Text);

                InsertAktivnosti ins = new InsertAktivnosti();
                int postoji = 0;
                StoredProcWithOutPutParameter(Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value);
                ///pntatattt
                if (Postoji > 1)
                {
                    MessageBox.Show("Postoji zapis za koji je početak i kraj unutar zadatok datuma početka");

                }
            }
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Aktivnosti", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void VratiEmail()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select DeEmail as Email from Delavci where DeSifra =" + Convert.ToInt32(cboZaposleni.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtEmail.Text = dr["Email"].ToString();
            }

            con.Close();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            double vreme = 0;
            int masinovodja = 0;
            int milspedsmena = 0;
            if (dtpVremeOd.Value < Convert.ToDateTime(DatumZakljucavanja))
            { 
                MessageBox.Show("Nije dozvoljen unos posle datuma zaključavanja");
                return;

            }    
               
            if (cboTIpRada.SelectedIndex < 0)
            {
            
            MessageBox.Show(" Niste uneli Tip Rada ");
            }

            if (Convert.ToInt32(cboMestoUpucenja.SelectedValue) < 1)
            {
                MessageBox.Show("Niste uneli mesto upućenja");
            }
            if (Convert.ToInt32(cboMestoUpucenja.SelectedValue) == 115)
            {
                MessageBox.Show("Uneli ste da nema mesto upućenja");
            }

            var selectedOption = MessageBox.Show("Da li ima pravo na dnevnicu(VSV)?", "Način izračuna", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



            // If the no button was pressed ...

            if (selectedOption == DialogResult.Yes)
            {

                MessageBox.Show("Odredili ste da ima pravo na dnevnicu!", "Yes - obeležili ste da ima pravo na dnevnicu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PravoDnevnice = 1;
                chkPravoDnevnice.Checked = true;

            }

            else if (selectedOption == DialogResult.No)
            {

                MessageBox.Show("Odredili ste da nema pravo na dnevnicu!", "No Dialog", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                PravoDnevnice = 0;
                chkPravoDnevnice.Checked = false;
            }

             

            if (chkUnosMasinovođa.Checked == true)
            {
                masinovodja = 1;
                vreme = Convert.ToDouble(txtUkupnoMašinovođa.Text);
            }
            else
            {
                masinovodja = 0;
                vreme = Convert.ToDouble(txtVreme.Text);
            }

            if (chkMilsped.Checked == true)
            {
               milspedsmena = 1;
            }
            else
            {
                milspedsmena = 0;
            }
            decimal provera = 0;
            provera = Convert.ToDecimal(txtVreme.Text);
            if ( provera> 12)
            {
                MessageBox.Show("Ukupno vreme je veće od 12 sati ");
            }
            InsertLogAktivnosti insL = new InsertLogAktivnosti();

            if (status == true)
            {
                InsertAktivnosti ins = new InsertAktivnosti();
                int postoji = 0;
                StoredProcWithOutPutParameter(Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value);
                ///pntatattt
                if (Postoji > 0)
                {
                    MessageBox.Show("Postoji zapis za koji je početak i kraj unutar zadatok datuma početka");

                }
                else
                {
                    ins.InsAktivnosti(Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, vreme, Convert.ToDouble(txtTrosak.Text), txtKomentar.Text, 0, txtOznaka.Text, Convert.ToDouble(txtRacun.Text), Convert.ToDouble(txtKartica.Text), masinovodja, txtMesto.Text.Trim(), milspedsmena, cboTIpRada.SelectedIndex, Convert.ToInt32(cboMestoUpucenja.SelectedValue), PravoDnevnice, Korisnik, 0);
                    ins.InsAktivnostiPrvi(Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, vreme, Convert.ToDouble(txtTrosak.Text), txtKomentar.Text, 0, txtOznaka.Text, Convert.ToDouble(txtRacun.Text), Convert.ToDouble(txtKartica.Text), masinovodja, txtMesto.Text.Trim(), milspedsmena, cboTIpRada.SelectedIndex, Convert.ToInt32(cboMestoUpucenja.SelectedValue), PravoDnevnice, Korisnik, 0);
                    //Ovde pravimo dupli upis
                    status = false;
                    VratiPodatkeMax();
                    insL.InsLog(Convert.ToInt32(txtSifra.Text), "Insert zaglavlje", Korisnik, DateTime.Now, 0,0,0);
                }
            }
            else
            {
                InsertAktivnosti upd = new InsertAktivnosti();
                VratiVrednostiPrvi();
                VratiVrednostiZadnji();

                upd.UpdAktivnosti(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, vreme, Convert.ToDouble(txtTrosak.Text), txtKomentar.Text, 0, txtOznaka.Text, Convert.ToDouble(txtRacun.Text), Convert.ToDouble(txtKartica.Text), masinovodja, txtMesto.Text.Trim(), milspedsmena, cboTIpRada.SelectedIndex, Convert.ToInt32(cboMestoUpucenja.SelectedValue));

                if (tUkupniTroskovi == -1 || tRacun == -1 || tKartica == -1)
                {

                }
                else
                {
                    if (tUkupniTroskovi != Convert.ToDouble(txtTrosak.Text))
                    {
                        insL.InsLog(Convert.ToInt32(txtSifra.Text), "Update zaglavlje Dodatni trosak", Korisnik, DateTime.Now, Convert.ToDouble(tUkupniTroskoviPrvi), Convert.ToDouble(tUkupniTroskovi), Convert.ToDouble(txtTrosak.Text));
                    }
                    if (tRacun != Convert.ToDouble(txtRacun.Text))
                    {
                        insL.InsLog(Convert.ToInt32(txtSifra.Text), "Update zaglavlje Racun", Korisnik, DateTime.Now, Convert.ToDouble(tRacunPrvi), Convert.ToDouble(tRacun), Convert.ToDouble(txtRacun.Text));
                    } 
                    if (tKartica != Convert.ToDouble(txtKartica.Text))
                    {
                            insL.InsLog(Convert.ToInt32(txtSifra.Text), "Update zaglavlje Kartica", Korisnik, DateTime.Now, Convert.ToDouble(tKarticaPrvi), Convert.ToDouble(tKartica), Convert.ToDouble(txtKartica.Text));
                    }
                 }


                    /*
                    int i = ProveraPromeneDodatniTrosak(txtSifra.Text);
                    int j = ProveraPromeneTekuciRacuni(txtSifra.Text);
                    int k = ProveraPromeneKartica(txtSifra.Text);
                    */
                    //  insL.InsLog(Convert.ToInt32(txtSifra.Text), "Update zaglavlje", Korisnik);
                    //Ovde treba zapamtiti menjanje troškova
                }
        }
        private void VratiVrednostiPrvi()
        {
            //p
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select ID, UkupniTroskovi, Racun, Kartica from AktivnostiPrvi where ID = " + Convert.ToInt32(txtSifra.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tUkupniTroskoviPrvi = Convert.ToDouble(dr["UkupniTroskovi"].ToString());
                tRacunPrvi = Convert.ToDouble(dr["Racun"].ToString());
                tKarticaPrvi = Convert.ToDouble(dr["Kartica"].ToString());
               
            }

            con.Close();
        }


        private void VratiVrednostiZadnji()
        {
            tUkupniTroskovi = -1;
            tRacun = -1;
            tKartica = -1;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select ID, UkupniTroskovi, Racun, Kartica from Aktivnosti where ID = " + Convert.ToInt32(txtSifra.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tUkupniTroskovi = Convert.ToDouble(dr["UkupniTroskovi"].ToString());
                tRacun = Convert.ToDouble(dr["Racun"].ToString());
                tKartica = Convert.ToDouble(dr["Kartica"].ToString());

            }

            con.Close();
        }



        public Tuple<int> StoredProcWithOutPutParameter(int clientId, DateTime DatumOd, DateTime DatumDo)
        {
            
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ProveriAktivnostPostoji";
            cmd.Parameters.AddWithValue("@ID", clientId);
            cmd.Parameters.AddWithValue("@DatumOd", DatumOd);
            cmd.Parameters.AddWithValue("@DatumDo", DatumDo);

            cmd.Parameters.Add("@Postoji", SqlDbType.Int);
            cmd.Parameters["@Postoji"].Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                //Storing the output parameters value in 3 different variables.  
                Postoji = Convert.ToInt32(cmd.Parameters["@Postoji"].Value);
                //clientName = Convert.ToString(cmd.Parameters["@ClientName"].Value);
                // dateCreated = Convert.ToDateTime(cmd.Parameters["@DateCreated"].Value);
                // Here we get all three values from database in above three variables.  
            }
            catch (Exception ex)
            {
                // throw the exception  
            }
            finally
            {
                conn.Close();
            }
            return new Tuple<int>(Postoji);
        }

        private void RefreshDataGridNadlezniMasinovodja()
        {
            var select = "select AktivnostiStavke.ID, AktivnostiStavke.IdNadredjena, VrstaAktivnosti.Naziv, Sati, BrojVagona, koeficijent, napomena, " +
           " razlog, (Cast(nalogodavac as nvarchar(3)) + ' - ' + Rtrim(D1.DePriimek) + ' ' + Rtrim(D1.DeIme)) as Nalogodavac, vozilo, " +
            "  Posao, " +
            " (Cast(nadlezni as nvarchar(3)) + ' - ' + Rtrim(D2.DePriimek) + ' ' + Rtrim(D2.DeIme)) as Nadlezni " +
            " from AktivnostiStavke " +
           " inner join VrstaAktivnosti on VrstaAktivnosti.ID = aKTIVNOSTIsTAVKE.VrstAAktivnostiID " +
           " inner " +
           " join Delavci as D1 on D1.DeSifra = AktivnostiStavke.Nalogodavac " +
           " inner " +
           " join Delavci as D2 on D2.DeSifra = AktivnostiStavke.Nadlezni" +
               " where Nadlezni = " + Convert.ToInt32(cboZaposleni.SelectedValue) + " Order by AktivnostiStavke.ID ";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView3.BackgroundColor = Color.White;

            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "ID Stavke";
            dataGridView3.Columns[0].Width = 60;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "ID smene";
            dataGridView3.Columns[1].Width = 60;

            
            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Naziv";
            dataGridView3.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Sati";
            dataGridView3.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Broj vagona";
            dataGridView3.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Koef";
            dataGridView3.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Napomena";
            dataGridView3.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Razlog";
            dataGridView3.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Nalogodavac";
            dataGridView3.Columns[8].Width = 100;

            DataGridViewColumn column10 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "Vozilo";
            dataGridView3.Columns[9].Width = 100;

            DataGridViewColumn column12 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Posao";
            dataGridView3.Columns[10].Width = 80;

            DataGridViewColumn column13 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Nadležni";
            dataGridView3.Columns[11].Width = 100;

        }

        private void RefreshDataGrid()
        {
            // select ID, Naziv from VrstaAktivnosti 
// inner join PravoAktivnosti on VrstaAktivnosti.ID = PravoAktivnosti.VrstaAktivnostiID
 //and PravoAktivnosti.Zaposleni = cboZaposleni.SelectedValue
            var select = "  select ID, Naziv from VrstaAktivnosti " +
             " inner join PravoAktivnosti on VrstaAktivnosti.ID = PravoAktivnosti.VrstaAktivnostiID " +
             " where VrstaAktivnosti.ObracunPoSatu=0   and PravoAktivnosti.Zaposleni = " + cboZaposleni.SelectedValue;

            //var select = "select ID, Naziv from VrstaAktivnosti where ObracunPoSatu=0 and ID <> 24";
           
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
            dataGridView2.Columns[1].HeaderText = "Naziv";
            dataGridView2.Columns[1].Width = 300;

         
        }

        private void RefreshDataGridDnevnice()
        {
            var select = "  select ID, Naziv from VrstaAktivnosti where ObracunPoSatu = 0  and ID <> 27";

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
            dataGridView2.Columns[1].HeaderText = "Naziv";
            dataGridView2.Columns[1].Width = 300;


        }

        private void RefreshDataGridPoAktivnostima()
        {
            var select = "select VrstaAktivnosti.Naziv, Sati, BrojVagona, koeficijent, napomena, " +
            " razlog, (Cast(nalogodavac as nvarchar(3)) + ' - ' + Rtrim(D1.DePriimek) + ' ' + Rtrim(D1.DeIme)) as Nalogodavac, vozilo, " +
             " AktivnostiStavke.ID, Posao, " +
             " (Cast(nadlezni as nvarchar(3)) + ' - ' + Rtrim(D2.DePriimek) + ' ' + Rtrim(D2.DeIme)) as Nadlezni " +
             " from AktivnostiStavke " +
            " inner join VrstaAktivnosti on VrstaAktivnosti.ID = aKTIVNOSTIsTAVKE.VrstAAktivnostiID " +
            " inner " +
            " join Delavci as D1 on D1.DeSifra = AktivnostiStavke.Nalogodavac " +
            " inner " +
            " join Delavci as D2 on D2.DeSifra = AktivnostiStavke.Nadlezni" +
                " where IDNadredjena = " + Convert.ToInt32(txtSifra.Text);

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
            dataGridView1.Columns[0].HeaderText = "Naziv";
            dataGridView1.Columns[0].Width = 200;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Sati";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Broj vagona";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Koef";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Napomena";
            dataGridView1.Columns[4].Width = 120;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Razlog";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Nalogodavac";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Vozilo";
            dataGridView1.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "ID";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Posao";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Nadležni maš.";
            dataGridView1.Columns[10].Width = 100;

        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            if (dtpVremeOd.Value < Convert.ToDateTime(DatumZakljucavanja))
            {
                MessageBox.Show("Nije dozvoljen unos posle datuma zaključavanja");
                return;

            }
            if (txtBrojVagona.Text == "0")
            {
                MessageBox.Show("Potrebno je uneti broj vagona");
                return;
            }
            int pomID = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                InsertAktivnostiStavke ins = new InsertAktivnostiStavke();
                if (txtDodatnaNapomena.Text == "")
                    txtDodatnaNapomena.Text = " ";
                if (row.Selected == true)
                {
                  //  chkUnetaAktivnost.Checked = true;
                    ins.InsAktivnostiStavke(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToDouble(txtRad.Text), Convert.ToDouble(txtKoeficijent.Text), txtDodatnaNapomena.Text, Convert.ToInt32(txtBrojVagona.Text), txtRazlog.Text, Convert.ToInt32(cboNalogodavac.SelectedValue), cboVozilo.Text, Convert.ToInt32(txtPosao.Text), dtpStavke.Value, Convert.ToInt32(cboNadlezni.SelectedValue));
                    pomID = Convert.ToInt32(row.Cells[0].Value.ToString());
                    if (chkPravoDnevnice.Checked == true)
                    {
                        IzracunPoDnevnici(pomID);
                    }
                    else
                    {
                        IzracunPoStarom(pomID);
                    }
                  
                }
                InsertLogAktivnosti insL = new InsertLogAktivnosti();
                //insL.InsLog(Convert.ToInt32(txtSifra.Text), "Ubacivanje stavke po Vagonu", Korisnik);
                    // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
            }

            
         
            
            RefreshDataGridPoAktivnostima();
            
            status = false;
        }

        private void IzracunPoStarom(int pomID)
        {
            int Smena = 1;  //Polusmena
         

            // ins.InsAktivnostiStavke(Convert.ToInt32(txtSifra.Text),  Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, Convert.ToDouble(txtVreme.Text), Convert.ToDouble(txtTrosak.Text), txtKomentar.Text, 0);
            double cena = 0;
            double FiksnaCena = 0;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand(" select Cena, Kragujevac,Smederevo, FisnaCena from VrstaAktivnosti where ID  = " + pomID, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cena = Convert.ToDouble(dr[0].ToString());
                    FiksnaCena = Convert.ToDouble(dr[3].ToString());

                }
            }
            conn.Close();
            double vrd = (Convert.ToDouble(txtBrojVagona.Text) * cena) + FiksnaCena;
            double pom = Convert.ToDouble(txtIzracun.Text);
            pom = pom + vrd;
            txtIzracun.Text = pom.ToString();
            txtRazlika.Text = "0";
            txtZarada.Text =  txtIzracun.Text;
        }

        private void IzracunPoDnevnici(int pomID)
        {
            int Smena = 1;  //Polusmena
            if (Convert.ToDouble(txtVreme.Text) <= 7)
            {
                Smena = 1;

            }
            else
            {
                Smena = 2;
            }

            // ins.InsAktivnostiStavke(Convert.ToInt32(txtSifra.Text),  Convert.ToInt32(cboZaposleni.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, Convert.ToDouble(txtVreme.Text), Convert.ToDouble(txtTrosak.Text), txtKomentar.Text, 0);
            double cena = 0;
            double FiksnaCena = 0;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand(" select Cena, Kragujevac,Smederevo, FisnaCena from VrstaAktivnosti where ID  = " + pomID, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cena = Convert.ToDouble(dr[0].ToString());
                    FiksnaCena = Convert.ToDouble(dr[3].ToString());
                }
            }
            conn.Close();
            double vrd = Convert.ToDouble(txtBrojVagona.Text) * cena + FiksnaCena;
            double pom = Convert.ToDouble(txtIzracun.Text);
            pom = pom + vrd;
            txtIzracun.Text = pom.ToString();
            if ((pom < 21) & (Smena == 1))
            {
                double Razlika = 21 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "21";
            }
            else if ((pom < 21) & (Smena == 2))
            {
                double Razlika = 21 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "21";
            }
            else if ((pom > 21) & (Smena == 1))
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
            }
            else if ((pom < 42) & (Smena == 2))
            {
                double Razlika = 42 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "42";
            }
            else if ((pom > 42) & (Smena == 2))
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
            }
        }

        private void btnUbaciAktivnost_Click(object sender, EventArgs e)
        {
            if (dtpVremeOd.Value < Convert.ToDateTime(DatumZakljucavanja))
            {
                MessageBox.Show("Nije dozvoljen unos posle datuma zaključavanja");
                return;

            }
            int Nalogodavac = 0;
              //  chkUnetaAktivnost.Checked = true;
                InsertAktivnostiStavke ins = new InsertAktivnostiStavke();
                if (txtDodatnaNapomena.Text == "")
                    txtDodatnaNapomena.Text = " ";

                if (cboNalogodavac.Text == "")
                    Nalogodavac = 0;
                else
                    Nalogodavac = Convert.ToInt32(cboNalogodavac.SelectedValue);

                chkUnetaAktivnost.Checked = true;
                ins.InsAktivnostiStavke(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboAktivnost.SelectedValue), Convert.ToDouble(txtRad.Text), Convert.ToDouble(txtKoeficijent.Text), txtDodatnaNapomena.Text, Convert.ToInt32(txtBrojVagona.Text), txtRazlog.Text, Nalogodavac, cboVozilo.Text, Convert.ToInt32(txtPosao.Text), dtpStavke.Value, Convert.ToInt32(cboNadlezni.SelectedValue));
               

                if (chkPravoDnevnice.Checked == true)
                {
                    IzracunPoDnevniciSati();
                }
                else
                {
                    IzracunPoStaromSati();
                }

            InsertLogAktivnosti insL = new InsertLogAktivnosti();
          //  insL.InsLog(Convert.ToInt32(txtSifra.Text), "Ubacivanje stavke po Satu", Korisnik);

            RefreshDataGridPoAktivnostima();     
        
        }

        private void IzracunPoStaromSati()
        {
            int Smena = 1;  //Polusmena
            if (Convert.ToDouble(txtVreme.Text) <= 7)
            {
                Smena = 1;
            }
            else
            {
                Smena = 2;
            }
            double cena = 0;
            int KG = 0;
            int SM = 0;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand(" select Cena, Kragujevac,Smederevo from VrstaAktivnosti where ID  = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cena = Convert.ToDouble(dr[0].ToString());
                    KG = Convert.ToInt32(dr[1].ToString());
                    SM = Convert.ToInt32(dr[2].ToString());
                }
            }
            conn.Close();
            double vrd = Convert.ToDouble(txtRad.Text) * cena;
            double pom = Convert.ToDouble(txtIzracun.Text);
            pom = pom + vrd;
            txtIzracun.Text = pom.ToString();
            double Razlika = 0;
            txtRazlika.Text = Razlika.ToString();
            txtZarada.Text = txtIzracun.Text;
            RefreshDataGridPoAktivnostima();
        }

        private void IzracunPoDnevniciSatiSve()
        {
            int Smena = 1;  //Polusmena
            if (Convert.ToDouble(txtVreme.Text) <= 7)
            {
                Smena = 1;
            }
            else
            {
                Smena = 2;
            }
            double cena = 0;
            double FiksnaCena = 0;
            int KG = 0;
            int SM = 0;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand(" select Cena, Kragujevac,Smederevo, FisnaCena from VrstaAktivnosti where ID  = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cena = Convert.ToDouble(dr[0].ToString());
                    KG = Convert.ToInt32(dr[1].ToString());
                    SM = Convert.ToInt32(dr[2].ToString());
                    FiksnaCena = Convert.ToDouble(dr[3].ToString());
                }
            }
            conn.Close();
            double vrd = (Convert.ToDouble(txtRad.Text) * cena) + FiksnaCena;
            double pom = Convert.ToDouble(txtIzracun.Text);
            pom = pom + vrd;
            txtIzracun.Text = pom.ToString();
            if (KG == 1)
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
                RefreshDataGridPoAktivnostima();

            }
            if (SM == 1)
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
                RefreshDataGridPoAktivnostima();

            }
            if ((pom < 21) & (Smena == 1))
            {
                double Razlika = 21 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "21";
            }
            else if ((pom < 21) & (Smena == 2))
            {
                double Razlika = 21 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "21";
            }
            else if ((pom > 21) & (Smena == 1))
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
            }
            else if ((pom < 42) & (Smena == 2))
            {
                double Razlika = 42 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "42";
            }
            else if ((pom > 42) & (Smena == 2))
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
            }
        }
        //Panta 2
        private void IzracunPoDnevniciSatiRefresh(int IDStavke)
        {
            int Smena = 1;  //Polusmena
            if (Convert.ToDouble(txtVreme.Text) <= 7)
            {
                Smena = 1;
            }
            else
            {
                Smena = 2;
            }

            int VrstaAktivnostiID = 0;
            double Sati = 0;
            double BrojVagona = 0;
            double Koeficijent = 0;



            double cena = 0;
            double FiksnaCena = 0;
            int KG = 0;
            int SM = 0;


            //Izvlacenje Vrste Aktivnosti, Sati, Koeficijenta, BrojaVagona
          

            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn2 = new SqlConnection(s_connection2);
            conn2.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd2 = new SqlCommand(" select VrstaAktivnostiID, Sati,BrojVagona, Koeficijent from AktivnostiStavke where ID  = " + IDStavke, conn2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    VrstaAktivnostiID = Convert.ToInt32(dr2[0].ToString());
                    Sati = Convert.ToDouble(dr2[1].ToString());
                    BrojVagona = Convert.ToDouble(dr2[2].ToString());
                    Koeficijent = Convert.ToDouble(dr2[3].ToString());
                }
            }
            conn2.Close();

           
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand(" select Cena, Kragujevac,Smederevo, FisnaCena from VrstaAktivnosti where ID  = " + VrstaAktivnostiID, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cena = Convert.ToDouble(dr[0].ToString());
                    KG = Convert.ToInt32(dr[1].ToString());
                    SM = Convert.ToInt32(dr[2].ToString());
                    FiksnaCena = Convert.ToDouble(dr[3].ToString());
                }
            }
            conn.Close();
            double vrd = 0;
            if (VrstaAktivnostiID != 43)
            { 
                vrd = (Sati * cena * (Koeficijent / 100)) + FiksnaCena + BrojVagona * cena * (Koeficijent / 100) ;
            }
            else
            {
                vrd = 0;

            }
            double pom = Convert.ToDouble(txtIzracun.Text);
            pom = pom + vrd;
            txtIzracun.Text = pom.ToString();
           
            if ((pom < 21) & (Smena == 1))
            {
                double Razlika = 21 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "21";
            }
            else if ((pom < 21) & (Smena == 2))
            {
                double Razlika = 21 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "21";
            }
            else if ((pom > 21) & (Smena == 1))
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
            }
            else if ((pom < 42) & (Smena == 2))
            {
                double Razlika = 42 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "42";
            }
            else if ((pom > 42) & (Smena == 2))
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
            }
        }

        private void IzracunPoDnevniciSati()
        {
            int Smena = 1;  //Polusmena
            if (Convert.ToDouble(txtVreme.Text) <= 7)
            {
                Smena = 1;
            }
            else
            {
                Smena = 2;
            }
            double cena = 0;
            double FiksnaCena = 0;
            int KG = 0;
            int SM = 0;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand(" select Cena, Kragujevac,Smederevo, FisnaCena from VrstaAktivnosti where ID  = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cena = Convert.ToDouble(dr[0].ToString());
                    KG = Convert.ToInt32(dr[1].ToString());
                    SM = Convert.ToInt32(dr[2].ToString());
                    FiksnaCena = Convert.ToDouble(dr[3].ToString());
                }
            }
            conn.Close();
            double vrd = (Convert.ToDouble(txtRad.Text) * cena) + FiksnaCena;
            double pom = Convert.ToDouble(txtIzracun.Text);
            pom = pom + vrd;
            txtIzracun.Text = pom.ToString();
            if (KG == 1)
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
                RefreshDataGridPoAktivnostima();

            }
            if (SM == 1)
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
                RefreshDataGridPoAktivnostima();

            }
            if ((pom < 21) & (Smena == 1))
            {
                double Razlika = 21 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "21";
            }
            else if ((pom < 21) & (Smena == 2))
            {
                double Razlika = 21 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "21";
            }
            else if ((pom > 21) & (Smena == 1))
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
            }
            else if ((pom < 42) & (Smena == 2))
            {
                double Razlika = 42 - pom;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = "42";
            }
            else if ((pom > 42) & (Smena == 2))
            {
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpVremeDo_Leave(object sender, EventArgs e)
        {
            TimeSpan span = dtpVremeDo.Value.Subtract(dtpVremeOd.Value);
            txtVreme.Text = Convert.ToString(Math.Round(Convert.ToDouble(span.TotalHours),2));
            if (Math.Round(Convert.ToDouble(span.TotalHours), 2) > 16)
            {
                MessageBox.Show("Ne možete uneti smenu veću od 16 sati");
            }
            
            if (Math.Round(Convert.ToDouble(span.TotalHours), 2) < 7)
            {
                txtUkupnoMašinovođa.Text = "6";
            }

            else
            {
                txtUkupnoMašinovođa.Text = "12";
            }

           // Math.Round(inputValue, 2);
        }

        private void cboAktivnost_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cboAktivnost_Leave(object sender, EventArgs e)
        {

            int ObracunPoSatu = 0; int PotrebanRazlog = 0; int PotrebanNalogodavac = 0; int PotrebnoVozilo = 0; int ObaveznaNapomena = 0;
            txtRad.Text = "0";
            txtBrojVagona.Text = "0";
            cboNalogodavac.SelectedValue = 0;
            txtDodatnaNapomena.Text = "";
            cboVozilo.Text = "";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
           // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand("select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ObracunPoSatu = Convert.ToInt32(dr[0].ToString());
                    PotrebanRazlog = Convert.ToInt32(dr[1].ToString());
                    PotrebanNalogodavac = Convert.ToInt32(dr[2].ToString());
                    PotrebnoVozilo = Convert.ToInt32(dr[3].ToString());
                    ObaveznaNapomena = Convert.ToInt32(dr[4].ToString());
                }
            }
            conn.Close();
            /*
            if  (ObracunPoSatu == 1)
                txtRad.Enabled = true;
            if (PotrebanRazlog == 1)
            { 
                txtRazlog.Enabled = true;
            }    
            else
            {
                txtRazlog.Enabled = false;
            }
                 
            if (PotrebanNalogodavac == 1)
                txtDodatnaNapomena.Enabled = true;
            else
            {
                txtDodatnaNapomena.Enabled = false;
            }
            if (PotrebnoVozilo  == 1)
                cboVozilo.Enabled = true;
            else
            {
                cboVozilo.Enabled = false;
            }
             * */
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnPosaljiMail_Click(object sender, EventArgs e)
        {
            try
            {
                string zadnjibroj = txtSifra.Text;

                string mail = txtEmail.Text.TrimEnd();

                mailMessage = new MailMessage("zaposleni@kprevoz.co.rs", mail);

                mailMessage.Subject = "Uneti podaci za smenu ";

                var select = "Select ID, Rtrim(Delavci.DePriimek) + ' ' + RTrim(Delavci.DeIme) as Zaposleni, " +
                " VremeOd, VremeDo, Ukupno, UkupniTroskovi, Opis, RN, Oznaka, " +
                " Racun, Kartica, Izracun, Razlika, Zarada " +
                " from Aktivnosti " + 
                " inner join Delavci on Aktivnosti.Zaposleni = Delavci.DeSifra " +
                " where ID = " + Convert.ToInt32(txtSifra.Text);

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                string body = "Spisak unetih aktivnosti za:  <br />";

              
                foreach (DataRow myRow in ds.Tables[0].Rows)
                {
                    body = body + "Zaposleni: " + myRow["Zaposleni"].ToString()  + "<br /> ";
                    body = body + "Vreme: " + myRow["VremeOd"].ToString() + " - " + myRow["VremeDo"].ToString() + " Ukupno:" + myRow["Ukupno"].ToString() + "H" +"<br /> ";

                    body = body + "TROŠAK: " + "<br /> ";
                    body = body + "Dodatni troškovi: " + myRow["UkupniTroskovi"].ToString() + "<br /> ";
                    body = body + "Računi: " + myRow["Racun"].ToString() + "<br /> ";
                    body = body + "Kartica: " + myRow["Kartica"].ToString() + "<br /> " + "<br /> ";

                    if (Convert.ToDouble(myRow["Izracun"].ToString()) == Convert.ToDouble(myRow["Zarada"].ToString()))
                    {
                        body = body + "Zarada: " + myRow["Zarada"].ToString() + "<br /> ";
                    }
                    else
                    {
                        body = body + "Po učinku: " + myRow["Izracun"].ToString() + "<br /> ";
                        body = body + "Zarada: " + myRow["Zarada"].ToString() + "<br /> ";
                    }
                    
                    
                    body = body + "Napomena: " + myRow["Opis"].ToString() + "<br /> <br />";
                }


                var select2 = " select VrstaAktivnosti.Naziv as Naziv, AktivnostiStavke.Sati as Sati, AktivnostiStavke.BrojVagona, " +
               " AktivnostiStavke.Razlog, Rtrim(Delavci.DePriimek) + ' ' + RTrim(Delavci.DeIme) as Nalogodavac, " +
                " AktivnostiStavke.Vozilo, AktivnostiStavke.Napomena, VrstaAktivnosti.ObracunPoSatu, VrstaAktivnosti.Cena, VrstaAktivnosti.Id,AktivnostiStavke.Koeficijent from AktivnostiStavke " +
               " inner join VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " +
               " Left join Delavci on AktivnostiStavke.Nalogodavac = Delavci.DeSifra " +
               " where IDNadredjena = " + Convert.ToInt32(txtSifra.Text);


                var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection2 = new SqlConnection(s_connection2);
                var c2 = new SqlConnection(s_connection2);
                var dataAdapter2 = new SqlDataAdapter(select2, c2);

                var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
                var ds2 = new DataSet();
                dataAdapter2.Fill(ds2);

                foreach (DataRow myRow2 in ds2.Tables[0].Rows)
                {
                    body = body + "<br />"; 
                    body = body + "Aktivnost: " + myRow2["Naziv"].ToString() + "<br />";
                    if (Convert.ToInt32(myRow2["ID"].ToString()) == 43)
                    {
                        double pom = 0;
                        pom = Convert.ToDouble(myRow2["Sati"].ToString()) * Convert.ToDouble(myRow2["Koeficijent"].ToString()) * 0.01;
                       // body = body + "Sati: " + myRow2["Sati"].ToString() + " H " + "<br />";
                        body = body + "Zarada aktivnost: " + pom.ToString() + "<br />";
                    }
                    else if (Convert.ToInt32(myRow2["ObracunPoSatu"].ToString()) == 1)
                    {
                        double pom = 0;
                        pom = Convert.ToDouble(myRow2["Sati"].ToString()) * Convert.ToDouble(myRow2["Cena"].ToString());
                        body = body + "Sati: " + myRow2["Sati"].ToString() + " H " + "<br />";
                        body = body + "Zarada aktivnost: " + pom.ToString() + "<br />";
                    }
                    else
                    {
                        double pom = 0;
                        pom = Convert.ToDouble(myRow2["BrojVagona"].ToString()) * Convert.ToDouble(myRow2["Cena"].ToString());
                        body = body + "Broj vagona: " + myRow2["BrojVagona"].ToString() + " VAG " + "<br />";
                        body = body + "Zarada aktivnost: " + pom.ToString() + "<br />";
                    }
//  if (Convert.ToDouble(myRow2["Sati"].ToString()) != 0)
                     
// if (Convert.ToInt32(myRow2["BrojVagona"].ToString()) != 0)
  //                      body = body + "Broj vagona: " + myRow2["BrojVagona"].ToString() + " VAG " +"<br />";
                 
                    if (myRow2["Razlog"].ToString() != "")
                        body = body + "Razlog: " + myRow2["Razlog"].ToString() + "<br />"; 
                    if (myRow2["Nalogodavac"].ToString() != "")
                        body = body + "Nalogodavac: " + myRow2["Nalogodavac"].ToString() + "<br />"; 
                    if (myRow2["Vozilo"].ToString() != "")
                        body = body + "Vozilo: " + myRow2["Vozilo"].ToString() + "<br />"; 
                    if (myRow2["Napomena"].ToString().TrimEnd() != "")
                        body = body + "Napomena: " + myRow2["Napomena"].ToString() + "<br />  <br />"; ;
                    
                }

                body = body + "<br /> <br /> ";

                body = body + "S poštovanjem" + "<br />";
                body = body + "Dispičerska služba RTC LUKA LEGET" + "<br />" + "<br />" + "<br />";

                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "mail.kprevoz.co.rs";

                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("pantelija.petrovic@kprevoz.co.rs", "pele0307.pantelija.petrovic");

                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);


                InsertAktivnosti ins = new InsertAktivnosti();
                ins.UpdatePoslaoMailAktivnosti(Convert.ToInt32(txtSifra.Text));
                chkPoslatMail.Checked = true;

                InsertLogAktivnosti insL = new InsertLogAktivnosti();
               // insL.InsLog(Convert.ToInt32(txtSifra.Text), "Brisanje stavke", Korisnik);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void VratiMoguceAktivnosti()
        { 
        // refresh cbo
        //refresh datagrid
            var select4 = "  select ID, Naziv from VrstaAktivnosti " +
           " inner join PravoAktivnosti on VrstaAktivnosti.ID = PravoAktivnosti.VrstaAktivnostiID " +
           " where VrstaAktivnosti.ObracunPoSatu=1   and PravoAktivnosti.Zaposleni = " + cboZaposleni.SelectedValue;


          //  var select4 = " select ID, Naziv from VrstaAktivnosti where ObracunPoSatu = 1 and Dnevnica = 1";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboAktivnost.DataSource = ds4.Tables[0];
            cboAktivnost.DisplayMember = "Naziv";
            cboAktivnost.ValueMember = "ID";

            RefreshDataGrid();
        }

        private void cboZaposleni_Leave(object sender, EventArgs e)
        {
            VratiEmail();
            VratiMoguceAktivnosti();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InsertAktivnosti ins = new InsertAktivnosti();
           // ins.UpdateAktivnostiPlaceno(Convert.ToInt32(txtSifra.Text));
            chkPlaceno.Checked = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            InsertAktivnosti ins = new InsertAktivnosti();
            ins.UpdateAktivnostiKontrolisanoSpoljno(Convert.ToInt32(txtSifra.Text));

            InsertLogAktivnosti insL = new InsertLogAktivnosti();
           // insL.InsLog(Convert.ToInt32(txtSifra.Text), "Kontrolisano outside", Korisnik);
            // chkPlaceno.Checked = true;
            /*
            frmEvidencijaRadaDokumenti frmER = new frmEvidencijaRadaDokumenti(txtSifra.Text);
            frmER.Show();
            */

        }

        private void cboTIpRada_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Panta
            /*
            if (cboTIpRada.SelectedIndex == 0)
            {
             var select4 = " select ID, Naziv from VrstaAktivnosti where ObracunPoSatu = 1 and Dnevnica = 1";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboAktivnost.DataSource = ds4.Tables[0];
            cboAktivnost.DisplayMember = "Naziv";
            cboAktivnost.ValueMember = "ID";
            RefreshDataGrid();
            
            
            }
            else if (cboTIpRada.SelectedIndex == 1)
            {
                var select4 = " select ID, Naziv from VrstaAktivnosti where ObracunPoSatu = 1 and Dnevnica = 0";
                var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection4 = new SqlConnection(s_connection4);
                var c4 = new SqlConnection(s_connection4);
                var dataAdapter4 = new SqlDataAdapter(select4, c4);

                var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
                var ds4 = new DataSet();
                dataAdapter4.Fill(ds4);
                cboAktivnost.DataSource = ds4.Tables[0];
                cboAktivnost.DisplayMember = "Naziv";
                cboAktivnost.ValueMember = "ID";
                RefreshDataGrid();
            }
            else
            {
                var select4 = " select ID, Naziv from VrstaAktivnosti where ObracunPoSatu = 1 and Milsped = 1";
                var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection4 = new SqlConnection(s_connection4);
                var c4 = new SqlConnection(s_connection4);
                var dataAdapter4 = new SqlDataAdapter(select4, c4);

                var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
                var ds4 = new DataSet();
                dataAdapter4.Fill(ds4);
                cboAktivnost.DataSource = ds4.Tables[0];
                cboAktivnost.DisplayMember = "Naziv";
                cboAktivnost.ValueMember = "ID";

                RefreshDataGridDnevnice(); //Samo milsped
            }
             * */
        }

        private void cboMestoUpucenja_Leave(object sender, EventArgs e)
        {
            txtMesto.Text = cboMestoUpucenja.SelectedText;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void OduzmiPoDnevnici(int Stavka)
        {
            int Smena = 1;

            if (Convert.ToDouble(txtVreme.Text) <= 7)
            {
                Smena = 1;
            }
            else
            {
                Smena = 2;
            }
            double cena = 0;
            int obracunposatu = 1;
            double sati = 0;
            double koeficijent = 0;
            double brojvagona = 0;
            int vrstaaktivnostiid = 43;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand("select Cena, ObracunPoSatu,Sati, Koeficijent, BrojVagona, VrstaAktivnosti.ID from VrstaAktivnosti " +
            " inner join AktivnostiStavke on VrstaAktivnosti.ID = AktivnostiStavke.VrstaAktivnostiID " +
            " where AktivnostiStavke.ID = " + Stavka, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cena = Convert.ToDouble(dr[0].ToString());
                    obracunposatu = Convert.ToInt32(dr[1].ToString());
                    sati = Convert.ToDouble(dr[2].ToString());
                    koeficijent = Convert.ToDouble(dr[3].ToString());
                    brojvagona = Convert.ToDouble(dr[4].ToString());
                    vrstaaktivnostiid = Convert.ToInt32(dr[5].ToString());
                }
            }
            conn.Close();
            if (vrstaaktivnostiid == 43)
            {
                return;
            }
            if (obracunposatu == 1)
            {
                double vrd = sati * -cena;
                double pom = Convert.ToDouble(txtIzracun.Text);
                pom = pom + vrd;
                txtIzracun.Text = pom.ToString();
                if ((pom < 21) & (Smena == 1))
                {
                    double Razlika = 21 - pom;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = "21";
                }
                else if ((pom < 21) & (Smena == 2))
                {
                    double Razlika = 21 - pom;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = "21";
                }
                else if ((pom > 21) & (Smena == 1))
                {
                    double Razlika = 0;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = txtIzracun.Text;
                }
                else if ((pom < 42) & (Smena == 2))
                {
                    double Razlika = 42 - pom;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = "42";
                }
                else if ((pom > 42) & (Smena == 2))
                {
                    double Razlika = 0;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = txtIzracun.Text;
                }
            }
            else
            {
                // po vagonu
                double vrd = brojvagona * -cena;
                double pom = Convert.ToDouble(txtIzracun.Text);
                pom = pom + vrd;
                txtIzracun.Text = pom.ToString();
                if ((pom < 21) & (Smena == 1))
                {
                    double Razlika = 21 - pom;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = "21";
                }
                else if ((pom < 21) & (Smena == 2))
                {
                    double Razlika = 21 - pom;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = "21";
                }
                else if ((pom > 21) & (Smena == 1))
                {
                    double Razlika = 0;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = txtIzracun.Text;
                }
                else if ((pom < 42) & (Smena == 2))
                {
                    double Razlika = 42 - pom;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = "42";
                }
                else if ((pom > 42) & (Smena == 2))
                {
                    double Razlika = 0;
                    txtRazlika.Text = Razlika.ToString();
                    txtZarada.Text = txtIzracun.Text;
                }

                //end po vagonu
            }

        }

        private void OduzmiBezDnevnice(int Stavka)
        {
            int Smena = 1;

            if (Convert.ToDouble(txtVreme.Text) <= 7)
            {
                Smena = 1;
            }
            else
            {
                Smena = 2;
            }
            double cena = 0;
            int obracunposatu = 1;
            double sati = 0;
            double koeficijent = 0;
            double brojvagona = 0;
            int vrstaaktivnostiid = 43;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand("select Cena, ObracunPoSatu,Sati, Koeficijent, BrojVagona, VrstaAktivnosti.ID from VrstaAktivnosti " +
            " inner join AktivnostiStavke on VrstaAktivnosti.ID = AktivnostiStavke.VrstaAktivnostiID " +
            " where AktivnostiStavke.ID = " + Stavka, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cena = Convert.ToDouble(dr[0].ToString());
                    obracunposatu = Convert.ToInt32(dr[1].ToString());
                    sati = Convert.ToDouble(dr[2].ToString());
                    koeficijent = Convert.ToDouble(dr[3].ToString());
                    brojvagona = Convert.ToDouble(dr[4].ToString());
                    vrstaaktivnostiid = Convert.ToInt32(dr[5].ToString());
                }
            }
            conn.Close();
            if (vrstaaktivnostiid == 43)
            {
                return;
            }
            if (obracunposatu == 1)
            {
                double vrd = sati * -cena;
                double pom = Convert.ToDouble(txtIzracun.Text);
                pom = pom + vrd;
                txtIzracun.Text = pom.ToString();
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
                
            }
            else
            {
                // po vagonu
                double vrd = brojvagona * -cena;
                double pom = Convert.ToDouble(txtIzracun.Text);
                pom = pom + vrd;
                txtIzracun.Text = pom.ToString();
                double Razlika = 0;
                txtRazlika.Text = Razlika.ToString();
                txtZarada.Text = txtIzracun.Text;
               

                //end po vagonu
            }


        }

        private void OduzmiStavku(int Stavka)
        {
            if (chkPravoDnevnice.Checked == true)
            {       
                OduzmiPoDnevnici(Stavka);
            }   
                else
            {
                OduzmiBezDnevnice(Stavka);
            }           
            
         
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpVremeOd.Value < Convert.ToDateTime(DatumZakljucavanja))
                {
                    MessageBox.Show("Nije dozvoljen unos posle datuma zaključavanja");
                    return;

                }
                InsertAktivnostiStavke ins = new InsertAktivnostiStavke();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        OduzmiStavku(Convert.ToInt32(row.Cells[8].Value.ToString()));
                        ins.DeleteAktivnostiStavke(Convert.ToInt32(row.Cells[8].Value.ToString()));
                      
                        RefreshDataGridPoAktivnostima();
                    }
                }
                InsertLogAktivnosti insL = new InsertLogAktivnosti();
                //insL.InsLog(Convert.ToInt32(txtSifra.Text), "Brisanje stavke", Korisnik);
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertAktivnostiStavke ins = new InsertAktivnostiStavke();
            ins.InsAktivnostiStavke(Convert.ToInt32(txtSifra.Text), 43, Convert.ToDouble(1), Convert.ToDouble(Convert.ToDouble(txtRazlika.Text) * 100), "Zaključenje smene", 0, "", 1, "", 0, dtpStavke.Value,0);
            InsertAktivnosti insA = new InsertAktivnosti();
            insA.UpdAktivnostiZarada(Convert.ToInt32(txtSifra.Text), Convert.ToDouble(txtIzracun.Text), Convert.ToDouble(txtRazlika.Text), Convert.ToDouble(txtZarada.Text));
            InsertLogAktivnosti insL = new InsertLogAktivnosti();
          //  insL.InsLog(Convert.ToInt32(txtSifra.Text), "Kraj unosa", Korisnik);
            RefreshDataGridPoAktivnostima();
        

           

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmEvidencijaRadaDokumenti frmER = new frmEvidencijaRadaDokumenti(txtSifra.Text);
            frmER.Show();
        }
        private void IzracunPoStaromRefresh(int IDStavke)
        {
            int VrstaAktivnostiID = 0;
            double Sati = 0;
            double BrojVagona = 0;
            double Koeficijent = 0;



            double cena = 0;
            double FiksnaCena = 0;
            int KG = 0;
            int SM = 0;


            //Izvlacenje Vrste Aktivnosti, Sati, Koeficijenta, BrojaVagona


            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn2 = new SqlConnection(s_connection2);
            conn2.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd2 = new SqlCommand(" select VrstaAktivnostiID, Sati,BrojVagona, Koeficijent from AktivnostiStavke where ID  = " + IDStavke, conn2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    VrstaAktivnostiID = Convert.ToInt32(dr2[0].ToString());
                    Sati = Convert.ToDouble(dr2[1].ToString());
                    BrojVagona = Convert.ToDouble(dr2[2].ToString());
                    Koeficijent = Convert.ToDouble(dr2[3].ToString());
                }
            }
            conn2.Close();


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            // SqlCommand command = new SqlCommand(" select ObracunPoSatu, PotrebanRazlog, PotrebanNalogodavac, PotrebnoVozilo, ObaveznaNapomena from VrstaAktivnosti where ID = " + Convert.ToInt32(cboAktivnost.SelectedValue), conn);
            SqlCommand cmd = new SqlCommand(" select Cena, Kragujevac,Smederevo, FisnaCena from VrstaAktivnosti where ID  = " + VrstaAktivnostiID, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cena = Convert.ToDouble(dr[0].ToString());
                    KG = Convert.ToInt32(dr[1].ToString());
                    SM = Convert.ToInt32(dr[2].ToString());
                    FiksnaCena = Convert.ToDouble(dr[3].ToString());
                }
            }
            conn.Close();
            double vrd = 0;
            if (VrstaAktivnostiID != 43)

            { vrd = (Sati * cena * (Koeficijent / 100)) + FiksnaCena + BrojVagona * cena * (Koeficijent / 100); }
            else
            {
                vrd = 0;
            
            }    
            double pom = Convert.ToDouble(txtIzracun.Text);
            pom = pom + vrd;
            txtIzracun.Text = pom.ToString();
            txtRazlika.Text = "0";
            txtZarada.Text = txtIzracun.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            txtIzracun.Text = "0";
            txtRazlika.Text = "0";
            txtZarada.Text = "0";

            //Panta
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (chkPravoDnevnice.Checked == true)
                { 
                IzracunPoDnevniciSatiRefresh(Convert.ToInt32(row.Cells[8].Value.ToString()));
                }
                else
                {
                IzracunPoStaromRefresh(Convert.ToInt32(row.Cells[8].Value.ToString()));
                }
                // ins.UpdUkupnoUEUR(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToDouble(txtZarada.Value));
                   
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
              
                InsertAktivnostiStavke ins = new InsertAktivnostiStavke();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                       
                        ins.PromeniSati(Convert.ToInt32(row.Cells[8].Value.ToString()), Convert.ToDouble(txtRad.Value));

                        RefreshDataGridPoAktivnostima();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            RefreshDataGridNadlezniMasinovodja();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                InsertAktivnostiStavke ins = new InsertAktivnostiStavke();

                if (row.Selected == true)
                {

                    ins.InsAktivnostiStavkeMas(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(txtSifra.Text));

                }   

                // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
            }
            RefreshDataGridPoAktivnostima();
           
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmLogAktivnosti la = new frmLogAktivnosti(txtSifra.Text);
            la.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
//Panta
                InsertAktivnostiStavke ins = new InsertAktivnostiStavke();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {

                        ins.PromeniKoeficijent(Convert.ToInt32(row.Cells[8].Value.ToString()), Convert.ToDouble(txtKoeficijent.Text));

                        RefreshDataGridPoAktivnostima();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsNapred_Click(object sender, EventArgs e)
        {

        }
    }

        /* protected void Submit(object sender, EventArgs e)
         {




             string constring = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
             using (SqlConnection con = new SqlConnection(constring))
             {
                 using (SqlCommand cmd = new SqlCommand("ProveriUnos", con))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@Zaposleni", cboZaposleni.SelectedValue());
                     cmd.Parameters.Add("@Postoji", SqlDbType.Int);
                     cmd.Parameters["@Postoji"].Direction = ParameterDirection.Output;
                     con.Open();
                     cmd.ExecuteNonQuery();
                     con.Close();
                     string test;
                     test= "Fruit Name: " + cmd.Parameters["@Postoji"].Value.ToString();
                 }
             }

         }
           * */


    }

