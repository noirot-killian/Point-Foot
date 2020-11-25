using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
        public static void createCategorie(Categorie categorie)
        {
            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO categorie(desiCat,prixLicence,jeune) VALUES(@desiCat,@prixLicence,@jeune)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@desiCat", categorie.Designation_Cat);
                cmd.Parameters.AddWithValue("@prixLicence", categorie.PrixLicence);
                cmd.Parameters.AddWithValue("@jeune", categorie.Jeune);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Catégorie créée");
                close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
           
        }
    }
}
