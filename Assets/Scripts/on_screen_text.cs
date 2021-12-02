using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Displays static on screen text
public class on_screen_text : MonoBehaviour
{
    public string textValue;
    public Text textElement;

    void Update()
    {
        textElement.text = textValue;
    }
}