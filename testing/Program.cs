using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace testing
{
    internal class Program
    {
        public static string curFile { get; set; }
        static void Main(string[] args)
        {
            string CD = Directory.GetCurrentDirectory();
            Character PC = new Character();
            PC = CharacterSelect(CD);
            Console.WriteLine(PC);
            SaveFile(PC);




            //Console.WriteLine("Add the new element to the document...");
            //XmlElement root = docX.DocumentElement;
            //XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Database", "");
            //string newFile = CD + @"\Savefiles\newXML.xml";
        }
        public static Character CharacterSelect(string CD)
        {
            Character PC = new Character();
            Console.WriteLine("Please select your profile");
            string filePath = CD + @"\SaveFiles\";
            string[] fileEntries = Directory.GetFiles(filePath);
            int i = 0;
            while(i < fileEntries.Length)
            {
                Console.WriteLine($"{i+1}. {fileEntries[i].Replace(filePath, "").Replace(".xml","")}");
                i++;
            }
            Console.WriteLine($"{i+1}. Create a new character");

            int choix = Convert.ToInt32(Console.ReadLine());
            if(choix == i + 1)
            {
                PC = CreateCharacter(filePath);
            }
            else
            {
                curFile = fileEntries[choix - 1];
                PC = PC.LoadCharacter(curFile);
            }
            return PC;
        }
        static Character CreateCharacter(string CD)
        {
            Console.WriteLine("Name your character");
            string newFile = Console.ReadLine();
            curFile = CD + newFile + ".xml";

            File.Create(curFile).Close();
            Character PC = new Character();
            PC = PC.CharacterCreator(newFile);

            PC.Serialize(curFile, PC);

            return PC;
        }
        static void SaveFile(Character PC)
        {
            PC.Serialize(curFile, PC);
        }
        static void UpdateStats()
        {

        }

        static void UpdateNode(string file)
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
                itemElement.SetAttributeValue(stat,newStat);
            }

            doc.Save(file);
        }
        static void XMLTest(XDocument doc)
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
