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

namespace Testiranje.Dokumeta
{
    public partial class frmVozila : Form
    {
        
            string KorisnikCene;
        bool status = false;
        public frmVozila()
        {
            InitializeComponent();
        }

        public frmVozila(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
            txtSifra.Text = "";
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int Servis = 0;
            int Godisnji = 0;
            int Tromesecni = 0;
            int Sestomesecni = 0;

            if (chkUradjenServis.Checked == true)
            { Servis = 1; }
            if (chkUradjenGodisnji.Checked == true)
            { Godisnji = 1; }
            if (chkUradjenSestomesecni.Checked == true)
            { Sestomesecni = 1; }
            if (chkUradjenTromesecni.Checked == true)
            { Tromesecni = 1; }

            if (status == true)
            {
                InsertVozila ins = new InsertVozila();
                ins.InsVozila(txtNaziv.Text, txtIndividualniBroj.Text, txtLicencaBroj.Text, Convert.ToDateTime(dtpLicencaVaziDo.Value), txtNamena.Text, txtVrsta.Text, Convert.ToInt32(txtBrojOsovina.Text), txtRegistarskaOznaka.Text, txtGodinaProizvodnje.Text, Convert.ToDouble(txtSopstvenaTezina.Text), Convert.ToDateTime(dtpNarednaRegistracija.Value), Convert.ToDateTime(dtpSestomesecniTehnicki.Value), Convert.ToDateTime(dtpGodisniTehnicki.Value), Convert.ToDateTime(dtpTahograf.Value), Convert.ToDateTime(dtpPPAparat.Value), Convert.ToDateTime(dtpServis.Value), Convert.ToDateTime(dtpAtest.Value), Convert.ToDouble(txtNosivost.Text), txtNapomena.Text, txtSifraERP.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, Tromesecni, Sestomesecni, Servis, Convert.ToDateTime(dtpUradjenTromesecni.Value), Convert.ToDateTime(dtpUradjenSestomesecni.Value), Convert.ToDateTime(dtpUradjenServis.Value), Convert.ToDateTime(dtpUradjenGodisnji.Value), Convert.ToDateTime(dtpTromesecniTehnicki.Value), Godisnji);
                status = false;
            }
            else
            {
                //int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik
                InsertVozila upd = new InsertVozila();
                upd.UpdVozila(Convert.ToInt32(txtSifra.Text), txtNaziv.Text, txtIndividualniBroj.Text, txtLicencaBroj.Text, Convert.ToDateTime(dtpLicencaVaziDo.Value), txtNamena.Text, txtVrsta.Text, Convert.ToInt32(txtBrojOsovina.Text), txtRegistarskaOznaka.Text, txtGodinaProizvodnje.Text, Convert.ToDouble(txtSopstvenaTezina.Text), Convert.ToDateTime(dtpNarednaRegistracija.Value), Convert.ToDateTime(dtpSestomesecniTehnicki.Value), Convert.ToDateTime(dtpGodisniTehnicki.Value), Convert.ToDateTime(dtpTahograf.Value), Convert.ToDateTime(dtpPPAparat.Value), Convert.ToDateTime(dtpServis.Value), Convert.ToDateTime(dtpAtest.Value), Convert.ToDouble(txtNosivost.Text), txtNapomena.Text, txtSifraERP.Text, Convert.ToDateTime(DateTime.Now), KorisnikCene, Tromesecni, Sestomesecni, Servis, Convert.ToDateTime(dtpUradjenTromesecni.Value), Convert.ToDateTime(dtpUradjenSestomesecni.Value), Convert.ToDateTime(dtpUradjenServis.Value), Convert.ToDateTime(dtpUradjenGodisnji.Value), Convert.ToDateTime(dtpTromesecniTehnicki.Value), Godisnji);
                status = false;
            }
            RefreshDataGrid();
            VratiPodatkeMax();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                InsertVozila upd = new InsertVozila();
                upd.DeleteVozila(Convert.ToInt32(txtSifra.Text));
                RefreshDataGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            
        }

        private void RefreshDataGrid()
        {
            var select = "  SELECT [ID],[Naziv],[IndividualniBroj] ,[LicencaBroj],[LicencaVaziDo],[Namena] " +
     " ,[Vrsta],[BrojOsovina],[RegistarskaOznaka],[GodinaProizvodnje],[SopstvenaTezina],[NarednaREgistracija] " +
     " ,[TromesecniTehnicki],[SetomesecniTehnicki],[GodisnjiTehnicki],[servis],[TahografSertifikat] " +
     " ,[PPAparat],[Atest],[Nosivost],[Napomena],[SifraERP],[Datum],[Korisnik], " +
    " CASE WHEN UradjenTromesecni > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenTromesecni,  " +
     " CASE WHEN UradjenSetomesecni > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenSetomesecni,  " +
      " CASE WHEN UradjenGodisnji > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenGodisnji,  " +
       " CASE WHEN UradjenServis > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenServis,  " +
     " [DatumUradjenTromesecni],[DatumUradjenSetomesecni],[DatumUradjenGodisnji],[DatumUradjenServis] " +   
     "   FROM [dbo].[Vozila]";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);
// [ID],[Naziv],[IndividualniBroj] ,[LicencaBroj],[LicencaVaziDo],[Namena]
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
            dataGridView1.Columns[1].HeaderText = "Naziv";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Individualni broj";
            dataGridView1.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Licenca broj";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Licenca važi do";
            dataGridView1.Columns[4].Width = 50;


            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Namena";
            dataGridView1.Columns[5].Width = 100;
           // [Vrsta],[BrojOsovina],[RegistarskaOznaka],[GodinaProizvodnje],[SopstvenaTezina],[NarednaREgistracija] " +
            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Vrsta";
            dataGridView1.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Broj osovina";
            dataGridView1.Columns[7].Width = 40;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Registarska oznaka";
            dataGridView1.Columns[8].Width = 100;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Godina proizvodnje";
            dataGridView1.Columns[9].Width = 70;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Sopst težina";
            dataGridView1.Columns[10].Width = 100;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Naredna regis.";
            dataGridView1.Columns[11].Width = 70;

            //" ,[TromesecniTehnicki],[SetomesecniTehnicki],[GodisnjiTehnicki],[servis],[TahografSertifikat] " +

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Tromesečni tehn";
            dataGridView1.Columns[12].Width = 70;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Šestomesečni tehn";
            dataGridView1.Columns[13].Width = 70;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Godišnji tehn";
            dataGridView1.Columns[14].Width = 70;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "Servis";
            dataGridView1.Columns[15].Width = 70;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Tahograf";
            dataGridView1.Columns[16].Width = 70;

            // " ,[PPAparat],[Atest],[Nosivost],[Napomena],[SifraERP],[Datum],[Korisnik], " +

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "PP Aparat";
            dataGridView1.Columns[17].Width = 70;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "ATest";
            dataGridView1.Columns[18].Width = 70;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Nosivost";
            dataGridView1.Columns[19].Width = 70;

            DataGridViewColumn column21 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Napomena";
            dataGridView1.Columns[20].Width = 70;

            DataGridViewColumn column22 = dataGridView1.Columns[21];
            dataGridView1.Columns[21].HeaderText = "Šifra ERP";
            dataGridView1.Columns[21].Width = 70;

            DataGridViewColumn column23 = dataGridView1.Columns[22];
            dataGridView1.Columns[22].HeaderText = "Datum";
            dataGridView1.Columns[22].Width = 70;

            DataGridViewColumn column24 = dataGridView1.Columns[23];
            dataGridView1.Columns[23].HeaderText = "Korisnik";
            dataGridView1.Columns[23].Width = 70;
/*
             " CASE WHEN UradjenTromesecni > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenTromesecni,  " +
     " CASE WHEN UradjenSetomesecni > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenSetomesecni,  " +
      " CASE WHEN UradjenGodisnji > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenGodisnji,  " +
       " CASE WHEN UradjenServis > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenServis,  " +
 * */
            DataGridViewColumn column25 = dataGridView1.Columns[24];
            dataGridView1.Columns[24].HeaderText = "Tromesečni";
            dataGridView1.Columns[24].Width = 50;

            DataGridViewColumn column26 = dataGridView1.Columns[25];
            dataGridView1.Columns[25].HeaderText = "Šestomesečni";
            dataGridView1.Columns[25].Width = 50;

            DataGridViewColumn column27 = dataGridView1.Columns[26];
            dataGridView1.Columns[26].HeaderText = "Godišnji";
            dataGridView1.Columns[26].Width = 50;

            DataGridViewColumn column28 = dataGridView1.Columns[27];
            dataGridView1.Columns[27].HeaderText = "Servis";
            dataGridView1.Columns[27].Width = 50;

           // [DatumUradjenTromesecni],[DatumUradjenSetomesecni],[DatumUradjenGodisnji],[DatumUradjenServis] 

            DataGridViewColumn column29 = dataGridView1.Columns[28];
            dataGridView1.Columns[28].HeaderText = "Ur tromesečni";
            dataGridView1.Columns[28].Width = 50;

            DataGridViewColumn column30 = dataGridView1.Columns[29];
            dataGridView1.Columns[29].HeaderText = "Ur šestomesečni";
            dataGridView1.Columns[29].Width = 50;

            DataGridViewColumn column31 = dataGridView1.Columns[30];
            dataGridView1.Columns[30].HeaderText = "Ur godišnji";
            dataGridView1.Columns[30].Width = 50;

            DataGridViewColumn column32 = dataGridView1.Columns[31];
            dataGridView1.Columns[31].HeaderText = "Ur servis";
            dataGridView1.Columns[31].Width = 50;
        }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand(" SELECT [ID],[Naziv],[IndividualniBroj] ,[LicencaBroj],[LicencaVaziDo],[Namena] " +
     " ,[Vrsta],[BrojOsovina],[RegistarskaOznaka],[GodinaProizvodnje],[SopstvenaTezina],[NarednaREgistracija] " +
     " ,[TromesecniTehnicki],[SetomesecniTehnicki],[GodisnjiTehnicki],[servis],[TahografSertifikat] " +
     " ,[PPAparat],[Atest],[Nosivost],[Napomena],[SifraERP]," +
    " CASE WHEN UradjenTromesecni > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenTromesecni,  " +
     " CASE WHEN UradjenSetomesecni > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenSetomesecni,  " +
      " CASE WHEN UradjenGodisnji > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenGodisnji,  " +
       " CASE WHEN UradjenServis > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UradjenServis,  " +
     " [DatumUradjenTromesecni],[DatumUradjenSetomesecni],[DatumUradjenGodisnji],[DatumUradjenServis] " +
     "   FROM [dbo].[Vozila] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["DatumUradjenServis"].ToString() == "")
                    dtpUradjenServis.Value = dtpUradjenServis.MinDate; 
                else
                dtpUradjenServis.Value = Convert.ToDateTime(dr["DatumUradjenServis"].ToString());

                if (dr["DatumUradjenGodisnji"].ToString() == "")
                    dtpUradjenGodisnji.Value = dtpUradjenGodisnji.MinDate;
                else
                dtpUradjenGodisnji.Value = Convert.ToDateTime(dr["DatumUradjenGodisnji"].ToString());


                if (dr["DatumUradjenSetomesecni"].ToString() == "")
                    dtpUradjenSestomesecni.Value = dtpUradjenSestomesecni.MinDate;
                else
                dtpUradjenSestomesecni.Value = Convert.ToDateTime(dr["DatumUradjenSetomesecni"].ToString());

                if (dr["DatumUradjenTromesecni"].ToString() == "")
                    dtpUradjenTromesecni.Value = dtpUradjenTromesecni.MinDate;
                else
                dtpUradjenTromesecni.Value = Convert.ToDateTime(dr["DatumUradjenTromesecni"].ToString()); 
                // Convert.ToInt32(cboTipCenovnika.SelectedValue), Convert.ToInt32(cboKomitent.SelectedValue), Convert.ToDouble(txtCena.Text), Convert.ToInt32(cboVrstaManipulacije.SelectedValue), Convert.ToDateTime(DateTime.Now), KorisnikCene
                if (dr["UradjenTromesecni"].ToString() == "True")
                { chkUradjenTromesecni.Checked = true; }
                else { chkUradjenTromesecni.Checked = false; }

                if (dr["UradjenSetomesecni"].ToString() == "True")
                { chkUradjenSestomesecni.Checked = true; }
                else { chkUradjenSestomesecni.Checked = false; }

                if (dr["UradjenGodisnji"].ToString() == "True")
                { chkUradjenGodisnji.Checked = true; }
                else { chkUradjenGodisnji.Checked = false; }


                if (dr["UradjenServis"].ToString() == "True")
                { chkUradjenServis.Checked = true; }
                else { chkUradjenServis.Checked = false; }
               
                txtSifraERP.Text = dr["SifraErp"].ToString();
                txtNapomena.Text = dr["Napomena"].ToString();
                txtNosivost.Value = Convert.ToDecimal(dr["Nosivost"].ToString());

                if (dr["Atest"].ToString() == "")
                    dtpAtest.Value = dtpAtest.MinDate;
                else
                dtpAtest.Value = Convert.ToDateTime(dr["Atest"].ToString());

                if (dr["PPAparat"].ToString() == "")
                    dtpPPAparat.Value = dtpPPAparat.MinDate;
                else
                dtpPPAparat.Value = Convert.ToDateTime(dr["PPAparat"].ToString());

                if (dr["TahografSertifikat"].ToString() == "")
                    dtpTahograf.Value = dtpTahograf.MinDate;
                else
                dtpTahograf.Value = Convert.ToDateTime(dr["TahografSertifikat"].ToString());

                if (dr["servis"].ToString() == "")
                    dtpServis.Value = dtpServis.MinDate;
                else
                dtpServis.Value = Convert.ToDateTime(dr["servis"].ToString());

                if (dr["GodisnjiTehnicki"].ToString() == "")
                    dtpGodisniTehnicki.Value = dtpGodisniTehnicki.MinDate;
                else
                dtpGodisniTehnicki.Value = Convert.ToDateTime(dr["GodisnjiTehnicki"].ToString());

                if (dr["SetomesecniTehnicki"].ToString() == "")
                    dtpSestomesecniTehnicki.Value = dtpSestomesecniTehnicki.MinDate;
                else
                dtpSestomesecniTehnicki.Value = Convert.ToDateTime(dr["SetomesecniTehnicki"].ToString());

                if (dr["TromesecniTehnicki"].ToString() == "")
                    dtpTromesecniTehnicki.Value = dtpTromesecniTehnicki.MinDate;
                else
                dtpTromesecniTehnicki.Value = Convert.ToDateTime(dr["TromesecniTehnicki"].ToString());

                if (dr["NarednaREgistracija"].ToString() == "")
                    dtpNarednaRegistracija.Value = dtpNarednaRegistracija.MinDate;
                else
                dtpNarednaRegistracija.Value = Convert.ToDateTime(dr["NarednaREgistracija"].ToString()); 
                txtSopstvenaTezina.Value = Convert.ToDecimal(dr["SopstvenaTezina"].ToString());
                txtGodinaProizvodnje.Text = dr["GodinaProizvodnje"].ToString();
                txtRegistarskaOznaka.Text = dr["RegistarskaOznaka"].ToString();
                txtBrojOsovina.Value = Convert.ToInt32(dr["BrojOsovina"].ToString());
                txtVrsta.Text = dr["Vrsta"].ToString();
                txtNamena.Text = dr["Namena"].ToString();
                if (dr["LicencaVaziDo"].ToString() == "")
                    dtpLicencaVaziDo.Value = dtpLicencaVaziDo.MinDate;
                else
                dtpLicencaVaziDo.Value = Convert.ToDateTime(dr["LicencaVaziDo"].ToString());
                txtNaziv.Text = dr["Naziv"].ToString();
                txtIndividualniBroj.Text = dr["IndividualniBroj"].ToString();
                txtLicencaBroj.Text = dr["LicencaBroj"].ToString();
                
            }

            con.Close();
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Vozila", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
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
                        VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void frmVozila_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmDokumentaVozila frmd3 = new frmDokumentaVozila(txtSifra.Text, KorisnikCene);
            frmd3.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtIndividualniBroj_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtSopstvenaTezina_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpNarednaRegistracija_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTromesecniTehnicki_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpAtest_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpServis_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpPPAparat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTahograf_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpGodisniTehnicki_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpSestomesecniTehnicki_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNosivost_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string configvalue1 = ConfigurationManager.AppSettings["ip"];
                string configvalue2 = ConfigurationManager.AppSettings["server"];
                string putanja = "\\\\" + configvalue1 + "\\Dok\\1\\fakturdomaci.rpt";
              
                putanja = putanja.Replace(configvalue1, configvalue2);
                System.Diagnostics.Process.Start(putanja);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void tsPrvi_Click(object sender, EventArgs e)
        {

        }
    }
}



        
