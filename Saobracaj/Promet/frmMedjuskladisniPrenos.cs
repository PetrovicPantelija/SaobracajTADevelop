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


namespace TrackModal.Promet
{
    public partial class frmMedjuskladisniPrenos : Form
    {
        string KorisnikCene;
       // bool status = false;
        bool usao = false;
        public frmMedjuskladisniPrenos()
        {
            InitializeComponent();
        }

        public frmMedjuskladisniPrenos(string Korisnik)
        {
            KorisnikCene = Korisnik;
            InitializeComponent();
        }

        private void VratiPodatkeMaxSledeci()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select (Max([PrStDokumenta]) + 1) as ID from Promet where VrstaDokumenta = 'PRI'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }



        private void frmMedjuskladisniPrenos_Load(object sender, EventArgs e)
        {
            dtpDatumRasporeda.Value = DateTime.Now;
            var select3 = " Select Distinct ID, Naziv From Skladista";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboSkladiste.DataSource = ds3.Tables[0];
            cboSkladiste.DisplayMember = "Naziv";
            cboSkladiste.ValueMember = "ID";

            cboSkladisteIzbor.DataSource = ds3.Tables[0];
            cboSkladisteIzbor.DisplayMember = "Naziv";
            cboSkladisteIzbor.ValueMember = "ID";

            var select4 = " Select Distinct ID, (Naziv + ' RB:' +  RegistarskaOznaka + ' IB:' + IndividualniBroj) as Naziv   From Vozila";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboSredstvoRada.DataSource = ds4.Tables[0];
            cboSredstvoRada.DisplayMember = "Naziv";
            cboSredstvoRada.ValueMember = "ID";


            var select5 = " Select Distinct ID, (Cast(ID as nvarchar(5)) + ' ' + Rtrim(Prezime) + ' ' + Rtrim(Ime)) as Naziv   From Zaposleni";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboZaposleni.DataSource = ds5.Tables[0];
            cboZaposleni.DisplayMember = "Naziv";
            cboZaposleni.ValueMember = "ID";

            //Dodato za pretragu
            var select = " Select Distinct ID, (NKM + '-' + Naziv) as NKM  From VrstaRobe";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboVrstaRobe.DataSource = ds.Tables[0];
            cboVrstaRobe.DisplayMember = "NKM";
            cboVrstaRobe.ValueMember = "ID";

            var select2 = " Select Distinct ID, Naziv From Komitenti where Vlasnik =1  order by Naziv";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboVlasnikKontejnera.DataSource = ds2.Tables[0];
            cboVlasnikKontejnera.DisplayMember = "Naziv";
            cboVlasnikKontejnera.ValueMember = "ID";

            /*
            var select9 = " Select Distinct ID, Naziv From TipKontenjera order by Naziv";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection9);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);

            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            cboTipKontejnera.DataSource = ds9.Tables[0];
            cboTipKontejnera.DisplayMember = "Naziv";
            cboTipKontejnera.ValueMember = "ID";
            */
            //End of dodato za


            VratiPodatkeMaxSledeci();
            usao = true;
        }

        private void cboSkladiste_SelectedValueChanged(object sender, EventArgs e)
        {
            if (usao == true)
            {
                var select = " Select ID, Oznaka From Pozicija where Skladiste = " + Convert.ToInt32(cboSkladiste.SelectedValue);
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                cboPozicija.DataSource = ds.Tables[0];
                cboPozicija.DisplayMember = "Oznaka";
                cboPozicija.ValueMember = "ID";
            }
        }

        private void RefreshDataGrid2()
        {
            var select = "  SELECT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
             " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
             " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
             " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
             " ,Promet.[Datum] ,Promet.[Korisnik] " +
             " FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
             " inner join Pozicija on Promet.LokacijaU = Pozicija.ID  where PrstDokumenta = " + Convert.ToInt32(txtSifra.Text);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "Šifra";
            dataGridView2.Columns[0].Width = 40;
            // dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Datum Transakcije";
            dataGridView2.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Vrsta Dokumenta";
            dataGridView2.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Br Dokumenta";
            dataGridView2.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Vrsta Prometa";
            dataGridView2.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Broj kontejnera";
            dataGridView2.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "PrPrimKol";
            dataGridView2.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "SkladID ";
            dataGridView2.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "Skladiste u";
            dataGridView2.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "LokacID ";
            dataGridView2.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView2.Columns[10];
            dataGridView2.Columns[10].HeaderText = "Lokac U";
            dataGridView2.Columns[10].Width = 80;

            DataGridViewColumn column12 = dataGridView2.Columns[11];
            dataGridView2.Columns[11].HeaderText = "Oznaka sled";
            dataGridView2.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView2.Columns[12];
            dataGridView2.Columns[12].HeaderText = "Datum";
            dataGridView2.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView2.Columns[13];
            dataGridView2.Columns[13].HeaderText = "Korisnik";
            dataGridView2.Columns[13].Width = 80;
        
        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            var select = "  SELECT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " + 
          " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
          " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
          " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
          " ,Promet.[Datum] ,Promet.[Korisnik], TipKontenjera.Naziv, VrstaRobe.Nkm as NHM, VrstaRobe.Naziv  " +
          " FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
          " inner join Pozicija on Promet.LokacijaU = Pozicija.ID " +
         "   inner join PrijemKontejneraVozStavke on Promet.[PrOznSled] = PrijemKontejneraVozStavke.Id " +
         " inner join TipKontenjera on TipKontenjera.Id = PrijemKontejneraVozStavke.TipKontejnera " +
         " inner join VrstaRobe on VrstaRobe.Id = PrijemKontejneraVozStavke.VrstaRobe" +
          "  where Zatvoren = 0 and SkladisteU = " + Convert.ToInt32(cboSkladisteIzbor.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 40;
            // dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Datum Transakcije";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Vrsta Dokumenta";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Br Dokumenta";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vrsta Prometa";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "PrPrimKol";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "SkladID ";
            dataGridView1.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Skladiste u";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "LokacID ";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Lokac U";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Oznaka sled";
            dataGridView1.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Datum";
            dataGridView1.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Korisnik";
            dataGridView1.Columns[13].Width = 80;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Tip kontejnera";
            dataGridView1.Columns[14].Width = 80;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "NHM";
            dataGridView1.Columns[15].Width = 80;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Roba";
            dataGridView1.Columns[16].Width = 80;
        }

        private void btnUbaci_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Dokumeta.InsertPromet ins = new Dokumeta.InsertPromet();
                int pom1 = 1;
                //int pom2 = 0;
                int pom3 = 1;
                string s1 = "MSP";
                string s2 = "MSP";

                if (row.Selected == true)
                {
                    string poms = row.Cells[2].Value.ToString();
                    int pozicija = Convert.ToInt32(cboPozicija.SelectedValue);
                    /*
                      SELECT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " + 
            " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
            " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
            " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
            " ,Promet.[Datum] ,Promet.[Korisnik]
                      */
                   // ins.InsProm(Convert.ToDateTime(dtpDatumPrijema.Value), s1, Convert.ToInt32(txtSifra.Text), row.Cells[0].Value.ToString(), s2, pom3, Convert.ToDouble(pom1), Convert.ToInt32(cboSkladiste.SelectedValue), pozicija, pom2, pom1, poms, Convert.ToDateTime(DateTime.Now), KorisnikCene, Convert.ToInt32(cboSredstvoRada.SelectedValue), Convert.ToInt32(cboZaposleni.SelectedValue), Convert.ToDateTime(dtpDatumRasporeda.Value));
                    ins.InsProm(Convert.ToDateTime(dtpDatumPrijema.Value), s1, Convert.ToInt32(txtSifra.Text), row.Cells[5].Value.ToString(), s2, pom3, pom1,                   Convert.ToInt32(cboSkladiste.SelectedValue), pozicija, Convert.ToInt32(row.Cells[7].Value.ToString()), Convert.ToInt32(row.Cells[9].Value.ToString()), row.Cells[11].Value.ToString(), Convert.ToDateTime(DateTime.Now), KorisnikCene,0,0, Convert.ToDateTime(dtpDatumRasporeda.Value));
                    ins.UpdateZatvoren(Convert.ToInt32(row.Cells[0].Value.ToString()));
                }
            }
            RefreshDataGrid2();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                /*
                  var select = "";
                    if (chkVoz.Checked == true)
                    {
                        select = "  select BrojKontejnera, VrstaManipulacije.Naziv, Komitenti.Naziv, NaruceneManipulacije.ID as NM, NaruceneManipulacije.IDPrijemaVoza from NaruceneManipulacije " +
            " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
            " inner join Komitenti on  NaruceneManipulacije.Platilac = Komitenti.ID " +
            " where NaruceneManipulacije.IDPrijemaVoza = " + Convert.ToInt32(cboPrijemVozom.SelectedValue) + " and BrojKontejnera = '" + row.Cells[0].Value.ToString() + "'";
                    }
                    else
                    {
                        select = "  select BrojKontejnera, VrstaManipulacije.Naziv, Komitenti.Naziv, NaruceneManipulacije.ID as NM, NaruceneManipulacije.IDPrijemaVoza from NaruceneManipulacije " +
               " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
               " inner join Komitenti on  NaruceneManipulacije.Platilac = Komitenti.ID " +
               " where IdPrijemaKamionom = " + Convert.ToInt32(cboPrijemKamionom.SelectedValue) + " and BrojKontejnera = '" + row.Cells[0].Value.ToString() + "'";
                    }
                */
                if (row.Selected == true)
                {

                    var select = "  select BrojKontejnera, VrstaManipulacije.Naziv, Komitenti.Naziv,NaruceneManipulacije.ID as NM, NaruceneManipulacije.IDPrijemaVoza,0 as IDPrijemaKamionom, VrstaManipulacije.ID from NaruceneManipulacije " +
                    " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
                    " inner join Komitenti on  NaruceneManipulacije.Platilac = Komitenti.ID " +
                    " where NaruceneManipulacije.IDPrijemaVoza = (select IDNadredjenog from PrijemKontejneraVozStavke where ID=" + Convert.ToInt32(row.Cells[11].Value.ToString()) + ") " + " and BrojKontejnera = '" + row.Cells[5].Value.ToString() + "'" +
                    " union "  +
                    " select BrojKontejnera, VrstaManipulacije.Naziv, Komitenti.Naziv,NaruceneManipulacije.ID as NM, " +
                     " NaruceneManipulacije.IDPrijemaVoza, NaruceneManipulacije.IDPrijemaKamionom,  VrstaManipulacije.ID from NaruceneManipulacije inner join VrstaManipulacije " +
                     " on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID  inner join Komitenti on " +
                     " NaruceneManipulacije.Platilac = Komitenti.ID  where NaruceneManipulacije.IDPrijemaKamionom =  " +
                     "  (select IDNadredjenog from PrijemKontejneraVozStavke where ID =" + Convert.ToInt32(row.Cells[11].Value.ToString()) + ") " + " and BrojKontejnera = '" + row.Cells[5].Value.ToString() + "'";

                    //NaruceneManipulacije.IdPrijemaVoza =" + Convert.ToInt32(row.Cells[11].Value.ToString()) + "" + " and

                    /*
                                        select = "  select BrojKontejnera, VrstaManipulacije.Naziv, Komitenti.Naziv, NaruceneManipulacije.ID as NM, NaruceneManipulacije.IDPrijemaVoza from NaruceneManipulacije " +
                               " inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
                               " inner join Komitenti on  NaruceneManipulacije.Platilac = Komitenti.ID " +
                               " where NaruceneManipulacije.IDPrijemaVoza = " + Convert.ToInt32(cboPrijemVozom.SelectedValue) + " and BrojKontejnera = '" + row.Cells[0].Value.ToString() + "'";
                                 */


                    var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                    SqlConnection myConnection = new SqlConnection(s_connection);
                    var c = new SqlConnection(s_connection);
                    var dataAdapter = new SqlDataAdapter(select, c);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView3.ReadOnly = true;
                    dataGridView3.DataSource = ds.Tables[0];

                    //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
                    DataGridViewColumn column = dataGridView3.Columns[0];
                    dataGridView3.Columns[0].HeaderText = "Broj kontejnera";
                    dataGridView3.Columns[0].Width = 80;

                    DataGridViewColumn column1 = dataGridView3.Columns[1];
                    dataGridView3.Columns[1].HeaderText = "Manipulacija";
                    dataGridView3.Columns[1].Width = 200;

                    DataGridViewColumn column2 = dataGridView3.Columns[2];
                    dataGridView3.Columns[2].HeaderText = "Platilac";
                    dataGridView3.Columns[2].Width = 170;

                    DataGridViewColumn column3 = dataGridView3.Columns[3];
                    dataGridView3.Columns[3].HeaderText = "NM";
                    dataGridView3.Columns[3].Width = 80;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Dokumeta.InsertPromet ins = new Dokumeta.InsertPromet();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected == true)
                    {

                        ins.DeleteProm(Convert.ToInt32(row.Cells[0].Value));

                    }
                }
                RefreshDataGrid2();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            VratiPodatkeMaxSledeci();
        }

        private void tsPrvi_Click(object sender, EventArgs e)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Min([PrStDokumenta]) as ID from Promet where VrstaDokumenta = 'MSP'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }
            RefreshDataGrid2();
            con.Close();

        }

        private void tsPoslednja_Click(object sender, EventArgs e)
        {


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([PrStDokumenta]) as ID from Promet where VrstaDokumenta = 'MSP'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }
            RefreshDataGrid2();
            con.Close();



        }

        private void tsNazad_Click(object sender, EventArgs e)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);
            int prvi = 0;
            con.Open();

            SqlCommand cmd = new SqlCommand("select Max(PrStDokumenta) as ID from Promet where VrstaDokumenta = 'MSP' and PrStDokumenta <" + Convert.ToInt32(txtSifra.Text) + " Order by ID desc", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                prvi = Convert.ToInt32(dr["ID"].ToString());
                txtSifra.Text = prvi.ToString();
            }

            con.Close();
            RefreshDataGrid2();

        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([Broj]) as ID from Promet where VrstaDokumenta = 'MSP'", con);
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

            SqlCommand cmd = new SqlCommand("select Min(PrStDokumenta) as ID from Promet where VrstaDokumenta = 'MSP'  and Broj >" + Convert.ToInt32(txtSifra.Text) + " Order by ID", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                zadnji = Convert.ToInt32(dr["ID"].ToString());
                txtSifra.Text = zadnji.ToString();
            }

            con.Close();
            RefreshDataGrid2();
            /*
                        if ((Convert.ToInt32(txtSifra.Text) + 1) == zadnji)
                          //  VratiPodatke((Convert.ToInt32(zadnji).ToString()));
                        else
                           // VratiPodatke((Convert.ToInt32(txtSifra.Text) + 1).ToString());
                        */
        }

        private void RefreshDataGrid4()
        {
            var select = "SELECT PrometManipulacije.Id AS ID, PrometManipulacije.PRStDokumenta, PrometManipulacije.BrojKontejnera AS BrojKontrejnera, PrometManipulacije.ManipulacijaID, PrometManipulacije.NajavaID, " +
                       " PrometManipulacije.Datum AS Datum, PrometManipulacije.Korisnik AS Korisnik, Zaposleni.Prezime, Zaposleni.Ime, Vozila.Naziv " +
                       " FROM  PrometManipulacije INNER JOIN " +
                      "  Zaposleni ON PrometManipulacije.Zaposleni = Zaposleni.ID INNER JOIN " +
                       " Vozila ON PrometManipulacije.SredstvoRada = Vozila.ID  and PrStDokumenta =  " + Convert.ToInt32(txtSifra.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = false;
            dataGridView4.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView4.Columns[0];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[0].Width = 40;
            // dataGridView2.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView4.Columns[1];
            dataGridView4.Columns[1].HeaderText = "Dokument";
            dataGridView4.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView4.Columns[2];
            dataGridView4.Columns[2].HeaderText = "Broj kontejnera";
            dataGridView4.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView4.Columns[3];
            dataGridView4.Columns[3].HeaderText = "MAN id";
            dataGridView4.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView4.Columns[4];
            dataGridView4.Columns[4].HeaderText = "NAJ ID";
            dataGridView4.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView4.Columns[5];
            dataGridView4.Columns[5].HeaderText = "Datum";
            dataGridView4.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView4.Columns[6];
            dataGridView4.Columns[6].HeaderText = "Korisnik";
            dataGridView4.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView4.Columns[7];
            dataGridView4.Columns[7].HeaderText = "Prezime ";
            dataGridView4.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView4.Columns[8];
            dataGridView4.Columns[8].HeaderText = "Ime";
            dataGridView4.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView4.Columns[9];
            dataGridView4.Columns[9].HeaderText = "Sredstvo rada";
            dataGridView4.Columns[9].Width = 80;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Dokumeta.InsertPromet ins = new Dokumeta.InsertPromet();
                if (row.Selected == true)
                {
                    string poms = row.Cells[2].Value.ToString();

                  
                        foreach (DataGridViewRow rowM in dataGridView3.Rows)
                        {
                            if (rowM.Selected == true)
                            {
                                ins.InsPromMan(Convert.ToInt32(txtSifra.Text), rowM.Cells[0].Value.ToString(), Convert.ToInt32(rowM.Cells[6].Value.ToString()), Convert.ToInt32(rowM.Cells[3].Value.ToString()), Convert.ToInt32(cboSredstvoRada.SelectedValue), Convert.ToInt32(cboZaposleni.SelectedValue), Convert.ToDateTime(DateTime.Now), KorisnikCene, cboSkladisteIzbor.Text, row.Cells[11].Value.ToString(), cboSkladiste.Text, cboPozicija.Text);
                            }
                        }
                   
                   
                }
            }
            RefreshDataGrid4();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string broj = txtSifra.Text;
            Promet.frmNalozi nal = new Promet.frmNalozi(broj);
            nal.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            string broj = txtSifra.Text;
            Promet.frmSredstvoRada sr = new Promet.frmSredstvoRada(broj);
            sr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Dokumeta.InsertPromet del = new Dokumeta.InsertPromet();
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.Selected == true)
                    {
                        del.DeletePromManipulacije(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                }
                RefreshDataGrid4();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var select = "  SELECT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
         " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
         " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
         " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
         " ,Promet.[Datum] ,Promet.[Korisnik], TipKontenjera.Naziv, VrstaRobe.Nkm as NHM, VrstaRobe.Naziv  " +
         " FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
         " inner join Pozicija on Promet.LokacijaU = Pozicija.ID " +
        "   inner join PrijemKontejneraVozStavke on Promet.[PrOznSled] = PrijemKontejneraVozStavke.Id " +
        " inner join TipKontenjera on TipKontenjera.Id = PrijemKontejneraVozStavke.TipKontejnera " +
        " inner join VrstaRobe on VrstaRobe.Id = PrijemKontejneraVozStavke.VrstaRobe" +
         "  where Zatvoren = 0 and SkladisteU = " + Convert.ToInt32(cboSkladisteIzbor.SelectedValue) + " and PrijemKontejneraVozStavke.VrstaRobe = " + Convert.ToInt32(cboVrstaRobe.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 40;
            // dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Datum Transakcije";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Vrsta Dokumenta";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Br Dokumenta";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vrsta Prometa";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "PrPrimKol";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "SkladID ";
            dataGridView1.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Skladiste u";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "LokacID ";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Lokac U";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Oznaka sled";
            dataGridView1.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Datum";
            dataGridView1.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Korisnik";
            dataGridView1.Columns[13].Width = 80;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Tip kontejnera";
            dataGridView1.Columns[14].Width = 80;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "NHM";
            dataGridView1.Columns[15].Width = 80;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Roba";
            dataGridView1.Columns[16].Width = 80;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var select = "  SELECT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
       " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
       " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
       " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
       " ,Promet.[Datum] ,Promet.[Korisnik], TipKontenjera.Naziv, VrstaRobe.Nkm as NHM, VrstaRobe.Naziv  " +
       " FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
       " inner join Pozicija on Promet.LokacijaU = Pozicija.ID " +
      "   inner join PrijemKontejneraVozStavke on Promet.[PrOznSled] = PrijemKontejneraVozStavke.Id " +
      " inner join TipKontenjera on TipKontenjera.Id = PrijemKontejneraVozStavke.TipKontejnera " +
      " inner join VrstaRobe on VrstaRobe.Id = PrijemKontejneraVozStavke.VrstaRobe" +
       "  where Zatvoren = 0 and SkladisteU = " + Convert.ToInt32(cboSkladisteIzbor.SelectedValue) + " and PrijemKontejneraVozStavke.VrstaRobe = " + Convert.ToInt32(cboVrstaRobe.SelectedValue) +  " and PrijemKontejneraVozStavke.BrojKontejnera = '" + txtBrojKontejnera.Text + "'" ;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 40;
            // dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Datum Transakcije";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Vrsta Dokumenta";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Br Dokumenta";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vrsta Prometa";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "PrPrimKol";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "SkladID ";
            dataGridView1.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Skladiste u";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "LokacID ";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Lokac U";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Oznaka sled";
            dataGridView1.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Datum";
            dataGridView1.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Korisnik";
            dataGridView1.Columns[13].Width = 80;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Tip kontejnera";
            dataGridView1.Columns[14].Width = 80;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "NHM";
            dataGridView1.Columns[15].Width = 80;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Roba";
            dataGridView1.Columns[16].Width = 80;
        }

        private void button4_Click(object sender, EventArgs e)
        {
          var select = "  SELECT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
           " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
           " ,Promet.[PrPrimKol] ,Promet.[SkladisteU], Skladista.Naziv as Skladiste " +
           " ,Promet.[LokacijaU] as LokacijaU,Pozicija.Oznaka ,Promet.[PrOznSled] " +
           " ,Promet.[Datum] ,Promet.[Korisnik], TipKontenjera.Naziv, VrstaRobe.Nkm as NHM, VrstaRobe.Naziv  " +
           " FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
           " inner join Pozicija on Promet.LokacijaU = Pozicija.ID " +
           " inner join PrijemKontejneraVozStavke on Promet.[PrOznSled] = PrijemKontejneraVozStavke.Id " +
           " inner join TipKontenjera on TipKontenjera.Id = PrijemKontejneraVozStavke.TipKontejnera " +
           " inner join VrstaRobe on VrstaRobe.Id = PrijemKontejneraVozStavke.VrstaRobe" +
           "  where Zatvoren = 0 and SkladisteU = " + Convert.ToInt32(cboSkladisteIzbor.SelectedValue) + " and PrijemKontejneraVozStavke.VrstaRobe = " + Convert.ToInt32(cboVrstaRobe.SelectedValue) +" and PrijemKontejneraVozStavke.BrojKontejnera = '" + txtBrojKontejnera.Text + "'" + " and PrijemKontejneraVozStavke.VlasnikKontejnera = " + Convert.ToInt32(cboVlasnikKontejnera.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView2.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 40;
            // dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Datum Transakcije";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Vrsta Dokumenta";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Br Dokumenta";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vrsta Prometa";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "PrPrimKol";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "SkladID ";
            dataGridView1.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Skladiste u";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "LokacID ";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Lokac U";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Oznaka sled";
            dataGridView1.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Datum";
            dataGridView1.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Korisnik";
            dataGridView1.Columns[13].Width = 80;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Tip kontejnera";
            dataGridView1.Columns[14].Width = 80;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "NHM";
            dataGridView1.Columns[15].Width = 80;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Roba";
            dataGridView1.Columns[16].Width = 80;

        }
    }
}
