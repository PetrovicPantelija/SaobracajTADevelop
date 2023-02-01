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
    class InsertRadniNalogZaposleniEvid
    {
        public void InsRNTLZEVID(int RadniNalog, int Trasa, string MestoTroska, int DeSifra, DateTime VremeJavljanja, DateTime VremePocetka, int DirektnaPrimopredaja, DateTime VremePrimopredaja, DateTime VremeZavrsetka, int VoznoVreme, int UkupnoVreme, int JalovoVreme, int JalovoVremeVanVoznje)
        {
               
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertRadniNalogZapEv";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDRadnogNaloga";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = RadniNalog;
            myCommand.Parameters.Add(parameter);
 
            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDTrase";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Trasa;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@SmSifra";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 8;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = MestoTroska;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@DeSifra";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = DeSifra;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@VremeJavljanja";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = VremeJavljanja;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@VremePocetka";
            parameter6.SqlDbType = SqlDbType.DateTime;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = VremePocetka;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@DirektnaPrimopredaja";
            parameter7.SqlDbType = SqlDbType.TinyInt;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = DirektnaPrimopredaja;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@VremePrimopredaja";
            parameter8.SqlDbType = SqlDbType.DateTime;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = VremePrimopredaja;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@VremeZavrsetka";
            parameter9.SqlDbType = SqlDbType.DateTime;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = VremeZavrsetka;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@VoznoVreme";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = VoznoVreme;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@UkupnoVreme";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = UkupnoVreme;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@JalovoVreme";
            parameter12.SqlDbType = SqlDbType.Int;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = JalovoVreme;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@JalovoVremeVanVoznje";
            parameter13.SqlDbType = SqlDbType.Int;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = JalovoVremeVanVoznje;
            myCommand.Parameters.Add(parameter13);

         
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
                throw new Exception("Neuspešan upis Radnog naloga u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos radnog naloga je uspešno završen", "",
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
