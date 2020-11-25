using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Point_Foot
{
    public class AdoActionProfil : Ado
    {
        public static List<ActionProfil> voirHistorique(int unId)
        {
            try
            {
                List<ActionProfil> actions_profils = new List<ActionProfil>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM action_profil WHERE idProfil=@id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", unId);
                cmd.Connection = conn;
                reader = cmd.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    ActionProfil ap = new ActionProfil((Int32)reader["idProfil"], (Int32)reader["codeAct"], (Double)reader["nbPointsGagnes"], (DateTime)reader["datePointsGagnes"]);
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
