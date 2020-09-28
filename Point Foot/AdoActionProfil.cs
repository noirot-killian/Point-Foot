using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class AdoActionProfil : Ado
    {
        public static List<ActionProfil> All()
        {
            try
            {
                List<ActionProfil> actions_profils = new List<ActionProfil>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM action_profil");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    ActionProfil ap = new ActionProfil((Int32)reader["idProfil"], (Int32)reader["codeAct"], (Double)reader["nbPointsGagnés"], (DateTime)reader["datePointsGagnés"]);
                    actions_profils.Add(ap);
                }
                reader.Close();
                return actions_profils;
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
