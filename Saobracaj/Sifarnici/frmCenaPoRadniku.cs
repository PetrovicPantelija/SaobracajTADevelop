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

namespace Saobracaj.Sifarnici
{
    public partial class frmCenaPoRadniku : Form
    {
        bool status = false;
        public frmCenaPoRadniku()
        {
            InitializeComponent();
        }

        private void frmCenaPoRadniku_Load(object sender, EventArgs e)
        {
            RefreshDataGRid();
        }

        private void RefreshDataGRid()
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



            var select = "  Select EvidencijaCenaRadnik.Id, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis, " +
 " CASE WHEN EvidencijaCenaRadnik.ObracunPoSatu > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as ObracunPoSatu , Cena  from EvidencijaCenaRadnik " +
 " inner join Delavci on Delavci.DeSifra " +
 " = EvidencijaCenaRadnik.Zaposleni ";
       
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
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni";
            dataGridView1.Columns[1].Width = 350;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "ObracunPoSatu";
            dataGridView1.Columns[2].Width = 50;
          

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Cena";
            dataGridView1.Columns[3].Width = 50;

        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int PoSatu = 0;
            if (chkPoSatu.Checked)
                {
                    PoSatu = 1;
                }
                else
                {
                    PoSatu = 0;
                }

            if (status == true)
            {
                InsertEvidencijaSatiPoRadniku ins = new InsertEvidencijaSatiPoRadniku();
                ins.InsCenaPoRadniku(Convert.ToInt32(cboZaposleni.SelectedValue), PoSatu, Convert.ToDouble(txtCena.Text));
                status = false;
            }
            else
            {
                InsertEvidencijaSatiPoRadniku upd = new InsertEvidencijaSatiPoRadniku();
                upd.UpdCenaPoRadniku(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboZaposleni.SelectedValue), PoSatu, Convert.ToDouble(txtCena.Text));
            }
            RefreshDataGRid();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
        }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT ID , Zaposleni , ObracunPoSatu, Cena from EvidencijaCenaRadnik where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

              
                cboZaposleni.SelectedValue = Convert.ToInt32(dr["Zaposleni"].ToString());
          
                txtCena.Text = Convert.ToDecimal(dr["Cena"].ToString()).ToString();
               

                if (dr["ObracunPoSatu"].ToString() == "1")
                {
                    chkPoSatu.Checked = true;
                }
                else
                {
                    chkPoSatu.Checked = false;
                }
              
            }

            con.Close();
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
                        VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            
            InsertEvidencijaSatiPoRadniku ins = new InsertEvidencijaSatiPoRadniku();
            ins.DeleteEvidencijaCenaRadnik(Convert.ToInt32(txtSifra.Text));
            status = false;
            
        }

        private void tsPoslednja_Click(object sender, EventArgs e)
        {

        }
    }
}
