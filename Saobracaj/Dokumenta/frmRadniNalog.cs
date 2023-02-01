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

namespace Saobracaj.Dokumenta
{
    public partial class frmRadniNalog : Form
    {
        int pomTrasa = 0;
        Boolean status = false;

        public frmRadniNalog()
        {
            InitializeComponent();
        }

        public frmRadniNalog(string IDRadnogNaloga)
        {
            InitializeComponent();
            txtSifra.Text = IDRadnogNaloga;
            VratiTeretnice(IDRadnogNaloga);
            RefreshDataGridNajave();

        }

        private void VratiPodatke(string IdRadnogNaloga)
         {
             if (IdRadnogNaloga == "")
             {
                 MessageBox.Show("Selektujte Radni nalog");
                 return;
             
             }
             var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
             SqlConnection con = new SqlConnection(s_connection);

             con.Open();

             SqlCommand cmd = new SqlCommand("select [ID],[BrojNajave] ,[Najava],[Komentar], Planer, StatusRN, TehnologijaID, PredhodniRadniNalog from RadniNalog where ID=" + IdRadnogNaloga, con);
             SqlDataReader dr = cmd.ExecuteReader();

             while (dr.Read())
             {
                // txtOpis.Text = dr["BrojNajave"].ToString();
                // cboNajava.SelectedValue = Convert.ToInt32(dr["Najava"].ToString());
                 txtKomentar.Text = dr["Komentar"].ToString();
                 cboPlaner.SelectedValue = Convert.ToInt32(dr["Planer"].ToString());
                 cboStatusRN.SelectedValue = dr["StatusRN"].ToString();
                // cboPorudzbinaID.SelectedValue = Convert.ToInt32(dr["TehnologijaID"].ToString());
                 cboPredhodniRadniNalog.SelectedValue = Convert.ToInt32(dr["PredhodniRadniNalog"].ToString());
                //Panta tehnologija
                RefreshDataGridNajave();
            }

             con.Close();
         }

        private void VratiTrase(string IDRadnogNaloga)
         {
             var select = "SELECT  RadniNalogTrase.IDRadnogNaloga, RadniNalogTrase.RB, RadniNalogTrase.IDTrase, Trase.Voz, " +
                 "RadniNalogTrase.DatumPolaska " +
                ",RadniNalogTrase.DatumDolaska " +
                ",RadniNalogTrase.Vreme " +
                 ",RadniNalogTrase.DatumPolaskaReal " +
                ",RadniNalogTrase.DatumDolaskaReal " +
                ",RadniNalogTrase.VremeReal " +
                ",RadniNalogTrase.PlaniranaMasa " +
                ",RadniNalogTrase.MasaLokomotive " +
                ",RadniNalogTrase.MasaVoza " +
                ",RadniNalogTrase.BrutoMasa " +
                ",RadniNalogTrase.Napomena " +
                ",stanice_2.Opis AS RN_Pocetna " +
                ",stanice_3.Opis AS RN_Krajnja " + 
                 ",stanice.Opis AS Trasa_Pocetna " +
                ",stanice_1.Opis AS Trasa_Krajnja " + 
                " FROM RadniNalogTrase INNER JOIN " +
                " Trase ON RadniNalogTrase.IDTrase = Trase.ID INNER JOIN " + 
                " stanice ON Trase.Pocetna = stanice.ID INNER JOIN " +
                " stanice AS stanice_1 ON Trase.Krajnja = stanice_1.ID " +
                " inner join stanice as stanice_2 ON RadniNalogTrase.StanicaOd = stanice_2.ID INNER JOIN  stanice AS stanice_3 ON RadniNalogTrase.StanicaDo = stanice_3.ID " +
                " where RadniNalogTrase.IDRadnogNaloga = " + Convert.ToInt32(txtSifra.Text) + " order by IDRadnogNaloga, RadniNalogTrase.RB";
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
             dataGridView1.Columns[0].HeaderText = "RN";
             dataGridView1.Columns[0].Width = 30;

             DataGridViewColumn column2 = dataGridView1.Columns[1];
             dataGridView1.Columns[1].HeaderText = "RB";
             dataGridView1.Columns[1].Width = 20;

             DataGridViewColumn column3 = dataGridView1.Columns[2];
             dataGridView1.Columns[2].HeaderText = "ID Trasa";
             dataGridView1.Columns[2].Width = 30;

             DataGridViewColumn column4 = dataGridView1.Columns[3];
             dataGridView1.Columns[3].HeaderText = "Trasa";
             dataGridView1.Columns[3].Width = 70;

             DataGridViewColumn column5 = dataGridView1.Columns[4];
             dataGridView1.Columns[4].HeaderText = "Plan polaska";
             dataGridView1.Columns[4].Width = 100;

             DataGridViewColumn column6 = dataGridView1.Columns[5];
             dataGridView1.Columns[5].HeaderText = "Plan dolaska";
             dataGridView1.Columns[5].Width = 100;

             DataGridViewColumn column7 = dataGridView1.Columns[6];
             dataGridView1.Columns[6].HeaderText = "Planirano vreme";
             dataGridView1.Columns[6].Width = 50;

             DataGridViewColumn column8 = dataGridView1.Columns[7];
             dataGridView1.Columns[7].HeaderText = "Realiz. polaska ";
             dataGridView1.Columns[7].Width = 100;

             DataGridViewColumn column9 = dataGridView1.Columns[8];
             dataGridView1.Columns[8].HeaderText = "Realiz. dolaska";
             dataGridView1.Columns[8].Width = 100;

             DataGridViewColumn column10 = dataGridView1.Columns[9];
             dataGridView1.Columns[9].HeaderText = "Realizovano vreme";
             dataGridView1.Columns[9].Width = 50;

             DataGridViewColumn column11 = dataGridView1.Columns[10];
             dataGridView1.Columns[10].HeaderText = "Planirana masa";
             dataGridView1.Columns[10].Width = 50;

             DataGridViewColumn column12 = dataGridView1.Columns[11];
             dataGridView1.Columns[11].HeaderText = "Masa lokomotive";
             dataGridView1.Columns[11].Width = 50;

             DataGridViewColumn column13 = dataGridView1.Columns[12];
             dataGridView1.Columns[12].HeaderText = "Masa voza";
             dataGridView1.Columns[12].Width = 50;

             DataGridViewColumn column14 = dataGridView1.Columns[13];
             dataGridView1.Columns[13].HeaderText = "Bruto masa";
             dataGridView1.Columns[13].Width = 50;

     

 

         }

        private void VratiLokomotive(int IDTrase, string IDRadnogNaloga)
         {
             var select = " SELECT IDRadnogNaloga, IDTrase, SmSifra,  CASE WHEN Vucna > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Vucna , Komentar, StanicaOd, s1.Opis as Od,  StanicaDo, s2.Opis as Do, Vreme " +
                " FROM RadniNalogLokNaTrasi " +
                " inner join stanice s1 on s1.ID = StanicaOd" +
                " inner join stanice s2 on s2.ID = StanicaDo " +
                " where IDRadnogNaloga =" + IDRadnogNaloga + " and IDTrase = " + IDTrase;

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
             dataGridView2.Columns[0].HeaderText = "RN";
             dataGridView2.Columns[0].Width = 40;

             DataGridViewColumn column2 = dataGridView2.Columns[1];
             dataGridView2.Columns[1].HeaderText = "Trasa";
             dataGridView2.Columns[1].Width = 60;

             DataGridViewColumn column3 = dataGridView2.Columns[2];
             dataGridView2.Columns[2].HeaderText = "Lokomotiva";
             dataGridView2.Columns[2].Width = 60;

             DataGridViewColumn column4 = dataGridView2.Columns[3];
             dataGridView2.Columns[3].HeaderText = "Vučna";
             dataGridView2.Columns[3].Width = 40;

             DataGridViewColumn column5 = dataGridView2.Columns[4];
             dataGridView2.Columns[4].HeaderText = "Napomena";
             dataGridView2.Columns[4].Width = 260;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "St";
            dataGridView1.Columns[5].Width = 20;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Od";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "St";
            dataGridView1.Columns[7].Width = 20;


            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Do";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Vreme";
            dataGridView1.Columns[9].Width = 80;
        }

        private void VratiTeretnice(string IDRadnogNaloga)
        {
            //var select = " SELECT IDRadnogNaloga, IDTrase, SmSifra, Komentar FROM RadniNalogLokNaTrasi where IDRadnogNaloga =" + IDRadnogNaloga + " and IDTrase = " + IDTrase;
           // var select = " Select * from RadniNalogTeretnice where IDRadnogNaloga =" + IDRadnogNaloga ;

           var select =  " Select IDRadnogNaloga, IDTeretnice, st.opis ,prijemna, prevozna, predajna, COUNT(BrojKola) as BrojKola, SUM(Duzina) as Duzina, SUM(tara) as Tara, SUM(neto) as Neto, SUM(p) as P  from RadniNalogTeretnice " +
            "inner join Teretnica on RadniNalogTeretnice.IDTeretnice = Teretnica.ID " +
            "inner join stanice as st on st.ID = Teretnica.StanicaPopisa " +
            "inner join TeretnicaStavke ts on ts.BrojTeretnice = Teretnica.ID " +
            "where IDRadnogNaloga = "  + IDRadnogNaloga  +  " group by IDTeretnice,st.Opis, IDRadnogNaloga,prijemna, prevozna, predajna ";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];

            dataGridView4.BorderStyle = BorderStyle.None;
            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView4.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView4.BackgroundColor = Color.White;

            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataGridViewColumn column = dataGridView4.Columns[0];
            dataGridView4.Columns[0].HeaderText = "RN";
            dataGridView4.Columns[0].Width = 30;

            DataGridViewColumn column2 = dataGridView4.Columns[1];
            dataGridView4.Columns[1].HeaderText = "Teretnica";
            dataGridView4.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView4.Columns[2];
            dataGridView4.Columns[2].HeaderText = "Stanica popisa";
            dataGridView4.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView4.Columns[3];
            dataGridView4.Columns[3].HeaderText = "Prijemna";
            dataGridView4.Columns[3].Width = 30;

            DataGridViewColumn column5 = dataGridView4.Columns[4];
            dataGridView4.Columns[4].HeaderText = "Prevozna";
            dataGridView4.Columns[4].Width = 30;

            DataGridViewColumn column6 = dataGridView4.Columns[5];
            dataGridView4.Columns[5].HeaderText = "Predajna";
            dataGridView4.Columns[5].Width = 30;

            DataGridViewColumn column7 = dataGridView4.Columns[6];
            dataGridView4.Columns[6].HeaderText = "Br kola";
            dataGridView4.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView4.Columns[7];
            dataGridView4.Columns[7].HeaderText = "Duzina";
            dataGridView4.Columns[7].Width = 50;

            DataGridViewColumn column9 = dataGridView4.Columns[8];
            dataGridView4.Columns[8].HeaderText = "Tara";
            dataGridView4.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView4.Columns[9];
            dataGridView4.Columns[9].HeaderText = "Neto";
            dataGridView4.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView4.Columns[10];
            dataGridView4.Columns[10].HeaderText = "P";
            dataGridView4.Columns[10].Width = 40;

        }

        private void OtvoriTehnologiju()
        {
            Tehnologija.frmTehnologijaPregled tehp = new Tehnologija.frmTehnologijaPregled("Admin");
            tehp.Show();
        }
        
        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            status = true;
            OtvoriTehnologiju();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {

            if (status == true)
            {
                InsertRadniNalog ins = new InsertRadniNalog();
            
                ins.InsRN("1", 1, txtKomentar.Text, Convert.ToInt32(cboPlaner.SelectedValue), Convert.ToString(cboStatusRN.SelectedValue), Convert.ToInt32(cboPorudzbinaID.SelectedValue), Convert.ToInt32(cboPredhodniRadniNalog.SelectedValue));
                VratiZadnjiBroj();
                VratiTrase(txtSifra.Text);
                status = false;
            }
            else
            {
                InsertRadniNalog upd = new InsertRadniNalog();
                upd.UpdRN(Convert.ToInt32(txtSifra.Text),"1", 1, txtKomentar.Text, Convert.ToInt32(cboPlaner.SelectedValue), Convert.ToString(cboStatusRN.SelectedValue), Convert.ToInt32(cboPorudzbinaID.SelectedValue), Convert.ToInt32(cboPredhodniRadniNalog.SelectedValue));
                VratiTrase(txtSifra.Text);
                status = false;
                /*
                const string caption = "Promena podataka";
                var result = MessageBox.Show("Da li unosite novu verziju?", caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
              */
                /*
                    InsertNajava upd = new InsertNajava();
                    upd.UpdNaj(Convert.ToInt32(txtSifra.Text), txtOpis.Text, cmbVoz.Text, Convert.ToInt32(cboPosiljalac.SelectedValue), Convert.ToInt32(cboPrevoznik.SelectedValue), Convert.ToInt32(cboOtpravna.SelectedValue), Convert.ToInt32(cboUputna.SelectedValue), Convert.ToInt32(cboPrimalac.SelectedValue), Convert.ToInt32(cboNHM.SelectedValue), txtRelacija.Text, Convert.ToDouble(txtTezinaVozaM.Text), Convert.ToDouble(txtDuzinaM.Text), Convert.ToInt32(txtBrojKola.Text), chkRID.Checked, Convert.ToDateTime(dtpPredvidjenoPrimanje.Value), Convert.ToDateTime(dtpStvarnoPrimanje.Value), Convert.ToDateTime(dtpPredvidjenaPredaja.Value), Convert.ToDateTime(dtpStvarnaPredaja.Value), cboStatusRadnogNaloga.Text, cboNHM.Text, txtRIDBroj.Text);
                    status = false;
                    txtSifra.Enabled = false;
                    RefreshDataGrid();
               */
            }

        }

        private void RefreshDataGrid()
        { 

        }

        private void VratiZadnjiBroj()
        { 
       
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT max(ID) as Broj from RadniNalog", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["Broj"].ToString();
            }

            con.Close();
       
        
        
        
        }

        private void frmRadniNalog_Load(object sender, EventArgs e)
        {
            var select = " Select Distinct SDnSifra, (Rtrim(Cast(SDnSifra as nvarchar(2))) +  '--'  + Rtrim(SdnOpis) ) as StatusRN From StatusDelNaloga";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboStatusRN.DataSource = ds.Tables[0];
            cboStatusRN.DisplayMember = "StatusRN";
            cboStatusRN.ValueMember = "SDnSifra";

            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboPlaner.DataSource = ds3.Tables[0];
            cboPlaner.DisplayMember = "Opis";
            cboPlaner.ValueMember = "ID";


            var select6 = " Select Najava.ID, Najava.TehnologijaID, Tehnologija.PorudzbinaID as MP ,MpNaziv,Tezina as NajavaTezina,Duzina as NajavaDuzina , BrojKola as NajavaBrojKola, Tehnologija.Tonaza, Tehnologija.TonazaPovratak  from Najava " +
            " inner join Tehnologija on Tehnologija.ID = Najava.TehnologijaID " +
            " inner join MaticniPodatki on MaticniPodatki.MpSifra = Tehnologija.PorudzbinaID " +
            " order by Najava.ID desc";

            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);

            DataView view = new DataView(ds6.Tables[0]);
            //multiColumnComboBox1.ReadOnly = true;
            cboPorudzbinaID.DataSource = view;
            cboPorudzbinaID.DisplayMember = "ID";
            cboPorudzbinaID.ValueMember = "ID";


            var select7 = " Select ID, Komentar, Planer, StatusRN, TehnologijaID from RadniNalog order by ID desc";

            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);

            DataView view3 = new DataView(ds7.Tables[0]);
            cboPredhodniRadniNalog.DataSource = view3;
            cboPredhodniRadniNalog.DisplayMember = "ID";
            cboPredhodniRadniNalog.ValueMember = "ID";



            if (txtSifra.Text == "")
            {

            }
            else
            {
                VratiPodatke(txtSifra.Text);
                VratiTrase(txtSifra.Text);
            }
            /*
            var select = " Select Distinct ID, (Rtrim(Cast(ID as nvarchar(10))) +  '--'  + Rtrim(BrojNajave) ) as Najava From Najava";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboNajava.DataSource = ds.Tables[0];
            cboNajava.DisplayMember = "Najava";
            cboNajava.ValueMember = "ID";
             * */
            /*
            var select2 = " Select Distinct ID, RTrim(Opis) as Opis From StatusVoza";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboStatusRadnogNaloga.DataSource = ds2.Tables[0];
            cboStatusRadnogNaloga.DisplayMember = "Opis";
            cboStatusRadnogNaloga.ValueMember = "ID";

            var select3 = " Select Distinct PaSifra, RTrim(PaNaziv) as Partner From Partnerji";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboPosiljalac.DataSource = ds3.Tables[0];
            cboPosiljalac.DisplayMember = "Partner";
            cboPosiljalac.ValueMember = "PaSifra";

            var select4 = " Select Distinct PaSifra, RTrim(PaNaziv) as Partner From Partnerji";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPrevoznik.DataSource = ds4.Tables[0];
            cboPrevoznik.DisplayMember = "Partner";
            cboPrevoznik.ValueMember = "PaSifra";

            var select5 = " Select Distinct PaSifra, RTrim(PaNaziv) as Partner From Partnerji";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboPrimalac.DataSource = ds5.Tables[0];
            cboPrimalac.DisplayMember = "Partner";
            cboPrimalac.ValueMember = "PaSifra";


            var select6 = " Select Distinct ID, RTrim(Opis) as Stanica From Stanice";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboOtpravna.DataSource = ds6.Tables[0];
            cboOtpravna.DisplayMember = "Stanica";
            cboOtpravna.ValueMember = "ID";

            var select7 = " Select Distinct ID, RTrim(Opis) as Stanica From Stanice";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboUputna.DataSource = ds7.Tables[0];
            cboUputna.DisplayMember = "Stanica";
            cboUputna.ValueMember = "ID";


            var select8 = " Select Distinct ID, RTrim(Broj) as NHM From NHM";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cmbVoz.DataSource = ds.Tables[0];
            cmbVoz.DisplayMember = "NHM";
            cmbVoz.ValueMember = "ID";

            var select9 = " Select Distinct ID, RTrim(Opis) as Razlog From Razlozi";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection9);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);

            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            txtRazlog.DataSource = ds.Tables[0];
            txtRazlog.DisplayMember = "Razlog";
            txtRazlog.ValueMember = "ID";
             */
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmRadniNalogTraseLok frmtl = new frmRadniNalogTraseLok(txtSifra.Text, "1", pomTrasa);
            frmtl.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (tabControl1.SelectedIndex == 1)
            {
                var select = "SELECT     RadniNalogTrase.IDRadnogNaloga, RadniNalogTrase.RB, RadniNalogTrase.IDTrase, stanice.Opis AS Pocetna, stanice_1.Opis AS Krajnja, Trase.Relacija, " +
                         " Trase.OpisRelacije, Trase.Voz, Trase.TezinaVoza, Trase.TezinaLokomotive, Trase.DuzinaVoza, Trase.ProcenatKocenja, Trase.Rastojanje, Trase.DuzinaTrajanja, " +
                         " Trase.VremePolaska, Trase.VremeDolaska " +
                           " FROM RadniNalogTrase INNER JOIN " +
                        " Trase ON RadniNalogTrase.IDTrase = Trase.ID INNER JOIN " +
                        " stanice ON Trase.Pocetna = stanice.ID INNER JOIN " +
                         " stanice AS stanice_1 ON Trase.Krajnja = stanice_1.ID where RadniNalogTrase.IDRadnogNaloga =  " + Convert.ToInt32(txtSifra.Text) + " order by IDRadnogNaloga";
                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

                DataGridViewColumn column = dataGridView1.Columns[0];
                dataGridView1.Columns[0].HeaderText = "RN";
                dataGridView1.Columns[0].Width = 30;

                DataGridViewColumn column2 = dataGridView1.Columns[1];
                dataGridView1.Columns[1].HeaderText = "RB";
                dataGridView1.Columns[1].Width = 30;

                DataGridViewColumn column3 = dataGridView1.Columns[2];
                dataGridView1.Columns[2].HeaderText = "Trasa";
                dataGridView1.Columns[2].Width = 30;

                DataGridViewColumn column4 = dataGridView1.Columns[3];
                dataGridView1.Columns[3].HeaderText = "Početna";
                dataGridView1.Columns[3].Width = 70;

                DataGridViewColumn column5 = dataGridView1.Columns[4];
                dataGridView1.Columns[4].HeaderText = "Krajnja";
                dataGridView1.Columns[4].Width = 70;

                DataGridViewColumn column6 = dataGridView1.Columns[5];
                dataGridView1.Columns[5].HeaderText = "Relacija";
                dataGridView1.Columns[5].Width = 100;

                DataGridViewColumn column7 = dataGridView1.Columns[6];
                dataGridView1.Columns[6].HeaderText = "Voz";
                dataGridView1.Columns[6].Width = 50;

                 DataGridViewColumn column8 = dataGridView1.Columns[7];
                dataGridView1.Columns[7].HeaderText = "Težina voz";
                dataGridView1.Columns[7].Width = 50;

                DataGridViewColumn column9 = dataGridView1.Columns[8];
                dataGridView1.Columns[8].HeaderText = "Težina lokomotiva";
                dataGridView1.Columns[8].Width = 50;

                DataGridViewColumn column10 = dataGridView1.Columns[9];
                dataGridView1.Columns[9].HeaderText = "Dužina voza";
                dataGridView1.Columns[9].Width = 50;

                 DataGridViewColumn column11 = dataGridView1.Columns[10];
                dataGridView1.Columns[10].HeaderText = "Procenat kočenja";
                dataGridView1.Columns[10].Width = 50;

                DataGridViewColumn column12 = dataGridView1.Columns[11];
                dataGridView1.Columns[11].HeaderText = "Rastojanje";
                dataGridView1.Columns[11].Width = 50;

                 DataGridViewColumn column13 = dataGridView1.Columns[12];
                dataGridView1.Columns[12].HeaderText = "Dužina trajanja";
                dataGridView1.Columns[12].Width = 50;

                 DataGridViewColumn column14 = dataGridView1.Columns[13];
                dataGridView1.Columns[13].HeaderText = "Vreme polaska";
                dataGridView1.Columns[13].Width = 50;

                  DataGridViewColumn column15 = dataGridView1.Columns[14];
                dataGridView1.Columns[14].HeaderText = "Vreme dolaska";
                dataGridView1.Columns[14].Width = 50;
                 
               /*



 try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        txtOpis.Text = row.Cells[1].Value.ToString();
                        txtTrase.Text = row.Cells[2].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }


                */

            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmLokomotiveNaTrasi frmtl = new frmLokomotiveNaTrasi(txtSifra.Text, pomTrasa);
            frmtl.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    pomTrasa = Convert.ToInt32(row.Cells[2].Value.ToString());

                    VratiLokomotive(pomTrasa, txtSifra.Text);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmRadniNalogZaposleni frmtzl = new frmRadniNalogZaposleni(txtSifra.Text, "1", pomTrasa);
            frmtzl.Show();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                       // txtTrase.Text = row.Cells[0].Value.ToString();
                       // VratiLokomotive(Convert.ToInt32(txtTrase.Text), txtSifra.Text);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija trasa");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            VratiTrase(txtSifra.Text);
           // txtSifra.Text = IDRadnogNaloga;
            VratiTeretnice(txtSifra.Text);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmPravljenjeVoza frmPrav = new frmPravljenjeVoza(Convert.ToInt32(txtSifra.Text));
            frmPrav.Show();
        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            frmDokumentaRadniNalog frmd = new frmDokumentaRadniNalog(txtSifra.Text);
            frmd.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

           
        }

        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (row.Selected)
                {
                    frmTeretnica ter = new frmTeretnica(row.Cells[1].Value.ToString(), "sa");
                     ter.Show();
                }
            }
           
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            int BrojTehnologije = 0;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT TehnologijaID from Najava where ID = " + Convert.ToInt32(cboPorudzbinaID.SelectedValue), con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                BrojTehnologije = Convert.ToInt32(dr["TehnologijaID"].ToString());
            }

            con.Close();


            Tehnologija.frmTehnologija tehn = new Tehnologija.frmTehnologija(BrojTehnologije, "");
            tehn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertRadniNalog ins = new InsertRadniNalog();
            ins.InsRadniNalogVezaNajava(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboPorudzbinaID.Text), Convert.ToInt32(txtBrojKola.Value));
            RefreshDataGridNajave();
            // VratiTrase(txtSifra.Text);
        }
        private void RefreshDataGridNajave()
        {
            var select = " select * from RadniNalogVezaNajave where IDRadnogNaloga = " + Convert.ToInt32(txtSifra.Text) ;

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
            dataGridView3.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "IDRadnogNaloga";
            dataGridView3.Columns[1].Width = 60;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "IDNajave";
            dataGridView3.Columns[2].Width = 60;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Broj kola";
            dataGridView3.Columns[3].Width = 60;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertRadniNalog ins = new InsertRadniNalog();
            ins.DeleteRNVezaNajava(Convert.ToInt32(txtSifraZap.Text));
            RefreshDataGridNajave();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            VratiPodatkeIDNajave();
        }

        private void VratiPodatkeIDNajave()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifraZap.Text = row.Cells[0].Value.ToString();
                        cboPorudzbinaID.Text = row.Cells[2].Value.ToString();
                        txtBrojKola.Value = Convert.ToDecimal(row.Cells[3].Value.ToString());
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
