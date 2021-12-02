using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Displays how many states were guessed correctly 
public class correct_counter : MonoBehaviour
{
    public int correct_done = 0;
    public int total_done = 0;
    public Text correct_count;

    void Update()
    {
      correct_count.text = correct_done.ToString().PadLeft(2, '0') + "/" + total_done.ToString().PadLeft(2, '0');
    }
}
