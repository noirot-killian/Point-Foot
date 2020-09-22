using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Foot
{
    class Action
    {
        private int code_Act;
        private string designation_Act;
        private int bareme;
        private bool jeune;

        public int Code_Act { get => code_Act; set => code_Act = value; }
        public string Designation_Act { get => designation_Act; set => designation_Act = value; }
        public int Bareme { get => bareme; set => bareme = value; }
        public bool Jeune { get => jeune; set => jeune = value; }

        public Action(int unCodeAct, string uneDesignationAct, int unBareme, bool unJeune)
        {
            this.code_Act = unCodeAct;
            this.designation_Act = uneDesignationAct;
            this.bareme = unBareme;
            this.jeune = unJeune;
        }
        public Action() { }
        
    }
}
