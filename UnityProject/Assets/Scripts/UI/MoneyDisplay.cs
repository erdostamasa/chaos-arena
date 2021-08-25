using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour {
    TextMeshProUGUI display;

    void Start() {
        display = GetComponent<TextMeshProUGUI>();
        EventManager.instance.onMoneyChanged += UpdateDisplay;
        
        UpdateDisplay(GameManager.instance.money);
    }

    void UpdateDisplay(int value) {
        display.text = value + " Coin";
    }
    
}
