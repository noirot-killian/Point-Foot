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

        private int idProfil;
        private string nom;
        private string prenom;
        private string mail;
        private string pseudo;
        private string mdp;
        private DateTime dateNaiss;
        private double score;
        private string numLicence; 
        private List<Role> roles;

        public Profil() { }
        public Profil(int unId, string unNom, string unPrenom, string unMail, string unPseudo, DateTime uneDateNaiss, double unScore, string unNumLicence)
        {
            this.idProfil = unId;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.mail = unMail;
            this.pseudo = unPseudo;
            this.mdp = RandomPassword();
            this.dateNaiss = uneDateNaiss;
            this.score = unScore;
            this.numLicence = unNumLicence;
            this.roles = new List<Role>();

        }
        public Profil(int unIdProfil, string unNom, string unPrenom, string unMail, string unPseudo, string unMdp, DateTime uneDate)
        {
            this.idProfil = unIdProfil;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.mail = unMail;
            this.pseudo = unPseudo;
            this.mdp = RandomPassword();
            this.dateNaiss = uneDate;
            this.roles = new List<Role>();
        }



        public int IdProfil { get => idProfil; set => idProfil = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public DateTime DateNaiss { get => dateNaiss; set => dateNaiss = value; }
        public double Score { get => score; set => score = value; }
        public string NumLicence { get => numLicence; set => numLicence = value; }
        public List<Role> Roles { get => roles; set => roles = value; }

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
       
    }
}
