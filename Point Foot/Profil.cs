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
        private int score;
        private bool licencie;
        private List<Role> roles;
 
        public Profil() { }
        public Profil(int unId, string unNom, string unPrenom, DateTime uneDateNaiss, string unMail, string unPseudo, string unMdp, int unScore)
        {
            this.idProfil = unId;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.dateNaiss = uneDateNaiss;
            this.mail = unMail;
            this.pseudo = unPseudo;
            this.mdp = unMdp;
            this.score = unScore;
            this.roles = new List<Role>();
        }
        public Profil(int unIdProfil, string unNom, string unPrenom, string unMail, string unPseudo, string unMdp, DateTime uneDate)
        {
            this.idProfil = unIdProfil;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.mail = unMail;
            this.pseudo = unPseudo;
            this.mdp = unMdp;
            this.dateNaiss = uneDate;
            this.roles = new List<Role>();
        }

        public int Id_profil { get => idProfil; set => idProfil = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public DateTime Date_Naiss { get => dateNaiss; set => dateNaiss = value; }
        public int Score { get => score; set => score = value; }
        public bool Licencie { get => licencie; set => licencie = value; }
        internal List<Role> Roles { get => roles; set => roles = value; }
    }
}
