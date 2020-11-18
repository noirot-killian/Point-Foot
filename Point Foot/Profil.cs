using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class Profil
    {

        public Profil() { }
        
        public Profil(int unId, string unNom, string unPrenom, string unMail, string unPseudo, DateTime uneDateNaiss, double unScore, string unNumLicence, int unePremiereCo)
        {
            this.IdProfil = unId;
            this.Nom = unNom;
            this.Prenom = unPrenom;
            this.Mail = unMail;
            this.Pseudo = unPseudo;
            this.Mdp = RandomPassword();
            this.DateNaiss = uneDateNaiss;
            this.Score = unScore;
            this.NumLicence = unNumLicence;
            this.PremiereCo = unePremiereCo;
            this.Roles = new List<Role>();
            

        }
        public Profil(int unIdProfil, string unNom, string unPrenom, string unMail, string unPseudo, string unMdp, DateTime uneDate, int unePremiereCo)
        {
            this.IdProfil = unIdProfil;
            this.Nom = unNom;
            this.Prenom = unPrenom;
            this.Mail = unMail;
            this.Pseudo = unPseudo;
            this.Mdp = RandomPassword();
            this.DateNaiss = uneDate;
            this.Roles = new List<Role>();
            this.Score = 0;
            this.PremiereCo = unePremiereCo;
        }
        
        //Constructeur pour méthode All() de AdoProfil

        public Profil(int unIdProfil, string unNom, string unPrenom, string unMail, double unScore, string unNumLicence)
        {
            this.IdProfil = unIdProfil;
            this.Nom = unNom;
            this.Prenom = unPrenom;
            this.Mail = unMail;
            this.Score = unScore;
            this.NumLicence = unNumLicence;
        }

        public int IdProfil { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Pseudo { get; set; }
        public string Mdp { get; set; }
        public DateTime DateNaiss { get; set; }
        public double Score { get; set; }
        public string NumLicence { get; set; }
        public List<Role> Roles { get; set; }
        public int PremiereCo { get; set; }
        public static string RandomPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public override string ToString()
        {
            return this.Nom + " " + this.Prenom;
        }

    }
}
