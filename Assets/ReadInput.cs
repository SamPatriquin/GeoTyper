using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;


public class ReadInput : MonoBehaviour
{
    private string input;
    private InputField inF;
    [SerializeField] private Text defText;
    [SerializeField] private Text hint1Text;
    [SerializeField] private Text hint2Text;
    [SerializeField] private Text hint3Text;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text timerText;
    [SerializeField] private Word[] words;

    //private Dictionary<string, string> dict;
    private string[] hintArr = new string[3];
    private int score = 0;
        
    void Awake() //Randomize words
    {
        inF = GetComponentInChildren<InputField>();
        if (inF == null)
            Debug.Log("error: no inputfield");
        //Put first word def in defText

        int rand = Random.Range(0, 20);

        defText.text = words[rand].def;
        Debug.Log("should be displaying: " + words[rand].def + "\nWith answer: " + words[rand].word);

        //generate first hints
        // generate new hints;
        int orderRand;
        int hintRand;
        string hint1 = words[rand].word;

        do
        {
            hintRand = Random.Range(0, 20);
        }
        while (hint1 == words[hintRand].word);

        string hint2 = words[hintRand].word;

        do
        {
            hintRand = Random.Range(0, 20);
        }
        while (hint1 == words[hintRand].word || hint2 == words[hintRand].word);

        string hint3 = words[hintRand].word;
        orderRand = Random.Range(0, 3);

        if (orderRand == 0)
        {
            hintArr[0] = hint1;
            hintArr[1] = hint2;
            hintArr[2] = hint3;
        }
        if (orderRand == 1)
        {
            hintArr[0] = hint3;
            hintArr[1] = hint1;
            hintArr[2] = hint2;
        }
        if (orderRand == 2)
        {
            hintArr[0] = hint2;
            hintArr[1] = hint3;
            hintArr[2] = hint1;
        }
        //don't show hints
        hint1Text.text = "";
        hint2Text.text = "";
        hint3Text.text = "";
    }

    private void Update()
    {
        //timer update
        if (Time.realtimeSinceStartup > 120.0)
        {
            timerText.text = "Time left: 0 seconds";
            defText.text = "GAME OVER\nScore: " + score;
        }
        else
            timerText.text = "Time left: " + (120.0 - Time.realtimeSinceStartup).ToString("N0") + " seconds";
    }

    // Update is called once per frame
    public void checkAnswer()
    {
        Debug.Log("CheckAnswer");

        if (Time.realtimeSinceStartup > 120.0)
            return;

            if (inF.text != "")
            score -= 10; //wrong answer penalty


        //check for match

        foreach (Word i in words)
        {
            if (i.word == inF.text && i.def == defText.text)
            {
                Debug.Log("We got a match");
                score += 110; // 100 for right answer 10 for offset of initial wrong
                

                int newRand;
                int hintRand;
                int orderRand;

                do
                {
                    newRand = Random.Range(0, 20);
                }
                while (inF.text == words[newRand].word);

                defText.text = words[newRand].def;
                inF.text = "";


                // generate new hints;
                string hint1 = words[newRand].word;

                do
                {
                    hintRand = Random.Range(0, 20);
                }
                while (inF.text == words[hintRand].word || hint1 == words[hintRand].word);

                string hint2 = words[hintRand].word;

                do
                {
                    hintRand = Random.Range(0, 20);
                }
                while (inF.text == words[hintRand].word || hint1 == words[hintRand].word || hint2 == words[hintRand].word);

                string hint3 = words[hintRand].word;
                orderRand = Random.Range(0, 3);

                if (orderRand == 0)
                {
                    hintArr[0] = hint1;
                    hintArr[1] = hint2;
                    hintArr[2] = hint3;
                }
                if (orderRand == 1)
                {
                    hintArr[0] = hint3;
                    hintArr[1] = hint1;
                    hintArr[2] = hint2;
                }
                if (orderRand == 2)
                {
                    hintArr[0] = hint2;
                    hintArr[1] = hint3;
                    hintArr[2] = hint1;
                }

                //disable hints 
                hint1Text.text = "";
                hint2Text.text = "";
                hint3Text.text = "";
            }
        }

        //update score accordingly

        currentScore.text = "Score: " + score;
    }

    public void ShowHints()
    {

        if (Time.realtimeSinceStartup > 120.0)
            return;

            Debug.Log("ShowHints()");
        hint1Text.text = hintArr[0];
        hint2Text.text = hintArr[1];
        hint3Text.text = hintArr[2];

        score -= 20;
        currentScore.text = "Score: " + score;
    }

}
