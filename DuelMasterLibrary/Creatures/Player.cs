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
    public class Player : Creature
    {
        private DamageDie _die;

        public Player(int hitpoints, string name, Position position, Equipment[] equipment=null, List<WorldObject>? inventory = null) : base(hitpoints, name, position, equipment, inventory)
        {
            Dead = false;
            Name = name;
            Hitpoints = hitpoints;
            if (inventory != null)
                Inventory = inventory;
            else
                Inventory = new List<WorldObject>();
            if (Equipments != null)
                Equipments = equipment;
            else
                Equipments = new Equipment[4];
            _die = new DamageDie(20, 10);
        }


        /// <summary>
        /// ser om der er en creature foran spilleren og hvis der er rulles
        /// die for at se hvor meget skade en creature får
        /// </summary>
        /// <param name="die">en terning som er rulles for at give skade til en creature</param>
        public override void Attack(DamageDie die=null)
        {
            
            Position? position = LocatePosition();
            Creature? creature = Worker.ExamineCreature(position);
            if (creature == null)
            {

            }
            else
            {
                int roll = 0;
                if (die!=null)
                    roll=die.roll();
                roll = _die.roll();

                Tracer.traceinfo($" you attacked with {roll} damage");
                creature.ReceiveDamage(new DamageController(roll));
            }
            Tracer.Close();
                

        }

        public override void Equip(Equipment equip)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// bruges til at flytte en Player rundt på Board og sørger for at spilleren kan ændre state
        /// selvom de ikke rykker sig
        /// </summary>
        /// <param name="type"> det Input en Player får der får dem til at rykke og ændre state</param>
        public override void PlayerMovement(InputType type)
        {
            Move move = State.NextMove(type);
            Position position = new Position(BoardPosition.Row + move.row, BoardPosition.Col + move.col);
            if (Worker.examinemovement(position) == true)
            {
                BoardPosition.Col += move.col;
                BoardPosition.Row += move.row;
            }

        }

        /// <summary>
        /// giver skade til en creature minus forsvar fra TotalDefense
        /// </summary>
        /// <param name="controller">giver skaden til funktionen receivedamage og sørger for at skaden
        /// ikke er en negativ værdi
        /// </param>
        public override void ReceiveDamage(DamageController controller)
        {
            int result = new DamageController(TotalDefense() + controller.Value).Value;
            Tracer.traceinfo($"received {result} damage");
            Hitpoints -= result;
            Hitpoints=new DamageController(Hitpoints).Value;
            Tracer.traceinfo($"{Name} has {Hitpoints} hitpoints");
        }

        /// <summary>
        /// returnere summen af forsvar en creature har og sender summen af forsvar
        /// til tracefile
        /// </summary>
        /// <returns> returnerne summen af forswar</returns>
        public override int TotalDefense()
        {
            int defensetotal = 0;
            foreach (Equipment equipment in Equipments)
            {
                defensetotal += equipment.Defense;
                
            }
            Tracer.traceinfo($"{Name} has {defensetotal} defense");
            return defensetotal;
        }
    }
}
