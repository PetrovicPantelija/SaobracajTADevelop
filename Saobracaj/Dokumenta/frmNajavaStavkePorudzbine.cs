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
using System.Net;
using System.Net.Mail;

using Microsoft.Reporting.WinForms;

namespace Saobracaj.Dokumenta
{
    public partial class frmNajavaStavkePorudzbine : Form
    {
        int SifraPartnera = 0;
        
        public frmNajavaStavkePorudzbine()
        {
            InitializeComponent();
        }

        public frmNajavaStavkePorudzbine(int Partner)
        {
            InitializeComponent();
            SifraPartnera = Partner;
        }


        private void RefreshDataGrid()
        {
            var select = "  select NarociloPostav.NaPNarZap AS ID, NaPartPlac as Partner, " +
                "NaDatNar as DatumNarudzbine, NaPNaziv as Naziv, NaPEM As JM, NaPem2 as JM2," +
                " NaPKolNar as Kolicina, NaPKolNar2 as KolicinaJM2, NaPOpomba as NHM, " +
                "NaPNote as Napomena   from Narocilo inner join NarociloPostav " +
" on Narocilo.NaStNar = NarociloPostav.NaPStNar " +
" where NaStatus = 'PO' and NaPartPlac = " + SifraPartnera;
           

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
            dataGridView1.Columns[0].Width = 70;

           

        }

        private void frmNajavaStavkePorudzbine_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
           
        }
    }
}
