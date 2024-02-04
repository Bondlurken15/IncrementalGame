using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    float oCash = 0;
    Clicker clicker;

    [SerializeField] float oCashForOboyClickAmountUpgrade;
    [SerializeField] float oCashForMilkClickAmountUpgrade;
    [SerializeField] float oCashForBaseOCashUpgrade;
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
        if (oCash >= oCashForOboyClickAmountUpgrade)
        {
            oCash -= oCashForOboyClickAmountUpgrade;
            oCashText.text = oCash.ToString();
            clicker.UpgradeOboyClickAmount();
        }
    }

    public void BuyMilkClickAmountUpgrade()
    {
        if (oCash >= oCashForMilkClickAmountUpgrade)
        {
            oCash -= oCashForMilkClickAmountUpgrade;
            oCashText.text = oCash.ToString();
            clicker.UpgradeMilkClickAmount();
        }
    }

    public void BuyBaseOCashUpgrade()
    {
        if (oCash >= oCashForBaseOCashUpgrade)
        {
            oCash -= oCashForBaseOCashUpgrade;
            oCashText.text = oCash.ToString();
            clicker.UpgradeBaseOCash();
            oCashForBaseOCashUpgrade *= 2;
        }
    }
}
