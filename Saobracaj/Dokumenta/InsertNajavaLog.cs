using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Saobracaj.Dokumenta
{
    class InsertNajavaLog
    {
        string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public void insNajavaLog(string Izmenio,string Akcija,DateTime Datum,int ID,string BrojNajave,int Voz,int Posiljalac,int Prevoznik,int Otpravna, 
           int Uputna,int Primalac,int RobaNHM,string PrevozniPut,decimal Tezina,decimal Duzina,int BrojKola,int RID,DateTime PredvidjenoPrimanje,
           DateTime StvarnoPrimanje,DateTime PredvidjenaPredaja,DateTime StvarnaPredaja,int Status,string OnBroj,int Verzija,int Razlog,DateTime DatumUnosa,
           string RIDBroj,string Komentar,int VozP,int Granicna,int Platilac,int AdHoc,int PrevoznikZa,string Faktura,string Zadatak,int CIM,string Korisnik,
           string DispecerRID,int TipPrevoza,decimal NetoTezinaM,int PorudzbinaID,int ImaPovrat,int TehnologijaID,int RobaNhm2,string DodatnoPorudzbina,DateTime PomocniDatum)
        {
            
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_InsertNajavaLOG";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter izmenio = new SqlParameter();
            izmenio.ParameterName = "@Izmenio";
            izmenio.SqlDbType = SqlDbType.NVarChar;
            izmenio.Size = 50;
            izmenio.Direction = ParameterDirection.Input;
            izmenio.Value = Izmenio;
            cmd.Parameters.Add(izmenio);

            SqlParameter akcija = new SqlParameter();
            akcija.ParameterName = "@Akcija";
            akcija.SqlDbType = SqlDbType.NVarChar;
            akcija.Size = 50;
            akcija.Direction = ParameterDirection.Input;
            akcija.Value = Akcija;
            cmd.Parameters.Add(akcija);

            SqlParameter datum = new SqlParameter();
            datum.ParameterName = "@Datum";
            datum.SqlDbType = SqlDbType.DateTime;
            datum.Direction = ParameterDirection.Input;
            datum.Value = Datum;
            cmd.Parameters.Add(datum);

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            SqlParameter najava = new SqlParameter();
            najava.ParameterName = "@BrojNajave";
            najava.SqlDbType = SqlDbType.NVarChar;
            najava.Size = 50;
            najava.Direction = ParameterDirection.Input;
            najava.Value = BrojNajave;
            cmd.Parameters.Add(najava);

            SqlParameter voz = new SqlParameter();
            voz.ParameterName = "@Voz";
            voz.SqlDbType = SqlDbType.Int;
            voz.Direction = ParameterDirection.Input;
            voz.Value = Voz;
            cmd.Parameters.Add(voz);

            SqlParameter posiljalac = new SqlParameter();
            posiljalac.ParameterName = "@Posiljalac";
            posiljalac.SqlDbType = SqlDbType.Int;
            posiljalac.Direction = ParameterDirection.Input;
            posiljalac.Value = Posiljalac;
            cmd.Parameters.Add(posiljalac);

            SqlParameter prevoznik = new SqlParameter();
            prevoznik.ParameterName = "@Prevoznik";
            prevoznik.SqlDbType = SqlDbType.Int;
            prevoznik.Direction = ParameterDirection.Input;
            prevoznik.Value = Prevoznik;
            cmd.Parameters.Add(prevoznik);

            SqlParameter otpravna = new SqlParameter();
            otpravna.ParameterName = "@Otpravna";
            otpravna.SqlDbType = SqlDbType.Int;
            otpravna.Direction = ParameterDirection.Input;
            otpravna.Value = Otpravna;
            cmd.Parameters.Add(otpravna);

            SqlParameter uputna = new SqlParameter();
            uputna.ParameterName="@Uputna";
            uputna.SqlDbType = SqlDbType.Int;
            uputna.Direction = ParameterDirection.Input;
            uputna.Value = Uputna;
            cmd.Parameters.Add(uputna);

            SqlParameter primalac = new SqlParameter();
            primalac.ParameterName = "@Primalac";
            primalac.SqlDbType = SqlDbType.Int;
            primalac.Direction = ParameterDirection.Input;
            primalac.Value = Primalac;
            cmd.Parameters.Add(primalac);

            SqlParameter roba = new SqlParameter();
            roba.ParameterName = "@RobaNHM";
            roba.SqlDbType = SqlDbType.Int;
            roba.Direction = ParameterDirection.Input;
            roba.Value = RobaNHM;
            cmd.Parameters.Add(roba);

            SqlParameter put = new SqlParameter();
            put.ParameterName = "@PrevozniPut";
            put.SqlDbType = SqlDbType.NVarChar;
            put.Size = 50;
            put.Direction = ParameterDirection.Input;
            put.Value = PrevozniPut;
            cmd.Parameters.Add(put);

            SqlParameter tezina = new SqlParameter();
            tezina.ParameterName = "@Tezina";
            tezina.SqlDbType = SqlDbType.Decimal;
            tezina.Direction = ParameterDirection.Input;
            tezina.Value = Tezina;
            cmd.Parameters.Add(tezina);

            SqlParameter duzina = new SqlParameter();
            duzina.ParameterName = "@Duzina";
            duzina.SqlDbType = SqlDbType.Decimal;
            duzina.Direction = ParameterDirection.Input;
            duzina.Value = Duzina;
            cmd.Parameters.Add(duzina);

            SqlParameter kola = new SqlParameter();
            kola.ParameterName = "@BrojKola";
            kola.SqlDbType = SqlDbType.Int;
            kola.Direction = ParameterDirection.Input;
            kola.Value = BrojKola;
            cmd.Parameters.Add(kola);

            SqlParameter rid = new SqlParameter();
            rid.ParameterName = "@RID";
            rid.SqlDbType = SqlDbType.Int;
            rid.Direction = ParameterDirection.Input;
            rid.Value = RID;
            cmd.Parameters.Add(rid);

            SqlParameter pPrimanje = new SqlParameter();
            pPrimanje.ParameterName = "@PredvidjenoPrimanje";
            pPrimanje.SqlDbType = SqlDbType.DateTime;
            pPrimanje.Direction = ParameterDirection.Input;
            pPrimanje.Value = PredvidjenoPrimanje;
            cmd.Parameters.Add(pPrimanje);

            SqlParameter sPrimanje = new SqlParameter();
            sPrimanje.ParameterName = "@StvarnoPrimanje";
            sPrimanje.SqlDbType = SqlDbType.DateTime;
            sPrimanje.Direction = ParameterDirection.Input;
            sPrimanje.Value = StvarnoPrimanje;
            cmd.Parameters.Add(sPrimanje);

            SqlParameter pPredaja = new SqlParameter();
            pPredaja.ParameterName = "@PredvidjenaPredaja";
            pPredaja.SqlDbType = SqlDbType.Date;
            pPredaja.Direction = ParameterDirection.Input;
            pPredaja.Value = PredvidjenaPredaja;
            cmd.Parameters.Add(pPredaja);

            SqlParameter sPredaja = new SqlParameter();
            sPredaja.ParameterName = "@StvarnaPredaja";
            sPredaja.SqlDbType = SqlDbType.DateTime;
            sPredaja.Direction = ParameterDirection.Input;
            sPredaja.Value = StvarnaPredaja;
            cmd.Parameters.Add(sPredaja);

            SqlParameter status = new SqlParameter();
            status.ParameterName = "@Status";
            status.SqlDbType = SqlDbType.Int;
            status.Direction = ParameterDirection.Input;
            status.Value = Status;
            cmd.Parameters.Add(status);

            SqlParameter onB = new SqlParameter();
            onB.ParameterName = "@OnBroj";
            onB.SqlDbType = SqlDbType.NVarChar;
            onB.Size = 50;
            onB.Direction = ParameterDirection.Input;
            onB.Value = OnBroj;
            cmd.Parameters.Add(onB);

            SqlParameter verzija = new SqlParameter();
            verzija.ParameterName = "@Verzija";
            verzija.SqlDbType = SqlDbType.Int;
            verzija.Direction = ParameterDirection.Input;
            verzija.Value = Verzija;
            cmd.Parameters.Add(verzija);

            SqlParameter razlog = new SqlParameter();
            razlog.ParameterName = "@Razlog";
            razlog.SqlDbType = SqlDbType.Int;
            razlog.Direction = ParameterDirection.Input;
            razlog.Value = Razlog;
            cmd.Parameters.Add(razlog);

            SqlParameter datumUnosa = new SqlParameter();
            datumUnosa.ParameterName = "@DatumUnosa";
            datumUnosa.SqlDbType = SqlDbType.DateTime;
            datumUnosa.Direction = ParameterDirection.Input;
            datumUnosa.Value = DatumUnosa;
            cmd.Parameters.Add(datumUnosa);

            SqlParameter ridB = new SqlParameter();
            ridB.ParameterName = "@RIDBroj";
            ridB.SqlDbType = SqlDbType.NVarChar;
            ridB.Size = 50;
            ridB.Direction = ParameterDirection.Input;
            ridB.Value = RIDBroj;
            cmd.Parameters.Add(ridB);

            SqlParameter komentar = new SqlParameter();
            komentar.ParameterName = "@Komentar";
            komentar.SqlDbType = SqlDbType.NVarChar;
            komentar.Size = 500;
            komentar.Direction = ParameterDirection.Input;
            komentar.Value = Komentar;
            cmd.Parameters.Add(komentar);

            SqlParameter vozP = new SqlParameter();
            vozP.ParameterName = "@VozP";
            vozP.SqlDbType = SqlDbType.Int;
            vozP.Direction = ParameterDirection.Input;
            vozP.Value = VozP;
            cmd.Parameters.Add(vozP);

            SqlParameter granicna = new SqlParameter();
            granicna.ParameterName = "@Granicna";
            granicna.SqlDbType = SqlDbType.Int;
            granicna.Direction = ParameterDirection.Input;
            granicna.Value = Granicna;
            cmd.Parameters.Add(granicna);

            SqlParameter platilac = new SqlParameter();
            platilac.ParameterName = "@Platilac";
            platilac.SqlDbType = SqlDbType.Int;
            platilac.Direction = ParameterDirection.Input;
            platilac.Value = Platilac;
            cmd.Parameters.Add(platilac);

            SqlParameter ad = new SqlParameter();
            ad.ParameterName = "@AdHoc";
            ad.SqlDbType = SqlDbType.Int;
            ad.Direction = ParameterDirection.Input;
            ad.Value = AdHoc;
            cmd.Parameters.Add(ad);

            SqlParameter prevoznikZa = new SqlParameter();
            prevoznikZa.ParameterName = "@PrevoznikZa";
            prevoznikZa.SqlDbType = SqlDbType.Int;
            prevoznikZa.Direction = ParameterDirection.Input;
            prevoznikZa.Value = PrevoznikZa;
            cmd.Parameters.Add(prevoznikZa);

            SqlParameter faktura = new SqlParameter();
            faktura.ParameterName = "@Faktura";
            faktura.SqlDbType = SqlDbType.NVarChar;
            faktura.Size = 30;
            faktura.Direction = ParameterDirection.Input;
            faktura.Value = Faktura;
            cmd.Parameters.Add(faktura);

            SqlParameter zadatak = new SqlParameter();
            zadatak.ParameterName = "@Zadatak";
            zadatak.SqlDbType = SqlDbType.NVarChar;
            zadatak.Size = 90;
            zadatak.Direction = ParameterDirection.Input;
            zadatak.Value = Zadatak;
            cmd.Parameters.Add(zadatak);

            SqlParameter cim = new SqlParameter();
            cim.ParameterName = "@CIM";
            cim.SqlDbType = SqlDbType.Int;
            cim.Direction = ParameterDirection.Input;
            cim.Value = CIM;
            cmd.Parameters.Add(cim);

            SqlParameter korisnik = new SqlParameter();
            korisnik.ParameterName = "@Korisnik";
            korisnik.SqlDbType = SqlDbType.NVarChar;
            korisnik.Size = 50;
            korisnik.Direction = ParameterDirection.Input;
            korisnik.Value = Korisnik;
            cmd.Parameters.Add(korisnik);

            SqlParameter dispecer = new SqlParameter();
            dispecer.ParameterName = "@DispecerRID";
            dispecer.SqlDbType = SqlDbType.NVarChar;
            dispecer.Size = 50;
            dispecer.Direction = ParameterDirection.Input;
            dispecer.Value = DispecerRID;
            cmd.Parameters.Add(dispecer);

            SqlParameter tip = new SqlParameter();
            tip.ParameterName = "@TipPrevoza";
            tip.SqlDbType = SqlDbType.Int;
            tip.Direction = ParameterDirection.Input;
            tip.Value = TipPrevoza;
            cmd.Parameters.Add(tip);

            SqlParameter neto = new SqlParameter();
            neto.ParameterName = "@NetoTezinaM";
            neto.SqlDbType = SqlDbType.Decimal;
            neto.Direction = ParameterDirection.Input;
            neto.Value = NetoTezinaM;
            cmd.Parameters.Add(neto);

            SqlParameter porudzbina = new SqlParameter();
            porudzbina.ParameterName = "@PorudzbinaID";
            porudzbina.SqlDbType = SqlDbType.Int;
            porudzbina.Direction = ParameterDirection.Input;
            porudzbina.Value = PorudzbinaID;
            cmd.Parameters.Add(porudzbina);

            SqlParameter povrat = new SqlParameter();
            povrat.ParameterName = "@ImaPovrat";
            povrat.SqlDbType = SqlDbType.Int;
            povrat.Direction = ParameterDirection.Input;
            povrat.Value = ImaPovrat;
            cmd.Parameters.Add(povrat);

            SqlParameter teh = new SqlParameter();
            teh.ParameterName = "@TehnologijaID";
            teh.SqlDbType = SqlDbType.Int;
            teh.Direction = ParameterDirection.Input;
            teh.Value = TehnologijaID;
            cmd.Parameters.Add(teh);

            SqlParameter roba2 = new SqlParameter();
            roba2.ParameterName = "@RobaNhm2";
            roba2.SqlDbType = SqlDbType.Int;
            roba2.Direction = ParameterDirection.Input;
            roba2.Value = RobaNhm2;
            cmd.Parameters.Add(roba2);

            SqlParameter por = new SqlParameter();
            por.ParameterName = "@DodatnoPorudzbina";
            por.SqlDbType = SqlDbType.NVarChar;
            por.Size = 500;
            por.Direction = ParameterDirection.Input;
            por.Value = DodatnoPorudzbina;
            cmd.Parameters.Add(por);

            SqlParameter pDat = new SqlParameter();
            pDat.ParameterName = "@PomocniDatum";
            pDat.SqlDbType = SqlDbType.DateTime;
            pDat.Direction = ParameterDirection.Input;
            pDat.Value = PomocniDatum;
            cmd.Parameters.Add(pDat);


            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
            }
            catch (SqlException ex)
            {
                //throw new Exception("Neuspešan upis");
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Upis LOG-a nije uspelo", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                if (error)
                {
                    
                }
            }
        }
    }
}
