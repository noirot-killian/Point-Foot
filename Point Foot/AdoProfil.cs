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
        public static List<Profil> All()
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
                    Profil p = new Profil((Int32)reader["idProfil"], (String)reader["nom"], (String)reader["prenom"], (DateTime)reader["dateNaiss"], (String)reader["pseudo"], (String)reader["mdp"], (String)reader["mail"], (Int32)reader["score"]);
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
        public static Profil unProfil(string pseudo, string mdp)
        {
            Profil p = null;
            MySqlDataReader reader;
            open();
            MySqlCommand requete = new MySqlCommand();
            requete.Connection = conn;
            requete.CommandText = ("SELECT *  FROM (profil p INNER JOIN profil_role pr ON p.idProfil = pr.idProfil) INNER JOIN role r ON pr.idRole = r.idRole WHERE pseudo = @pseudo AND mdp = @mdp");
            requete.Prepare();
            requete.Parameters.AddWithValue("@pseudo", pseudo);
            requete.Parameters.AddWithValue("@mdp", mdp);
            requete.Connection = conn;
            reader = requete.ExecuteReader();
            bool trouve = false;
            while (reader.Read())
            {
                if (!trouve)
                {
                    p = new Profil(reader.GetInt32("idProfil"), reader.GetString("nom"), reader.GetString("prenom"), reader.GetDateTime("date_naiss"), reader.GetString("mail"), reader.GetString("pseudo"), reader.GetString("mdp"), reader.GetDouble("score"));
                    trouve = true;
                }
                Role r = new Role(reader.GetInt32("idRole"), reader.GetString("libelle"));
                p.getRoles().Add(r);
                r.getProfils().Add(p);

            }
            reader.Close();
            return p;


        }
    }
}
