using DuelMasterLibrary.GameMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    public static class InputTranslations
    {
        public static InputType translatekey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    return InputType.Forward;
                case ConsoleKey.A:
                    return InputType.Left;
                case ConsoleKey.D:
                    return InputType.Right;
                case ConsoleKey.S:
                    return InputType.backwards;
                case ConsoleKey.E:          
                    return InputType.item;
                case ConsoleKey.C:
                    return InputType.save;
                case ConsoleKey.Q:
                    return InputType.quit;
                case ConsoleKey.R:
                    return InputType.pickup;
            }
            return InputType.none;
        }
    }
}
