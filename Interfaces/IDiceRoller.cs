using System;
using System.Collections.Generic;
using System.Text;

namespace DnDiceHelperLib.Interfaces
{
    internal interface IDiceRoller
    {
        int RollDice(IDice[] dices);
    }
}
