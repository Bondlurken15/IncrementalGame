using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    int clickCounter = 0;
    [SerializeField] TextMeshProUGUI clickCounterText;
    
    public void OnClick()
    {
        clickCounter++;
        clickCounterText.text = clickCounter.ToString();
    }
}
