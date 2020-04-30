using System;
using System.Collections.Generic;
using System.Text;

namespace DnDiceHelperLib.Helper
{
    internal static class ExceptionManager
    {
        internal static void ThrowArgumentOutOfRangeExceptionIfParameterNegativeOrZero(string parameterName, int parameter, bool allowZeroValue = false)
        {
            if ((allowZeroValue && parameter < 0)
                || (!allowZeroValue && parameter <= 0))
            {
                throw new ArgumentOutOfRangeException($"Parameter out of range: {parameterName}={parameter}");
            }
        }
    }
}
