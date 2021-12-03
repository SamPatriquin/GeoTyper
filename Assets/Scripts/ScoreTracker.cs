using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {
    static ScoreTracker instance;

    [SerializeField] int  bestTyperScore = 0;
    [SerializeField] float bestWpm = 0;

    [SerializeField] int bestStateScore = 0;

    [SerializeField] int bestVocabScore = 0;

    private void Awake() {
        if (instance != null) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void updateTyperScore(int score, float wpm) {
        if (score > bestTyperScore && wpm > bestWpm) {
            bestTyperScore = score;
            bestWpm = wpm;
            Debug.Log(bestTyperScore);
            Debug.Log(bestWpm);
        }
    }

    public void updateGeoScore(int score) {
        if (score > bestStateScore) {
            bestStateScore = score;
        }
    }

    public void updateVocabScore(int score) {
        if (score > bestVocabScore) {
            bestVocabScore = score;
        }
    }

    public int getBestTyperScore() { return bestTyperScore; }
    public float getBestWPM() { return bestWpm; }
    public int getBestStateScore() { return bestStateScore; }
    public int getBestVocabScore() { return bestVocabScore; }

}   
