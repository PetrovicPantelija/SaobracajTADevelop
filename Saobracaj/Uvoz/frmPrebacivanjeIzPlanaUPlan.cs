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
    public partial class frmPrebacivanjeIzPlanaUPlan : Form
    {
        public string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        public frmPrebacivanjeIzPlanaUPlan()
        {
            InitializeComponent();
        }

        private void frmPrebacivanjeIzPlanaUPlan_Load(object sender, EventArgs e)
        {
            var planutovara = "select UvozKonacnaZaglavlje.ID,(Cast(BrVoza as nvarchar(15)) + ' '  + Relacija) as Naziv from UvozKonacnaZaglavlje " +
             " inner join Voz on Voz.Id = UvozKonacnaZaglavlje.IdVoza order by UvozKonacnaZaglavlje.ID desc";
            var planutovaraSAD = new SqlDataAdapter(planutovara, connection);
            var planutovaraSDS = new DataSet();
            planutovaraSAD.Fill(planutovaraSDS);
            cboPlanUtovaraIz.DataSource = planutovaraSDS.Tables[0];
            cboPlanUtovaraIz.DisplayMember = "Naziv";
            cboPlanUtovaraIz.ValueMember = "ID";

            var planutovara2 = "select UvozKonacnaZaglavlje.ID,(Cast(BrVoza as nvarchar(15)) + ' '  + Relacija) as Naziv from UvozKonacnaZaglavlje " +
            " inner join Voz on Voz.Id = UvozKonacnaZaglavlje.IdVoza order by UvozKonacnaZaglavlje.ID desc";
            var planutovara2SAD = new SqlDataAdapter(planutovara2, connection);
            var planutovara2SDS = new DataSet();
            planutovara2SAD.Fill(planutovara2SDS);
            cboPlanUtovaraU.DataSource = planutovara2SDS.Tables[0];
            cboPlanUtovaraU.DisplayMember = "Naziv";
            cboPlanUtovaraU.ValueMember = "ID";
        }

        private void RefreshDataGrid1()
        {
            var select = "SELECT UvozKonacna.ID, AtaBroda, " +
"  [BrojKontejnera], DobijenNalogBrodara, TipKontenjera.Naziv,DobijeBZ,PIN,  pp1.Naziv as DirigacijaKontejneraZa, " +
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
" where UvozKonacna.IdNadredjeni = " + Convert.ToInt32(cboPlanUtovaraIz.SelectedValue) + " order by UvozKonacna.ID desc";
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
"  [BrojKontejnera], DobijenNalogBrodara, TipKontenjera.Naziv,DobijeBZ,PIN,  pp1.Naziv as DirigacijaKontejneraZa, " +
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
" where UvozKonacna.IdNadredjeni = " + Convert.ToInt32(cboPlanUtovaraU.SelectedValue) + " order by UvozKonacna.ID desc";
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


        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid2();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    InsertUvozKonacna ins = new InsertUvozKonacna();
                    ins.PrenesiIzPlanUtovaraUPlanUtovara(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboPlanUtovaraIz.SelectedValue), Convert.ToInt32(cboPlanUtovaraU.SelectedValue));
                }
            }
            RefreshDataGrid1();
            RefreshDataGrid2();
        }

        private void cboPlanUtovaraU_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
