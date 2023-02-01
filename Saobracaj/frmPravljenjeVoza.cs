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

namespace Saobracaj
{
    public partial class frmPravljenjeVoza : Form
    {
        int tmpStanicaPopisa = 0;
        public frmPravljenjeVoza()
        {
            InitializeComponent();
           // int RadniNalog = 0;

            var select8 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboStanicaOd.DataSource = ds8.Tables[0];
            cboStanicaOd.DisplayMember = "Stanica";
            cboStanicaOd.ValueMember = "ID";

            var select9 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection8);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);

            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            cboStanicaDo.DataSource = ds9.Tables[0];
            cboStanicaDo.DisplayMember = "Stanica";
            cboStanicaDo.ValueMember = "ID";


       
        }

        public frmPravljenjeVoza(int RN)
        {
            InitializeComponent();
            cboRadniNalog.SelectedValue = RN;

            var select8 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboStanicaOd.DataSource = ds8.Tables[0];
            cboStanicaOd.DisplayMember = "Stanica";
            cboStanicaOd.ValueMember = "ID";

            var select9 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection8);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);

            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            cboStanicaDo.DataSource = ds9.Tables[0];
            cboStanicaDo.DisplayMember = "Stanica";
            cboStanicaDo.ValueMember = "ID";


          
        }

        public frmPravljenjeVoza(int RN, int StanicaPopisa, int StanicaOd, int StanicaDo, DateTime vreme)
        {
            InitializeComponent();
            cboRadniNalog.SelectedValue = RN;
            

            var select8 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboStanicaOd.DataSource = ds8.Tables[0];
            cboStanicaOd.DisplayMember = "Stanica";
            cboStanicaOd.ValueMember = "ID";

            var select9 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection8);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);

            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            cboStanicaDo.DataSource = ds9.Tables[0];
            cboStanicaDo.DisplayMember = "Stanica";
            cboStanicaDo.ValueMember = "ID";


            cboStanicaOd.SelectedValue = StanicaOd;
            cboStanicaDo.SelectedValue = StanicaDo;
            tmpStanicaPopisa = StanicaPopisa;
            dtpVremeOd.Value = vreme;

        }
        private void refreshGroup()
        {
            var select = " Select Max(ID) as ID ,Opis, COUNT(ID) as BrojVagona, SUM(neto) as Neto, SUM(Tara) as Tara, sum(Duzina) as Duzina from ( " +
            " Select TIV.ID, TIV.StanicaIskljucenja, s1.Opis, ts.Duzina, ts.Tara, ts.Neto " + 
            " from TeretnicaIskljuceniVagoni TIV " +
            " inner join stanice s1 on TIV.StanicaIskljucenja = s1.ID " +
            " inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id) f1 " +
            " group by Opis";

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
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Stanica";
            dataGridView1.Columns[1].Width = 140;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Broj vagona";
            dataGridView1.Columns[2].Width = 60;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Ukupno neto";
            dataGridView1.Columns[3].Width = 80;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Ukupno Tara";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Ukupno Duzina";
            dataGridView1.Columns[5].Width = 80;

        
        }

        private void frmPravljenjeVoza_Load(object sender, EventArgs e)
        {
            var select6 = " Select distinct STID as ID ,Opis from ( " +
" Select TIV.ID as TIVID, TIV.StanicaIskljucenja, s1.ID as STID,  s1.Opis " +
" from TeretnicaIskljuceniVagoni TIV " +
" inner join stanice s1 on TIV.StanicaIskljucenja = s1.ID " +
" inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id " +
" where TIV.StatusVagona in (1,3)) f1 " +
" order by Opis";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboStanicaIsklj.DataSource = ds6.Tables[0];
            cboStanicaIsklj.DisplayMember = "Opis";
            cboStanicaIsklj.ValueMember = "ID";

           


            refreshGroup();

            var select7 = " Select ID  from RadniNalog where StatusRN in ('PL','OD', 'LA') ";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboRadniNalog.DataSource = ds7.Tables[0];
            cboRadniNalog.DisplayMember = "ID";
            cboRadniNalog.ValueMember = "ID";

            if (tmpStanicaPopisa != 0)
            {
                cboStanicaIsklj.SelectedValue = tmpStanicaPopisa;
                PovuciVagone(tmpStanicaPopisa);
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Select TIV.ID, TIV.StanicaIskljucenja, s1.Opis, 
,ts.BrojTeretnice, TS.IDNajave, ts.BrojKola, ts.Serija, ts.BrojOsovina, ts.Duzina, ts.Tara, ts.Neto, ts.G, ts.P, ts.R, ts, RR, ts.Reon, ts.VRNP, ts.RID, ts.Primedba, ts.RucKoc
from TeretnicaIskljuceniVagoni TIV 
inner join stanice s1 on TIV.StanicaIskljucenja = s1.ID 
inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id*/
            var select = " Select ts.ID, TIV.ID, TIV.StanicaIskljucenja, s1.Opis, " +
            " ts.BrojTeretnice, TS.IDNajave, stanice_3.Opis as Otpravna, stanice_2.Opis as Uputna, ts.BrojKola, ts.Serija, ts.BrojOsovina, ts.Duzina, " +
            " ts.Tara, ts.Neto, ts.G, ts.P, ts.R, ts.RR, ts.Reon, ts.VRNP, ts.RID, ts.Primedba, ts.RucKoc " +
            " from TeretnicaIskljuceniVagoni TIV " +
            " inner join stanice s1 on TIV.StanicaIskljucenja = s1.ID " +
            " inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id " +
             " inner join stanice AS stanice_3 ON ts.Otpravna = stanice_3.ID INNER JOIN " +
            " stanice AS stanice_2 ON ts.Uputna = stanice_2.ID " +
            " where TIV.StanicaIskljucenja = " + Convert.ToInt32(cboStanicaIsklj.SelectedValue) + " and TIV.StatusVagona in (1,3)";

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
            dataGridView3.Columns[0].HeaderText = "ID ter st";
            dataGridView3.Columns[0].Width = 40;

            DataGridViewColumn column1 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "ID iskl";
            dataGridView3.Columns[1].Width = 40;

            DataGridViewColumn column2 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Stan ID";
            dataGridView3.Columns[2].Width = 40;

            DataGridViewColumn column3 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Stanica isključenja";
            dataGridView3.Columns[3].Width = 120;

            DataGridViewColumn column4 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Prijemna teretnica";
            dataGridView3.Columns[4].Width = 40;

            DataGridViewColumn column5 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Najava";
            dataGridView3.Columns[5].Width = 40;

            DataGridViewColumn column6 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Otpravna";
            dataGridView3.Columns[6].Width = 120;

            DataGridViewColumn column7 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Uputna";
            dataGridView3.Columns[7].Width = 120;

            DataGridViewColumn column8 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Broj kola";
            dataGridView3.Columns[8].Width = 100;

            DataGridViewColumn column9 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "Serija";
            dataGridView3.Columns[9].Width = 40;

            DataGridViewColumn column10 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Broj osovina";
            dataGridView3.Columns[10].Width = 40;

            DataGridViewColumn column11 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Dužina";
            dataGridView3.Columns[11].Width = 60;

            DataGridViewColumn column12 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Tara";
            dataGridView3.Columns[12].Width = 60;

            DataGridViewColumn column13 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "Neto";
            dataGridView3.Columns[13].Width = 60;

            DataGridViewColumn column14 = dataGridView3.Columns[14];
            dataGridView3.Columns[14].HeaderText = "G";
            dataGridView3.Columns[14].Width = 30;

            DataGridViewColumn column15 = dataGridView3.Columns[15];
            dataGridView3.Columns[15].HeaderText = "P";
            dataGridView3.Columns[15].Width = 30;

            DataGridViewColumn column16 = dataGridView3.Columns[16];
            dataGridView3.Columns[16].HeaderText = "R";
            dataGridView3.Columns[16].Width = 30;

            DataGridViewColumn column17 = dataGridView3.Columns[17];
            dataGridView3.Columns[17].HeaderText = "RR";
            dataGridView3.Columns[17].Width = 30;

            DataGridViewColumn column18 = dataGridView3.Columns[18];
            dataGridView3.Columns[18].HeaderText = "Reon";
            dataGridView3.Columns[18].Width = 60;

            DataGridViewColumn column19 = dataGridView3.Columns[19];
            dataGridView3.Columns[19].HeaderText = "VRNR";
            dataGridView3.Columns[19].Width = 60;

            DataGridViewColumn column20 = dataGridView3.Columns[20];
            dataGridView3.Columns[20].HeaderText = "RID";
            dataGridView3.Columns[20].Width = 60;

            DataGridViewColumn column21 = dataGridView3.Columns[21];
            dataGridView3.Columns[21].HeaderText = "Primedba";
            dataGridView3.Columns[21].Width = 60;

            DataGridViewColumn column22 = dataGridView3.Columns[22];
            dataGridView3.Columns[22].HeaderText = "Ruč koč";
            dataGridView3.Columns[22].Width = 60;

        }

        private void PovuciVagone(int StanicaIskljucenja)
        {
            var select = " Select TIV.ID, TIV.StanicaIskljucenja, s1.Opis, " +
               " ts.BrojTeretnice, TS.IDNajave, stanice_3.Opis as Otpravna, stanice_2.Opis as Uputna, ts.BrojKola, ts.Serija, ts.BrojOsovina, ts.Duzina, " +
               " ts.Tara, ts.Neto, ts.G, ts.P, ts.R, ts.RR, ts.Reon, ts.VRNP, ts.RID, ts.Primedba, ts.RucKoc " +
               " from TeretnicaIskljuceniVagoni TIV " +
               " inner join stanice s1 on TIV.StanicaIskljucenja = s1.ID " +
               " inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id " +
                " inner join stanice AS stanice_3 ON ts.Otpravna = stanice_3.ID INNER JOIN " +
               " stanice AS stanice_2 ON ts.Uputna = stanice_2.ID " +
               " where TIV.StanicaIskljucenja = " + StanicaIskljucenja + " and TIV.StatusVagona in (1,3)";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];
            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Stan ID";
            dataGridView3.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Stanica isključenja";
            dataGridView3.Columns[2].Width = 120;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Prijemna teretnica";
            dataGridView3.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Najava";
            dataGridView3.Columns[4].Width = 40;

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Otpravna";
            dataGridView3.Columns[5].Width = 120;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Uputna";
            dataGridView3.Columns[6].Width = 120;

            DataGridViewColumn column8 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Broj kola";
            dataGridView3.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Serija";
            dataGridView3.Columns[8].Width = 40;

            DataGridViewColumn column10 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "Broj osovina";
            dataGridView3.Columns[9].Width = 40;

            DataGridViewColumn column11 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Dužina";
            dataGridView3.Columns[10].Width = 60;

            DataGridViewColumn column12 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Tara";
            dataGridView3.Columns[11].Width = 60;

            DataGridViewColumn column13 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Neto";
            dataGridView3.Columns[12].Width = 60;

            DataGridViewColumn column14 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "G";
            dataGridView3.Columns[13].Width = 30;

            DataGridViewColumn column15 = dataGridView3.Columns[14];
            dataGridView3.Columns[14].HeaderText = "P";
            dataGridView3.Columns[14].Width = 30;

            DataGridViewColumn column16 = dataGridView3.Columns[15];
            dataGridView3.Columns[15].HeaderText = "R";
            dataGridView3.Columns[15].Width = 30;

            DataGridViewColumn column17 = dataGridView3.Columns[16];
            dataGridView3.Columns[16].HeaderText = "RR";
            dataGridView3.Columns[16].Width = 30;

            DataGridViewColumn column18 = dataGridView3.Columns[17];
            dataGridView3.Columns[17].HeaderText = "Reon";
            dataGridView3.Columns[17].Width = 60;

            DataGridViewColumn column19 = dataGridView3.Columns[18];
            dataGridView3.Columns[18].HeaderText = "VRNR";
            dataGridView3.Columns[18].Width = 60;

            DataGridViewColumn column20 = dataGridView3.Columns[19];
            dataGridView3.Columns[19].HeaderText = "RID";
            dataGridView3.Columns[19].Width = 60;

            DataGridViewColumn column21 = dataGridView3.Columns[20];
            dataGridView3.Columns[20].HeaderText = "Primedba";
            dataGridView3.Columns[20].Width = 60;

            DataGridViewColumn column22 = dataGridView3.Columns[21];
            dataGridView3.Columns[21].HeaderText = "Ruč koč";
            dataGridView3.Columns[21].Width = 60;
        
        
        
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            int brojvagona = 0;
            double duzina = 0;
            double neto = 0;
            double tara = 0;
            double bruto = 0;
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        brojvagona = brojvagona + 1;
                        duzina = duzina + Convert.ToDouble(row.Cells[11].Value.ToString());
                        tara = tara + Convert.ToDouble(row.Cells[12].Value.ToString());
                        neto = neto + Convert.ToDouble(row.Cells[13].Value.ToString());
                        bruto = neto + tara;
                    }
                }
                txtBrojKola.Text = brojvagona.ToString();
                txtDuzina.Text = duzina.ToString();
                txtNeto.Text = neto.ToString();
                txtTara.Text = tara.ToString();
                txtBruto.Text = bruto.ToString();
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void RefreshDataGrid()
        { 
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Dokumenta.InsertTeretnica it = new Dokumenta.InsertTeretnica();
                it.InsTeretnica("", Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToInt32(cboStanicaIsklj.SelectedValue), Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeOd.Value), "", 0, 0, "sa", 1, Convert.ToInt32(cboRadniNalog.SelectedValue));

                Dokumenta.InsertRadniNalog irn = new Dokumenta.InsertRadniNalog();
                irn.InsRNTeretnica(Convert.ToInt32(cboRadniNalog.SelectedValue));
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        InsertTeretnicaStavke its = new InsertTeretnicaStavke();
                        its.InsTeretnicaStavkeRN(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue));

                        Dokumenta.InsertIskljuceniVagoni div = new Dokumenta.InsertIskljuceniVagoni();
                        div.UpdateIskljuceniVag(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboRadniNalog.SelectedValue));
                       
                    }
                }
                //dataGridView3
                PovuciVagone(Convert.ToInt32(cboStanicaIsklj.SelectedValue));
                MessageBox.Show("Napravljena je nova prevozna teretnica!!!!");
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }
    
    }
}
