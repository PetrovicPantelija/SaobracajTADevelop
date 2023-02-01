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
    public partial class frmMapaOpis : Form
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        int marker = Dokumenta.frmMapa.stanicaMarker;
        int partner = Dokumenta.frmMapa.partner;
        int najava = Dokumenta.frmMapa.najava;

        public frmMapaOpis()
        {
            InitializeComponent();
            if (marker > 0)
            {
                Marker();
            }
            if (partner > 0)
            {
                Partner();
            }
            if (najava > 0)
            {
                Najava();
            }
        }

        private void Marker()
        {
            var query = "select n.ID,n.BrojNajave,n.Voz,n.Posiljalac,RTrim(Partnerji.PaNaziv) as PosiljalacNaziv,n.Prevoznik,RTrim(partnerji_1.PaNaziv) as PRevozinkNaziv,n.Otpravna," +
                "RTrim(stanice.Opis) as OTOpis,n.Uputna,RTrim(stanice_1.Opis) as UPOpis,n.Primalac,RTrim(partnerji_2.PaNaziv) as PrimalacNaziv,n.RobaNHM,n.PrevozniPut,n.Tezina,n.Duzina," +
                "n.BrojKola,n.RID,n.PredvidjenoPrimanje,n.StvarnoPrimanje,n.PredvidjenaPredaja,n.StvarnaPredaja,n.Status,n.OnBroj,n.Verzija,n.Razlog,n.DatumUnosa,n.RIDBroj,n.Komentar," +
                "n.VozP,n.Granicna,RTrim(stanice_2.Opis) as GranicnaOpis,n.Platilac,RTrim(partnerji_3.PaNaziv) as PlatilacNaziv,n.AdHoc,n.PrevoznikZa," +
                "RTrim(partnerji_4.PaNaziv) as PrevoznikNaziv,n.faktura,n.Zadatak,n.CIM,n.Korisnik,n.DispecerRID,n.TipPrevoza,n.NetoTezinaM,n.PorudzbinaID,n.ImaPovrat,n.TehnologijaID," +
                "n.RobaNHM,n.DodatnoPorudznina,n.PomocniDatum " +
                "From Najava n " +
                "inner join partnerji on partnerji.PaSifra = n.Posiljalac " +
                "inner join partnerji as partnerji_1 on partnerji_1.PaSifra = n.Prevoznik " +
                "inner join partnerji as partnerji_2 on partnerji_2.PaSifra = n.Primalac " +
                "inner join partnerji as partnerji_3 on partnerji_3.PaSifra = n.Platilac " +
                "inner join partnerji as partnerji_4 on partnerji_4.PaSifra = n.PrevoznikZa " +
                "inner join stanice on stanice.id = n.Otpravna " +
                "inner join stanice as stanice_1 on stanice_1.id = n.Uputna " +
                "inner join stanice as stanice_2 on stanice_2.ID = n.Granicna " +
                "where n.granicna = " + marker + " and Status<>7 and status<>9";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 50; //id
            dataGridView1.Columns[1].Width = 60; //brNajave
            dataGridView1.Columns[2].Width = 50; //Voz
            dataGridView1.Columns[3].Width = 55; //Posiljac
            dataGridView1.Columns[4].Width = 100; //Naziv
            dataGridView1.Columns[5].Width = 55; //Prevoznik
            dataGridView1.Columns[6].Width = 100; //Naziv
            dataGridView1.Columns[7].Width = 55; //Otpravna
            dataGridView1.Columns[8].HeaderText = "Mesto";
            dataGridView1.Columns[8].Width = 70;
            dataGridView1.Columns[9].Width = 50; //Uputna
            dataGridView1.Columns[10].HeaderText = "Mesto";
            dataGridView1.Columns[10].Width = 70;
            dataGridView1.Columns[11].Width = 50;//primalac
            dataGridView1.Columns[12].Width = 80;//naziv
            dataGridView1.Columns[13].Width = 60;//NHM
            dataGridView1.Columns[14].Width = 150;//prevozni put
            dataGridView1.Columns[15].Width = 50; //tezina
            dataGridView1.Columns[16].Width = 50; //duzina
            dataGridView1.Columns[17].Width = 50;//broj kola
            dataGridView1.Columns[18].Width = 50;//rid
            //19. predvidjeno primanje
            //20. stvarno primanje
            //21. predvidjena predaja
            //22. stvarna predaja
            dataGridView1.Columns[23].Width = 50; //status
            dataGridView1.Columns[24].Width = 65; //onBroj
            dataGridView1.Columns[25].Width = 50; //vrezija
            dataGridView1.Columns[26].Width = 50; //razlog
            //27. datum Unosa
            dataGridView1.Columns[28].Width = 65;//rid br
            dataGridView1.Columns[29].Width = 80; //komentar
            dataGridView1.Columns[30].Width = 50;//vozP
            dataGridView1.Columns[31].Width = 55; //granicna
            dataGridView1.Columns[32].Width = 75; //opis
            dataGridView1.Columns[33].Width = 50;//platilac'
            dataGridView1.Columns[34].Width = 100; //naziv
            dataGridView1.Columns[35].Width = 50;//ad hoc
            dataGridView1.Columns[36].Width = 70;//prevoznik za
            dataGridView1.Columns[37].Width = 100; //naziv
            //38. faktura
            dataGridView1.Columns[39].Width = 100;//zadatak
            dataGridView1.Columns[40].Width = 40; //cim
            //41. korisnik
            //42. dispecer
            dataGridView1.Columns[43].Width = 60;
            //44. neto
            //45. porudzbina
            dataGridView1.Columns[46].Width = 60; //imaPovrat
            dataGridView1.Columns[47].Width = 70; //tehnologijaID
            dataGridView1.Columns[48].Width = 60; //nhm1
            dataGridView1.Columns[49].Width = 120; //dodatno
            //50. pomocni datum

            string naziv = dataGridView1.Rows[0].Cells[32].Value.ToString();

            lbl_stanica.Text = naziv;
            int brKola = 0;
            double tezina = 0;
            double neto = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                brKola += Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[15].Value);
                neto += Convert.ToDouble(dataGridView1.Rows[i].Cells[44].Value);
            }
            lbl_kola.Text = brKola.ToString();
            lbl_tezina.Text = tezina.ToString();
            lbl_neto.Text = neto.ToString();
        }
        private void Partner()
        {
            var query = "select n.ID,n.BrojNajave,n.Voz,n.Posiljalac,RTrim(Partnerji.PaNaziv) as PosiljalacNaziv,n.Prevoznik,RTrim(partnerji_1.PaNaziv) as PRevozinkNaziv," +
                "n.Otpravna,RTrim(stanice.Opis) as OTOpis,n.Uputna,RTrim(stanice_1.Opis) as UPOpis,n.Primalac,RTrim(partnerji_2.PaNaziv) as PrimalacNaziv," +
                "n.RobaNHM,n.PrevozniPut,n.Tezina,n.Duzina,n.BrojKola,n.RID,n.PredvidjenoPrimanje,n.StvarnoPrimanje,n.PredvidjenaPredaja,n.StvarnaPredaja," +
                "n.Status,n.OnBroj,n.Verzija,n.Razlog,n.DatumUnosa,n.RIDBroj,n.Komentar,n.VozP,n.Granicna,RTrim(stanice_2.Opis) as GranicnaOpis,n.Platilac," +
                "RTrim(partnerji_3.PaNaziv) as PlatilacNaziv,n.AdHoc,n.PrevoznikZa,RTrim(partnerji_4.PaNaziv) as PrevoznikNaziv,n.faktura,n.Zadatak,n.CIM," +
                "n.Korisnik,n.DispecerRID,n.TipPrevoza,n.NetoTezinaM,n.PorudzbinaID,n.ImaPovrat,n.TehnologijaID,n.RobaNHM,n.DodatnoPorudznina,n.PomocniDatum " +
                "From Najava n " +
                "inner join partnerji on partnerji.PaSifra = n.Posiljalac " +
                "inner join partnerji as partnerji_1 on partnerji_1.PaSifra = n.Prevoznik " +
                "inner join partnerji as partnerji_2 on partnerji_2.PaSifra = n.Primalac " +
                "inner join partnerji as partnerji_3 on partnerji_3.PaSifra = n.Platilac " +
                "inner join partnerji as partnerji_4 on partnerji_4.PaSifra = n.PrevoznikZa " +
                "inner join stanice on stanice.id = n.Otpravna " +
                "inner join stanice as stanice_1 on stanice_1.id = n.Uputna " +
                "inner join stanice as stanice_2 on stanice_2.ID = n.Granicna " +
                "where n.Platilac = " + partner + " and Status<>7 and status<>9";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 50; //id
            dataGridView1.Columns[1].Width = 60; //brNajave
            dataGridView1.Columns[2].Width = 50; //Voz
            dataGridView1.Columns[3].Width = 55; //Posiljac
            dataGridView1.Columns[4].Width = 100; //Naziv
            dataGridView1.Columns[5].Width = 55; //Prevoznik
            dataGridView1.Columns[6].Width = 100; //Naziv
            dataGridView1.Columns[7].Width = 55; //Otpravna
            dataGridView1.Columns[8].HeaderText = "Mesto";
            dataGridView1.Columns[8].Width = 70;
            dataGridView1.Columns[9].Width = 50; //Uputna
            dataGridView1.Columns[10].HeaderText = "Mesto";
            dataGridView1.Columns[10].Width = 70;
            dataGridView1.Columns[11].Width = 50;//primalac
            dataGridView1.Columns[12].Width = 80;//naziv
            dataGridView1.Columns[13].Width = 60;//NHM
            dataGridView1.Columns[14].Width = 150;//prevozni put
            dataGridView1.Columns[15].Width = 50; //tezina
            dataGridView1.Columns[16].Width = 50; //duzina
            dataGridView1.Columns[17].Width = 50;//broj kola
            dataGridView1.Columns[18].Width = 50;//rid
            //19. predvidjeno primanje
            //20. stvarno primanje
            //21. predvidjena predaja
            //22. stvarna predaja
            dataGridView1.Columns[23].Width = 50; //status
            dataGridView1.Columns[24].Width = 65; //onBroj
            dataGridView1.Columns[25].Width = 50; //vrezija
            dataGridView1.Columns[26].Width = 50; //razlog
            //27. datum Unosa
            dataGridView1.Columns[28].Width = 65;//rid br
            dataGridView1.Columns[29].Width = 80; //komentar
            dataGridView1.Columns[30].Width = 50;//vozP
            dataGridView1.Columns[31].Width = 55; //granicna
            dataGridView1.Columns[32].Width = 75; //opis
            dataGridView1.Columns[33].Width = 50;//platilac'
            dataGridView1.Columns[34].Width = 100; //naziv
            dataGridView1.Columns[35].Width = 50;//ad hoc
            dataGridView1.Columns[36].Width = 70;//prevoznik za
            dataGridView1.Columns[37].Width = 100; //naziv
            //38. faktura
            dataGridView1.Columns[39].Width = 100;//zadatak
            dataGridView1.Columns[40].Width = 40; //cim
            //41. korisnik
            //42. dispecer
            dataGridView1.Columns[43].Width = 60;
            //44. neto
            //45. porudzbina
            dataGridView1.Columns[46].Width = 60; //imaPovrat
            dataGridView1.Columns[47].Width = 70; //tehnologijaID
            dataGridView1.Columns[48].Width = 60; //nhm1
            dataGridView1.Columns[49].Width = 120; //dodatno
            //50. pomocni datum

            string naziv = dataGridView1.Rows[0].Cells[34].Value.ToString();
            label1.Text = "Partner:";

            lbl_stanica.Text = naziv;
            int brKola = 0;
            double tezina = 0;
            double neto = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                brKola += Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[15].Value);
                neto += Convert.ToDouble(dataGridView1.Rows[i].Cells[44].Value);
            }
            lbl_kola.Text = brKola.ToString();
            lbl_tezina.Text = tezina.ToString();
            lbl_neto.Text = neto.ToString();
        }
        private void Najava()
        {
            var query = "select n.ID,n.BrojNajave,n.Voz,n.Posiljalac,RTrim(Partnerji.PaNaziv) as PosiljalacNaziv,n.Prevoznik,RTrim(partnerji_1.PaNaziv) as PRevozinkNaziv,n.Otpravna," +
                 "RTrim(stanice.Opis) as OTOpis,n.Uputna,RTrim(stanice_1.Opis) as UPOpis,n.Primalac,RTrim(partnerji_2.PaNaziv) as PrimalacNaziv,n.RobaNHM,n.PrevozniPut,n.Tezina,n.Duzina," +
                 "n.BrojKola,n.RID,n.PredvidjenoPrimanje,n.StvarnoPrimanje,n.PredvidjenaPredaja,n.StvarnaPredaja,n.Status,n.OnBroj,n.Verzija,n.Razlog,n.DatumUnosa,n.RIDBroj,n.Komentar," +
                 "n.VozP,n.Granicna,RTrim(stanice_2.Opis) as GranicnaOpis,n.Platilac,RTrim(partnerji_3.PaNaziv) as PlatilacNaziv,n.AdHoc,n.PrevoznikZa," +
                 "RTrim(partnerji_4.PaNaziv) as PrevoznikNaziv,n.faktura,n.Zadatak,n.CIM,n.Korisnik,n.DispecerRID,n.TipPrevoza,n.NetoTezinaM,n.PorudzbinaID,n.ImaPovrat,n.TehnologijaID," +
                 "n.RobaNHM,n.DodatnoPorudznina,n.PomocniDatum " +
                 "From Najava n " +
                 "inner join partnerji on partnerji.PaSifra = n.Posiljalac " +
                 "inner join partnerji as partnerji_1 on partnerji_1.PaSifra = n.Prevoznik " +
                 "inner join partnerji as partnerji_2 on partnerji_2.PaSifra = n.Primalac " +
                 "inner join partnerji as partnerji_3 on partnerji_3.PaSifra = n.Platilac " +
                 "inner join partnerji as partnerji_4 on partnerji_4.PaSifra = n.PrevoznikZa " +
                 "inner join stanice on stanice.id = n.Otpravna " +
                 "inner join stanice as stanice_1 on stanice_1.id = n.Uputna " +
                 "inner join stanice as stanice_2 on stanice_2.ID = n.Granicna " +
                 "where n.ID = " + najava + " and Status<>7 and status<>9";
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 50; //id
            dataGridView1.Columns[1].Width = 60; //brNajave
            dataGridView1.Columns[2].Width = 50; //Voz
            dataGridView1.Columns[3].Width = 55; //Posiljac
            dataGridView1.Columns[4].Width = 100; //Naziv
            dataGridView1.Columns[5].Width = 55; //Prevoznik
            dataGridView1.Columns[6].Width = 100; //Naziv
            dataGridView1.Columns[7].Width = 55; //Otpravna
            dataGridView1.Columns[8].HeaderText = "Mesto";
            dataGridView1.Columns[8].Width = 70;
            dataGridView1.Columns[9].Width = 50; //Uputna
            dataGridView1.Columns[10].HeaderText = "Mesto";
            dataGridView1.Columns[10].Width = 70;
            dataGridView1.Columns[11].Width = 50;//primalac
            dataGridView1.Columns[12].Width = 80;//naziv
            dataGridView1.Columns[13].Width = 60;//NHM
            dataGridView1.Columns[14].Width = 150;//prevozni put
            dataGridView1.Columns[15].Width = 50; //tezina
            dataGridView1.Columns[16].Width = 50; //duzina
            dataGridView1.Columns[17].Width = 50;//broj kola
            dataGridView1.Columns[18].Width = 50;//rid
            //19. predvidjeno primanje
            //20. stvarno primanje
            //21. predvidjena predaja
            //22. stvarna predaja
            dataGridView1.Columns[23].Width = 50; //status
            dataGridView1.Columns[24].Width = 65; //onBroj
            dataGridView1.Columns[25].Width = 50; //vrezija
            dataGridView1.Columns[26].Width = 50; //razlog
            //27. datum Unosa
            dataGridView1.Columns[28].Width = 65;//rid br
            dataGridView1.Columns[29].Width = 80; //komentar
            dataGridView1.Columns[30].Width = 50;//vozP
            dataGridView1.Columns[31].Width = 55; //granicna
            dataGridView1.Columns[32].Width = 75; //opis
            dataGridView1.Columns[33].Width = 50;//platilac'
            dataGridView1.Columns[34].Width = 100; //naziv
            dataGridView1.Columns[35].Width = 50;//ad hoc
            dataGridView1.Columns[36].Width = 70;//prevoznik za
            dataGridView1.Columns[37].Width = 100; //naziv
            //38. faktura
            dataGridView1.Columns[39].Width = 100;//zadatak
            dataGridView1.Columns[40].Width = 40; //cim
            //41. korisnik
            //42. dispecer
            dataGridView1.Columns[43].Width = 60;
            //44. neto
            //45. porudzbina
            dataGridView1.Columns[46].Width = 60; //imaPovrat
            dataGridView1.Columns[47].Width = 70; //tehnologijaID
            dataGridView1.Columns[48].Width = 60; //nhm1
            dataGridView1.Columns[49].Width = 120; //dodatno
            //50. pomocni datum

            string naziv = dataGridView1.Rows[0].Cells[32].Value.ToString();

            lbl_stanica.Text = naziv;
            int brKola = 0;
            double tezina = 0;
            double neto = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                brKola += Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                tezina += Convert.ToDouble(dataGridView1.Rows[i].Cells[15].Value);
                neto += Convert.ToDouble(dataGridView1.Rows[i].Cells[44].Value);
            }
            lbl_kola.Text = brKola.ToString();
            lbl_tezina.Text = tezina.ToString();
            lbl_neto.Text = neto.ToString();
        }
    }
}
