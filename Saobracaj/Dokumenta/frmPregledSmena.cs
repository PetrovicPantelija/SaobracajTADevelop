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

using Microsoft.Reporting.WinForms;

namespace Saobracaj.Dokumenta
{
    public partial class frmPregledSmena : Form
    {
        public frmPregledSmena()
        {
            InitializeComponent();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            var select = "";
            select = "Select DelovnaMesta.DmNaziv,(RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni , " +
            " Sum(Aktivnosti.Zarada) as Zarada, Sum(Aktivnosti.Razlika) as Razlika," +
            " Sum(( CASE " +
            "  WHEN Zarada <= 21 THEN 0.5 " +
             "  WHEN Zarada > 21 THEN 1 " +
            " END)) as Smena  " +
            " from Aktivnosti   " +
            " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
            " inner join AktivnostiStavke on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
            " inner join DelovnaMesta  on Delavci.DesifDelMes = DelovnaMesta.DmSifra " +
            " where AktivnostiStavke.VrstaAktivnostiID = 43 and Convert(nvarchar(10),VremeOd,126) >  '" + dtpVremeOd.Text + "' " +
            " and Aktivnosti.PravoDnevnice = 1 And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' Group by DelovnaMesta.DmNaziv, (RTrim(DeIme) + ' ' + RTRim(DePriimek))   " +
            " union " +
            " Select DelovnaMesta.DmNaziv,(RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni , " +
            " Sum(Aktivnosti.Zarada) as Zarada, Sum(Aktivnosti.Razlika) as Razlika," +
            " Sum(( CASE   WHEN Aktivnosti.Ukupno <= 7 THEN 0.5   WHEN Aktivnosti.Ukupno > 7 THEN 1  END)) as Smena " +
            " from Aktivnosti   " +
            " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
            " inner join AktivnostiStavke on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
            " inner join DelovnaMesta  on Delavci.DesifDelMes = DelovnaMesta.DmSifra " +
            " where AktivnostiStavke.VrstaAktivnostiID = 43 and Convert(nvarchar(10),VremeOd,126) >  '" + dtpVremeOd.Text + "' " +
            " and Aktivnosti.PravoDnevnice = 0 And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' Group by DelovnaMesta.DmNaziv, (RTrim(DeIme) + ' ' + RTRim(DePriimek))   ";
          






   
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

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Radno Mesto";
            dataGridView1.Columns[0].Width = 200;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni";
            dataGridView1.Columns[1].Width = 200;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zarada";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[2].Visible = false;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Razlika";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[3].Visible = false;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Smena";
            dataGridView1.Columns[4].Width = 100;

           
        }

        private void frmPregledSmena_Load(object sender, EventArgs e)
        {
            var select2 = "  Select DelovnaMesta.DmSifra  as ID, DelovnaMesta.DmNaziv as Naziv from DelovnaMesta";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboRadnoMesto.DataSource = ds2.Tables[0];
            cboRadnoMesto.DisplayMember = "Naziv";
            cboRadnoMesto.ValueMember = "ID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var select = "";
            select = "Select DelovnaMesta.DmNaziv,(RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni , " +
            " Sum(Aktivnosti.Zarada) as Zarada, Sum(Aktivnosti.Razlika) as Razlika," +
            " Sum(( CASE " +
            "  WHEN Zarada <= 21 THEN 0.5 " +
             "  WHEN Zarada > 21 THEN 1 " +
            " END)) as Smena  " +
            " from Aktivnosti   " +
            " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
            " inner join AktivnostiStavke on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
            " inner join DelovnaMesta  on Delavci.DesifDelMes = DelovnaMesta.DmSifra " +
            " where AktivnostiStavke.VrstaAktivnostiID = 43 and Convert(nvarchar(10),VremeOd,126) >  '" + dtpVremeOd.Text + "' " +
            " and DelovnaMesta.DmSifra = " + +Convert.ToInt32(cboRadnoMesto.SelectedValue) + " and Aktivnosti.PravoDnevnice = 1 And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' Group by DelovnaMesta.DmNaziv, (RTrim(DeIme) + ' ' + RTRim(DePriimek))   " +
            " union " +
            " Select DelovnaMesta.DmNaziv,(RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni , " +
            " Sum(Aktivnosti.Zarada) as Zarada, Sum(Aktivnosti.Razlika) as Razlika," +
            " Sum(( CASE   WHEN Aktivnosti.Ukupno <= 7 THEN 0.5   WHEN Aktivnosti.Ukupno > 7 THEN 1  END)) as Smena " +
            " from Aktivnosti   " +
            " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni " +
            " inner join AktivnostiStavke on Aktivnosti.ID = AktivnostiStavke.IDNadredjena " +
            " inner join DelovnaMesta  on Delavci.DesifDelMes = DelovnaMesta.DmSifra " +
            " where AktivnostiStavke.VrstaAktivnostiID = 43 and Convert(nvarchar(10),VremeOd,126) >  '" + dtpVremeOd.Text + "' " +
            " and DelovnaMesta.DmSifra = " + +Convert.ToInt32(cboRadnoMesto.SelectedValue) + " and Aktivnosti.PravoDnevnice = 0 And  Convert(nvarchar(10),VremeDo,126) <  '" + dtpVremeDo.Text + "' Group by DelovnaMesta.DmNaziv, (RTrim(DeIme) + ' ' + RTRim(DePriimek))   ";


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

            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Radno Mesto";
            dataGridView1.Columns[0].Width = 200;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni";
            dataGridView1.Columns[1].Width = 200;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zarada";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[2].Visible = false;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Razlika";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[3].Visible = false;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Smena";
            dataGridView1.Columns[4].Width = 100;
        }
    }
}
