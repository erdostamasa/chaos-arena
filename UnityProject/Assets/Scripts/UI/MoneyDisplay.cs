using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour {
    [SerializeField] TextMeshProUGUI display;

    void Start() {
        EventManager.instance.onMoneyChanged += UpdateDisplay;
        UpdateDisplay(PlayerPrefs.GetInt("money"));
    }

    void UpdateDisplay(int value) {
        display.text = "$" + PlayerPrefs.GetInt("money");
    }
    
}
