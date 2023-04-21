using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public bool AOE { get; set; }
        public int Hits { get; set; }

        public Skill(string name, string description, int cost, bool aOE, int hits)
        {
            Name = name;
            Description = description;
            Cost = cost;
            AOE = aOE;
            Hits = hits;
        }
    }
}
