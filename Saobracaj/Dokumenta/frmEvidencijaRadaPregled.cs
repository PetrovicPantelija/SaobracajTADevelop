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
    public partial class frmEvidencijaRadaPregled : Form
    {
        public frmEvidencijaRadaPregled()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid1()
        {
            var select = "Select Aktivnosti.ID as ZapisNadredjeni, AktivnostiStavke.ID as Stavke, Aktivnosti.Oznaka, " +
                           " VrstaAktivnosti.Naziv, (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                           " AktivnostiStavke.BrojVagona, AktivnostiStavke.Sati, AktivnostiStavke.Napomena,  " +
                           " AktivnostiStavke.Razlog, AktivnostiStavke.Vozilo, AktivnostiStavke.Nalogodavac,   " +
                           "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN  " +
                           " from Aktivnosti  " +
                           " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                           " inner join AktivnostiStavke on Aktivnosti.ID = AktivnostiStavke.IDNadredjena  " +
                           "inner join VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID  " +
                           " order by Aktivnosti.ID desc";
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "ID stavka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Oznaka";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Aktivnost";
            dataGridView1.Columns[3].Width = 170;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Zaposleni";
            dataGridView1.Columns[4].Width = 170;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vagoni";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Sati";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Napomena";
            dataGridView1.Columns[7].Width = 150;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Razlog";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Vozilo";
            dataGridView1.Columns[9].Width = 150;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Nalogodavac";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Vreme od";
            dataGridView1.Columns[11].Width = 150;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Vreme do";
            dataGridView1.Columns[12].Width = 150;

            DataGridViewColumn column13 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Ukupno";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Ukupno troškovi";
            dataGridView1.Columns[14].Width = 50;


        }


        private void frmEvidencijaRadaPregled_Load(object sender, EventArgs e)
        {

            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci order by opis";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboZaposleni.DataSource = ds3.Tables[0];
            cboZaposleni.DisplayMember = "Opis";
            cboZaposleni.ValueMember = "ID";

            RefreshDataGrid1();

          
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            var select = "Select Aktivnosti.ID as ZapisNadredjeni, AktivnostiStavke.ID as Stavke,  " +
                           " VrstaAktivnosti.Naziv, (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                           " AktivnostiStavke.BrojVagona, AktivnostiStavke.Sati, AktivnostiStavke.Napomena,  " +
                           " AktivnostiStavke.Razlog, AktivnostiStavke.Vozilo, AktivnostiStavke.Nalogodavac,   " +
                           "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN  " +
                           " from Aktivnosti  " +
                           " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                           " inner join AktivnostiStavke on Aktivnosti.ID = AktivnostiStavke.IDNadredjena  " +
                           "inner join VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID " + 
                           "  where Zaposleni = " + Convert.ToInt32(cboZaposleni.SelectedValue) +
                           " order by Aktivnosti.ID desc";
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "ID stavka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Aktivnost";
            dataGridView1.Columns[2].Width = 170;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Zaposleni";
            dataGridView1.Columns[3].Width = 170;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vagoni";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Sati";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Napomena";
            dataGridView1.Columns[6].Width = 150;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Razlog";
            dataGridView1.Columns[7].Width = 150;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Vozilo";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Nalogodavac";
            dataGridView1.Columns[9].Width = 50;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Vreme od";
            dataGridView1.Columns[10].Width = 150;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Vreme do";
            dataGridView1.Columns[11].Width = 150;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Ukupno";
            dataGridView1.Columns[12].Width = 50;

            DataGridViewColumn column13 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Ukupno troškovi";
            dataGridView1.Columns[13].Width = 50;
           
                 
                        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                InsertAktivnostiStavke ins = new InsertAktivnostiStavke();

                if (row.Selected == true)
                {
                    ins.DeleteAktivnostiStavke(Convert.ToInt32(row.Cells[1].Value.ToString()));
                }

               
                // ins.UpdateOstaleStavke(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(row.Cells[1].Value.ToString()), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), Convert.ToDouble(row.Cells[7].Value.ToString()), Convert.ToDouble(row.Cells[8].Value.ToString()), Convert.ToDouble(row.Cells[9].Value.ToString()), Convert.ToDouble(row.Cells[10].Value.ToString()), Convert.ToDouble(row.Cells[11].Value.ToString()), Convert.ToDouble(row.Cells[12].Value.ToString()), Convert.ToDouble(row.Cells[13].Value.ToString()), Convert.ToDouble(row.Cells[14].Value.ToString()), row.Cells[15].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), Convert.ToDouble(row.Cells[20].Value.ToString()), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString());
            }
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            var select = "Select Aktivnosti.ID as ZapisNadredjeni, AktivnostiStavke.ID as Stavke, Aktivnosti.Oznaka, " +
                          " VrstaAktivnosti.Naziv, (RTrim(DeIme) + ' ' + RTRim(DePriimek)) as Zaposleni,  " +
                          " AktivnostiStavke.BrojVagona, AktivnostiStavke.Sati, AktivnostiStavke.Napomena,  " +
                          " AktivnostiStavke.Razlog, AktivnostiStavke.Vozilo, AktivnostiStavke.Nalogodavac,   " +
                          "  VremeOD, VremeDo, Ukupno, UkupniTroskovi, Aktivnosti.Opis, RN  " +
                          " from Aktivnosti  " +
                          " inner join Delavci on Delavci.DeSifra = Aktivnosti.Zaposleni  " +
                          " inner join AktivnostiStavke on Aktivnosti.ID = AktivnostiStavke.IDNadredjena  " +
                          "inner join VrstaAktivnosti on AktivnostiStavke.VrstaAktivnostiID = VrstaAktivnosti.ID  " +
                          " order by Aktivnosti.ID desc";
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 30;

            DataGridViewColumn column1 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "ID stavka";
            dataGridView1.Columns[1].Width = 30;

            DataGridViewColumn column2 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Oznaka";
            dataGridView1.Columns[2].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Aktivnost";
            dataGridView1.Columns[3].Width = 170;

            DataGridViewColumn column4 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Zaposleni";
            dataGridView1.Columns[4].Width = 170;

            DataGridViewColumn column5 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Vagoni";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Sati";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Napomena";
            dataGridView1.Columns[7].Width = 150;

            DataGridViewColumn column8 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Razlog";
            dataGridView1.Columns[8].Width = 150;

            DataGridViewColumn column9 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Vozilo";
            dataGridView1.Columns[9].Width = 150;

            DataGridViewColumn column10 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Nalogodavac";
            dataGridView1.Columns[10].Width = 50;

            DataGridViewColumn column11 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Vreme od";
            dataGridView1.Columns[11].Width = 150;

            DataGridViewColumn column12 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Vreme do";
            dataGridView1.Columns[12].Width = 150;

            DataGridViewColumn column13 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Ukupno";
            dataGridView1.Columns[13].Width = 50;

            DataGridViewColumn column14 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "Ukupno troškovi";
            dataGridView1.Columns[14].Width = 50;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
