using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//Checks if a guess is correct and updates states
public class input_states : MonoBehaviour
{
    //public string input_state { get; set; }
    public correct_counter correct;
    public state_change switchstate;
    public state_counter left;
    public InputField input;
    public previous_state previously;

    void Start()
    {
        input = FindObjectOfType<InputField>();
        input.ActivateInputField();
    }

    public void ReadInput(string state)
    {   
        //input_state = state;

        correct = FindObjectOfType<correct_counter>();
        switchstate = FindObjectOfType<state_change>();
        left = FindObjectOfType<state_counter>();
        previously = FindObjectOfType<previous_state>();
        input = FindObjectOfType<InputField>();

        Debug.Log("Input: " + state);
        Debug.Log("current state: " + switchstate);

        Debug.Log("State Name: " + switchstate.state_Array[switchstate.current_State].name); //error here

        if (state == switchstate.state_Array[switchstate.current_State].name)
        {
            correct.correct_done++;   
        }
        previously.last_state = "    " + switchstate.state_Array[switchstate.current_State].name;
        correct.total_done++;            
        left.states_left--;             

        switchstate.current_State++;
 
        input.text = "";
        if (switchstate.current_State < 50)
        {
            input.ActivateInputField();
        }
    }
}
