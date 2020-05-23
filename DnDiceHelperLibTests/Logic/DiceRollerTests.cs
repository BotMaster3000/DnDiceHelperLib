using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnDiceHelperLib.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DnDiceHelperLib.Models;
using DnDiceHelperLib.Interfaces;
using System.Linq;

namespace DnDiceHelperLib.Logic.Tests
{
    [TestClass]
    public class DiceRollerTests
    {
        private readonly Random rand = new Random();

        [TestMethod]
        public void RollDiceTest()
        {
            DiceRoller roller = new DiceRoller();
            for (int i = 0; i < 100; ++i)
            {
                List<IDice> dices = new List<IDice>();
                for (int j = 0; j < rand.Next(1000); ++j)
                {
                    int totalDice = rand.Next(100);
                    int sides = rand.Next(500000);
                    dices.AddRange(DiceManager.GetDices(sides, totalDice));
                }
                int result = roller.RollDice(dices.ToArray());

                int minDiceRoll = dices.Count;
                Assert.IsTrue(result >= minDiceRoll);

                int maxDiceRoll = dices.Sum(dice => dice.Sides);
                Assert.IsTrue(result <= maxDiceRoll);
            }
        }

        [TestMethod]
        public void RollDiceTest_NullParameter_ArgumentNullException()
        {
            DiceRoller roller = new DiceRoller();
            Assert.ThrowsException<ArgumentNullException>(() => roller.RollDice(dices: null));
        }

        [TestMethod]
        public void RollDiceTest_ZeroDiceToRoll_ShouldReturnZero()
        {
            DiceRoller roller = new DiceRoller();
            Assert.AreEqual(0, roller.RollDice(new IDice[] { }));
        }

        [TestMethod]
        public void RollDiceSingleTest()
        {
            IDice dice = DiceManager.GetDice(rand.Next());
            DiceRoller roller = new DiceRoller();
            int result = roller.RollDice(dice);
            Assert.IsTrue(result >= 1 && result <= dice.Sides);
        }

        [TestMethod]
        public void RollDiceSingleTest_NullParameter_ArgumentNullException()
        {
            DiceRoller roller = new DiceRoller();
            Assert.ThrowsException<ArgumentNullException>(() => roller.RollDice(dice: null));
        }
    }
}