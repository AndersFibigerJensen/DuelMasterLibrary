using DuelMasterLibrary.Creatures;
using DuelMasterLibrary.Templates;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DuelMasterLibrary.GameMechanics
{
    public class SaveFile
    {
        public SaveFile()
        {
            
        }

        public XmlDocument? Doc { get; set; }

        public StreamWriter Writer { get; set; }

        public List<WorldObject> objects { get; set; }

        public Board board { get; set; }

        public List<Creature> creatures { get; set; }

        public Player Player { get; set; }


        /// <summary>
        /// loader boardet ud fra en config fil
        /// </summary>
        /// <param name="file">filstien til det board som skal loades</param>
        public void LoadBoard()
        {
            LoadFile();
            XmlNode? node=Doc.SelectSingleNode("saveFile/Board");
            if(node!= null) 
            {
                List<string> list = new List<string>();
                for (int i=0; i<node.ChildNodes.Count;i++) 
                {
                    list.Add(node.ChildNodes.Item(i).InnerText);
                }
                board = new Board(Convert.ToInt32(list[0]), Convert.ToInt32(list[1]));
            }
            
            
        }

        public void LoadFile(string file=null)
        {
            Doc = new XmlDocument();
            switch (file)
            {
                case null:
                    Doc.Load("C:\\Users\\ander\\source\\repos\\DuelMasterLibrary\\Worker\\bin\\Debug\\net8.0\\boardfile.xml");
                    break;
                default:
                    Doc.Load(file);
                    break;
            }
        }



    }
}
