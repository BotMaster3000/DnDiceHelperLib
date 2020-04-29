using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnDiceHelperLib.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DnDiceHelperLib.Interfaces;
using System.Linq;

namespace DnDiceHelperLib.Logic.Tests
{
    [TestClass]
    public class DiceManagerTests
    {
        private Random rand = new Random();

        [TestMethod]
        public void GetDiceTest_GetRandomDice()
        {
            for (int i = 0; i < 1000; ++i)
            {
                int sides = rand.Next();
                IDice dice = DiceManager.GetDice(sides);
                Assert.AreEqual(sides, dice.Sides);
            }
        }

        [TestMethod]
        public void GetDicesTest_GetMultipleDiceWithSameSide()
        {
            for (int i = 0; i < 100; ++i)
            {
                int diceToGenerate = rand.Next(100);
                int sides = rand.Next();
                IDice[] dices = DiceManager.GetDices(sides, diceToGenerate);
                Assert.AreEqual(diceToGenerate, dices.Length);
                foreach (IDice dice in dices)
                {
                    Assert.AreEqual(sides, dice.Sides);
                }
            }
        }

        [TestMethod]
        public void GetDicesTest_GetMultipleDiceWithMultipleSides()
        {
            IDictionary<int, int> sideCountAndTotalDice = new Dictionary<int, int>()
            {
                { 20, 51 },
                { 21, 354 },
                { 7638, 384 },
                { 438, 534 },
                { 43, 3547 },
                { 7988, 67863 },
                { 34, 843 },
                { 7, 385 },
            };
            IDice[] dices = DiceManager.GetDices(sideCountAndTotalDice);
            foreach (KeyValuePair<int, int> sidesAndDice in sideCountAndTotalDice)
            {
                int dicesWithSameSideCount = dices.Count(dice
                    => dice.Sides == sidesAndDice.Key);
                Assert.AreEqual(sidesAndDice.Value, dicesWithSameSideCount);
            }
        }
    }
}