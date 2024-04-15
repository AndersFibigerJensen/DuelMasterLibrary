using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DuelMasterLibrary
{
    public class Position
    {
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public Position()
        {
            
        }

        [XmlAttribute("Row")]
        public int Row { get; set; }

        [XmlAttribute("Col")]
        public int Col { get; set; }
    }
}
