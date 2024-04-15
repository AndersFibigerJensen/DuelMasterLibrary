using DuelMasterLibrary.GameMechanics.Directions;
using DuelMasterLibrary.GameMechanics.State_Interfaces;
using DuelMasterLibrary.GameMechanics.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    public static class StateTranslator
    {
        public static string statetranslator(IStateMachinePattern pattern)
        {
            switch(pattern)
            {
                case StateMachinePatternNorth:
                    return "north";
                case StateMachinePatternSouth:
                    return "south";
                case StateMachinePatternEast:
                    return "east";
                case StateMachinePatternWest:
                    return "west";
            }
            return null;
        }

    }
}
