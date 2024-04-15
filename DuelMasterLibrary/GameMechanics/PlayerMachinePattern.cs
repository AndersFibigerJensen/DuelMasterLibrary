using DuelMasterLibrary.GameMechanics.Directions;
using DuelMasterLibrary.GameMechanics.State_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.GameMechanics
{
    public class PlayerMachinePattern:IState
    {

        public PlayerMachinePattern()
        {
            CurrentState = new StateMachinePatternNorth();
        }

        public PlayerMachinePattern(IStateMachinePattern pattern)
        {
            CurrentState=pattern;
        }


        public IStateMachinePattern CurrentState { get; set; }

        /// <summary>
        /// bruges til at flytte rundt på creatures
        /// </summary>
        /// <param name="key"> det input der bruges til at bevæge en creature</param>
        /// <returns> returnere et Move object</returns>
        public Move NextMove(InputType key)
        {

            Move nextMove = CurrentState.NextAction(key);

            CurrentState = CurrentState.NextState(key);

            return nextMove;

        }
    }
}
