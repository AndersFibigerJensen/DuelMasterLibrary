using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.GameMechanics.State_Interfaces
{
    public record Move(int row, int col);
    public interface IState
    {
        Move NextMove(InputType type);

        public IStateMachinePattern CurrentState { get; set; }

    }
}
