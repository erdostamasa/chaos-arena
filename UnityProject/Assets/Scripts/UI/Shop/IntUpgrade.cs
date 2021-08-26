using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntUpgrade : MonoBehaviour {
    [SerializeField] string upgradeName;
    [SerializeField] int basePrice = 10;
    [SerializeField] float multiplier = 10f;
    [SerializeField] TextMeshProUGUI currentDisplay;
    [SerializeField] TextMeshProUGUI upgradedDisplay;
    [SerializeField] TextMeshProUGUI priceDisplay;
    public bool available = true;

    //int Price => (int)(basePrice * PlayerPrefs.GetInt(upgradeName,1) * multiplier);
    int Price {
        get {
            int level = PlayerPrefs.GetInt(upgradeName, 1);
            switch (level) {
                case 1:
                    return 100;
                case 2:
                    return 1000;
                case 3:
                    return 5000;
                case 4:
                    return 10000;
                default:
                    return 0;
            }
        }
    }

    void Start() {
        UpdateDisplay();
    }

    public void Upgrade() {
        int money = PlayerPrefs.GetInt("money");
        if (available && money >= Price) {
            money -= Price;
            PlayerPrefs.SetInt(upgradeName, PlayerPrefs.GetInt(upgradeName, 1) + 1);
            PlayerPrefs.SetInt("money", money);
            EventManager.instance.MoneyChanged(money);
            if (PlayerPrefs.GetInt(upgradeName) > 4) available = false;
        }

        UpdateDisplay();
    }

    void UpdateDisplay() {
        currentDisplay.text = (PlayerPrefs.GetInt(upgradeName, 1) - 1).ToString();
        upgradedDisplay.text = (PlayerPrefs.GetInt(upgradeName, 1)).ToString();
        priceDisplay.text = "$" + Price;

        if (!available) {
            currentDisplay.text = "MAX";
            upgradedDisplay.text = "MAX";
            priceDisplay.text = "MAX";
        }
    }
}