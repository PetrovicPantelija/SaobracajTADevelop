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
    public partial class frmTeretnica : Form
    {
        Boolean status = false;
        int pomPrijemna = 0;
        int pomPredajna = 0;
        int pomPrevozna = 0;
        string Korisnik = "";
        public frmTeretnica()
        {
            InitializeComponent();
        }

        public frmTeretnica(string IdTeretnice, string KorisnikTeretnica)
        {
            InitializeComponent();
            Korisnik = KorisnikTeretnica;
            txtSifra.Text = IdTeretnice;
            VratiPodatke(IdTeretnice);
            RefreshDataGrid();
        }

        private void VratiPodatke(string IdTeretnice)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select [ID],[BrojTeretnice] ,[StanicaOd],[StanicaDo],[StanicaPopisa],[VremeOd],[VremeDo],[BrojLista], [Prijemna], [Predajna], [Prevozna], [RN] from Teretnica where ID=" + IdTeretnice, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtVozBroj.Text = dr["BrojTeretnice"].ToString();
                cboStanicaOd.SelectedValue = Convert.ToInt32(dr["StanicaOd"].ToString()); 
                cboStanicaDo.SelectedValue = Convert.ToInt32(dr["StanicaDo"].ToString());
                cboStanicaPopisa.SelectedValue = Convert.ToInt32(dr["StanicaPopisa"].ToString());
                dtpVremeOd.Value = Convert.ToDateTime(dr["VremeOd"].ToString());
                dtpVremeDo.Value = Convert.ToDateTime(dr["VremeDo"].ToString());
                txtBrojLista.Text = dr["BrojLista"].ToString();
                txtRN.Text = dr["RN"].ToString();
                if (dr["Prijemna"].ToString() == "1")
                {
                    chkPrijemna.Checked = true;
                }
                else
                {
                  chkPrijemna.Checked = false;     
                }


                if (dr["Predajna"].ToString() == "1")
                {
                    chkPredajna.Checked = true;
                }
                else
                {
                    chkPredajna.Checked = false;
                }

                if (dr["Prevozna"].ToString() == "1")
                {
                    chkPrevozna.Checked = true;
                }
                else
                {
                    chkPrevozna.Checked = false;
                }
            }

            con.Close();
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from Teretnica", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void VratiPodatkeStavke(string IdTeretnice, int RB)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] ,[RB] ,[BrojTeretnice] ,[IDNajave] ,[Uvrstena] "
            + " ,[Otkacena] ,[BrojKola] ,[Serija] ,[BrojOsovina] ,[Duzina] ,[Tara] ,[Neto] ,[G] "
            + " ,[P] ,[R] ,[RR] ,[VRNP] ,[Otpravna] ,[Uputna] ,[Reon] ,[Primedba],[RucKoc], [Uvozna], [Izvozna], RID, Dokument "
            + " FROM [TESTIRANJE].[dbo].[TeretnicaStavke]  where BrojTeretnice=" + IdTeretnice +  " and RB = "  + RB, con);
           
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtRB.Text = dr["RB"].ToString();
                txtBrojNajave.Text = dr["IDNajave"].ToString();
                cboUvrstena.SelectedValue = Convert.ToInt32(dr["Uvrstena"].ToString());
                cboOtkacena.SelectedValue = Convert.ToInt32(dr["Otkacena"].ToString());
                txtBrojKola.Text = dr["BrojKola"].ToString();
                txtSerija.Text = dr["Serija"].ToString();
                txtBrojOsovina.Text = dr["BrojOsovina"].ToString();
                txtDuzina.Value = Convert.ToDecimal(dr["Duzina"].ToString()); 
                txtTara.Value = Convert.ToDecimal(dr["Tara"].ToString());
                txtNeto.Value = Convert.ToDecimal(dr["Neto"].ToString());
                txtG.Value = Convert.ToDecimal(dr["G"].ToString());
                txtP.Value = Convert.ToDecimal(dr["P"].ToString());
                txtR.Value = Convert.ToDecimal(dr["R"].ToString());
                txtRR.Value = Convert.ToDecimal(dr["RR"].ToString());
                txtVRNP.Text = dr["VRNP"].ToString();
                cboOtpravna.SelectedValue = Convert.ToInt32(dr["Otpravna"].ToString());
                cboUputna.SelectedValue = Convert.ToInt32(dr["Uputna"].ToString());
                txtReon.Text = dr["Reon"].ToString();
                txtPrimedba.Text = dr["Primedba"].ToString();
                txtRucKoc.Value = Convert.ToDecimal(dr["RucKoc"].ToString());
                cboUvozna.SelectedValue = Convert.ToInt32(dr["Uvozna"].ToString());
                cboIzvozna.SelectedValue = Convert.ToInt32(dr["Izvozna"].ToString());
                txtRID.Text = dr["RID"].ToString();
                txtDokument.Text = dr["Dokument"].ToString();
            }

            con.Close();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            dtpVremeOd.Value = DateTime.Now;
            dtpVremeDo.Value = DateTime.Now;
            //Napisati kod      
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            //Panta
            if (status == true)
            {
                if (chkPrijemna.Checked)
                {
                    pomPrijemna = 1;
                }
                else
                {
                    pomPrijemna = 0;
                }
               
                InsertTeretnica ins = new InsertTeretnica();
                ins.InsTeretnica(txtVozBroj.Text, Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToInt32(cboStanicaPopisa.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, txtBrojLista.Text, pomPrijemna, pomPredajna, Korisnik, pomPrevozna, Convert.ToInt32(txtRN.Text));
                VratiPodatkeMax();
                //RefreshDataGrid();
                status = false;
            }
            else
            {
                if (chkPrijemna.Checked)
                {
                    pomPrijemna = 1;
                }
                else
                {
                    pomPrijemna = 0;
                }
                InsertTeretnica upd = new InsertTeretnica();
                upd.UpdTeretnica(Convert.ToInt32(txtSifra.Text), txtVozBroj.Text, Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToInt32(cboStanicaPopisa.SelectedValue), dtpVremeOd.Value, dtpVremeDo.Value, txtBrojLista.Text, pomPrijemna, pomPredajna, Korisnik, pomPrevozna, Convert.ToInt32(txtRN.Text));
            }
        }

        private void frmTeretnica_Load(object sender, EventArgs e)
        {
            var select6 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);
            var dataAdapter7 = new SqlDataAdapter(select6, c6);
            var dataAdapter8 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            var ds7 = new DataSet();
            var ds8= new DataSet();
            var ds9 = new DataSet();
            var ds10 = new DataSet();
            var ds11 = new DataSet();
            var ds12 = new DataSet();
            var ds13 = new DataSet();
            var ds14 = new DataSet();

            dataAdapter6.Fill(ds6);
            dataAdapter6.Fill(ds7);
            dataAdapter6.Fill(ds8);
            dataAdapter6.Fill(ds9);
            dataAdapter6.Fill(ds10);
            dataAdapter6.Fill(ds11);
            dataAdapter6.Fill(ds12);
            dataAdapter6.Fill(ds13);
            dataAdapter6.Fill(ds14);
        
            cboStanicaOd.DataSource = ds6.Tables[0];
            cboStanicaOd.DisplayMember = "Stanica";
            cboStanicaOd.ValueMember = "ID";

            cboStanicaDo.DataSource = ds7.Tables[0];
            cboStanicaDo.DisplayMember = "Stanica";
            cboStanicaDo.ValueMember = "ID";

            cboStanicaPopisa.DataSource = ds8.Tables[0];
            cboStanicaPopisa.DisplayMember = "Stanica";
            cboStanicaPopisa.ValueMember = "ID";

            cboUvrstena.DataSource = ds9.Tables[0];
            cboUvrstena.DisplayMember = "Stanica";
            cboUvrstena.ValueMember = "ID";

            cboOtkacena.DataSource = ds10.Tables[0];
            cboOtkacena.DisplayMember = "Stanica";
            cboOtkacena.ValueMember = "ID";

            cboOtpravna.DataSource = ds11.Tables[0];
            cboOtpravna.DisplayMember = "Stanica";
            cboOtpravna.ValueMember = "ID";

            cboUputna.DataSource = ds12.Tables[0];
            cboUputna.DisplayMember = "Stanica";
            cboUputna.ValueMember = "ID";

            cboUvozna.DataSource = ds13.Tables[0];
            cboUvozna.DisplayMember = "Stanica";
            cboUvozna.ValueMember = "ID";

            cboIzvozna.DataSource = ds14.Tables[0];
            cboIzvozna.DisplayMember = "Stanica";
            cboIzvozna.ValueMember = "ID";
            
            VratiPodatke(txtSifra.Text);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBrojNajave.Text == "")
            {
                MessageBox.Show("Niste uneli broj najave");
            }
            else
            {
                int Postoji = ProveriDaLiPOstoji(Convert.ToInt32(txtSifra.Text), txtBrojKola.Text);
                if (Postoji == 1)
                {
                    MessageBox.Show("Isti broj kola je već unet - dupliranje!!!");

                }
                else
                {
                    InsertTeretnicaStavke ins = new InsertTeretnicaStavke();
                    ins.InsTeretnicaStavke(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtBrojNajave.Text), Convert.ToInt32(cboUvrstena.SelectedValue), Convert.ToInt32(cboOtkacena.SelectedValue), txtBrojKola.Text, txtSerija.Text, Convert.ToDouble(txtBrojOsovina.Text), Convert.ToDouble(txtDuzina.Value), Convert.ToDouble(txtTara.Value), Convert.ToDouble(txtNeto.Value), Convert.ToDouble(txtG.Value), Convert.ToDouble(txtP.Value), Convert.ToDouble(txtR.Value), Convert.ToDouble(txtRR.Value), txtVRNP.Text, Convert.ToInt32(cboOtpravna.SelectedValue), Convert.ToInt32(cboUputna.SelectedValue), txtReon.Text, txtPrimedba.Text, Convert.ToDouble(txtRucKoc.Value), Convert.ToInt32(cboUvozna.SelectedValue), Convert.ToInt32(cboIzvozna.SelectedValue), txtRID.Text, txtDokument.Text);
                    RefreshDataGrid();
                }
             
            }
            
        }

        static int ProveriDaLiPOstoji(int Teretnica, string BrojKola)
        {
            int CountKola = 0; 
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Count(*) as Ima from TeretnicaStavke where BrojTeretnice=" + Teretnica + " and BrojKola = '" + BrojKola + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

               CountKola =  Convert.ToInt32(dr["Ima"].ToString());
               
            }
            con.Close();

            return CountKola;
        }

        private void RefreshDataGrid()
        {
            var select = " SELECT     TeretnicaStavke.ID, TeretnicaStavke.RB, TeretnicaStavke.IDNajave, stanice.Opis as Uvrstena, stanice_1.Opis AS Otkacena, TeretnicaStavke.BrojKola, TeretnicaStavke.Serija, "
                          + " TeretnicaStavke.BrojOsovina, TeretnicaStavke.Duzina, TeretnicaStavke.Tara, TeretnicaStavke.Neto, TeretnicaStavke.G, TeretnicaStavke.P, TeretnicaStavke.R, "
                          + " TeretnicaStavke.RR, TeretnicaStavke.VRNP, stanice_3.Opis AS Otpravna, stanice_2.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, "
                          + " TeretnicaStavke.RucKoc,  stanice_5.Opis as Izvozna, stanice_4.Opis as Uvozna, RID, Dokument "
                          + " FROM         TeretnicaStavke INNER JOIN "
                          + " stanice ON TeretnicaStavke.Uvrstena = stanice.ID INNER JOIN "
                          + " stanice AS stanice_1 ON TeretnicaStavke.Otkacena = stanice_1.ID INNER JOIN "
                          + " stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN "
                          + " stanice AS stanice_2 ON TeretnicaStavke.Uputna = stanice_2.ID INNER JOIN "
                           + " stanice AS stanice_4 ON TeretnicaStavke.Uvozna = stanice_4.ID INNER JOIN "
                           + " stanice AS stanice_5 ON TeretnicaStavke.Izvozna = stanice_5.ID"
                          + " where BrojTEretnice = " + txtSifra.Text + " order by RB";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = false;
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
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "IDNajave";
            dataGridView1.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Uvrštena";
            dataGridView1.Columns[3].Width = 90;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Otkačena";
            dataGridView1.Columns[4].Width = 90;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Broj Kola";
            dataGridView1.Columns[5].Width = 90;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Serija";
            dataGridView1.Columns[6].Width = 20;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Br. osovina";
            dataGridView1.Columns[7].Width = 30;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Dužina";
            dataGridView1.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Tara";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Neto";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "G";
            dataGridView1.Columns[11].Width = 30;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "P";
            dataGridView1.Columns[12].Width = 40;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "R";
            dataGridView1.Columns[13].Width = 30;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "RR";
            dataGridView1.Columns[14].Width = 30;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "VRNP";
            dataGridView1.Columns[15].Width = 30;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Otpravna";
            dataGridView1.Columns[16].Width = 90;

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Uputna";
            dataGridView1.Columns[17].Width = 90;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Reon";
            dataGridView1.Columns[18].Width = 70;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Primedba";
            dataGridView1.Columns[19].Width = 70;

            DataGridViewColumn column21 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Ruč. koč";
            dataGridView1.Columns[20].Width = 70;

            DataGridViewColumn column22 = dataGridView1.Columns[21];
            dataGridView1.Columns[21].HeaderText = "Izvozna";
            dataGridView1.Columns[21].Width = 70;

            DataGridViewColumn column23 = dataGridView1.Columns[22];
            dataGridView1.Columns[22].HeaderText = "Uvozna";
            dataGridView1.Columns[22].Width = 70;

            DataGridViewColumn column24 = dataGridView1.Columns[23];
            dataGridView1.Columns[23].HeaderText = "RID";
            dataGridView1.Columns[23].Width = 70;

            DataGridViewColumn column25 = dataGridView1.Columns[24];
            dataGridView1.Columns[24].HeaderText = "Dokument";
            dataGridView1.Columns[24].Width = 70;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        VratiPodatkeStavke(txtSifra.Text, Convert.ToInt32(row.Cells[1].Value.ToString()));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertTeretnicaStavke ins = new InsertTeretnicaStavke();
            ins.UpdTeretnicaStavke(Convert.ToInt32(txtRB.Text), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtBrojNajave.Text), Convert.ToInt32(cboUvrstena.SelectedValue), Convert.ToInt32(cboOtkacena.SelectedValue), txtBrojKola.Text, txtSerija.Text, Convert.ToDouble(txtBrojOsovina.Text), Convert.ToDouble(txtDuzina.Value), Convert.ToDouble(txtTara.Value), Convert.ToDouble(txtNeto.Value), Convert.ToDouble(txtG.Value), Convert.ToDouble(txtP.Value), Convert.ToDouble(txtR.Value), Convert.ToDouble(txtRR.Value), txtVRNP.Text, Convert.ToInt32(cboOtpravna.SelectedValue), Convert.ToInt32(cboUputna.SelectedValue), txtReon.Text, txtPrimedba.Text, Convert.ToDouble(txtRucKoc.Value),  Convert.ToInt32(cboUvozna.SelectedValue), Convert.ToInt32(cboIzvozna.SelectedValue), txtRID.Text, txtDokument.Text);
            RefreshDataGrid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertTeretnica del = new InsertTeretnica();
            del.DeleteTeretnica(Convert.ToInt32(txtSifra.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertTeretnicaStavke dels = new InsertTeretnicaStavke();
            dels.DeleteTeretnicaStavke(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(txtRB.Text));
            RefreshDataGrid();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter ta = new TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter();
            TESTIRANJEDataSet.SelectTeretnicaDataTable dt = new TESTIRANJEDataSet.SelectTeretnicaDataTable();
           
            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet2";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "Teretnica.rdlc";
            reportViewer1.LocalReport.SetParameters(par);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();

            InsertTeretnica upd = new InsertTeretnica();
            //Ukoliko je Najava i CIM onda Update
            //upd.UpdNajavaCIM(Convert.ToInt32(txtSifra.Text),  Korisnik);
            /*
             Aziriraj Najavu
             
             */
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter ta = new TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter();
            TESTIRANJEDataSet.SelectTeretnicaDataTable dt = new TESTIRANJEDataSet.SelectTeretnicaDataTable();

            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet2";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.ReportPath = "K200.rdlc";
            reportViewer2.LocalReport.SetParameters(par);
            reportViewer2.LocalReport.DataSources.Add(rds);
            reportViewer2.RefreshReport();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter ta = new TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter();
            TESTIRANJEDataSet.SelectTeretnicaDataTable dt = new TESTIRANJEDataSet.SelectTeretnicaDataTable();

            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet2";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);
            reportViewer3.LocalReport.DataSources.Clear();
            reportViewer3.LocalReport.ReportPath = "Kol65.rdlc";
            reportViewer3.LocalReport.SetParameters(par);
            reportViewer3.LocalReport.DataSources.Add(rds);
            reportViewer3.RefreshReport();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmTeretnicaKopiranjeStavki frmKopiranjeStavki = new frmTeretnicaKopiranjeStavki();
            frmKopiranjeStavki.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter  ta = new TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter();
            TESTIRANJEDataSet.SelectTeretnicaDataTable dt = new TESTIRANJEDataSet.SelectTeretnicaDataTable();

            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet2";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);
            reportViewer4.LocalReport.DataSources.Clear();
            reportViewer4.LocalReport.ReportPath = "K200Bosna.rdlc";
            reportViewer4.LocalReport.SetParameters(par);
            reportViewer4.LocalReport.DataSources.Add(rds);
            reportViewer4.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    InsertTeretnicaStavke  insTer = new InsertTeretnicaStavke();
                    insTer.UpdateRB(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()));
                }
                RefreshDataGrid();
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter ta = new TESTIRANJEDataSetTableAdapters.SelectTeretnicaTableAdapter();
            // NedraDataSetTableAdapters.SelectNajavaTableAdapter ta = new NedraDataSetTableAdapters.SelectNajavaTableAdapter();
            TESTIRANJEDataSet.SelectTeretnicaDataTable dt = new TESTIRANJEDataSet.SelectTeretnicaDataTable();

            ta.Fill(dt, Convert.ToInt32(txtSifra.Text));
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet3";
            rds.Value = dt;

            ReportParameter[] par = new ReportParameter[1];
            par[0] = new ReportParameter("ID", txtSifra.Text);
            reportViewer5.LocalReport.DataSources.Clear();
            reportViewer5.LocalReport.ReportPath = "K65Bosna.rdlc";
            reportViewer5.LocalReport.SetParameters(par);
            reportViewer5.LocalReport.DataSources.Add(rds);
            reportViewer5.RefreshReport();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                        InsertIskljuceniVagoni its = new InsertIskljuceniVagoni();
                        its.InsertIskljuceniVagPrijem(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboStanicaPopisa.SelectedValue), 1);
                }
                MessageBox.Show("Vagoni su raspušteni nalaze se u stanici popisa");
            }
            catch
            {
                MessageBox.Show("Nije uspeo prijem vagona");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int totalRows = dataGridView1.Rows.Count;
            int trenutniindex = dataGridView1.CurrentCell.RowIndex;
            if (trenutniindex + 1 == totalRows)
            {
                return;
            }
           
            InsertTeretnicaStavke ins = new InsertTeretnicaStavke();
            ins.UpdateTeretnicaRBUpDown(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()), Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), 1);
            //dataGridView1.CurrentCell.RowIndex = trenutniindex + 1;
            RefreshDataGrid();
            this.dataGridView1.CurrentCell = this.dataGridView1[5, trenutniindex + 1];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int trenutniindex = dataGridView1.CurrentCell.RowIndex;
            if (trenutniindex == 0)
            {
                return;
            }
            
            InsertTeretnicaStavke ins = new InsertTeretnicaStavke();
            ins.UpdateTeretnicaRBUpDown(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()), Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), 0);
            RefreshDataGrid();
            
            this.dataGridView1.CurrentCell = this.dataGridView1[5, trenutniindex - 1];
        }

        private void button9_Click(object sender, EventArgs e)
        {
           //promena sve
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
             
                    InsertTeretnicaStavke insTer = new InsertTeretnicaStavke();
                    insTer.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()),row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(),  Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()),Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
                }
                RefreshDataGrid();
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void txtBrojKola_Leave(object sender, EventArgs e)
        {
            string sub1 = txtBrojKola.Text.Substring(0, 1);
            string sub2 = txtBrojKola.Text.Substring(1, 1);
            string sub3 = txtBrojKola.Text.Substring(2, 1);
            string sub4 = txtBrojKola.Text.Substring(3, 1);
            string sub5 = txtBrojKola.Text.Substring(4, 1);
            string sub6 = txtBrojKola.Text.Substring(5, 1);
            string sub7 = txtBrojKola.Text.Substring(6, 1);
            string sub8 = txtBrojKola.Text.Substring(7, 1);
            string sub9 = txtBrojKola.Text.Substring(8, 1);
            string sub10 = txtBrojKola.Text.Substring(9, 1);
            string sub11 = txtBrojKola.Text.Substring(10, 1);
            string sub12 = txtBrojKola.Text.Substring(11, 1);
            string sub13 = txtBrojKola.Text.Substring(12, 1);

            int s1 = Convert.ToInt32(sub1) * 2;
            if (s1 > 9)
            { 
            s1 = Convert.ToInt32(s1.ToString().Substring(0, 1))  + Convert.ToInt32(s1.ToString().Substring(1, 1));
            }
            int s2 = Convert.ToInt32(sub2);
            int s3 = Convert.ToInt32(sub3) * 2;
            if (s3 > 9)
            {
                s3 = Convert.ToInt32(s3.ToString().Substring(0, 1)) + Convert.ToInt32(s3.ToString().Substring(1, 1));
            }
            int s4 = Convert.ToInt32(sub4);
            int s5 = Convert.ToInt32(sub5) * 2;
            if (s5 > 9)
            {
                s5 = Convert.ToInt32(s5.ToString().Substring(0, 1)) + Convert.ToInt32(s5.ToString().Substring(1, 1));
            }
            int s6 = Convert.ToInt32(sub6);
            int s7 = Convert.ToInt32(sub7) * 2;
            if (s7 > 9)
            {
                s7 = Convert.ToInt32(s7.ToString().Substring(0, 1)) + Convert.ToInt32(s7.ToString().Substring(1, 1));
            }
            int s8 = Convert.ToInt32(sub8);
            int s9 = Convert.ToInt32(sub9) * 2;
            if (s9 > 9)
            {
                s9 = Convert.ToInt32(s9.ToString().Substring(0, 1)) + Convert.ToInt32(s9.ToString().Substring(1, 1));
            }
            int s10 = Convert.ToInt32(sub10);
            int s11 = Convert.ToInt32(sub11) * 2;
            if (s11 > 9)
            {
                s11 = Convert.ToInt32(s11.ToString().Substring(0, 1)) + Convert.ToInt32(s11.ToString().Substring(1, 1));
            }
            int zbir = s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10 + s11;
            int Odrednica = 50;
            if (zbir > 50)
            { Odrednica = 60; }
            if (zbir > 60)
            { Odrednica = 70; }
            int pomzbir = Math.Abs((Odrednica - zbir));
            if (pomzbir != Convert.ToInt32(sub13))
            {
                MessageBox.Show("Nije u redu broj kola");
            }

            int Postoji = ProveriPostoji();
            if (Postoji > 0)
            {
                VratiPodatkeKola();
            }
        }
        int ProveriPostoji()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select count(*) as Broj  from TeretnicaStavke where BrojKola = '" + txtBrojKola.Text + " ' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            //select Top 1 Serija, BrojOsovina, Duzina, Tara, P, RucKoc  from TeretnicaStavke where BrojKola = '31655960061-4' order by ID desc
            while (dr.Read())
            {
                return Convert.ToInt32(dr["Broj"].ToString());
            }
            return 0;
            con.Close();
        }

        private void  VratiPodatkeKola()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Top 1 Serija, BrojOsovina, Duzina, Tara, P, RucKoc  from TeretnicaStavke where BrojKola =  '" + txtBrojKola.Text + " ' order by ID desc ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            //select Top 1 Serija, BrojOsovina, Duzina, Tara, P, RucKoc  from TeretnicaStavke where BrojKola = '31655960061-4' order by ID desc
            while (dr.Read())
            {
                txtSerija.Text =  dr["Serija"].ToString();
                txtBrojOsovina.Value = Convert.ToDecimal(dr["BrojOsovina"].ToString());
                txtDuzina.Value = Convert.ToDecimal(dr["Duzina"].ToString());
                txtTara.Value = Convert.ToDecimal(dr["Tara"].ToString());
                txtP.Value = Convert.ToDecimal(dr["P"].ToString());
                txtRucKoc.Value = Convert.ToDecimal(dr["RucKoc"].ToString());
            }
           
            con.Close();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmTeretnicaTerenIzmena teren = new frmTeretnicaTerenIzmena(txtSifra.Text);
            teren.Show();
        }
    }
}
