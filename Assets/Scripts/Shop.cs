using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    float oCash = 0;
    Clicker clicker;
    Timer timer;
    FrenzyManager frenzyManager;

    [SerializeField] float oCashForOboyClickAmountUpgrade;
    [SerializeField] float oCashForMilkClickAmountUpgrade;
    [SerializeField] float oCashForBaseOCashUpgrade;
    [SerializeField] float oCashForAutoClicker;
    [SerializeField] TextMeshProUGUI oCashText;
    [SerializeField] Button autoClickerButton;

    void Start()
    {
        clicker = FindObjectOfType<Clicker>();
        timer = FindObjectOfType<Timer>();
        frenzyManager = FindObjectOfType<FrenzyManager>();
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
            oCashForOboyClickAmountUpgrade *= 2;
        }
    }

    public void BuyMilkClickAmountUpgrade()
    {
        if (oCash >= oCashForMilkClickAmountUpgrade)
        {
            oCash -= oCashForMilkClickAmountUpgrade;
            oCashText.text = oCash.ToString();
            clicker.UpgradeMilkClickAmount();
            oCashForMilkClickAmountUpgrade *= 2;
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

    public void BuyAutoClicker()
    {
        if (oCash >= oCashForAutoClicker)
        {
            oCash -= oCashForAutoClicker;
            oCashText.text = oCash.ToString();
            clicker.ToggleAutoClick();
            timer.ToggleAutoClicker();
            frenzyManager.ActivateFrenzyEffect();
            autoClickerButton.interactable = false;
            oCashForAutoClicker *= 2;
        }
    }

    public void TurnOffAutoClicker()
    {
        clicker.ToggleAutoClick();
        timer.ToggleAutoClicker();
        frenzyManager.ActivateFrenzyEffect();
        autoClickerButton.interactable = true;
    }
}
