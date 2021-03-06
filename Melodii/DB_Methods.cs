﻿using Melodii.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace Melodii
{
    class DB_Methods
    {

        public static string ConnectionString =  @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\Database.mdf; Integrated Security=True; Pooling = true";

        #region Melodii
        public static void InsertMelodie(Melodie melodie)
        {

            //---------------------< Insereaza o melodie in baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                //SqlCommand cmd = new SqlCommand("INSERT INTO MELODII" +
                //"(Denumire, Interpret, Puncte, Informatii, GenMuzical)" +
                //"VALUES" +
                //"(@Denumire, @Interpret, @Puncte, @Informatii, @GenMuzical); ", Connection);
                SqlCommand cmd = new SqlCommand("sp_InsertMelodie", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

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

        public static void LoadMelodii(ref List<Melodie> melodii, bool top3)
        {

            //---------------------< Extragerea melodiilor din baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);

            try
            {
                //----------------------------< Extragerea datelor din BD >-------------------------

                //Stabilirea conexiunii
                Connection.Open();

                //Crerea unui obiect de tip DataAdapter pentru conectarea DataSet-ului
                //cu baza de date.
                SqlDataAdapter daMelodii;
                if(!top3)
                    daMelodii = new SqlDataAdapter("sp_LoadMelodii", Connection);
                else
                    daMelodii = new SqlDataAdapter("sp_LoadMelodiiTOP3", Connection);
                daMelodii.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public static void LoadMelodiiTOP3(ref List<Melodie> melodii)
        {

            //---------------------< Extragerea melodiilor din baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);

            try
            {
                //select top (3) with ties id, count from table1
                //order by count desc
                //----------------------------< Extragerea datelor din BD >-------------------------

                //Stabilirea conexiunii
                Connection.Open();

                //Crerea unui obiect de tip DataAdapter pentru conectarea DataSet-ului
                //cu baza de date.
                SqlDataAdapter daMelodii = new SqlDataAdapter("sp_LoadMelodiiTOP3", Connection);
                daMelodii.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public static int NrMelodii()
        {

            //---------------------< Returneaza numarul de melodii inregistrate >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_NrMelodii", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                Connection.Open();
                int nrMelodii = (int)cmd.ExecuteScalar();
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

        public static void RemoveMelodie(int idMelodie)
        {

            //---------------------< Exclude melodia din baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_RemoveMelodie", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdMelodie = new SqlParameter("@IdMelodie", idMelodie);
                cmd.Parameters.Add(parIdMelodie);

                Connection.Open();
                cmd.ExecuteNonQuery();
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

        public static string MelodieNameByID(int idMelodie, bool CloseConnection)
        {
            //---------------------< Returneaza denumirea melodiei >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                SqlCommand cmd = new SqlCommand("sp_MelodieNameByID", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@IdMelodie", idMelodie);
                cmd.Parameters.Add(parId);

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                string Nume;
                Nume = cmd.ExecuteScalar().ToString();
                
                if(CloseConnection)
                    Connection.Close();

                return Nume;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare MelodieNameByID: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        #endregion

        #region Participanti
        public static void InsertParticipant(Participant participant)
        {

            //---------------------< Insereaza un participant in baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                SqlCommand cmd = new SqlCommand("sp_InsertParticipant", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

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

        public static void LoadParticipanti(ref List<Participant> participanti)
        {

            //---------------------< Extrage participantii din baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //----------------------------< Extragerea datelor din BD >-------------------------

                //Stabilirea conexiunii
                Connection.Open();

                //Crerea unui obiect de tip DataAdapter pentru conectarea DataSet-ului
                //cu baza de date.
                SqlDataAdapter daParticipanti = new SqlDataAdapter("sp_LoadParticipanti", Connection);
                daParticipanti.SelectCommand.CommandType = CommandType.StoredProcedure;
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
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        public static void UpdateParticipantScor(int idParticipant, int ScorDeAdaugat)
        {

            //---------------------< Modifica scorul participantului >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateParticipantScor", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parScor = new SqlParameter("@ScorDeAdaugat", ScorDeAdaugat);
                cmd.Parameters.Add(parScor);

                SqlParameter parIdParticipant = new SqlParameter("@IdParticipant", idParticipant);
                cmd.Parameters.Add(parIdParticipant);

                Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare UpdateParticipantScor: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        public static string ParticipantNumeByID(int idParticipant, bool CloseConnection)
        {

            //---------------------< Returneaza numele participantului >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                SqlCommand cmd = new SqlCommand("sp_ParticipantNumeByID", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@IdParticipant", idParticipant);
                cmd.Parameters.Add(parId);

                if(Connection.State == ConnectionState.Closed)
                    Connection.Open();

                string Nume;
                Nume = cmd.ExecuteScalar().ToString();

                if(CloseConnection)
                    Connection.Close();

                return Nume;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare ParticipantNumeByID: " + ex.Message);
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

            //---------------------< Elimina participantul din baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_RemoveParticipant", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdParticipant = new SqlParameter("@IdParticipant", IdParticipant);
                cmd.Parameters.Add(parIdParticipant);

                Connection.Open();
                cmd.ExecuteNonQuery();
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
        #endregion

        #region Voturi
        public static void InsertVot(Vot vot)
        {
            //---------------------< Insereaza in vot in baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                SqlCommand cmd = new SqlCommand("sp_InsertVot", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parParticipant = new SqlParameter("@IdParticipant", vot.IdParticipant);
                cmd.Parameters.Add(parParticipant);

                SqlParameter parMelodie = new SqlParameter("@IdMelodie", vot.IdMelodie);
                cmd.Parameters.Add(parMelodie);

                SqlParameter parScor = new SqlParameter("@ScorVot", vot.ScorVot);
                cmd.Parameters.Add(parScor);

                SqlParameter parSondaj = new SqlParameter("@IdSondaj", vot.IdSondaj);
                cmd.Parameters.Add(parSondaj);

                SqlParameter parPozitieTop = new SqlParameter("@PozitieTop", vot.PozitieTop);
                cmd.Parameters.Add(parPozitieTop);

                SqlParameter parPozitieIndicata = new SqlParameter("@PozitiaIndicata", vot.PozitiaIndicata);
                cmd.Parameters.Add(parPozitieIndicata);

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
        
        public static void LoadVoturi(ref List<Vot> voturi, int idSondaj)
        {
            //--------------< Returneaza lista de voturi pentru sondajul indicat >---------------------
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //----------------------------< Extragerea datelor din BD >-------------------------

                //Stabilirea conexiunii
                Connection.Open();

                //Crerea unui obiect de tip DataAdapter pentru conectarea DataSet-ului
                //cu baza de date.
                SqlDataAdapter daVoturi = new SqlDataAdapter("sp_LoadVoturi", Connection);
                daVoturi.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdSondaj = new SqlParameter("@IdSondaj", idSondaj);
                daVoturi.SelectCommand.Parameters.Add(parIdSondaj);
                DataSet dsVoturi = new DataSet("Voturi");
                daVoturi.Fill(dsVoturi, "Voturi");
                DataTable tblVoturi = dsVoturi.Tables["Voturi"];
                Connection.Close();

                //Trecem la popularea listei.
                voturi.Clear();
                foreach (DataRow drVot in tblVoturi.Rows)
                {
                    voturi.Add(new Vot
                    {
                        IdVot = (int)drVot["IdVot"],
                        IdMelodie = (int)drVot["IdMelodie"],
                        IdParticipant = (int)drVot["IdParticipant"],
                        IdSondaj = (int)drVot["IdSondaj"],
                        ScorVot = (int)drVot["ScorVot"],
                        DenumireMelodie = MelodieNameByID((int)drVot["IdMelodie"], false),
                        NumeParticipant = ParticipantNumeByID((int)drVot["IdParticipant"], false),
                        PozitiaIndicata = (int)drVot["PozitiaIndicata"],
                        PozitieTop = (int)drVot["PozitieTop"]
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare LoadVoturi: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        #endregion

        #region Sondaj
        public static void InsertSondaj(Sondaj sondaj)
        {

            //---------------------< Insereaza un sondaj in baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertSondaj", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

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
            catch (Exception ex)
            {
                Debug.WriteLine("Error inserting Sondaj: " + ex.Message);
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        public static void UpdateScorFinalSondaj(Sondaj sondaj)
        {

            //---------------------< Actualizeaza scorul unui sondaj >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                SqlCommand cmd = new SqlCommand("sp_UpdateScorFinalSondaj", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

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

        public static void LoadSondaje(ref List<Sondaj> sondaje)
        {

            //---------------------< Extragerea sondajelor din baza de date >---------------------------

            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                //----------------------------< Extragerea datelor din BD >-------------------------

                //Stabilirea conexiunii
                Connection.Open();

                //Crerea unui obiect de tip DataAdapter pentru conectarea DataSet-ului
                //cu baza de date.
                SqlDataAdapter daSondaje = new SqlDataAdapter("sp_LoadSondaje", Connection);
                daSondaje.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dsSondaje = new DataSet("Sondaje");
                daSondaje.Fill(dsSondaje, "Sondaje");
                DataTable tblSondaje = dsSondaje.Tables["Sondaje"];
                Connection.Close();

                //Acum avem datele din tabela Melodii din baza de date in obiectul tblMelodii.
                //Trecem la popularea listei.

                sondaje.Clear();
                foreach (DataRow drSondaj in tblSondaje.Rows)
                {
                    sondaje.Add(new Sondaj
                    {
                        IdSondaj = (int)drSondaj["IdSondaj"],
                        IdParticipant = (int)drSondaj["IdParticipant"],
                        NumeParticipant = ParticipantNumeByID((int)drSondaj["IdParticipant"], false),
                        Data = (DateTime)drSondaj["Data"],
                        ScorFinal = (int)drSondaj["ScorFinal"]
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
        #endregion

        public static int LastInsertedID(string tableName)
        {

            //---------------------< Returneaza ultimul ID inserat in tabela indicata >---------------------------

            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd;
                switch (tableName)
                {
                    case "Melodii":
                        cmd = new SqlCommand("sp_LastInsertedIdMelodii", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        break;
                    case "Participanti":
                        cmd = new SqlCommand("sp_LastInsertedIdParticipanti", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        break;
                    case "Voturi":
                        cmd = new SqlCommand("sp_LastInsertedIdVoturi", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        break;
                    case "Sondaje":
                        cmd = new SqlCommand("sp_LastInsertedIdSondaje", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        break;
                    default:
                        throw new Exception("Invalid table name");
                }

                connection.Open();
                int LastInsertedId = (int)cmd.ExecuteScalar();
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

    }
}
