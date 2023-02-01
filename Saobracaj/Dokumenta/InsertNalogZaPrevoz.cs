using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TrackModal.Dokumeta
{
    class InsertNalogZaPrevoz
    {
        public void InsNalogZaPrevoz(string BrojKontejnera1, string BrojKontejnera2, double UkupnaMasa, string Relacija1, string Relacija2, DateTime DatumPrevoza, string VrstaRobe, double UkupnaMasa2, int Platilac, int OrganizacionaJedinica, string UtovarnoMesto, string IstovarnoMesto, string KontaktOsoba, string Napomena, DateTime Datum, string Korisnik, int Primalac, int statusrn, DateTime DatumUtovara, DateTime PredvidjenoDatumUtovara, string TipKontejnera1, string TipKontejnera2, int VrstaRobeID, double NetoMasaRobe)
        {


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertNaloziZaPrevoz";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


            /*
           @BrojKontejnera1 nvarchar(20),
           @BrojKontejnera2 nvarchar(20),
           @UkupnaMasa numeric(18,2),
           @Relacija1 nvarchar(30),
           @Relacija2 nvarchar(30),
           @DatumPrevoza datetime,
           @VrstaRobe nvarchar(30),
           @UkupnaMasa2 numeric(18,2),
           @Platilac int,
           @OrganizacionaJedinica int,
           @UtovarnoMesto nvarchar(70),
           @IstovarnoMesto nvarchar(70),
           @KontaktOsoba nvarchar(70),
           @Napomena nvarchar(300),
           @Datum datetime,
           @Korisnik nvarchar(20)
            */
          

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@BrojKontejnera1";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 20;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value =  BrojKontejnera1;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@BrojKontejnera2";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value =  BrojKontejnera2;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@UkupnaMasa";
            parameter3.SqlDbType = SqlDbType.Decimal;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = UkupnaMasa;
            myCommand.Parameters.Add(parameter3);


             SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Relacija1";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 30;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value =  Relacija1;
            myCommand.Parameters.Add(parameter4);
           
      SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Relacija2";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 30;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value =  Relacija2;
            myCommand.Parameters.Add(parameter5);

               SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@DatumPrevoza";
            parameter6.SqlDbType = SqlDbType.DateTime;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = DatumPrevoza;
            myCommand.Parameters.Add(parameter6);

             SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@VrstaRobe";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 30;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value =  VrstaRobe;
            myCommand.Parameters.Add(parameter7);

               SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@UkupnaMasa2";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = UkupnaMasa2;
            myCommand.Parameters.Add(parameter8);

              SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Platilac";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Platilac;
            myCommand.Parameters.Add(parameter9);
       
          SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@OrganizacionaJedinica";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = OrganizacionaJedinica;
            myCommand.Parameters.Add(parameter10);
        
            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@UtovarnoMesto";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 70;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value =  UtovarnoMesto;
            myCommand.Parameters.Add(parameter11);
       
          SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@IstovarnoMesto";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 70;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value =  IstovarnoMesto;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@KontaktOsoba";
            parameter13.SqlDbType = SqlDbType.NVarChar;
            parameter13.Size = 70;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value =  KontaktOsoba;
            myCommand.Parameters.Add(parameter13);

           SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Napomena";
            parameter14.SqlDbType = SqlDbType.NVarChar;
            parameter14.Size = 300;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value =  Napomena;
            myCommand.Parameters.Add(parameter14);
          
              SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Datum";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Datum;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Korisnik";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Korisnik;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Primalac";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Primalac;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@statusrn";
            parameter18.SqlDbType = SqlDbType.Int;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = statusrn;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@DatumUtovara";
            parameter19.SqlDbType = SqlDbType.DateTime;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = DatumUtovara;
            myCommand.Parameters.Add(parameter19);


            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@PredvidjenoDatumUtovara";
            parameter20.SqlDbType = SqlDbType.DateTime;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = PredvidjenoDatumUtovara;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@TipKontejnera1";
            parameter21.SqlDbType = SqlDbType.NVarChar;
            parameter21.Size = 40;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = TipKontejnera1;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@TipKontejnera2";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 40;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = TipKontejnera2;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@VrstaRobeId";
            parameter23.SqlDbType = SqlDbType.Int;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = VrstaRobeID;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@NetoMasaRobe";
            parameter24.SqlDbType = SqlDbType.Decimal;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = NetoMasaRobe;
            myCommand.Parameters.Add(parameter24);

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
                throw new Exception("Neuspešan upis cena u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis cena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdNaloziZaPrevoz(int ID, string BrojKontejnera1, string BrojKontejnera2, double UkupnaMasa, string Relacija1, string Relacija2, DateTime DatumPrevoza, string VrstaRobe, double UkupnaMasa2, int Platilac, int OrganizacionaJedinica, string UtovarnoMesto, string IstovarnoMesto, string KontaktOsoba, string Napomena, DateTime Datum, string Korisnik, int Primalac, int statusrn,  DateTime DatumUtovara, DateTime PredvidjenoDatumUtovara, string TipKontejnera1, string TipKontejnera2, int VrstaRobeID, double NetoMasaRobe)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateNaloziZaprevoz";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@BrojKontejnera1";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 20;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = BrojKontejnera1;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@BrojKontejnera2";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = BrojKontejnera2;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@UkupnaMasa";
            parameter3.SqlDbType = SqlDbType.Decimal;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = UkupnaMasa;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Relacija1";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 30;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Relacija1;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Relacija2";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 30;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Relacija2;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@DatumPrevoza";
            parameter6.SqlDbType = SqlDbType.DateTime;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = DatumPrevoza;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@VrstaRobe";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 30;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = VrstaRobe;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@UkupnaMasa2";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = UkupnaMasa2;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Platilac";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Platilac;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@OrganizacionaJedinica";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = OrganizacionaJedinica;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@UtovarnoMesto";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 70;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = UtovarnoMesto;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@IstovarnoMesto";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 70;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = IstovarnoMesto;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@KontaktOsoba";
            parameter13.SqlDbType = SqlDbType.NVarChar;
            parameter13.Size = 70;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = KontaktOsoba;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Napomena";
            parameter14.SqlDbType = SqlDbType.NVarChar;
            parameter14.Size = 300;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Napomena;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Datum";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Datum;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Korisnik";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Korisnik;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Primalac";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Primalac;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@statusrn";
            parameter18.SqlDbType = SqlDbType.Int;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = statusrn;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@DatumUtovara";
            parameter19.SqlDbType = SqlDbType.DateTime;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = DatumUtovara;
            myCommand.Parameters.Add(parameter19);


            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@PredvidjenoDatumUtovara";
            parameter20.SqlDbType = SqlDbType.DateTime;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = PredvidjenoDatumUtovara;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@TipKontejnera1";
            parameter21.SqlDbType = SqlDbType.NVarChar;
            parameter21.Size = 40;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = TipKontejnera1;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@TipKontejnera2";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 40;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = TipKontejnera2;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@VrstaRobeId";
            parameter23.SqlDbType = SqlDbType.Int;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = VrstaRobeID;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@NetoMasaRobe";
            parameter24.SqlDbType = SqlDbType.Decimal;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = NetoMasaRobe;
            myCommand.Parameters.Add(parameter24);


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
                throw new Exception("Neuspešan upis aktivnosti u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis aktivnosti", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void DeleteNaloziZaPrevoz(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteNalogZaPrevoz";
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
                    MessageBox.Show("Brisanje Voza uspešno završeno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void InsNalogZaPrevozTroskovi(int ID, int VrstaManipulacijeID, DateTime Datum, string Korisnik, double Popust)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertNaloziZaPrevozTrosak";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@ID";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = ID;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@VrstaManipulacijeID";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = VrstaManipulacijeID;
            myCommand.Parameters.Add(parameter2);

           
            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Datum";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Datum;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Korisnik";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Korisnik;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Popust";
            parameter17.SqlDbType = SqlDbType.Decimal;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Popust;
            myCommand.Parameters.Add(parameter17);


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

            catch (SqlException ex)
            {
                throw new Exception("Neuspešan upis  u bazu" + ex.ErrorCode);
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdNalogZaPrevozTroskovi(int ID, double Popust)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateNaloziZaPrevozTrosak";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@ID";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = ID;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Popust";
            parameter2.SqlDbType = SqlDbType.Decimal;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Popust;
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

            catch (SqlException ex)
            {
                throw new Exception("Neuspešan upis  u bazu" + ex.ErrorCode);
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void DelNalogZaPrevozTroskovi(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteNajavaPrevozaTroskovi";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@ID";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = ID;
            myCommand.Parameters.Add(parameter1);

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

            catch (SqlException ex)
            {
                throw new Exception("Neuspešan upis  u bazu" + ex.ErrorCode);
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
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
