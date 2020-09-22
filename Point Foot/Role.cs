using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    class Role
    {
        private int idRole;
        private string libelle;
        private List<Profil> profils;

        public Role() { }
        public Role(int unIdRole, string unLibelle)
        {
            this.idRole = unIdRole;
            this.libelle = unLibelle;
            this.profils = new List<Profil>();
        }
        public Role(string unLibelle)
        {

            this.idRole = 0;
            this.libelle = unLibelle;
            List<Profil> profils = new List<Profil>();
        }

        public int IdRole { get => idRole; set => idRole = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        internal List<Profil> Profils { get => profils; set => profils = value; }
    }
}
