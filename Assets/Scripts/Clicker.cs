using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    [SerializeField] bool isAutoClick;
    [SerializeField] float autoClickInterval = 1.0f;
    [SerializeField] int autoClickAmount = 1;
    int clickCounter = 0;
    [SerializeField] TextMeshProUGUI clickCounterText;

    private bool autoClickRunning;

    private void Start()
    {
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
    }

    public void OnClick()
    {
        clickCounter++;
        clickCounterText.text = clickCounter.ToString();
    }

    void AutoClick()
    {
        clickCounter += autoClickAmount;
        clickCounterText.text = clickCounter.ToString();
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