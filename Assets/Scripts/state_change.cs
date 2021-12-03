using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

//updates and displays State image
public class state_change : MonoBehaviour
{
    public int current_State = 0;
    public SpriteRenderer sprites;
    public Sprite[] state_Array;
    public correct_counter final_correct;
    public clock_script final_time;
    public Sprite end_sprite;
    private ScoreTracker scoreTracker;

    private void Awake() {
        scoreTracker = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>();
    }

    void Update()
    {
        sprites = GetComponent<SpriteRenderer>();

        if (current_State < 50)
        {
            sprites.sprite = state_Array[current_State];
        }
        else
        {
            final_correct = FindObjectOfType<correct_counter>();
            final_time = FindObjectOfType<clock_script>();
            sprites.sprite = end_sprite;
            scoreTracker.updateGeoScore(final_correct.correct_done);
            SceneManager.LoadScene(0);

        }
    }
}
