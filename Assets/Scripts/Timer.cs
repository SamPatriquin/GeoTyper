//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   private float _timeLeft, _milliseconds, _seconds, _minutes;
   private const float TimeLimit = 90.00f;
   public void Start()
   {
      _timeLeft = TimeLimit;
   }

   public bool UpdateTimer(Text timerDisplay)
   {
      if (_timeLeft > 0)
      {
         _timeLeft -= Time.deltaTime;
         _milliseconds = (int)((_timeLeft - (int)_timeLeft) * 100);
         _seconds = (int)(_timeLeft % 60);
         _minutes = (int)(_timeLeft / 60 % 60);
         timerDisplay.text = $"Timer: {_minutes:00}:{_seconds:00}:{_milliseconds:00}";
         return true;
      }
      return false;
   } 
}
