using ClassMaster.Templates;
using DuelMasterLibrary.GameMechanics.Directions;
using DuelMasterLibrary.GameMechanics.State_Interfaces;
using DuelMasterLibrary.GameMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Serialization;

namespace DuelMasterLibrary.Templates
{
    public abstract class Creature : ICreature
    {
        private int _hitpoints;
        private int maxhitpoints;
        private bool _dead;


        public Creature(int hitpoints, string? name, Position positions, Equipment[] equipment=null, List<WorldObject>? inventory = null)
        {
            Name = name;
            maxhitpoints = hitpoints;
            BoardPosition = positions;
            _hitpoints = maxhitpoints;
            if (inventory != null)
                Inventory = inventory;
            else
                Inventory = new List<WorldObject>();
            if (Equipments != null)
                Equipments = equipment;
            else
                Equipments = new Equipment[4];
            State = new PlayerMachinePattern();

        }

        public string? Name { get; set; }

        public IState State { get; set; }


        public DuelMasterWorker? Worker { get; set; }

        public List<WorldObject> Inventory { get; set; }

        public Position BoardPosition { get; set; }


        public Equipment[] Equipments { get; set; }

        public int Hitpoints { get { return _hitpoints; } set { _hitpoints = value; } }

        public bool Dead
        {
            get { if (Hitpoints == 0) _dead = true; return _dead; }
            set { _dead = value; }
        }


        /// <summary>
        /// Calculate damage to hitpoints
        /// </summary>
        /// <param name="die"> is used to create damage instead of making it a fixed amount</param>
        /// <returns>an int that shows how much damage another creature gets</returns>
        public abstract void Attack(DamageDie die);

        /// <summary>
        /// The method is used to reduce hitpoints minus the total defense of Equipment
        /// 
        /// </summary>
        /// <param name="damage"> how much damage the original hit is  </param>
        public abstract void ReceiveDamage(DamageController controller);

        /// <summary>
        /// gives a creature a way to pick up materials
        /// </summary>
        public void Pickup()
        {
            WorldObject? item = Worker.ExamineObject(LocatePosition());
            if (item != null)
            {
                if (item.Removeable && item.Lootable)
                {
                    Tracer.traceinfo(item.ToString());
                    Inventory.Add(item);
                    Worker.removeobject(item);
                }
            }
        }

        /// <summary>
        ///  is used to locate what the position in front of a creature is
        /// </summary>
        /// <returns> a Position</returns>
        public Position? LocatePosition()
        {
            Move? move = State.NextMove(InputType.Forward);
            if (move != null)
            {
                Position position = new Position(BoardPosition.Row + move.row, BoardPosition.Col + move.col);
                return position;
            }
            return null;

        }


        /// <summary>
        /// the total amount of defense a creature has
        /// </summary>
        /// <returns>returns the sum of defense points a creature has</returns>
        public abstract int TotalDefense();

        /// <summary>
        /// is used to move a creature in a specific direction
        /// </summary>
        /// <param name="move"> the movement that a creature takes</param>
        public abstract void PlayerMovement(InputType type);

        /// <summary>
        /// is used to add an Equipment to a player
        /// </summary>
        /// <param name="equip"></param>
        public abstract void Equip(Equipment equip);
    }
}
