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
    /* @BrojTeretnice nvarchar(50),
          @StanicaOd int,
          @StanicaDo int,
          @StanicaPopisa int,
          @VremeOd datetime,
          @VremeDo datetime,
          @BrojLista nvarchar(20) */

    class InsertTeretnica
    {
        public void InsTeretnica(string BrojTeretnice, int StanicaOd, int StanicaDo, int StanicaPopisa, DateTime VremeOd, DateTime VremeDo, string BrojLista, int Prijemna, int Predajna, string Korisnik, int Prevozna, int RN)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertTeretnica";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@BrojTeretnice";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 50;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = BrojTeretnice;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@StanicaOd";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = StanicaOd;
            myCommand.Parameters.Add(parameter2);

           SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@StanicaDo";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = StanicaDo;
            myCommand.Parameters.Add(parameter3); 

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@StanicaPopisa";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = StanicaPopisa;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@VremeOd";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = VremeOd;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@VremeDo";
            parameter6.SqlDbType = SqlDbType.DateTime;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = VremeDo;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@BrojLista";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = BrojLista;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Prijemna";
            parameter8.SqlDbType = SqlDbType.TinyInt;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Prijemna;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Predajna";
            parameter9.SqlDbType = SqlDbType.TinyInt;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Predajna;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Korisnik";
            parameter10.SqlDbType = SqlDbType.NVarChar;
            parameter10.Size = 50;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Korisnik;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Prevozna";
            parameter11.SqlDbType = SqlDbType.TinyInt;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Prevozna;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@RN";
            parameter12.SqlDbType = SqlDbType.Int;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Prevozna;
            myCommand.Parameters.Add(parameter12);

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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdTeretnica(int ID, string BrojTeretnice, int StanicaOd, int StanicaDo, int StanicaPopisa, DateTime VremeOd, DateTime VremeDo, string BrojLista, int Prijemna, int Predajna, string Korisnik, int Prevozna, int RN)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTeretnica";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            //parameter.Size = 50;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@BrojTeretnice";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 50;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = BrojTeretnice;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@StanicaOd";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = StanicaOd;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@StanicaDo";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = StanicaDo;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@StanicaPopisa";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = StanicaPopisa;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@VremeOd";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = VremeOd;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@VremeDo";
            parameter6.SqlDbType = SqlDbType.DateTime;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = VremeDo;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@BrojLista";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = BrojLista;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Prijemna";
            parameter8.SqlDbType = SqlDbType.TinyInt;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Prijemna;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Predajna";
            parameter9.SqlDbType = SqlDbType.TinyInt;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Predajna;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Korisnik";
            parameter10.SqlDbType = SqlDbType.NVarChar;
            parameter10.Size = 50;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Korisnik;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Prevozna";
            parameter11.SqlDbType = SqlDbType.TinyInt;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Prevozna;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@RN";
            parameter12.SqlDbType = SqlDbType.Int;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = RN;
            myCommand.Parameters.Add(parameter12);


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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdNajavaCIM(int ID, string Korisnik)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateNajavaTerStampa";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            //parameter.Size = 50;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Korisnik";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 50;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Korisnik;
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

            catch (SqlException)
            {
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void DeleteTeretnica(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteTeretnica";
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
                    MessageBox.Show("Brisanje Teretnice uspešno završeno", "",
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