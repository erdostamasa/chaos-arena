using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    [SerializeField] Slider slider;

    void Start() {
        EventManager.instance.onPlayerDamaged += UpdateDisplay;

        /*slider.maxValue = PlayerPrefs.GetFloat("maxHealthLevel") * 100f;
        slider.value = slider.maxValue;*/
    }

    void UpdateDisplay(float percentRemaining) {
        slider.value = percentRemaining;
    }
}