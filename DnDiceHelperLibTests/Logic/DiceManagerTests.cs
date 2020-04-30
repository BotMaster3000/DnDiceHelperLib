using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnDiceHelperLib.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DnDiceHelperLib.Interfaces;
using System.Linq;
using DnDiceHelperLib.Models;

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
        public void GetDiceTest_GetDiceWithNegativeSides_ArgumentOutOfRangeException()
        {
            int sides = -rand.Next();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DiceManager.GetDice(sides));
        }

        [TestMethod]
        public void GetDiceTest_GetDiceWithZeroSides_ArgumentOutOfRangeException()
        {
            const int Sides = 0;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DiceManager.GetDice(Sides));
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
        public void GetDicesTest_GetTotalOfZeroDice_ShouldReturnZeroDice()
        {
            const int DiceToGenerate = 0;
            int sides = rand.Next();
            IDice[] dices = DiceManager.GetDices(sides, DiceToGenerate);
            Assert.AreEqual(0, dices.Length);
        }

        [TestMethod]
        public void GetDicesTest_GetNegativeNumberOfDice_ArgumentOutOfRangeException()
        {
            int diceToGenerate = -rand.Next();
            int sides = rand.Next();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DiceManager.GetDices(sides, diceToGenerate));
        }

        [TestMethod]
        public void GetDicesTest_ZeroSidesPerDice_ArgumentOutOfRangeException()
        {
            int diceToGenerate = -rand.Next(1000);
            const int Sides = 0;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DiceManager.GetDices(Sides, diceToGenerate));
        }

        [TestMethod]
        public void GetDicesTest_NegativeSidesPerDice_ArgumentOutOfRangeException()
        {
            int diceToGenerate = rand.Next(1000);
            int sides = -rand.Next();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DiceManager.GetDices(sides, diceToGenerate));
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