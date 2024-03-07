namespace ZeusUnite.Dice
{
    public class DiceRoller
    {
        public int rolledValue;

        public DiceRoller(int min = 1, int maxValue = 6)
        {
            rolledValue = RollDice(min, maxValue);
        }

        public int RollDice(int min, int maxValue)
        {
            int RandomNumber = UnityEngine.Random.Range(min, maxValue + 1);

            return RandomNumber;
        }
    }
}