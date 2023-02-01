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
using System.Globalization;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms;

using MetroFramework.Forms;

namespace Saobracaj.Tehnologija
{
    
    public partial class frmTehnologija : Syncfusion.Windows.Forms.Office2010Form
    {
        public static string code = "frmTehnologija";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        bool status = false;
        int TehnologijaPrenesena = 0;
        string KorisnikP = "";
        public frmTehnologija(string Korisnik)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
            KorisnikP = Korisnik;
            if (Korisnik != "admin")
            {
                txtUkupnoTrase.Visible = false;
                txtUkupnoLokomotive.Visible = false;
                txtUkupnoZaposleni.Visible = false;
                txtUkupnoSumarno.Visible = false;
                txtDizel.Visible = false;
                txtEnergija.Visible = false;
                txtCenaL.Visible = false;
                txtUkupnol.Visible = false;
                txtFiksnaCenaL.Visible = false;
                txtUkupnoA.Visible = false;
                txtCenaA.Visible = false;
                txtFCenaA.Visible = false;
                lblDizel.Visible = false;
                lblEnergija.Visible = false;
                lblCenaT.Visible = false;
                lblFiksnaC.Visible = false;
                lblUkupnoT.Visible = false;
                lblCenaA.Visible = false;
                lblFiksnaA.Visible = false;
                lblUkupnoA.Visible = false;
                lblUkupnoTrase.Visible = false;
                lblUkupnoLokomotive.Visible = false;
                lblUkupnoZaposleni.Visible = false;
                lblSumarno.Visible = false;

            }
            else
            {
                txtUkupnoTrase.Visible = true;
                txtUkupnoLokomotive.Visible = true;
                txtUkupnoZaposleni.Visible = true;
                txtUkupnoSumarno.Visible = true;
                txtDizel.Visible = true;
                txtEnergija.Visible = true;
                txtCenaL.Visible = true;
                txtUkupnol.Visible = true;
                txtFiksnaCenaL.Visible = true;
                txtUkupnoA.Visible = true;
                txtCenaA.Visible = true;
                txtFCenaA.Visible = true;
                lblDizel.Visible = true;
                lblEnergija.Visible = true;
                lblCenaT.Visible = true;
                lblFiksnaC.Visible = true;
                lblUkupnoT.Visible = true;
                lblCenaA.Visible = true;
                lblFiksnaA.Visible = true;
                lblUkupnoA.Visible = true;
                lblUkupnoTrase.Visible = true;
                lblUkupnoLokomotive.Visible = true;
                lblUkupnoZaposleni.Visible = true;
                lblSumarno.Visible = true;
            }
        }
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
        public frmTehnologija(int SifraTehnologije, string Korisnik)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
            KorisnikP = Korisnik;
            TehnologijaPrenesena = SifraTehnologije;
            txtSifra.Text = TehnologijaPrenesena.ToString();
            if (Korisnik != "admin")
            {
                txtUkupnoTrase.Visible = false;
                txtUkupnoLokomotive.Visible = false;
                txtUkupnoZaposleni.Visible = false;
                txtUkupnoSumarno.Visible = false;
                txtDizel.Visible = false;
                txtEnergija.Visible = false;
                txtCenaL.Visible = false;
                txtUkupnol.Visible = false;
                txtFiksnaCenaL.Visible = false;
                txtUkupnoA.Visible = false;
                txtCenaA.Visible = false;
                txtFCenaA.Visible = false;
                lblDizel.Visible = false;
                lblEnergija.Visible = false;
                lblCenaT.Visible = false;
                lblFiksnaC.Visible = false;
                lblUkupnoT.Visible = false;
                lblCenaA.Visible = false;
                lblFiksnaA.Visible = false;
                lblUkupnoA.Visible = false;
                lblUkupnoTrase.Visible = false;
                lblUkupnoLokomotive.Visible = false;
                lblUkupnoZaposleni.Visible = false;
                lblSumarno.Visible = false;

            }
            else
            {
                txtUkupnoTrase.Visible = true;
                txtUkupnoLokomotive.Visible = true;
                txtUkupnoZaposleni.Visible = true;
                txtUkupnoSumarno.Visible = true;
                txtDizel.Visible = true;
                txtEnergija.Visible = true;
                txtCenaL.Visible = true;
                txtUkupnol.Visible = true;
                txtFiksnaCenaL.Visible = true;
                txtUkupnoA.Visible = true;
                txtCenaA.Visible = true;
                txtFCenaA.Visible = true;
                lblDizel.Visible = true;
                lblEnergija.Visible = true;
                lblCenaT.Visible = true;
                lblFiksnaC.Visible = true;
                lblUkupnoT.Visible = true;
                lblCenaA.Visible = true;
                lblFiksnaA.Visible = true;
                lblUkupnoA.Visible = true;
                lblUkupnoTrase.Visible = true;
                lblUkupnoLokomotive.Visible = true;
                lblUkupnoZaposleni.Visible = true;
                lblSumarno.Visible = true;
            }
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int Prazan = 0;
            if (chkPrazno.Checked == true)
            { Prazan = 1; }

            InsertTehnologija ins = new InsertTehnologija();
            if (status == true)
            {
                ins.InsTehnologija(Convert.ToInt32(cboPorudzbinaID.Text), Prazan, txtNapomenaZaglavlje.Text, Convert.ToDouble(txtTonaza.Value), Convert.ToDouble(txtTonazaPovratak.Value), Convert.ToInt32(cboTehnologijaID.SelectedValue), Convert.ToDouble(txtUkupnoVremeTransporta.Value));
                VratiZadnji();
            }
            else
            {
                ins.UpdTehnologija(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboPorudzbinaID.Text), Prazan, txtNapomenaZaglavlje.Text, Convert.ToDouble(txtTonaza.Value), Convert.ToDouble(txtTonazaPovratak.Value), Convert.ToInt32(cboTehnologijaID.SelectedValue), Convert.ToDouble(txtUkupnoVremeTransporta.Value));
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertTehnologija del = new InsertTehnologija();
            del.DeleteTehnologija(Convert.ToInt32(txtSifra.Text));
        }

        private void frmTehnologija_Load(object sender, EventArgs e)
        {
            /*
            var select = "  select NarociloPostav.NaPNarZap , NaPStNar, NaPartPlac as Partner, " +
           "NaDatNar as DatumNarudzbine, NaPNaziv as Naziv, NaPEM As JM, NaPem2 as JM2," +
           " NaPKolNar as Kolicina, NaPKolNar2 as KolicinaJM2, NaPOpomba as NHM, " +
           "NaPNote as Napomena   from Narocilo inner join NarociloPostav " +
" on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
" where Narocilo.NaStNar > 542 and NaStatus = 'PO' ";
            */

            var select =  "select MpSifra, MpStaraSif as Kod, MpNaziv as Naziv, MpSifEnoteMere1 as JM1, MpSifEnoteMere2 as JM2   from MaticniPodatki " +
            " where MpSifProdSkup = 1" ;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            DataView view = new DataView(ds.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            cboPorudzbinaID.DataSource = view;
            cboPorudzbinaID.DisplayMember = "Sifra";
            cboPorudzbinaID.ValueMember = "MpSifra";



            var select2 = " Select ID, (Rtrim(Voz) + '-' + Rtrim(Relacija)) as Opis from Trase";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboTrase.DataSource = ds2.Tables[0];
            cboTrase.DisplayMember = "Opis";
            cboTrase.ValueMember = "ID";

            var select6 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboStanicaOd.DataSource = ds6.Tables[0];
            cboStanicaOd.DisplayMember = "Stanica";
            cboStanicaOd.ValueMember = "ID";

            var select7 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboStanicaDo.DataSource = ds7.Tables[0];
            cboStanicaDo.DisplayMember = "Stanica";
            cboStanicaDo.ValueMember = "ID";


            var select8 = " select ID, Oznaka from LokomotivaSerija";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboSerija.DataSource = ds8.Tables[0];
            cboSerija.DisplayMember = "Oznaka";
            cboSerija.ValueMember = "ID";

            var select9 = " select ID, Naziv from VrstaAktivnosti";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection9);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);

            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            cboVrstaAktivnosti.DataSource = ds9.Tables[0];
            cboVrstaAktivnosti.DisplayMember = "Naziv";
            cboVrstaAktivnosti.ValueMember = "ID";

            var select10 = " select DmSifra, DmNaziv from DelovnaMesta";
            var s_connection10 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection10 = new SqlConnection(s_connection10);
            var c10 = new SqlConnection(s_connection10);
            var dataAdapter10 = new SqlDataAdapter(select10, c10);

            var commandBuilder10 = new SqlCommandBuilder(dataAdapter10);
            var ds10 = new DataSet();
            dataAdapter10.Fill(ds10);
            cboRadnoMesto.DataSource = ds10.Tables[0];
            cboRadnoMesto.DisplayMember = "DmNaziv";
            cboRadnoMesto.ValueMember = "DmSifra";


            var select14 = "    select ID, PorudzbinaID as MP, MaticniPodatki.MpNaziv, Tonaza, TonazaPovratak from Tehnologija " +
           " inner join MaticniPodatki on Tehnologija.PorudzbinaID = MaticniPodatki.MpSifra ";
            var s_connection14 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection14 = new SqlConnection(s_connection14);
            var c14 = new SqlConnection(s_connection14);
            var dataAdapter14 = new SqlDataAdapter(select14, c14);

            var commandBuilder14 = new SqlCommandBuilder(dataAdapter14);
            var ds14 = new DataSet();
            dataAdapter14.Fill(ds14);

            DataView view1 = new DataView(ds14.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            cboTehnologijaID.DataSource = view1;
            cboTehnologijaID.DisplayMember = "MpNaziv";
            cboTehnologijaID.ValueMember = "ID";

            if (TehnologijaPrenesena != 0)
            {
                RefreshDataGridTehnologijaAktivnosti();
                RefreshDataGridTehnologijaTrase();
                RefreshDataGridTehnologijaTraseLokomotiva();
                RefreshZaglavlje();
                prva();
                druga();
                treca();
                txtUkupnoSumarno.Value = txtUkupnoZaposleni.Value + txtUkupnoLokomotive.Value + txtUkupnoTrase.Value;
            }
        }

        private void RefreshZaglavlje()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select PorudzbinaID, Prazan, Napomena, Tonaza, TonazaPovratak, TehnologijaPovratna, UkupnoVremeTransporta from Tehnologija where ID = " + Convert.ToInt32(txtSifra.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();
            int Prazno = 0;
            while (dr.Read())
            {
                cboPorudzbinaID.SelectedValue = Convert.ToInt32(dr["PorudzbinaID"].ToString());
                Prazno = Convert.ToInt32(dr["Prazan"].ToString());
                txtTonaza.Value = Convert.ToDecimal(dr["Tonaza"].ToString());
                txtTonazaPovratak.Value = Convert.ToDecimal(dr["TonazaPovratak"].ToString());
                
                if (Prazno == 1)
                { chkPrazno.Checked = true; }

                txtNapomenaZaglavlje.Text = dr["Napomena"].ToString();
                cboTehnologijaID.SelectedValue = Convert.ToInt32(dr["TehnologijaPovratna"].ToString());
                txtUkupnoVremeTransporta.Value = Convert.ToDecimal(dr["UkupnoVremeTransporta"].ToString());
            }

            con.Close();



        }

        private void VratiZadnji()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Tehnologija", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }
           
            con.Close();


        }

        private void VratiZadnjiTrasa()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from TehnologijaTrase", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtIDTrase.Text = dr["ID"].ToString();
            }

            con.Close();


        }

        private void VratiZadnjiSerija()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from TehnologijaTrasaLokomotiva", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtIDSerija.Text = dr["ID"].ToString();
            }

            con.Close();


        }
        private void VratiZadnjiAktivnosti()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from TehnologijaAktivnosti", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtAktivnostiID.Text = dr["ID"].ToString();
            }

            con.Close();


        }

        private void RefreshDataGridTehnologijaTrase()
        {
            var select = "  SELECT TehnologijaTrase.[ID] , TehnologijaTrase.[Trasa], Trase.Voz as Trasa      ,[StanicaOd], stanice.Opis ,[StanicaDo], st2.Opis      ,[IDTehnologije], TehnologijaTrase.Povratak     FROM [TESTIRANJE].[dbo].[TehnologijaTrase]  inner join stanice on TehnologijaTrase.StanicaOd = stanice.id  inner join stanice st2 on TehnologijaTrase.StanicaDo = st2.id "+
            " inner join Trase on TehnologijaTrase.Trasa = Trase.ID " +
            " where TehnologijaTrase.IDTehnologije = " + Convert.ToInt32(txtSifra.Text);


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
            dataGridView1.Columns[0].Width = 25;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Trasa ID";
            dataGridView1.Columns[1].Width = 25;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Trasa";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "St1";
            dataGridView1.Columns[3].Width = 30;
            
            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "St1 Od";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "St2";
            dataGridView1.Columns[5].Width = 30;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "St1 Do";
            dataGridView1.Columns[6].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Tehn ID";
            dataGridView1.Columns[7].Width = 30;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Povratak";
            dataGridView1.Columns[8].Width = 30;
        }

        private void RefreshDataGridTehnologijaAktivnosti()
        {
            var select = "  select TehnologijaAktivnosti.ID, VrstaAktivnosti.Naziv, DelovnaMesta.DmNaziv, TehnologijaAktivnosti.Koef, TehnologijaAktivnosti.Ukupno, TehnologijaAktivnosti.Napomena  from TehnologijaAktivnosti " +
                    " inner join VrstaAktivnosti on VrstaAktivnosti.ID = TehnologijaAktivnosti.VrstaAktivnostiID " +
                    " inner join DelovnaMesta on DelovnaMesta.DMSifra = TehnologijaAktivnosti.RadnoMestoID  where IDTehnologije = " + Convert.ToInt32(txtSifra.Text);


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
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Vrsta aktivnosti";
            dataGridView3.Columns[1].Width = 90;

            DataGridViewColumn column2 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Radno mesto";
            dataGridView3.Columns[2].Width = 90;


            DataGridViewColumn column3 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Sati/Vagona";
            dataGridView3.Columns[3].Width = 40;
            if (KorisnikP != "admin")
            {
                DataGridViewColumn column4 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Ukupno";
                dataGridView3.Columns[4].Width = 40;
                dataGridView3.Columns[4].Visible = false;
            }
            else
            {
                DataGridViewColumn column4 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Ukupno";
                dataGridView3.Columns[4].Width = 70;
                dataGridView3.Columns[4].Visible = true;
            }

            DataGridViewColumn column5 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Napomena";
            dataGridView3.Columns[5].Width = 100;
            dataGridView3.Columns[5].Visible = true;
        }

        private void RefreshDataGridTehnologijaTraseLokomotiva()
        {
            var select = "  select TehnologijaTrasaLokomotiva.ID, IDSerije, LokomotivaSerija.Oznaka as Serija, " +
                            " IDTrase as TrasaID, Trase.Voz, " +
                            " TehnologijaTrasaLokomotiva.fiksna as FiksnaCena, TehnologijaTrasaLokomotiva.Sati,  " + 
                            " TehnologijaTrasaLokomotiva.Cena, TehnologijaTrasaLokomotiva.ukupno " +
                            " from TehnologijaTrasaLokomotiva inner join LokomotivaSerija " +
                            " on TehnologijaTrasaLokomotiva.IdSerije = LokomotivaSerija.ID " +
                            " inner join TehnologijaTrase on TehnologijaTrase.ID = TehnologijaTrasaLokomotiva.IDTrase " +
                            " inner join Trase " +
                            " on Trase.ID = TehnologijaTrase.Trasa where TehnologijaTrasaLokomotiva.IDTehnologije = " + Convert.ToInt32(txtSifra.Text);


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
            dataGridView2.Columns[0].Width = 25;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Serija ID";
            dataGridView2.Columns[1].Width = 25;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Serija";
            dataGridView2.Columns[2].Width = 35;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Trasa ID";
            dataGridView2.Columns[3].Width = 30;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Trasa";
            dataGridView2.Columns[4].Width = 50;

            if (KorisnikP != "admin")
            {

                DataGridViewColumn column6 = dataGridView2.Columns[5];
                dataGridView2.Columns[5].HeaderText = "Fiksna";
                dataGridView2.Columns[5].Width = 30;
                dataGridView2.Columns[5].Visible = false;

                DataGridViewColumn column7 = dataGridView2.Columns[6];
                dataGridView2.Columns[6].HeaderText = "Sati";
                dataGridView2.Columns[6].Width = 30;

                DataGridViewColumn column8 = dataGridView2.Columns[7];
                dataGridView2.Columns[7].HeaderText = "Cena";
                dataGridView2.Columns[7].Width = 30;
                dataGridView2.Columns[7].Visible = false;

                DataGridViewColumn column9 = dataGridView2.Columns[8];
                dataGridView2.Columns[8].HeaderText = "Ukupno";
                dataGridView2.Columns[8].Width = 40;
                dataGridView2.Columns[8].Visible = false;
            }
            else
            {
                DataGridViewColumn column6 = dataGridView2.Columns[5];
                dataGridView2.Columns[5].HeaderText = "Fiksna";
                dataGridView2.Columns[5].Width = 30;
                dataGridView2.Columns[5].Visible = true;

                DataGridViewColumn column7 = dataGridView2.Columns[6];
                dataGridView2.Columns[6].HeaderText = "Sati";
                dataGridView2.Columns[6].Width = 30;

                DataGridViewColumn column8 = dataGridView2.Columns[7];
                dataGridView2.Columns[7].HeaderText = "Cena";
                dataGridView2.Columns[7].Width = 30;
                dataGridView2.Columns[7].Visible = true;

                DataGridViewColumn column9 = dataGridView2.Columns[8];
                dataGridView2.Columns[8].HeaderText = "Ukupno";
                dataGridView2.Columns[8].Width = 40;
                dataGridView2.Columns[8].Visible = true;
            }
        }

        private void prva()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select SUM(cena) as ukupno, Sum(Dizel) as dizel, Sum(Energija) as energija from TehnologijaTrase where IDTehnologije = " + Convert.ToInt32(txtSifra.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if ((dr["ukupno"].ToString() != "")  && (dr["dizel"].ToString() != "") && (dr["energija"].ToString() != ""))
                { 
                txtUkupnoTrase.Value = Convert.ToDecimal(dr["ukupno"].ToString()) + Convert.ToDecimal(dr["dizel"].ToString()) + Convert.ToDecimal(dr["energija"].ToString());
                }

            }

            con.Close();
        }

        private void druga()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select isnull(SUM(ukupno),0) as ukupno from TehnologijaTrasaLokomotiva where IDTehnologije =  " + Convert.ToInt32(txtSifra.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtUkupnoLokomotive.Value = Convert.ToDecimal(dr["ukupno"].ToString());
            }

            con.Close();
        }

        private void treca()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select isnull(SUM(ukupno),0) as ukupno from TehnologijaAktivnosti where IDTehnologije =  " + Convert.ToInt32(txtSifra.Text), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtUkupnoZaposleni.Value = Convert.ToDecimal(dr["ukupno"].ToString());
            }

            con.Close();
        }

        private void VratiUkupneCene()
        {
            //UkupnoTrase

            prva();
            druga();
            treca();
            //ukupno serije

           

          

            txtUkupnoSumarno.Value = txtUkupnoZaposleni.Value + txtUkupnoLokomotive.Value + txtUkupnoTrase.Value;

        }

        private void btnUnesiTrasa_Click(object sender, EventArgs e)
        {
            int PomPovratak = 0;
            if (chkPovratak.Checked == true)
            {
                PomPovratak = 1;
            }
            
            
            InsertTehnologija ins = new InsertTehnologija();
            ins.InsTehnologijaTrase(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboTrase.SelectedValue), Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToDouble(txtCena.Value), Convert.ToDouble(txtDizel.Value), Convert.ToDouble(txtEnergija.Value), PomPovratak);
          
             RefreshDataGridTehnologijaTrase();
             VratiZadnjiTrasa();
             VratiUkupneCene();
             status = false;
        }

        private void btnIzbaciTrasa_Click(object sender, EventArgs e)
        {
            InsertTehnologija del = new InsertTehnologija();
            del.DelTehnologijaTrase(Convert.ToInt32(txtIDTrase.Text));
            RefreshDataGridTehnologijaTrase();
            status = false;
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            InsertTehnologija ins = new InsertTehnologija();
            ins.InsTehnologijaTraseLokomotiva(Convert.ToInt32(txtSifra.Text),Convert.ToInt32(txtIDTrase.Text), Convert.ToInt32(cboSerija.SelectedValue), Convert.ToDouble(txtFiksnaCenaL.Value), Convert.ToDouble(txtSatiL.Value), Convert.ToDouble(txtCenaL.Value), Convert.ToDouble(txtUkupnol.Value));
            RefreshDataGridTehnologijaTraseLokomotiva();
            VratiZadnjiSerija();
            VratiUkupneCene();

        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
           //Insert aktivnosti
            
            InsertTehnologija ins = new InsertTehnologija();
            ins.InsTehnologijaTraseAktivnosti(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboVrstaAktivnosti.SelectedValue), Convert.ToInt32(cboRadnoMesto.SelectedValue), Convert.ToDouble(txtSatiA.Value), txtNapomenaAktivnosti.Text, Convert.ToDouble(txtUkupnoA.Value));
            VratiZadnjiAktivnosti();
            RefreshDataGridTehnologijaAktivnosti();
            VratiUkupneCene();
        }

        private void cboTrase_Leave(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Cena, Pocetna, Krajnja from Trase where ID = " + Convert.ToInt32(cboTrase.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtCena.Value = Convert.ToDecimal(dr["Cena"].ToString());

                cboStanicaOd.SelectedValue = Convert.ToInt32(dr["Pocetna"].ToString());
                cboStanicaDo.SelectedValue = Convert.ToInt32(dr["Krajnja"].ToString());
            }

            con.Close();
        }

        private void sfButton4_Click(object sender, EventArgs e)
        {
            
            InsertTehnologija del = new InsertTehnologija();
            del.DelTehnologijaTraseLokomotiva(Convert.ToInt32(txtIDSerija.Text));
            RefreshDataGridTehnologijaTraseLokomotiva();

        }

        private void txtCenaL_ValueChanged(object sender, EventArgs e)
        {
            txtUkupnol.Value = (txtFiksnaCenaL.Value + (txtCenaL.Value * txtSatiL.Value)) * txtKurs.Value;
        }

        private void txtFiksnaCenaL_ValueChanged(object sender, EventArgs e)
        {
            txtUkupnol.Value = (txtFiksnaCenaL.Value + (txtCenaL.Value * txtSatiL.Value)) * txtKurs.Value;
        }

        private void txtSatiL_ValueChanged(object sender, EventArgs e)
        {
            txtUkupnol.Value = (txtFiksnaCenaL.Value + (txtCenaL.Value * txtSatiL.Value)) * txtKurs.Value; 
        }

        private void txtSatiA_ValueChanged(object sender, EventArgs e)
        {
            VratiVrednostAktivnosti(Convert.ToInt32(cboVrstaAktivnosti.SelectedValue));
        }

        private void VratiVrednostAktivnosti(int Aktivnost)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Cena, FisnaCena from VrstaAktivnosti where ID = " + Aktivnost, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtCenaA.Value = Convert.ToDecimal(dr["Cena"].ToString());
                txtFCenaA.Value = Convert.ToDecimal(dr["FisnaCena"].ToString());
            }

            txtUkupnoA.Value = (txtFCenaA.Value + (txtCenaA.Value * txtSatiA.Value)) * txtKurs.Value;

            con.Close();

        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        txtAktivnostiID.Text = row.Cells[0].Value.ToString();
                       // VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtIDTrase.Text = row.Cells[0].Value.ToString();
                        // VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                        txtIDSerija.Text = row.Cells[0].Value.ToString();
                        // VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            // txtAktivnostiID
            InsertTehnologija del = new InsertTehnologija();
            del.DelTehnologijaTraseAktivnosti(Convert.ToInt32(txtAktivnostiID.Text));
            RefreshDataGridTehnologijaAktivnosti();
        }

        private void sfButton5_Click(object sender, EventArgs e)
        {

            int PomPovratak = 0;
            if (chkPovratak.Checked == true)
            {
                PomPovratak = 1;
            }
            InsertTehnologija ins = new InsertTehnologija();
            ins.UpdTehnologijaTrase(Convert.ToInt32(txtIDTrase.Text), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboTrase.SelectedValue), Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToDouble(txtCena.Value), Convert.ToDouble(txtDizel.Value), Convert.ToDouble(txtEnergija.Value), PomPovratak);
            RefreshDataGridTehnologijaTrase();
            VratiUkupneCene();
        }

        private void sfButton6_Click(object sender, EventArgs e)
        {
            InsertTehnologija ins = new InsertTehnologija();
            ins.UpdTehnologijaTraseLokomotiva(Convert.ToInt32(txtIDSerija.Text), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtIDTrase.Text), Convert.ToInt32(cboSerija.SelectedValue), Convert.ToDouble(txtFiksnaCenaL.Value), Convert.ToDouble(txtSatiL.Value), Convert.ToDouble(txtCenaL.Value), Convert.ToDouble(txtUkupnol.Value));
            RefreshDataGridTehnologijaTraseLokomotiva();
            VratiZadnjiSerija();
            VratiUkupneCene();
        }

        private void cboSerija_Leave(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Tezina, Snaga  from LokomotivaSerija where Oznaka = '" + Convert.ToInt32(cboSerija.Text) + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtTezina.Value = Convert.ToDecimal(dr["Tezina"].ToString());
                txtSnaga.Value = Convert.ToDecimal(dr["Snaga"].ToString());
            }

            con.Close();
        }

        private void sfButton7_Click(object sender, EventArgs e)
        {

        }

        private void cboVrstaAktivnosti_Leave(object sender, EventArgs e)
        {
            VratiVrednostAktivnosti(Convert.ToInt32(cboVrstaAktivnosti.SelectedValue));
        }

        private void gradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFCenaA_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
