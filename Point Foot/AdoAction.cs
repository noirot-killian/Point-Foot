using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class AdoAction : Ado
    {
        public static List<Action> All()
        {
            try
            {
                List<Action> actions = new List<Action>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM action");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    Action a = new Action((Int32)reader["codeAct"], (String)reader["desiAct"], (Int32)reader["bareme"], (Boolean)reader["jeuneO/N"]);
                    actions.Add(a);
                }
                reader.Close();
                return actions;
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
