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

namespace Testiranje.Dokumeta
{
    public partial class frmPregledNarucenihManipulacija : Form
    {
          string KorisnikCene;
        int pomPrijemnica = 0;
        int pomVozom = 0;
      //  bool status = false;
        public frmPregledNarucenihManipulacija()
        {
            InitializeComponent();
        }

        public frmPregledNarucenihManipulacija(string Korisnik)
        {
            KorisnikCene = Korisnik;
            InitializeComponent();
        }

        public frmPregledNarucenihManipulacija(string Korisnik, int Prijemnica, int Vozom)
        {
            pomPrijemnica = Prijemnica;
            pomVozom = Vozom;
            KorisnikCene = Korisnik;
            InitializeComponent();
        }

        private void frmPregledNarucenihManipulacija_Load(object sender, EventArgs e)
        {
            if (pomPrijemnica > 1)
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
                    if (chkPrijem.Checked == true)
                    {
                        RefreshDataGrid3();
                    }
                    else
                    {
                        RefreshDataGrid4();
                    }

                }
                else
                {
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

                    chkPrijem.Checked = true;
                    cboPrijemVozom.Enabled = false;

                    chkVoz.Checked = false;
                    if (chkPrijem.Checked == true)
                    {
                        RefreshDataGrid3();
                    }
                    else
                    {
                        RefreshDataGrid4();
                    }
                }
            }
            else
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
            }
         
        }

        //Iz prijema
        private void RefreshDataGrid3()
        {// if (chkPrijem.Checked == true)
            //{
                if (chkVoz.Checked == true)
                {
                    var select = "   select  NaruceneManipulacije.IDPrijemaVoza, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, " +
                     " CASE WHEN NaruceneManipulacije.Uradjeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Uradjeno, " +
                     " NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik,  NaruceneManipulacije.ID, NaruceneManipulacije.Broj from NaruceneManipulacije " +
                     " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
                     " inner join Komitenti on NaruceneManipulacije.Platilac = Komitenti.ID " +
                     " where NaruceneManipulacije.IzPrijema = 1 and NaruceneManipulacije.IDPrijemaVoza = " + Convert.ToInt32(cboPrijemVozom.SelectedValue);

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
                    dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                    // dataGridView2.Columns[0].Visible = false;

                    DataGridViewColumn column2 = dataGridView3.Columns[1];
                    dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                    dataGridView3.Columns[1].Width = 100;
                    dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                    DataGridViewColumn column3 = dataGridView3.Columns[2];
                    dataGridView3.Columns[2].HeaderText = "Man ID";
                    dataGridView3.Columns[2].Width = 50;

                    DataGridViewColumn column4 = dataGridView3.Columns[3];
                    dataGridView3.Columns[3].HeaderText = "Manipulacija";
                    dataGridView3.Columns[3].Width = 250;
                    dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

                    DataGridViewColumn column5 = dataGridView3.Columns[4];
                    dataGridView3.Columns[4].HeaderText = "Urađeno";
                    dataGridView3.Columns[4].Width = 50;

                    DataGridViewColumn column6 = dataGridView3.Columns[5];
                    dataGridView3.Columns[5].HeaderText = "Datum od";
                    dataGridView3.Columns[5].Width = 150;

                    DataGridViewColumn column7 = dataGridView3.Columns[6];
                    dataGridView3.Columns[6].HeaderText = "Datum do";
                    dataGridView3.Columns[6].Width = 150;

                    DataGridViewColumn column8 = dataGridView3.Columns[7];
                    dataGridView3.Columns[7].HeaderText = "Datum";
                    dataGridView3.Columns[7].Width = 80;

                    DataGridViewColumn column9 = dataGridView3.Columns[8];
                    dataGridView3.Columns[8].HeaderText = "Korisnik";
                    dataGridView3.Columns[8].Width = 80;

                    DataGridViewColumn column10 = dataGridView3.Columns[9];
                    dataGridView3.Columns[9].HeaderText = "ID";
                    dataGridView3.Columns[9].Width = 70;

                    DataGridViewColumn column11 = dataGridView3.Columns[10];
                    dataGridView3.Columns[10].HeaderText = "Broj";
                    dataGridView3.Columns[10].Width = 70;
                    dataGridView3.Columns[10].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                /*
                    DataGridViewColumn column12 = dataGridView3.Columns[11];
                    dataGridView3.Columns[11].HeaderText = "Datum urađeno";
                    dataGridView3.Columns[11].Width = 80;
                */

                }
                else
                {
                    var select = "  select NaruceneManipulacije.IDPrijemaKamionom, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, NaruceneManipulacije.Uradjeno, NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik, NaruceneManipulacije.ID, NaruceneManipulacije.Broj, NaruceneManipulacije.DatumUradjeno from NaruceneManipulacije " +
                " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
                 " where NaruceneManipulacije.IzPrijema = 1 and NaruceneManipulacije.IDPrijemaKamionom = " + Convert.ToInt32(cboPrijemKamionom.SelectedValue);

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
                    dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.CadetBlue;
                    //  dataGridView3.Columns[0].
                    // dataGridView2.Columns[0].Visible = false;

                    DataGridViewColumn column2 = dataGridView3.Columns[1];
                    dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                    dataGridView3.Columns[1].Width = 100;
                    dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                    DataGridViewColumn column3 = dataGridView3.Columns[2];
                    dataGridView3.Columns[2].HeaderText = "Man ID";
                    dataGridView3.Columns[2].Width = 50;

                    DataGridViewColumn column4 = dataGridView3.Columns[3];
                    dataGridView3.Columns[3].HeaderText = "Manipulacija";
                    dataGridView3.Columns[3].Width = 250;
                    dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

                    DataGridViewColumn column5 = dataGridView3.Columns[4];
                    dataGridView3.Columns[4].HeaderText = "Urađeno";
                    dataGridView3.Columns[4].Width = 50;

                    DataGridViewColumn column6 = dataGridView3.Columns[5];
                    dataGridView3.Columns[5].HeaderText = "Datum od";
                    dataGridView3.Columns[5].Width = 120;

                    DataGridViewColumn column7 = dataGridView3.Columns[6];
                    dataGridView3.Columns[6].HeaderText = "Datum do";
                    dataGridView3.Columns[6].Width = 120;

                    DataGridViewColumn column8 = dataGridView3.Columns[7];
                    dataGridView3.Columns[7].HeaderText = "Datum";
                    dataGridView3.Columns[7].Width = 80;

                    DataGridViewColumn column9 = dataGridView3.Columns[8];
                    dataGridView3.Columns[8].HeaderText = "Korisnik";
                    dataGridView3.Columns[8].Width = 80;

                    DataGridViewColumn column10 = dataGridView3.Columns[9];
                    dataGridView3.Columns[9].HeaderText = "ID";
                    dataGridView3.Columns[9].Width = 80;

                    DataGridViewColumn column11 = dataGridView3.Columns[10];
                    dataGridView3.Columns[10].HeaderText = "Broj";
                    dataGridView3.Columns[10].Width = 80;

                    DataGridViewColumn column12 = dataGridView3.Columns[11];
                    dataGridView3.Columns[11].HeaderText = "Datum urađeno";
                    dataGridView3.Columns[11].Width = 80;

                }
          
        }

        //Iz otpreme
        private void RefreshDataGrid4()
        {// if (chkPrijem.Checked == true)
         //{
            if (chkVoz.Checked == true)
            {
                var select = "   select  NaruceneManipulacije.IDPrijemaVoza, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, " +
                 " CASE WHEN NaruceneManipulacije.Uradjeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Uradjeno, " +
                 " NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik,  NaruceneManipulacije.ID, NaruceneManipulacije.Broj from NaruceneManipulacije " +
                 " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
                 " inner join Komitenti on NaruceneManipulacije.Platilac = Komitenti.ID " +
                 " where NaruceneManipulacije.IzPrijema = 0 and NaruceneManipulacije.IDPrijemaVoza = " + Convert.ToInt32(cboPrijemVozom.SelectedValue);

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
                dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView3.Columns[1];
                dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                dataGridView3.Columns[1].Width = 100;
                dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                DataGridViewColumn column3 = dataGridView3.Columns[2];
                dataGridView3.Columns[2].HeaderText = "Man ID";
                dataGridView3.Columns[2].Width = 50;

                DataGridViewColumn column4 = dataGridView3.Columns[3];
                dataGridView3.Columns[3].HeaderText = "Manipulacija";
                dataGridView3.Columns[3].Width = 250;
                dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

                DataGridViewColumn column5 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Urađeno";
                dataGridView3.Columns[4].Width = 50;

                DataGridViewColumn column6 = dataGridView3.Columns[5];
                dataGridView3.Columns[5].HeaderText = "Datum od";
                dataGridView3.Columns[5].Width = 150;

                DataGridViewColumn column7 = dataGridView3.Columns[6];
                dataGridView3.Columns[6].HeaderText = "Datum do";
                dataGridView3.Columns[6].Width = 150;

                DataGridViewColumn column8 = dataGridView3.Columns[7];
                dataGridView3.Columns[7].HeaderText = "Datum";
                dataGridView3.Columns[7].Width = 80;

                DataGridViewColumn column9 = dataGridView3.Columns[8];
                dataGridView3.Columns[8].HeaderText = "Korisnik";
                dataGridView3.Columns[8].Width = 80;

                DataGridViewColumn column10 = dataGridView3.Columns[9];
                dataGridView3.Columns[9].HeaderText = "ID";
                dataGridView3.Columns[9].Width = 70;

                DataGridViewColumn column11 = dataGridView3.Columns[10];
                dataGridView3.Columns[10].HeaderText = "Broj";
                dataGridView3.Columns[10].Width = 70;
                dataGridView3.Columns[10].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                /*
                    DataGridViewColumn column12 = dataGridView3.Columns[11];
                    dataGridView3.Columns[11].HeaderText = "Datum urađeno";
                    dataGridView3.Columns[11].Width = 80;
                */

            }
            else
            {
                var select = "  select NaruceneManipulacije.IDPrijemaKamionom, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, NaruceneManipulacije.Uradjeno, NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik, NaruceneManipulacije.ID, NaruceneManipulacije.Broj, NaruceneManipulacije.DatumUradjeno from NaruceneManipulacije " +
            " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
             " where NaruceneManipulacije.IzPrijema = 0 and NaruceneManipulacije.IDPrijemaKamionom = " + Convert.ToInt32(cboPrijemKamionom.SelectedValue);

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
                dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.CadetBlue;
                //  dataGridView3.Columns[0].
                // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView3.Columns[1];
                dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                dataGridView3.Columns[1].Width = 100;
                dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                DataGridViewColumn column3 = dataGridView3.Columns[2];
                dataGridView3.Columns[2].HeaderText = "Man ID";
                dataGridView3.Columns[2].Width = 50;

                DataGridViewColumn column4 = dataGridView3.Columns[3];
                dataGridView3.Columns[3].HeaderText = "Manipulacija";
                dataGridView3.Columns[3].Width = 250;
                dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

                DataGridViewColumn column5 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Urađeno";
                dataGridView3.Columns[4].Width = 50;

                DataGridViewColumn column6 = dataGridView3.Columns[5];
                dataGridView3.Columns[5].HeaderText = "Datum od";
                dataGridView3.Columns[5].Width = 120;

                DataGridViewColumn column7 = dataGridView3.Columns[6];
                dataGridView3.Columns[6].HeaderText = "Datum do";
                dataGridView3.Columns[6].Width = 120;

                DataGridViewColumn column8 = dataGridView3.Columns[7];
                dataGridView3.Columns[7].HeaderText = "Datum";
                dataGridView3.Columns[7].Width = 80;

                DataGridViewColumn column9 = dataGridView3.Columns[8];
                dataGridView3.Columns[8].HeaderText = "Korisnik";
                dataGridView3.Columns[8].Width = 80;

                DataGridViewColumn column10 = dataGridView3.Columns[9];
                dataGridView3.Columns[9].HeaderText = "ID";
                dataGridView3.Columns[9].Width = 80;

                DataGridViewColumn column11 = dataGridView3.Columns[10];
                dataGridView3.Columns[10].HeaderText = "Broj";
                dataGridView3.Columns[10].Width = 80;

                DataGridViewColumn column12 = dataGridView3.Columns[11];
                dataGridView3.Columns[11].HeaderText = "Datum urađeno";
                dataGridView3.Columns[11].Width = 80;

            }

        }


        private void RefreshDataGrid3PoKontejneru()
        {// if (chkPrijem.Checked == true)
         //{
            if (chkVoz.Checked == true)
            {
                var select = "   select  NaruceneManipulacije.IDPrijemaVoza, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, " +
                 " CASE WHEN NaruceneManipulacije.Uradjeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Uradjeno, " +
                 " NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik,  NaruceneManipulacije.ID, NaruceneManipulacije.Broj from NaruceneManipulacije " +
                 " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
                 " inner join Komitenti on NaruceneManipulacije.Platilac = Komitenti.ID " +
                 " where NaruceneManipulacije.IzPrijema = 1 and NaruceneManipulacije.IDPrijemaVoza = " + Convert.ToInt32(cboPrijemVozom.SelectedValue) + " and NaruceneManipulacije.BrojKontejnera = '" + txtBrojKontejnera.Text + "'"; ;

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
                dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView3.Columns[1];
                dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                dataGridView3.Columns[1].Width = 100;
                dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                DataGridViewColumn column3 = dataGridView3.Columns[2];
                dataGridView3.Columns[2].HeaderText = "Man ID";
                dataGridView3.Columns[2].Width = 50;

                DataGridViewColumn column4 = dataGridView3.Columns[3];
                dataGridView3.Columns[3].HeaderText = "Manipulacija";
                dataGridView3.Columns[3].Width = 250;
                dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

                DataGridViewColumn column5 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Urađeno";
                dataGridView3.Columns[4].Width = 50;

                DataGridViewColumn column6 = dataGridView3.Columns[5];
                dataGridView3.Columns[5].HeaderText = "Datum od";
                dataGridView3.Columns[5].Width = 150;

                DataGridViewColumn column7 = dataGridView3.Columns[6];
                dataGridView3.Columns[6].HeaderText = "Datum do";
                dataGridView3.Columns[6].Width = 150;

                DataGridViewColumn column8 = dataGridView3.Columns[7];
                dataGridView3.Columns[7].HeaderText = "Datum";
                dataGridView3.Columns[7].Width = 80;

                DataGridViewColumn column9 = dataGridView3.Columns[8];
                dataGridView3.Columns[8].HeaderText = "Korisnik";
                dataGridView3.Columns[8].Width = 80;

                DataGridViewColumn column10 = dataGridView3.Columns[9];
                dataGridView3.Columns[9].HeaderText = "ID";
                dataGridView3.Columns[9].Width = 70;

                DataGridViewColumn column11 = dataGridView3.Columns[10];
                dataGridView3.Columns[10].HeaderText = "Broj";
                dataGridView3.Columns[10].Width = 70;
                dataGridView3.Columns[10].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                /*
                    DataGridViewColumn column12 = dataGridView3.Columns[11];
                    dataGridView3.Columns[11].HeaderText = "Datum urađeno";
                    dataGridView3.Columns[11].Width = 80;
                */

            }
            else
            {
                var select = "  select NaruceneManipulacije.IDPrijemaKamionom, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, NaruceneManipulacije.Uradjeno, NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik, NaruceneManipulacije.ID, NaruceneManipulacije.Broj, NaruceneManipulacije.DatumUradjeno from NaruceneManipulacije " +
            " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
             " where NaruceneManipulacije.IzPrijema = 1 and NaruceneManipulacije.IDPrijemaKamionom = " + Convert.ToInt32(cboPrijemKamionom.SelectedValue) + " and NaruceneManipulacije.BrojKontejnera = '" + txtBrojKontejnera.Text + "'"; ;

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
                dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.CadetBlue;
                //  dataGridView3.Columns[0].
                // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView3.Columns[1];
                dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                dataGridView3.Columns[1].Width = 100;
                dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                DataGridViewColumn column3 = dataGridView3.Columns[2];
                dataGridView3.Columns[2].HeaderText = "Man ID";
                dataGridView3.Columns[2].Width = 50;

                DataGridViewColumn column4 = dataGridView3.Columns[3];
                dataGridView3.Columns[3].HeaderText = "Manipulacija";
                dataGridView3.Columns[3].Width = 250;
                dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

                DataGridViewColumn column5 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Urađeno";
                dataGridView3.Columns[4].Width = 50;

                DataGridViewColumn column6 = dataGridView3.Columns[5];
                dataGridView3.Columns[5].HeaderText = "Datum od";
                dataGridView3.Columns[5].Width = 120;

                DataGridViewColumn column7 = dataGridView3.Columns[6];
                dataGridView3.Columns[6].HeaderText = "Datum do";
                dataGridView3.Columns[6].Width = 120;

                DataGridViewColumn column8 = dataGridView3.Columns[7];
                dataGridView3.Columns[7].HeaderText = "Datum";
                dataGridView3.Columns[7].Width = 80;

                DataGridViewColumn column9 = dataGridView3.Columns[8];
                dataGridView3.Columns[8].HeaderText = "Korisnik";
                dataGridView3.Columns[8].Width = 80;

                DataGridViewColumn column10 = dataGridView3.Columns[9];
                dataGridView3.Columns[9].HeaderText = "ID";
                dataGridView3.Columns[9].Width = 80;

                DataGridViewColumn column11 = dataGridView3.Columns[10];
                dataGridView3.Columns[10].HeaderText = "Broj";
                dataGridView3.Columns[10].Width = 80;

                DataGridViewColumn column12 = dataGridView3.Columns[11];
                dataGridView3.Columns[11].HeaderText = "Datum urađeno";
                dataGridView3.Columns[11].Width = 80;

            }

        }

        //Iz otpreme
        private void RefreshDataGrid4PoKontejneru()
        {// if (chkPrijem.Checked == true)
         //{
            if (chkVoz.Checked == true)
            {
                var select = "   select  NaruceneManipulacije.IDPrijemaVoza, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, " +
                 " CASE WHEN NaruceneManipulacije.Uradjeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Uradjeno, " +
                 " NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik,  NaruceneManipulacije.ID, NaruceneManipulacije.Broj from NaruceneManipulacije " +
                 " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
                 " inner join Komitenti on NaruceneManipulacije.Platilac = Komitenti.ID " +
                 " where NaruceneManipulacije.IzPrijema = 0 and NaruceneManipulacije.IDPrijemaVoza = " + Convert.ToInt32(cboPrijemVozom.SelectedValue) + " and NaruceneManipulacije.BrojKontejnera = '" + txtBrojKontejnera.Text + "'"; ;

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
                dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView3.Columns[1];
                dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                dataGridView3.Columns[1].Width = 100;
                dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                DataGridViewColumn column3 = dataGridView3.Columns[2];
                dataGridView3.Columns[2].HeaderText = "Man ID";
                dataGridView3.Columns[2].Width = 50;

                DataGridViewColumn column4 = dataGridView3.Columns[3];
                dataGridView3.Columns[3].HeaderText = "Manipulacija";
                dataGridView3.Columns[3].Width = 250;
                dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

                DataGridViewColumn column5 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Urađeno";
                dataGridView3.Columns[4].Width = 50;

                DataGridViewColumn column6 = dataGridView3.Columns[5];
                dataGridView3.Columns[5].HeaderText = "Datum od";
                dataGridView3.Columns[5].Width = 150;

                DataGridViewColumn column7 = dataGridView3.Columns[6];
                dataGridView3.Columns[6].HeaderText = "Datum do";
                dataGridView3.Columns[6].Width = 150;

                DataGridViewColumn column8 = dataGridView3.Columns[7];
                dataGridView3.Columns[7].HeaderText = "Datum";
                dataGridView3.Columns[7].Width = 80;

                DataGridViewColumn column9 = dataGridView3.Columns[8];
                dataGridView3.Columns[8].HeaderText = "Korisnik";
                dataGridView3.Columns[8].Width = 80;

                DataGridViewColumn column10 = dataGridView3.Columns[9];
                dataGridView3.Columns[9].HeaderText = "ID";
                dataGridView3.Columns[9].Width = 70;

                DataGridViewColumn column11 = dataGridView3.Columns[10];
                dataGridView3.Columns[10].HeaderText = "Broj";
                dataGridView3.Columns[10].Width = 70;
                dataGridView3.Columns[10].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                /*
                    DataGridViewColumn column12 = dataGridView3.Columns[11];
                    dataGridView3.Columns[11].HeaderText = "Datum urađeno";
                    dataGridView3.Columns[11].Width = 80;
                */

            }
            else
            {
                var select = "  select NaruceneManipulacije.IDPrijemaKamionom, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, NaruceneManipulacije.Uradjeno, NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik, NaruceneManipulacije.ID, NaruceneManipulacije.Broj, NaruceneManipulacije.DatumUradjeno from NaruceneManipulacije " +
            " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
             " where NaruceneManipulacije.IzPrijema = 0 and NaruceneManipulacije.IDPrijemaKamionom = " + Convert.ToInt32(cboPrijemKamionom.SelectedValue) + " and NaruceneManipulacije.BrojKontejnera = '" + txtBrojKontejnera.Text + "'"; ;

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
                dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.CadetBlue;
                //  dataGridView3.Columns[0].
                // dataGridView2.Columns[0].Visible = false;

                DataGridViewColumn column2 = dataGridView3.Columns[1];
                dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
                dataGridView3.Columns[1].Width = 100;
                dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

                DataGridViewColumn column3 = dataGridView3.Columns[2];
                dataGridView3.Columns[2].HeaderText = "Man ID";
                dataGridView3.Columns[2].Width = 50;

                DataGridViewColumn column4 = dataGridView3.Columns[3];
                dataGridView3.Columns[3].HeaderText = "Manipulacija";
                dataGridView3.Columns[3].Width = 250;
                dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

                DataGridViewColumn column5 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Urađeno";
                dataGridView3.Columns[4].Width = 50;

                DataGridViewColumn column6 = dataGridView3.Columns[5];
                dataGridView3.Columns[5].HeaderText = "Datum od";
                dataGridView3.Columns[5].Width = 120;

                DataGridViewColumn column7 = dataGridView3.Columns[6];
                dataGridView3.Columns[6].HeaderText = "Datum do";
                dataGridView3.Columns[6].Width = 120;

                DataGridViewColumn column8 = dataGridView3.Columns[7];
                dataGridView3.Columns[7].HeaderText = "Datum";
                dataGridView3.Columns[7].Width = 80;

                DataGridViewColumn column9 = dataGridView3.Columns[8];
                dataGridView3.Columns[8].HeaderText = "Korisnik";
                dataGridView3.Columns[8].Width = 80;

                DataGridViewColumn column10 = dataGridView3.Columns[9];
                dataGridView3.Columns[9].HeaderText = "ID";
                dataGridView3.Columns[9].Width = 80;

                DataGridViewColumn column11 = dataGridView3.Columns[10];
                dataGridView3.Columns[10].HeaderText = "Broj";
                dataGridView3.Columns[10].Width = 80;

                DataGridViewColumn column12 = dataGridView3.Columns[11];
                dataGridView3.Columns[11].HeaderText = "Datum urađeno";
                dataGridView3.Columns[11].Width = 80;

            }

        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            chkVoz.Checked = true;
            if (chkPrijem.Checked == true)
            {
                RefreshDataGrid3();
            }
            else
            {
                RefreshDataGrid4();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chkVoz.Checked = false;
            if (chkPrijem.Checked == true)
            {
                RefreshDataGrid3();
            }
            else
            {
                RefreshDataGrid4();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            InsertNaruceneManipulacije ins = new InsertNaruceneManipulacije();
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Selected == true)
                {

                    ins.UpdateUradjeno(Convert.ToInt32(row.Cells[9].Value) , DateTime.Now);

                }
            }
            RefreshDataGrid3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertNaruceneManipulacije ins = new InsertNaruceneManipulacije();
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Selected == true)
                {
                    ins.UpdateNijeUradjeno(Convert.ToInt32(row.Cells[9].Value), DateTime.Now);
                }
            }
            RefreshDataGrid3();
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

        private void RefreshComboPrijem()
        {
            var select = "SELECT PrijemKontejneraVoz.[ID], (CAst(PrijemKontejneraVoz.[ID] as nvarchar(4)) + '-' + Cast(Voz.BrVoza as nvarchar(6)) + ' ' + Voz.Relacija +  ' ' +  CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5)) as Naziv " +
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
            var select2 = "SELECT PrijemKontejneraVoz.[ID], (CAst(PrijemKontejneraVoz.[ID] as nvarchar(4)) + '-' + RegBrKamiona + ' ' + ImeVozaca +  ' ' +   CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],104)      + ' '      + SUBSTRING(CONVERT(varchar,PrijemKontejneraVoz.[DatumPrijema],108),1,5)) as Naziv " +
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

           


        }

        private void RefreshComboOtprema()
        {
            var select = "SELECT OtpremaKontejnera.[ID], (CAst(OtpremaKontejnera.[ID] as nvarchar(5)) + '-' + Cast(Voz.BrVoza as nvarchar(6)) + ' ' + Voz.Relacija + ' ' +  " +
 " CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 104) + ' ' + " +
 " SUBSTRING(CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 108), 1, 5)) as Naziv " +
   " FROM[dbo].[OtpremaKontejnera]    inner join Voz on Voz.ID = OtpremaKontejnera.IdVoza  where otpremakontejnera.NacinOtpreme = 1 order by OtpremaKontejnera.[DatumOtpreme] desc, OtpremaKontejnera.[ID]";
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
            var select2 = "SELECT OtpremaKontejnera.[ID], (CAst(OtpremaKontejnera.[ID] as nvarchar(5)) +'-' + OtpremaKontejnera.RegBrKamiona + ' ' + ImeVozaca +  ' ' + " +
" CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 104) + ' ' + " +
" SUBSTRING(CONVERT(varchar, OtpremaKontejnera.[DatumOtpreme], 108), 1, 5)) as Naziv " +
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (chkPrijem.Checked == true)
            {
                RefreshDataGrid3PoKontejneru();
            }
            else
            {
                RefreshDataGrid4PoKontejneru();
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chkVoz.Checked = false;
            if (chkPrijem.Checked == true)
            {
                RefreshDataGrid3PoKontejneru();
            }
            else
            {
                RefreshDataGrid4PoKontejneru();
            }
        }
    }
    }

