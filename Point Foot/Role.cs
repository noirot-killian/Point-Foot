using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class Role
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

        // getters
        public int getIdRole()
        {
            return this.idRole;
        }
        public string getLibelle()
        {
            return this.libelle;
        }
        public List<Profil> getProfils()
        {
            return this.profils;
        }

        // setters
        public void setIdRole(int newIdRole)
        {
            this.idRole = newIdRole;
        }
        public void setLibelle(string newLibelle)
        {
            this.libelle = newLibelle;
        }
        public void setProfils(List<Profil> newProfils)
        {
            this.profils = newProfils;
        }
    }
}
