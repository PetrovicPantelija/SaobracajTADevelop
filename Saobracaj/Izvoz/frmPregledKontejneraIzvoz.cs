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

namespace Saobracaj.Izvoz
{
    public partial class frmPregledKontejneraIzvoz : Form
    {
        public frmPregledKontejneraIzvoz()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            var select = " SELECT  Izvoz.ID as ID,    Izvoz.VrstaKontejnera, TipKontenjera.Naziv, Izvoz.BrojVagona, Izvoz.BrojKontejnera, Izvoz.BrodskaPlomba, Izvoz.OstalePlombe, Izvoz.BookingBrodara, Partnerji.PaNaziv, " +
                  "    Izvoz.CutOffPort, Izvoz.NetoRobe, Izvoz.BrutoRobe, Izvoz.BrutoRobeO, Izvoz.BrojKoleta, Izvoz.BrojKoletaO, Izvoz.CBM, Izvoz.CBMO, Izvoz.VrednostRobeFaktura, " +
                   "  (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaManipulacije.Naziv as nvarchar(20))   FROM IzvozVrstaManipulacije " +
   "       inner join VrstaManipulacije on VrstaManipulacije.ID = IzvozVrstaManipulacije.IDVrstaManipulacije   where IzvozVrstaManipulacije.IDNadredjena = Izvoz.ID " +
   "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as VrsteUsluga,   " +
   "     (SELECT  STUFF((SELECT distinct    '/' + Cast(VrstaRobeHS.HSKod as nvarchar(20))   FROM IzvozVrstaRobeHS " +
   "       inner join VrstaRobeHS on IzvozVrstaRobeHS.IDVrstaRobeHS = VrstaRobeHS.ID   where IzvozVrstaRobeHS.IDNadredjena = Izvoz.ID " +
   "        FOR XML PATH('')), 1, 1, ''   ) As Skupljen) as HS,   " +
   "    (SELECT  STUFF((SELECT distinct    '/' + Cast(NHM.Broj as nvarchar(20)) " +
  "            FROM IzvozNHM  inner join NHM on IzvozNHM.IDNHM = NHM.ID  where IzvozNHM.IDNadredjena = Izvoz.ID   FOR XML PATH('')), 1, 1, ''  ) As Skupljen) as NHM, " +
                  "        Izvoz.Valuta, KrajnjaDestinacija.Naziv AS KrajnjaDestinacija, VrstePostupakaUvoz.Naziv AS Postupak, KontejnerskiTerminali.Naziv AS PPCNT, " +
                  "        KontejnerskiTerminali.Oznaka, Izvoz.Cirada, Izvoz.PlaniraniDatumUtovara, MestaUtovara.Naziv AS MestoUtovara, Izvoz.KontaktOsoba,  " +
                  "        Carinarnice.Naziv AS Carinarnica, Carinarnice.CIOznaka, Partnerji_1.PaNaziv AS Spedicija, AdresaStatusVozila.Naziv AS AdresaStatusVozila, " +
                  "        NaslovStatusaVozila.Naziv AS NaslovStatusaVozila, Izvoz.EtaLeget, VrstaCarinskogPostupka.Naziv AS Reexport, InspekciskiTretman.Naziv AS InspekciskiTretman, " +
                  "        Izvoz.AutoDana, Izvoz.NajavaVozila, Izvoz.DodatneNapomeneDrumski, Izvoz.Vaganje, Izvoz.VGMTezina, Izvoz.Tara, Izvoz.VGMBrod, " +
                  "        Partnerji_2.PaNaziv AS Izvoznik, Partnerji_3.PaNaziv AS Klijent1, Izvoz.Napomena1REf, Izvoz.DobijenNalogKlijent1, Partnerji_4.PaNaziv AS klijent2, " +
                  "        Izvoz.Napomena2REf, Partnerji_5.PaNaziv AS Klijent3, Izvoz.Napomena3REf, Partnerji_6.PaNaziv AS SpediterRijeka, uvNacinPakovanja.Naziv AS NacinPakovanja, " +
                  "        Izvoz.NacinPretovara " +
"    FROM         Izvoz INNER JOIN " +
                   "       TipKontenjera ON Izvoz.VrstaKontejnera = TipKontenjera.ID INNER JOIN " +
                  "        Partnerji ON Izvoz.Brodar = Partnerji.PaSifra INNER JOIN " +
                  "        KrajnjaDestinacija ON Izvoz.KrajnaDestinacija = KrajnjaDestinacija.ID INNER JOIN " +
                  "        VrstePostupakaUvoz ON Izvoz.Postupanje = VrstePostupakaUvoz.ID INNER JOIN " +
                  "        KontejnerskiTerminali ON Izvoz.MestoPreuzimanja = KontejnerskiTerminali.id INNER JOIN " +
                  "        MestaUtovara ON Izvoz.MesoUtovara = MestaUtovara.ID INNER JOIN " +
                  "        Carinarnice ON Izvoz.MestoCarinjenja = Carinarnice.ID INNER JOIN " +
                   "       Partnerji AS Partnerji_1 ON Izvoz.Spedicija = Partnerji_1.PaSifra INNER JOIN " +
                   "       AdresaStatusVozila ON Izvoz.AdresaSlanjaStatusa = AdresaStatusVozila.ID INNER JOIN " +
                   "       NaslovStatusaVozila ON Izvoz.NaslovSlanjaStatusa = NaslovStatusaVozila.ID INNER JOIN " +
                  "        VrstaCarinskogPostupka ON Izvoz.NapomenaReexport = VrstaCarinskogPostupka.id INNER JOIN " +
                   "       InspekciskiTretman ON Izvoz.Inspekcija = InspekciskiTretman.ID INNER JOIN " +
                   "       Partnerji AS Partnerji_2 ON Izvoz.Izvoznik = Partnerji_2.PaSifra INNER JOIN " +
                   "       Partnerji AS Partnerji_3 ON Izvoz.Klijent1 = Partnerji_3.PaSifra INNER JOIN " +
                    "      Partnerji AS Partnerji_4 ON Izvoz.Klijent2 = Partnerji_4.PaSifra INNER JOIN " +
                  "        Partnerji AS Partnerji_5 ON Izvoz.Klijent3 = Partnerji_5.PaSifra INNER JOIN " +
                 "         Partnerji AS Partnerji_6 ON Izvoz.SpediterRijeka = Partnerji_6.PaSifra INNER JOIN " +
                  "        uvNacinPakovanja ON Izvoz.NacinPakovanja = uvNacinPakovanja.ID order by Izvoz.ID desc ";


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

        private void frmPregledKontejneraIzvoz_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Izvoz.frmIzvoz fIzvoz = new frmIzvoz();
            fIzvoz.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmIzvoz frmUIzvoz = new frmIzvoz(Convert.ToInt32(txtSifra.Text));
            frmUIzvoz.Show();
        }
    }
}
