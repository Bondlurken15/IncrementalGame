using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting.ReorderableList;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] float autoClickDuration;
    [SerializeField] float elapsedTime;

    bool autoClickerIsActive = false;
    Clicker clicker;

    private void Update()
    {
        if (autoClickerIsActive)
        {
            FrenzyTimer();
        }
    }

    private void Start()
    {
        clicker = FindObjectOfType<Clicker>();

        elapsedTime = autoClickDuration;
    }

    public void FrenzyTimer()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime <= 0)
        {
            ToggleAutoClicker();
            clicker.ToggleAutoClick();
            elapsedTime = autoClickDuration;
        }

        int minutes = Mathf.FloorToInt(elapsedTime / 60);

        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        TimerText.text = minutes.ToString();
        TimerText.text = seconds.ToString();
    }

    public void ToggleAutoClicker()
    {
        autoClickerIsActive = !autoClickerIsActive;
    }
}
