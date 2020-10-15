﻿using Renci.SshNet;
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
        private int premiereCo;

        public int IdProfil { get => idProfil; set => idProfil = value; }

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
            this.premiereCo = 0;

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
            this.premiereCo = 0;
        }
  
        public int getIdProfil()
        {
            return this.idProfil;
        }
        public string getNom()
        {
            return this.nom;
        }
        public string getPrenom()
        {
            return this.prenom;
        }
        public DateTime getDateNaiss()
        {
            return this.dateNaiss;
        }
        public string getMail()
        {
            return this.mail;
        }
        public string getPseudo()
        {
            return this.pseudo;
        }
        public string getMdp()
        {
            return this.mdp;
        }
        public double getScore()
        {
            return this.score;
        }
        public string getNumLicence()
        {
            return this.numLicence;
        }
        public List<Role> getRoles()
        {
            return this.roles;
        }
        public int getPremiereCo()
        {
            return this.premiereCo;
        }

        // setters
        public void setIdProfil(int newIdProfil)
        {
            this.idProfil = newIdProfil;
        }
        public void setNom(string newNom)
        {
            this.nom = newNom;
        }
        public void setPrenom(string newPrenom)
        {
            this.prenom = newPrenom;
        }
        public void setDateNaiss(DateTime newDateNaiss)
        {
            this.dateNaiss = newDateNaiss;
        }
        public void setMail(string newMail)
        {
            this.mail = newMail;
        }
        public void setPseudo(string newPseudo)
        {
            this.pseudo = newPseudo;
        }
        public void setMdp(string newMdp)
        {
            this.mdp = newMdp;
        }
        public void setScore(int newScore)
        {
            this.score = newScore;
        }
        public void setNumLicence(string newNumLicence)
        {
            this.numLicence = newNumLicence;
        }
        public void setRoles(List<Role> newRoles)
        {
            this.roles = newRoles;
        }
        public void setPremiereCo(int unePremiereCo)
        {
            this.premiereCo = unePremiereCo;
        }
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
