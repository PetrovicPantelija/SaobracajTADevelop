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
using MetroFramework.Forms;

namespace Saobracaj.Dokumenta
{
    public partial class frmOsnovnaZarada : MetroForm
    {
        bool status = false;

        public frmOsnovnaZarada()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        string niz = "";
        public static string code = "frmOsnovnaZarada";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
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
            if (txtPassword.Text != "iv4321")
            {
                return;
            
            }
            var select = " select Zarada.Zaposleni, (Rtrim(Delavci.DePriimek) + ' ' + RTrim(DeIme)) as Zaposleni,Zarada.Osnovna,Zarada.Minimalna ,  Smena, Parametar1, Parametar2, Zarada.PrviDeo, Zarada.DrugiDeo, Zarada.Fiksna,  Zarada.Benificirani,  Zarada.TipRadnika from Zarada " +
            " inner join Delavci on Zarada.Zaposleni = DElavci.DeSifra order by Zarada.Zaposleni";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

         //   dataGridView1.BorderStyle = BorderStyle.None;
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
            dataGridView1.Columns[0].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni";
            dataGridView1.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Ciljna";
            dataGridView1.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Minimalna";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Smena";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Noćni";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Terenski";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "I deo";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "II deo";
            dataGridView1.Columns[8].Width = 100;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Fiksna";
            dataGridView1.Columns[9].Width = 60;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Benificirani";
            dataGridView1.Columns[10].Width = 60;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Tip Radnika";
            dataGridView1.Columns[11].Width = 120;

        }


        private void RefreshDataGridFiksni()
        {
            if (txtPassword.Text != "iv4321")
            {
                return;

            }
            var select = " select Zarada.Zaposleni, (Rtrim(Delavci.DePriimek) + ' ' + RTrim(DeIme)) as Zaposleni,Zarada.Osnovna,Zarada.Minimalna ,  Smena, Parametar1, Parametar2, Zarada.PrviDeo, Zarada.DrugiDeo, Zarada.Fiksna,  Zarada.Benificirani,  Zarada.TipRadnika from Zarada " +
            " inner join Delavci on Zarada.Zaposleni = DElavci.DeSifra " +
             " where Fiksna = 1 " +
            " order by Zarada.Zaposleni";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni";
            dataGridView1.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Ciljna";
            dataGridView1.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Minimalna";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Smena";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Noćni";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Terenski";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "I deo";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "II deo";
            dataGridView1.Columns[8].Width = 100;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Fiksna";
            dataGridView1.Columns[9].Width = 60;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Benificirani";
            dataGridView1.Columns[10].Width = 60;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Tip Radnika";
            dataGridView1.Columns[11].Width = 120;

        }

        private void RefreshDataGridNisuFiksni()
        {
            if (txtPassword.Text != "iv4321")
            {
                return;

            }
            var select = " select Zarada.Zaposleni, (Rtrim(Delavci.DePriimek) + ' ' + RTrim(DeIme)) as Zaposleni,Zarada.Osnovna,Zarada.Minimalna ,  Smena, Parametar1, Parametar2, Zarada.PrviDeo, Zarada.DrugiDeo, Zarada.Fiksna,  Zarada.Benificirani,  Zarada.TipRadnika from Zarada " +
            " inner join Delavci on Zarada.Zaposleni = DElavci.DeSifra " +
             " where Fiksna = 0 " +
            " order by Zarada.Zaposleni";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            //string value = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni";
            dataGridView1.Columns[1].Width = 150;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Ciljna";
            dataGridView1.Columns[2].Width = 150;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Minimalna";
            dataGridView1.Columns[3].Width = 150;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Smena";
            dataGridView1.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Noćni";
            dataGridView1.Columns[5].Width = 50;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Terenski";
            dataGridView1.Columns[6].Width = 50;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "I deo";
            dataGridView1.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "II deo";
            dataGridView1.Columns[8].Width = 100;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Fiksna";
            dataGridView1.Columns[9].Width = 60;
           
            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Benificirani";
            dataGridView1.Columns[10].Width = 60;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "Tip Radnika";
            dataGridView1.Columns[11].Width = 120;

        }

        private void frmOsnovnaZarada_Load(object sender, EventArgs e)
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
           
           
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
           int PomSmena = 0;
           int PomParametar1 = 0;
           int PomParametar2 = 0;
           int Fiksna = 0;
           int PomBenigiciraniStaz = 0;
            string PomTipRadnika = "";
            if (chkSmenski.Checked == true)
            {
            PomSmena = 1;
            }
            else
	        {
            PomSmena = 0;
	        }

              if (chkParametar1.Checked == true)
            {
            PomParametar1 = 1;
            }
            else
	        {
            PomParametar1 = 0;
	        }

            if (chkParametar2.Checked == true)
            {
            PomParametar2 = 1;
            }
            else
	        {
            PomParametar2 = 0;
	        }


            if (chkFiksna.Checked == true)
            {
                Fiksna = 1;
            }
            else
            {
                Fiksna = 0;
            }


            if (chkBenificirani.Checked == true)
            {
                PomBenigiciraniStaz = 1;
            }
            else
            {
                PomBenigiciraniStaz = 0;
            }

            if (status == true)
            {
                InsertOsnovnaZarada ins = new InsertOsnovnaZarada();
                ins.InsZar(Convert.ToInt32(cboZaposleni.SelectedValue), Convert.ToDouble(txtCiljna.Value),Convert.ToDouble(txtMinimalna.Value), PomSmena, PomParametar1, PomParametar2, Convert.ToDouble(txtPrviDeo.Value), Convert.ToDouble(txtDrugiDeo.Text), Fiksna, PomBenigiciraniStaz, cboTipRadnika.Text);
                RefreshDataGrid();
                status = false;
            }
            else
            {
                InsertOsnovnaZarada upd = new InsertOsnovnaZarada();
                upd.UpdZar(Convert.ToInt32(cboZaposleni.SelectedValue), Convert.ToDouble(txtCiljna.Value), Convert.ToDouble(txtMinimalna.Value), PomSmena, PomParametar1, PomParametar2, Convert.ToDouble(txtPrviDeo.Value), Convert.ToDouble(txtDrugiDeo.Text), Fiksna,  PomBenigiciraniStaz, cboTipRadnika.Text);
                status = false;
               /// txtSifra.Enabled = false;
                RefreshDataGrid();
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertOsnovnaZarada del = new InsertOsnovnaZarada();
            del.DeleteZar(Convert.ToInt32(cboZaposleni.SelectedValue));
            status = false;
         //   txtSifra.Enabled = false;
            RefreshDataGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           // PrebaciIzPlata
            InsertOsnovnaZarada del = new InsertOsnovnaZarada();
            del.PrebaciIzPlata();
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
                        cboZaposleni.SelectedValue = Convert.ToInt32(row.Cells[0].Value.ToString());
                
                        txtCiljna.Value = Convert.ToDecimal(row.Cells[2].Value.ToString());
                        txtMinimalna.Value = Convert.ToDecimal(row.Cells[3].Value.ToString());
                         txtPrviDeo.Value = Convert.ToDecimal(row.Cells[7].Value.ToString());
                        txtDrugiDeo.Value = Convert.ToDecimal(row.Cells[8].Value.ToString());
                        if (Convert.ToInt32(row.Cells[9].Value.ToString()) == 1)
                        {
                            chkFiksna.Checked = true;

                        }
                        else
                        {
                            chkFiksna.Checked = false;
                        }
                        if ( Convert.ToInt32(row.Cells[4].Value.ToString())== 1)
                        {
                            chkSmenski.Checked = true;
                  
                        }
                        else
                        {
                            chkSmenski.Checked = false;
                        }

                        if (Convert.ToInt32(row.Cells[5].Value.ToString()) == 1)
                        {
                            chkParametar1.Checked = true;

                        }
                        else
                        {
                            chkParametar1.Checked = false;
                        }

                        if (Convert.ToInt32(row.Cells[6].Value.ToString()) == 1)
                        {
                            chkParametar2.Checked = true;

                        }
                        else
                        {
                            chkParametar2.Checked = false;
                        }

                        if (Convert.ToInt32(row.Cells[10].Value.ToString()) == 1)
                        {
                           chkBenificirani.Checked = true;

                        }
                        else
                        {
                            chkBenificirani.Checked = false;
                        }

                        if (row.Cells[11].Value.ToString() == "Osnivač")
                        {
                            cboTipRadnika.SelectedValue = "Osnivač";
                           

                        }
                        else if (row.Cells[11].Value.ToString() == "Radnik")
                        {
                            cboTipRadnika.SelectedValue = "Radnik";
                        }
                        else if (row.Cells[11].Value.ToString() == "Penzioner")
                        {
                            cboTipRadnika.SelectedValue = "Penzioner";
                        }
                        else
                        {
                            cboTipRadnika.SelectedValue = "";
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Nije uspela promena stavki");
            }
            
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            if (chkPregleFiksni.Checked == true)
            {
                RefreshDataGridFiksni();
            }
            else
            {
                RefreshDataGridNisuFiksni();
            }
        }

        private void btnPostaviPrviDeo_Click(object sender, EventArgs e)
        {
            InsertOsnovnaZarada upd = new InsertOsnovnaZarada();
            upd.PostaviPrviDeo(Convert.ToDouble(txtPrviDeo.Value));
            RefreshDataGrid();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            InsertOsnovnaZarada upd = new InsertOsnovnaZarada();
            upd.UpdateZaradePrvideoSvi();
           // RefreshDataGrid();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            InsertOsnovnaZarada upd = new InsertOsnovnaZarada();
            upd.UpdateZaradeDrugideoSvi();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            InsertOsnovnaZarada upd = new InsertOsnovnaZarada();
            upd.PostaviDrugiDeo();
            RefreshDataGrid();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            InsertOsnovnaZarada upd = new InsertOsnovnaZarada();
            upd.Plate22222();
            MessageBox.Show("Podaci su obrađeni");
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            InsertOsnovnaZarada upd = new InsertOsnovnaZarada();
            upd.UpdateZaradePrvideoSviMinimalna(Convert.ToDouble(txtMinimalnaDrzavna.Value));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            chkPregleFiksni.Checked = true;
            RefreshDataGridFiksni();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            chkPregleFiksni.Checked = false;
            RefreshDataGridNisuFiksni();
        }
    }
}
