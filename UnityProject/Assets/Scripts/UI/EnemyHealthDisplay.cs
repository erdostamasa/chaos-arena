using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthDisplay : MonoBehaviour {
    [SerializeField] Health health;
    [SerializeField] TextMeshProUGUI text;

    void Start() {
        UpdateDisplay();
    }

    public void UpdateDisplay() {
        text.text = health.healthPoints.ToString();
    }
}