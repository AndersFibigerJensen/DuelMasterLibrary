using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DuelMasterLibrary.GameMechanics
{
    public class Board
    {
        
        public int Col { get; set; }
        
        
        public int Row { get; set; }

        public Board(int col, int row)
        {
           Row= new DamageController(row).Value;
           Col = new DamageController(col).Value;
        }

        public Board()
        {
            
        }
    }
}
