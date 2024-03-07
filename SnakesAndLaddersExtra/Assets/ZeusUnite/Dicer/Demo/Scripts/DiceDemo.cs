using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ZeusUnite.Dice;

public class DiceDemo : MonoBehaviour
{
    #region Serialized Variables
    [Header("GUI Setup")]
    [SerializeField] TextMeshProUGUI diceEndResult = null;
    [SerializeField] TextMeshProUGUI diceRolledResults = null;

    [SerializeField] Button amountDicePlusButton = null;
    [SerializeField] Button amountDiceMinusButton = null;
    [SerializeField] Button rangeDicePlusButton = null;
    [SerializeField] Button rangeDiceMinusButton = null;

    [SerializeField] TMP_InputField amountDiceField = null;
    [SerializeField] TMP_InputField rangeDiceField = null;

    [SerializeField] TextMeshProUGUI percentageResult = null;
    [SerializeField] TextMeshProUGUI characterResult = null;

    [Space(5)]
    [Header("Latest Results")]
    [SerializeField] Transform lastDiceContent = null;
    [SerializeField] Transform resultPrefab = null;
    #endregion

    #region Public Variables
    #endregion

    #region Local Variables
    List<TextMeshProUGUI> latestResultTexts = new();

    int diceAmount = 1;
    int diceRange = 6;
    #endregion

    void Start()
    {
        amountDicePlusButton.onClick.AddListener(IncreaseDices);
        amountDiceMinusButton.onClick.AddListener(DecreaseDices);
        rangeDicePlusButton.onClick.AddListener(IncreaseDicesRange);
        rangeDiceMinusButton.onClick.AddListener(DecreaseDicesRange);

        amountDiceField.text = diceAmount.ToString();
        rangeDiceField.text = diceRange.ToString();
    }

    #region Public Methods
    public void RollTheDice()
    {
        if(diceAmount == 1)
        {
            DiceRoller dr = new(1, diceRange);
            diceEndResult.text = dr.rolledValue.ToString();
            diceRolledResults.text = "Dices: " + dr.rolledValue.ToString();
            UpdateLatestResults(dr);
            return;
        }

        int calculatedValue = 0;
        string rolledDices = "Dices:\n";

        for (int i = 0; i < diceAmount; i++)
        {
            DiceRoller dr = new(1, diceRange);
            calculatedValue += dr.rolledValue;
            rolledDices += " " + dr.rolledValue.ToString() + " +";
        }

        string normalizedResult = rolledDices.Remove(rolledDices.Length - 2);

        diceEndResult.text = calculatedValue.ToString();
        diceRolledResults.text = normalizedResult;

        DiceRoller allDices = new(1, diceRange);
        allDices.rolledValue = calculatedValue;
        UpdateLatestResults(allDices);
    }

    public void RollPercentage()
    {
        PercentageRoller pr = new(false);
        percentageResult.text = pr.rolledValue.ToString() + " %";
    }

    public void RollCharacter()
    {
        CharRoller cha = new();
        characterResult.text = cha.rolledValue.ToString();
    }

    public void RollQuickNumber(int max)
    {
        DiceRoller dr = new(1, max);
        diceEndResult.text = dr.rolledValue.ToString();
        diceRolledResults.text = "Dices: " + dr.rolledValue.ToString();

        UpdateLatestResults(dr);
    }
    #endregion

    #region Private Methods
    void UpdateLatestResults(DiceRoller dr)
    {
        if (latestResultTexts.Count > 6)
        {
            Destroy(latestResultTexts[0].transform.parent.gameObject);
            latestResultTexts.RemoveAt(0);
        }

        Transform result = Instantiate(resultPrefab, lastDiceContent);
        result.localScale = Vector3.one;

        TextMeshProUGUI resultText = result.Find("Result").GetComponent<TextMeshProUGUI>();
        resultText.text = "Result: " + dr.rolledValue.ToString();

        latestResultTexts.Add(resultText);
    }

    void IncreaseDices()
    {
        diceAmount++;

        amountDiceField.text = diceAmount.ToString();

    }

    void DecreaseDices()
    {
        diceAmount--;

        if (diceAmount < 1)
            diceAmount = 1;

        amountDiceField.text = diceAmount.ToString();
    }

    void IncreaseDicesRange()
    {
        diceRange++;

        if (diceRange > 20)
            diceRange = 20;

        rangeDiceField.text = diceRange.ToString();

    }

    void DecreaseDicesRange()
    {
        diceRange--;

        if (diceRange < 2)
            diceRange = 2;

        rangeDiceField.text = diceRange.ToString();
    }
    #endregion
}
