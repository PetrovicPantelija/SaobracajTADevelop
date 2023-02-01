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
    class InsertVrstaAktivnosti
    {

        public void InsVrstaAktivnosti(string Naziv, double Cena, string Opis, int ObracunPoSatu, int PotrebanRazlog, int PotrebanNalogodavac, int PotrebnoVozilo, int ObaveznaNapomena, double FisnaCena, int Smederevo, int Kragujevac, int CG, int Remont, int Milsped, int Dnevnica, double VremeVagon, double MaxSati, double MaxVagona)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertVrstaAktivnosti";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Naziv";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 100;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Naziv;
            myCommand.Parameters.Add(parameter);
           
            
            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Cena";
            parameter2.SqlDbType = SqlDbType.Decimal;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Cena;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Opis";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 500; 
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Opis;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@ObracunPoSatu";
            parameter4.SqlDbType = SqlDbType.TinyInt;
        
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = ObracunPoSatu;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@PotrebanRazlog";
            parameter5.SqlDbType = SqlDbType.TinyInt;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = PotrebanRazlog;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@PotrebanNalogodavac";
            parameter6.SqlDbType = SqlDbType.TinyInt;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = PotrebanNalogodavac;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@PotrebnoVozilo";
            parameter7.SqlDbType = SqlDbType.TinyInt;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = PotrebnoVozilo;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@ObaveznaNapomena";
            parameter8.SqlDbType = SqlDbType.TinyInt;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = ObaveznaNapomena;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@FisnaCena";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = FisnaCena;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Smederevo";
            parameter10.SqlDbType = SqlDbType.TinyInt;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Smederevo;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Kragujevac";
            parameter11.SqlDbType = SqlDbType.TinyInt;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Kragujevac;
            myCommand.Parameters.Add(parameter11);

             SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@CG";
            parameter12.SqlDbType = SqlDbType.TinyInt;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = CG;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Remont";
            parameter13.SqlDbType = SqlDbType.TinyInt;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Remont;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Milsped";
            parameter14.SqlDbType = SqlDbType.TinyInt;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Milsped;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Dnevnica";
            parameter15.SqlDbType = SqlDbType.Int;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Dnevnica;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@VremeVagon";
            parameter16.SqlDbType = SqlDbType.Decimal;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = VremeVagon;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@MaxSati";
            parameter17.SqlDbType = SqlDbType.Decimal;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = MaxSati;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@MaxVagona";
            parameter18.SqlDbType = SqlDbType.Decimal;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = MaxVagona;
            myCommand.Parameters.Add(parameter18);
            // chekiranPotrebanRazlog	,chekiranPotrebanNalogodavac,chekiranPotrebnoVozilo,chekiranObaveznaNapomena 

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
                throw new Exception("Neuspešan upis Vrste aktivnosti");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos Vrste aktivnosti", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }


        public void UpdVrstaAktivnosti(int ID, string Naziv, double Cena, string Opis, int ObracunPoSatu, int PotrebanRazlog, int PotrebanNalogodavac, int PotrebnoVozilo, int ObaveznaNapomena, double FisnaCena, int Smederevo, int Kragujevac, int CG, int Remont, int Milsped, int Dnevnica, double VremeVagon, double MaxSati, double MaxVagona)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateVrstaAktivnosti";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter); 
            
            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Naziv";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 100;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Naziv;
            myCommand.Parameters.Add(parameter2);


            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Cena";
            parameter3.SqlDbType = SqlDbType.Decimal;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Cena;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Opis";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 500;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Opis;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@ObracunPoSatu";
            parameter5.SqlDbType = SqlDbType.TinyInt;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = ObracunPoSatu;
            myCommand.Parameters.Add(parameter5);


            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@PotrebanRazlog";
            parameter6.SqlDbType = SqlDbType.TinyInt;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = PotrebanRazlog;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@PotrebanNalogodavac";
            parameter7.SqlDbType = SqlDbType.TinyInt;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = PotrebanNalogodavac;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@PotrebnoVozilo";
            parameter8.SqlDbType = SqlDbType.TinyInt;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = PotrebnoVozilo;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@ObaveznaNapomena";
            parameter9.SqlDbType = SqlDbType.TinyInt;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = ObaveznaNapomena;
            myCommand.Parameters.Add(parameter9);



            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@FisnaCena";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = FisnaCena;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Smederevo";
            parameter11.SqlDbType = SqlDbType.TinyInt;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Smederevo;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Kragujevac";
            parameter12.SqlDbType = SqlDbType.TinyInt;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Kragujevac;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@CG";
            parameter13.SqlDbType = SqlDbType.TinyInt;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = CG;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Remont";
            parameter14.SqlDbType = SqlDbType.TinyInt;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Remont;
            myCommand.Parameters.Add(parameter14);


            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Milsped";
            parameter15.SqlDbType = SqlDbType.TinyInt;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Milsped;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Dnevnica";
            parameter16.SqlDbType = SqlDbType.Int;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Dnevnica;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@VremeVagon";
            parameter17.SqlDbType = SqlDbType.Decimal;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = VremeVagon;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@MaxSati";
            parameter18.SqlDbType = SqlDbType.Decimal;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = MaxSati;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@MaxVagona";
            parameter19.SqlDbType = SqlDbType.Decimal;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = MaxVagona;
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
                throw new Exception("Neuspešna promena stavki aktivnosti");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Promena Aktivnosti je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }


        public void DeleteVrstaAktivnosti(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteVrstaAktivnosti";
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

