using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntUpgrade : MonoBehaviour {
    [SerializeField] string upgradeName;
    //[SerializeField] int currentValue;

    [SerializeField] int basePrice = 10;
    [SerializeField] float multiplier = 10f;

    [SerializeField] TextMeshProUGUI currentDisplay;
    [SerializeField] TextMeshProUGUI upgradedDisplay;
    [SerializeField] TextMeshProUGUI priceDisplay;

    void Start() {
        UpdateDisplay();
    }

    public void Upgrade() {
        int money = PlayerPrefs.GetInt("money");
        int price = (int)(basePrice + PlayerPrefs.GetInt(upgradeName) * multiplier);
        if (money >= price) {
            money -= price;
            PlayerPrefs.SetInt(upgradeName, PlayerPrefs.GetInt(upgradeName) + 1);
            PlayerPrefs.SetInt("money", money);
            EventManager.instance.MoneyChanged(money);
        }

        UpdateDisplay();
    }

    void UpdateDisplay() {
        currentDisplay.text = PlayerPrefs.GetInt(upgradeName).ToString();
        upgradedDisplay.text = (PlayerPrefs.GetInt(upgradeName) + 1).ToString();
        priceDisplay.text = (basePrice + PlayerPrefs.GetInt(upgradeName) * multiplier).ToString();
    }
}