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
    class InsertRadniNalogTransport
    {
        public void InsRadniNalogZaTransport(  int IdNalogZaPrevoz, int IDPutniNalog, int IDAutoprevozniList, int Vozilo, DateTime Dana, int TransportniDispecer, string MestoIzdavanja, DateTime DatumPrevoza,  DateTime Datum, string Korisnik, int PrikljucnoVoziloID, string RelacijaOd, string RelacijaDo, string BrojOtpravljanja, double BrojVagona, double NetoMasa, DateTime DatumIstovara, string BrVoza)
        {
           

             /* @PrikljucnoVoziloID int,
          @RelacijaOd nvarchar(40),
             @RelacijaDo nvarchar(40),
             @BrojOtpravljanja nvarchar(40),
             @BrojVagona decimal(18, 0),
             @NetoMasa decimal(18, 0),
             @DatumIstovara DateTime
            */

             var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertRadniNalogTransport";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDNalogZaPrevoz";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IdNalogZaPrevoz;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDPutniNalog";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = IDPutniNalog;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@IDAutoprevoznilist";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = IDAutoprevozniList;
            myCommand.Parameters.Add(parameter3);

         
    

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@IDVozilo";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Vozilo;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Dana";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Dana;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@TransportniDispecer";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = TransportniDispecer;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@DatumPrevoza";
            parameter8.SqlDbType = SqlDbType.DateTime;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = DatumPrevoza;
            myCommand.Parameters.Add(parameter8);
            
		  
            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@MestoIzdavanja";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 50;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = MestoIzdavanja;
            myCommand.Parameters.Add(parameter7);

           

         
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
            parameter17.ParameterName = "@PrikljucnoVoziloID";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = PrikljucnoVoziloID;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@RelacijaOd";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 40;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = RelacijaOd;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@RelacijaDo";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 40;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = RelacijaDo;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@BrojOtpravljanja";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 40;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = BrojOtpravljanja;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@BrojVagona";
            parameter21.SqlDbType = SqlDbType.Decimal;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = BrojVagona;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@NetoMasa";
            parameter22.SqlDbType = SqlDbType.Decimal;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = NetoMasa;
            myCommand.Parameters.Add(parameter22);

         
            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@DatumIstovara";
            parameter23.SqlDbType = SqlDbType.DateTime;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = DatumIstovara;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@BrVoza";
            parameter24.SqlDbType = SqlDbType.NVarChar;
            parameter24.Size = 30;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = BrVoza;
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
                throw new Exception("Neuspešan upis u bazu");
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

        public void UpdRadniNalogZaTransport(int ID, int IdNalogZaPrevoz, int IDPutniNalog, int IDAutoprevozniList, int Vozilo, DateTime Dana, int TransportniDispecer, string MestoIzdavanja, DateTime DatumPrevoza, DateTime Datum, string Korisnik, int PrikljucnoVoziloID, string RelacijaOd, string RelacijaDo, string BrojOtpravljanja, double BrojVagona, double NetoMasa, DateTime DatumIstovara, string BrVoza)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateRadniNalogZaTransport";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);




            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDNalogZaPrevoz";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IdNalogZaPrevoz;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDPutniNalog";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = IDPutniNalog;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@IDAutoprevoznilist";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = IDAutoprevozniList;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Vozilo";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Vozilo;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Dana";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Dana;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@TransportniDispecer";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = TransportniDispecer;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@MestoIzdavanja";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 30;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = MestoIzdavanja;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@DatumPrevoza";
            parameter8.SqlDbType = SqlDbType.DateTime;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = DatumPrevoza;
            myCommand.Parameters.Add(parameter8);


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
            parameter17.ParameterName = "@PrikljucnoVoziloID";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = PrikljucnoVoziloID;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@RelacijaOd";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 40;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = RelacijaOd;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@RelacijaDo";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 40;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = RelacijaDo;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@BrojOtpravljanja";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 40;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = BrojOtpravljanja;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@BrojVagona";
            parameter21.SqlDbType = SqlDbType.Decimal;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = BrojVagona;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@NetoMasa";
            parameter22.SqlDbType = SqlDbType.Decimal;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = NetoMasa;
            myCommand.Parameters.Add(parameter22);


            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@DatumIstovara";
            parameter23.SqlDbType = SqlDbType.DateTime;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = DatumIstovara;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@BrVoza";
            parameter24.SqlDbType = SqlDbType.NVarChar;
            parameter24.Size = 30;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = DatumIstovara;
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

        public void DelRadniNalogZaTransport(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteRadniNalogZaTransport";
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
    }
}
