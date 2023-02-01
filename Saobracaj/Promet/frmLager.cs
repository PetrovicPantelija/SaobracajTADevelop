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



namespace TrackModal.Promet
{
    public partial class frmLager : Form
    {
        string KorisnikCene;
        public frmLager()
        {
            InitializeComponent();
        }

         public frmLager(string Korisnik)
        {
            KorisnikCene = Korisnik;
            InitializeComponent();
        }

        private void frmLager_Load(object sender, EventArgs e)
        {
            var select = " Select Distinct ID, (NKM + '-' + Naziv) as NKM  From VrstaRobe";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboVrstaRobe.DataSource = ds.Tables[0];
            cboVrstaRobe.DisplayMember = "NKM";
            cboVrstaRobe.ValueMember = "ID";

            var select2 = " Select Distinct ID, Naziv From Komitenti where Vlasnik =1  order by Naziv";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboVlasnikKontejnera.DataSource = ds2.Tables[0];
            cboVlasnikKontejnera.DisplayMember = "Naziv";
            cboVlasnikKontejnera.ValueMember = "ID";

            var select3 = " Select Distinct ID, Naziv   From Skladista";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboSkladiste.DataSource = ds3.Tables[0];
            cboSkladiste.DisplayMember = "Naziv";
            cboSkladiste.ValueMember = "ID";

            var select4 = " Select Distinct ID, Naziv From TipKontenjera order by Naziv";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboTipKontejnera.DataSource = ds4.Tables[0];
            cboTipKontejnera.DisplayMember = "Naziv";
            cboTipKontejnera.ValueMember = "ID";
        }

        private void btnPregled_Click(object sender, EventArgs e)
        {
            var select = " Select * from( " +
     "SELECT distinct Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
   " , Promet.[PrStDokumenta], Promet.[PrSifVrstePrometa], Promet.[BrojKontejnera]  " +
   " , Promet.[PrPrimKol], Promet.[PrIzdKol] , Skladista.Naziv as Skladiste  , Pozicija.Oznaka, Skladista1.Naziv as SkaldisteIz, pozicija1.Oznaka as LokacijaIz,  " +
 " Promet.[PrOznSled]  ,Promet.[Datum] ,Promet.[Korisnik]  " +
 " FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID  " +
 " inner join Pozicija on Pozicija.ID = Promet.LokacijaU  " +
 " left join skladista as skladista1 on skladista1.ID = promet.SkladisteIz  " +
" left join pozicija as pozicija1 on Pozicija1.ID = Promet.LokacijaIz  " +
" where Zatvoren = 0 and Promet.SkladisteU  = " + Convert.ToInt32(cboSkladiste.SelectedValue) + " ) t1  ";
 ;


/*
            var select = " SELECT DISTINCT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
         " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
         " ,Promet.[PrPrimKol],Promet.[PrIzdKol] , Skladista.Naziv as Skladiste  , Pozicija.Oznaka, Skladista1.Naziv as SkaldisteIz, pozicija1.Oznaka as LokacijaIz, " +
         " Promet.[PrOznSled]  ,Promet.[Datum] ,Promet.[Korisnik]  FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
         " inner join Pozicija on Pozicija.ID = Promet.LokacijaU " +
         " inner join skladista as skladista1 on skladista1.ID = promet.SkladisteIz " +
         " inner join pozicija as pozicija1 on Pozicija1.ID = Promet.LokacijaIz " +
         " where Zatvoren = 0 and Promet.SkladisteU  = " + Convert.ToInt32(cboSkladiste.SelectedValue);
          */
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
            /*
            //string value = dataGridView1.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 40;
            // dataGridView1.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Datum Transakcije";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Vrsta Dokumenta";
            dataGridView1.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Br Dokumenta";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Vrsta Prometa";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Broj kontejnera";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "PrPrimKol";
            dataGridView1.Columns[6].Width = 80;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "SkladID ";
            dataGridView1.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Skladiste u";
            dataGridView1.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "LokacID ";
            dataGridView1.Columns[9].Width = 80;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Lokac U";
            dataGridView1.Columns[10].Width = 80;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Oznaka sled";
            dataGridView1.Columns[11].Width = 80;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "Datum";
            dataGridView1.Columns[12].Width = 80;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "Korisnik";
            dataGridView1.Columns[13].Width = 80;
             * */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var select = " SELECT DISTINCT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
         " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
         " ,Promet.[PrPrimKol],Promet.[PrIzdKol] , Skladista.Naziv as Skladiste  , Pozicija.Oznaka, Skladista1.Naziv as SkaldisteIz, pozicija1.Oznaka as LokacijaIz, " +
         " Promet.[PrOznSled]  ,Promet.[Datum] ,Promet.[Korisnik]  FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
         " inner join Pozicija on Pozicija.ID = Promet.LokacijaU " +
         " inner join skladista as skladista1 on skladista1.ID = promet.SkladisteIz " +
         " inner join pozicija as pozicija1 on Pozicija1.ID = Promet.LokacijaIz " +
         " inner join PrijemKontejneraVozStavke on Promet.PrOznSled = PrijemKontejneraVozStavke.ID " + 
         " where Zatvoren = 0 and Promet.SkladisteU  = " + Convert.ToInt32(cboSkladiste.SelectedValue) + " and PrijemKontejneraVozStavke.VrstaRobe = " + Convert.ToInt32(cboVrstaRobe.SelectedValue);
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

        private void button2_Click(object sender, EventArgs e)
        {
            var select = " SELECT DISTINCT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
       " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
       " ,Promet.[PrPrimKol],Promet.[PrIzdKol] , Skladista.Naziv as Skladiste  , Pozicija.Oznaka, Skladista1.Naziv as SkaldisteIz, pozicija1.Oznaka as LokacijaIz, " +
       " Promet.[PrOznSled]  ,Promet.[Datum] ,Promet.[Korisnik]  FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
       " inner join Pozicija on Pozicija.ID = Promet.LokacijaU " +
       " inner join skladista as skladista1 on skladista1.ID = promet.SkladisteIz " +
       " inner join pozicija as pozicija1 on Pozicija1.ID = Promet.LokacijaIz " +
       " inner join PrijemKontejneraVozStavke on Promet.PrOznSled = PrijemKontejneraVozStavke.ID " +
       " where Zatvoren = 0 and Promet.SkladisteU  = " + Convert.ToInt32(cboSkladiste.SelectedValue) + " and PrijemKontejneraVozStavke.TipKontejnera = " + Convert.ToInt32(cboTipKontejnera.SelectedValue) + " and PrijemKontejneraVozStavke.VrstaRobe = " + Convert.ToInt32(cboVrstaRobe.SelectedValue); ;


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

        private void button3_Click(object sender, EventArgs e)
        {
            var select = " SELECT DISTINCT Promet.[Id], Promet.[DatumTransakcije], Promet.[VrstaDokumenta] " +
      " ,Promet.[PrStDokumenta],Promet.[PrSifVrstePrometa],Promet.[BrojKontejnera] " +
      " ,Promet.[PrPrimKol],Promet.[PrIzdKol] , Skladista.Naziv as Skladiste  , Pozicija.Oznaka, Skladista1.Naziv as SkaldisteIz, pozicija1.Oznaka as LokacijaIz, " +
      " Promet.[PrOznSled]  ,Promet.[Datum] ,Promet.[Korisnik]  FROM [dbo].[Promet] inner join Skladista on Promet.SkladisteU = Skladista.ID " +
      " inner join Pozicija on Pozicija.ID = Promet.LokacijaU " +
      " inner join skladista as skladista1 on skladista1.ID = promet.SkladisteIz " +
      " inner join pozicija as pozicija1 on Pozicija1.ID = Promet.LokacijaIz " +
      " inner join PrijemKontejneraVozStavke on Promet.PrOznSled = PrijemKontejneraVozStavke.ID " +
      " where Zatvoren = 0 and Promet.SkladisteU  = " + Convert.ToInt32(cboSkladiste.SelectedValue) + " and PrijemKontejneraVozStavke.VlasnikKontejnera = " + Convert.ToInt32(cboVlasnikKontejnera.SelectedValue) + " and PrijemKontejneraVozStavke.TipKontejnera = " + Convert.ToInt32(cboTipKontejnera.SelectedValue) + " and PrijemKontejneraVozStavke.VrstaRobe = " + Convert.ToInt32(cboVrstaRobe.SelectedValue); ;
          
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
    }
}
