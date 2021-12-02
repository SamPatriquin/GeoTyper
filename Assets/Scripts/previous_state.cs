using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Displays how many states were guessed correctly 
public class previous_state : MonoBehaviour
{
    public string last_state;
    public Text previous;

    void Update()
    {
        previous.text = last_state;
    }
}