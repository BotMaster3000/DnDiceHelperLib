A simple Library for rolling Dices.
You just have to determine the amount of sides your Dice should have and optionally how many of them you want.
You can then even roll the dice to determine the results.

<h2>Generating Dice</h2>
The library features multiple ways to generate Dice, all of which are in the DnDiceHelperLib.Logic.DiceManager.cs

GetDice(int)<br/>
=> Returns a single Dice with the amount of Sides provided, producing numbers from 1 to the number of sides
  
GetDices(int, int)<br/>
=> Returns as many Dice with the same number of sides as provided as the second parameter.
  
GetDices(IEnumerable<KeyValuePair<int, int>>)<br/>
=> Generates multiple sets of different-sided dice. Example:

    IDictionary<int, int> sideCountAndTotalDice = new Dictionary<int, int>()
    {
        { 15, 10 },
        { 7, 8 }
    }
    IDice[] dices = DiceManager.GetDices(sideCountAndTotalDice);
    // The dices-Array now contains 10 dice with 15 sides and 8 dice with 7 sides.

<h2>Rolling Dice</h2>
To roll the dice, simply pass a Dice-Array to the DnDiceHelperLib.Logic.DiceRoller.RollDice(IDice[])-Method 
and it returns an integer with the result. Example:

    IDice[] dices = DiceManager.GetDices(12, 10);
    DiceRoller roller = new DiceRoller();
    int result = roller.RollDice(dices);
    // Returns a number between 10 and 120


