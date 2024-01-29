using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class Clicker : MonoBehaviour
{
    [SerializeField] bool isAutoClick;
    [SerializeField] float autoClickInterval = 1.0f;
    [SerializeField] float mixTimer = 10f;
    [SerializeField] int autoClickAmount = 1;
    [SerializeField] int baseOCash;
    [SerializeField] TextMeshProUGUI oboyClickCounterText;
    [SerializeField] TextMeshProUGUI milkClickCounterText;
    [SerializeField] TextMeshProUGUI currentMixTimerText;

    private bool autoClickRunning;
    int oboyClickCounter = 0;
    int milkClickCounter = 0;
    float currentMixTimer;

    Shop shop;

    private void Start()
    {
        shop = FindObjectOfType<Shop>();
        
        currentMixTimer = mixTimer;
        
        autoClickRunning = isAutoClick;
        if (isAutoClick)
        {
            StartCoroutine(AutoClickCoroutine());
        }
    }

    private void Update()
    {
        // Check if the state of isAutoClick has changed
        if (isAutoClick != autoClickRunning)
        {
            autoClickRunning = isAutoClick;

            if (autoClickRunning)
            {
                StartCoroutine(AutoClickCoroutine());
            }
            else
            {
                StopCoroutine(AutoClickCoroutine());
            }
        }
        
        currentMixTimer -= Time.deltaTime;
        int seconds = Mathf.FloorToInt(currentMixTimer % 60);
        currentMixTimerText.text = seconds.ToString();
        
        if (currentMixTimer <= 0)
        {
            if (milkClickCounter >= oboyClickCounter)
            {
                float oboyClicks = oboyClickCounter;
                float milkClicks = milkClickCounter;
                float oCashToAdd = (oboyClicks / milkClicks) * baseOCash * oboyClicks;
                shop.AddOCash(oCashToAdd);
            }
            else if (milkClickCounter < oboyClickCounter)
            {
                float oboyClicks = oboyClickCounter;
                float milkClicks = milkClickCounter;
                float oCashToAdd = (milkClicks / oboyClicks) * baseOCash * milkClicks;
                shop.AddOCash(oCashToAdd);
            }

            oboyClickCounter = 0;
            milkClickCounter = 0;
            oboyClickCounterText.text = oboyClickCounter.ToString();
            milkClickCounterText.text = milkClickCounter.ToString();
            currentMixTimer = mixTimer;
        }
    }

    public void OnOboyClick()
    {
        oboyClickCounter++;
        oboyClickCounterText.text = oboyClickCounter.ToString();
    }

    public void OnMilkClick()
    {
        milkClickCounter++;
        milkClickCounterText.text = milkClickCounter.ToString();
    }

    void AutoClick()
    {
        oboyClickCounter += autoClickAmount;
        oboyClickCounterText.text = oboyClickCounter.ToString();
        milkClickCounter += autoClickAmount;
        milkClickCounterText.text = milkClickCounter.ToString();
    }

    public void ToggleAutoClick()
    {
        isAutoClick = !isAutoClick; // Toggle the value
    }

    IEnumerator AutoClickCoroutine()
    {
        while (autoClickRunning)
        {
            yield return new WaitForSeconds(autoClickInterval);
            AutoClick();
        }
    }
}