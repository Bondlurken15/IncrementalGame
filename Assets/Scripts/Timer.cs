using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting.ReorderableList;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] float autoClickDuration;
    [SerializeField] float elapsedTime;

    bool autoClickerIsActive = false;
    Shop shop;

    private void Update()
    {
        if (autoClickerIsActive)
        {
            FrenzyTimer();
        }
    }

    private void Start()
    {
        shop = FindObjectOfType<Shop>();

        elapsedTime = autoClickDuration;
    }

    public void FrenzyTimer()
    {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0)
        {
            shop.TurnOffAutoClicker();
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
