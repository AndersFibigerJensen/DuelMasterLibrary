using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.GameMechanics.State_Interfaces
{
    public interface IStateMachinePattern
    {
        /// <summary>
        /// determines which direction a creature is facing
        /// </summary>
        /// <param name="key">the input that determines the direction a creature is turning</param>
        /// <returns> the current state of a creatures direction</returns>
        IStateMachinePattern? NextState(InputType? key);

        /// <summary>
        /// shows the movement of a creature
        /// </summary>
        /// <param name="key">the input that determines how a creature moves</param>
        /// <returns> a move that is used to change the current position of a creature</returns>
        Move? NextAction(InputType? key);


    }
}
