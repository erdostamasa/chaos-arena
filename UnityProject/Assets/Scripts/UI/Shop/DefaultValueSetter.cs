using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultValueSetter : MonoBehaviour {
    void Start() {
        if (!PlayerPrefs.HasKey("airJumps")) PlayerPrefs.SetInt("airJumps", 1);
        if (!PlayerPrefs.HasKey("maxHealthUpgradeCount")) PlayerPrefs.SetInt("maxHealthUpgradeCount", 0);
        if (!PlayerPrefs.HasKey("maxHealthLevel")) PlayerPrefs.SetFloat("maxHealthLevel", 1);
        if (!PlayerPrefs.HasKey("shootingSpeedUpgradeCount")) PlayerPrefs.SetInt("shootingSpeedUpgradeCount", 0);
        if (!PlayerPrefs.HasKey("shootingSpeedLevel")) PlayerPrefs.SetFloat("shootingSpeedLevel", 1);
        if (!PlayerPrefs.HasKey("money")) PlayerPrefs.SetInt("money", 0);
    }
}