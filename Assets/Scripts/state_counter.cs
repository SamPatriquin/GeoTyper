using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Displays how many states are left
public class state_counter : MonoBehaviour
{
    public int states_left = 50;
    public Text states_left_text;

    void Update()
    {
        states_left_text.text = states_left.ToString().PadLeft(2, '0');
    }
}
