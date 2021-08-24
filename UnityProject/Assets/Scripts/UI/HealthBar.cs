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
    }

    void UpdateDisplay(float percentRemaining) {
        slider.value = percentRemaining;
    }
}