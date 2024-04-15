using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMasterLibrary.GameMechanics
{
    public class DamageController
    {
        public int Value { get; }

        /// <summary>
        /// Sørger for at man ikke kan give negativ skade
        /// </summary>
        /// <param name="value">value bliver indsat i konstruktoren og sættter værdi til 0 hvis værdien er et negativ nummer</param>
        public DamageController(int value)
        {
            if (value < 0)
                Value = 0;
            else
                Value = value;
        }
    }
}
