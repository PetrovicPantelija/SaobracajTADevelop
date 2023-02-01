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
    public partial class frmRadniNaloziPregled2 : Form
    {
        public frmRadniNaloziPregled2()
        {
            InitializeComponent();
        }

        private void refreshDataGrid()
        {
            string pom = "'1'";
            var select = " select ID, Komentar, (Cast(Zaposleni.DeSifra as nvarchar(3)) + '--'  + Rtrim(Zaposleni.DeIme) + ' ' + Rtrim(Zaposleni.DePriimek)) as Planer, StatusRN  from RadniNalog RN " +
            " inner Join Delavci as Zaposleni ON RN.Planer = Zaposleni.DeSifra ";

            if (chkLA.Checked == true)
            {
                pom = pom + ",'RA'";
            }
            if (chkOD.Checked == true)
            {
                pom = pom + ",'OD'";
            }

            if (chkPL.Checked == true)
            {
                pom = pom + ",'PL'";
            }

            if (chkPR.Checked == true)
            {
                pom = pom + ",'PR'";
            }

            if (chkST.Checked == true)
            {
                pom = pom + ",'ST'";
            }
            if (chkZA.Checked == true)
            {
                pom = pom + ",'ZA'";
            }

            select = select + "where StatusRN in ( " + pom + ")";


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



        }

        private void frmRadniNaloziPregled2_Load(object sender, EventArgs e)
        {
            string pom = "'1'";
            var select = " select ID, Komentar, (Cast(Zaposleni.DeSifra as nvarchar(3)) + '--'  + Rtrim(Zaposleni.DeIme) + ' ' + Rtrim(Zaposleni.DePriimek)) as Planer, StatusRN  from RadniNalog RN " +
            " inner Join Delavci as Zaposleni ON RN.Planer = Zaposleni.DeSifra "; 
           
            if (chkLA.Checked == true)
            {
            pom = pom + ",'RA'";
            }
            if (chkOD.Checked == true)
            {
            pom = pom + ",'OD'";
            }
            
            if ( chkPL.Checked == true)
            {
            pom = pom + ",'PL'";
            }

            if (chkPR.Checked == true)
            {
            pom = pom + ",'PR'";
            }

            if (chkST.Checked == true)
            {
            pom = pom + ",'ST'";
            }
            if (chkZA.Checked == true)
            {
            pom = pom + ",'ZA'";
            }
              
            select = select + "where StatusRN in ( " + pom + ")"  ;


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void chkPR_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void chkLA_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void chkOD_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void chkPL_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void chkST_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void chkZA_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGrid();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmRadniNalog ter = new frmRadniNalog(txtSifra.Text);
            ter.Show();
        }
    }
}
