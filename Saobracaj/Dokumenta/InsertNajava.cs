using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Saobracaj.Dokumenta
{
    class InsertNajava
    {
        public void InsNaj(string BrojNajave, int Voz, int Posiljalac, int Prevoznik, int Otpravna, int Uputna, int Primalac, int RobaNHM, string PrevozniPut, double Tezina, double Duzina, int BrojKola, bool RID, System.DateTime PredvidjenoPrimanje, System.DateTime StvarnoPrimanje, System.DateTime PredvidjenaPredaja, System.DateTime StvarnaPredaja, int Status, string OnBroj, string RidBroj, string Komentar, int VozP, int Granicna, int Platilac, bool AdHoc, int PrevoznikZa, string Faktura, string Zadatak, bool CIM, string Korisnik, string DispecerRid, int TipPrevoza, double NetoTezinaM, int PorudzbinaID, int ImaPovrat, int TehnologijaID, int RobaNHM2, string DodatnoPorudzbina)
        {
           
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertNajava";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@BrojNajave";
            parameter.SqlDbType = SqlDbType.Char;
            parameter.Size = 50;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = BrojNajave;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Voz";
            parameter2.SqlDbType = SqlDbType.Int;
        
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Voz;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Posiljalac";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Posiljalac;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Prevoznik";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Prevoznik;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Otpravna";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Otpravna;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Uputna";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Uputna;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Primalac";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Primalac;
            myCommand.Parameters.Add(parameter7);
          
            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@RobaNHM";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = RobaNHM;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@PrevozniPut";
            parameter9.SqlDbType = SqlDbType.NChar;
            parameter9.Size = 50;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = PrevozniPut;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Tezina";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Tezina;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Duzina";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Duzina;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@BrojKola";
            parameter12.SqlDbType = SqlDbType.Int;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = BrojKola;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@RID";
            parameter13.SqlDbType = SqlDbType.TinyInt;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = RID;
            myCommand.Parameters.Add(parameter13);
          
            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@PredvidjenoPrimanje";
            parameter14.SqlDbType = SqlDbType.DateTime;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = PredvidjenoPrimanje;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@StvarnoPrimanje";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = StvarnoPrimanje;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@PredvidjenaPredaja";
            parameter16.SqlDbType = SqlDbType.DateTime;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = PredvidjenaPredaja;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@StvarnaPredaja";
            parameter17.SqlDbType = SqlDbType.DateTime;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = StvarnaPredaja;
            myCommand.Parameters.Add(parameter17);
          
            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Status";
            parameter18.SqlDbType = SqlDbType.Int;
        
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Status;
            myCommand.Parameters.Add(parameter18);
      
            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@OnBroj";
            parameter19.SqlDbType = SqlDbType.NChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = OnBroj;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@RIDBroj";
            parameter20.SqlDbType = SqlDbType.NChar;
            parameter20.Size = 50;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = RidBroj;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Komentar";
            parameter21.SqlDbType = SqlDbType.NVarChar;
            parameter21.Size = 500;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Komentar;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@VozP";
            parameter22.SqlDbType = SqlDbType.Int;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = VozP;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Granicna";
            parameter23.SqlDbType = SqlDbType.Int;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Granicna;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Platilac";
            parameter24.SqlDbType = SqlDbType.Int;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Platilac;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@AdHoc";
            parameter25.SqlDbType = SqlDbType.TinyInt;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = AdHoc;
            myCommand.Parameters.Add(parameter25);

            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@PrevoznikZa";
            parameter26.SqlDbType = SqlDbType.Int;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = PrevoznikZa;
            myCommand.Parameters.Add(parameter26);

            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@Faktura";
            parameter27.SqlDbType = SqlDbType.NVarChar;
            parameter27.Size = 30;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = Faktura;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@Zadatak";
            parameter28.SqlDbType = SqlDbType.NVarChar;
            parameter28.Size = 50;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = Zadatak;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@CIM";
            parameter29.SqlDbType = SqlDbType.TinyInt;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = CIM;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@Korisnik";
            parameter30.SqlDbType = SqlDbType.NVarChar;
            parameter30.Size = 50;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = Korisnik;
            myCommand.Parameters.Add(parameter30);

            SqlParameter parameter31 = new SqlParameter();
            parameter31.ParameterName = "@DispecerRID";
            parameter31.SqlDbType = SqlDbType.NVarChar;
            parameter31.Size = 50;
            parameter31.Direction = ParameterDirection.Input;
            parameter31.Value = DispecerRid;
            myCommand.Parameters.Add(parameter31);

            SqlParameter parameter32 = new SqlParameter();
            parameter32.ParameterName = "@TipPrevoza";
            parameter32.SqlDbType = SqlDbType.Int;
            parameter32.Direction = ParameterDirection.Input;
            parameter32.Value = TipPrevoza;
            myCommand.Parameters.Add(parameter32);

            SqlParameter parameter33 = new SqlParameter();
            parameter33.ParameterName = "@NetoTezinaM";
            parameter33.SqlDbType = SqlDbType.Decimal;
            parameter33.Direction = ParameterDirection.Input;
            parameter33.Value = NetoTezinaM;
            myCommand.Parameters.Add(parameter33);

            SqlParameter parameter34 = new SqlParameter();
            parameter34.ParameterName = "@PorudzbinaID";
            parameter34.SqlDbType = SqlDbType.Int;
            parameter34.Direction = ParameterDirection.Input;
            parameter34.Value = PorudzbinaID;
            myCommand.Parameters.Add(parameter34);

            SqlParameter parameter35 = new SqlParameter();
            parameter35.ParameterName = "@ImaPovrat";
            parameter35.SqlDbType = SqlDbType.Int;
            parameter35.Direction = ParameterDirection.Input;
            parameter35.Value = ImaPovrat;
            myCommand.Parameters.Add(parameter35);

            SqlParameter parameter36 = new SqlParameter();
            parameter36.ParameterName = "@TehnologijaID";
            parameter36.SqlDbType = SqlDbType.Int;
            parameter36.Direction = ParameterDirection.Input;
            parameter36.Value = TehnologijaID;
            myCommand.Parameters.Add(parameter36);

            SqlParameter parameter37 = new SqlParameter();
            parameter37.ParameterName = "@RobaNHM2";
            parameter37.SqlDbType = SqlDbType.Int;
            parameter37.Direction = ParameterDirection.Input;
            parameter37.Value = RobaNHM2;
            myCommand.Parameters.Add(parameter37);

            SqlParameter parameter38 = new SqlParameter();
            parameter38.ParameterName = "@DodatnoPorudzbina";
            parameter38.SqlDbType = SqlDbType.NVarChar;
            parameter38.Size = 500;
            parameter38.Direction = ParameterDirection.Input;
            parameter38.Value = DodatnoPorudzbina;
            myCommand.Parameters.Add(parameter38);

            myConnection.Open();
            SqlTransaction myTransaction = myConnection.BeginTransaction();
            myCommand.Transaction = myTransaction;
            bool error = true;
            try
            {
                myCommand.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = myConnection.BeginTransaction();
                myCommand.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešan upis Najave u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos najave je uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void InsertVerzija(int ID, string BrojNajave, int Voz, int Posiljalac, int Prevoznik, int Otpravna, int Uputna, int Primalac, int RobaNHM, string PrevozniPut, double Tezina, double Duzina, int BrojKola, bool RID, System.DateTime PredvidjenoPrimanje, System.DateTime StvarnoPrimanje, System.DateTime PredvidjenaPredaja, System.DateTime StvarnaPredaja, int Status, string OnBroj, int Razlog, string RidBroj)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertNajavaVerzija";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@BrojNajave";
            parameter1.SqlDbType = SqlDbType.Char;
            parameter1.Size = 50;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = BrojNajave;
            myCommand.Parameters.Add(parameter1);


            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Voz";
            parameter2.SqlDbType = SqlDbType.Int;
          
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Voz;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Posiljalac";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Posiljalac;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Prevoznik";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Prevoznik;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Otpravna";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Otpravna;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Uputna";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Uputna;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Primalac";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Primalac;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@RobaNHM";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = RobaNHM;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@PrevozniPut";
            parameter9.SqlDbType = SqlDbType.NChar;
            parameter9.Size = 50;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = PrevozniPut;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Tezina";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Tezina;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Duzina";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Duzina;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@BrojKola";
            parameter12.SqlDbType = SqlDbType.Int;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = BrojKola;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@RID";
            parameter13.SqlDbType = SqlDbType.TinyInt;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = RID;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@PredvidjenoPrimanje";
            parameter14.SqlDbType = SqlDbType.DateTime;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = PredvidjenoPrimanje;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@StvarnoPrimanje";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = StvarnoPrimanje;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@PredvidjenaPredaja";
            parameter16.SqlDbType = SqlDbType.DateTime;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = PredvidjenaPredaja;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@StvarnaPredaja";
            parameter17.SqlDbType = SqlDbType.DateTime;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = StvarnaPredaja;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Status";
            parameter18.SqlDbType = SqlDbType.Int;
           
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = StvarnaPredaja;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@OnBroj";
            parameter19.SqlDbType = SqlDbType.NChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = OnBroj;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Razlog";
            parameter20.SqlDbType = SqlDbType.Int;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Razlog;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@RIDBroj";
            parameter21.SqlDbType = SqlDbType.Int;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = RidBroj;
            myCommand.Parameters.Add(parameter21);

            /*
            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@DispecerRID";
            parameter22.SqlDbType = SqlDbType.Int;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = DispecerRID;
            myCommand.Parameters.Add(parameter22);

            */
            myConnection.Open();
            SqlTransaction myTransaction = myConnection.BeginTransaction();
            myCommand.Transaction = myTransaction;
            bool error = true;
            try
            {
                myCommand.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = myConnection.BeginTransaction();
                myCommand.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešna izmena Najave");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos najave je uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void UpdNaj(int ID, string BrojNajave, int Voz, int Posiljalac, int Prevoznik, int Otpravna, int Uputna, int Primalac, int RobaNHM, string PrevozniPut, double Tezina, double Duzina, int BrojKola, bool RID, System.DateTime PredvidjenoPrimanje, System.DateTime StvarnoPrimanje, System.DateTime PredvidjenaPredaja, System.DateTime StvarnaPredaja, int Status, string OnBroj, string RIDBroj, string Komentar, int VozP, int Granicna, int Platilac, bool AdHoc, int PrevoznikZa, string Faktura, string Zadatak, bool CIM, string Korisnik, string DispecerRid, int TipPrevoza, double NetoTezinaM, int PorudzbinaID, int ImaPovrat, int TehnologijaID, int RobaNHM2, string DodatnoPorudzbina)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateNajava";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;

            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@BrojNajave";
            parameter1.SqlDbType = SqlDbType.Char;
            parameter1.Size = 50;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = BrojNajave;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Voz";
            parameter2.SqlDbType = SqlDbType.Int;
            
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Voz;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Posiljalac";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Posiljalac;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Prevoznik";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Prevoznik;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Otpravna";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Otpravna;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Uputna";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Uputna;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Primalac";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Primalac;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@RobaNHM";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = RobaNHM;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@PrevozniPut";
            parameter9.SqlDbType = SqlDbType.NChar;
            parameter9.Size = 50;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = PrevozniPut;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Tezina";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Tezina;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Duzina";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Duzina;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@BrojKola";
            parameter12.SqlDbType = SqlDbType.Int;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = BrojKola;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@RID";
            parameter13.SqlDbType = SqlDbType.TinyInt;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = RID;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@PredvidjenoPrimanje";
            parameter14.SqlDbType = SqlDbType.DateTime;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = PredvidjenoPrimanje;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@StvarnoPrimanje";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = StvarnoPrimanje;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@PredvidjenaPredaja";
            parameter16.SqlDbType = SqlDbType.DateTime;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = PredvidjenaPredaja;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@StvarnaPredaja";
            parameter17.SqlDbType = SqlDbType.DateTime;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = StvarnaPredaja;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Status";
            parameter18.SqlDbType = SqlDbType.Int;
       
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Status;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@OnBroj";
            parameter19.SqlDbType = SqlDbType.NChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = OnBroj;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@RIDBroj";
            parameter20.SqlDbType = SqlDbType.NChar;
            parameter20.Size = 50;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = RIDBroj;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@komentar";
            parameter21.SqlDbType = SqlDbType.NChar;
            parameter21.Size = 500;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Komentar;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@VozP";
            parameter22.SqlDbType = SqlDbType.Int;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = VozP;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Granicna";
            parameter23.SqlDbType = SqlDbType.Int;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Granicna;
            myCommand.Parameters.Add(parameter23);


            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Platilac";
            parameter24.SqlDbType = SqlDbType.Int;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Platilac;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@AdHoc";
            parameter25.SqlDbType = SqlDbType.TinyInt;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = AdHoc;
            myCommand.Parameters.Add(parameter25);


            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@PrevoznikZa";
            parameter26.SqlDbType = SqlDbType.Int;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = PrevoznikZa;
            myCommand.Parameters.Add(parameter26);

            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@Faktura";
            parameter27.SqlDbType = SqlDbType.NVarChar;
            parameter27.Size = 30;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = Faktura;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@Zadatak";
            parameter28.SqlDbType = SqlDbType.NVarChar;
            parameter28.Size = 50;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = Zadatak;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@CIM";
            parameter29.SqlDbType = SqlDbType.TinyInt;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = CIM;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@Korisnik";
            parameter30.SqlDbType = SqlDbType.NVarChar;
            parameter30.Size = 50;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = Korisnik;
            myCommand.Parameters.Add(parameter30);

            SqlParameter parameter31 = new SqlParameter();
            parameter31.ParameterName = "@DispecerRid";
            parameter31.SqlDbType = SqlDbType.NVarChar;
            parameter31.Size = 50;
            parameter31.Direction = ParameterDirection.Input;
            parameter31.Value = DispecerRid;
            myCommand.Parameters.Add(parameter31);

            SqlParameter parameter32 = new SqlParameter();
            parameter32.ParameterName = "@TipPrevoza";
            parameter32.SqlDbType = SqlDbType.Int;
            parameter32.Direction = ParameterDirection.Input;
            parameter32.Value = TipPrevoza;
            myCommand.Parameters.Add(parameter32);


            SqlParameter parameter33 = new SqlParameter();
            parameter33.ParameterName = "@NetoTezinaM";
            parameter33.SqlDbType = SqlDbType.Decimal;
            parameter33.Direction = ParameterDirection.Input;
            parameter33.Value = NetoTezinaM;
            myCommand.Parameters.Add(parameter33);

            SqlParameter parameter34 = new SqlParameter();
            parameter34.ParameterName = "@PorudzbinaID";
            parameter34.SqlDbType = SqlDbType.Int;
            parameter34.Direction = ParameterDirection.Input;
            parameter34.Value = PorudzbinaID;
            myCommand.Parameters.Add(parameter34);

            SqlParameter parameter35 = new SqlParameter();
            parameter35.ParameterName = "@ImaPovrat";
            parameter35.SqlDbType = SqlDbType.Int;
            parameter35.Direction = ParameterDirection.Input;
            parameter35.Value = ImaPovrat;
            myCommand.Parameters.Add(parameter35);


            SqlParameter parameter36 = new SqlParameter();
            parameter36.ParameterName = "@TehnologijaID";
            parameter36.SqlDbType = SqlDbType.Int;
            parameter36.Direction = ParameterDirection.Input;
            parameter36.Value = TehnologijaID;
            myCommand.Parameters.Add(parameter36);

            SqlParameter parameter37 = new SqlParameter();
            parameter37.ParameterName = "@RobaNHM2";
            parameter37.SqlDbType = SqlDbType.Int;
            parameter37.Direction = ParameterDirection.Input;
            parameter37.Value = RobaNHM2;
            myCommand.Parameters.Add(parameter37);

            SqlParameter parameter38 = new SqlParameter();
            parameter38.ParameterName = "@DodatnoPorudzbina";
            parameter38.SqlDbType = SqlDbType.NVarChar;
            parameter38.Size = 500;
            parameter38.Direction = ParameterDirection.Input;
            parameter38.Value = DodatnoPorudzbina;
            myCommand.Parameters.Add(parameter38);

            myConnection.Open();
            SqlTransaction myTransaction = myConnection.BeginTransaction();
            myCommand.Transaction = myTransaction;
            bool error = true;
            try
            {
                myCommand.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = myConnection.BeginTransaction();
                myCommand.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešna izmena Najave");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos najave je uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void DeleteNaj(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteNajava";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            myConnection.Open();
            SqlTransaction myTransaction = myConnection.BeginTransaction();
            myCommand.Transaction = myTransaction;
            bool error = true;
            try
            {
                myCommand.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = myConnection.BeginTransaction();
                myCommand.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Brisanje neuspešno");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Brisanje stanice uspešno završeno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void InsNajDodatneUSluge(int PorudzbinaID, int NajavaID)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertNajavaDodatneUsluge";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDPorudzbinaID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = PorudzbinaID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDNajava";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = NajavaID;
            myCommand.Parameters.Add(parameter2);






            myConnection.Open();
            SqlTransaction myTransaction = myConnection.BeginTransaction();
            myCommand.Transaction = myTransaction;
            bool error = true;
            try
            {
                myCommand.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = myConnection.BeginTransaction();
                myCommand.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešan upis Najave u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos najave je uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }


        public void InsNajDeljenjeVoza(int PorudzbinaID, int NajavaID, int BrojKola, double Tezina)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertNajavaDeljenjeVoza";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDPorudzbinaID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = PorudzbinaID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDNajava";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = NajavaID;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@BrojKola";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = BrojKola;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Tezina";
            parameter4.SqlDbType = SqlDbType.Decimal;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Tezina;
            myCommand.Parameters.Add(parameter4);


            myConnection.Open();
            SqlTransaction myTransaction = myConnection.BeginTransaction();
            myCommand.Transaction = myTransaction;
            bool error = true;
            try
            {
                myCommand.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = myConnection.BeginTransaction();
                myCommand.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešan upis Najave u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos najave je uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }


    }
}
