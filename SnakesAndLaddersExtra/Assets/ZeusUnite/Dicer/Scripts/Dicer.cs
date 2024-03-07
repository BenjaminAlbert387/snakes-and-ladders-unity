using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace ZeusUnite.Dice
{
    public class Dicer : MonoBehaviour
    {
        public static Dicer Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<Dicer>();

                if (instance == null)
                {
                    Dicer d = Resources.Load<Dicer>("Dicer/DiceGenerator");
                    Dicer go = Instantiate(d);
                    instance = go;
                }

                return instance;
            }
        }

        static Dicer instance;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        [SerializeField] Transform DicePanel = null;
        [SerializeField] TextMeshProUGUI randomNumberText = null;

        DiceRoller lastRolledDice;
        PercentageRoller lastRolledPercentage;
        CharRoller lastRolledCharacter;

        public DiceRoller LastRolledDice { get => lastRolledDice; set => lastRolledDice = value; }
        public PercentageRoller LastRolledPercentage { get => lastRolledPercentage; set => lastRolledPercentage = value; }
        public CharRoller LastRolledCharacter { get => lastRolledCharacter; set => lastRolledCharacter = value; }

        bool isRolling;
        Animator anim = null;

        public void OpenDicePanel(Action<DiceRoller> callback, int range)
        {
            if (isRolling)
                return;

            isRolling = true;

            DicePanel.gameObject.SetActive(true);
            anim.SetBool("Open", true);

            StartCoroutine(RotateDice(callback, range));
        }

        public void OpenPercentagePanel(Action<PercentageRoller> callback)
        {
            if (isRolling)
                return;

            isRolling = true;

            DicePanel.gameObject.SetActive(true);
            anim.SetBool("Open", true);

            StartCoroutine(RotatePercentage(callback));
        }

        public void OpenAlphabeticPanel(Action<CharRoller> callback)
        {
            if (isRolling)
                return;

            isRolling = true;

            DicePanel.gameObject.SetActive(true);
            anim.SetBool("Open", true);

            StartCoroutine(RotateCharacter(callback));
        }

        IEnumerator RotateDice(Action<DiceRoller> callback, int range)
        {
            yield return null;
            WaitForSeconds wfs = new WaitForSeconds(Time.deltaTime);

            float rotateTime = 2f;
            float nextTime = 0f;

            while (rotateTime > 0)
            {
                rotateTime -= Time.deltaTime;
                nextTime += Time.deltaTime;

                if (nextTime > .05f)
                {
                    LastRolledDice = new DiceRoller(1, range);
                    randomNumberText.text = LastRolledDice.rolledValue.ToString();
                    nextTime = 0f;
                }

                yield return wfs;
            }

            callback(LastRolledDice);

            isRolling = false;
            yield return new WaitForSeconds(2f);
            anim.SetBool("Open", false);
        }

        IEnumerator RotatePercentage(Action<PercentageRoller> callback)
        {
            yield return null;
            WaitForSeconds wfs = new WaitForSeconds(Time.deltaTime);

            float rotateTime = 2f;
            float nextTime = 0f;

            while (rotateTime > 0)
            {
                rotateTime -= Time.deltaTime;
                nextTime += Time.deltaTime;

                if (nextTime > .05f)
                {
                    LastRolledPercentage = new PercentageRoller();
                    randomNumberText.text = LastRolledPercentage.rolledValue.ToString();
                    nextTime = 0f;
                }

                yield return wfs;
            }

            callback(LastRolledPercentage);

            isRolling = false;
            yield return new WaitForSeconds(2f);
            anim.SetBool("Open", false);
        }

        IEnumerator RotateCharacter(Action<CharRoller> callback)
        {
            yield return null;
            WaitForSeconds wfs = new WaitForSeconds(Time.deltaTime);

            float rotateTime = 2f;
            float nextTime = 0f;

            while (rotateTime > 0)
            {
                rotateTime -= Time.deltaTime;
                nextTime += Time.deltaTime;

                if (nextTime > .05f)
                {
                    lastRolledCharacter = new CharRoller();
                    randomNumberText.text = lastRolledCharacter.rolledValue.ToString();
                    nextTime = 0f;
                }

                yield return wfs;
            }

            callback(lastRolledCharacter);

            isRolling = false;
            yield return new WaitForSeconds(2f);
            anim.SetBool("Open", false);
        }
    }
}