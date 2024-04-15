using DuelMasterLibrary.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.Worldobjects
{
    public class Wall : WorldObject
    {
        public Wall(string name="Wall", bool lootable=false, bool removable=false, Position? boardPostion = null) : base(name, lootable, removable, boardPostion)
        {

        }
    }
}
