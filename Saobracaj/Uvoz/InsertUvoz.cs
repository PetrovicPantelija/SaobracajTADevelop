using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Saobracaj.Uvoz
{
    class InsertUvoz
    {
        string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.TestiranjeConnectionString"].ConnectionString;
        public void UpdUvoz(int ID,DateTime ETABroda,DateTime ATABroda,string Status,string BrojKont,int TipKont,DateTime DobijenNalog,string DobijeBZ,string Napomena,
            string PIN,int DirigacijaKont,int NazivBroda,string BTeretnica,int ADR,int Vlasnik,int Buking,string Nalogodavac,string VrstaUsluge,int Uvoznik,int NHM,
            string NazivRobe,int SpedicijaGranicna,int SpedicijaRTC,int CarinskiPostupak,int PostupakRoba,int NacinPakovanja,int OdredisnaCarina,int OdredisnaSpedicija,
            string MestoIstovara,string KontaktOsoba,string Mail,string Plomba1,string Plomba2,decimal NetoRoba,decimal BrutoRoba,decimal TaraKont,decimal BrutoKont,
            int NapomenaPoz,DateTime ATAOtpreme,int BrojVoza,string Relacija,DateTime ATADolazak, decimal Koleta, int RLTerminali
            , string Napomena1, string VrstaPregleda, int Nalogodavac1, string Ref1, int Nalogodavac2,
string Ref2, int Nalogodavac3, string Ref3, int Brodar)
        {

             

              

            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateUvoz";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            SqlParameter etaBroda = new SqlParameter();
            etaBroda.ParameterName = "@EtaBroda";
            etaBroda.SqlDbType = SqlDbType.DateTime;
            etaBroda.Direction = ParameterDirection.Input;
            etaBroda.Value = ETABroda;
            cmd.Parameters.Add(etaBroda);

            SqlParameter ataBroda = new SqlParameter();
            ataBroda.ParameterName = "@AtaBroda";
            ataBroda.SqlDbType = SqlDbType.DateTime;
            ataBroda.Direction = ParameterDirection.Input;
            ataBroda.Value = ATABroda;
            cmd.Parameters.Add(ataBroda);

            SqlParameter status = new SqlParameter();
            status.ParameterName = "@StatusPrijema";
            status.SqlDbType = SqlDbType.NVarChar;
            status.Size = 50;
            status.Direction = ParameterDirection.Input;
            status.Value = Status;
            cmd.Parameters.Add(status);

            SqlParameter brojKont = new SqlParameter();
            brojKont.ParameterName = "@BrojKontejnera";
            brojKont.SqlDbType = SqlDbType.NVarChar;
            brojKont.Size = 50;
            brojKont.Direction = ParameterDirection.Input;
            brojKont.Value = BrojKont;
            cmd.Parameters.Add(brojKont);

            SqlParameter tipKont = new SqlParameter();
            tipKont.ParameterName = "@TipKontejnera";
            tipKont.SqlDbType = SqlDbType.Int;
            tipKont.Direction = ParameterDirection.Input;
            tipKont.Value = TipKont;
            cmd.Parameters.Add(tipKont);

            SqlParameter nalogBrod = new SqlParameter();
            nalogBrod.ParameterName = "@DobijenNalogBrodara";
            nalogBrod.SqlDbType = SqlDbType.DateTime;
            nalogBrod.Direction = ParameterDirection.Input;
            nalogBrod.Value = DobijenNalog;
            cmd.Parameters.Add(nalogBrod);

            SqlParameter bz = new SqlParameter();
            bz.ParameterName = "@DobijeBZ";
            bz.SqlDbType = SqlDbType.NVarChar;
            bz.Size = 50;
            bz.Direction = ParameterDirection.Input;
            bz.Value = DobijeBZ;
            cmd.Parameters.Add(bz);

            SqlParameter napomena = new SqlParameter();
            napomena.ParameterName = "@Napomena";
            napomena.SqlDbType = SqlDbType.NVarChar;
            napomena.Size = 50;
            napomena.Direction = ParameterDirection.Input;
            napomena.Value = Napomena;
            cmd.Parameters.Add(napomena);

            SqlParameter pin = new SqlParameter();
            pin.ParameterName = "@PIN";
            pin.SqlDbType = SqlDbType.NVarChar;
            pin.Size = 50;
            pin.Direction = ParameterDirection.Input;
            pin.Value = PIN;
            cmd.Parameters.Add(pin);

            SqlParameter dirigacija = new SqlParameter();
            dirigacija.ParameterName = "@DirigacijaKontejeraZa";
            dirigacija.SqlDbType = SqlDbType.Int;
            dirigacija.Direction = ParameterDirection.Input;
            dirigacija.Value = DirigacijaKont;
            cmd.Parameters.Add(dirigacija);

            SqlParameter brod = new SqlParameter();
            brod.ParameterName = "@NazivBroda";
            brod.SqlDbType = SqlDbType.Int;
            brod.Direction = ParameterDirection.Input;
            brod.Value = NazivBroda;
            cmd.Parameters.Add(brod);

            SqlParameter teretnica = new SqlParameter();
            teretnica.ParameterName = "@BrodskaTeretnica";
            teretnica.SqlDbType = SqlDbType.NVarChar;
            teretnica.Size = 50;
            teretnica.Direction = ParameterDirection.Input;
            teretnica.Value = BTeretnica;
            cmd.Parameters.Add(teretnica);

            SqlParameter adr = new SqlParameter();
            adr.ParameterName = "@ADR";
            adr.SqlDbType = SqlDbType.Int;
            adr.Direction = ParameterDirection.Input;
            adr.Value = ADR;
            cmd.Parameters.Add(adr);

            SqlParameter vlasnik = new SqlParameter();
            vlasnik.ParameterName = "@VlasnikKontejnera";
            vlasnik.SqlDbType = SqlDbType.Int;
            vlasnik.Direction = ParameterDirection.Input;
            vlasnik.Value = Vlasnik;
            cmd.Parameters.Add(vlasnik);

            SqlParameter buking = new SqlParameter();
            buking.ParameterName = "@BukingBrodara";
            buking.SqlDbType = SqlDbType.Int;
            buking.Direction = ParameterDirection.Input;
            buking.Value = Buking;
            cmd.Parameters.Add(buking);

            SqlParameter nalogodavac = new SqlParameter();
            nalogodavac.ParameterName = "@Nalogodavac";
            nalogodavac.SqlDbType = SqlDbType.NVarChar;
            nalogodavac.Size = 50;
            nalogodavac.Direction = ParameterDirection.Input;
            nalogodavac.Value = Nalogodavac;
            cmd.Parameters.Add(nalogodavac);

            SqlParameter usluga = new SqlParameter();
            usluga.ParameterName = "@VrstaUsluge";
            usluga.SqlDbType = SqlDbType.NVarChar;
            usluga.Size = 50;
            usluga.Direction = ParameterDirection.Input;
            usluga.Value = VrstaUsluge;
            cmd.Parameters.Add(usluga);

            SqlParameter uvoznik = new SqlParameter();
            uvoznik.ParameterName = "@Uvoznik";
            uvoznik.SqlDbType = SqlDbType.Int;
            uvoznik.Direction = ParameterDirection.Input;
            uvoznik.Value = Uvoznik;
            cmd.Parameters.Add(uvoznik);

            SqlParameter nhm = new SqlParameter();
            nhm.ParameterName = "@NHMBroj";
            nhm.SqlDbType = SqlDbType.Int;
            nhm.Direction = ParameterDirection.Input;
            nhm.Value = NHM;
            cmd.Parameters.Add(nhm);

            SqlParameter nazivRobe = new SqlParameter();
            nazivRobe.ParameterName = "@NazivRobe";
            nazivRobe.SqlDbType = SqlDbType.NVarChar;
            nazivRobe.Size = 50;
            nazivRobe.Direction = ParameterDirection.Input;
            nazivRobe.Value = NazivRobe;
            cmd.Parameters.Add(nazivRobe);

            SqlParameter spedicijaG = new SqlParameter();
            spedicijaG.ParameterName = "@SpedicijaGranica";
            spedicijaG.SqlDbType = SqlDbType.Int;
            spedicijaG.Direction = ParameterDirection.Input;
            spedicijaG.Value = SpedicijaGranicna;
            cmd.Parameters.Add(spedicijaG);

            SqlParameter spedicijaR = new SqlParameter();
            spedicijaR.ParameterName = "@SpedicijaRTC";
            spedicijaR.SqlDbType = SqlDbType.Int;
            spedicijaR.Direction = ParameterDirection.Input;
            spedicijaR.Value = SpedicijaRTC;
            cmd.Parameters.Add(spedicijaR);

            SqlParameter carinskiP = new SqlParameter();
            carinskiP.ParameterName = "@CarinskiPostupak";
            carinskiP.SqlDbType = SqlDbType.Int;
            carinskiP.Direction = ParameterDirection.Input;
            carinskiP.Value = CarinskiPostupak;
            cmd.Parameters.Add(carinskiP);

            SqlParameter postupakRoba = new SqlParameter();
            postupakRoba.ParameterName = "@PostupakSaRobom";
            postupakRoba.SqlDbType = SqlDbType.Int;
            postupakRoba.Direction = ParameterDirection.Input;
            postupakRoba.Value = PostupakRoba;
            cmd.Parameters.Add(postupakRoba);

            SqlParameter pakovanje = new SqlParameter();
            pakovanje.ParameterName = "@NacinPakovanja";
            pakovanje.SqlDbType = SqlDbType.Int;
            pakovanje.Direction = ParameterDirection.Input;
            pakovanje.Value = NacinPakovanja;
            cmd.Parameters.Add(pakovanje);

            SqlParameter odCarina = new SqlParameter();
            odCarina.ParameterName = "@OdredisnaCarina";
            odCarina.SqlDbType = SqlDbType.Int;
            odCarina.Direction = ParameterDirection.Input;
            odCarina.Value = OdredisnaCarina;
            cmd.Parameters.Add(odCarina);

            SqlParameter odSpedicija = new SqlParameter();
            odSpedicija.ParameterName = "@OdredisnaSpedicija";
            odSpedicija.SqlDbType = SqlDbType.Int;
            odSpedicija.Direction = ParameterDirection.Input;
            odSpedicija.Value = OdredisnaSpedicija;
            cmd.Parameters.Add(odSpedicija);

            SqlParameter mesto = new SqlParameter();
            mesto.ParameterName = "@MestoIstovara";
            mesto.SqlDbType = SqlDbType.NVarChar;
            mesto.Size = 50;
            mesto.Direction = ParameterDirection.Input;
            mesto.Value = MestoIstovara;
            cmd.Parameters.Add(mesto);

            SqlParameter kontakt = new SqlParameter();
            kontakt.ParameterName = "@KontaktOsoba";
            kontakt.SqlDbType = SqlDbType.NVarChar;
            kontakt.Size = 50;
            kontakt.Direction = ParameterDirection.Input;
            kontakt.Value = KontaktOsoba;
            cmd.Parameters.Add(kontakt);

            SqlParameter mail = new SqlParameter();
            mail.ParameterName = "@Email";
            mail.SqlDbType = SqlDbType.NVarChar;
            mail.Size = 50;
            mail.Direction = ParameterDirection.Input;
            mail.Value = Mail;
            cmd.Parameters.Add(mail);

            SqlParameter plomba1 = new SqlParameter();
            plomba1.ParameterName = "@BrojPlombe1";
            plomba1.SqlDbType = SqlDbType.NVarChar;
            plomba1.Size = 50;
            plomba1.Direction = ParameterDirection.Input;
            plomba1.Value = Plomba1;
            cmd.Parameters.Add(plomba1);

            SqlParameter plomba2 = new SqlParameter();
            plomba2.ParameterName = "@BrojPlombe2";
            plomba2.SqlDbType = SqlDbType.NVarChar;
            plomba2.Size = 50;
            plomba2.Direction = ParameterDirection.Input;
            plomba2.Value = Plomba2;
            cmd.Parameters.Add(plomba2);

            SqlParameter netoR = new SqlParameter();
            netoR.ParameterName = "@NetoRobe";
            netoR.SqlDbType = SqlDbType.Decimal;
            netoR.Direction = ParameterDirection.Input;
            netoR.Value = NetoRoba;
            cmd.Parameters.Add(netoR);

            SqlParameter brutoR = new SqlParameter();
            brutoR.ParameterName = "@BrutoRobe";
            brutoR.SqlDbType = SqlDbType.Decimal;
            brutoR.Direction = ParameterDirection.Input;
            brutoR.Value = BrutoRoba;
            cmd.Parameters.Add(brutoR);

            SqlParameter taraK = new SqlParameter();
            taraK.ParameterName = "@TaraKontejnera";
            taraK.SqlDbType = SqlDbType.Decimal;
            taraK.Direction = ParameterDirection.Input;
            taraK.Value = TaraKont;
            cmd.Parameters.Add(taraK);

            SqlParameter brutoK = new SqlParameter();
            brutoK.ParameterName = "@BrutoKontejnera";
            brutoK.SqlDbType = SqlDbType.Decimal;
            brutoK.Direction = ParameterDirection.Input;
            brutoK.Value = BrutoKont;
            cmd.Parameters.Add(brutoK);

            SqlParameter napomenaP = new SqlParameter();
            napomenaP.ParameterName = "@NapomenaZaPozicioniranje";
            napomenaP.SqlDbType = SqlDbType.Int;
            napomenaP.Direction = ParameterDirection.Input;
            napomenaP.Value = NapomenaPoz;
            cmd.Parameters.Add(napomenaP);

            SqlParameter ataO = new SqlParameter();
            ataO.ParameterName = "@AtaOtpreme";
            ataO.SqlDbType = SqlDbType.Date;
            ataO.Direction = ParameterDirection.Input;
            ataO.Value = ATAOtpreme;
            cmd.Parameters.Add(ataO);

            SqlParameter voz = new SqlParameter();
            voz.ParameterName = "@BrojVoza";
            voz.SqlDbType = SqlDbType.Int;
            voz.Direction = ParameterDirection.Input;
            voz.Value = BrojVoza;
            cmd.Parameters.Add(voz);

            SqlParameter relacija = new SqlParameter();
            relacija.ParameterName = "@RelacijaVoza";
            relacija.SqlDbType = SqlDbType.NVarChar;
            relacija.Size = 50;
            relacija.Direction = ParameterDirection.Input;
            relacija.Value = Relacija;
            cmd.Parameters.Add(relacija);

            SqlParameter ataD = new SqlParameter();
            ataD.ParameterName = "@AtaDolazak";
            ataD.SqlDbType = SqlDbType.DateTime;
            ataD.Direction = ParameterDirection.Input;
            ataD.Value = ATADolazak;
            cmd.Parameters.Add(ataD);

            SqlParameter koleta= new SqlParameter();
            koleta.ParameterName = "@Koleta";
            koleta.SqlDbType = SqlDbType.Decimal;
            koleta.Direction = ParameterDirection.Input;
            koleta.Value = Koleta;
            cmd.Parameters.Add(koleta);

            SqlParameter rlterminali = new SqlParameter();
            rlterminali.ParameterName = "@RLTerminali";
            rlterminali.SqlDbType = SqlDbType.Decimal;
            rlterminali.Direction = ParameterDirection.Input;
            rlterminali.Value = RLTerminali;
            cmd.Parameters.Add(rlterminali);

            SqlParameter napomena1 = new SqlParameter();
            napomena1.ParameterName = "@Napomena1";
            napomena1.SqlDbType = SqlDbType.NVarChar;
            napomena1.Size = 100;
            napomena1.Direction = ParameterDirection.Input;
            napomena1.Value = Napomena1;
            cmd.Parameters.Add(napomena1);

            SqlParameter vrstapregleda = new SqlParameter();
            vrstapregleda.ParameterName = "@VrstaPregleda";
            vrstapregleda.SqlDbType = SqlDbType.NVarChar;
            vrstapregleda.Size = 100;
            vrstapregleda.Direction = ParameterDirection.Input;
            vrstapregleda.Value = VrstaPregleda;
            cmd.Parameters.Add(vrstapregleda);

            SqlParameter nalogodavac1 = new SqlParameter();
            nalogodavac1.ParameterName = "@Nalogodavac1";
            nalogodavac1.SqlDbType = SqlDbType.Int;
            nalogodavac1.Direction = ParameterDirection.Input;
            nalogodavac1.Value = Nalogodavac1;
            cmd.Parameters.Add(nalogodavac1);

            SqlParameter ref1 = new SqlParameter();
            ref1.ParameterName = "@Ref1";
            ref1.SqlDbType = SqlDbType.NVarChar;
            ref1.Size = 100;
            ref1.Direction = ParameterDirection.Input;
            ref1.Value = Ref1;
            cmd.Parameters.Add(ref1);

            SqlParameter nalogodavac2 = new SqlParameter();
            nalogodavac2.ParameterName = "@Nalogodavac2";
            nalogodavac2.SqlDbType = SqlDbType.Int;
            nalogodavac2.Direction = ParameterDirection.Input;
            nalogodavac2.Value = Nalogodavac2;
            cmd.Parameters.Add(nalogodavac2);

            SqlParameter ref2 = new SqlParameter();
            ref2.ParameterName = "@Ref2";
            ref2.SqlDbType = SqlDbType.NVarChar;
            ref2.Size = 100;
            ref2.Direction = ParameterDirection.Input;
            ref2.Value = Ref2;
            cmd.Parameters.Add(ref2);

            SqlParameter nalogodavac3 = new SqlParameter();
            nalogodavac3.ParameterName = "@Nalogodavac3";
            nalogodavac3.SqlDbType = SqlDbType.Int;
            nalogodavac3.Direction = ParameterDirection.Input;
            nalogodavac3.Value = Nalogodavac3;
            cmd.Parameters.Add(nalogodavac3);

            SqlParameter ref3 = new SqlParameter();
            ref3.ParameterName = "@Ref3";
            ref3.SqlDbType = SqlDbType.NVarChar;
            ref3.Size = 100;
            ref3.Direction = ParameterDirection.Input;
            ref3.Value = Ref3;
            cmd.Parameters.Add(ref3);

            SqlParameter brodar = new SqlParameter();
            brodar.ParameterName = "@Brodar";
            brodar.SqlDbType = SqlDbType.Int;
            brodar.Direction = ParameterDirection.Input;
            brodar.Value = Brodar;
            cmd.Parameters.Add(brodar);

            conn.Open();
            SqlTransaction myTransaction = conn.BeginTransaction();
            cmd.Transaction = myTransaction;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = conn.BeginTransaction();
                cmd.Transaction = myTransaction;
            }

            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }
        public void DelUvoz(int ID)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteUvoz";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            conn.Open();
            SqlTransaction myTransaction = conn.BeginTransaction();
            cmd.Transaction = myTransaction;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = conn.BeginTransaction();
                cmd.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešan upis ");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }
    }
}
