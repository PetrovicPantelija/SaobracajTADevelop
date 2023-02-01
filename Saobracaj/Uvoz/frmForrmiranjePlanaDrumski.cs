using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Saobracaj.Uvoz
{
    public partial class frmForrmiranjePlanaDrumski : Form
    {
        bool status = false;
        public string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        public frmForrmiranjePlanaDrumski()
        {
            InitializeComponent();
        }

        public frmForrmiranjePlanaDrumski(int ID)
        {
            InitializeComponent();
            txtID.Text = ID.ToString();
            VratiOstalePodatke();
        }
        private void VratiOstalePodatke()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT  ID, VoziloOznaka, VoziloDatum, VoziloVozac, BrojTelefona, Napomena from UvozKonacnaZaglavlje " +
            "  where ID=" + txtID.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtID.Text = dr["ID"].ToString();
                txtVozilo.Text = dr["VoziloOznaka"].ToString();
                dtpDatum.Value = Convert.ToDateTime(dr["VoziloDatum"].ToString());
                txtNapomena.Text = dr["VoziloOznaka"].ToString();
                txtVozac.Text = dr["VoziloOznaka"].ToString();
                txtBrojTelefona.Text = dr["VoziloOznaka"].ToString();

            }
            con.Close();
            RefreshDataGrid1();
            RefreshDataGrid2();
        }

        private void RefreshDataGrid1()
        {

            var select = " select Uvoz.ID, EtaBroda, AtaBroda, BrojKontejnera, TipKontenjera.SkNaziv from Uvoz " +
" inner join TipKontenjera on TipKontenjera.ID = Uvoz.TipKontejnera order by Uvoz.ID desc";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
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
            dataGridView1.Columns[0].Width = 50;

        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertUvozKonacnaZaglavlje ins = new InsertUvozKonacnaZaglavlje();
            if (status == true)
            {
                ins.InsUvozKonacnaZaglavlje(0,txtNapomena.Text,0,txtVozilo.Text, Convert.ToDateTime(dtpDatum.Value), txtVozac.Text, txtBrojTelefona.Text);
            }
            else
            {
                ins.UpdUvozKonacnaZaglavlje(Convert.ToInt32(txtID.Text.ToString()), 0, txtNapomena.Text, 0, txtVozilo.Text, Convert.ToDateTime(dtpDatum.Value), txtVozac.Text, txtBrojTelefona.Text);
            }
          //  FillGV();
            tsNew.Enabled = true;
            status = false;

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            tsNew.Enabled = false;
            status = true;
        }
        private void RefreshDataGrid2()
        {
            var select = "SELECT UvozKonacna.ID, AtaBroda, " +
"  [EtaBroda],[BrojKontejnera], DobijenNalogBrodara, TipKontenjera.Naziv,DobijeBZ,PIN,  pp1.Naziv as DirigacijaKontejneraZa, " +
"  Brodovi.Naziv as Brod,BrodskaTeretnica, VrstaRobeADR.Naziv as ADR, " +
"  Carinarnice.Naziv,   Partnerji.PaNaziv as Vlasnik, Partnerji.PaEMatSt1 as VlasnikPIB,nalogodavac,VrstaUsluge, " +
"  p1.PaNaziv as Uvoznik, p1.PaEMatSt1 as UvoznikPIB,  " +
"   (" +
"   SELECT" +
"  STUFF(" +
"   (" +
"   SELECT distinct" +
"    '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20))" +
"   FROM UvozKonacnaVrstaRobeHS" +
"   inner join VrstaRobeHS on UvozKonacnaVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID" +
"   where UvozKonacnaVrstaRobeHS.IDNadredjena = UvozKonacna.ID" +
"   FOR XML PATH('')" +
"    ), 1, 1, '' " +
"  ) As Skupljen) as VrsteRobe, " +
"  (" +
"  SELECT" +
"  STUFF(" +
"   (" +
"   SELECT distinct" +
"    '/' + Cast(NHM.Broj as nvarchar(20))" +
"   FROM UvozKonacnaNHM" +
 "  inner join NHM on UvozKonacnaNHM.IDNHM = NHM.ID" +
"  where UvozKonacnaNHM.IDNadredjena = UvozKonacna.ID" +
"   FOR XML PATH('')" +
 "  ), 1, 1, ''" +
"  ) As Skupljen) as NHM, " +
"  p2.PaNaziv as SpedicijaRTC, " +
"  p3.PaNaziv as SpedicijaGranica," +
"  VrstaCarinskogPostupka.Naziv as CarinskiPostupak, " +
"    VrstePostupakaUvoz.Naziv as PostupakSaRobom,uvNacinPakovanja.Naziv as NacinPakovanja, Napomena, " +
"      (Carinarnice.CINaziv + ' ' + Carinarnice.CIOznaka + ' ' + CIEmail + ' ' + CITelefon + ' / ' + p3.PaNaziv) as Carinarnica, " +
"      p4.PaNaziv as OdredisnaSpedicija," +
"      MestoIstovara, KontaktOsoba, Email, BrojPlombe1, BrojPlombe2, " +
"      PredefinisanePoruke.Naziv as NapomenaZaPozicioniranje, NetoRobe, BrutoRobe, TaraKontejnera, BrutoKontejnera, Koleta, BrojVoza, RelacijaVoza, ATAOtpreme, AtaDolazak" +
"       FROM UvozKonacna" +
"       inner join Partnerji on PaSifra = VlasnikKontejnera" +
"      inner join Partnerji p1 on p1.PaSifra = Uvoznik" +
"        inner join Partnerji p2 on p2.PaSifra = SpedicijaRTC" +
"        inner join Partnerji p3 on p3.PaSifra = SpedicijaGranica" +
"     inner join VrstaRobeHS on VrstaRobeHS.ID = UvozKonacna.NazivRobe" +
"     inner join NHM on NHM.ID = NHMBroj" +
"    inner join TipKontenjera on TipKontenjera.ID = UvozKonacna.TipKontejnera" +
"    inner join Carinarnice on Carinarnice.ID = UvozKonacna.OdredisnaCarina" +
"     inner join VrstaCarinskogPostupka on VrstaCarinskogPostupka.ID = UvozKonacna.CarinskiPostupak" +
"     inner join Predefinisaneporuke on PredefinisanePoruke.ID = UvozKonacna.NapomenaZaPozicioniranje" +
"    inner join PredefinisanePoruke pp1 on pp1.ID = DirigacijaKontejeraZa" +
"     inner join Brodovi on Brodovi.ID = UvozKonacna.NazivBroda" +
"    inner join VrstaRobeADR on VrstaRobeADR.ID = ADR" +
"    inner join VrstePostupakaUvoz on VrstePostupakaUvoz.ID = PostupakSaRobom" +
"    inner join uvNacinPakovanja on uvNacinPakovanja.ID = NacinPakovanja" +
"  inner join Partnerji p4 on p4.PaSifra = OdredisnaSpedicija " +
" where UvozKonacna.IdNadredjeni = " + Convert.ToInt32(txtID.Text) + " order by UvozKonacna.ID desc";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
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
            dataGridView2.Columns[0].Width = 50;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {

                    InsertUvozKonacna ins = new InsertUvozKonacna();
                    ins.PrenesiUPlanUtovara(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(txtID.Text));

                }
            }
            RefreshDataGrid1();
            RefreshDataGrid2();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmForrmiranjePlanaDrumski_Load(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //   1   Uvoz
            // 2   Izvoz 
            // 3   Bezbednost
            // 4   Terminal 
            // 5   Opšte 
            // 6   Drumski prevoz 
            DialogResult dialogResult = MessageBox.Show("Da li pravite za Drumski saobraćaj za selektovane zapise Da/Ne", "Radni nalog interni", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                        InsertRadniNalogInterni ins = new InsertRadniNalogInterni();
                        ins.InsRadniNalogInterni(Convert.ToInt32(1), Convert.ToInt32(6), Convert.ToDateTime(DateTime.Now), Convert.ToDateTime("1.1.1900. 00:00:00"), "", Convert.ToInt32(0), "PlanUtovaraDrumski", Convert.ToInt32(row.Cells[0].Value.ToString()), "sa", "sa");
                    }
                }
            }
            else
            {
                // FormirajOpstiExcel();
            }

        }
    }
}
