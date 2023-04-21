using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class Enemy
    {
        public string name { get; set; }
        public int maxHP { get; set; }
        public int HP { get; set; }
        public int maxMP { get; set; }
        public int MP { get; set; }
        public Skill[] Skills { get; set; }



    }
}
