using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    float oCash = 0;
    Clicker clicker;

    [SerializeField] float cashForOboyClickAmountUpgrade;
    [SerializeField] TextMeshProUGUI oCashText;
    
    void Start()
    {
        clicker = FindObjectOfType<Clicker>();
    }

    void Update()
    {
        
    }

    public void AddOCash(float cashToAdd)
    {
        oCash += cashToAdd;
        oCashText.text = oCash.ToString();
    }

    public void BuyOboyClickAmountUpgrade()
    {
        if (oCash >= cashForOboyClickAmountUpgrade)
        {
            oCash -= cashForOboyClickAmountUpgrade;
            oCashText.text = oCash.ToString();
            clicker.UpgradeOboyClickAmount();
        }
    }
}
