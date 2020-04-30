using DnDiceHelperLib.Interfaces;
using DnDiceHelperLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DnDiceHelperLib.Logic
{
    public static class DiceManager
    {
        private static readonly IDictionary<int, IDice> diceDictionary = new Dictionary<int, IDice>();

        public static IDice GetDice(int sides)
        {
            ThrowArgumentOutOfRangeExceptionIfParameterNegativeOrZero(nameof(sides), sides);
            if (!diceDictionary.ContainsKey(sides))
            {
                diceDictionary.Add(sides, new Dice(sides));
            }
            return diceDictionary[sides];
        }

        private static void ThrowArgumentOutOfRangeExceptionIfParameterNegativeOrZero(string parameterName, int parameter, bool allowZeroValue = false)
        {
            if ((allowZeroValue && parameter < 0)
                || (!allowZeroValue && parameter <= 0))
            {
                throw new ArgumentOutOfRangeException($"Parameter out of range: {parameterName}={parameter}");
            }
        }

        public static IDice[] GetDices(int sides, int totalDice)
        {
            ThrowArgumentOutOfRangeExceptionIfParameterNegativeOrZero(nameof(totalDice), totalDice, true);
            IDice[] dices = new IDice[totalDice];
            for (int i = 0; i < totalDice; ++i)
            {
                dices[i] = GetDice(sides);
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
