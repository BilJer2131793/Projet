using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Projet
{
    internal class Game
    {
        public string curFile { get; set; }
        public Character PC { get; set; }

        public void Start()
        {
            Loader loader = new Loader();

            PC = loader.CharacterLoader();



        }

        public void GameplayLoop()
        {

        }

        
    }
}
