using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Servis
{
    public partial class frmPlombe : Form
    {
        string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public static string code = "frmPlombe";
        public bool Pravo;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        bool status = false;
        string niz = "";
        OpenFileDialog ofd1 = new OpenFileDialog();
        FolderBrowserDialog fbd1 = new FolderBrowserDialog();
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
        public frmPlombe()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }

        private void frmPlombe_Load(object sender, EventArgs e)
        {
            FillCombo();
            FillGV();
            dateTimePicker1.Value = DateTime.Now;
            txt_ID.Enabled = false;
        }
        private void FillCombo()
        {
            var query = "Select RTrim(Korisnik) as Korisnik From Korisnici order by Korisnik";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            combo_Korisnik.DataSource = ds.Tables[0];
            combo_Korisnik.DisplayMember = "Korisnik";
            combo_Korisnik.ValueMember = "Korisnik";

            var query2 = "Select ID From Najava order by ID desc";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, conn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            combo_Najava.DataSource = ds2.Tables[0];
            combo_Najava.DisplayMember = "ID";
            combo_Najava.ValueMember = "ID";
        }
        private void FillGV()
        {
            var query = "Select * from Plombe";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].HeaderText = "Potrošeno";
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 320;
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txt_ID.Text = "";
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            InsertPlombe ins = new InsertPlombe();
            if (status == true)
            {
                ins.InsPlombe(Convert.ToDateTime(dateTimePicker1.Value.ToString()), combo_Korisnik.SelectedValue.ToString(), Convert.ToInt32(combo_Najava.SelectedValue),
                    Convert.ToInt32(txt_BrPlombi.Text), txt_Slika.Text.ToString().TrimEnd());
                status = false;
            }
            else
            {
                ins.UpdPlombe(Convert.ToInt32(txt_ID.Text), Convert.ToDateTime(dateTimePicker1.Value.ToString()), combo_Korisnik.SelectedValue.ToString(), Convert.ToInt32(combo_Najava.SelectedValue),
                Convert.ToInt32(txt_BrPlombi.Text), txt_Slika.Text.ToString().TrimEnd());
            }
            FillGV();
        }
        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertPlombe ins = new InsertPlombe();
            ins.DelPlombe(Convert.ToInt32(txt_ID.Text));
            FillGV();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txt_ID.Text = row.Cells[0].Value.ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(row.Cells[1].Value.ToString());
                        combo_Korisnik.SelectedValue = row.Cells[2].Value.ToString();
                        combo_Najava.SelectedValue = Convert.ToInt32(row.Cells[3].Value.ToString());
                        txt_BrPlombi.Text = row.Cells[4].Value.ToString();
                        txt_Slika.Text = row.Cells[5].Value.ToString();
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folder = txt_Slika.Text;
            ofd1.InitialDirectory = folder;
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                txt_Slika.Text = fbd1.SelectedPath.ToString() + ofd1.FileName;
            }
        }
        private void KopirajFajlPoTipu(string putanja, string FolderDestinacije, int ID)
        {
            string fileName = ofd1.FileName; //Ovde ce trebati promena
            fileName = fileName.Replace(" ", "_");
            string sourcePath = fbd1.SelectedPath.ToString();
            string result = Path.GetFileName(fileName);
            string targetPath = "";

            targetPath = @"\\192.168.1.6\Plombe\" + FolderDestinacije + ID;

            string sourceFile = putanja;
            string destFile = System.IO.Path.Combine(targetPath, result);

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            var remote = Path.Combine(targetPath, result);
            File.Copy(sourceFile, remote);
            txt_Slika.Text = targetPath;

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = 0;
            int id;
            if (txt_ID.Text == "")
            {
                string query = "Select top 1 ID from Plombe order by id desc";
                SqlConnection conn = new SqlConnection(connect);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ID = Convert.ToInt32(reader["ID"].ToString());
                }
                id = ID + 1;
                conn.Close();
            }
            else
            {
                id = Convert.ToInt32(txt_ID.Text);
            }
            KopirajFajlPoTipu(txt_Slika.Text, txt_ID.Text, id);
        }

        private void btn_Otvori_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txt_Slika.Text);
        }
    }
}