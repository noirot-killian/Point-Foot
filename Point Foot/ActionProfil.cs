using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    public class ActionProfil
    {
        private int idProfil;
        private int codeAct;
        private double nbPoints;
        private DateTime datePoints;

        public ActionProfil() { }
        public ActionProfil(int unIdProfil, int unCodeAct, double unNbPoints, DateTime uneDatePoints)
        {
            this.idProfil = unIdProfil;
            this.codeAct = unCodeAct;
            this.nbPoints = unNbPoints;
            this.datePoints = uneDatePoints;
        }

        public int IdProfil { get => idProfil; set => idProfil = value; }
        public int CodeAct { get => codeAct; set => codeAct = value; }
        public double NbPoints { get => nbPoints; set => nbPoints = value; }
        public DateTime DatePoints { get => datePoints; set => datePoints = value; }
    }
}
