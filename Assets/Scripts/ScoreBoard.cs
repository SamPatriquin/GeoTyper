using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] ScoreTracker scoreTracker;
    [SerializeField] TextMeshProUGUI correctStates;
    [SerializeField] TextMeshProUGUI vocabScore;
    [SerializeField] TextMeshProUGUI typingScore;
    [SerializeField] TextMeshProUGUI WPM;

    private void Awake() {
        scoreTracker = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>();
    }

    void Update()
    {
        correctStates.text = scoreTracker.getBestStateScore().ToString();
        vocabScore.text = scoreTracker.getBestVocabScore().ToString();
        typingScore.text = scoreTracker.getBestTyperScore().ToString();
        WPM.text = scoreTracker.getBestWPM().ToString();
    }
}
