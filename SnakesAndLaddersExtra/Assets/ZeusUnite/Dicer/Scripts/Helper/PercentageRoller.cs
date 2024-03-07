using System;

namespace ZeusUnite.Dice
{
    public class PercentageRoller
    {
        public float rolledValue;

        public PercentageRoller(bool floatingNumber = false)
        {
            if (floatingNumber)
            {
                rolledValue = RollFloatPercentage();
                return;
            }

            rolledValue = RollPercentage();
        }

        public int RollPercentage()
        {
            int RandomNumber = UnityEngine.Random.Range(0, 101);

            return RandomNumber;
        }

        public float RollFloatPercentage()
        {
            float RandomNumber = UnityEngine.Random.Range((float)0, (float)100);
            decimal floatPlace = Decimal.Round((decimal)RandomNumber, 2);

            return (float)floatPlace;
        }
    }
}