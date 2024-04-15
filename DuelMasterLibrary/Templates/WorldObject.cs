using ClassMaster.Templates;
using DuelMasterLibrary.Worldobjects;
using System.Xml.Serialization;

namespace DuelMasterLibrary.Templates
{
    public abstract class WorldObject
    {

        public WorldObject(string name, bool lootable, bool removable, Position? boardPostion = null)
        {
            Name = name;
            Lootable = lootable;
            Removeable = removable;
            Position = boardPostion;

        }

        public Position? Position { get; set; }
        public bool Lootable { get; set; }
        public bool Removeable { get; set; }
        public string? Name { set; get; }

        public override string ToString()
        {
            return $"name {Name} , Position: Coloumn:{Position.Col}  Row:{Position.Row} Lootable:{Lootable}  Removable:{Removeable}";
        }

    }
}
