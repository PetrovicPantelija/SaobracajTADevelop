using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Saobracaj.Sifarnici
{
    class InsertMaticniPodatki
    {
        public void InsMaticniPodatki( string MpStaraSif, string MpNaziv, string MpDoNaziv, string MpSifEnoteMere1, string MpSifEnoteMere2, int MpSifProdSkup)
        {


            /*
            @MpSifra int,
     @MpStaraSif char(24),
           @MpNaziv char(35),
           @MpDoNaziv char(60),
           @MpSifEnoteMere1 char(3),
           @MpSifEnoteMere2 char(3)
            */

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertMaticniPodatki";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            /*
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@MpSifra";
            parameter.SqlDbType = SqlDbType.Int;
            //  parameter.Size = 100;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = MpSifra;
            myCommand.Parameters.Add(parameter);
            */
          

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@MpStaraSif";
            parameter2.SqlDbType = SqlDbType.Char;
            parameter2.Size = 24;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = MpStaraSif;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@MpNaziv";
            parameter3.SqlDbType = SqlDbType.Char;
              parameter3.Size = 35;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = MpNaziv;
            myCommand.Parameters.Add(parameter3);
           
            
            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@MpDoNaziv";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 60;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = MpDoNaziv;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@MpSifEnoteMere1";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 3;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = MpSifEnoteMere1;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@MpSifEnoteMere2";
            parameter6.SqlDbType = SqlDbType.Char;
            parameter6.Size = 3;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = MpSifEnoteMere2;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@MpSifProdSkup";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = MpSifProdSkup;
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
                throw new Exception("Neuspešan upis ");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos je uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void UpdMaticniPodatki(int MpSifra, string MpStaraSif, string MpNaziv, string MpDoNaziv, string MpSifEnoteMere1, string MpSifEnoteMere2, int MpSifProdSkup)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateMaticniPodatki";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

           
           SqlParameter parameter = new SqlParameter();
           parameter.ParameterName = "@MpSifra";
           parameter.SqlDbType = SqlDbType.Int;
           //  parameter.Size = 100;
           parameter.Direction = ParameterDirection.Input;
           parameter.Value = MpSifra;
           myCommand.Parameters.Add(parameter);
           


            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@MpStaraSif";
            parameter2.SqlDbType = SqlDbType.Char;
            parameter2.Size = 24;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = MpStaraSif;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@MpNaziv";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 35;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = MpNaziv;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@MpDoNaziv";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 60;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = MpDoNaziv;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@MpSifEnoteMere1";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 3;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = MpSifEnoteMere1;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@MpSifEnoteMere2";
            parameter6.SqlDbType = SqlDbType.Char;
            parameter6.Size = 3;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = MpSifEnoteMere2;
            myCommand.Parameters.Add(parameter6);


            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@MpSifProdSkup";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = MpSifProdSkup;
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
                throw new Exception("Neuspešna promena ");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Promena  je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void DeleteMaticniPodatki(int MpSifra)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteMaticniPOdatki";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@MpSifra";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = MpSifra;
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
                    MessageBox.Show("Brisanje nije uspešno", "",
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
