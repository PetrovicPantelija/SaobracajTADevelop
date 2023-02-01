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
    class InsertPrugaStavke
    {
        public void InsPrugaStavke(int IDPruge, int StanicaOd, int StanicaDo, int RastojanjeKM, int RastojanjeM, Double StacionazaKM, int StacionazaM, int VmaxL, int VmaxD, string OsOtpor, int MaxDVA, string KoliseciA, int MaxDVB, string KoliseciB, string Vaga, string PutTer, double Nagib, double MNU, double MNP, double MNOU, double MNOP, string Klasa, double Osovinsko)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPrugaStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDPruge";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = IDPruge;
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
            parameter4.ParameterName = "@RastojanjeKM";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = RastojanjeKM;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@RastojanjeM";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = RastojanjeM;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@StacionazaKM";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = StacionazaKM;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@StacionazaM";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = StacionazaM;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@VmaxL";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = VmaxL;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@VmaxD";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = VmaxD;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@OsOtpor";
            parameter10.SqlDbType = SqlDbType.NVarChar;
             parameter10.Size = 20;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = OsOtpor;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@MaxDVA";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = MaxDVA;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@KoliseciA";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 20;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = KoliseciA;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@MaxDVB";
            parameter13.SqlDbType = SqlDbType.Int;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = MaxDVB;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@KoliseciB";
            parameter14.SqlDbType = SqlDbType.NVarChar;
            parameter14.Size = 20;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = KoliseciB;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Vaga";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 20;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Vaga;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@PutTer";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = PutTer;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Nagib";
            parameter17.SqlDbType = SqlDbType.Decimal;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Nagib;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@MNU";
            parameter18.SqlDbType = SqlDbType.Decimal;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = MNU;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@MNP";
            parameter19.SqlDbType = SqlDbType.Decimal;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = MNP;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@MNOU";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = MNOU;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@MNOP";
            parameter21.SqlDbType = SqlDbType.Decimal;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = MNOP;
            myCommand.Parameters.Add(parameter21);


            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Klasa";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 1;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Klasa;
            myCommand.Parameters.Add(parameter22);


            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Osovinsko";
            parameter23.SqlDbType = SqlDbType.Decimal;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Osovinsko;
            myCommand.Parameters.Add(parameter23);

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
                throw new Exception("Neuspešan upis pruga");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos pruge je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void UpdPrugaStavke(int rb, int IDPruge, int StanicaOd, int StanicaDo, int RastojanjeKM, int RastojanjeM, double StacionazaKM, int StacionazaM, int VmaxL, int VmaxD, string OsOtpor, int MaxDVA, string KoliseciA, int MaxDVB, string KoliseciB, string Vaga, string PutTer, double Nagib, double MNU, double MNP, double MNOU, double MNOP, string Klasa, double Osovinsko)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdatePrugaStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@RB";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = rb;
            myCommand.Parameters.Add(parameter);
            
            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDPruge";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDPruge;
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
            parameter4.ParameterName = "@RastojanjeKM";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = RastojanjeKM;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@RastojanjeM";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = RastojanjeM;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@StacionazaKM";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = StacionazaKM;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@StacionazaM";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = StacionazaM;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@VmaxL";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = VmaxL;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@VmaxD";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = VmaxD;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@OsOtpor";
            parameter10.SqlDbType = SqlDbType.NVarChar;
            parameter10.Size = 20;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = OsOtpor;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@MaxDVA";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = MaxDVA;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@KoliseciA";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 20;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = KoliseciA;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@MaxDVB";
            parameter13.SqlDbType = SqlDbType.Int;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = MaxDVB;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@KoliseciB";
            parameter14.SqlDbType = SqlDbType.NVarChar;
            parameter14.Size = 20;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = KoliseciB;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Vaga";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 20;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Vaga;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@PutTer";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = PutTer;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Nagib";
            parameter17.SqlDbType = SqlDbType.Decimal;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Nagib;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@MNU";
            parameter18.SqlDbType = SqlDbType.Decimal;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = MNU;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@MNP";
            parameter19.SqlDbType = SqlDbType.Decimal;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = MNP;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@MNOU";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = MNOU;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@MNOP";
            parameter21.SqlDbType = SqlDbType.Decimal;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = MNOP;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Klasa";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 1;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Klasa;
            myCommand.Parameters.Add(parameter22);


            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Osovinsko";
            parameter23.SqlDbType = SqlDbType.Decimal;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Osovinsko;
            myCommand.Parameters.Add(parameter23);

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
                throw new Exception("Neuspešan upis pruga");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos pruge je uspešno završena", "",
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
