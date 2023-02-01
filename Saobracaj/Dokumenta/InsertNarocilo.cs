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
    class InsertNarocilo
    {
        public void InsNarocilo(string NaStatus, DateTime NaDatNar, int NaPartPlac, int NaNacinDobave, int NaSifObjekt, string NaOpomba1)
        {
         // int  NaStNar ,  string NaStatus , DateTime    NaDatNar ,        int    NaPartPlac,        int  NaNacinDobave ,        int   NaSifObjekt ,        string   NaOpomba1 


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertNarocilo";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@NaStatus";
            parameter1.SqlDbType = SqlDbType.Char;
            parameter1.Size = 2;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = NaStatus;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@NaDatNar";
            parameter2.SqlDbType = SqlDbType.DateTime;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = NaDatNar;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@NaPartPlac";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = NaPartPlac;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@NaNacinDobave";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = NaNacinDobave;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@NaSifObjekt";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = NaSifObjekt;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6= new SqlParameter();
            parameter6.ParameterName = "@NaOpomba1";
            parameter6.SqlDbType = SqlDbType.VarChar;
            parameter1.Size = 255;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = NaOpomba1;
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
                throw new Exception("Neuspešan upis  u Bazu");
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

        public void UpdNarocilo(int NaStNar, string NaStatus, DateTime NaDatNar, int NaPartPlac, int NaNacinDobave, int NaSifObjekt, string NaOpomba1)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateNarocilo";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@NaStNar";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = NaStNar;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@NaStatus";
            parameter1.SqlDbType = SqlDbType.Char;
            parameter1.Size = 2;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = NaStatus;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@NaDatNar";
            parameter2.SqlDbType = SqlDbType.DateTime;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = NaDatNar;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@NaPartPlac";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = NaPartPlac;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@NaNacinDobave";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = NaNacinDobave;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@NaSifObjekt";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = NaSifObjekt;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@NaOpomba1";
            parameter6.SqlDbType = SqlDbType.VarChar;
            parameter1.Size = 255;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = NaOpomba1;
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

        public void DeleteNarocilo(int NaStNar)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteNarocilo";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@NaStNar";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = NaStNar;
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


        public void InsNarociloStavka(int NaPstNar, int NaPSifra, string NaPNaziv, string NaPEM, string NaPem2, decimal NaPKolNar, decimal NaPKolNar2, string NaPOpomba, string NaPNote)
        {
            // int  NaStNar ,  string NaStatus , DateTime    NaDatNar ,        int    NaPartPlac,        int  NaNacinDobave ,        int   NaSifObjekt ,        string   NaOpomba1 
            // NaPNarZap,NaPstNar,NaPSifra,NaPNaziv,NaPEM,NaPem2,NaPKolNar,NaPKolNar2,NaPOpomba,NaPNote
            /*
            @NaPNarZap int,
          @NaPStNar int,
          @NaPSifra int,
          @NaPNaziv char(70),
           @NaPEM char(3),
           @NaPEM2 char(3),
           @NaPKolNar decimal(18, 2),
           @NaPKolNar2 decimal(18, 2),
           @NaPOpomba varchar(255),
           @NaPNote nvarchar(100)
            */

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertNarociloStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@NaPStNar";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = NaPstNar;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@NaPSifra";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = NaPSifra;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@NaPNaziv";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 70;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = NaPNaziv;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@NaPEM";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 3;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = NaPEM;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@NaPEM2";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 3;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = NaPem2;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@NaPKolNar";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = NaPKolNar;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@NaPKolNar2";
            parameter7.SqlDbType = SqlDbType.Decimal;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = NaPKolNar2;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@NaPOpomba";
            parameter8.SqlDbType = SqlDbType.VarChar;
            parameter8.Size = 255;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = NaPOpomba;
            myCommand.Parameters.Add(parameter8);


            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@NaPNote";
            parameter9.SqlDbType = SqlDbType.NVarChar;
            parameter9.Size = 100;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = NaPNote;
            myCommand.Parameters.Add(parameter9);

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
                throw new Exception("Neuspešan upis  u Bazu");
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

        public void UpdNarociloStavka(int NaPNarZap, int NaPstNar, int NaPSifra, string NaPNaziv, string NaPEM, string NaPem2, decimal NaPKolNar, decimal NaPKolNar2, string NaPOpomba, string NaPNote)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateNarociloStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@NaPNarZap";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = NaPNarZap;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@NaPstNar";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = NaPstNar;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@NaPSifra";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = NaPSifra;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@NaPNaziv";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 70;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = NaPNaziv;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@NaPEM";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 3;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = NaPEM;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@NaPEM2";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 3;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = NaPem2;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@NaPKolNar";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = NaPKolNar;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@NaPKolNar2";
            parameter7.SqlDbType = SqlDbType.Decimal;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = NaPKolNar2;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@NaPOpomba";
            parameter8.SqlDbType = SqlDbType.VarChar;
            parameter8.Size = 255;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = NaPOpomba;
            myCommand.Parameters.Add(parameter8);


            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@NaPNote";
            parameter9.SqlDbType = SqlDbType.NVarChar;
            parameter9.Size = 100;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = NaPNote;
            myCommand.Parameters.Add(parameter9);

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

        public void DeleteNarociloStavka(int NaPNarZap)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteNarociloStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@NaPNarZap";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = NaPNarZap;
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
    }
}
