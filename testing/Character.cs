using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Humanizer;
using System.Xml.Serialization;

namespace testing
{
    public enum Prof
    {
        warrior,
        archer,
        mage,
        thief,
        creation
    }
    public class Character
    {
        public string name { get; set; }
        public Prof prof;
        public int maxHP { get; set; }
        public int HP { get; set; }
        public int maxMP { get; set; }
        public int MP { get; set; }
        public int str { get; set; }
        public int wis { get; set; }
        public int dex { get; set; }
        public int def { get; set; }
        public int atk { get; set; }
        public int statPoints { get; set; }
        public Equipment[] equipment { get; set; }
        public List<string> inv { get; set; }

        
        public Character(string name, int HP, int MP, int str, int wis, int dex, int def, int atk, Prof prof)
        {
            this.name = name;
            maxHP = HP; 
            this.HP = HP;
            maxMP = MP;
            this.MP = MP;
            this.str = str;
            this.wis = wis;
            this.dex = dex;
            this.def = def;
            this.atk = atk;
            this.prof = prof;
            equipment = new Equipment[5];
            inv = new List<string>();
        }
        public Character(string name)
        {
            this.name=name;
            maxHP = 0;
            HP = 0;
            maxMP = 0;
            MP = 0;
            str = 0;
            wis = 0;
            dex = 0;
            def = 0;
            atk = 0;
            prof = Prof.creation;

            inv = new List<string>();
            equipment = new Equipment[5];
        }
        public Character()
        {

        }
        public string GetInfoPersonnage(Character PC)
        {
            return $"Personnage:\n" +
            $"NOM       : {{{PC.name}}}\n" +
            $"CLASSE    : {{{PC.prof.Humanize()}}}\n" +
            $"PV        : {{{PC.HP}}}\n" +
            $"Arme      : " +
            $"ARMURE    : " +
            $"BOUCLIER  : " +
            $"HEAUME    : " +
            $"EQUIPEMENT: {{}} \n";
        }
        public override string ToString()
        {
            return $"Personnage:\n" +
            $"NOM       : {{{name}}}\n" +
            $"CLASSE    : {{{prof.Humanize()}}}\n" +
            $"PV        : {{{HP}}}\n" +
            $"STR       : {{{str}}}\n" +
            $"WIS       : {{{wis}}}\n" +
            $"DEX       : {{{dex}}}\n" +
            $"DEF       : {{{def}}}\n" +
            $"ATK       : {{{atk}}}\n";
        }
        public string Inventory()
        {
            return $"Arme      : \n" +
            $"ARMURE    : \n" +
            $"BOUCLIER  : \n" +
            $"HEAUME    : \n" +
            $"EQUIPEMENT: {{}} \n"; ;
        }

        public Character CharacterCreator(string name)
        {

            int HP=0; int MP = 0; int str = 0; int wis = 0; int dex = 0; int def = 0; int atk = 0;
            Prof newProf;
            int choix = SelectProfession();
            switch (choix)
            {
                case 1:
                    newProf = Prof.warrior;
                    break;
                case 2:
                    newProf = Prof.archer;
                    break;
                case 3:
                    newProf = Prof.mage;
                    break;
                case 4:
                    newProf = Prof.thief;
                    break;
                default:
                    newProf = Prof.creation;
                    break;
            }
            switch (newProf)
            {
                case Prof.warrior:
                    HP = 20;
                    MP = 6;
                    str = 17;
                    wis = 14;
                    dex = 13;
                    def = 3;
                    atk = 2;
                    break;
                case Prof.archer:
                    HP = 16;
                    MP = 14;
                    str = 13;
                    wis = 15;
                    dex = 17;
                    def = 0;
                    atk = 2;
                    break;
                case Prof.mage:
                    HP = 14;
                    MP = 20;
                    str = 11;
                    wis = 18;
                    dex = 13;
                    def = 0;
                    atk = 0;
                    break;
                case Prof.thief:
                    HP = 15;
                    MP = 10;
                    str = 14;
                    wis = 14;
                    dex = 17;
                    def = 0;
                    atk = 3;
                    break;
            }
            return new Character(name, HP, MP, str, wis, dex, def, atk, newProf);

        }
        public int SelectProfession()
        {
            bool ok = true;
            int choix = 0;
            Console.WriteLine("Chose your Profession: \n" +
                "1. Warior\n" +
                "2. Archer\n" +
                "3. Mage\n" +
                "4. Thief\n");
            do
            {
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix < 0 && choix > 4)
                {
                    ok = false;
                    Console.WriteLine($"{choix} is not a valid Profession");
                }
            }while (!ok);

            return choix;
        }
        public Character LoadCharacter(string filepath)
        {

            XmlSerializer ser = new XmlSerializer(typeof(Character));
            using (StreamReader sr = new StreamReader(filepath))
            {
                return (Character)ser.Deserialize(sr);
            }
        }
        public void Serialize(string path, Character p)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
            File.WriteAllText(path, x + Environment.NewLine);
            TextWriter textWriter = new StreamWriter(path);
            x.Serialize(textWriter, p);
            textWriter.Close();
        }
    }
}
    

    


    





    

