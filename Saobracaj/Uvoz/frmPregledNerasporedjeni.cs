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

namespace Saobracaj.Uvoz
{
    public partial class frmPregledNerasporedjeni : Form
    {
        public frmPregledNerasporedjeni()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            var select = "SELECT Uvoz.ID, AtaBroda, " +
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
   "   FROM UvozVrstaRobeHS" +
   "   inner join VrstaRobeHS on UvozVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID" +
  "   where UvozVrstaRobeHS.IDNadredjena = Uvoz.ID" +
   "   FOR XML PATH('')" +
   "    ), 1, 1, '' " +
   "  ) As Skupljen) as VrsteRobe, " +
   "  (" +
   "  SELECT" +
   "  STUFF(" +
   "   (" +
   "   SELECT distinct" +
   "    '/' + Cast(NHM.Broj as nvarchar(20))" +
   "   FROM UvozNHM" +
    "  inner join NHM on UvozNHM.IDNHM = NHM.ID" +
   "  where UvozNHM.IDNadredjena = Uvoz.ID" +
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
  "       FROM Uvoz" +
  "       inner join Partnerji on PaSifra = VlasnikKontejnera" +
  "      inner join Partnerji p1 on p1.PaSifra = Uvoznik" +
  "        inner join Partnerji p2 on p2.PaSifra = SpedicijaRTC" +
   "        inner join Partnerji p3 on p3.PaSifra = SpedicijaGranica" +
  "     inner join VrstaRobeHS on VrstaRobeHS.ID = Uvoz.NazivRobe" +
  "     inner join NHM on NHM.ID = NHMBroj" +
  "    inner join TipKontenjera on TipKontenjera.ID = Uvoz.TipKontejnera" +
  "    inner join Carinarnice on Carinarnice.ID = Uvoz.OdredisnaCarina" +
  "     inner join VrstaCarinskogPostupka on VrstaCarinskogPostupka.ID = Uvoz.CarinskiPostupak" +
  "     inner join Predefinisaneporuke on PredefinisanePoruke.ID = Uvoz.NapomenaZaPozicioniranje" +
  "    inner join PredefinisanePoruke pp1 on pp1.ID = DirigacijaKontejeraZa" +
  "     inner join Brodovi on Brodovi.ID = Uvoz.NazivBroda" +
  "    inner join VrstaRobeADR on VrstaRobeADR.ID = ADR" +
  "    inner join VrstePostupakaUvoz on VrstePostupakaUvoz.ID = PostupakSaRobom" +
  "    inner join uvNacinPakovanja on uvNacinPakovanja.ID = NacinPakovanja" +
  "  inner join Partnerji p4 on p4.PaSifra = OdredisnaSpedicija  order by Uvoz.ID desc";
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
/*
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Br voza";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Relacija";
            dataGridView1.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Vr polaska";
            dataGridView1.Columns[3].Width = 70;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vr dolaska";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Max bruto";
            dataGridView1.Columns[5].Width = 70;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Max duž";
            dataGridView1.Columns[6].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Max br kola";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Napomena";
            dataGridView1.Columns[8].Width = 100;
*/

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

                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void frmPregledNerasporedjeni_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Uvoz fUvoz = new Uvoz();
            fUvoz.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Uvoz pUvoz = new Uvoz(Convert.ToInt32(txtSifra.Text));
            pUvoz.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
