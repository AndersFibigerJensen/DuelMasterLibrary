using DuelMasterLibrary.Creatures;
using DuelMasterLibrary.GameMechanics.State_Interfaces;
using DuelMasterLibrary.GameMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuelMasterLibrary;

namespace Worker
{
    public class Menu
    {
        private Player _player;
        private SaveFile save = new SaveFile();

        public Menu(DuelMasterWorker Worker)
        {
            _player = Worker.Player;
        }

        /// <summary>
        /// bruges til at styre hvad en Player gør og kan gøre
        /// </summary>
        /// <param name="key"> det input som bruges til at styre hvad en spiller gør</param>
        public void FieldMenu(InputType key)
        {
            switch (key)
            {
                case InputType.Forward:
                    _player.PlayerMovement(key);
                    break;
                case InputType.Left:
                    _player.PlayerMovement(key);
                    break;
                case InputType.Right:
                    _player.PlayerMovement(key);
                    break;
                case InputType.backwards:
                    _player.PlayerMovement(key);
                    break;
                case InputType.item:
                    _player.Attack();
                    break;
                case InputType.pickup:
                    _player.Pickup();
                    break;
                case InputType.quit:
                    break;
            }
        }
    }
}
