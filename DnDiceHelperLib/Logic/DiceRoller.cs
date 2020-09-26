using DnDiceHelperLib.Helper;
using DnDiceHelperLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnDiceHelperLib.Logic
{
    public class DiceRoller : IDiceRoller
    {
        public int RollDice(IDice dice)
        {
            ExceptionManager.ThrowArgumentNullExceptionIfParameterNull(nameof(dice), dice);
            return RandomManager.NextNumber(dice.Sides);
        }

        public int RollDice(IDice[] dices)
        {
            ExceptionManager.ThrowArgumentNullExceptionIfParameterNull(nameof(dices), dices);
            int result = 0;
            for (int i = 0; i < dices.Length; ++i)
            {
                result += RandomManager.NextNumber(dices[i].Sides);
            }
            return result;
        }
    }
}
