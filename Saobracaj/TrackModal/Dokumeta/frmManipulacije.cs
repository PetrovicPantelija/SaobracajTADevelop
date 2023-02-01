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
//Panta
namespace Testiranje.Dokumeta
{
    public partial class frmManipulacije : Form
    {
        string KorisnikCene;
        int pomPrijemnica = 0;
        int pomVozom = 0;
        int IzPrijemnice = 0;
        //  bool status = false;
        public frmManipulacije()
        {
            InitializeComponent();
        }

        public frmManipulacije(string Korisnik)
        {
            KorisnikCene = Korisnik;
            InitializeComponent();
        }

        public frmManipulacije(string Korisnik, int PrijemnicaOtpremnica, int Vozom, int IzPrijema)
        {
            if (IzPrijema == 0)
            {
                IzPrijemnice = 0; //Podatak dosao iz Prijema
            }
            else
            {
                IzPrijemnice = 1; // Podatak Dosao iz Otpreme
            }
            pomPrijemnica = PrijemnicaOtpremnica;
            pomVozom = Vozom;
            KorisnikCene = Korisnik;
            InitializeComponent();
        }

        private void frmManipulacije_Load(object sender, EventArgs e)
        {
            // var select = " Select ID From PrijemKontejneraVoz";
            if (IzPrijemnice == 1)
            {
                if (pomVozom == 1)
                {
                    var select = "SELECT PrijemKontejneraVoz.[ID], (CAst(PrijemKontejneraVoz.[ID] as nvarchar(5)) + '-' + Cast(Voz.BrVoza as nvarchar(6)) + ' ' + Voz.Relacija +  ' ' +  CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5)) as Naziv " +
                            " FROM [dbo].[PrijemKontejneraVoz]    inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza  where PrijemKontejneraVoz.[ID] = " + pomPrijemnica + "  order by  PrijemKontejneraVoz.[DatumPrijema] desc, PrijemKontejneraVoz.[ID] ";
                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection myConnection = new SqlConnection(s_connection);
                    var c = new SqlConnection(s_connection);
                    var dataAdapter = new SqlDataAdapter(select, c);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    cboPrijemVozom.DataSource = ds.Tables[0];
                    cboPrijemVozom.DisplayMember = "Naziv";
                    cboPrijemVozom.ValueMember = "ID";
                    chkPrijem.Checked = true;
                    cboPrijemKamionom.Enabled = false;
                    chkVoz.Checked = true;

                    PretraziKontejnereVozomIzPrijemnice();
                  // Ovde treba refreh kontejnera

                }
                else
                {
                    var select2 = "SELECT PrijemKontejneraVoz.[ID], (CAst(PrijemKontejneraVoz.[ID] as nvarchar(5)) + '-' + RegBrKamiona + ' ' + ImeVozaca +  ' ' +   CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5)) as Naziv " +
                    " FROM [dbo].[PrijemKontejneraVoz]  where Vozom = 0 and PrijemKontejneraVoz.ID = " + pomPrijemnica + "   order by  PrijemKontejneraVoz.[DatumPrijema] desc, PrijemKontejneraVoz.[ID] ";

                    var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection myConnection2 = new SqlConnection(s_connection2);
                    var c2 = new SqlConnection(s_connection2);
                    var dataAdapter2 = new SqlDataAdapter(select2, c2);

                    var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
                    var ds2 = new DataSet();
                    dataAdapter2.Fill(ds2);
                    cboPrijemKamionom.DataSource = ds2.Tables[0];
                    cboPrijemKamionom.DisplayMember = "Naziv";
                    cboPrijemKamionom.ValueMember = "ID";

                    chkPrijem.Checked = true;
                    cboPrijemVozom.Enabled = false;

                    chkVoz.Checked = false;
                    PretraziKontejnereKamionomIzPrijemnice();
                }
            }
            else if (IzPrijemnice == 0)
            {
                //Panta
                if (pomVozom == 1)
                {
                    var select = "SELECT OtpremaKontejnera.[ID], (CAst(OtpremaKontejnera.[ID] as nvarchar(5)) + '-' + Cast(Voz.BrVoza as nvarchar(6)) + ' ' + Voz.Relacija + ' ' +  " +
" CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 104) + ' ' + " +
" SUBSTRING(CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 108), 1, 5)) as Naziv " +
" FROM [dbo].[OtpremaKontejnera]    inner join Voz on Voz.ID = OtpremaKontejnera.IdVoza  where OtpremaKontejnera.[ID] = " + pomPrijemnica + " and otpremakontejnera.NacinOtpreme = 1 order by OtpremaKontejnera.[DatumOtpreme] desc, OtpremaKontejnera.[ID]";
                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection myConnection = new SqlConnection(s_connection);
                    var c = new SqlConnection(s_connection);
                    var dataAdapter = new SqlDataAdapter(select, c);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    cboPrijemVozom.DataSource = ds.Tables[0];
                    cboPrijemVozom.DisplayMember = "Naziv";
                    cboPrijemVozom.ValueMember = "ID";

                    PretraziKontejnereVozomIzOtpremnice();
                }
                else
                {
                    var select2 = "SELECT OtpremaKontejnera.[ID], (CAst(OtpremaKontejnera.[ID] as nvarchar(5)) + '-' + (CAst(OtpremaKontejnera.[ID] as nvarchar(5)) + '-' + OtpremaKontejnera.RegBrKamiona + ' ' + OtpremaKontejnera.ImeVozaca +  ' ' + " +
                   " CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 104) + ' ' + " +
                   " SUBSTRING(CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 108), 1, 5))) as Naziv " +
                   " FROM [dbo].[OtpremaKontejnera]     where OtpremaKontejnera.[ID] = " + pomPrijemnica + " and otpremakontejnera.NacinOtpreme = 0 order by OtpremaKontejnera.[DatumOtpreme] desc, OtpremaKontejnera.[ID]";

                    var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection myConnection2 = new SqlConnection(s_connection2);
                    var c2 = new SqlConnection(s_connection2);
                    var dataAdapter2 = new SqlDataAdapter(select2, c2);

                    var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
                    var ds2 = new DataSet();
                    dataAdapter2.Fill(ds2);
                    cboPrijemKamionom.DataSource = ds2.Tables[0];
                    cboPrijemKamionom.DisplayMember = "Naziv";
                    cboPrijemKamionom.ValueMember = "ID";

                    PretraziKontejnereKamionomIzOtpremnice();
                }
              

                //

                //Kod za ulazak a nije iz prijemnice tj sa otpremnice
                /*
                 var select = "SELECT PrijemKontejneraVoz.[ID], (CAst(PrijemKontejneraVoz.[ID] as nvarchar(5)) + '-' + Cast(Voz.BrVoza as nvarchar(6)) + ' ' + Voz.Relacija +  ' ' +  CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5)) as Naziv " +
     " FROM [dbo].[PrijemKontejneraVoz]    inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza  where Vozom = 1 order by  PrijemKontejneraVoz.[DatumPrijema] desc, PrijemKontejneraVoz.[ID] ";
                 var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                 SqlConnection myConnection = new SqlConnection(s_connection);
                 var c = new SqlConnection(s_connection);
                 var dataAdapter = new SqlDataAdapter(select, c);

                 var commandBuilder = new SqlCommandBuilder(dataAdapter);
                 var ds = new DataSet();
                 dataAdapter.Fill(ds);
                 cboPrijemVozom.DataSource = ds.Tables[0];
                 cboPrijemVozom.DisplayMember = "Naziv";
                 cboPrijemVozom.ValueMember = "ID";
                 var select2 = "SELECT PrijemKontejneraVoz.[ID], (CAst(PrijemKontejneraVoz.[ID] as nvarchar(5)) + '-' + RegBrKamiona + ' ' + ImeVozaca +  ' ' +   CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5)) as Naziv " +
       " FROM [dbo].[PrijemKontejneraVoz]  where Vozom = 0  order by  PrijemKontejneraVoz.[DatumPrijema] desc, PrijemKontejneraVoz.[ID] ";

                 var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                 SqlConnection myConnection2 = new SqlConnection(s_connection2);
                 var c2 = new SqlConnection(s_connection2);
                 var dataAdapter2 = new SqlDataAdapter(select2, c2);

                 var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
                 var ds2 = new DataSet();
                 dataAdapter2.Fill(ds2);
                 cboPrijemKamionom.DataSource = ds2.Tables[0];
                 cboPrijemKamionom.DisplayMember = "Naziv";
                 cboPrijemKamionom.ValueMember = "ID";
                */

            }
            var select3 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboPlatilac.DataSource = ds3.Tables[0];
            cboPlatilac.DisplayMember = "Naziv";
            cboPlatilac.ValueMember = "ID";

            RefreshManipulacije();

        }

        private void PretraziKontejnereVozomIzPrijemnice()
        {
            chkPrijem.Checked = true;
                chkVoz.Checked = true;
                var select = "  Select BrojKontejnera, IDNAdredjenog as Dokument   From PrijemKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboPrijemVozom.SelectedValue);
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

                //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
                DataGridViewColumn column = dataGridView1.Columns[0];
                dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
                dataGridView1.Columns[0].Width = 100;

                DataGridViewColumn column1 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Dokument prijema voza";
                dataGridView1.Columns[1].Width = 100;
           

        }

        private void PretraziKontejnereKamionomIzPrijemnice()
        {
          
                chkVoz.Checked = false;
                var select = "  Select BrojKontejnera, IDNAdredjenog as Dokument   From PrijemKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboPrijemKamionom.SelectedValue);
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

                //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
                DataGridViewColumn column = dataGridView1.Columns[0];
                dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
                dataGridView1.Columns[0].Width = 100;

                DataGridViewColumn column1 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Dokument prijema";
                dataGridView1.Columns[1].Width = 100;
          
        }

        private void PretraziKontejnereVozomIzOtpremnice()
        {
            chkPrijem.Checked = false;
            chkOtprema.Checked = true;
            chkVoz.Checked = true;
            cboPrijemKamionom.Enabled = false;
            var select = "  Select BrojKontejnera, IDNAdredjenog as Dokument   From OtpremaKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboPrijemVozom.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[0].Width = 100;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Dokument prijema voza";
            dataGridView1.Columns[1].Width = 100;


        }

        private void PretraziKontejnereKamionomIzOtpremnice()
        {
            cboPrijemVozom.Enabled = false;
            chkOtprema.Checked = true;
            chkPrijem.Checked = false;
            chkVoz.Checked = false;
            var select = "  Select BrojKontejnera, IDNAdredjenog as Dokument   From OtpremaKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboPrijemKamionom.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[0].Width = 100;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Dokument prijema";
            dataGridView1.Columns[1].Width = 100;

        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            if (chkPrijem.Checked == true)
            {
                chkVoz.Checked = true;
                var select = "  Select BrojKontejnera, IDNAdredjenog as Dokument   From PrijemKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboPrijemVozom.SelectedValue);
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

                //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
                DataGridViewColumn column = dataGridView1.Columns[0];
                dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
                dataGridView1.Columns[0].Width = 100;

                DataGridViewColumn column1 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Dokument prijema voza";
                dataGridView1.Columns[1].Width = 100;
            }
            else
            {
                chkVoz.Checked = true;
                var select = "  Select BrojKontejnera, IDNAdredjenog as Dokument   From OtpremaKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboPrijemVozom.SelectedValue);
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

                //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
                DataGridViewColumn column = dataGridView1.Columns[0];
                dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
                dataGridView1.Columns[0].Width = 100;

                DataGridViewColumn column1 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Dokument otpreme voza";
                dataGridView1.Columns[1].Width = 100;

            }
        }

        private void RefreshDataGrid3()
        {
            if (chkVoz.Checked == true)
            {
                var select = "   select  NaruceneManipulacije.IDPrijemaVoza, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, " +
 " CASE WHEN NaruceneManipulacije.Uradjeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Uradjeno, " +
 " NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik,  NaruceneManipulacije.ID from NaruceneManipulacije " + 
" inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
" inner join Komitenti on NaruceneManipulacije.Platilac = Komitenti.ID " +
               " where Broj = " + Convert.ToInt32(txtSifra.Text);

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView3.ReadOnly = false;
                dataGridView3.DataSource = ds.Tables[0];

                DataGridViewColumn column = dataGridView3.Columns[0];
                dataGridView3.Columns[0].HeaderText = "Prijem";
                dataGridView3.Columns[0].Width = 40;
                // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView3.Columns[1];
                dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                dataGridView3.Columns[1].Width = 100;

                DataGridViewColumn column3 = dataGridView3.Columns[2];
                dataGridView3.Columns[2].HeaderText = "Man ID";
                dataGridView3.Columns[2].Width = 50;

                DataGridViewColumn column4 = dataGridView3.Columns[3];
                dataGridView3.Columns[3].HeaderText = "Manipulacija";
                dataGridView3.Columns[3].Width = 50;

              

                DataGridViewColumn column5 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Urađeno";
                dataGridView3.Columns[4].Width = 50;

                DataGridViewColumn column6 = dataGridView3.Columns[5];
                dataGridView3.Columns[5].HeaderText = "Datum od";
                dataGridView3.Columns[5].Width = 80;

                DataGridViewColumn column7 = dataGridView3.Columns[6];
                dataGridView3.Columns[6].HeaderText = "Datum do";
                dataGridView3.Columns[6].Width = 80;

                DataGridViewColumn column8 = dataGridView3.Columns[7];
                dataGridView3.Columns[7].HeaderText = "Datum";
                dataGridView3.Columns[7].Width = 80;

                DataGridViewColumn column9 = dataGridView3.Columns[8];
                dataGridView3.Columns[8].HeaderText = "Korisnik";
                dataGridView3.Columns[8].Width = 80;

                DataGridViewColumn column10 = dataGridView3.Columns[9];
                dataGridView3.Columns[9].HeaderText = "ID";
                dataGridView3.Columns[9].Width = 70;


            
            
            }
            else
            {
                var select = "  select NaruceneManipulacije.IDPrijemaKamionom, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, NaruceneManipulacije.Uradjeno, NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik, NaruceneManipulacije.ID from NaruceneManipulacije " +
            " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
             " where Broj = " + Convert.ToInt32(txtSifra.Text);

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView3.ReadOnly = false;
                dataGridView3.DataSource = ds.Tables[0];



                DataGridViewColumn column = dataGridView3.Columns[0];
                dataGridView3.Columns[0].HeaderText = "Prijem kamionom";
                dataGridView3.Columns[0].Width = 40;
                // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView3.Columns[1];
                dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                dataGridView3.Columns[1].Width = 100;

                DataGridViewColumn column3 = dataGridView3.Columns[2];
                dataGridView3.Columns[2].HeaderText = "Man ID";
                dataGridView3.Columns[2].Width = 50;

                DataGridViewColumn column4 = dataGridView3.Columns[3];
                dataGridView3.Columns[3].HeaderText = "Manipulacija";
                dataGridView3.Columns[3].Width = 50;

                DataGridViewColumn column5 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Urađeno";
                dataGridView3.Columns[4].Width = 50;

                DataGridViewColumn column6 = dataGridView3.Columns[5];
                dataGridView3.Columns[5].HeaderText = "Datum od";
                dataGridView3.Columns[5].Width = 80;

                DataGridViewColumn column7 = dataGridView3.Columns[6];
                dataGridView3.Columns[6].HeaderText = "Datum do";
                dataGridView3.Columns[6].Width = 80;

                DataGridViewColumn column8 = dataGridView3.Columns[7];
                dataGridView3.Columns[7].HeaderText = "Datum";
                dataGridView3.Columns[7].Width = 80;

                DataGridViewColumn column9 = dataGridView3.Columns[8];
                dataGridView3.Columns[8].HeaderText = "Korisnik";
                dataGridView3.Columns[8].Width = 80;

                DataGridViewColumn column10 = dataGridView3.Columns[8];
                dataGridView3.Columns[9].HeaderText = "ID";
                dataGridView3.Columns[9].Width = 80;

            }
          

        }

        private void RefreshManipulacije()
            {
                var select = "  SELECT ID, Naziv, JM, CASE WHEN UticeSkladisno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UticeSkladisno from VrstaManipulacije";

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView2.ReadOnly = false;
                dataGridView2.DataSource = ds.Tables[0];



                DataGridViewColumn column = dataGridView2.Columns[0];
                dataGridView2.Columns[0].HeaderText = "ID";
                dataGridView2.Columns[0].Width = 40;
               // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView2.Columns[1];
                dataGridView2.Columns[1].HeaderText = "Manipulacija";
                dataGridView2.Columns[1].Width = 250;

                DataGridViewColumn column3 = dataGridView2.Columns[2];
                dataGridView2.Columns[2].HeaderText = "JM";
                dataGridView2.Columns[2].Width = 80;

                DataGridViewColumn column4 = dataGridView2.Columns[3];
                dataGridView2.Columns[3].HeaderText = "Skladišno";
                dataGridView2.Columns[3].Width = 80;

               
              }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkPrijem.Checked == true)
            { 
            chkVoz.Checked = false;
            var select = "  Select BrojKontejnera, IDNAdredjenog as Dokument   From PrijemKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboPrijemKamionom.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[0].Width = 100;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Dokument prijema";
            dataGridView1.Columns[1].Width = 100;
            }
            else
            {
                chkVoz.Checked = false;
                var select = "  Select BrojKontejnera, IDNAdredjenog as Dokument   From OtpremaKontejneraVozStavke where IDNadredjenog = " + Convert.ToInt32(cboPrijemKamionom.SelectedValue);
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

                //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
                DataGridViewColumn column = dataGridView1.Columns[0];
                dataGridView1.Columns[0].HeaderText = "Broj kontejnera";
                dataGridView1.Columns[0].Width = 100;

                DataGridViewColumn column1 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "Dokument otpreme";
                dataGridView1.Columns[1].Width = 100;
            }
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            int IzPrijema = 0;
            int Direktna = 0;
            if (chkPrijem.Checked == true)
            { IzPrijema = 1; }
            else
            {
                IzPrijema = 0;
            }
            if (chkDirektna.Checked == true)
            { Direktna = 1; 
            }
            else
            {
               Direktna = 0;
            }


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                InsertNaruceneManipulacije ins = new InsertNaruceneManipulacije();

                if (row.Selected == true)
                    foreach (DataGridViewRow row2 in dataGridView2.Rows)
                    {
                        if (chkVoz.Checked == true && row2.Selected == true)
                        {
                            ins.InsertNarManipulacije(Convert.ToInt32(cboPrijemVozom.SelectedValue), 0, row.Cells[0].Value.ToString(), Convert.ToInt32(row2.Cells[0].Value.ToString()), 0, Convert.ToDateTime(dtpVremeOd.Text), Convert.ToDateTime(dtpVremeDo.Text), Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboPlatilac.SelectedValue), IzPrijema, Direktna);
                        }
                        else if (chkVoz.Checked == false && row2.Selected == true)
                        {
                            ins.InsertNarManipulacije( 0,Convert.ToInt32(cboPrijemKamionom.SelectedValue) , row.Cells[0].Value.ToString(), Convert.ToInt32(row2.Cells[0].Value.ToString()), 0, Convert.ToDateTime(dtpVremeOd.Text), Convert.ToDateTime(dtpVremeDo.Text), Convert.ToDateTime(DateTime.Now), KorisnikCene,  Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboPlatilac.SelectedValue), IzPrijema, Direktna);
                        }
                    }
                    
                // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
                     }
            RefreshDataGrid3();
           //RefreshDataGrid3();
           //RefreshDataGridIma();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void dtpVremeOd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpVremeDo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void VratiPodatkeMaxSledeci()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select (Max([Broj]) + 1) as ID from NaruceneManipulacije", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            VratiPodatkeMaxSledeci();
            dtpVremeOd.Value = DateTime.Now;
            dtpVremeDo.Value = DateTime.Now;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmNajavaKomitemtaDokument frmd3 = new frmNajavaKomitemtaDokument(txtSifra.Text, KorisnikCene);
            frmd3.Show();
        }

        private void tsPrvi_Click(object sender, EventArgs e)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Min([Broj]) as ID from NaruceneManipulacije", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }
            RefreshDataGrid3();
            con.Close();

        }

        private void tsPoslednja_Click(object sender, EventArgs e)
        {


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([Broj]) as ID from NaruceneManipulacije", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }
            RefreshDataGrid3();
            con.Close();



        }

        private void tsNazad_Click(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);
            int prvi = 0;
            con.Open();

            SqlCommand cmd = new SqlCommand("select Max(Broj) as ID from NaruceneManipulacije where Broj <" + Convert.ToInt32(txtSifra.Text) + " Order by ID desc", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                prvi = Convert.ToInt32(dr["ID"].ToString());
                txtSifra.Text = prvi.ToString();
            }

            con.Close();
            RefreshDataGrid3();
        
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([Broj]) as ID from NaruceneManipulacije", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void tsNapred_Click(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);
            int zadnji = 0;
            con.Open();

            SqlCommand cmd = new SqlCommand("select Min(Broj) as ID from NaruceneManipulacije where Broj >" + Convert.ToInt32(txtSifra.Text) + " Order by ID", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                zadnji = Convert.ToInt32(dr["ID"].ToString());
                txtSifra.Text = zadnji.ToString();
            }

            con.Close();
            RefreshDataGrid3();
/*
            if ((Convert.ToInt32(txtSifra.Text) + 1) == zadnji)
              //  VratiPodatke((Convert.ToInt32(zadnji).ToString()));
            else
               // VratiPodatke((Convert.ToInt32(txtSifra.Text) + 1).ToString());
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertNaruceneManipulacije ins = new InsertNaruceneManipulacije();
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected == true)
                    {

                        ins.DeleteNarManipulacija(Convert.ToInt32(row.Cells[9].Value));

                    }
                }
                RefreshDataGrid3();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshDataGrid3();
        }

        private void RefreshComboPrijem()
        {
            var select = "SELECT PrijemKontejneraVoz.[ID], (CAst(PrijemKontejneraVoz.[ID] as nvarchar(5)) + '-' + Cast(Voz.BrVoza as nvarchar(6)) + ' ' + Voz.Relacija +  ' ' +  CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5)) as Naziv " +
      " FROM [dbo].[PrijemKontejneraVoz]    inner join Voz on Voz.ID = PrijemKontejneraVoz.IdVoza  where Vozom = 1 order by  PrijemKontejneraVoz.[DatumPrijema] desc, PrijemKontejneraVoz.[ID] ";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboPrijemVozom.DataSource = ds.Tables[0];
            cboPrijemVozom.DisplayMember = "Naziv";
            cboPrijemVozom.ValueMember = "ID";
            var select2 = "SELECT PrijemKontejneraVoz.[ID], (CAst(PrijemKontejneraVoz.[ID] as nvarchar(5)) + '-' + RegBrKamiona + ' ' + ImeVozaca +  ' ' +   CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5)) as Naziv " +
  " FROM [dbo].[PrijemKontejneraVoz]  where Vozom = 0  order by  PrijemKontejneraVoz.[DatumPrijema] desc, PrijemKontejneraVoz.[ID] ";

            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboPrijemKamionom.DataSource = ds2.Tables[0];
            cboPrijemKamionom.DisplayMember = "Naziv";
            cboPrijemKamionom.ValueMember = "ID";

            var select3 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboPlatilac.DataSource = ds3.Tables[0];
            cboPlatilac.DisplayMember = "Naziv";
            cboPlatilac.ValueMember = "ID";

            RefreshManipulacije();


        }

        private void RefreshComboOtprema()
        {
            var select = "SELECT OtpremaKontejnera.[ID], (CAst(OtpremaKontejnera.[ID] as nvarchar(5)) + '-' + Cast(Voz.BrVoza as nvarchar(6)) + ' ' + Voz.Relacija + ' ' +  " +
" CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 104) + ' ' + " +
" SUBSTRING(CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 108), 1, 5)) as Naziv " +
 " FROM [dbo].[OtpremaKontejnera]    inner join Voz on Voz.ID = OtpremaKontejnera.IdVoza  where otpremakontejnera.NacinOtpreme = 1 order by OtpremaKontejnera.[DatumOtpreme] desc, OtpremaKontejnera.[ID]";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboPrijemVozom.DataSource = ds.Tables[0];
            cboPrijemVozom.DisplayMember = "Naziv";
            cboPrijemVozom.ValueMember = "ID";
          
            var select2 = "SELECT OtpremaKontejnera.[ID], (CAst(OtpremaKontejnera.[ID] as nvarchar(5)) + '-' + (CAst(OtpremaKontejnera.[ID] as nvarchar(5)) + '-' + OtpremaKontejnera.RegBrKamiona + ' ' + OtpremaKontejnera.ImeVozaca +  ' ' + " +
 " CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 104) + ' ' + " +
 " SUBSTRING(CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 108), 1, 5))) as Naziv " +
   " FROM[dbo].[OtpremaKontejnera]     where otpremakontejnera.NacinOtpreme = 0 order by OtpremaKontejnera.[DatumOtpreme] desc, OtpremaKontejnera.[ID]";

            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboPrijemKamionom.DataSource = ds2.Tables[0];
            cboPrijemKamionom.DisplayMember = "Naziv";
            cboPrijemKamionom.ValueMember = "ID";

            var select3 = " Select Distinct ID, Naziv From Komitenti order by Naziv";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboPlatilac.DataSource = ds3.Tables[0];
            cboPlatilac.DisplayMember = "Naziv";
            cboPlatilac.ValueMember = "ID";

            RefreshManipulacije();




        }

        private void chkOtprema_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtprema.Checked == true)
            {
                chkPrijem.Checked = false;
                RefreshComboOtprema();
            }
            else
            {
                chkPrijem.Checked = true;
                RefreshComboPrijem();
            }
        }

        private void chkPrijem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrijem.Checked == true)
            {
                chkOtprema.Checked = false;
                RefreshComboPrijem();
            }
            else
            {
                chkOtprema.Checked = true;
                RefreshComboOtprema();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
