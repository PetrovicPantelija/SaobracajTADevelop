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
using Microsoft.Office.Interop.Excel;

namespace Saobracaj.Uvoz
{
    public partial class frmUvozKonacnaZaglavlje : Form
    {
        bool status = false;
        public string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public frmUvozKonacnaZaglavlje()
        {
            InitializeComponent();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNapomenaZaglavlje.Text = "";
            status = true;
        }

        private void VratiVoz()
        {
            var select = "SELECT [ID] ,[BrVoza],[Relacija], " +
                " CONVERT(varchar,VremePolaska,104)      + ' '      + SUBSTRING(CONVERT(varchar,VremePolaska,108),1,5) as VremePolaska, " +
                " CONVERT(varchar,[VremeDolaska],104)      + ' '      + SUBSTRING(CONVERT(varchar,[VremeDolaska],108),1,5)  as VremeDolaska, " +
                " [MaksimalnaBruto],[MaksimalnaDuzina] " +
                " ,[MaksimalanBrojKola] " +
                " ,[Napomena]" +
                " ,[PostNaTerminalD] as Postavka,[KontrolniPregledD] as Kontrolni ,[VremePrimopredajeD] as Primopredaja,[VremeIstovaraD] as Istovar" +
                " ,[Datum] ,[Korisnik],[Dolazeci] " +
                " FROM [dbo].[Voz] where ID =  " + Convert.ToInt32(cboVoz.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView5.ReadOnly = true;
            dataGridView5.DataSource = ds.Tables[0];

            dataGridView5.BorderStyle = BorderStyle.None;
            dataGridView5.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView5.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView5.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView5.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView5.BackgroundColor = Color.White;

            dataGridView5.EnableHeadersVisualStyles = false;
            dataGridView5.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView5.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;



        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                InsertUvozKonacnaZaglavlje ins = new InsertUvozKonacnaZaglavlje();
                ins.InsUvozKonacnaZaglavlje(Convert.ToInt32(cboVoz.SelectedValue), txtNapomenaZaglavlje.Text,1, "", Convert.ToDateTime("1.1.1900"), "","");
                RefreshDataGrid();
                status = false;
            }
            else
            {
                InsertUvozKonacnaZaglavlje ins = new InsertUvozKonacnaZaglavlje();
                ins.UpdUvozKonacnaZaglavlje(Convert.ToInt32(txtID.Text),Convert.ToInt32(cboVoz.SelectedValue), txtNapomenaZaglavlje.Text, 1, "", Convert.ToDateTime("1.1.1900"), "", "");
                RefreshDataGrid();
                status = false;
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertUvozKonacnaZaglavlje ins = new InsertUvozKonacnaZaglavlje();
            ins.DelUvozKonacnaZaglavlje(Convert.ToInt32(txtID.Text));
            RefreshDataGrid();
            status = false;
        }

        private void RefreshDataGrid()
        {
            var select = " Select UvozKonacnaZaglavlje.ID, UvozKonacnaZaglavlje.IDVoza, Voz.BrVoza, Voz.VremePolaska, Voz.VremeDolaska, s1.Opis as StanicaOd, s2.Opis as StanicaDo, Voz.Relacija as Relacija from UvozKonacnaZaglavlje " +
            " inner join Voz on Voz.ID = UvozKonacnaZaglavlje.IDVoza " +
            " inner join stanice s1 on s1.ID = Voz.StanicaOd " +
            " inner join stanice s2 on s2.ID = Voz.StanicaDo " +
            " order by UvozKonacnaZaglavlje.ID desc";
            // var select = "SELECT RkShippingItemPak.ShippingItemPakId as ID, RkShipping.ShippingNo as BarkodUtovara, RkShipping.BrojIstovara as BrojUtovara, RkShipping.DatumIstovara as DatumUtovara, RkShipping.BrojUtovara as BrojIstovara,  RkShipping.DatumUtovara as DatumIstovara , Saloni.MestoIsporuke, RkShippingItemPak.PaketName, RkShippingItemPak.LargoPakId, RkShippingItemPak.LargoNaziv, RkShippingItemPak.Paleta, RkShippingItemPak.Tezina,  RkShippingItemPak.LargoDimenzija  FROM [dbo].RkShippingItemPak inner join RkShipping on [dbo].RkShippingItemPak.ShipingIDz = RkShipping.[ShippingID] inner join SysKomitenti on RkShipping.KupacIDz = SysKomitenti.KomintentID inner join Saloni on RkShipping.SalonIDz = Saloni.SifraKomintentaMestoIsporuke where RkShipping.Vozilo  = '" + cboVozila.Text + "' and RkShipping.DatumUtovara = '" + cboDatumUtovara.Text + "' and RkShipping.DatumUtovara = '" + cboDatumUtovara.Text + "'";
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
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "IDVoza";
            dataGridView1.Columns[1].Width = 40;

        }

        private void frmUvozKonacnaZaglavlje_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connection);

            var voz = "select ID, (Cast(ID as NVarChar(10)) + '-'+Cast(BrVoza as NVarchar(15)) + '-' + Relacija + '-' + Cast(VremePolaska as nvarchar(20))) as Naziv   from Voz ";
            var vozSAD = new SqlDataAdapter(voz, conn);
            var vozSDS = new DataSet();
            vozSAD.Fill(vozSDS);
            cboVoz.DataSource = vozSDS.Tables[0];
            cboVoz.DisplayMember = "Naziv";
            cboVoz.ValueMember = "ID";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            VratiVoz();
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

                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtID.Text = row.Cells[0].Value.ToString();
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
