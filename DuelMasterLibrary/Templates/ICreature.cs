using ClassMaster.Templates;
using DuelMasterLibrary.GameMechanics;
using DuelMasterLibrary.GameMechanics.State_Interfaces;

namespace DuelMasterLibrary.Templates
{
    public interface ICreature
    {
        Position BoardPosition { get; set; }
        bool Dead { get; set; }
        Equipment[] Equipments { get; set; }
        int Hitpoints { get; set; }
        List<WorldObject> Inventory { get; set; }
        string? Name { get; set; }
        IState State { get; set; }
        DuelMasterWorker? Worker { get; set; }

        void Attack(DamageDie die);
        Position? LocatePosition();
        void Pickup();
        void PlayerMovement(InputType type);
        void ReceiveDamage(DamageController controller);
        int TotalDefense();
    }
}