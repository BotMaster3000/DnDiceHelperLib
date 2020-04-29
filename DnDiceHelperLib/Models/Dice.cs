using DnDiceHelperLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDiceHelperLib.Models
{
    public class Dice : IDice
    {
        public int Sides { get; }

        internal Dice(int sides)
        {
            Sides = sides;
        }
    }
}
