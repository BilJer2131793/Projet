using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Humanizer;
using System.Xml.Serialization;

namespace Projet
{
    internal class Loader
    {
        public string curFile { get; set; }
        public Character PC { get; set; }
        public Character CharacterLoader()
        {
            string CD = Directory.GetCurrentDirectory();
            PC = CharacterSelect(CD);
            Console.WriteLine(PC);
            SaveFile(PC);


            return PC;
        }
        public Character CharacterSelect(string CD)
        {
            Character PC = new Character();
            Console.WriteLine("Please select your profile");
            string filePath = CD + @"\SaveFiles\";
            string[] fileEntries = Directory.GetFiles(filePath);
            int i = 0;
            while (i < fileEntries.Length)
            {
                Console.WriteLine($"{i + 1}. {fileEntries[i].Replace(filePath, "").Replace(".xml", "")}");
                i++;
            }
            Console.WriteLine($"{i + 1}. Create a new character");

            int choix = Convert.ToInt32(Console.ReadLine());
            if (choix == i + 1)
            {
                PC = CreateCharacter(filePath);
            }
            else
            {
                curFile = fileEntries[choix - 1];
                PC = LoadCharacter(curFile);
            }
            return PC;
        }
        public Character CreateCharacter(string CD)
        {
            Console.WriteLine("Name your character");
            string newFile = Console.ReadLine();
            curFile = CD + newFile + ".xml";

            File.Create(curFile).Close();
            Character PC = new Character();
            PC = PC.CharacterCreator(newFile);

            Serialize(curFile, PC);

            return PC;
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
        public void SaveFile(Character PC)
        {
            Serialize(curFile, PC);
        }



        public void UpdateNode(string file)
        {
            XDocument doc = XDocument.Load(file);
            string stat = "str";
            int newStat = 2;
            // Option1: Using SetAttributeValue()
            //XDocument xmlDoc = XDocument.Parse(tempXml);
            // Update Element value  
            var items = from item in doc.Descendants(stat)
                        where item.Attribute("ID").Value == "2"
                        select item;

            foreach (XElement itemElement in items)
            {
                itemElement.SetAttributeValue(stat, newStat);
            }

            doc.Save(file);
        }
        public void XMLTest(XDocument doc)
        {
            var str = doc.Root.Element("str");
            Console.WriteLine(str);
            if (str != null)
            {
                str.Value = "6";
            }
            doc.Save(@"J:\Code Prog\testing\test.xml");
        }
    }
}
