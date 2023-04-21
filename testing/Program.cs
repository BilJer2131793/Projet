using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Projet
{
    internal class Program
    {
        public static string curFile { get; set; }
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();




            //Console.WriteLine("Add the new element to the document...");
            //XmlElement root = docX.DocumentElement;
            //XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Database", "");
            //string newFile = CD + @"\Savefiles\newXML.xml";
        }
    }
}
