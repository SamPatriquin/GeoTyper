using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUtility : MonoBehaviour
{
    private int _wordsCompleted, _score;
    private float _wpm;
    private int _correctPresses, _incorrectPresses, _totalPresses;

    private void Start()
    {
        _wordsCompleted = 0;
        _score = 0;
        _wpm = 0f;
        _correctPresses = 0;
        _incorrectPresses = 0;
        _totalPresses = 0;
    }

    // Used to get player's current score
    public int GetScore()
    {
        return _score;
    }

    public float GetWpm()
    {
        return _wpm;
    }

    public float CalculateWPM()
    {
        float elapsedTime = (int) Time.fixedTime;
        if (elapsedTime % 2 == 0)
        {
            float minutesElapsed = Time.fixedTime / 60;
            _wpm = _correctPresses / 5f / minutesElapsed;
        }
        return _wpm;
    }

    public int CalculateScore()
    {
        int difficultyMultiplier = 2; // for medium difficulty, can be changed if additional difficulties are implemented
        _score = (_wordsCompleted * 50) + ((int)Math.Round(_wpm,0)*10) * difficultyMultiplier;
        return _score;
    }

    public void IncrementCorrectPresses()
    {
        _correctPresses++;
        _totalPresses++;
    }

    public void IncrementIncorrectPresses()
    {
        _incorrectPresses++;
        _totalPresses++;
    }

    public void IncrementCompletedWords()
    {
        _wordsCompleted++;
    }
}
