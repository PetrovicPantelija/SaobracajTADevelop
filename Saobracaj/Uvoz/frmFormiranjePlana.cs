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
    public partial class frmFormiranjePlana : Form
    {
        public string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public frmFormiranjePlana()
        {
            InitializeComponent();
        }

        private void VratiUkupanBrojKontejneraPrenetih()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Isnull(SUM(CASE WHEN TipKontejnera = 2 THEN 1 else 2 END),0) as BrojKontejnera from UvozKonacna " +
            " where IDNadredjeni = " + cboPlanUtovara.SelectedValue , con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                nmSpakovanih.Value = Convert.ToInt32(dr["BrojKontejnera"].ToString());
            }

            con.Close();

        }

        private void VratiUkupanBrojKontejneraPrenetihBezSerije()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select count(*) as BrjKontejnera from UvozKonacna " +
            " where IDNadredjeni = " + cboPlanUtovara.SelectedValue, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSpakovaniUB.Value = Convert.ToInt32(dr["BrojKontejnera"].ToString());
            }

            con.Close();

        }

        private void VratiUkupanBrojKontejnera()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select isnull(SUM(Broj20 * BrojSerija),0) as BrojKontejnera from VozSerijeKola " +
            " inner join SerijeKola on SerijeKola.Id = VozSerijeKola.TipKontejnera where IDVoza = (Select Top 1 IDVoza from UvozKonacnaZaglavlje where ID = " + cboPlanUtovara.SelectedValue + " ) ", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                nmrUkupanBrojKontejnera.Value = Convert.ToInt32(dr["BrojKontejnera"].ToString());
            }

            con.Close();

        }

        private void VratiUkupanBrojKontejneraSumaSerija()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select isnull(BrojSerija),0) as BrojKontejnera from VozSerijeKola " +
            " inner join SerijeKola on SerijeKola.Id = VozSerijeKola.TipKontejnera where IDVoza = (Select Top 1 IDVoza from UvozKonacnaZaglavlje where ID = " + cboPlanUtovara.SelectedValue + " ) ", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                nmrUkupanBrojKontejneraSS.Value = Convert.ToInt32(dr["BrojKontejnera"].ToString());
            }

            con.Close();

        }

        private void RefreshDataGrid3()
        {
            var select = "  select SerijeKola.ID as Zapis, UvozKonacnaZaglavlje.IDVoza, VozSerijeKola.TipKontejnera as IDT, Naziv, Broj20 as Nosivost20, BrojSerija, (Broj20 * BrojSerija) as UkupnoPoSeriji  from VozSerijeKola " +
  " inner join UvozKonacnaZaglavlje on UvozKonacnaZaglavlje.IdVoza = VozSerijeKola.IDVoza " +
  "  inner join SerijeKola on SerijeKola.Id = VozSerijeKola.TipKontejnera where UvozkonacnaZaglavlje.ID = " + Convert.ToInt32(cboPlanUtovara.SelectedValue);

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
            dataGridView3.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "ID Voza";
            dataGridView3.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "TSV";
            dataGridView3.Columns[2].Width = 40;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Naziv serije";
            dataGridView3.Columns[3].Width = 80;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Nosivost 20 ST";
            dataGridView3.Columns[4].Width = 60;

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Broj Serija";
            dataGridView3.Columns[5].Width = 60;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Ukupno po Seriji";
            dataGridView3.Columns[6].Width = 70;

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
" where UvozKonacna.IdNadredjeni = " + Convert.ToInt32(cboPlanUtovara.SelectedValue) + " order by UvozKonacna.ID desc";  
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
                        ins.PrenesiUPlanUtovara(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboPlanUtovara.SelectedValue));
                       
                }
            }
            RefreshDataGrid1();
            RefreshDataGrid2();
            VratiUkupanBrojKontejnera();
            VratiUkupanBrojKontejneraPrenetih();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid2();
            RefreshDataGrid3();
            VratiUkupanBrojKontejnera();
            VratiUkupanBrojKontejneraSumaSerija();
            VratiUkupanBrojKontejneraPrenetih();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
           

        }
        private void FillCombo()
        {
            var planutovara = "select UvozKonacnaZaglavlje.ID,(Cast(BrVoza as nvarchar(15)) + ' '  + Relacija) as Naziv from UvozKonacnaZaglavlje " +
              " inner join Voz on Voz.Id = UvozKonacnaZaglavlje.IdVoza order by UvozKonacnaZaglavlje.ID desc";
            var planutovaraSAD = new SqlDataAdapter(planutovara, connection);
            var planutovaraSDS = new DataSet();
            planutovaraSAD.Fill(planutovaraSDS);
            cboPlanUtovara.DataSource = planutovaraSDS.Tables[0];
            cboPlanUtovara.DisplayMember = "Naziv";
            cboPlanUtovara.ValueMember = "ID";

        }

        private void frmFormiranjePlana_Load(object sender, EventArgs e)
        {
            RefreshDataGrid1();
            RefreshDataGrid2();
            FillCombo();
           
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void nmrUkupanBrojKontejnera_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
