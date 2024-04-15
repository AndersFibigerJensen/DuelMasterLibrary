using DuelMasterLibrary;
using DuelMasterLibrary.Templates;
using System.Xml.Serialization;


namespace ClassMaster.Templates
{
    public abstract class Equipment : WorldObject
    {

        public Equipment(string name, Position boardposition, int defense, bool lootable, bool removable = true) : base(name, lootable, removable,boardposition)
        {
            Equipable = true;
            Defense = defense;
        }

        [XmlAttribute("Defense")]
        public int Defense { get; set; }

        [XmlAttribute("Equipable")]
        public bool Equipable { get; set; }

    }
}
