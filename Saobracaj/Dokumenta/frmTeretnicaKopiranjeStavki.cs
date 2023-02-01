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
    public partial class frmTeretnicaKopiranjeStavki : Form
    {
        public frmTeretnicaKopiranjeStavki()
        {
            InitializeComponent();
        }

        private void frmTeretnicaKopiranjeStavki_Load(object sender, EventArgs e)
        {
            var select = " Select ID, (Cast(id as nvarchar) + '/' +BrojTeretnice) as Teretnica From Teretnica";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboTeretnicaIz.DataSource = ds.Tables[0];
            cboTeretnicaIz.DisplayMember = "Teretnica";
            cboTeretnicaIz.ValueMember = "ID";

            var select2 = " Select ID, (Cast(id as nvarchar) + '/' +BrojTeretnice) as Teretnica From Teretnica";
            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            cboTeretnicaU.DataSource = ds2.Tables[0];
            cboTeretnicaU.DisplayMember = "Teretnica";
            cboTeretnicaU.ValueMember = "ID";

            var select6 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboStanicaIsklj.DataSource = ds6.Tables[0];
            cboStanicaIsklj.DisplayMember = "Stanica";
            cboStanicaIsklj.ValueMember = "ID";

            RefreshDataGrid3();
        }

        private void cboTeretnicaIz_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            /*
            SELECT     TeretnicaStavke.ID, TeretnicaStavke.RB, TeretnicaStavke.IDNajave, stanice.Opis as Uvrstena, stanice_1.Opis AS Otkacena, TeretnicaStavke.BrojKola, TeretnicaStavke.Serija, 
                          TeretnicaStavke.BrojOsovina, TeretnicaStavke.Duzina, TeretnicaStavke.Tara, TeretnicaStavke.Neto, TeretnicaStavke.G, TeretnicaStavke.P, TeretnicaStavke.R, 
                          TeretnicaStavke.RR, TeretnicaStavke.VRNP, stanice_3.Opis AS Otpravna, stanice_2.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, 
                          TeretnicaStavke.RucKoc
    FROM         TeretnicaStavke INNER JOIN
                          stanice ON TeretnicaStavke.Uvrstena = stanice.ID INNER JOIN
                          stanice AS stanice_1 ON TeretnicaStavke.Otkacena = stanice_1.ID INNER JOIN
                          stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN
                          stanice AS stanice_2 ON TeretnicaStavke.Otpravna = stanice_2.ID
                          where BrojTEretnice = 2 order by RB
        
            */
            if (cboTeretnicaIz.SelectedIndex == 0)
            {
            return;
            }
            else{
            var select = " SELECT     TeretnicaStavke.ID, TeretnicaStavke.RB, TeretnicaStavke.IDNajave, stanice.Opis as Uvrstena, stanice_1.Opis AS Otkacena, TeretnicaStavke.BrojKola, TeretnicaStavke.Serija, "
                          + " TeretnicaStavke.BrojOsovina, TeretnicaStavke.Duzina, TeretnicaStavke.Tara, TeretnicaStavke.Neto, TeretnicaStavke.G, TeretnicaStavke.P, TeretnicaStavke.R, "
                          + " TeretnicaStavke.RR, TeretnicaStavke.VRNP, stanice_3.Opis AS Otpravna, stanice_2.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, "
                          + " TeretnicaStavke.RucKoc "
                          + " FROM         TeretnicaStavke INNER JOIN "
                          + " stanice ON TeretnicaStavke.Uvrstena = stanice.ID INNER JOIN "
                          + " stanice AS stanice_1 ON TeretnicaStavke.Otkacena = stanice_1.ID INNER JOIN "
                          + " stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN "
                          + " stanice AS stanice_2 ON TeretnicaStavke.Otpravna = stanice_2.ID "
                          + " where BrojTEretnice = " + cboTeretnicaIz.SelectedValue + " order by RB";

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
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "IDNajave";
            dataGridView1.Columns[2].Width = 40;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Uvrštena";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Otkačena";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Broj Kola";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Serija";
            dataGridView1.Columns[6].Width = 20;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Br. osovina";
            dataGridView1.Columns[7].Width = 30;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Dužina";
            dataGridView1.Columns[8].Width = 30;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Tara";
            dataGridView1.Columns[9].Width = 30;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Neto";
            dataGridView1.Columns[10].Width = 30;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "G";
            dataGridView1.Columns[11].Width = 30;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "P";
            dataGridView1.Columns[12].Width = 30;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "R";
            dataGridView1.Columns[13].Width = 30;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "RR";
            dataGridView1.Columns[14].Width = 30;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "VRNP";
            dataGridView1.Columns[15].Width = 30;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Otpravna";
            dataGridView1.Columns[16].Width = 100;

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Uputna";
            dataGridView1.Columns[17].Width = 100;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Reon";
            dataGridView1.Columns[18].Width = 70;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Primedba";
            dataGridView1.Columns[19].Width = 70;

            DataGridViewColumn column21 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Ruč. koč";
            dataGridView1.Columns[20].Width = 70;
            }
        }

        private void RefreshDataGrid2()
        {
            /*
            SELECT     TeretnicaStavke.ID, TeretnicaStavke.RB, TeretnicaStavke.IDNajave, stanice.Opis as Uvrstena, stanice_1.Opis AS Otkacena, TeretnicaStavke.BrojKola, TeretnicaStavke.Serija, 
                          TeretnicaStavke.BrojOsovina, TeretnicaStavke.Duzina, TeretnicaStavke.Tara, TeretnicaStavke.Neto, TeretnicaStavke.G, TeretnicaStavke.P, TeretnicaStavke.R, 
                          TeretnicaStavke.RR, TeretnicaStavke.VRNP, stanice_3.Opis AS Otpravna, stanice_2.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, 
                          TeretnicaStavke.RucKoc
    FROM         TeretnicaStavke INNER JOIN
                          stanice ON TeretnicaStavke.Uvrstena = stanice.ID INNER JOIN
                          stanice AS stanice_1 ON TeretnicaStavke.Otkacena = stanice_1.ID INNER JOIN
                          stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN
                          stanice AS stanice_2 ON TeretnicaStavke.Otpravna = stanice_2.ID
                          where BrojTEretnice = 2 order by RB
        
            */
            if (cboTeretnicaIz.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                var select = " SELECT     TeretnicaStavke.ID, TeretnicaStavke.RB, TeretnicaStavke.IDNajave, stanice.Opis as Uvrstena, stanice_1.Opis AS Otkacena, TeretnicaStavke.BrojKola, TeretnicaStavke.Serija, "
                              + " TeretnicaStavke.BrojOsovina, TeretnicaStavke.Duzina, TeretnicaStavke.Tara, TeretnicaStavke.Neto, TeretnicaStavke.G, TeretnicaStavke.P, TeretnicaStavke.R, "
                              + " TeretnicaStavke.RR, TeretnicaStavke.VRNP, stanice_3.Opis AS Otpravna, stanice_2.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, "
                              + " TeretnicaStavke.RucKoc "
                              + " FROM         TeretnicaStavke INNER JOIN "
                              + " stanice ON TeretnicaStavke.Uvrstena = stanice.ID INNER JOIN "
                              + " stanice AS stanice_1 ON TeretnicaStavke.Otkacena = stanice_1.ID INNER JOIN "
                              + " stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN "
                              + " stanice AS stanice_2 ON TeretnicaStavke.Otpravna = stanice_2.ID "
                              + " where BrojTEretnice = " + cboTeretnicaU.SelectedValue + " order by RB";

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView2.ReadOnly = true;
                dataGridView2.DataSource = ds.Tables[0];



                DataGridViewColumn column = dataGridView2.Columns[0];
                dataGridView2.Columns[0].HeaderText = "ID";
                dataGridView2.Columns[0].Width = 40;

                DataGridViewColumn column2 = dataGridView2.Columns[1];
                dataGridView2.Columns[1].HeaderText = "RB";
                dataGridView2.Columns[1].Width = 40;

                DataGridViewColumn column3 = dataGridView2.Columns[2];
                dataGridView2.Columns[2].HeaderText = "IDNajave";
                dataGridView2.Columns[2].Width = 40;

                DataGridViewColumn column4 = dataGridView2.Columns[3];
                dataGridView2.Columns[3].HeaderText = "Uvrštena";
                dataGridView2.Columns[3].Width = 100;

                DataGridViewColumn column5 = dataGridView2.Columns[4];
                dataGridView2.Columns[4].HeaderText = "Otkačena";
                dataGridView2.Columns[4].Width = 100;

                DataGridViewColumn column6 = dataGridView2.Columns[5];
                dataGridView2.Columns[5].HeaderText = "Broj Kola";
                dataGridView2.Columns[5].Width = 100;

                DataGridViewColumn column7 = dataGridView2.Columns[6];
                dataGridView2.Columns[6].HeaderText = "Serija";
                dataGridView2.Columns[6].Width = 20;

                DataGridViewColumn column8 = dataGridView2.Columns[7];
                dataGridView2.Columns[7].HeaderText = "Br. osovina";
                dataGridView2.Columns[7].Width = 30;

                DataGridViewColumn column9 = dataGridView2.Columns[8];
                dataGridView2.Columns[8].HeaderText = "Dužina";
                dataGridView2.Columns[8].Width = 30;

                DataGridViewColumn column10 = dataGridView2.Columns[9];
                dataGridView2.Columns[9].HeaderText = "Tara";
                dataGridView2.Columns[9].Width = 30;

                DataGridViewColumn column11 = dataGridView2.Columns[10];
                dataGridView2.Columns[10].HeaderText = "Neto";
                dataGridView2.Columns[10].Width = 30;

                DataGridViewColumn column12 = dataGridView2.Columns[11];
                dataGridView2.Columns[11].HeaderText = "G";
                dataGridView2.Columns[11].Width = 30;

                DataGridViewColumn column13 = dataGridView2.Columns[12];
                dataGridView2.Columns[12].HeaderText = "P";
                dataGridView2.Columns[12].Width = 30;

                DataGridViewColumn column14 = dataGridView2.Columns[13];
                dataGridView2.Columns[13].HeaderText = "R";
                dataGridView2.Columns[13].Width = 30;

                DataGridViewColumn column15 = dataGridView2.Columns[14];
                dataGridView2.Columns[14].HeaderText = "RR";
                dataGridView2.Columns[14].Width = 30;

                DataGridViewColumn column16 = dataGridView2.Columns[15];
                dataGridView2.Columns[15].HeaderText = "VRNP";
                dataGridView2.Columns[15].Width = 30;

                DataGridViewColumn column17 = dataGridView2.Columns[16];
                dataGridView2.Columns[16].HeaderText = "Otpravna";
                dataGridView2.Columns[16].Width = 100;

                DataGridViewColumn column18 = dataGridView2.Columns[17];
                dataGridView2.Columns[17].HeaderText = "Uputna";
                dataGridView2.Columns[17].Width = 100;

                DataGridViewColumn column19 = dataGridView2.Columns[18];
                dataGridView2.Columns[18].HeaderText = "Reon";
                dataGridView2.Columns[18].Width = 70;

                DataGridViewColumn column20 = dataGridView2.Columns[19];
                dataGridView2.Columns[19].HeaderText = "Primedba";
                dataGridView2.Columns[19].Width = 70;

                DataGridViewColumn column21 = dataGridView2.Columns[20];
                dataGridView2.Columns[20].HeaderText = "Ruč. koč";
                dataGridView2.Columns[20].Width = 70;

            }
        }

        private void RefreshDataGrid3()
        {
            /*
             SELECT      TeretnicaStavke.VRNP, 
                          stanice_3.Opis AS Otpravna, stanice_4.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, TeretnicaStavke.RucKoc
    FROM         TeretnicaIskljuceniVagoni INNER JOIN
                          stanice ON TeretnicaIskljuceniVagoni.StanicaIskljucenja = stanice.ID INNER JOIN
                          TeretnicaStavke ON TeretnicaIskljuceniVagoni.IDTeretnice = TeretnicaStavke.ID INNER JOIN
                          stanice AS stanice_1 ON TeretnicaStavke.Uvrstena = stanice_1.ID INNER JOIN
                          stanice AS stanice_2 ON TeretnicaStavke.Otkacena = stanice_2.ID INNER JOIN
                          stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN
             */


            var select = " SELECT     TeretnicaIskljuceniVagoni.ID, TeretnicaIskljuceniVagoni.IDTeretnice, stanice.Opis, TeretnicaStavke.RB, TeretnicaStavke.BrojTeretnice, TeretnicaStavke.IDNajave, " +
                        " stanice_1.Opis AS Uvrstena, stanice_2.Opis AS Otkacena, TeretnicaStavke.BrojKola, TeretnicaStavke.Serija, TeretnicaStavke.BrojOsovina, TeretnicaStavke.Duzina, " +
                        " TeretnicaStavke.Tara, TeretnicaStavke.Neto, TeretnicaStavke.G, TeretnicaStavke.P, TeretnicaStavke.R, TeretnicaStavke.RR, TeretnicaStavke.VRNP, " +
                        " stanice_3.Opis AS Otpravna, stanice_4.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, TeretnicaStavke.RucKoc " +
                        " FROM TeretnicaIskljuceniVagoni INNER JOIN " +
                        " stanice ON TeretnicaIskljuceniVagoni.StanicaIskljucenja = stanice.ID INNER JOIN " +
                        " TeretnicaStavke ON TeretnicaIskljuceniVagoni.IDTeretnice = TeretnicaStavke.ID INNER JOIN " +
                        " stanice AS stanice_1 ON TeretnicaStavke.Uvrstena = stanice_1.ID INNER JOIN " +
                        " stanice AS stanice_2 ON TeretnicaStavke.Otkacena = stanice_2.ID INNER JOIN " +
                        " stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN " +
                        " stanice AS stanice_4 ON TeretnicaStavke.Uputna = stanice_4.ID";

                var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView3.ReadOnly = true;
                dataGridView3.DataSource = ds.Tables[0];
                DataGridViewColumn column = dataGridView3.Columns[0];
                dataGridView3.Columns[0].HeaderText = "Isklj vag ID";
                dataGridView3.Columns[0].Width = 40;

                DataGridViewColumn column2 = dataGridView3.Columns[1];
                dataGridView3.Columns[1].HeaderText = "Stavka ID";
                dataGridView3.Columns[1].Width = 40;

                DataGridViewColumn column3 = dataGridView3.Columns[2];
                dataGridView3.Columns[2].HeaderText = "Stanica isklj.";
                dataGridView3.Columns[2].Width = 100;

                DataGridViewColumn column4 = dataGridView3.Columns[3];
                dataGridView3.Columns[3].HeaderText = "RB";
                dataGridView3.Columns[3].Width = 30;

                DataGridViewColumn column5 = dataGridView3.Columns[4];
                dataGridView3.Columns[4].HeaderText = "Br teretnice";
                dataGridView3.Columns[4].Width = 30;

                DataGridViewColumn column6 = dataGridView3.Columns[5];
                dataGridView3.Columns[5].HeaderText = "Najava ID";
                dataGridView3.Columns[5].Width = 40;

                DataGridViewColumn column7 = dataGridView3.Columns[6];
                dataGridView3.Columns[6].HeaderText = "Uvrštena";
                dataGridView3.Columns[6].Width = 100;

                DataGridViewColumn column8 = dataGridView3.Columns[7];
                dataGridView3.Columns[7].HeaderText = "Otkačena";
                dataGridView3.Columns[7].Width = 100;

                DataGridViewColumn column9 = dataGridView3.Columns[8];
                dataGridView3.Columns[8].HeaderText = "Broj kola";
                dataGridView3.Columns[8].Width = 50;

                DataGridViewColumn column10 = dataGridView3.Columns[9];
                dataGridView3.Columns[9].HeaderText = "Serija";
                dataGridView3.Columns[9].Width = 50;

                DataGridViewColumn column11 = dataGridView3.Columns[10];
                dataGridView3.Columns[10].HeaderText = "Broj osovina";
                dataGridView3.Columns[10].Width = 50;

                DataGridViewColumn column12 = dataGridView3.Columns[11];
                dataGridView3.Columns[11].HeaderText = "Dužina";
                dataGridView3.Columns[11].Width = 50;

                DataGridViewColumn column13 = dataGridView3.Columns[12];
                dataGridView3.Columns[12].HeaderText = "Tara";
                dataGridView3.Columns[12].Width = 50;

                DataGridViewColumn column14 = dataGridView3.Columns[13];
                dataGridView3.Columns[13].HeaderText = "Neto";
                dataGridView3.Columns[13].Width = 50;

                DataGridViewColumn column15 = dataGridView3.Columns[14];
                dataGridView3.Columns[14].HeaderText = "G";
                dataGridView3.Columns[14].Width = 50;

                DataGridViewColumn column16 = dataGridView3.Columns[15];
                dataGridView3.Columns[15].HeaderText = "P";
                dataGridView3.Columns[15].Width = 50;

                DataGridViewColumn column17 = dataGridView3.Columns[16];
                dataGridView3.Columns[16].HeaderText = "R";
                dataGridView3.Columns[16].Width = 50;

                DataGridViewColumn column18 = dataGridView3.Columns[17];
                dataGridView3.Columns[17].HeaderText = "RR";
                dataGridView3.Columns[17].Width = 50;

                DataGridViewColumn column19 = dataGridView3.Columns[18];
                dataGridView3.Columns[18].HeaderText = "Vrs. rob nam pr";
                dataGridView3.Columns[18].Width = 50;

                DataGridViewColumn column20 = dataGridView3.Columns[19];
                dataGridView3.Columns[19].HeaderText = "Otpravna";
                dataGridView3.Columns[19].Width = 100;

                DataGridViewColumn column21 = dataGridView3.Columns[20];
                dataGridView3.Columns[20].HeaderText = "Uputna";
                dataGridView3.Columns[20].Width = 100;

                DataGridViewColumn column22 = dataGridView3.Columns[21];
                dataGridView3.Columns[21].HeaderText = "Reon";
                dataGridView3.Columns[21].Width = 70;
            /*    
          TeretnicaStavke.R, TeretnicaStavke.RR, TeretnicaStavke.VRNP, " +
                        " stanice_3.Opis AS Otpravna, stanice_4.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, TeretnicaStavke.RucKoc 
                        //
            */
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                    InsertTeretnicaStavke its = new InsertTeretnicaStavke();
                    its.InsTeretnicaStavkeKopiranje(Convert.ToInt32(cboTeretnicaIz.SelectedValue), Convert.ToInt32(cboTeretnicaU.SelectedValue), Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                }

                RefreshDataGrid2();
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Selected)
                        {
                            InsertIskljuceniVagoni its = new InsertIskljuceniVagoni();
                            its.InsertIskljuceniVag(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboStanicaIsklj.SelectedValue));
                        }
                    }

                    RefreshDataGrid3();
                }
                catch
                {
                    MessageBox.Show("Nije uspela selekcija stavki");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        if (row.Selected)
                        {
                            InsertTeretnicaStavke its = new InsertTeretnicaStavke();
                            its.InsTeretnicaStavkeKopiranje(Convert.ToInt32(row.Cells[4].Value.ToString()), Convert.ToInt32(cboTeretnicaU.SelectedValue), Convert.ToInt32(row.Cells[1].Value.ToString()));
                            
                            InsertIskljuceniVagoni div = new InsertIskljuceniVagoni();
                            div.DeleteIskljuceniVagoni(Convert.ToInt32(row.Cells[0].Value.ToString()));
                            //, Convert.ToInt32(cboStanicaIsklj.SelectedValue));
                        }
                    }
                    //dataGridView3
                    RefreshDataGrid3();
                    RefreshDataGrid2();
                }
                catch
                {
                    MessageBox.Show("Nije uspela selekcija stavki");
                }






            }

        }

        private void cboTeretnicaU_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGrid2();
        }

        private void cboStanicaIsklj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
