using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Melodii.Models;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.CodeDom;
using System.Linq.Expressions;

namespace Melodii
{
    class DB_Methods
    {
        public static string ConnectionString =  @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\Database.mdf;Integrated Security=True";

        public static void LoadMelodii(ref List<Melodie> melodii)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            try
            {
                //----------------------------< Extragerea datelor din BD >-------------------------

                //Stabilirea conexiunii
                Connection.Open();

                //Crerea unui obiect de tip DataAdapter pentru conectarea DataSet-ului
                //cu baza de date.
                SqlDataAdapter daMelodii = new SqlDataAdapter("SELECT * FROM MELODII", Connection);
                DataSet dsMelodii = new DataSet("Melodii");
                daMelodii.Fill(dsMelodii, "Melodii");
                DataTable tblMelodii = dsMelodii.Tables["Melodii"];
                Connection.Close();

                //Acum avem datele din tabela Melodii din baza de date in obiectul tblMelodii.
                //Trecem la popularea listei.

                melodii.Clear();
                foreach (DataRow drMelodie in tblMelodii.Rows)
                {
                    melodii.Add(new Melodie
                    {
                        IdMelodie = int.Parse(drMelodie["IdMelodie"].ToString()),
                        Denumire = drMelodie["Denumire"].ToString(),
                        Interpret = drMelodie["Interpret"].ToString(),
                        Puncte = int.Parse(drMelodie["Puncte"].ToString()),
                        Informatii = drMelodie["Informatii"].ToString(),
                        GenMuzical = drMelodie["GenMuzical"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare LoadMelodii: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        public static void LoadParticipanti(ref List<Participant> participanti)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //----------------------------< Extragerea datelor din BD >-------------------------

                //Stabilirea conexiunii
                Connection.Open();

                //Crerea unui obiect de tip DataAdapter pentru conectarea DataSet-ului
                //cu baza de date.
                SqlDataAdapter daParticipanti = new SqlDataAdapter("SELECT * FROM PARTICIPANTI", Connection);
                DataSet dsParticipanti = new DataSet("Participanti");
                daParticipanti.Fill(dsParticipanti, "Participanti");
                DataTable tblParticipanti = dsParticipanti.Tables["Participanti"];
                Connection.Close();

                //Acum avem datele din tabela Melodii din baza de date in obiectul tblMelodii.
                //Trecem la popularea listei.
                participanti.Clear();
                foreach (DataRow drParticipant in tblParticipanti.Rows)
                {
                    participanti.Add(new Participant
                    {
                        IdParticipant = int.Parse(drParticipant["IdParticipant"].ToString()),
                        Nume = drParticipant["Nume"].ToString(),
                        Scor = int.Parse(drParticipant["Scor"].ToString()),
                        Informatii = drParticipant["Informatii"].ToString(),
                        Varsta = int.Parse(drParticipant["Varsta"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare LoadParticipanti: " + ex.Message);
                throw ex;
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        public static void InsertMelodie(Melodie melodie)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                SqlCommand cmd = new SqlCommand("INSERT INTO MELODII" +
                "(Denumire, Interpret, Puncte, Informatii, GenMuzical)" +
                "VALUES" +
                "(@Denumire, @Interpret, @Puncte, @Informatii, @GenMuzical); ", Connection);
                SqlParameter parDenumire = new SqlParameter("@Denumire", melodie.Denumire);
                cmd.Parameters.Add(parDenumire);

                SqlParameter parInterpret = new SqlParameter("@Interpret", melodie.Interpret);
                cmd.Parameters.Add(parInterpret);

                SqlParameter parPuncte = new SqlParameter("@Puncte", int.Parse(melodie.Puncte.ToString()));
                cmd.Parameters.Add(parPuncte);

                SqlParameter parInformatii;
                if (melodie.Informatii != null)
                    parInformatii = new SqlParameter("@Informatii", melodie.Informatii);
                else
                    parInformatii = new SqlParameter("@Informatii", DBNull.Value);
                cmd.Parameters.Add(parInformatii);

                SqlParameter parGenMuzical = new SqlParameter("@GenMuzical", melodie.GenMuzical);
                cmd.Parameters.Add(parGenMuzical);

                //Executarea comenzii INSERT
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare InsertMelodie: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        public static void InsertParticipant(Participant participant)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                SqlCommand cmd = new SqlCommand("INSERT INTO PARTICIPANTI" +
                "(Nume, Scor, Informatii, Varsta)" +
                "VALUES" +
                "(@Nume, @Scor, @Informatii, @Varsta); ", Connection);
                SqlParameter parNume = new SqlParameter("@Nume", participant.Nume);
                cmd.Parameters.Add(parNume);

                SqlParameter parScor = new SqlParameter("@Scor", participant.Scor);
                cmd.Parameters.Add(parScor);

                SqlParameter parInformatii;
                if (participant.Informatii != null)
                    parInformatii = new SqlParameter("@Informatii", participant.Informatii);
                else
                    parInformatii = new SqlParameter("@Informatii", DBNull.Value);
                cmd.Parameters.Add(parInformatii);

                SqlParameter parVarsta = new SqlParameter("@Varsta", participant.Varsta);
                cmd.Parameters.Add(parVarsta);

                //Executarea comenzii INSERT
                Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare InsertParticipant: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        public static void InsertVot(Vot vot)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                SqlCommand cmd = new SqlCommand("INSERT INTO Voturi" +
                "(IdParticipant, IdMelodie, ScorVot, IdSondaj)" +
                "VALUES" +
                "(@IdParticipant, @IdMelodie, @ScorVot, @IdSondaj); ", Connection);

                SqlParameter parParticipant = new SqlParameter("@IdParticipant", vot.IdParticipant);
                cmd.Parameters.Add(parParticipant);

                SqlParameter parMelodie = new SqlParameter("@IdMelodie", vot.IdMelodie);
                cmd.Parameters.Add(parMelodie);

                SqlParameter parScor = new SqlParameter("@ScorVot", vot.ScorVot);
                cmd.Parameters.Add(parScor);

                SqlParameter parSondaj = new SqlParameter("@IdSondaj", vot.IdSondaj);
                cmd.Parameters.Add(parSondaj);

                Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare InsertVot: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        public static void UpdateScorFinalSondaj(Sondaj sondaj)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                SqlCommand cmd = new SqlCommand("UPDATE Sondaje SET ScorFinal = @ScorFinal WHERE IdSondaj = @IdSondaj", Connection);

                SqlParameter parScor = new SqlParameter("@ScorFinal", sondaj.ScorFinal);
                cmd.Parameters.Add(parScor);

                SqlParameter parIdSondaj = new SqlParameter("@IdSondaj", sondaj.IdSondaj);
                cmd.Parameters.Add(parIdSondaj);

                Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare Update Sondaj: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        public static void RemoveParticipant(int IdParticipant)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand sqlcDelete = new SqlCommand("DELETE FROM PARTICIPANTI WHERE IDPARTICIPANT = @IdParticipant", Connection);
                SqlParameter parIdParticipant = new SqlParameter("@IdParticipant", IdParticipant);
                sqlcDelete.Parameters.Add(parIdParticipant);

                Connection.Open();
                sqlcDelete.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare RemoveParticipant: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        public static void RemoveMelodie(int idMelodie)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand sqlcDelete = new SqlCommand("DELETE FROM MELODII WHERE IDMELODIE = @IdMelodie", Connection);
                SqlParameter parIdMelodie = new SqlParameter("@IdMelodie", idMelodie);
                sqlcDelete.Parameters.Add(parIdMelodie);

                Connection.Open();
                sqlcDelete.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare RemoveMelodie: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

        }
        public static int LastInsertedID(string tableName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand lastId;
                switch (tableName)
                {
                    case "Melodii":
                        lastId = new SqlCommand("SELECT MAX(IdMelodie) FROM Melodii", connection);
                        break;
                    case "Participanti":
                        lastId = new SqlCommand("SELECT MAX(IdParticipant) FROM Participanti", connection);
                        break;
                    case "Voturi":
                        lastId = new SqlCommand("SELECT MAX(IdVot) FROM Voturi", connection);
                        break;
                    case "Sondaje":
                        lastId = new SqlCommand("SELECT MAX(IdSondaj) FROM Sondaje", connection);
                        break;
                    default:
                        throw new Exception("Invalid table name");
                }

                connection.Open();
                int LastInsertedId = (int)lastId.ExecuteScalar();
                connection.Close();

                return LastInsertedId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                if (connection.State == ConnectionState.Open)
                    connection.Close();

                return -1;
            }
        }
        public static void InsertSondaj(Sondaj sondaj)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Sondaje" +
                    "(IdParticipant, ScorFinal, Data)" +
                    "VALUES" +
                    "(@IdParticipant, @ScorFinal, @Data)", Connection);

                SqlParameter parParticipant = new SqlParameter("@IdParticipant", sondaj.IdParticipant);
                cmd.Parameters.Add(parParticipant);

                SqlParameter parScorFinal = new SqlParameter("@ScorFinal", sondaj.ScorFinal);
                cmd.Parameters.Add(parScorFinal);

                SqlParameter parData = new SqlParameter("@Data", sondaj.Data);
                cmd.Parameters.Add(parData);

                Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error inserting Sondaj: " + ex.Message);
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        public static int NrMelodii()
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand sqlCount = new SqlCommand("SELECT COUNT(*) FROM MELODII", Connection);

                Connection.Open();
                int nrMelodii = (int)sqlCount.ExecuteScalar();
                Connection.Close();
                return nrMelodii;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare NrMelodii: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
    }
}
