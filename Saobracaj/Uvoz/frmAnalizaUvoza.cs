using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Data;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;

namespace Saobracaj.Uvoz
{
    public partial class frmAnalizaUvoza : Form
    {
        public frmAnalizaUvoza()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzcwMDg5QDMxMzgyZTM0MmUzMFhQSmlDM0M2bGpxcXVtT1VScTg1a0dtVTFLcUZiK0tLRnpvRTYyRFpMc3M9");

            InitializeComponent();
           
        }

        private void frmAnalizaUvoza_Load(object sender, EventArgs e)
        {
            var select =  "SELECT Uvoz.ID, AtaBroda, " +
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
            gridGroupingControl1.DataSource = ds.Tables[0];
            gridGroupingControl1.ShowGroupDropArea = true;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = true;
            foreach (GridColumnDescriptor column in this.gridGroupingControl1.TableDescriptor.Columns)
            {
                column.AllowFilter = true;
            }
          /*
            GridSummaryColumnDescriptor summaryColumnDescriptor = new GridSummaryColumnDescriptor();
            summaryColumnDescriptor.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
            summaryColumnDescriptor.DataMember = "Ukupno";
            summaryColumnDescriptor.Format = "{Sum}";
            summaryColumnDescriptor.Name = "Potrošeno";
            summaryColumnDescriptor.SummaryType = Syncfusion.Grouping.SummaryType.Int32Aggregate;

            GridSummaryRowDescriptor summaryRowDescriptor = new GridSummaryRowDescriptor();
            summaryRowDescriptor.SummaryColumns.Add(summaryColumnDescriptor);
            summaryRowDescriptor.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(255, 231, 162));

            this.gridGroupingControl1.TableDescriptor.SummaryRows.Add(summaryRowDescriptor);
          */
        }
    }
}
