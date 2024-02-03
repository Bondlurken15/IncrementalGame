using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] float elapsedTime;

    public void FrenzyTimer()
    {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0)
        {
            elapsedTime = 0;
        }

        int minutes = Mathf.FloorToInt(elapsedTime / 60);

        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        TimerText.text = minutes.ToString();
        TimerText.text = seconds.ToString();
    }

}
