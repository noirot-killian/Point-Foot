using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class Categorie
    {
        private int code_Cat;
        private string designation_Cat;
        private double prixLicence;
        private bool jeune;

        public int Code_Cat { get => code_Cat; set => code_Cat = value; }
        public string Designation_Cat { get => designation_Cat; set => designation_Cat = value; }
        public double PrixLicence { get => prixLicence; set => prixLicence = value; }
        public bool Jeune { get => jeune; set => jeune = value; }

        public Categorie (int unCodeCat, string uneDesignationCat, double unPrixLicence, bool unJeune)
        {
            this.code_Cat = unCodeCat;
            this.designation_Cat = uneDesignationCat;
            this.prixLicence = unPrixLicence;
            this.jeune = unJeune;
        }
        public Categorie() { }
    }
}
