using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DuelMasterLibrary.GameMechanics
{
    public class DamageDie
    {
        private Random ran;

        public DamageDie(int highroll, int lowroll = 0)
        {
            Highestroll = highroll;
            LowRoll = lowroll;
            ran = new Random();
        }

        public int LowRoll { get; set; }

        [XmlAttribute("Highestroll")]
        public int Highestroll { get; set; }

        /// <summary>
        /// bruges til at rulle skade for creatures
        /// </summary>
        /// <returns>the functions returns a number between the minumum roll and highestroll</returns>
        public int roll()
        {
            return ran.Next(LowRoll,Highestroll);
        }


    }
}
