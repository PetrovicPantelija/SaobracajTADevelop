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
    public partial class frmTrasaStanice : Form
    {
        bool status = true;
        int PrviUlazak = 0;
        public frmTrasaStanice()
        {
            InitializeComponent();
        }

        public frmTrasaStanice(string SifraTrase, string OznakaTrase)
        {
            InitializeComponent();
            txtSifra.Text = SifraTrase;
            txtVoz.Text = OznakaTrase;
            //
            RefreshDataGrid();

        }
        //txtSifra.Text, txtVoz.Text

        private void btnUbaci_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
               /*
                InsertTrasaStanice ins = new InsertTrasaStanice();
                ins.InsTStan(Convert.ToInt32((cboPruga.SelectedValue)), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cmbPocetna.SelectedValue), Convert.ToInt32(cboKrajnja.SelectedValue));
                RefreshDataGrid();
               */
                //status = false;
            }
            else
            {
                /*
                Insertnhm upd = new Insertnhm();
                upd.UpdStanice(Convert.ToInt32(txtSifra.Text), txtBroj.Text, txtNaziv.Text);
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid();
                 * */
            }
        }

        private void RefreshDataGrid()
        {

            //SELECT     TrasaStanice.IDTrase, TrasaStanice.RB, stanice.Opis, stanice.Kod FROM TrasaStanice INNER JOIN  PrugaStavke ON TrasaStanice.IDStanice = PrugaStavke.ID INNER JOIN stanice ON PrugaStavke.StanicaOd = stanice.ID
            //  var select = " SELECT     TrasaStanice.IDTrase, TrasaStanice.RB, stanice.Opis, stanice.Kod FROM TrasaStanice INNER JOIN  PrugaStavke ON TrasaStanice.IDStanice = PrugaStavke.ID INNER JOIN stanice ON PrugaStavke.StanicaOd = stanice.ID where IdTrase = " + txtSifra.Text;
            var select = " SELECT     TrasaStanice.ID, TrasaStanice.IDPruge, TrasaStanice.IDTrase, Trase.Voz ,TrasaStanice.StanicaOd, TrasaStanice.StanicaDo, Pruga.Oznaka + '  ' + Pruga.Opis AS Pruga, " +
                      " stanice.Opis AS StanicaOd, stanice_1.Opis AS StanicaDo " +
                      " FROM         TrasaStanice INNER JOIN " +
                      " Pruga ON TrasaStanice.ID = Pruga.ID INNER JOIN " +
                      " stanice ON TrasaStanice.StanicaOD = stanice.ID INNER JOIN " +
                      " stanice AS stanice_1 ON TrasaStanice.StanicaDo = stanice_1.ID " +
                      " inner join Trase on Trase.ID = TrasaStanice.IDTrase  where IdTrase = " + txtSifra.Text;
         



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
            dataGridView1.Columns[0].HeaderText = "ID ";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "ID pruge";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Trasa ID";
            dataGridView1.Columns[2].Width = 40;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Trasa";
            dataGridView1.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "StanID od";
            dataGridView1.Columns[4].Width = 40;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "StanID do";
            dataGridView1.Columns[5].Width = 40;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Pruga";
            dataGridView1.Columns[6].Width = 240;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "StanicaOd";
            dataGridView1.Columns[7].Width = 140;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "StanicaDo";
            dataGridView1.Columns[8].Width = 140;


        }

        private void frmTrasaStanice_Load(object sender, EventArgs e)
        {
            var select = " Select Distinct ID,  (RTrim(Oznaka) + '-' + Rtrim(Opis)) as Opis From Pruga";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboPruga.DataSource = ds.Tables[0];
            cboPruga.DisplayMember = "Opis";
            cboPruga.ValueMember = "ID";


           

            var select2 = " Select Distinct ID, RTrim(Opis) as Stanica From Stanice";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboKrajnja.DataSource = ds2.Tables[0];
            cboKrajnja.DisplayMember = "Stanica";
            cboKrajnja.ValueMember = "ID";


            var select3 = " Select Distinct ID, RTrim(Opis) as Stanica From Stanice";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3= new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cmbPocetna.DataSource = ds3.Tables[0];
            cmbPocetna.DisplayMember = "Stanica";
            cmbPocetna.ValueMember = "ID";
        }

        private void cboPruga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PrviUlazak != 0)
            {
           
            }

        }

        private void cboPruga_Leave(object sender, EventArgs e)
        {
           /*
            var select = " Select Stanice.ID, RTrim(Stanice.Opis) as Opis from PRugaStavke inner join Stanice on PrugaStavke.StanicaOd = Stanice.Id where PrugaStavke.IdPruge =  " + cboPruga.SelectedValue;
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cmbPocetna.DataSource = ds.Tables[0];
            cmbPocetna.DisplayMember = "Opis";
            cmbPocetna.ValueMember = "ID";


            /////////////Stanica do

            var select2 = " Select Stanice.ID, RTrim(Stanice.OPis) as Opis from PRugaStavke inner join Stanice on PrugaStavke.StanicaDo= Stanice.Id where PrugaStavke.IdPruge =  " + cboPruga.SelectedValue;
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboKrajnja.DataSource = ds2.Tables[0];
            cboKrajnja.DisplayMember = "Opis";
            cboKrajnja.ValueMember = "ID";
           */

        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertTrasaStanice ins = new InsertTrasaStanice();
                ins.InsTStan(Convert.ToInt32(cboPruga.SelectedValue), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cmbPocetna.SelectedValue), Convert.ToInt32(cboKrajnja.SelectedValue));
                RefreshDataGrid();
                status = false;
            }
            else
            {

                InsertTrasaStanice upd = new InsertTrasaStanice();
                upd.UpdTStan(Convert.ToInt32(txtID.Text), Convert.ToInt32(cboPruga.SelectedValue), Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cmbPocetna.SelectedValue), Convert.ToInt32(cboKrajnja.SelectedValue));
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid();

            }
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtID.Enabled = false;
            txtID.Text = "";
            status = true;
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertTrasaStanice upd = new InsertTrasaStanice();
            upd.DelTStan(Convert.ToInt32(txtID.Text));
            status = false;
            txtSifra.Enabled = false;
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
                        txtID.Text = row.Cells[0].Value.ToString();
                        txtSifra.Text = row.Cells[2].Value.ToString();
                        cboPruga.SelectedValue = Convert.ToInt32(row.Cells[1].Value.ToString());
                        txtVoz.Text = row.Cells[3].Value.ToString();
                        cmbPocetna.SelectedValue = Convert.ToInt32(row.Cells[4].Value.ToString());
                        cboKrajnja.SelectedValue = Convert.ToInt32(row.Cells[5].Value.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela promena stavki");
            }
        }
    }
}
