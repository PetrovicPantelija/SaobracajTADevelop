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
    public partial class frmPregledAutoPrevozniList : Form
    {
        public frmPregledAutoPrevozniList()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string KorisnikCene = " ";
            frmAutoprevozniList2 nal = new frmAutoprevozniList2(Convert.ToInt32(txtSifra.Text), KorisnikCene);
            nal.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var select = " SELECT [ID] " +
     " ,[IDPutniNalog]       ,[IDNalogZaPrevoz] " +
     " ,[IDRadniNalog]       ,[Platilac] " +
     " ,[Kontakt]       ,[Vozilo] " +
     " ,[Dana]      ,[UtovarnoMesto] " +
     " ,[IstovarnoMesto]       ,[Primalac] " +
     " ,[Ugovor]       ,[Ponuda] " +
     " ,[MestoIzdavanja]       ,[Datum] " +
    " FROM [dbo].[Autoprevoznilist]" +
      " order by Autoprevoznilist.ID desc";
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

        private void frmPregledAutoPrevozniList_Load(object sender, EventArgs e)
        {

        }
    }
}
