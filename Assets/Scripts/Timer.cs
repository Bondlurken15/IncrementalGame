using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    float elapsedTime;
    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        
       int minutes= Mathf.FloorToInt(elapsedTime / 60);

        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        TimerText.text = minutes.ToString();
        TimerText.text = seconds.ToString();
    }
}
