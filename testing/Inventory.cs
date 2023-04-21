using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class Inventory
    {
        public Weapon RightHand { get; set; }
        public Weapon LeftHand { get; set; }
        public Armor Head { get; set; }
        public Armor Chestpiece { get; set; }
        public Armor Boots { get; set; }
        public List<Item> Inv { get; set; }
        public int Money { get; set; }
        public Inventory()
        {
            Inv = new List<Item>();
            RightHand = new Weapon("empty");
            LeftHand = new Weapon("empty");
            Head = new Armor("empty");
            Chestpiece = new Armor("empty");
            Boots = new Armor("empty");
        }

    }
}
