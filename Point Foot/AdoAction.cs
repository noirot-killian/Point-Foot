using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
                    int bareme = 0;
                    int jeune = 0;
                    if (!reader.IsDBNull(2))
                    {
                        bareme = reader.GetInt32(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        jeune = reader.GetInt32(3);
                    }
                    Action a = new Action((Int32)reader["codeAct"], (String)reader["desiAct"], bareme, Convert.ToBoolean(jeune));
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
