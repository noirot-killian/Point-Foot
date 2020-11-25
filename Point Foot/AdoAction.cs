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
                    int codeAct = 0;
                   
                    if (!reader.IsDBNull(2))
                    {
                        bareme = reader.GetInt32(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        jeune = reader.GetInt32(3);
                    }
                    if(!reader.IsDBNull(0))
                    {
                        codeAct = reader.GetInt32(0);
                    }
                    Action a = new Action(codeAct, (String)reader["desiAct"], bareme, jeune);
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
        public static void createAction(Action action)
        {
            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO action(desiAct,bareme,jeune) VALUES(@desiAct,@bareme,@jeune)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@desiAct", action.Designation_Act);
                cmd.Parameters.AddWithValue("@bareme", action.Bareme);
                cmd.Parameters.AddWithValue("@jeune", action.Jeune);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Action créée");
                close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
    }
}
