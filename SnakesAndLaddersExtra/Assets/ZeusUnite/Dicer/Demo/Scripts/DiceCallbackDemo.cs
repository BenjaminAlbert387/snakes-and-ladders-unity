using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ZeusUnite.Dice;

public class DiceCallbackDemo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultText = null;

    public void StartDiceRoll(int range)
    {
        Dicer.Instance.OpenDicePanel(callback => SetResult(callback), range);
    }

    public void StartPercentageRoll()
    {
        Dicer.Instance.OpenPercentagePanel(callback => SetResult(callback));
    }

    public void StartAlphabeticRoll()
    {
        Dicer.Instance.OpenAlphabeticPanel(callback => SetResult(callback));
    }


    public void SetResult(DiceRoller dice)
    {
        resultText.text = dice.rolledValue.ToString();
    }

    public void SetResult(PercentageRoller dice)
    {
        resultText.text = dice.rolledValue.ToString() + " %";
    }
    public void SetResult(CharRoller dice)
    {
        resultText.text = dice.rolledValue.ToString();
    }
}
