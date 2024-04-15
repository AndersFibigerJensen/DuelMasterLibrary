using ClassMaster.Templates;
using DuelMasterLibrary.GameMechanics.State_Interfaces;
using DuelMasterLibrary.GameMechanics;
using DuelMasterLibrary.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.Creatures
{
    public class Wolf : Creature
    {
        /// <summary>
        /// kan bruges hvis wolf ikke har et weapon
        /// </summary>
        private DamageDie die;

        public Wolf(int hitpoints, string name, Position position, Equipment[] Equipment=null, List<WorldObject> inventory = null) : base(hitpoints, name, position, Equipment, inventory)
        {
            Dead = false;
            Name = name;
            Hitpoints = hitpoints;
            if (inventory != null)
                Inventory = inventory;
            else
                Inventory = new List<WorldObject>();
            if (Equipments != null)
                Equipments = Equipment;
            else
                Equipments = new Equipment[4];
            die = new DamageDie(12);

        }

        /// <summary>
        /// angreb mod et creatures hvis en creature eksistere på en position
        /// </summary>
        /// <param name="die">en terning som bruges til at rulle skade</param>
        public override void Attack(DamageDie die=null)
        {
            Position? position = LocatePosition();
            Creature? creature = Worker.ExamineCreature(position);
            if (creature == null)
            {

            }
            else
            {
                if (die == null)
                {
                    creature.ReceiveDamage(new DamageController(this.die.roll()));
                }
                creature.ReceiveDamage(new DamageController(die.roll()));
            }

        }

        public override void Equip(Equipment equip)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// en wolf flytter sig to felter når den bevæger sig
        /// </summary>
        /// <param name="move">hvilken vej creatures bevæger sig</param>
        public override void PlayerMovement(InputType type)
        {
            Move move = State.NextMove(type);
            Position position = new Position(BoardPosition.Row + move.row + 1, BoardPosition.Col + move.col + 1);
            if (Worker.examinemovement(position) == true)
            {
                BoardPosition.Col += move.col + 1;
                BoardPosition.Row += move.row + 1;
            }

        }

        public override void ReceiveDamage(DamageController controller)
        {
            int result = new DamageController(controller.Value-TotalDefense()).Value;
            Tracer.traceinfo($"Damaged received {result}");
            Hitpoints -= result;
            Hitpoints = new DamageController(Hitpoints).Value;
            Tracer.traceinfo($"{Name} has {Hitpoints} hitpoints");
        }

        /// <summary>
        /// ulve har 10 ekstra defense
        /// </summary>
        /// <returns>summen af defense</returns>
        public override int TotalDefense()
        {
            int defense = 10;
            if(Equipments!=null)
            {
                foreach (Equipment equip in Equipments)
                {
                    defense += equip.Defense;
                }
            }
            Tracer.traceinfo($"{Name} has {defense} in defense");
            return defense;
        }
    }
}
