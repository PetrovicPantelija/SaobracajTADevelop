using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Testiranje.Sifarnici
{
    class InsertTipKontejnera
    {

        public void InsTipKontejnera(string Naziv, double Duzina, double Sirina, double Visina, double Tara, DateTime Datum, string Korisnik, string SkNaziv, string Velicina)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertTipKontenjera";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Naziv";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Naziv;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Duzina";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Duzina;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Sirina";
            parameter12.SqlDbType = SqlDbType.Decimal;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Sirina;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Visina";
            parameter13.SqlDbType = SqlDbType.Decimal;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Visina;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Tara";
            parameter14.SqlDbType = SqlDbType.Decimal;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Tara;
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
            parameter17.ParameterName = "@SkNaziv";
            parameter17.SqlDbType = SqlDbType.NVarChar;
            parameter17.Size = 20;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = SkNaziv;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Velicina";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Velicina;
            myCommand.Parameters.Add(parameter18);



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
                throw new Exception("Neuspešan upis  u bazu");
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

        public void UpdTipKontejnera(int ID, string Naziv, double Duzina, double Sirina, double Visina, double Tara, DateTime Datum, string Korisnik, string SkNaziv, string Velicina)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTipKontenjera";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Naziv";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Naziv;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Duzina";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Duzina;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Sirina";
            parameter12.SqlDbType = SqlDbType.Decimal;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Sirina;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Visina";
            parameter13.SqlDbType = SqlDbType.Decimal;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Visina;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Tara";
            parameter14.SqlDbType = SqlDbType.Decimal;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Tara;
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
            parameter17.ParameterName = "@SkNaziv";
            parameter17.SqlDbType = SqlDbType.NVarChar;
            parameter17.Size = 20;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = SkNaziv;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Velicina";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Velicina;
            myCommand.Parameters.Add(parameter18);

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

        public void DeleteTipKontejnera(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteTipKontenjera";
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
                    MessageBox.Show("Brisanje uspešno završeno", "",
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
