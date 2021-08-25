using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI moneyDisplay;

    void Start() {
        EventManager.instance.onMoneyChanged += UpdateDisplay;
        
        
        PlayerPrefs.SetInt("money", 0);
        EventManager.instance.MoneyChanged(0);
        
    }

    void UpdateDisplay(int money) {
        moneyDisplay.text = "$" + PlayerPrefs.GetInt("money");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 100);
            EventManager.instance.MoneyChanged(PlayerPrefs.GetInt("money"));
        }
    }
}