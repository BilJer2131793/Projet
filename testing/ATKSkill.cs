using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class ATKSkill : Skill
    {
        public int DMG { get; set; }

        public ATKSkill(int dMG, string name, string description, int cost, bool aOE, int hits) : base(name, description, cost, aOE, hits)
        {
            DMG = dMG;
        }
    }
}
