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

namespace TrackModal.Dokumeta
{
    public partial class frmBukingKolaKontrejner : Form
    {
        string KorisnikCene;

        public frmBukingKolaKontrejner()
        {
            InitializeComponent();
        }

        public frmBukingKolaKontrejner(string Korisnik)
        {
            InitializeComponent();
            KorisnikCene = Korisnik;
            
        }

        private void frmBukingKolaKontrejner_Load(object sender, EventArgs e)
        {
            //Prijemnica

            var select4 = " select PrijemKontejneraVoz.ID,  (Cast(Voz.BrVoza as nvarchar(6)) + ' / ' + Cast(PrijemKontejneraVoz.vremedolaska as nvarchar(12))) as BrVoza from PrijemKontejneraVoz inner join Voz on Voz.Id = PrijemKontejneraVoz.IDVoza" +
                " where PrijemKontejneraVoz.Vozom =1" +
                " order by PrijemKontejneraVoz.id desc";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboPrijemnica.DataSource = ds4.Tables[0];
            cboPrijemnica.DisplayMember = "BrVoza";
            cboPrijemnica.ValueMember = "ID";


            var select5 = " Select Distinct OtpremaKontejnera.ID as ID, (Cast(OtpremaKontejnera.id as nvarchar(5))+ '-' + Cast(BrVoza as nvarchar(5)) + '-' + Relacija + '-' + Cast(Cast(VremePolaskaO as DateTime) as Nvarchar(12))) as BrVoza From OtpremaKontejnera inner join Voz on Voz.ID = OtpremaKontejnera.IdVoza where StatusOtpreme = 0";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboOtpremnica.DataSource = ds5.Tables[0];
            cboOtpremnica.DisplayMember = "BrVoza";
            cboOtpremnica.ValueMember = "ID";

            var select7 = " select Distinct ID from VozPaket order by id desc";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboGarnitura.DataSource = ds7.Tables[0];
            cboGarnitura.DisplayMember = "ID";
            cboGarnitura.ValueMember = "ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var select = "  Select PrijemKontejneraVozStavke.BrojVagona, 'Voz' as Tip,PrijemKontejneraVozStavke.ID , PrijemKontejneraVozStavke.IDNadredjenog, TipKontenjera.Naziv,  PrijemKontejneraVozStavke.Tara,  PrijemKontejneraVozStavke.Neto,  (PrijemKontejneraVozStavke.Tara +  PrijemKontejneraVozStavke.Neto) as Bruto, PrijemKontejneraVozStavke.SopstvenaMasa, PrijemKontejneraVozStavke.BrojOsovina  from PrijemKontejneraVozStavke " +
           " inner Join TipKontenjera on PrijemKontejneraVozStavke.TipKontejnera = TipKontenjera.ID where PrijemKontejneraVozStavke.IdNadredjenog = " + Convert.ToInt32(cboPrijemnica.SelectedValue);
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
            dataGridView1.Columns[0].HeaderText = "Broj vagona";
            dataGridView1.Columns[0].Width = 170;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Broj vagona";
            dataGridView1.Columns[1].Width = 70;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "ID stavke";
            dataGridView1.Columns[2].Width = 70;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Broj";
            dataGridView1.Columns[3].Width = 70;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Tip kontejnera";
            dataGridView1.Columns[4].Width = 70;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Tara";
            dataGridView1.Columns[5].Width = 70;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Neto";
            dataGridView1.Columns[6].Width = 70;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Bruto";
            dataGridView1.Columns[7].Width = 70;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Sopstv. masa";
            dataGridView1.Columns[8].Width = 70;
            
            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Br. osovina";
            dataGridView1.Columns[9].Width = 70;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var select = "  SELECT OtpremaKontejneraVozStavke.ID, OtpremaKontejneraVozStavke.RB, OtpremaKontejneraVozStavke.IDNadredjenog,  OtpremaKontejneraVozStavke.BrojKontejnera, OtpremaKontejneraVozStavke.BrojVagona, "
                        + " OtpremaKontejneraVozStavke.BrojOsovina, OtpremaKontejneraVozStavke.SopstvenaMasa, OtpremaKontejneraVozStavke.Tara, OtpremaKontejneraVozStavke.Neto, Komitenti.Naziv AS Posiljalac, Komitenti_1.Naziv AS primalac, "
                        + " Komitenti_2.Naziv AS Vlasnikkontejnera, " +
                          " Komitenti_3.Naziv AS Organizator, " +
                        "  TipKontenjera.Naziv AS TipKontejnera, VrstaRobe.Naziv AS VrstaRobe, OtpremaKontejneraVozStavke.Buking , OtpremaKontejneraVozStavke.StatusKontejnera, "
                        + " OtpremaKontejneraVozStavke.BrojPlombe, OtpremaKontejneraVozStavke.BrojPlombe2, OtpremaKontejneraVozStavke.PlaniraniLager,"
                        + " OtpremaKontejneraVozStavke.Datum, OtpremaKontejneraVozStavke.Korisnik "
                        + "FROM  Komitenti INNER JOIN "
                        + " OtpremaKontejneraVozStavke ON Komitenti.ID = OtpremaKontejneraVozStavke.Posiljalac INNER JOIN "
                        + " Komitenti AS Komitenti_1 ON OtpremaKontejneraVozStavke.Primalac = Komitenti_1.ID INNER JOIN "
                        + " Komitenti AS Komitenti_2 ON OtpremaKontejneraVozStavke.VlasnikKontejnera = Komitenti_2.ID INNER JOIN "
                          + " Komitenti AS Komitenti_3 ON OtpremaKontejneraVozStavke.Organizator = Komitenti_3.ID INNER JOIN "
                         + "TipKontenjera ON OtpremaKontejneraVozStavke.TipKontejnera = TipKontenjera.ID INNER JOIN "
                        + " VrstaRobe ON OtpremaKontejneraVozStavke.VrstaRobe = VrstaRobe.ID "
                                + " where IdNadredjenog = " + Convert.ToInt32(cboOtpremnica.SelectedValue) + " order by RB";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = false;
            dataGridView2.DataSource = ds.Tables[0];



            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 40;
            dataGridView2.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "RB";
            dataGridView2.Columns[1].Width = 30;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Br otp";
            dataGridView2.Columns[2].Width = 30;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Broj kontejnera";
            dataGridView2.Columns[3].Width = 90;



            DataGridViewColumn column5 = dataGridView2.Columns[4];
            dataGridView2.Columns[4].HeaderText = "Broj vagona";
            dataGridView2.Columns[4].Width = 90;

            DataGridViewColumn column6 = dataGridView2.Columns[5];
            dataGridView2.Columns[5].HeaderText = "Broj osovina";
            dataGridView2.Columns[5].Width = 20;

            DataGridViewColumn column7 = dataGridView2.Columns[6];
            dataGridView2.Columns[6].HeaderText = "Sopstvena masa";
            dataGridView2.Columns[6].Width = 30;

            DataGridViewColumn column8 = dataGridView2.Columns[7];
            dataGridView2.Columns[7].HeaderText = "Tara";
            dataGridView2.Columns[7].Width = 50;

            DataGridViewColumn column9 = dataGridView2.Columns[8];
            dataGridView2.Columns[8].HeaderText = "Neto";
            dataGridView2.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView2.Columns[9];
            dataGridView2.Columns[9].HeaderText = "Posiljalac";
            dataGridView2.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView2.Columns[10];
            dataGridView2.Columns[10].HeaderText = "Primalac";
            dataGridView2.Columns[10].Width = 50;

            DataGridViewColumn column12 = dataGridView2.Columns[11];
            dataGridView2.Columns[11].HeaderText = "Vlasnik kontejnera";
            dataGridView2.Columns[11].Width = 40;

            DataGridViewColumn column13 = dataGridView2.Columns[12];
            dataGridView2.Columns[12].HeaderText = "Organizator";
            dataGridView2.Columns[12].Width = 40;

            DataGridViewColumn column14 = dataGridView2.Columns[13];
            dataGridView2.Columns[13].HeaderText = "Tip kontejnera";
            dataGridView2.Columns[13].Width = 30;

            DataGridViewColumn column15 = dataGridView2.Columns[14];
            dataGridView2.Columns[14].HeaderText = "Vrsta robe";
            dataGridView2.Columns[14].Width = 30;

            DataGridViewColumn column16 = dataGridView2.Columns[15];
            dataGridView2.Columns[15].HeaderText = "Buking";
            dataGridView2.Columns[15].Width = 30;

            DataGridViewColumn column17 = dataGridView2.Columns[16];
            dataGridView2.Columns[16].HeaderText = " Status Kontejnera";
            dataGridView2.Columns[16].Width = 90;

            DataGridViewColumn column18 = dataGridView2.Columns[17];
            dataGridView2.Columns[17].HeaderText = "Broj plombe";
            dataGridView2.Columns[17].Width = 90;

            DataGridViewColumn column19 = dataGridView2.Columns[18];
            dataGridView2.Columns[18].HeaderText = "Br plombe 2";
            dataGridView2.Columns[18].Width = 70;

            DataGridViewColumn column20 = dataGridView2.Columns[19];
            dataGridView2.Columns[19].HeaderText = "Pl lager";
            dataGridView2.Columns[19].Width = 70;


            DataGridViewColumn column21 = dataGridView2.Columns[20];
            dataGridView2.Columns[20].HeaderText = "Datum";
            dataGridView2.Columns[20].Width = 70;

            DataGridViewColumn column22 = dataGridView2.Columns[21];
            dataGridView2.Columns[21].HeaderText = "Korisnik";
            dataGridView2.Columns[21].Width = 70;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewRow row2 in dataGridView2.Rows)
                    {
                        if (row2.Selected)
                        {
                            InsertOtpremaKontejneraStavke ins = new InsertOtpremaKontejneraStavke();
                            if (row.Cells[0].Value == null)
                            {
                                ins.PromeniBrojVagona(Convert.ToInt32(row2.Cells[0].Value.ToString()), row.Cells[3].Value.ToString(), Convert.ToDouble(row.Cells[4].Value.ToString()), Convert.ToDouble(row.Cells[5].Value.ToString()));
                            }
                            else
                            {
                               // ins.PromeniBrojVagona(Convert.ToInt32(row2.Cells[0].Value.ToString()), row.Cells[0].Value.ToString());
                            }
                            }

                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int prvi = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    if (prvi == 1)
                    {
                        InsertVozPaket ins = new InsertVozPaket();
                        ins.InsertVozPak(Convert.ToInt32(txtSifra.Text),row.Cells[0].Value.ToString(), Convert.ToDouble(row.Cells[8].Value), Convert.ToDouble(row.Cells[9].Value), DateTime.Now, "sa", 1);
                        prvi = 0;
                    }
                    else
                    {
                        InsertVozPaket ins = new InsertVozPaket();
                        ins.InsertVozPak(Convert.ToInt32(txtSifra.Text),row.Cells[0].Value.ToString(), Convert.ToDouble(row.Cells[8].Value), Convert.ToDouble(row.Cells[9].Value), DateTime.Now, "sa", 0);
                    }


                }
            }
            /*
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int index = dataGridView3.Rows.Add();
                dataGridView3.Rows[index].Cells[0].Value = dataGridView1.SelectedRows[i].Cells[0].Value.ToString();  
                dataGridView3.Rows[index].Cells[1].Value = dataGridView1.SelectedRows[i].Cells[8].Value.ToString(); 
                dataGridView3.Rows[index].Cells[2].Value = dataGridView1.SelectedRows[i].Cells[9].Value.ToString(); 
               

            }
            */
            foreach (DataGridViewRow selRow in dataGridView1.SelectedRows.OfType<DataGridViewRow>().ToArray())
            {
                dataGridView1.Rows.Remove(selRow);

            }

            RefreshDataGrid3();


        }
        private void RefreshDataGrid3()
        {
            var select = "  Select BrojVagona, SopstvenaMasa, BrojOsovina,RB  from VozPaket " +
              " where ID = " + Convert.ToInt32(txtSifra.Text);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);
           
            // dataGridView3.Columns[3].Visible = false;
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = false;
            dataGridView3.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "Broj vagona";
            dataGridView3.Columns[0].Width = 90;

            DataGridViewColumn column1 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Sopstv. masa";
            dataGridView3.Columns[1].Width = 50;

            DataGridViewColumn column2 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Br. osovina";
            dataGridView3.Columns[2].Width = 50;

            DataGridViewColumn column3 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "RB";
            dataGridView3.Columns[3].Width = 40;

            double sopstvenamasa = 0;
            double brojosovina = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                sopstvenamasa = sopstvenamasa + Convert.ToDouble(row.Cells[1].Value);
                brojosovina = brojosovina + Convert.ToDouble(row.Cells[2].Value);

            }
            txtSopstvenaMasa2.Value = Convert.ToDecimal(sopstvenamasa);
            txtBrojOsovina2.Value = Convert.ToDecimal(brojosovina);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            /*
                int index = dataGridView3.Rows.Add();
                dataGridView3.Rows[index].Cells[0].Value = txtVagon.Text;
                dataGridView3.Rows[index].Cells[1].Value = txtSopstvenaMasa.Value.ToString();
                dataGridView3.Rows[index].Cells[2].Value = txtBrojOsovina.Value.ToString();
*/
            InsertVozPaket ins = new InsertVozPaket();
            ins.InsertVozPak(Convert.ToInt32(txtSifra.Text), txtVagon.Text, Convert.ToDouble(txtSopstvenaMasa.Value), Convert.ToDouble(txtBrojOsovina.Value), DateTime.Now, "sa", 1);

            RefreshDataGrid3();
        }
        private void VratiPodatkeMaxSledeci()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("Select (Max(ID) + 1)  as ID from VozPaket", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }
        private void btnSacuvajGarnituru_Click(object sender, EventArgs e)
        {
            /*
            int prvi = 1;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Selected)
                {
                    if (prvi == 1)
                    {
                        InsertVozPaket ins = new InsertVozPaket();
                        ins.InsertVozPak(row.Cells[0].Value.ToString(), Convert.ToDouble(row.Cells[1].Value), Convert.ToDouble(row.Cells[2].Value), DateTime.Now, "sa", 1);
                        prvi = 0;
                    }
                    else 
                    {
                        InsertVozPaket ins = new InsertVozPaket();
                        ins.InsertVozPak(row.Cells[0].Value.ToString(), Convert.ToDouble(row.Cells[1].Value), Convert.ToDouble(row.Cells[2].Value), DateTime.Now, "sa", 0);
                    }

                           
                }
            }
            */
            VratiPodatkeMaxSledeci();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var select = "  Select BrojVagona, SopstvenaMasa, BrojOsovina,RB  from VozPaket " +
            " where ID = " + Convert.ToInt32(cboGarnitura.SelectedValue);
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);
          
           // dataGridView3.Columns[3].Visible = false;
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = false;
            dataGridView3.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "Broj vagona";
            dataGridView3.Columns[0].Width = 90;

            DataGridViewColumn column1 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Sopstv. masa";
            dataGridView3.Columns[1].Width = 50;

            DataGridViewColumn column2 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Br. osovina";
            dataGridView3.Columns[2].Width = 50;

            DataGridViewColumn column3 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "RB";
            dataGridView3.Columns[3].Width = 40;

            double sopstvenamasa = 0;
            double brojosovina = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                sopstvenamasa = sopstvenamasa + Convert.ToDouble(row.Cells[1].Value);
                brojosovina = brojosovina + Convert.ToDouble(row.Cells[2].Value);

            }
            txtSopstvenaMasa2.Value = Convert.ToDecimal(sopstvenamasa);
            txtBrojOsovina2.Value = Convert.ToDecimal(brojosovina);

            txtSifra.Text = cboGarnitura.SelectedValue.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var select7 = " select Distinct ID from VozPaket order by id desc";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboGarnitura.DataSource = ds7.Tables[0];
            cboGarnitura.DisplayMember = "ID";
            cboGarnitura.ValueMember = "ID";

           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da brišete?", "Izbor", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        InsertVozPaket dels = new InsertVozPaket();
                        dels.DeleteVozPak(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(row.Cells[3].Value));
                        RefreshDataGrid3();
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


                   
        }

        private void button9_Click(object sender, EventArgs e)
        {
          
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                 
                        InsertVozPaket dels = new InsertVozPaket();
                        dels.UpdateVozPak(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(row.Cells[3].Value), row.Cells[0].Value.ToString().Trim());
                  
                }
                RefreshDataGrid3();
           
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
               
                    InsertVozPaket dels = new InsertVozPaket();
                    dels.ObrniVozPak(Convert.ToInt32(txtSifra.Text));
                    

                RefreshDataGrid3();
            }
            catch
            {
                MessageBox.Show("Nije uspela promena rednog broja");
            }
        }
    }
}