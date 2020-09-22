using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class AdoProfil : Ado
    {
        public static List<Profil> all()
        {
            try
            {
                List<Profil> profils = new List<Profil>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM profil");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    Profil p = new Profil((Int32)reader["id"], (String)reader["nom"], (String)reader["prenom"], (DateTime)reader["dateNaiss"], (String)reader["pseudo"], (String)reader["mdp"], (String)reader["mail"], (Int32)reader["score"]);
                    profils.Add(p);
                }
                reader.Close();
                return profils;
            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                close();
            }
        }
    }
}
