using UnityEngine;

namespace ZeusUnite.Dice
{
    public class CharRoller
    {
        public char rolledValue;

        char[] charactersToRoll = new char[]
        {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        public CharRoller()
        {
            rolledValue = ReturnRandomChar();
        }

        char ReturnRandomChar()
        {
            return charactersToRoll[Random.Range(0, charactersToRoll.Length)];
        }
    }
}
