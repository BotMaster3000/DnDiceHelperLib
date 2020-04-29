using DnDiceHelperLib.Helper;
using DnDiceHelperLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDiceHelperLib.Logic
{
    public class DiceRoller : IDiceRoller
    {
        public int RollDice(IDice[] dices)
        {
            int result = 0;
            for(int i = 0; i < dices.Length; ++i)
            {
                result += RandomManager.NextNumber(dices[i].Sides);
            }
            return result;
        }
    }
}
