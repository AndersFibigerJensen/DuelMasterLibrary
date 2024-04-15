using DuelMasterLibrary.GameMechanics.State_Interfaces;
using DuelMasterLibrary.GameMechanics.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.GameMechanics.Directions
{
        public class StateMachinePatternEast : IStateMachinePattern
    {
        public Move? NextAction(InputType? key)
        {
            switch (key)
            {
                case InputType.Forward: return MoveObjects.GoEast;
                case InputType.Right : return MoveObjects.GoNorth;
                case InputType.Left: return MoveObjects.GoSouth;
                case InputType.backwards: return MoveObjects.GoWest;
            }
            return null;
        }

        public IStateMachinePattern? NextState(InputType? key)
        {
            switch (key)
            {
                case InputType.Forward: return StateObjects.East;
                case InputType.Right: return StateObjects.North;
                case InputType.Left: return StateObjects.South;
                case InputType.backwards: return StateObjects.West;
            }
            return null;
        }
    }
}
