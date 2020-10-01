using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class AdoRole : Ado
    {
        public static List<Role> All()
        {
            try
            {
                List<Role> roles = new List<Role>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM role");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    Role r = new Role((Int32)reader["idRole"], (String)reader["libelle"]);
                    roles.Add(r);
                }
                reader.Close();
                return roles;
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
        public static Role unRole(string libelle)
        {


            Role r = null;
            MySqlDataReader reader;
            open();
            MySqlCommand requete = new MySqlCommand();
            requete.Connection = conn;
            requete.CommandText = ("SELECT * FROM(role r INNER JOIN profil_role pr ON r.idRole = pr.FK_idRole) INNER JOIN profil p ON pr.FK_idProfil = p.idProfil WHERE libelle = @libelle");
            requete.Parameters.AddWithValue("@libelle", libelle);
            requete.ExecuteNonQuery();
            reader = requete.ExecuteReader();
            while (reader.Read())
            {

                r = new Role(reader.GetInt32("idRole"), reader.GetString("libelle"));
                Profil p = new Profil(reader.GetInt32("idProfil"), reader.GetString("nom"), reader.GetString("prenom"), reader.GetString("mail"), reader.GetString("pseudo"), reader.GetString("mdp"), reader.GetDateTime("DateNaissance"));
                r.getProfils().Add(p);
                p.getRoles().Add(r);

            }
            reader.Close();
            return r;
        }
    }
}
