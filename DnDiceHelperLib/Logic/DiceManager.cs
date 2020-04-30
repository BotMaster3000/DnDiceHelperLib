using DnDiceHelperLib.Interfaces;
using DnDiceHelperLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DnDiceHelperLib.Helper;

namespace DnDiceHelperLib.Logic
{
    public static class DiceManager
    {
        private static readonly IDictionary<int, IDice> diceDictionary = new Dictionary<int, IDice>();

        public static IDice GetDice(int sides)
        {
            ExceptionManager.ThrowArgumentOutOfRangeExceptionIfParameterNegativeOrZero(nameof(sides), sides);
            if (!diceDictionary.ContainsKey(sides))
            {
                diceDictionary.Add(sides, new Dice(sides));
            }
            return diceDictionary[sides];
        }

        public static IDice[] GetDices(int sides, int totalDice)
        {
            ExceptionManager.ThrowArgumentOutOfRangeExceptionIfParameterNegativeOrZero(nameof(totalDice), totalDice, true);
            IDice[] dices = new IDice[totalDice];
            IDice dice = GetDice(sides);
            for (int i = 0; i < totalDice; ++i)
            {
                dices[i] = dice;
            }
            return dices;
        }

        public static IDice[] GetDices(IEnumerable<KeyValuePair<int, int>> sideCountAndTotalDice)
        {
            List<IDice> diceCollection = new List<IDice>();
            foreach (KeyValuePair<int, int> sideCountsAndDices in sideCountAndTotalDice)
            {
                diceCollection
                    .AddRange(
                        GetDices(sideCountsAndDices.Key, sideCountsAndDices.Value));
            }
            return diceCollection.ToArray();
        }
    }
}
