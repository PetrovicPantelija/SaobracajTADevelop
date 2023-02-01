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
    public partial class frmPregledPutnihNaloga : Form
    {
        public frmPregledPutnihNaloga()
        {
            InitializeComponent();
        }

        private void frmPregledPutnihNaloga_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string KorisnikCene = " ";
            frmPutniNalog nal = new frmPutniNalog(Convert.ToInt32(txtSifra.Text), KorisnikCene);
            nal.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var select = "SELECT PutniNalog.[ID] " +
     " ,[IDNalogZaPrevoz],[MestoIzdavanja]      ,[DatumPrevoza],[UtovarnoMesto] " +
    "  ,[IstovarnoMesto] ,[Vozilo]      ,[PrikljucnaVozila],PutniNalog.[Napomena] " +
    "  ,[Dispecer],[Vozac]      ,[TehnickuIspravnost] ,PutniNalog.[Datum] " +
     " ,PutniNalog.[Korisnik],[PrikljucnoVoziloID]      ,[Marka1],[Tip1] " +
     " ,[Tezina1] ,[Marka2]      ,[Tip2],[Tezina2] " +
     " ,[RelacijaOd],[RelacijaDo]  FROM [dbo].[PutniNalog] " +
      " inner join Vozila v on v.ID = Vozilo " +
         " inner join Vozila p on p.Id = PrikljucnoVoziloID " +
         " inner join Zaposleni z on z.ID = Dispecer" +
         " order by ID desc";
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
