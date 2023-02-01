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
    public partial class frmVrsteAktivnosti : Form
    {
        bool status = false;
        public frmVrsteAktivnosti()
        {
            InitializeComponent();
        }

       

        private void RefreshDataGrid()
        {
            //
          //    ,PotrebanRazlog = @PotrebanRazlog
		  // ,PotrebanNalogodavac = @PotrebanNalogodavac
           //,PotrebnoVozilo = @PotrebnoVozilo
           //,ObaveznaNapomena = @ObaveznaNapomena
            //
            var select = " Select ID, Naziv, " +
            " CASE WHEN ObracunPoSatu > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as obracunPoSatu, " +
            " CASE WHEN PotrebanRazlog > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PotrebanRazlog, " +
            " CASE WHEN PotrebanNalogodavac> 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PotrebanNalogodavac, " +
            " CASE WHEN PotrebnoVozilo> 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as PotrebnoVozilo, " +
            " CASE WHEN ObaveznaNapomena> 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as ObaveznaNapomena, " +
            " Cena, Opis , " +
            " CASE WHEN Smederevo> 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Smederevo, " +
            " CASE WHEN Kragujevac> 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Kragujevac, " +
            " CASE WHEN CG> 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as CG, " +
            " CASE WHEN Remont> 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Remont, " +
             " CASE WHEN Milsped> 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Milsped, " +
              " CASE WHEN Dnevnica> 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as UlaziUDnevnicu, MaxSati, MaxVagona " +
            " from VrstaAktivnosti";
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

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Naziv";
            dataGridView1.Columns[1].Width = 350;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Obračun po satu";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Potreban razlog";
            dataGridView1.Columns[3].Width = 50;

             DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Potreban nalogodavac";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Potrebno vozilo";
            dataGridView1.Columns[5].Width = 50;

		     DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Obavezna napomena";
            dataGridView1.Columns[6].Width = 50;

           

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Cena";
            dataGridView1.Columns[7].Width = 50;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Opis";
            dataGridView1.Columns[8].Width = 500;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Smederevo";
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Kragujevac";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "CG";
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[11].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Remont";
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[12].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Milsped";
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Dnevnica";
            dataGridView1.Columns[14].Width = 50;


            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "MaxSATI";
            dataGridView1.Columns[15].Width = 50;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "MaxVagona";
            dataGridView1.Columns[16].Width = 50;
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            txtCena.Value = 0;
            txtNaziv.Text = "";

            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int chekiran = 0;
            int chekiranPotrebanRazlog = 0;
            int chekiranPotrebanNalogodavac = 0;
            int chekiranPotrebnoVozilo = 0;
            int chekiranObaveznaNapomena = 0;
            int chekiranSmederevo = 0;
            int chekiranKragujevac = 0;
            int chekiranCG = 0;
            int chekiranRemont = 0;
            int chekiranMilsped = 0;
            int chekiranUlaziUDnevnicu = 0;
            if (status == true)
            {
                if (chkObracunPoSatu.Checked == true)
                {
                    chekiran = 1;
                }
                else
                {
                    chekiran = 0;
                }
                if (chkPotrebanRazlog.Checked == true)
                {
                    chekiranPotrebanRazlog = 1;
                }
                else
                {
                    chekiranPotrebanRazlog = 0;
                }
                if (chkPotrebanNalogodavac.Checked == true)
                {
                    chekiranPotrebanNalogodavac = 1;
                }
                else
                {
                    chekiranPotrebanNalogodavac = 0;
                }
                if (chkPotrebnoVozilo.Checked == true)
                {
                    chekiranPotrebnoVozilo = 1;
                }
                else
                {
                    chekiranPotrebnoVozilo = 0;
                }
                if (chkObaveznaNapomena.Checked == true)
                {
                    chekiranObaveznaNapomena = 1;
                }
                else
                {
                    chekiranObaveznaNapomena = 0;
                }
                
                if (chkSmederevo.Checked == true)
                {
                    chekiranSmederevo = 1;
                }
                else
                {
                    chekiranSmederevo = 0;
                }

                if (chkKragujevac.Checked == true)
                {
                    chekiranKragujevac = 1;
                }
                else
                {
                    chekiranKragujevac = 0;
                }
                if (chkCG.Checked == true)
                {
                    chekiranCG = 1;
                }
                else
                {
                    chekiranCG = 0;
                }
                if (chkRemont.Checked == true)
                {
                    chekiranRemont = 1;
                }
                else
                {
                    chekiranRemont = 0;
                }
                if (chkMilsped.Checked == true)
                {
                    chekiranMilsped = 1;
                }
                else
                {
                    chekiranMilsped = 0;
                }

              
                if (chkUlaziUDnevnicu.Checked == true)
                {
                    chekiranUlaziUDnevnicu = 1;
                }
                else
                {
                    chekiranUlaziUDnevnicu = 0;
                }


                InsertVrstaAktivnosti ins = new InsertVrstaAktivnosti();

                ins.InsVrstaAktivnosti(txtNaziv.Text, Convert.ToDouble(txtCena.Text), txtOpis.Text, chekiran, chekiranPotrebanRazlog, chekiranPotrebanNalogodavac, chekiranPotrebnoVozilo, chekiranObaveznaNapomena, Convert.ToDouble(txtFiksniDeo.Text), chekiranSmederevo, chekiranKragujevac, chekiranCG, chekiranRemont, chekiranMilsped, chekiranUlaziUDnevnicu, Convert.ToDouble(txtVremeVagon.Text), Convert.ToDouble(txtMaxSati.Value), Convert.ToDouble(txtMaxVagona.Value));
                RefreshDataGrid();
                status = false;
            }
            else
            {
                if (chkObracunPoSatu.Checked == true)
                {
                    chekiran = 1;
                }
                else
                {
                    chekiran = 0;
                }
                if (chkPotrebanRazlog.Checked == true)
                {
                    chekiranPotrebanRazlog = 1;
                }
                else
                {
                    chekiranPotrebanRazlog = 0;
                }
                if (chkPotrebanNalogodavac.Checked == true)
                {
                    chekiranPotrebanNalogodavac = 1;
                }
                else
                {
                    chekiranPotrebanNalogodavac = 0;
                }
                if (chkPotrebnoVozilo.Checked == true)
                {
                    chekiranPotrebnoVozilo = 1;
                }
                else
                {
                    chekiranPotrebnoVozilo = 0;
                }
                if (chkObaveznaNapomena.Checked == true)
                {
                    chekiranObaveznaNapomena = 1;
                }
                else
                {
                    chekiranObaveznaNapomena = 0;
                }
                if (chkSmederevo.Checked == true)
                {
                    chekiranSmederevo = 1;
                }
                else
                {
                    chekiranSmederevo = 0;
                }
                  if (chkKragujevac.Checked == true)
                {
                    chekiranKragujevac = 1;
                }
                else
                {
                    chekiranKragujevac = 0;
                }
                  if (chkCG.Checked == true)
                {
                    chekiranCG = 1;
                }
                else
                {
                    chekiranCG = 0;
                }
                if (chkRemont.Checked == true)
                {
                    chekiranRemont = 1;
                }
                else
                {
                    chekiranRemont = 0;
                }
                if (chkMilsped.Checked == true)
                {
                    chekiranMilsped = 1;
                }
                else
                {
                    chekiranMilsped = 0;
                }
                if (chkUlaziUDnevnicu.Checked == true)
                {
                    chekiranUlaziUDnevnicu = 1;
                }
                else
                {
                    chekiranUlaziUDnevnicu = 0;
                }

                InsertVrstaAktivnosti upd = new InsertVrstaAktivnosti();
                upd.UpdVrstaAktivnosti(Convert.ToInt32(txtSifra.Text), txtNaziv.Text, Convert.ToDouble(txtCena.Text), txtOpis.Text, chekiran, chekiranPotrebanRazlog, chekiranPotrebanNalogodavac, chekiranPotrebnoVozilo, chekiranObaveznaNapomena, Convert.ToDouble(txtFiksniDeo.Text), chekiranSmederevo, chekiranKragujevac, chekiranCG, chekiranRemont, chekiranMilsped, chekiranUlaziUDnevnicu, Convert.ToDouble(txtVremeVagon.Text),  Convert.ToDouble(txtMaxSati.Value), Convert.ToDouble(txtMaxVagona.Value));
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid();
            }
        }

        private void frmVrsteAktivnosti_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
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
                        txtNaziv.Text = row.Cells[1].Value.ToString();
                      
                        chkObracunPoSatu.Checked = Convert.ToBoolean(row.Cells[2].Value.ToString());
                        chkPotrebanRazlog.Checked = Convert.ToBoolean(row.Cells[3].Value.ToString());
                        chkPotrebanNalogodavac.Checked = Convert.ToBoolean(row.Cells[4].Value.ToString());
                        chkPotrebnoVozilo.Checked = Convert.ToBoolean(row.Cells[5].Value.ToString());
                        chkObaveznaNapomena.Checked = Convert.ToBoolean(row.Cells[6].Value.ToString());
                        chkSmederevo.Checked = Convert.ToBoolean(row.Cells[9].Value.ToString());
                        chkKragujevac.Checked = Convert.ToBoolean(row.Cells[10].Value.ToString());
                        chkCG.Checked = Convert.ToBoolean(row.Cells[11].Value.ToString());
                        chkRemont.Checked = Convert.ToBoolean(row.Cells[12].Value.ToString());
                        txtCena.Value = Convert.ToDecimal(row.Cells[7].Value.ToString());
                        txtOpis.Text = row.Cells[8].Value.ToString();
                        chkMilsped.Checked = Convert.ToBoolean(row.Cells[13].Value.ToString());


                        txtMaxSati.Value = Convert.ToDecimal(row.Cells[15].Value.ToString());
                        txtMaxVagona.Value = Convert.ToDecimal(row.Cells[16].Value.ToString());


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
