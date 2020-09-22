using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    class Profil
    {
        private int id_profil;
        private string nom;
        private string prenom;
        private string mail;
        private string pseudo;
        private string mdp;
        private DateTime date_Naiss;
        private int score;
        private bool licencie;
        private List<Role> roles;
 
        public Profil() { }

        public Profil(int unIdProfil, string unNom, string unPrenom, string unMail, string unPseudo, string unMdp, DateTime uneDate)
        {
            this.id_profil = unIdProfil;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.mail = unMail;
            this.pseudo = unPseudo;
            this.mdp = unMdp;
            this.date_Naiss = uneDate;
            this.roles = new List<Role>();
        }

        public int Id_profil { get => id_profil; set => id_profil = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public DateTime Date_Naiss { get => date_Naiss; set => date_Naiss = value; }
        public int Score { get => score; set => score = value; }
        public bool Licencie { get => licencie; set => licencie = value; }
        internal List<Role> Roles { get => roles; set => roles = value; }
    }
}
