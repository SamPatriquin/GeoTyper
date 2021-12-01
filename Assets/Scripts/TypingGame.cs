using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This file can be considered as the typing mini-game's main file

public class TypingGame : MonoBehaviour
{
    public Dictionary dictionary;
    public Timer timer;
    public ScoreUtility scoreUtil;
    public Text wordDisplay;
    public Text scoreDisplay;
    public Text wpmDisplay;
    public Text timerDisplay;
    public GameOverScreen screen;
    private string _currentWord = String.Empty;
    private string _remainingWord = String.Empty;
    private const string ScorePrefix = "Score: ";
    private const string WpmPrefix = "WPM: ";


    // Start is called before the first frame update
    void Start()
    {
        // get initial word
        SetCurrentWord();
        // initialize on-screen text
        scoreDisplay.text = ScorePrefix + scoreUtil.GetScore();
        wpmDisplay.text = WpmPrefix + scoreUtil.GetWpm();
        // initialize time scale
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       // check timer in case time runs out
       CheckTimer();
       // workaround for preventing input while game is paused
       if (Time.timeScale > 0)
       {
           // check which key the user pressed and update accordingly
            CheckUserInput();
            // update score and wpm
            UpdateScoreAndWpm();
           
       }
    }

    private void SetCurrentWord()
    {
        _currentWord = dictionary.GETNewWord();
        SetRemainingWord(_currentWord);
    }

    private void SetRemainingWord(string word)
    {
        _remainingWord = word;
        wordDisplay.text = _remainingWord;
        // check if _remainingWord has any letters left in it
        if (!string.IsNullOrEmpty(_remainingWord))
        {
            // if so, make first letter blue to signify which key to press
            string firstCharacter = _remainingWord.Substring(0, 1);
            string rest = _remainingWord.Substring(1);
            wordDisplay.text = $"<color=#2F637A>{firstCharacter}</color>{rest}"; // use rich text to pull this off
        }
    }
    
    private void CheckTimer()
    {
        if (!timer.UpdateTimer(timerDisplay))
        {
            // temporary workaround; remove when game over screen is implemented
            // Debug.Log("Time's up!! Game over!!");
            // Application.Quit();
            if (!screen.IsActive())
                screen.Activate(scoreUtil.GetScore(), scoreUtil.GetWpm());
        }
    }

    private void CheckUserInput()
    {
        if (Input.anyKeyDown)
        {
            string pressedKeys = Input.inputString;
            if (pressedKeys.Length == 1)
            {
                LetterHandler(pressedKeys);
            }
            else if (pressedKeys.Length > 1)
            {
                // make necessary score adjustments
                LetterHandler(pressedKeys[0].ToString());
            }
        }
    }

    private void LetterHandler(string enteredLetter)
    {
        if (IsCorrectLetter(enteredLetter))
        {
            // remove letter from remaining word
            RemoveLetter();
            // make necessary adjustments
            scoreUtil.IncrementCorrectPresses();
            // get new word if word is completed
            if (_remainingWord.Length == 0)
            {
                scoreUtil.IncrementCompletedWords();
                SetCurrentWord();
            }
        }
        else
        {
            // make necessary adjustments
            scoreUtil.IncrementIncorrectPresses();
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return _remainingWord.IndexOf(letter, StringComparison.Ordinal) == 0;
    }

    private void RemoveLetter()
    {
        string newString = _remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
        
    }

    private void UpdateScoreAndWpm()
    {
        float limit = timer.GetTimeLimit();
        float timeLeft = timer.GetTimeLeft();
        wpmDisplay.text = $"{WpmPrefix}{scoreUtil.CalculateWPM(timeLeft, limit).ToString("F1")}";
        scoreDisplay.text = $"{ScorePrefix}{scoreUtil.CalculateScore()}";
    }
}