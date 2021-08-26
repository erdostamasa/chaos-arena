using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultValueSetter : MonoBehaviour {
    void Start() {
        /*if (!PlayerPrefs.HasKey("airJumps")) PlayerPrefs.SetInt("airJumps", 0);
        if (!PlayerPrefs.HasKey("maxHealthUpgradeCount")) PlayerPrefs.SetInt("maxHealthUpgradeCount", 1);
        if (!PlayerPrefs.HasKey("shootingSpeedUpgradeCount")) PlayerPrefs.SetInt("shootingSpeedUpgradeCount", 10);*/
        if (!PlayerPrefs.HasKey("shootingSpeedLevel")) PlayerPrefs.SetFloat("shootingSpeedLevel", 1.5f);
    }
}