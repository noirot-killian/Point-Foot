using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class AdoCategorie : Ado
    {
        public static List<Categorie> All()
        {
            try
            {
                List<Categorie> categories = new List<Categorie>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM categorie");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    Categorie c = new Categorie((Int32)reader["codeCat"], (String)reader["desiCat"], (Double)reader["prixLicence"], (Boolean)reader["jeuneO/N"]);
                    categories.Add(c);
                }
                reader.Close();
                return categories;
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
