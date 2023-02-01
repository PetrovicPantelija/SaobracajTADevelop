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

namespace Saobracaj.Dokumenta
{
    public partial class frmAutomobili : Form
    {
        string Poruka = "";
        bool status = false;
        public frmAutomobili()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "frmAutomobili";
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
        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
            txtSifra.Text = "";
            txtRegBr.Text = "";
            txtMarka.Text = "";
        }

        private void frmAutomobili_Load(object sender, EventArgs e)
        {
            RefreshDataGRid();
            IstekPPomoc();
            IstekPP();

            IstekReg();
        }
        private void RefreshDataGRid()
        {
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


            var select4 = " select SmSifra from Mesta";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboMestoTroska.DataSource = ds4.Tables[0];
            cboMestoTroska.DisplayMember = "SmSifra";
            cboMestoTroska.ValueMember = "SmSifra";



            var select = "  select Automobili.ID as ID, Automobili.Zaposleni, " +
           " Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme) as ZaposleniNaziv, " +
           " Automobili.RegBr, Automobili.Marka, Automobili.Sluzbeni, VServisSledeci as VelServisSled, MServisSledeci as MaliServSled,PPAparatDatumIsteka,PRvaPomocDatumIsteka,DatumRegistracije from Automobili " +
" inner join Delavci on Delavci.DeSifra = Automobili.Zaposleni ";

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
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni naziv";
            dataGridView1.Columns[2].Width = 150;


            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Reg br";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Marka";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Službeni";
            dataGridView1.Columns[5].Width = 40;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Veliki servis istek";
            dataGridView1.Columns[6].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Mali servis istek";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "PPAparatDatumIsteka";
            dataGridView1.Columns[8].Width = 120;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "PrvaPomocDatumIsteka";
            dataGridView1.Columns[9].Width = 120;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "DatumRegistracije";
            dataGridView1.Columns[10].Width = 120;
        }
        private void tsSave_Click(object sender, EventArgs e)
        {
            int Sluzbeni = 0;
            int TrougaoIma = 0;
            int MarkerIma = 0;
            int SajluZaVucu = 0;
            int ImaLance = 0;

            if (chkLanci.Checked)
            {
                ImaLance = 1;
            }
            else
            {
                ImaLance = 0;
            }

            if (chkSajlaZaVucu.Checked)
            {
                SajluZaVucu = 1;
            }
            else
            {
                SajluZaVucu = 0;
            }

            if (chkMarker.Checked)
            {
                MarkerIma = 1;
            }
            else
            {
                MarkerIma = 0;
            }
            if (chkImaTrougao.Checked)
            {
                TrougaoIma = 1;
            }
            else
            {
                TrougaoIma = 0;
            }
            if (chkSluzbeni.Checked)
            {
                Sluzbeni = 1;
            }
            else
            {
                Sluzbeni = 0;
            }

            if (status == true)
            {
                InsertAutomobili ins = new InsertAutomobili();
                ins.InsAutomobili(Convert.ToInt32(cboZaposleni.SelectedValue), txtRegBr.Text, txtMarka.Text, Sluzbeni, txtModel.Text, dtpDatumRegistracije.Value
                    , Convert.ToInt32(txtGodinaProizvodnje.Text), txtGorivo.Text, Convert.ToInt32(txtZapreminaMotora.Text),
                    txtKategorija.Text, Convert.ToDateTime(dtpVServisUradjen.Value), Convert.ToDouble(txtVServisKM.Text), Convert.ToDateTime(dtpVServisSledeci.Value),
                    Convert.ToDateTime(dtpMaliServisUradjen.Value), Convert.ToDouble(txtMaliServisKM.Text), Convert.ToDateTime(dtpMaliServisSledeci.Value),
                    txtBrojPlombe1.Text, txtBrojPlombe2.Text, Convert.ToDateTime(dtpPPAparatDatumOvere.Value), Convert.ToDateTime(dtpPPAparatDatumIsteka.Value),
                    txtPPAparatSeriskiBroj.Text, Convert.ToDateTime(dtpPrvaPomocDatumIsteka.Value), TrougaoIma,
                MarkerIma, SajluZaVucu, ImaLance, txtLokacijaLanci.Text, txtZGDot.Text, txtZGLokacija.Text,
                txtZGSare.Text, txtLGgumeDOT.Text, txtLGLokacija.Text, txtLGSare.Text, txtNapomena.Text,
                txtCistocaSpolja.Text, txtCistocaUnutra.Text, txtNivoUlja.Text, txtNepravilnosti.Text, cboMestoTroska.Text);
                status = false;
            }
            else
            {
                InsertAutomobili upd = new InsertAutomobili();
                upd.UpdAutobili(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboZaposleni.SelectedValue), txtRegBr.Text, txtMarka.Text, Sluzbeni, txtModel.Text, dtpDatumRegistracije.Value
                    , Convert.ToInt32(txtGodinaProizvodnje.Text), txtGorivo.Text, Convert.ToInt32(txtZapreminaMotora.Text),
                    txtKategorija.Text, Convert.ToDateTime(dtpVServisUradjen.Value), Convert.ToDouble(txtVServisKM.Text), Convert.ToDateTime(dtpVServisSledeci.Value),
                    Convert.ToDateTime(dtpMaliServisUradjen.Value), Convert.ToDouble(txtMaliServisKM.Text), Convert.ToDateTime(dtpMaliServisSledeci.Value),
                    txtBrojPlombe1.Text, txtBrojPlombe2.Text, Convert.ToDateTime(dtpPPAparatDatumOvere.Value), Convert.ToDateTime(dtpPPAparatDatumIsteka.Value),
                    txtPPAparatSeriskiBroj.Text, Convert.ToDateTime(dtpPrvaPomocDatumIsteka.Value), TrougaoIma,
                MarkerIma, SajluZaVucu, ImaLance, txtLokacijaLanci.Text, txtZGDot.Text, txtZGLokacija.Text,
                txtZGSare.Text, txtLGgumeDOT.Text, txtLGLokacija.Text, txtLGSare.Text, txtNapomena.Text,
                txtCistocaSpolja.Text, txtCistocaUnutra.Text, txtNivoUlja.Text, txtNepravilnosti.Text, cboMestoTroska.Text);
            }
            RefreshDataGRid();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertAutomobili ins = new InsertAutomobili();
            ins.DeleteAutomobili(Convert.ToInt32(txtSifra.Text));
            status = false;
            RefreshDataGRid();
        }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [ID] " +
             " ,[Zaposleni],[RegBr] ,[Marka],[Sluzbeni] " +
             " ,[Model],[DatumRegistracije],[GodinaProizvodnje],[Gorivo] " +
             " ,[ZapreminaMotora],[Kategorija] ,[VServisUradjen],[VServisKM] " +
             " ,[VServisSledeci],[MServisUradjen] ,[MServisKM],[MServisSledeci] " +
             " ,[BrojPlombe1],[BrojPlombe2] ,[PPAparatDatumOvere],[PPAparatDatumIsteka] " +
             " ,[PPAparatSeriski],[PRvaPomocDatumIsteka] ,[TrougaoIma],[SajlaZaVucu] " +
             " ,[Marker],[Lanci] ,[LokacijaLanci],[ZGDOT] " +
             " ,[ZGLokacija],[ZGDubinaSare],[LGDot],[LGLokacija] " +
             " ,[LGDubinaSare],[Napomena],[CistocaSpolja],[CistocaUnutra] " +
             "  ,[NivoUlja],[Nepravilnosti] ,[MestoTroska] " +
             " FROM [TESTIRANJE].[dbo].[Automobili] where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtModel.Text = dr["Model"].ToString();
                dtpDatumRegistracije.Value = Convert.ToDateTime(dr["DatumRegistracije"].ToString());
                txtGodinaProizvodnje.Text = dr["GodinaProizvodnje"].ToString();
                txtGorivo.Text = dr["Gorivo"].ToString();
                txtZapreminaMotora.Text = dr["ZapreminaMotora"].ToString();
                txtKategorija.Text = dr["Kategorija"].ToString();
                dtpVServisUradjen.Value = Convert.ToDateTime(dr["VServisUradjen"].ToString());
                txtVServisKM.Text = dr["VServisKM"].ToString();
                dtpVServisSledeci.Value = Convert.ToDateTime(dr["VServisSledeci"].ToString());
                dtpMaliServisUradjen.Value = Convert.ToDateTime(dr["MServisUradjen"].ToString());
                txtMaliServisKM.Text = dr["MServisKM"].ToString();
                dtpMaliServisSledeci.Value = Convert.ToDateTime(dr["MServisSledeci"].ToString());
                txtBrojPlombe1.Text = dr["BrojPlombe1"].ToString();
                txtBrojPlombe2.Text = dr["BrojPlombe2"].ToString();
                dtpPPAparatDatumOvere.Value = Convert.ToDateTime(dr["PPAparatDatumOvere"].ToString());
                dtpPPAparatDatumIsteka.Value = Convert.ToDateTime(dr["PPAparatDatumIsteka"].ToString());
                txtPPAparatSeriskiBroj.Text = dr["PPAparatSeriski"].ToString();
                dtpPrvaPomocDatumIsteka.Value = Convert.ToDateTime(dr["PRvaPomocDatumIsteka"].ToString());
                if (dr["TrougaoIma"].ToString() == "1")
                {
                    chkImaTrougao.Checked = true;
                }
                else
                {
                    chkImaTrougao.Checked = false;
                }

                if (dr["SajlaZaVucu"].ToString() == "1")
                {
                    chkSajlaZaVucu.Checked = true;
                }
                else
                {
                    chkSajlaZaVucu.Checked = false;
                }

                if (dr["Marker"].ToString() == "1")
                {
                    chkMarker.Checked = true;
                }
                else
                {
                    chkMarker.Checked = false;
                }

                if (dr["Lanci"].ToString() == "1")
                {
                    chkLanci.Checked = true;
                }
                else
                {
                    chkLanci.Checked = false;
                }

                txtLokacijaLanci.Text = dr["LokacijaLanci"].ToString();
                txtZGDot.Text = dr["ZGDOT"].ToString();
                txtZGLokacija.Text = dr["ZGLokacija"].ToString();
                txtZGSare.Text = dr["ZGDubinaSare"].ToString();
                txtLGgumeDOT.Text = dr["LGDot"].ToString();
                txtLGLokacija.Text = dr["LGLokacija"].ToString();
                txtLGSare.Text = dr["LGDubinaSare"].ToString();
                txtNapomena.Text = dr["Napomena"].ToString();
                txtCistocaSpolja.Text = dr["CistocaSpolja"].ToString();
                txtCistocaUnutra.Text = dr["CistocaUnutra"].ToString();
                txtNivoUlja.Text = dr["NivoUlja"].ToString();
                txtNepravilnosti.Text = dr["Nepravilnosti"].ToString();
                cboMestoTroska.SelectedValue = dr["MestoTroska"].ToString();
                cboZaposleni.SelectedValue = Convert.ToInt32(dr["Zaposleni"].ToString());
                txtRegBr.Text = dr["RegBr"].ToString();
                txtMarka.Text = dr["Marka"].ToString();

                if (dr["Sluzbeni"].ToString() == "1")
                {
                    chkSluzbeni.Checked = true;
                }
                else
                {
                    chkSluzbeni.Checked = false;
                }
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

                        DateTime danas = DateTime.Now;
                        DateTime PP = Convert.ToDateTime(row.Cells[8].Value);
                        DateTime pPomoc = Convert.ToDateTime(row.Cells[9].Value);
                        DateTime reg = Convert.ToDateTime(row.Cells[10].Value);
                        DateTime regIstek = reg.AddYears(1);

                        TimeSpan tsPP = PP - danas;
                        TimeSpan tsPomoc = pPomoc - danas;
                        TimeSpan tsReg = regIstek - danas;

                        int diffPP = tsPP.Days;
                        if (diffPP <= 30)
                        {
                            MessageBox.Show("PP Aparat ističe za manje od 30 dana");
                        }
                        int diffPomoc = tsPomoc.Days;
                        if (diffPomoc <= 30)
                        {
                            MessageBox.Show("Prva Pomoć ističe za manje od 30 dana");
                        }
                        int diffReg = tsReg.Days;
                        if (diffReg <= 30)
                        {
                            MessageBox.Show("Registracija ističe za manje od 30 dana");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }
        public void IstekPP()
        {
            var connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand PPA = new SqlCommand("Select Marka, Model,RegBR FROM Automobili Where DateDiff(Day,GetDate(),PPAparatDatumIsteka)<=30", conn);
            conn.Open();
            SqlDataReader dr = PPA.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < 1; i++)
                {
                    string RegBR = dr["RegBr"].ToString();
                    string Marka = dr["Marka"].ToString();
                    string Model = dr["Model"].ToString();
                    Poruka += "Za vozilo " + Marka + " " + Model + " " + RegBR + " " + "PP aparat ističe za manje od 30 dana!" + Environment.NewLine + "\n";
                }
            }
            conn.Close();
        }
        public void IstekPPomoc()
        {
            var connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand PPomoc = new SqlCommand("Select Marka,Model,RegBr From Automobili Where DateDiff(Day,GetDate(),PrvaPomocDatumIsteka)<=30", conn);
            conn.Open();
            SqlDataReader dr = PPomoc.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < 1; i++)
                {
                    string RegBR = dr["RegBr"].ToString();
                    string Marka = dr["Marka"].ToString();
                    string Model = dr["Model"].ToString();
                    Poruka += "Za vozilo " + Marka + " " + Model + " " + RegBR + " " + "prva pomoc ističe za manje od 30 dana!" + Environment.NewLine + "\n";
                }
            }
            conn.Close();
        }
        public void IstekReg()
        {
            var connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand Reg = new SqlCommand("Select Marka,Model,RegBr From Automobili Where DateDiff(Day,GetDate(),DateAdd(year,1,DatumRegistracije))<=30", conn);
            conn.Open();
            SqlDataReader dr = Reg.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < 1; i++)
                {
                    string RegBR = dr["RegBr"].ToString();
                    string Marka = dr["Marka"].ToString();
                    string Model = dr["Model"].ToString();
                    Poruka += "Za vozilo " + Marka + " " + Model + " " + RegBR + " " + "registracija ističe za manje od 30 dana!" + Environment.NewLine + "\n";
                }
            }
            MessageBox.Show(Poruka, "Informacije o vozilima", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            conn.Close();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAutomobiliDokumenta ad = new frmAutomobiliDokumenta(txtSifra.Text);
            ad.Show();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmAutomobiliServis ass = new frmAutomobiliServis(txtSifra.Text);
            ass.Show();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmAutomobiliRegistracija reg = new frmAutomobiliRegistracija(txtSifra.Text);
            reg.Show();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmEvidencijaTroskova trosak = new frmEvidencijaTroskova();
            trosak.Show();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmEvidencijaKvarova kvar = new frmEvidencijaKvarova();
            kvar.Show();
        }

        private void txtCistocaUnutra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
