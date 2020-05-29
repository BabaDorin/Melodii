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
                        Informatii = drMelodie["Informatii"].ToString()
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
    }
}
