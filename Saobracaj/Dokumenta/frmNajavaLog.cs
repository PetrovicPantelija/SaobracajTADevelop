using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Dokumenta
{
    public partial class frmNajavaLog : Form
    {
        string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public frmNajavaLog()
        {
            InitializeComponent();
            FillGV();
            FillCombo();
        }
        private void FillGV()
        {
            var select = "Select * from NajavaLog order by LogID desc";
            var conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void FillCombo()
        {
            var select = "Select Distinct ID,PrevozniPut from NajavaLog order by ID desc";
            var conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            combo_Najava.DataSource = ds.Tables[0];
            combo_Najava.DisplayMember = "ID";
            combo_Najava.ValueMember = "ID";

            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[6].Width = 40;
            dataGridView1.Columns[7].Width = 60;
            dataGridView1.Columns[8].Width = 60;
            dataGridView1.Columns[9].Width = 60;
            dataGridView1.Columns[10].Width = 60;
            dataGridView1.Columns[11].Width = 60;
            dataGridView1.Columns[12].Width = 60;
            dataGridView1.Columns[13].Width = 150;
            dataGridView1.Columns[14].Width = 50;
            dataGridView1.Columns[15].Width = 50;
            dataGridView1.Columns[16].Width = 50;
            dataGridView1.Columns[17].Width = 50;
            dataGridView1.Columns[22].Width = 40;
            dataGridView1.Columns[24].Width = 50;
            dataGridView1.Columns[25].Width = 50;
            dataGridView1.Columns[28].Width = 150;
            dataGridView1.Columns[29].Width = 50;
            dataGridView1.Columns[30].Width = 55;
            dataGridView1.Columns[31].Width = 50;
            dataGridView1.Columns[32].Width = 45;
            dataGridView1.Columns[33].Width = 55;
            dataGridView1.Columns[35].Width = 120;
            dataGridView1.Columns[36].Width = 40;
            dataGridView1.Columns[39].Width = 50;
            dataGridView1.Columns[40].Width = 65;
            dataGridView1.Columns[41].Width = 55;
            dataGridView1.Columns[42].Width = 55;
            dataGridView1.Columns[44].Width = 55;
            dataGridView1.Columns[45].Width = 70;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.ClearSelection();
            var select = "Select * from NajavaLog where ID=" + Convert.ToInt32(combo_Najava.SelectedValue) + "order by LogID desc";
            var conn = new SqlConnection(connect);
            var dataAdapter = new SqlDataAdapter(select, conn);
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

            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[6].Width = 40;
            dataGridView1.Columns[7].Width = 60;
            dataGridView1.Columns[8].Width = 60;
            dataGridView1.Columns[9].Width = 60;
            dataGridView1.Columns[10].Width = 60;
            dataGridView1.Columns[11].Width = 60;
            dataGridView1.Columns[12].Width = 60;
            dataGridView1.Columns[13].Width = 150;
            dataGridView1.Columns[14].Width = 50;
            dataGridView1.Columns[15].Width = 50;
            dataGridView1.Columns[16].Width = 50;
            dataGridView1.Columns[17].Width = 50;
            dataGridView1.Columns[22].Width = 40;
            dataGridView1.Columns[24].Width = 50;
            dataGridView1.Columns[25].Width = 50;
            dataGridView1.Columns[28].Width = 150;
            dataGridView1.Columns[29].Width = 50;
            dataGridView1.Columns[30].Width = 55;
            dataGridView1.Columns[31].Width = 50;
            dataGridView1.Columns[32].Width = 45;
            dataGridView1.Columns[33].Width = 55;
            dataGridView1.Columns[35].Width = 120;
            dataGridView1.Columns[36].Width = 40;
            dataGridView1.Columns[39].Width = 50;
            dataGridView1.Columns[40].Width = 65;
            dataGridView1.Columns[41].Width = 55;
            dataGridView1.Columns[42].Width = 55;
            dataGridView1.Columns[44].Width = 55;
            dataGridView1.Columns[45].Width = 70;

            Proveri();
        }
        private void Proveri()
        {
            int row = dataGridView1.Rows.Count;

            for (int i = 0; i < row - 1; i++)
            {
                if (dataGridView1.Rows[0].Cells[5].Value.ToString().TrimEnd().Equals(dataGridView1.Rows[i].Cells[5].Value.ToString().TrimEnd()))
                {
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Blue;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Red;
                }

                if (dataGridView1.Rows[0].Cells[13].Value.ToString().TrimEnd().Equals(dataGridView1.Rows[i].Cells[13].Value.ToString().TrimEnd()))
                {
                    dataGridView1.Rows[i].Cells[13].Style.BackColor = Color.Blue;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[13].Style.BackColor = Color.Red;
                }

                if (dataGridView1.Rows[0].Cells[23].Value.ToString().TrimEnd().Equals(dataGridView1.Rows[i].Cells[23].Value.ToString().TrimEnd()))
                {
                    dataGridView1.Rows[i].Cells[23].Style.BackColor = Color.Blue;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[23].Style.BackColor = Color.Red;
                }

                if (dataGridView1.Rows[0].Cells[27].Value.ToString().TrimEnd().Equals(dataGridView1.Rows[i].Cells[27].Value.ToString().TrimEnd()))
                {

                    dataGridView1.Rows[i].Cells[27].Style.BackColor = Color.Blue;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[27].Style.BackColor = Color.Red;
                }

                if (dataGridView1.Rows[0].Cells[34].Value.ToString().TrimEnd().Equals(dataGridView1.Rows[i].Cells[34].Value.ToString().TrimEnd()))
                {
                    dataGridView1.Rows[i].Cells[34].Style.BackColor = Color.Blue;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[34].Style.BackColor = Color.Red;
                }

                if (dataGridView1.Rows[0].Cells[35].Value.ToString().TrimEnd().Equals(dataGridView1.Rows[i].Cells[35].Value.ToString().TrimEnd()))
                {
                    dataGridView1.Rows[i].Cells[35].Style.BackColor = Color.Blue;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[35].Style.BackColor = Color.Red;
                }
                
                if (dataGridView1.Rows[0].Cells[38].Value.ToString().TrimEnd().Equals(dataGridView1.Rows[i].Cells[38].Value.ToString().TrimEnd()))
                {
                        dataGridView1.Rows[i].Cells[38].Style.BackColor = Color.Blue;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[38].Style.BackColor = Color.Red;
                }

                if (dataGridView1.Rows[0].Cells[45].Value.ToString().TrimEnd().Equals(dataGridView1.Rows[i].Cells[45].Value.ToString().TrimEnd()))
                {
                        dataGridView1.Rows[i].Cells[45].Style.BackColor = Color.Blue;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[45].Style.BackColor = Color.Red;
                }


                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[6].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value))
                {
                    dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[7].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value))
                {
                    dataGridView1.Rows[i].Cells[7].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[7].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[8].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value))
                {
                    dataGridView1.Rows[i].Cells[8].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[8].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[9].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value))
                {
                    dataGridView1.Rows[i].Cells[9].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[9].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[10].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value))
                {
                    dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[11].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value))
                {
                    dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[12].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value))
                {
                    dataGridView1.Rows[i].Cells[12].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[12].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[16].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value))
                {
                    dataGridView1.Rows[i].Cells[16].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[16].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[17].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value))
                {
                    dataGridView1.Rows[i].Cells[17].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[17].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[22].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[22].Value))
                {
                    dataGridView1.Rows[i].Cells[22].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[22].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[24].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[24].Value))
                {
                    dataGridView1.Rows[i].Cells[24].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[24].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[25].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[25].Value))
                {
                    dataGridView1.Rows[i].Cells[25].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[25].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[29].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[29].Value))
                {
                    dataGridView1.Rows[i].Cells[29].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[29].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[30].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[30].Value))
                {
                    dataGridView1.Rows[i].Cells[30].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[30].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[31].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[31].Value))
                {
                    dataGridView1.Rows[i].Cells[31].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[31].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[32].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[32].Value))
                {
                    dataGridView1.Rows[i].Cells[32].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[32].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[33].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[33].Value))
                {
                    dataGridView1.Rows[i].Cells[33].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[33].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[36].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[36].Value))
                {
                    dataGridView1.Rows[i].Cells[36].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[36].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[39].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[39].Value))
                {
                    dataGridView1.Rows[i].Cells[39].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[39].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[41].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[41].Value))
                {
                    dataGridView1.Rows[i].Cells[41].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[41].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[42].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[42].Value))
                {
                    dataGridView1.Rows[i].Cells[42].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[42].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[43].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[43].Value))
                {
                    dataGridView1.Rows[i].Cells[43].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[43].Style.BackColor = Color.Blue;
                }
                if (Convert.ToInt32(dataGridView1.Rows[0].Cells[44].Value) != Convert.ToInt32(dataGridView1.Rows[i].Cells[44].Value))
                {
                    dataGridView1.Rows[i].Cells[44].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[44].Style.BackColor = Color.Blue;
                }

                if (Convert.ToDecimal(dataGridView1.Rows[0].Cells[14].Value) != Convert.ToDecimal(dataGridView1.Rows[i].Cells[14].Value))
                {
                    dataGridView1.Rows[i].Cells[14].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[14].Style.BackColor = Color.Blue;
                }
                if (Convert.ToDecimal(dataGridView1.Rows[0].Cells[15].Value) != Convert.ToDecimal(dataGridView1.Rows[i].Cells[15].Value))
                {
                    dataGridView1.Rows[i].Cells[15].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[15].Style.BackColor = Color.Blue;
                }
                if (Convert.ToDecimal(dataGridView1.Rows[0].Cells[40].Value) != Convert.ToDecimal(dataGridView1.Rows[i].Cells[40].Value))
                {
                    dataGridView1.Rows[i].Cells[40].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[40].Style.BackColor = Color.Blue;
                }
            }
        }
    }
}
