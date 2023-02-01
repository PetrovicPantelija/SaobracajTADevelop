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
    class InsertPotNal
    {
        public void InsPotNal(int Radnik, int Kraj, int KrajO, string MestoTroska, DateTime DatumOdlaska, DateTime DatumDolaska, int DanaOdsustva, double Iznos, string OpisRada)
        {
           
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPotNal";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Radnik";
            parameter.SqlDbType = SqlDbType.Int;
           // parameter.Size = 50;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Radnik;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Kraj";
            parameter2.SqlDbType = SqlDbType.Int;
        
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Kraj;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@KrajO";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = KrajO;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@MestoTroska";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 8;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = MestoTroska;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@DatumOdlaska";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = DatumOdlaska;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@DatumDolaska";
            parameter6.SqlDbType = SqlDbType.DateTime;
           
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = DatumDolaska;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@DanaOdsustva";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = DanaOdsustva;
            myCommand.Parameters.Add(parameter7);
          
      

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Iznos";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Iznos;
            myCommand.Parameters.Add(parameter10);

         
      
            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@OpisRada";
            parameter19.SqlDbType = SqlDbType.NChar;
            parameter19.Size = 100;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = OpisRada;
            myCommand.Parameters.Add(parameter19);

          
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
                throw new Exception("Neuspešan upis zaglavlja Putnog Naloga u bazu");
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

        public void InsPotNalRelacije(int Radnik, int Kraj, int KrajO, int DanaOdsustva, DateTime DatumOdlaska, DateTime DatumDolaska)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPotNalRelacije";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Radnik";
            parameter.SqlDbType = SqlDbType.Int;
            // parameter.Size = 50;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Radnik;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Kraj";
            parameter2.SqlDbType = SqlDbType.Int;

            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Kraj;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@KrajO";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = KrajO;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Kolicina";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = DanaOdsustva;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@DatumOdlaska";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = DatumOdlaska;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@DatumDolaska";
            parameter6.SqlDbType = SqlDbType.DateTime;

            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = DatumDolaska;
            myCommand.Parameters.Add(parameter6);


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
                throw new Exception("Neuspešan upis relacija Putnog Naloga u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos putnog naloga relacija je uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void InsPotNalStavke(int DanaOdsustva,double Cena ,double Iznos, int Puna)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPotNalStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            
            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Kolicina";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = DanaOdsustva;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Cena";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Cena;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Iznos";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Iznos;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Puna";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Puna;
            myCommand.Parameters.Add(parameter11);


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
                throw new Exception("Neuspešan upis zaglavlja Putnog Naloga u bazu");
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

        public void UpdPotNal(int ID)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAktivnostiPutniNalog";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@ID";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = ID;
            myCommand.Parameters.Add(parameter7);



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
                throw new Exception("Neuspešan upis zaglavlja Putnog Naloga u bazu");
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

