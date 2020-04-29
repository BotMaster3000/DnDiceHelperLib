using System;
using System.Collections.Generic;
using System.Text;

namespace DnDiceHelperLib.Helper
{
    internal static class RandomManager
    {
        private static readonly Random rand = new Random();

        internal static int NextNumber(int maxNumber)
        {
            return rand.Next(1, maxNumber + 1);
        }
    }
}
