using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Dokumenta
{
    class InsertAutomobiliPregledPrijava
    {
        string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public void InsAutomobiliPregledPrijava(int Zaposleni, DateTime DatumPrijave, DateTime DatumOdjave, int AutomobilId, string Relacija, int CistocaSpoljaZaduzivanje,
        int CistocaIznutraZaduzivanje, int CistocaSpoljaRazduzivanje, int CistocaIznutraRazduzivanje, int NivoUljaZaduzivanje, bool DirektnaPrimopredajaZaduzivanje,
        int NivoUljaRazduzivanje, bool DirektnaPrimopredajaRazduzivanje, float KilometrazaZaduzivanje, float KilometrazaRazduzivanje, bool Plomba1PotvrdaZaduzenje,
        bool Plomba2PotvrdaZaduzenje, bool Plomba1PotvrdaRazduzenje, bool Plomba2PotvrdaRazduzenje)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_InsertZaposleniPrijavaAuto";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramZaposleni = new SqlParameter();
            paramZaposleni.ParameterName = "@Zaposleni";
            paramZaposleni.SqlDbType=SqlDbType.Int;
            paramZaposleni.Direction = ParameterDirection.Input;
            paramZaposleni.Value = Zaposleni;
            cmd.Parameters.Add(paramZaposleni);

            SqlParameter paramPrijava = new SqlParameter();
            paramPrijava.ParameterName = "@DatumPrijave";
            paramPrijava.SqlDbType = SqlDbType.DateTime;
            paramPrijava.Direction = ParameterDirection.Input;
            paramPrijava.Value = DatumPrijave;
            cmd.Parameters.Add(paramPrijava);

            SqlParameter paramOdjava = new SqlParameter();
            paramOdjava.ParameterName = "@DatumOdjave";
            paramOdjava.SqlDbType = SqlDbType.DateTime;
            paramOdjava.Direction = ParameterDirection.Input;
            paramOdjava.Value = DatumOdjave;
            cmd.Parameters.Add(paramOdjava);

            SqlParameter paramAuto = new SqlParameter();
            paramAuto.ParameterName = "@AutomobilId";
            paramAuto.SqlDbType = SqlDbType.Int;
            paramAuto.Direction = ParameterDirection.Input;
            paramAuto.Value = AutomobilId;
            cmd.Parameters.Add(paramAuto);

            SqlParameter paramRelacija = new SqlParameter();
            paramRelacija.ParameterName = "@Relacija";
            paramRelacija.SqlDbType = SqlDbType.NVarChar;
            paramRelacija.Size = 50;
            paramRelacija.Direction = ParameterDirection.Input;
            paramRelacija.Value = Relacija;
            cmd.Parameters.Add(paramRelacija);

            SqlParameter paramCistocaSpZad = new SqlParameter();
            paramCistocaSpZad.ParameterName = "@CistocaSpoljaZaduzivanje";
            paramCistocaSpZad.SqlDbType = SqlDbType.Int;
            paramCistocaSpZad.Direction = ParameterDirection.Input;
            paramCistocaSpZad.Value = CistocaSpoljaZaduzivanje;
            cmd.Parameters.Add(paramCistocaSpZad);

            SqlParameter paramCistocaIznZad = new SqlParameter();
            paramCistocaIznZad.ParameterName = "@CistocaIznutraZaduzivanje";
            paramCistocaIznZad.SqlDbType = SqlDbType.Int;
            paramCistocaIznZad.Direction = ParameterDirection.Input;
            paramCistocaIznZad.Value = CistocaIznutraZaduzivanje;
            cmd.Parameters.Add(paramCistocaIznZad);

            SqlParameter paramCistocaSpRaz = new SqlParameter();
            paramCistocaSpRaz.ParameterName = "@CistocaSpoljaRazduzivanje";
            paramCistocaSpRaz.SqlDbType = SqlDbType.Int;
            paramCistocaSpRaz.Direction = ParameterDirection.Input;
            paramCistocaSpRaz.Value = CistocaSpoljaRazduzivanje;
            cmd.Parameters.Add(paramCistocaSpRaz);

            SqlParameter paramCistocaIznRaz = new SqlParameter();
            paramCistocaIznRaz.ParameterName = "@CistocaIznutraRazduzivanje";
            paramCistocaIznRaz.SqlDbType = SqlDbType.Int;
            paramCistocaIznRaz.Direction = ParameterDirection.Input;
            paramCistocaIznRaz.Value = CistocaIznutraRazduzivanje;
            cmd.Parameters.Add(paramCistocaIznRaz);

            SqlParameter paramNivoUljaZad = new SqlParameter();
            paramNivoUljaZad.ParameterName = "@NivoUljaZaduzivanje";
            paramNivoUljaZad.SqlDbType = SqlDbType.Int;
            paramNivoUljaZad.Direction = ParameterDirection.Input;
            paramNivoUljaZad.Value = NivoUljaZaduzivanje;
            cmd.Parameters.Add(paramNivoUljaZad);

            SqlParameter paramDirPrimZad = new SqlParameter();
            paramDirPrimZad.ParameterName = "@DirektnaPrimopredajaZaduzivanje";
            paramDirPrimZad.SqlDbType = SqlDbType.Bit;
            paramDirPrimZad.Direction = ParameterDirection.Input;
            paramDirPrimZad.Value = DirektnaPrimopredajaZaduzivanje;
            cmd.Parameters.Add(paramDirPrimZad);

            SqlParameter paramNivoUljaRaz = new SqlParameter();
            paramNivoUljaRaz.ParameterName = "@NivoUljaRazduzivanje";
            paramNivoUljaRaz.SqlDbType = SqlDbType.Int;
            paramNivoUljaRaz.Direction = ParameterDirection.Input;
            paramNivoUljaRaz.Value = NivoUljaRazduzivanje;
            cmd.Parameters.Add(paramNivoUljaRaz);

            SqlParameter paramDirPrimRaz = new SqlParameter();
            paramDirPrimRaz.ParameterName = "@DirektnaPrimopredajaRazduzivanje";
            paramDirPrimRaz.SqlDbType = SqlDbType.Bit;
            paramDirPrimRaz.Direction = ParameterDirection.Input;
            paramDirPrimRaz.Value = DirektnaPrimopredajaRazduzivanje;
            cmd.Parameters.Add(paramDirPrimRaz);

            SqlParameter paramKmZad = new SqlParameter();
            paramKmZad.ParameterName = "@KilometrazaZaduzivanje";
            paramKmZad.SqlDbType = SqlDbType.Float;
            paramKmZad.Direction = ParameterDirection.Input;
            paramKmZad.Value = KilometrazaZaduzivanje;
            cmd.Parameters.Add(paramKmZad);

            SqlParameter paramKmRaz = new SqlParameter();
            paramKmRaz.ParameterName = "@KilometrazaRazduzivanje";
            paramKmRaz.SqlDbType = SqlDbType.Float;
            paramKmRaz.Direction = ParameterDirection.Input;
            paramKmRaz.Value = KilometrazaRazduzivanje;
            cmd.Parameters.Add(paramKmRaz);

            SqlParameter paramPlomba1Zad = new SqlParameter();
            paramPlomba1Zad.ParameterName = "@Plomba1PotvrdaZaduzenje";
            paramPlomba1Zad.SqlDbType = SqlDbType.Bit;
            paramPlomba1Zad.Direction = ParameterDirection.Input;
            paramPlomba1Zad.Value = Plomba1PotvrdaZaduzenje;
            cmd.Parameters.Add(paramPlomba1Zad);

            SqlParameter paramPlomba2Zad = new SqlParameter();
            paramPlomba2Zad.ParameterName = "@Plomba2PotvrdaZaduzenje";
            paramPlomba2Zad.SqlDbType = SqlDbType.Bit;
            paramPlomba2Zad.Direction = ParameterDirection.Input;
            paramPlomba2Zad.Value = Plomba2PotvrdaZaduzenje;
            cmd.Parameters.Add(paramPlomba2Zad);

            SqlParameter paramPlomba1Raz = new SqlParameter();
            paramPlomba1Raz.ParameterName = "@Plomba1PotvrdaRazduzenje";
            paramPlomba1Raz.SqlDbType = SqlDbType.Bit;
            paramPlomba1Raz.Direction = ParameterDirection.Input;
            paramPlomba1Raz.Value = Plomba1PotvrdaRazduzenje;
            cmd.Parameters.Add(paramPlomba1Raz);

            SqlParameter paramPlomba2Raz = new SqlParameter();
            paramPlomba2Raz.ParameterName = "@Plomba2PotvrdaRazduzenje";
            paramPlomba2Raz.SqlDbType = SqlDbType.Bit;
            paramPlomba2Raz.Direction = ParameterDirection.Input;
            paramPlomba2Raz.Value = Plomba2PotvrdaRazduzenje;
            cmd.Parameters.Add(paramPlomba2Raz);

            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
            }
            catch (SqlException)
            {
                throw new Exception("Neuspešan upis razduživanja");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Zaduživanje nije uspelo", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                if (error)
                {

                }
            }
        }
        public void UpdAutomobiliPregledPrijava(int ID, int Zaposleni, DateTime DatumPrijave, DateTime DatumOdjave, int AutomobilId, string Relacija, int CistocaSpoljaZaduzivanje,
        int CistocaIznutraZaduzivanje, int CistocaSpoljaRazduzivanje, int CistocaIznutraRazduzivanje, int NivoUljaZaduzivanje, bool DirektnaPrimopredajaZaduzivanje,
        int NivoUljaRazduzivanje, bool DirektnaPrimopredajaRazduzivanje, float KilometrazaZaduzivanje, float KilometrazaRazduzivanje, bool Plomba1PotvrdaZaduzenje,
        bool Plomba2PotvrdaZaduzenje, bool Plomba1PotvrdaRazduzenje, bool Plomba2PotvrdaRazduzenje)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_UpdateZaposleniPrijavaAuto";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramID = new SqlParameter();
            paramID.ParameterName = "@ID";
            paramID.SqlDbType = SqlDbType.Int;
            paramID.Direction = ParameterDirection.Input;
            paramID.Value = ID;
            cmd.Parameters.Add(paramID);

            SqlParameter paramZaposleni = new SqlParameter();
            paramZaposleni.ParameterName = "@Zaposleni";
            paramZaposleni.SqlDbType = SqlDbType.Int;
            paramZaposleni.Direction = ParameterDirection.Input;
            paramZaposleni.Value = Zaposleni;
            cmd.Parameters.Add(paramZaposleni);

            SqlParameter paramPrijava = new SqlParameter();
            paramPrijava.ParameterName = "@DatumPrijave";
            paramPrijava.SqlDbType = SqlDbType.DateTime;
            paramPrijava.Direction = ParameterDirection.Input;
            paramPrijava.Value = DatumPrijave;
            cmd.Parameters.Add(paramPrijava);

            SqlParameter paramOdjava = new SqlParameter();
            paramOdjava.ParameterName = "@DatumOdjave";
            paramOdjava.SqlDbType = SqlDbType.DateTime;
            paramOdjava.Direction = ParameterDirection.Input;
            paramOdjava.Value = DatumOdjave;
            cmd.Parameters.Add(paramOdjava);

            SqlParameter paramAuto = new SqlParameter();
            paramAuto.ParameterName = "@AutomobilId";
            paramAuto.SqlDbType = SqlDbType.Int;
            paramAuto.Direction = ParameterDirection.Input;
            paramAuto.Value = AutomobilId;
            cmd.Parameters.Add(paramAuto);

            SqlParameter paramRelacija = new SqlParameter();
            paramRelacija.ParameterName = "@Relacija";
            paramRelacija.SqlDbType = SqlDbType.NVarChar;
            paramRelacija.Size = 50;
            paramRelacija.Direction = ParameterDirection.Input;
            paramRelacija.Value = Relacija;
            cmd.Parameters.Add(paramRelacija);

            SqlParameter paramCistocaSpZad = new SqlParameter();
            paramCistocaSpZad.ParameterName = "@CistocaSpoljaZaduzivanje";
            paramCistocaSpZad.SqlDbType = SqlDbType.Int;
            paramCistocaSpZad.Direction = ParameterDirection.Input;
            paramCistocaSpZad.Value = CistocaSpoljaZaduzivanje;
            cmd.Parameters.Add(paramCistocaSpZad);

            SqlParameter paramCistocaIznZad = new SqlParameter();
            paramCistocaIznZad.ParameterName = "@CistocaIznutraZaduzivanje";
            paramCistocaIznZad.SqlDbType = SqlDbType.Int;
            paramCistocaIznZad.Direction = ParameterDirection.Input;
            paramCistocaIznZad.Value = CistocaIznutraZaduzivanje;
            cmd.Parameters.Add(paramCistocaIznZad);

            SqlParameter paramCistocaSpRaz = new SqlParameter();
            paramCistocaSpRaz.ParameterName = "@CistocaSpoljaRazduzivanje";
            paramCistocaSpRaz.SqlDbType = SqlDbType.Int;
            paramCistocaSpRaz.Direction = ParameterDirection.Input;
            paramCistocaSpRaz.Value = CistocaSpoljaRazduzivanje;
            cmd.Parameters.Add(paramCistocaSpRaz);

            SqlParameter paramCistocaIznRaz = new SqlParameter();
            paramCistocaIznRaz.ParameterName = "@CistocaIznutraRazduzivanje";
            paramCistocaIznRaz.SqlDbType = SqlDbType.Int;
            paramCistocaIznRaz.Direction = ParameterDirection.Input;
            paramCistocaIznRaz.Value = CistocaIznutraRazduzivanje;
            cmd.Parameters.Add(paramCistocaIznRaz);

            SqlParameter paramNivoUljaZad = new SqlParameter();
            paramNivoUljaZad.ParameterName = "@NivoUljaZaduzivanje";
            paramNivoUljaZad.SqlDbType = SqlDbType.Int;
            paramNivoUljaZad.Direction = ParameterDirection.Input;
            paramNivoUljaZad.Value = NivoUljaZaduzivanje;
            cmd.Parameters.Add(paramNivoUljaZad);

            SqlParameter paramDirPrimZad = new SqlParameter();
            paramDirPrimZad.ParameterName = "@DirektnaPrimopredajaZaduzivanje";
            paramDirPrimZad.SqlDbType = SqlDbType.Bit;
            paramDirPrimZad.Direction = ParameterDirection.Input;
            paramDirPrimZad.Value = DirektnaPrimopredajaZaduzivanje;
            cmd.Parameters.Add(paramDirPrimZad);

            SqlParameter paramNivoUljaRaz = new SqlParameter();
            paramNivoUljaRaz.ParameterName = "@NivoUljaRazduzivanje";
            paramNivoUljaRaz.SqlDbType = SqlDbType.Int;
            paramNivoUljaRaz.Direction = ParameterDirection.Input;
            paramNivoUljaRaz.Value = NivoUljaRazduzivanje;
            cmd.Parameters.Add(paramNivoUljaRaz);

            SqlParameter paramDirPrimRaz = new SqlParameter();
            paramDirPrimRaz.ParameterName = "@DirektnaPrimopredajaRazduzivanje";
            paramDirPrimRaz.SqlDbType = SqlDbType.Bit;
            paramDirPrimRaz.Direction = ParameterDirection.Input;
            paramDirPrimRaz.Value = DirektnaPrimopredajaRazduzivanje;
            cmd.Parameters.Add(paramDirPrimRaz);

            SqlParameter paramKmZad = new SqlParameter();
            paramKmZad.ParameterName = "@KilometrazaZaduzivanje";
            paramKmZad.SqlDbType = SqlDbType.Float;
            paramKmZad.Direction = ParameterDirection.Input;
            paramKmZad.Value = KilometrazaZaduzivanje;
            cmd.Parameters.Add(paramKmZad);

            SqlParameter paramKmRaz = new SqlParameter();
            paramKmRaz.ParameterName = "@KilometrazaRazduzivanje";
            paramKmRaz.SqlDbType = SqlDbType.Float;
            paramKmRaz.Direction = ParameterDirection.Input;
            paramKmRaz.Value = KilometrazaRazduzivanje;
            cmd.Parameters.Add(paramKmRaz);

            SqlParameter paramPlomba1Zad = new SqlParameter();
            paramPlomba1Zad.ParameterName = "@Plomba1PotvrdaZaduzenje";
            paramPlomba1Zad.SqlDbType = SqlDbType.Bit;
            paramPlomba1Zad.Direction = ParameterDirection.Input;
            paramPlomba1Zad.Value = Plomba1PotvrdaZaduzenje;
            cmd.Parameters.Add(paramPlomba1Zad);

            SqlParameter paramPlomba2Zad = new SqlParameter();
            paramPlomba2Zad.ParameterName = "@Plomba2PotvrdaZaduzenje";
            paramPlomba2Zad.SqlDbType = SqlDbType.Bit;
            paramPlomba2Zad.Direction = ParameterDirection.Input;
            paramPlomba2Zad.Value = Plomba2PotvrdaZaduzenje;
            cmd.Parameters.Add(paramPlomba2Zad);

            SqlParameter paramPlomba1Raz = new SqlParameter();
            paramPlomba1Raz.ParameterName = "@Plomba1PotvrdaRazduzenje";
            paramPlomba1Raz.SqlDbType = SqlDbType.Bit;
            paramPlomba1Raz.Direction = ParameterDirection.Input;
            paramPlomba1Raz.Value = Plomba1PotvrdaRazduzenje;
            cmd.Parameters.Add(paramPlomba1Raz);

            SqlParameter paramPlomba2Raz = new SqlParameter();
            paramPlomba2Raz.ParameterName = "@Plomba2PotvrdaRazduzenje";
            paramPlomba2Raz.SqlDbType = SqlDbType.Bit;
            paramPlomba2Raz.Direction = ParameterDirection.Input;
            paramPlomba2Raz.Value = Plomba2PotvrdaRazduzenje;
            cmd.Parameters.Add(paramPlomba2Raz);


            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                throw new Exception("Neuspešna promena razduživanja");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Promena zaduživanja nije uspela", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                if (error)
                {

                }
            }
        }
        public void DeleteAutomobiliPregledPrijava(int ID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_DeleteZaposleniPrijavaAuto";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramID = new SqlParameter();
            paramID.ParameterName = "@ID";
            paramID.SqlDbType = SqlDbType.Int;
            paramID.Direction = ParameterDirection.Input;
            paramID.Value = ID;
            cmd.Parameters.Add(paramID);

            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                throw new Exception("Brisanje neuspešno");
             
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Brisanje nije uspešno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                if (error)
                {

                }
            }
        }
    }
}
