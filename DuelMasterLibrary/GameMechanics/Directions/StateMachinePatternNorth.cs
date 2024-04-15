using DuelMasterLibrary.GameMechanics.State_Interfaces;
using DuelMasterLibrary.GameMechanics.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.GameMechanics.Directions
{
    public class StateMachinePatternNorth : IStateMachinePattern
    {
        public Move? NextAction(InputType? key)
        {
            switch (key)
            {
                case InputType.Forward: return MoveObjects.GoNorth;
                case InputType.Right: return MoveObjects.GoWest;
                case InputType.Left: return MoveObjects.GoEast;
                case InputType.backwards: return MoveObjects.GoSouth;
            }
            Console.WriteLine("sorry input not valid");
            return null;
        }

        public IStateMachinePattern? NextState(InputType? key)
        {
            switch (key)
            {
                case InputType.Forward: return StateObjects.North;
                case InputType.Right: return StateObjects.West;
                case InputType.Left: return StateObjects.East;
                case InputType.backwards: return StateObjects.South;
            }
            Console.WriteLine("sorry input not valid");
            return null;
        }
    }
}
