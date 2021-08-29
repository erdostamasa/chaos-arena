using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatUpgrade : MonoBehaviour {
    [SerializeField] string upgradeLevelString;
    [SerializeField] string upgradeCountString;
    [SerializeField] TextMeshProUGUI currentDisplay;
    [SerializeField] TextMeshProUGUI upgradedDisplay;
    [SerializeField] TextMeshProUGUI priceDisplay;

    [SerializeField] float baseLevel = 1f;
    [SerializeField] float basePrice = 10f;
    [SerializeField] float levelIncrease;
    [SerializeField] float priceIncrease;
    [SerializeField] bool durationDisplay = false;


    int Price {
        get {
            int upgradeCount = PlayerPrefs.GetInt(upgradeCountString, 0);
            return (int)(basePrice * Mathf.Pow(priceIncrease, upgradeCount));
        }
    }

    void Start() {
        UpdateDisplay();
    }

    public void Upgrade() {
        int money = PlayerPrefs.GetInt("money");
        if (money >= Price) {
            money -= Price;

            float currentLevel = baseLevel * Mathf.Pow(levelIncrease, PlayerPrefs.GetInt(upgradeCountString, 0));
            float upgradedLevel = currentLevel * levelIncrease;

            PlayerPrefs.SetInt(upgradeCountString, PlayerPrefs.GetInt(upgradeCountString, 0) + 1);
            PlayerPrefs.SetFloat(upgradeLevelString, upgradedLevel);

            PlayerPrefs.SetInt("money", money);
            EventManager.instance.MoneyChanged(money);
            AudioManager.instance.ShopBuy();
        }
        else {
            AudioManager.instance.ShopFail();
        }

        UpdateDisplay();
    }

    void UpdateDisplay() {
        if (durationDisplay) {
            currentDisplay.text = Math.Round(PlayerPrefs.GetFloat(upgradeLevelString, baseLevel), 2) + "s";
            upgradedDisplay.text = Math.Round(PlayerPrefs.GetFloat(upgradeLevelString, baseLevel) * levelIncrease, 2) + "s";
            priceDisplay.text = "$" + Price;
        }
        else {
            currentDisplay.text = "x" + Math.Round(PlayerPrefs.GetFloat(upgradeLevelString, baseLevel), 2);
            upgradedDisplay.text = "x" + Math.Round(PlayerPrefs.GetFloat(upgradeLevelString, baseLevel) * levelIncrease, 2);
            priceDisplay.text = "$" + Price;    
        }
    }
}