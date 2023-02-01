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

namespace TrackModal.Dokumeta
{
    public partial class frmPregledRadniNaloziTransport : Form
    {
        public frmPregledRadniNaloziTransport()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string KorisnikCene = " ";
            frmRadniNalogTransport nal = new frmRadniNalogTransport(Convert.ToInt32(txtSifra.Text), KorisnikCene);
            nal.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var select = " SELECT RadniNalogTransport.[ID]" +
      " ,[IDPutniNalog]       ,[IDNalogZaPrevoz] " +
      " ,[IDAutoprevoznilist]      ,[IDVozilo] " +
      " ,[Dana]      ,[TransportniDispecer] " +
      " ,[DatumPrevoza]      ,[MestoIzdavanja] " +
      " ,RadniNalogTransport.[Datum]      ,RadniNalogTransport.[Korisnik] " +
      " ,[PrikljucnoVoziloID]      ,[RelacijaOd] " +
      " ,[RelacijaDo]      ,[BrojOtpravljanja] " +
      " ,[BrojVagona]      ,[NetoMasa] " +
      " ,[DatumIstovara]  FROM [dbo].[RadniNalogTransport] " +
     " inner join Vozila v on v.ID = IDVozilo " +
        " inner join Vozila p on p.Id = PrikljucnoVoziloID " +
        " inner join Zaposleni z on z.ID = TransportniDispecer" +
        " order by RadniNalogTransport.ID desc";
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
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
    }
}
