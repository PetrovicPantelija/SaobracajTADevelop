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
    class InsertKontaktOsobe
    {
        public void InsKontaktOsoba(int PaSifra, string Ime, string Prezime, string Odeljenje, string Telefon, string Mail, string Napomena, int Operatika)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertKontaktOsobe";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            
            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@PaKOSifra";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = PaSifra;
            myCommand.Parameters.Add(parameter1);

    /*
     [PaKOSifra] [int] NOT NULL,
    [PaKOIme] [char](35) NULL,
	[PaKOPriimek] [char](35) NULL,
	[PaKOOddelek] [char](35) NULL,
	[PaKOTel] [char](17) NULL,
	[PaKOMail] [char](70) NULL,
	[PaKOOpomba] [varchar](2048) NULL,
	[Operatika] [bit] NULL,
           */ 
            
            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@PaKOIme";
            parameter2.SqlDbType = SqlDbType.Char;
            parameter2.Size = 35;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Ime;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@PaKOPriimek";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 35;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Prezime;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@PaKOTel";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 17;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Telefon;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@PaKOMail";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 70;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Mail;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@PaKOOpomba";
            parameter6.SqlDbType = SqlDbType.VarChar;
            parameter6.Size = 2048;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Napomena;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Operatika";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Operatika;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@PaKOOddelek";
            parameter8.SqlDbType = SqlDbType.Char;
            parameter8.Size = 35;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Odeljenje;
            myCommand.Parameters.Add(parameter8);


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
                throw new Exception("Neuspešna promena podataka");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Neuspešna promena podataka", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void UpdKontaktOsoba(int ID, int PaSifra, string Ime, string Prezime, string Odeljenje, string Telefon, string Mail, string Napomena, int Operatika)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateKontaktOsobe";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@PaKOSifra";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = PaSifra;
            myCommand.Parameters.Add(parameter1);

            /*
             [PaKOSifra] [int] NOT NULL,
            [PaKOIme] [char](35) NULL,
            [PaKOPriimek] [char](35) NULL,
            [PaKOOddelek] [char](35) NULL,
            [PaKOTel] [char](17) NULL,
            [PaKOMail] [char](70) NULL,
            [PaKOOpomba] [varchar](2048) NULL,
            [Operatika] [bit] NULL,
                   */

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@PaKOIme";
            parameter2.SqlDbType = SqlDbType.Char;
            parameter2.Size = 35;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Ime;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@PaKOPriimek";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 35;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Prezime;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@PaKOTel";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 17;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Telefon;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@PaKOMail";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 70;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Mail;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@PaKOOpomba";
            parameter6.SqlDbType = SqlDbType.VarChar;
            parameter6.Size = 2048;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Napomena;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Operatika";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Operatika;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@PaKOOddelek";
            parameter8.SqlDbType = SqlDbType.Char;
            parameter8.Size = 35;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Odeljenje;
            myCommand.Parameters.Add(parameter8);


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
                throw new Exception("Neuspešna promena podataka");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Neuspešna promena podataka", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void DelKontaktOsoba(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteKontaktOsoba";
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
                throw new Exception("Neuspešna promena podataka");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Neuspešna promena podataka", "",
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
