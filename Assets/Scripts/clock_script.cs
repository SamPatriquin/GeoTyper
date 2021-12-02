using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//Displays in game clock
public class clock_script : MonoBehaviour
{
    private Text timecount;
    public float hour;
    public float minutes;
    public float seconds;
    public int int_sec;
    public state_change states_finished;


    void Start()
    {
        timecount = GetComponent<Text>();
    }

    void Update()
    {
        states_finished = FindObjectOfType<state_change>();

        if (states_finished.current_State < 50)
        {
            seconds += Time.deltaTime;
            if (seconds >= 60)
            {
                minutes++;
                seconds = 0;
            }
            if (minutes >= 60)
            {
                hour++;
                minutes = 0;
            }
            int_sec = (int)seconds;

            timecount.text = hour.ToString().PadLeft(2, '0') + ":" + minutes.ToString().PadLeft(2, '0') + ":" + int_sec.ToString().PadLeft(2, '0');
        }

    }
}