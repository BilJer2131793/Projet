using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public enum Effect
    {
        Heal,
        Shield
    }
    internal class SUPSkill : Skill
    {
        public Effect effect { get; set; }
        public int points { get; set; }

        public SUPSkill(Effect effect, int points, string name, string description, int cost, bool aOE, int hits) : base(name, description, cost, aOE, hits)
        {
            this.effect = effect;
            this.points = points;
        }
    }
}
