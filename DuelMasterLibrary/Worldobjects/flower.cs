using DuelMasterLibrary.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.Worldobjects
{
    public class flower:WorldObject
    {

        public flower(string name="flower", bool lootable=true, bool removable = true, Position? boardPostion = null) : base(name, lootable, removable, boardPostion)
        {

        }
    }
}
