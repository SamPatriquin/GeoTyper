using System;
using UnityEngine;

public class ScoreUtility : MonoBehaviour
{
    private int _wordsCompleted, _score;
    private float _wpm;
    private int _correctPresses;

    private void Start()
    {
        _wordsCompleted = 0;
        _score = 0;
        _wpm = 0f;
        _correctPresses = 0;
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

    public float CalculateWpm(float timeLeft, float timeLimit)
    {
        float elapsedTime = timeLimit - timeLeft;
        if ((int) elapsedTime % 2 == 0)
        {
            float minutesElapsed = elapsedTime / 60;
            _wpm = _correctPresses / 5f / minutesElapsed;
        }
        return _wpm;
    }

    public int CalculateScore()
    { 
        const int difficultyMultiplier = 2; // for medium difficulty, can be changed if more difficulties are added
        _score = (_wordsCompleted * 50) + ((int)Math.Round(_wpm,0)*10) * difficultyMultiplier;
        return _score;
    }

    public void IncrementCorrectPresses()
    {
        _correctPresses++;
    }

    public void IncrementCompletedWords()
    {
        _wordsCompleted++;
    }
}
