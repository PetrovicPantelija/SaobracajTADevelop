using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Saobracaj.Izvoz
{
    class InsertIzvoz
    {
        string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.TestiranjeConnectionString"].ConnectionString;

        public void InsIzvozNHM(int IDNadredjena, int idNHM)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertIzvozNHM";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter idnadredjena = new SqlParameter();
            idnadredjena.ParameterName = "@IDNadredjena";
            idnadredjena.SqlDbType = SqlDbType.Int;
            idnadredjena.Direction = ParameterDirection.Input;
            idnadredjena.Value = IDNadredjena;
            cmd.Parameters.Add(idnadredjena);

            SqlParameter idnhm = new SqlParameter();
            idnhm.ParameterName = "@IDNHM";
            idnhm.SqlDbType = SqlDbType.Int;
            idnhm.Direction = ParameterDirection.Input;
            idnhm.Value = idNHM;
            cmd.Parameters.Add(idnhm);

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

        public void InsIzvozKonacnaNHM(int IDNadredjena, int idNHM)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertIzvozKonacnaNHM";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter idnadredjena = new SqlParameter();
            idnadredjena.ParameterName = "@IDNadredjena";
            idnadredjena.SqlDbType = SqlDbType.Int;
            idnadredjena.Direction = ParameterDirection.Input;
            idnadredjena.Value = IDNadredjena;
            cmd.Parameters.Add(idnadredjena);

            SqlParameter idnhm = new SqlParameter();
            idnhm.ParameterName = "@IDNHM";
            idnhm.SqlDbType = SqlDbType.Int;
            idnhm.Direction = ParameterDirection.Input;
            idnhm.Value = idNHM;
            cmd.Parameters.Add(idnhm);

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

        public void DelIzvozNHM(int ID)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteIzvozNHM";
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

        public void DelIzvozKonacnaNHM(int ID)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteIzvozKonacnaNHM";
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
        public void InsUbaciUslugu(int IDNadredjena, int IDVrstaManipulacije, double Cena)
        {
            //  @IdNadredjena int,
            //@IDVrstaManipulacije int,
            //@Cena numeric(18, 2)

            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertIzvozVrstaManipulacije";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter idnadredjena = new SqlParameter();
            idnadredjena.ParameterName = "@IDNadredjena";
            idnadredjena.SqlDbType = SqlDbType.Int;
            idnadredjena.Direction = ParameterDirection.Input;
            idnadredjena.Value = IDNadredjena;
            cmd.Parameters.Add(idnadredjena);

            SqlParameter idVrstaManipulacije = new SqlParameter();
            idVrstaManipulacije.ParameterName = "@IDVrstaManipulacije";
            idVrstaManipulacije.SqlDbType = SqlDbType.Int;
            idVrstaManipulacije.Direction = ParameterDirection.Input;
            idVrstaManipulacije.Value = IDVrstaManipulacije;
            cmd.Parameters.Add(idVrstaManipulacije);


            SqlParameter cena = new SqlParameter();
            cena.ParameterName = "@Cena";
            cena.SqlDbType = SqlDbType.Int;
            cena.Direction = ParameterDirection.Input;
            cena.Value = Cena;
            cmd.Parameters.Add(cena);

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

        public void InsUbaciUsluguKonacna(int IDNadredjena, int IDVrstaManipulacije, double Cena)
        {
            //  @IdNadredjena int,
            //@IDVrstaManipulacije int,
            //@Cena numeric(18, 2)

            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertIzvozKonacnaVrstaManipulacije";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter idnadredjena = new SqlParameter();
            idnadredjena.ParameterName = "@IDNadredjena";
            idnadredjena.SqlDbType = SqlDbType.Int;
            idnadredjena.Direction = ParameterDirection.Input;
            idnadredjena.Value = IDNadredjena;
            cmd.Parameters.Add(idnadredjena);

            SqlParameter idVrstaManipulacije = new SqlParameter();
            idVrstaManipulacije.ParameterName = "@IDVrstaManipulacije";
            idVrstaManipulacije.SqlDbType = SqlDbType.Int;
            idVrstaManipulacije.Direction = ParameterDirection.Input;
            idVrstaManipulacije.Value = IDVrstaManipulacije;
            cmd.Parameters.Add(idVrstaManipulacije);


            SqlParameter cena = new SqlParameter();
            cena.ParameterName = "@Cena";
            cena.SqlDbType = SqlDbType.Int;
            cena.Direction = ParameterDirection.Input;
            cena.Value = Cena;
            cmd.Parameters.Add(cena);

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

        public void DelIzvozVrstaRobeHS(int ID)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteIzvozVrstaRobeHS";
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

        public void InsIzvozVrstaRobeHS(int IDNadredjena, int idVrstaRobeHS)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertIzvozVrstaRobeHS";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter idnadredjena = new SqlParameter();
            idnadredjena.ParameterName = "@IDNadredjena";
            idnadredjena.SqlDbType = SqlDbType.Int;
            idnadredjena.Direction = ParameterDirection.Input;
            idnadredjena.Value = IDNadredjena;
            cmd.Parameters.Add(idnadredjena);

            SqlParameter idvrstarobehs = new SqlParameter();
            idvrstarobehs.ParameterName = "@IDVrstaRobeHS";
            idvrstarobehs.SqlDbType = SqlDbType.Int;
            idvrstarobehs.Direction = ParameterDirection.Input;
            idvrstarobehs.Value = idVrstaRobeHS;
            cmd.Parameters.Add(idvrstarobehs);

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

        public void DelIzvozKonacnaVrstaRobeHS(int ID)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteIzvozKonacnaVrstaRobeHS";
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

        public void InsIzvozKonacnaVrstaRobeHS(int IDNadredjena, int idVrstaRobeHS)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertIzvozkonacnaVrstaRobeHS";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter idnadredjena = new SqlParameter();
            idnadredjena.ParameterName = "@IDNadredjena";
            idnadredjena.SqlDbType = SqlDbType.Int;
            idnadredjena.Direction = ParameterDirection.Input;
            idnadredjena.Value = IDNadredjena;
            cmd.Parameters.Add(idnadredjena);

            SqlParameter idvrstarobehs = new SqlParameter();
            idvrstarobehs.ParameterName = "@IDVrstaRobeHS";
            idvrstarobehs.SqlDbType = SqlDbType.Int;
            idvrstarobehs.Direction = ParameterDirection.Input;
            idvrstarobehs.Value = idVrstaRobeHS;
            cmd.Parameters.Add(idvrstarobehs);

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

        public void UpdIzvoz(int ID, string BrojVagona, string BrojKontejnera, int VrstaKontejnera, string BrodskaPlomba,
                            int BookingBrodara, int Brodar, DateTime CutOffPort, decimal NetoRobe,
                            decimal BrutoRobe, decimal BrutoRobeO, int BrojKoleta, int BrojKoletaO,
                            decimal CBM, decimal CBMO, decimal VrednostRobeFaktura, string Valuta,
                            int KrajnaDestinacija, int Postupanje, int MestoPreuzimanja, int Cirada,
                            DateTime PlaniraniDatumUtovara, int MesoUtovara, string KontaktOsoba, int MestoCarinjenja,
                            int Spedicija, int AdresaSlanjaStatusa, int NaslovSlanjaStatusa, DateTime EtaLeget,
                            int NapomenaReexport, int Inspekcija, decimal AutoDana, int NajavaVozila,
                            int NacinPakovanja, int NacinPretovara, string DodatneNapomeneDrumski, int Vaganje,
                            decimal VGMTezina, decimal Tara, decimal VGMBrod, int Izvoznik,
                            int Klijent1, int Napomena1REf, int DobijenNalogKlijent1, int Klijent2,
                            int Napomena2REf, int Klijent3, int Napomena3REf, int SpediterRijeka, string OstalePlombe, int ADR)
        {

            



            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateIzvoz";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            SqlParameter brojvagona = new SqlParameter();
            brojvagona.ParameterName = "@BrojVagona";
            brojvagona.SqlDbType = SqlDbType.NVarChar;
            brojvagona.Size = 30;
            brojvagona.Direction = ParameterDirection.Input;
            brojvagona.Value = BrojVagona;
            cmd.Parameters.Add(brojvagona);

            SqlParameter brojkontejnera = new SqlParameter();
            brojkontejnera.ParameterName = "@BrojKontejnera";
            brojkontejnera.SqlDbType = SqlDbType.NVarChar;
            brojkontejnera.Size = 30;
            brojkontejnera.Direction = ParameterDirection.Input;
            brojkontejnera.Value = BrojKontejnera;
            cmd.Parameters.Add(brojkontejnera);

            SqlParameter vrstakontejnera = new SqlParameter();
            vrstakontejnera.ParameterName = "@VrstaKontejnera";
            vrstakontejnera.SqlDbType = SqlDbType.Int;
            vrstakontejnera.Direction = ParameterDirection.Input;
            vrstakontejnera.Value = VrstaKontejnera;
            cmd.Parameters.Add(vrstakontejnera);

            SqlParameter brodskaplomba = new SqlParameter();
            brodskaplomba.ParameterName = "@BrodskaPlomba";
            brodskaplomba.SqlDbType = SqlDbType.NVarChar;
            brodskaplomba.Size = 30;
            brodskaplomba.Direction = ParameterDirection.Input;
            brodskaplomba.Value = BrodskaPlomba;
            cmd.Parameters.Add(brodskaplomba);

            SqlParameter bookingbrodara = new SqlParameter();
            bookingbrodara.ParameterName = "@BookingBrodara";
            bookingbrodara.SqlDbType = SqlDbType.Int;
            bookingbrodara.Direction = ParameterDirection.Input;
            bookingbrodara.Value = BookingBrodara;
            cmd.Parameters.Add(bookingbrodara);

            SqlParameter brodar = new SqlParameter();
            brodar.ParameterName = "@Brodar";
            brodar.SqlDbType = SqlDbType.Int;
            brodar.Direction = ParameterDirection.Input;
            brodar.Value = Brodar;
            cmd.Parameters.Add(brodar);

            SqlParameter cutoffPort = new SqlParameter();
            cutoffPort.ParameterName = "@CutOffPort";
            cutoffPort.SqlDbType = SqlDbType.DateTime;
            cutoffPort.Direction = ParameterDirection.Input;
            cutoffPort.Value = CutOffPort;
            cmd.Parameters.Add(cutoffPort);

            SqlParameter netorobe = new SqlParameter();
            netorobe.ParameterName = "@NetoRobe";
            netorobe.SqlDbType = SqlDbType.Decimal;
            netorobe.Direction = ParameterDirection.Input;
            netorobe.Value = NetoRobe;
            cmd.Parameters.Add(netorobe);

            SqlParameter brutorobe = new SqlParameter();
            brutorobe.ParameterName = "@BrutoRobe";
            brutorobe.SqlDbType = SqlDbType.Decimal;
            brutorobe.Direction = ParameterDirection.Input;
            brutorobe.Value = BrutoRobe;
            cmd.Parameters.Add(brutorobe);

            SqlParameter brutorobeO = new SqlParameter();
            brutorobeO.ParameterName = "@BrutoRobeO";
            brutorobeO.SqlDbType = SqlDbType.Decimal;
            brutorobeO.Direction = ParameterDirection.Input;
            brutorobeO.Value = BrutoRobeO;
            cmd.Parameters.Add(brutorobeO);
           
            SqlParameter brojkoleta = new SqlParameter();
            brojkoleta.ParameterName = "@BrojKoleta";
            brojkoleta.SqlDbType = SqlDbType.Int;
            brojkoleta.Direction = ParameterDirection.Input;
            brojkoleta.Value = BrojKoleta;
            cmd.Parameters.Add(brojkoleta);

            SqlParameter brojkoletaO = new SqlParameter();
            brojkoletaO.ParameterName = "@BrojKoletaO";
            brojkoletaO.SqlDbType = SqlDbType.Int;
            brojkoletaO.Direction = ParameterDirection.Input;
            brojkoletaO.Value = BrojKoletaO;
            cmd.Parameters.Add(brojkoletaO);



            SqlParameter cmb = new SqlParameter();
            cmb.ParameterName = "@CBM";
            cmb.SqlDbType = SqlDbType.Decimal;
            cmb.Direction = ParameterDirection.Input;
            cmb.Value = CBM;
            cmd.Parameters.Add(cmb);

            SqlParameter cmbO = new SqlParameter();
            cmbO.ParameterName = "@CBMO";
            cmbO.SqlDbType = SqlDbType.Decimal;
            cmbO.Direction = ParameterDirection.Input;
            cmbO.Value = CBMO;
            cmd.Parameters.Add(cmbO);

            SqlParameter vrednostrobefaktura = new SqlParameter();
            vrednostrobefaktura.ParameterName = "@VrednostRobeFaktura";
            vrednostrobefaktura.SqlDbType = SqlDbType.Decimal;
            vrednostrobefaktura.Direction = ParameterDirection.Input;
            vrednostrobefaktura.Value = VrednostRobeFaktura;
            cmd.Parameters.Add(vrednostrobefaktura);

            SqlParameter valuta = new SqlParameter();
            valuta.ParameterName = "@Valuta";
            valuta.SqlDbType = SqlDbType.NVarChar;
            valuta.Size = 50;
            valuta.Direction = ParameterDirection.Input;
            valuta.Value = Valuta;
            cmd.Parameters.Add(valuta);

            SqlParameter krajnaDestinacija = new SqlParameter();
            krajnaDestinacija.ParameterName = "@KrajnaDestinacija";
            krajnaDestinacija.SqlDbType = SqlDbType.Int;
            krajnaDestinacija.Direction = ParameterDirection.Input;
            krajnaDestinacija.Value = KrajnaDestinacija;
            cmd.Parameters.Add(krajnaDestinacija);

            SqlParameter postupanje = new SqlParameter();
            postupanje.ParameterName = "@Postupanje";
            postupanje.SqlDbType = SqlDbType.Int;
            postupanje.Direction = ParameterDirection.Input;
            postupanje.Value = Postupanje;
            cmd.Parameters.Add(postupanje);

            SqlParameter mestopreuzimanja = new SqlParameter();
            mestopreuzimanja.ParameterName = "@MestoPreuzimanja";
            mestopreuzimanja.SqlDbType = SqlDbType.Int;
            mestopreuzimanja.Direction = ParameterDirection.Input;
            mestopreuzimanja.Value = MestoPreuzimanja;
            cmd.Parameters.Add(mestopreuzimanja);

            SqlParameter cirada = new SqlParameter();
            cirada.ParameterName = "@Cirada";
            cirada.SqlDbType = SqlDbType.Int;
            cirada.Direction = ParameterDirection.Input;
            cirada.Value = Cirada;
            cmd.Parameters.Add(cirada);


            SqlParameter planiraniDatumUtovara = new SqlParameter();
            planiraniDatumUtovara.ParameterName = "@PlaniraniDatumUtovara";
            planiraniDatumUtovara.SqlDbType = SqlDbType.DateTime;
            planiraniDatumUtovara.Direction = ParameterDirection.Input;
            planiraniDatumUtovara.Value = PlaniraniDatumUtovara;
            cmd.Parameters.Add(planiraniDatumUtovara);

            SqlParameter mesoutovara = new SqlParameter();
            mesoutovara.ParameterName = "@MesoUtovara";
            mesoutovara.SqlDbType = SqlDbType.Int;
            mesoutovara.Direction = ParameterDirection.Input;
            mesoutovara.Value = MesoUtovara;
            cmd.Parameters.Add(mesoutovara);

            SqlParameter kontaktOsoba = new SqlParameter();
            kontaktOsoba.ParameterName = "@KontaktOsoba";
            kontaktOsoba.SqlDbType = SqlDbType.NVarChar;
            kontaktOsoba.Size = 50;
            kontaktOsoba.Direction = ParameterDirection.Input;
            kontaktOsoba.Value = KontaktOsoba;
            cmd.Parameters.Add(kontaktOsoba);

            SqlParameter mestocarinjenja = new SqlParameter();
            mestocarinjenja.ParameterName = "@MestoCarinjenja";
            mestocarinjenja.SqlDbType = SqlDbType.Int;
            mestocarinjenja.Direction = ParameterDirection.Input;
            mestocarinjenja.Value = MestoCarinjenja;
            cmd.Parameters.Add(mestocarinjenja);

            SqlParameter spedicija = new SqlParameter();
            spedicija.ParameterName = "@Spedicija";
            spedicija.SqlDbType = SqlDbType.Int;
            spedicija.Direction = ParameterDirection.Input;
            spedicija.Value = Spedicija;
            cmd.Parameters.Add(spedicija);

            SqlParameter adresaslanjastatusa = new SqlParameter();
            adresaslanjastatusa.ParameterName = "@AdresaSlanjaStatusa";
            adresaslanjastatusa.SqlDbType = SqlDbType.Int;
            adresaslanjastatusa.Direction = ParameterDirection.Input;
            adresaslanjastatusa.Value = AdresaSlanjaStatusa;
            cmd.Parameters.Add(adresaslanjastatusa);

            SqlParameter naslovSlanjaStatusa = new SqlParameter();
            naslovSlanjaStatusa.ParameterName = "@NaslovSlanjaStatusa";
            naslovSlanjaStatusa.SqlDbType = SqlDbType.Int;
            naslovSlanjaStatusa.Direction = ParameterDirection.Input;
            naslovSlanjaStatusa.Value = NaslovSlanjaStatusa;
            cmd.Parameters.Add(naslovSlanjaStatusa);

            SqlParameter etaLeget = new SqlParameter();
            etaLeget.ParameterName = "@EtaLeget";
            etaLeget.SqlDbType = SqlDbType.DateTime;
            etaLeget.Direction = ParameterDirection.Input;
            etaLeget.Value = EtaLeget;
            cmd.Parameters.Add(etaLeget);

            SqlParameter napomenaReexport = new SqlParameter();
            napomenaReexport.ParameterName = "@NapomenaReexport";
            napomenaReexport.SqlDbType = SqlDbType.Int;
            napomenaReexport.Direction = ParameterDirection.Input;
            napomenaReexport.Value = NapomenaReexport;
            cmd.Parameters.Add(napomenaReexport);

            SqlParameter inspekcija = new SqlParameter();
            inspekcija.ParameterName = "@Inspekcija";
            inspekcija.SqlDbType = SqlDbType.Int;
            inspekcija.Direction = ParameterDirection.Input;
            inspekcija.Value = Inspekcija;
            cmd.Parameters.Add(inspekcija);

            SqlParameter autoDana = new SqlParameter();
            autoDana.ParameterName = "@AutoDana";
            autoDana.SqlDbType = SqlDbType.Int;
            autoDana.Direction = ParameterDirection.Input;
            autoDana.Value = AutoDana;
            cmd.Parameters.Add(autoDana);

            SqlParameter najavaVozila = new SqlParameter();
            najavaVozila.ParameterName = "@NajavaVozila";
            najavaVozila.SqlDbType = SqlDbType.Int;
            najavaVozila.Direction = ParameterDirection.Input;
            najavaVozila.Value = NajavaVozila;
            cmd.Parameters.Add(najavaVozila);

            SqlParameter nacinPakovanja = new SqlParameter();
            nacinPakovanja.ParameterName = "@NacinPakovanja";
            nacinPakovanja.SqlDbType = SqlDbType.Int;
            nacinPakovanja.Direction = ParameterDirection.Input;
            nacinPakovanja.Value = NacinPakovanja;
            cmd.Parameters.Add(nacinPakovanja);

            SqlParameter nacinPretovara = new SqlParameter();
            nacinPretovara.ParameterName = "@NacinPretovara";
            nacinPretovara.SqlDbType = SqlDbType.Int;
            nacinPretovara.Direction = ParameterDirection.Input;
            nacinPretovara.Value = NacinPretovara;
            cmd.Parameters.Add(nacinPretovara);

            SqlParameter dodatneNapomeneDrumski = new SqlParameter();
            dodatneNapomeneDrumski.ParameterName = "@DodatneNapomeneDrumski";
            dodatneNapomeneDrumski.SqlDbType = SqlDbType.NVarChar;
            dodatneNapomeneDrumski.Size = 500;
            dodatneNapomeneDrumski.Direction = ParameterDirection.Input;
            dodatneNapomeneDrumski.Value = DodatneNapomeneDrumski;
            cmd.Parameters.Add(dodatneNapomeneDrumski);

            SqlParameter vaganje = new SqlParameter();
            vaganje.ParameterName = "@Vaganje";
            vaganje.SqlDbType = SqlDbType.Int;
            vaganje.Direction = ParameterDirection.Input;
            vaganje.Value = Vaganje;
            cmd.Parameters.Add(vaganje);

            SqlParameter vGMTezina = new SqlParameter();
            vGMTezina.ParameterName = "@VGMTezina";
            vGMTezina.SqlDbType = SqlDbType.Decimal;
            vGMTezina.Direction = ParameterDirection.Input;
            vGMTezina.Value = VGMTezina;
            cmd.Parameters.Add(vGMTezina);

            SqlParameter tara = new SqlParameter();
            tara.ParameterName = "@Tara";
            tara.SqlDbType = SqlDbType.Decimal;
            tara.Direction = ParameterDirection.Input;
            tara.Value = Tara;
            cmd.Parameters.Add(tara);

            SqlParameter vGMBrod = new SqlParameter();
            vGMBrod.ParameterName = "@VGMBrod";
            vGMBrod.SqlDbType = SqlDbType.Decimal;
            vGMBrod.Direction = ParameterDirection.Input;
            vGMBrod.Value = VGMBrod;
            cmd.Parameters.Add(vGMBrod);

            SqlParameter izvoznik = new SqlParameter();
            izvoznik.ParameterName = "@Izvoznik";
            izvoznik.SqlDbType = SqlDbType.Int;
            izvoznik.Direction = ParameterDirection.Input;
            izvoznik.Value = Izvoznik;
            cmd.Parameters.Add(izvoznik);

            SqlParameter klijent1 = new SqlParameter();
            klijent1.ParameterName = "@Klijent1";
            klijent1.SqlDbType = SqlDbType.Int;
            klijent1.Direction = ParameterDirection.Input;
            klijent1.Value = Klijent1;
            cmd.Parameters.Add(klijent1);

            SqlParameter napomena1REf = new SqlParameter();
            napomena1REf.ParameterName = "@Napomena1REf";
            napomena1REf.SqlDbType = SqlDbType.Int;
            napomena1REf.Direction = ParameterDirection.Input;
            napomena1REf.Value = Napomena1REf;
            cmd.Parameters.Add(napomena1REf);

            SqlParameter dobijenNalogKlijent1 = new SqlParameter();
            dobijenNalogKlijent1.ParameterName = "@DobijenNalogKlijent1";
            dobijenNalogKlijent1.SqlDbType = SqlDbType.Int;
            dobijenNalogKlijent1.Direction = ParameterDirection.Input;
            dobijenNalogKlijent1.Value = DobijenNalogKlijent1;
            cmd.Parameters.Add(dobijenNalogKlijent1);

            SqlParameter klijent2 = new SqlParameter();
            klijent2.ParameterName = "@Klijent2";
            klijent2.SqlDbType = SqlDbType.Int;
            klijent2.Direction = ParameterDirection.Input;
            klijent2.Value = Klijent2;
            cmd.Parameters.Add(klijent2);

            SqlParameter napomena2REf = new SqlParameter();
            napomena2REf.ParameterName = "@Napomena2REf";
            napomena2REf.SqlDbType = SqlDbType.Int;
            napomena2REf.Direction = ParameterDirection.Input;
            napomena2REf.Value = Napomena2REf;
            cmd.Parameters.Add(napomena2REf);

            SqlParameter klijent3 = new SqlParameter();
            klijent3.ParameterName = "@Klijent3";
            klijent3.SqlDbType = SqlDbType.Int;
            klijent3.Direction = ParameterDirection.Input;
            klijent3.Value = Klijent3;
            cmd.Parameters.Add(klijent3);

            SqlParameter napomena3REf = new SqlParameter();
            napomena3REf.ParameterName = "@Napomena3REf";
            napomena3REf.SqlDbType = SqlDbType.Int;
            napomena3REf.Direction = ParameterDirection.Input;
            napomena3REf.Value = Napomena3REf;
            cmd.Parameters.Add(napomena3REf);

            SqlParameter spediterRijeka = new SqlParameter();
            spediterRijeka.ParameterName = "@SpediterRijeka";
            spediterRijeka.SqlDbType = SqlDbType.Int;
            spediterRijeka.Direction = ParameterDirection.Input;
            spediterRijeka.Value = SpediterRijeka;
            cmd.Parameters.Add(spediterRijeka);

            SqlParameter ostaleplombe = new SqlParameter();
            ostaleplombe.ParameterName = "@OstalePlombe";
            ostaleplombe.SqlDbType = SqlDbType.NVarChar;
            ostaleplombe.Size = 50;
            ostaleplombe.Direction = ParameterDirection.Input;
            ostaleplombe.Value = OstalePlombe;
            cmd.Parameters.Add(ostaleplombe);

            SqlParameter adr = new SqlParameter();
            adr.ParameterName = "@ADR";
            adr.SqlDbType = SqlDbType.Int;
            adr.Direction = ParameterDirection.Input;
            adr.Value = ADR;
            cmd.Parameters.Add(adr);



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

        public void UpdIzvozKonacna(int ID, string BrojVagona, string BrojKontejnera, int VrstaKontejnera, string BrodskaPlomba,
                           int BookingBrodara, int Brodar, DateTime CutOffPort, decimal NetoRobe,
                           decimal BrutoRobe, decimal BrutoRobeO, int BrojKoleta, int BrojKoletaO,
                           decimal CBM, decimal CBMO, decimal VrednostRobeFaktura, string Valuta,
                           int KrajnaDestinacija, int Postupanje, int MestoPreuzimanja, int Cirada,
                           DateTime PlaniraniDatumUtovara, int MesoUtovara, string KontaktOsoba, int MestoCarinjenja,
                           int Spedicija, int AdresaSlanjaStatusa, int NaslovSlanjaStatusa, DateTime EtaLeget,
                           int NapomenaReexport, int Inspekcija, decimal AutoDana, int NajavaVozila,
                           int NacinPakovanja, int NacinPretovara, string DodatneNapomeneDrumski, int Vaganje,
                           decimal VGMTezina, decimal Tara, decimal VGMBrod, int Izvoznik,
                           int Klijent1, int Napomena1REf, int DobijenNalogKlijent1, int Klijent2,
                           int Napomena2REf, int Klijent3, int Napomena3REf, int SpediterRijeka, string OstalePlombe, int ADR, int IDNadredjena)
        {





            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateIzvoz";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            SqlParameter brojvagona = new SqlParameter();
            brojvagona.ParameterName = "@BrojVagona";
            brojvagona.SqlDbType = SqlDbType.NVarChar;
            brojvagona.Size = 30;
            brojvagona.Direction = ParameterDirection.Input;
            brojvagona.Value = BrojVagona;
            cmd.Parameters.Add(brojvagona);

            SqlParameter brojkontejnera = new SqlParameter();
            brojkontejnera.ParameterName = "@BrojKontejnera";
            brojkontejnera.SqlDbType = SqlDbType.NVarChar;
            brojkontejnera.Size = 30;
            brojkontejnera.Direction = ParameterDirection.Input;
            brojkontejnera.Value = BrojKontejnera;
            cmd.Parameters.Add(brojkontejnera);

            SqlParameter vrstakontejnera = new SqlParameter();
            vrstakontejnera.ParameterName = "@VrstaKontejnera";
            vrstakontejnera.SqlDbType = SqlDbType.Int;
            vrstakontejnera.Direction = ParameterDirection.Input;
            vrstakontejnera.Value = VrstaKontejnera;
            cmd.Parameters.Add(vrstakontejnera);

            SqlParameter brodskaplomba = new SqlParameter();
            brodskaplomba.ParameterName = "@BrodskaPlomba";
            brodskaplomba.SqlDbType = SqlDbType.NVarChar;
            brodskaplomba.Size = 30;
            brodskaplomba.Direction = ParameterDirection.Input;
            brodskaplomba.Value = BrodskaPlomba;
            cmd.Parameters.Add(brodskaplomba);

            SqlParameter bookingbrodara = new SqlParameter();
            bookingbrodara.ParameterName = "@BookingBrodara";
            bookingbrodara.SqlDbType = SqlDbType.Int;
            bookingbrodara.Direction = ParameterDirection.Input;
            bookingbrodara.Value = BookingBrodara;
            cmd.Parameters.Add(bookingbrodara);

            SqlParameter brodar = new SqlParameter();
            brodar.ParameterName = "@Brodar";
            brodar.SqlDbType = SqlDbType.Int;
            brodar.Direction = ParameterDirection.Input;
            brodar.Value = Brodar;
            cmd.Parameters.Add(brodar);

            SqlParameter cutoffPort = new SqlParameter();
            cutoffPort.ParameterName = "@CutOffPort";
            cutoffPort.SqlDbType = SqlDbType.DateTime;
            cutoffPort.Direction = ParameterDirection.Input;
            cutoffPort.Value = CutOffPort;
            cmd.Parameters.Add(cutoffPort);

            SqlParameter netorobe = new SqlParameter();
            netorobe.ParameterName = "@NetoRobe";
            netorobe.SqlDbType = SqlDbType.Decimal;
            netorobe.Direction = ParameterDirection.Input;
            netorobe.Value = NetoRobe;
            cmd.Parameters.Add(netorobe);

            SqlParameter brutorobe = new SqlParameter();
            brutorobe.ParameterName = "@BrutoRobe";
            brutorobe.SqlDbType = SqlDbType.Decimal;
            brutorobe.Direction = ParameterDirection.Input;
            brutorobe.Value = BrutoRobe;
            cmd.Parameters.Add(brutorobe);

            SqlParameter brutorobeO = new SqlParameter();
            brutorobeO.ParameterName = "@BrutoRobeO";
            brutorobeO.SqlDbType = SqlDbType.Decimal;
            brutorobeO.Direction = ParameterDirection.Input;
            brutorobeO.Value = BrutoRobeO;
            cmd.Parameters.Add(brutorobeO);

            SqlParameter brojkoleta = new SqlParameter();
            brojkoleta.ParameterName = "@BrojKoleta";
            brojkoleta.SqlDbType = SqlDbType.Int;
            brojkoleta.Direction = ParameterDirection.Input;
            brojkoleta.Value = BrojKoleta;
            cmd.Parameters.Add(brojkoleta);

            SqlParameter brojkoletaO = new SqlParameter();
            brojkoletaO.ParameterName = "@BrojKoletaO";
            brojkoletaO.SqlDbType = SqlDbType.Int;
            brojkoletaO.Direction = ParameterDirection.Input;
            brojkoletaO.Value = BrojKoletaO;
            cmd.Parameters.Add(brojkoletaO);



            SqlParameter cmb = new SqlParameter();
            cmb.ParameterName = "@CBM";
            cmb.SqlDbType = SqlDbType.Decimal;
            cmb.Direction = ParameterDirection.Input;
            cmb.Value = CBM;
            cmd.Parameters.Add(cmb);

            SqlParameter cmbO = new SqlParameter();
            cmbO.ParameterName = "@CBMO";
            cmbO.SqlDbType = SqlDbType.Decimal;
            cmbO.Direction = ParameterDirection.Input;
            cmbO.Value = CBMO;
            cmd.Parameters.Add(cmbO);

            SqlParameter vrednostrobefaktura = new SqlParameter();
            vrednostrobefaktura.ParameterName = "@VrednostRobeFaktura";
            vrednostrobefaktura.SqlDbType = SqlDbType.Decimal;
            vrednostrobefaktura.Direction = ParameterDirection.Input;
            vrednostrobefaktura.Value = VrednostRobeFaktura;
            cmd.Parameters.Add(vrednostrobefaktura);

            SqlParameter valuta = new SqlParameter();
            valuta.ParameterName = "@Valuta";
            valuta.SqlDbType = SqlDbType.NVarChar;
            valuta.Size = 50;
            valuta.Direction = ParameterDirection.Input;
            valuta.Value = Valuta;
            cmd.Parameters.Add(valuta);

            SqlParameter krajnaDestinacija = new SqlParameter();
            krajnaDestinacija.ParameterName = "@KrajnaDestinacija";
            krajnaDestinacija.SqlDbType = SqlDbType.Int;
            krajnaDestinacija.Direction = ParameterDirection.Input;
            krajnaDestinacija.Value = KrajnaDestinacija;
            cmd.Parameters.Add(krajnaDestinacija);

            SqlParameter postupanje = new SqlParameter();
            postupanje.ParameterName = "@Postupanje";
            postupanje.SqlDbType = SqlDbType.Int;
            postupanje.Direction = ParameterDirection.Input;
            postupanje.Value = Postupanje;
            cmd.Parameters.Add(postupanje);

            SqlParameter mestopreuzimanja = new SqlParameter();
            mestopreuzimanja.ParameterName = "@MestoPreuzimanja";
            mestopreuzimanja.SqlDbType = SqlDbType.Int;
            mestopreuzimanja.Direction = ParameterDirection.Input;
            mestopreuzimanja.Value = MestoPreuzimanja;
            cmd.Parameters.Add(mestopreuzimanja);

            SqlParameter cirada = new SqlParameter();
            cirada.ParameterName = "@Cirada";
            cirada.SqlDbType = SqlDbType.Int;
            cirada.Direction = ParameterDirection.Input;
            cirada.Value = Cirada;
            cmd.Parameters.Add(cirada);


            SqlParameter planiraniDatumUtovara = new SqlParameter();
            planiraniDatumUtovara.ParameterName = "@PlaniraniDatumUtovara";
            planiraniDatumUtovara.SqlDbType = SqlDbType.DateTime;
            planiraniDatumUtovara.Direction = ParameterDirection.Input;
            planiraniDatumUtovara.Value = PlaniraniDatumUtovara;
            cmd.Parameters.Add(planiraniDatumUtovara);

            SqlParameter mesoutovara = new SqlParameter();
            mesoutovara.ParameterName = "@MesoUtovara";
            mesoutovara.SqlDbType = SqlDbType.Int;
            mesoutovara.Direction = ParameterDirection.Input;
            mesoutovara.Value = MesoUtovara;
            cmd.Parameters.Add(mesoutovara);

            SqlParameter kontaktOsoba = new SqlParameter();
            kontaktOsoba.ParameterName = "@KontaktOsoba";
            kontaktOsoba.SqlDbType = SqlDbType.NVarChar;
            kontaktOsoba.Size = 50;
            kontaktOsoba.Direction = ParameterDirection.Input;
            kontaktOsoba.Value = KontaktOsoba;
            cmd.Parameters.Add(kontaktOsoba);

            SqlParameter mestocarinjenja = new SqlParameter();
            mestocarinjenja.ParameterName = "@MestoCarinjenja";
            mestocarinjenja.SqlDbType = SqlDbType.Int;
            mestocarinjenja.Direction = ParameterDirection.Input;
            mestocarinjenja.Value = MestoCarinjenja;
            cmd.Parameters.Add(mestocarinjenja);

            SqlParameter spedicija = new SqlParameter();
            spedicija.ParameterName = "@Spedicija";
            spedicija.SqlDbType = SqlDbType.Int;
            spedicija.Direction = ParameterDirection.Input;
            spedicija.Value = Spedicija;
            cmd.Parameters.Add(spedicija);

            SqlParameter adresaslanjastatusa = new SqlParameter();
            adresaslanjastatusa.ParameterName = "@AdresaSlanjaStatusa";
            adresaslanjastatusa.SqlDbType = SqlDbType.Int;
            adresaslanjastatusa.Direction = ParameterDirection.Input;
            adresaslanjastatusa.Value = AdresaSlanjaStatusa;
            cmd.Parameters.Add(adresaslanjastatusa);

            SqlParameter naslovSlanjaStatusa = new SqlParameter();
            naslovSlanjaStatusa.ParameterName = "@NaslovSlanjaStatusa";
            naslovSlanjaStatusa.SqlDbType = SqlDbType.Int;
            naslovSlanjaStatusa.Direction = ParameterDirection.Input;
            naslovSlanjaStatusa.Value = NaslovSlanjaStatusa;
            cmd.Parameters.Add(naslovSlanjaStatusa);

            SqlParameter etaLeget = new SqlParameter();
            etaLeget.ParameterName = "@EtaLeget";
            etaLeget.SqlDbType = SqlDbType.DateTime;
            etaLeget.Direction = ParameterDirection.Input;
            etaLeget.Value = EtaLeget;
            cmd.Parameters.Add(etaLeget);

            SqlParameter napomenaReexport = new SqlParameter();
            napomenaReexport.ParameterName = "@NapomenaReexport";
            napomenaReexport.SqlDbType = SqlDbType.Int;
            napomenaReexport.Direction = ParameterDirection.Input;
            napomenaReexport.Value = NapomenaReexport;
            cmd.Parameters.Add(napomenaReexport);

            SqlParameter inspekcija = new SqlParameter();
            inspekcija.ParameterName = "@Inspekcija";
            inspekcija.SqlDbType = SqlDbType.Int;
            inspekcija.Direction = ParameterDirection.Input;
            inspekcija.Value = Inspekcija;
            cmd.Parameters.Add(inspekcija);

            SqlParameter autoDana = new SqlParameter();
            autoDana.ParameterName = "@AutoDana";
            autoDana.SqlDbType = SqlDbType.Int;
            autoDana.Direction = ParameterDirection.Input;
            autoDana.Value = AutoDana;
            cmd.Parameters.Add(autoDana);

            SqlParameter najavaVozila = new SqlParameter();
            najavaVozila.ParameterName = "@NajavaVozila";
            najavaVozila.SqlDbType = SqlDbType.Int;
            najavaVozila.Direction = ParameterDirection.Input;
            najavaVozila.Value = NajavaVozila;
            cmd.Parameters.Add(najavaVozila);

            SqlParameter nacinPakovanja = new SqlParameter();
            nacinPakovanja.ParameterName = "@NacinPakovanja";
            nacinPakovanja.SqlDbType = SqlDbType.Int;
            nacinPakovanja.Direction = ParameterDirection.Input;
            nacinPakovanja.Value = NacinPakovanja;
            cmd.Parameters.Add(nacinPakovanja);

            SqlParameter nacinPretovara = new SqlParameter();
            nacinPretovara.ParameterName = "@NacinPretovara";
            nacinPretovara.SqlDbType = SqlDbType.Int;
            nacinPretovara.Direction = ParameterDirection.Input;
            nacinPretovara.Value = NacinPretovara;
            cmd.Parameters.Add(nacinPretovara);

            SqlParameter dodatneNapomeneDrumski = new SqlParameter();
            dodatneNapomeneDrumski.ParameterName = "@DodatneNapomeneDrumski";
            dodatneNapomeneDrumski.SqlDbType = SqlDbType.NVarChar;
            dodatneNapomeneDrumski.Size = 500;
            dodatneNapomeneDrumski.Direction = ParameterDirection.Input;
            dodatneNapomeneDrumski.Value = DodatneNapomeneDrumski;
            cmd.Parameters.Add(dodatneNapomeneDrumski);

            SqlParameter vaganje = new SqlParameter();
            vaganje.ParameterName = "@Vaganje";
            vaganje.SqlDbType = SqlDbType.Int;
            vaganje.Direction = ParameterDirection.Input;
            vaganje.Value = Vaganje;
            cmd.Parameters.Add(vaganje);

            SqlParameter vGMTezina = new SqlParameter();
            vGMTezina.ParameterName = "@VGMTezina";
            vGMTezina.SqlDbType = SqlDbType.Decimal;
            vGMTezina.Direction = ParameterDirection.Input;
            vGMTezina.Value = VGMTezina;
            cmd.Parameters.Add(vGMTezina);

            SqlParameter tara = new SqlParameter();
            tara.ParameterName = "@Tara";
            tara.SqlDbType = SqlDbType.Decimal;
            tara.Direction = ParameterDirection.Input;
            tara.Value = Tara;
            cmd.Parameters.Add(tara);

            SqlParameter vGMBrod = new SqlParameter();
            vGMBrod.ParameterName = "@VGMBrod";
            vGMBrod.SqlDbType = SqlDbType.Decimal;
            vGMBrod.Direction = ParameterDirection.Input;
            vGMBrod.Value = VGMBrod;
            cmd.Parameters.Add(vGMBrod);

            SqlParameter izvoznik = new SqlParameter();
            izvoznik.ParameterName = "@Izvoznik";
            izvoznik.SqlDbType = SqlDbType.Int;
            izvoznik.Direction = ParameterDirection.Input;
            izvoznik.Value = Izvoznik;
            cmd.Parameters.Add(izvoznik);

            SqlParameter klijent1 = new SqlParameter();
            klijent1.ParameterName = "@Klijent1";
            klijent1.SqlDbType = SqlDbType.Int;
            klijent1.Direction = ParameterDirection.Input;
            klijent1.Value = Klijent1;
            cmd.Parameters.Add(klijent1);

            SqlParameter napomena1REf = new SqlParameter();
            napomena1REf.ParameterName = "@Napomena1REf";
            napomena1REf.SqlDbType = SqlDbType.Int;
            napomena1REf.Direction = ParameterDirection.Input;
            napomena1REf.Value = Napomena1REf;
            cmd.Parameters.Add(napomena1REf);

            SqlParameter dobijenNalogKlijent1 = new SqlParameter();
            dobijenNalogKlijent1.ParameterName = "@DobijenNalogKlijent1";
            dobijenNalogKlijent1.SqlDbType = SqlDbType.Int;
            dobijenNalogKlijent1.Direction = ParameterDirection.Input;
            dobijenNalogKlijent1.Value = DobijenNalogKlijent1;
            cmd.Parameters.Add(dobijenNalogKlijent1);

            SqlParameter klijent2 = new SqlParameter();
            klijent2.ParameterName = "@Klijent2";
            klijent2.SqlDbType = SqlDbType.Int;
            klijent2.Direction = ParameterDirection.Input;
            klijent2.Value = Klijent2;
            cmd.Parameters.Add(klijent2);

            SqlParameter napomena2REf = new SqlParameter();
            napomena2REf.ParameterName = "@Napomena2REf";
            napomena2REf.SqlDbType = SqlDbType.Int;
            napomena2REf.Direction = ParameterDirection.Input;
            napomena2REf.Value = Napomena2REf;
            cmd.Parameters.Add(napomena2REf);

            SqlParameter klijent3 = new SqlParameter();
            klijent3.ParameterName = "@Klijent3";
            klijent3.SqlDbType = SqlDbType.Int;
            klijent3.Direction = ParameterDirection.Input;
            klijent3.Value = Klijent3;
            cmd.Parameters.Add(klijent3);

            SqlParameter napomena3REf = new SqlParameter();
            napomena3REf.ParameterName = "@Napomena3REf";
            napomena3REf.SqlDbType = SqlDbType.Int;
            napomena3REf.Direction = ParameterDirection.Input;
            napomena3REf.Value = Napomena3REf;
            cmd.Parameters.Add(napomena3REf);

            SqlParameter spediterRijeka = new SqlParameter();
            spediterRijeka.ParameterName = "@SpediterRijeka";
            spediterRijeka.SqlDbType = SqlDbType.Int;
            spediterRijeka.Direction = ParameterDirection.Input;
            spediterRijeka.Value = SpediterRijeka;
            cmd.Parameters.Add(spediterRijeka);

            SqlParameter ostaleplombe = new SqlParameter();
            ostaleplombe.ParameterName = "@OstalePlombe";
            ostaleplombe.SqlDbType = SqlDbType.NVarChar;
            ostaleplombe.Size = 50;
            ostaleplombe.Direction = ParameterDirection.Input;
            ostaleplombe.Value = OstalePlombe;
            cmd.Parameters.Add(ostaleplombe);

            SqlParameter adr = new SqlParameter();
            adr.ParameterName = "@ADR";
            adr.SqlDbType = SqlDbType.Int;
            adr.Direction = ParameterDirection.Input;
            adr.Value = ADR;
            cmd.Parameters.Add(adr);

            SqlParameter idnadredjena = new SqlParameter();
            idnadredjena.ParameterName = "@IDNadredjena";
            idnadredjena.SqlDbType = SqlDbType.Int;
            idnadredjena.Direction = ParameterDirection.Input;
            idnadredjena.Value = IDNadredjena;
            cmd.Parameters.Add(idnadredjena);

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

    }
}
