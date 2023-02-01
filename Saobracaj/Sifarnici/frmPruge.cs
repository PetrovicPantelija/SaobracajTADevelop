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

namespace Saobracaj.Sifarnici
{
    public partial class frmPruge : Form
    {
        public static string code = "frmPruge";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";

        bool status = false;
        public frmPruge()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            txtOznaka.Text = "";
            txtOpis.Text = "";
            status = true;
        }

        private void VratiMaxId()
        {
            bool temp = false;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max(ID) as ID from Pruga " , con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            if (temp == false)

                MessageBox.Show("not found");
            con.Close();

        }

        private void tsSave_Click(object sender, EventArgs e)
        {
           
            if (status == true)
            {
                int tmpEliktrificirana = 0;
                if (chkElektrificirana.Checked == true)
                {
                    tmpEliktrificirana = 1;
                
                }
                InsertPruga ins = new InsertPruga();
                ins.InsPruga(txtOznaka.Text, txtOpis.Text, tmpEliktrificirana);
                VratiMaxId();
               // RefreshDataGrid();
                status = false;
            }
            else
            {
                int tmpEliktrificirana = 0;
                if (chkElektrificirana.Checked == true)
                {
                    tmpEliktrificirana = 1;

                }
                InsertPruga upd = new InsertPruga();
                upd.UpdPruga(Convert.ToInt32(txtSifra.Text), txtOznaka.Text, txtOpis.Text, tmpEliktrificirana);
                status = false;
                txtSifra.Enabled = false;
               // RefreshDataGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertPrugaStavke ins = new InsertPrugaStavke();
            ins.InsPrugaStavke(Convert.ToInt32(txtOznaka.Text), Convert.ToInt32(StanicaOD.SelectedValue), Convert.ToInt32(stanicaDO.SelectedValue), Convert.ToInt32(RastojanjeKM.Value), Convert.ToInt32(RastojanjeM.Value), Convert.ToDouble(StacionazaKM.Value), Convert.ToInt32(StacionazaM.Value), Convert.ToInt32(VmaxL.Text), Convert.ToInt32(VmaxD.Text), OsOtpor.Text, Convert.ToInt32(MaxDVA.Value), KoliseciA.Text, Convert.ToInt32(MaxDVB.Value), KoliseciB.Text, Vaga.Text, PutTer.Text, Convert.ToDouble(Nagib.Value), Convert.ToDouble(MNU.Value), Convert.ToDouble(MNP.Value), Convert.ToDouble(MNOU.Value), Convert.ToDouble(MNOP.Value), cmbKlasa.Text, Convert.ToDouble(txtOsovinsko.Value));
            RastojanjeKM.Value = 0;
            RastojanjeM.Value = 0;
            StacionazaKM.Value = 0; 
            StacionazaM.Value = 0;
            VmaxL.Value = 0; 
            VmaxD.Value = 0; 
            OsOtpor.Text = "";
            MaxDVA.Value = 0; 
            KoliseciA.Text = "";
            MaxDVB.Value = 0;
            KoliseciB.Text = "";
            Vaga.Text = "";
            PutTer.Text = ""; 
            Nagib.Value = 0;
            MNU.Value = 0; 
            MNP.Value = 0;
            MNOU.Value = 0;
            MNOP.Value = 0;
            RefreshDataGrid(); 
        }

        private void frmPruge_Load(object sender, EventArgs e)
        {
            var select6 = " Select Distinct ID, RTrim(Opis) as Stanica From Stanice";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            StanicaOD.DataSource = ds6.Tables[0];
            StanicaOD.DisplayMember = "Stanica";
            StanicaOD.ValueMember = "ID";

            var select7 = " Select Distinct ID, RTrim(Opis) as Stanica From Stanice";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            stanicaDO.DataSource = ds7.Tables[0];
            stanicaDO.DisplayMember = "Stanica";
            stanicaDO.ValueMember = "ID";
        }

        public void RefreshDataGrid()
        {
            var select = " Select PrugaStavke.ID,PrugaStavke.RB, PrugaStavke.IDPruge, stanice.Opis, stanice.Kod as UIC, PrugaStavke.StacionazaKM, " +
                    " PrugaStavke.MNOU,PrugaStavke.MNOP, PrugaStavke.Klasa, PrugaStavke.Osovinsko " +
                    "   FROM         Pruga inner JOIN " +
                    " PrugaStavke ON Pruga.Oznaka = PrugaStavke.IDPruge left JOIN" +
                    " stanice ON PrugaStavke.StanicaOd = stanice.ID left JOIN" +
                    " stanice AS stanice_1 ON PrugaStavke.StanicaDo = stanice_1.ID where Pruga.Oznaka ='" + txtOznaka.Text + "'";
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
            dataGridView1.Columns[0].Width = 60;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "IDPRUGE";
            dataGridView1.Columns[2].Width = 60;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Stanica";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "UIC";
            dataGridView1.Columns[4].Width = 40;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Stacionaza";
            dataGridView1.Columns[5].Width = 40;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "MO A";
            dataGridView1.Columns[6].Width = 40;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "MO B";
            dataGridView1.Columns[7].Width = 40;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Klasa";
            dataGridView1.Columns[8].Width = 40;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Osovinsko";
            dataGridView1.Columns[9].Width = 40;

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            frmPrugeSpisak frmsp = new frmPrugeSpisak();
            frmsp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtOznaka.Text == "")
            {
                MessageBox.Show("Morate prvo uneti oznaku pruge");
                return;
            }
            var select = "  Select PrugaStavke.ID,PrugaStavke.RB, PrugaStavke.IDPruge, stanice.Opis, stanice.Kod as UIC, PrugaStavke.StacionazaKM, " +
                    " PrugaStavke.MNOU,PrugaStavke.MNOP, PrugaStavke.Klasa, PrugaStavke.Osovinsko " +
                    "   FROM         Pruga inner JOIN " +
                     " PrugaStavke ON Pruga.Oznaka = PrugaStavke.IDPruge INNER JOIN" +
                     " stanice ON PrugaStavke.StanicaOd = stanice.ID INNER JOIN" +
                     " stanice AS stanice_1 ON PrugaStavke.StanicaDo = stanice_1.ID where Pruga.Oznaka ='" + txtOznaka.Text + "'";
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
            dataGridView1.Columns[0].Width = 60;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 80;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "IDPRUGE";
            dataGridView1.Columns[2].Width = 60;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Stanica";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "UIC";
            dataGridView1.Columns[4].Width = 40;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Stacionaza";
            dataGridView1.Columns[5].Width = 40;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "MO A";
            dataGridView1.Columns[6].Width = 40;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "MO B";
            dataGridView1.Columns[7].Width = 40;
            
            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Klasa";
            dataGridView1.Columns[8].Width = 40;
          
             DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Osovinsko";
            dataGridView1.Columns[9].Width = 40;

           

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (row.Selected)
                    { 
                        txtRB.Text = row.Cells[0].Value.ToString();
                        VratiPodatke(Convert.ToInt32(row.Cells[0].Value.ToString()));
                       
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela promena stavki");
            }
        }
        private void VratiPodatke(int RB)
        {
            bool temp = false;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from PrugaStavke where IDPruge=" + txtOznaka.Text.Trim() + " and ID =" + RB, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                StanicaOD.SelectedValue = Convert.ToInt32(dr["StanicaOd"].ToString());
                stanicaDO.SelectedValue = Convert.ToInt32(dr["StanicaDo"].ToString());
                RastojanjeKM.Value  = Convert.ToInt32(dr["RastojanjeKM"].ToString());
                RastojanjeM.Value = Convert.ToInt32(dr["RastojanjeM"].ToString());
                StacionazaKM.Value = Convert.ToDecimal(dr["StacionazaKM"].ToString());
                StacionazaM.Value = Convert.ToInt32(dr["StacionazaM"].ToString());
                VmaxL.Value = Convert.ToInt32(dr["VmaxL"].ToString());
                VmaxD.Value = Convert.ToInt32(dr["VmaxD"].ToString());
                OsOtpor.Text = dr["OsOtpor"].ToString();
                MaxDVA.Value = Convert.ToInt32(dr["MaxDVA"].ToString());
                KoliseciA.Text = dr["KoliseciA"].ToString();
                MaxDVB.Value = Convert.ToInt32(dr["MaxDVB"].ToString());
                KoliseciB.Text = dr["KoliseciB"].ToString();
                Vaga.Text = dr["Vaga"].ToString();
                PutTer.Text = dr["PutTer"].ToString();
                Nagib.Value = Convert.ToDecimal(dr["Nagib"].ToString());
                MNU.Value = Convert.ToDecimal(dr["MNU"].ToString());
                MNP.Value = Convert.ToDecimal(dr["MNP"].ToString());
                MNOU.Value = Convert.ToDecimal(dr["MNOU"].ToString());
                MNOP.Value = Convert.ToDecimal(dr["MNOP"].ToString());
                temp = true;
                }

            if (temp == false)

            MessageBox.Show("not found");
            con.Close();

            }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertPrugaStavke upd = new InsertPrugaStavke();
            upd.UpdPrugaStavke(Convert.ToInt32(txtRB.Text), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(StanicaOD.SelectedValue), Convert.ToInt32(stanicaDO.SelectedValue), Convert.ToInt32(RastojanjeKM.Value), Convert.ToInt32(RastojanjeM.Value), Convert.ToDouble(StacionazaKM.Value), Convert.ToInt32(StacionazaM.Value), Convert.ToInt32(VmaxL.Text), Convert.ToInt32(VmaxD.Text), OsOtpor.Text, Convert.ToInt32(MaxDVA.Value), KoliseciA.Text, Convert.ToInt32(MaxDVB.Value), KoliseciB.Text, Vaga.Text, PutTer.Text, Convert.ToDouble(Nagib.Value), Convert.ToDouble(MNU.Value), Convert.ToDouble(MNP.Value), Convert.ToDouble(MNOU.Value), Convert.ToDouble(MNOP.Value), cmbKlasa.Text, Convert.ToDouble(txtOsovinsko.Text));
            RastojanjeKM.Value = 0;
            RastojanjeM.Value = 0;
            StacionazaKM.Value = 0;
            StacionazaM.Value = 0;
            VmaxL.Value = 0;
            VmaxD.Value = 0;
            OsOtpor.Text = "";
            MaxDVA.Value = 0;
            KoliseciA.Text = "";
            MaxDVB.Value = 0;
            KoliseciB.Text = "";
            Vaga.Text = "";
            PutTer.Text = "";
            Nagib.Value = 0;
            MNU.Value = 0;
            MNP.Value = 0;
            MNOU.Value = 0;
            MNOP.Value = 0;
            RefreshDataGrid(); 
        }

        private void txtOznaka_TextChanged(object sender, EventArgs e)
        {

        }
        }
    }

