using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class AdoProfil : Ado
    {
        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);

            }
        }
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
                    Profil p = new Profil((Int32)reader["idProfil"], (String)reader["nom"], (String)reader["prenom"], (String)reader["pseudo"], (String)reader["mdp"], (String)reader["mail"], (DateTime)reader["dateNaiss"],(Int32)reader["score"], (String)reader["numLicence"]);
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
            requete.Parameters.AddWithValue("@mdp", Encrypt(mdp));
            requete.Connection = conn;
            reader = requete.ExecuteReader();
            bool trouve = false;
            while (reader.Read())
            {
                if (!trouve)
                {
                    double score = 0;
                    if (!reader.IsDBNull(7))
                    {
                        score = reader.GetDouble(7);
                    }
                    p = new Profil(reader.GetInt32("idProfil"), reader.GetString("nom"), reader.GetString("prenom"), reader.GetString("mail"), reader.GetString("pseudo"), reader.GetString("mdp"), reader.GetDateTime("date_naiss"), score, (String)reader["numLicence"]);
                    trouve = true;
                }
                Role r = new Role(reader.GetInt32("idRole"), reader.GetString("libelle"));
                p.getRoles().Add(r);
                r.getProfils().Add(p);

            }
            reader.Close();
            return p;
        }
        public static void create(Profil profil)
        {
            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO profil(nom,prenom,mail,pseudo,mdp,date_naiss,score,numLicence) VALUES(@nom,@prenom,@mail,@pseudo,@mdp,@date_naiss,@score,@numLicence)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@nom", profil.getNom());
                cmd.Parameters.AddWithValue("@prenom", profil.getPrenom());
                cmd.Parameters.AddWithValue("@mail", profil.getMail());
                cmd.Parameters.AddWithValue("@pseudo", profil.getPseudo());
                cmd.Parameters.AddWithValue("@mdp", Encrypt(profil.getMdp()));
                cmd.Parameters.AddWithValue("@date_naiss", profil.getDateNaiss());
                cmd.Parameters.AddWithValue("@score", profil.getScore());
                cmd.Parameters.AddWithValue("@numLicence", profil.getNumLicence());
                cmd.ExecuteNonQuery();
                Console.WriteLine("profil créé");
                close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void delete(int unId)
        {
            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE * FROM profil WHERE idProfil = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", unId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("profil supprimé");
                close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
