using DuelMasterLibrary.GameMechanics.State_Interfaces;
using DuelMasterLibrary.GameMechanics.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.GameMechanics.Directions
{
    public class StateMachinePatternSouth : IStateMachinePattern
    {
        public Move? NextAction(InputType? key)
        {
            switch (key)
            {
                case InputType.Forward: return MoveObjects.GoSouth;
                case InputType.Right: return MoveObjects.GoEast;
                case InputType.Left: return MoveObjects.GoWest;
                case InputType.backwards: return MoveObjects.GoNorth;
            }
            Console.WriteLine("sorry input not valid");
            return null;
        }

        public IStateMachinePattern? NextState(InputType? key)
        {
            switch (key)
            {
                case InputType.Forward: return StateObjects.South;
                case InputType.Right: return StateObjects.East;
                case InputType.Left: return StateObjects.West;
                case InputType.backwards: return StateObjects.North;
            }
            Console.WriteLine("sorry input not valid");
            return null;
        }
    }
}
