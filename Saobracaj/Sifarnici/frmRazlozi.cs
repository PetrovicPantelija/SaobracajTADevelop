﻿using System;
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
    
    public partial class frmRazlozi : Form
    {
        public static string code = "frmRazlozi";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";

        bool status = false;
        public frmRazlozi()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public string IdGrupe()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            //Sifarnici.frmLogovanje frm = new Sifarnici.frmLogovanje();         
            string query = "Select IdGrupe from KorisnikGrupa Where Korisnik = " + "'" + Kor.TrimEnd() + "'";
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;

            while (dr.Read())
            {
                if (count == 0)
                {
                    niz = dr["IdGrupe"].ToString();
                    count++;
                }
                else
                {
                    niz = niz + "," + dr["IdGrupe"].ToString();
                    count++;
                }

            }
            conn.Close();
            return niz;
        }
        private int IdForme()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            string query = "Select IdForme from Forme where Rtrim(Code)=" + "'" + code + "'";
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idForme = Convert.ToInt32(dr["IdForme"].ToString());
            }
            conn.Close();
            return idForme;
        }

        private void PravoPristupa()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            string query = "Select * From GrupeForme Where IdGrupe in (" + niz + ") and IdForme=" + idForme;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == false)
            {
                MessageBox.Show("Nemate prava za pristup ovoj formi", code);
                Pravo = false;
            }
            else
            {
                Pravo = true;
                while (reader.Read())
                {
                    insert = Convert.ToBoolean(reader["Upis"]);
                    if (insert == false)
                    {
                        tsNew.Enabled = false;
                    }
                    update = Convert.ToBoolean(reader["Izmena"]);
                    if (update == false)
                    {
                        tsSave.Enabled = false;
                    }
                    delete = Convert.ToBoolean(reader["Brisanje"]);
                    if (delete == false)
                    {
                        tsDelete.Enabled = false;
                    }
                }
            }

            conn.Close();
        }
        private void RefreshDataGrid()
        {
            var select = " Select * from Razlozi";
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

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Opis";
            dataGridView1.Columns[1].Width = 350;
        }
        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            txtSifra.Text = "";
            txtOpis.Text = "";
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertRazlozi ins = new InsertRazlozi();
                ins.InsRazlozi(txtOpis.Text, cboRazloziTip.Text);
                RefreshDataGrid();
                status = false;
            }
            else
            {
                InsertRazlozi upd = new InsertRazlozi();
                upd.UpdRazlozi(Convert.ToInt32(txtSifra.Text), txtOpis.Text, cboRazloziTip.Text);
                status = false;
                txtSifra.Enabled = false;
                RefreshDataGrid();
                

            }
        }

        private void frmRazlozi_Load(object sender, EventArgs e)
        {
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
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        txtOpis.Text = row.Cells[1].Value.ToString();
                        cboRazloziTip.Text = row.Cells[2].Value.ToString();
                       
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
