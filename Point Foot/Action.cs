﻿using System.Collections.Generic;

namespace Point_Foot
{
    public class Action
    {
        private int codeAct;
        private string desiAct;
        private int bareme;
        private int jeune;
        private List<Action> actions;

        public int Code_Act { get => codeAct; set => codeAct = value; }
        public string Designation_Act { get => desiAct; set => desiAct = value; }
        public int Bareme { get => bareme; set => bareme = value; }
        public int Jeune { get => jeune; set => jeune = value; }
        public List<Action> Actions { get => actions; set => actions = value; }

        public Action(int unCodeAct, string uneDesignationAct, int unBareme, int unJeune)
        {
            this.codeAct = unCodeAct;
            this.desiAct = uneDesignationAct;
            this.bareme = unBareme;
            this.jeune = unJeune;
        }
        public Action() { }

        public override string ToString()
        {
            return this.Designation_Act;
        }

    }
}
