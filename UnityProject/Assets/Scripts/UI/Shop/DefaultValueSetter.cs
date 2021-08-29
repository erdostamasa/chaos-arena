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
        if (!PlayerPrefs.HasKey("shieldLevel")) PlayerPrefs.SetFloat("shieldLevel", 5f);
        if (!PlayerPrefs.HasKey("shieldCount")) PlayerPrefs.SetInt("shieldCount", 1);
        if (!PlayerPrefs.HasKey("boostLevel")) PlayerPrefs.SetFloat("boostLevel", 5f);
        if (!PlayerPrefs.HasKey("boostCount")) PlayerPrefs.SetInt("boostCount", 1);
        if (!PlayerPrefs.HasKey("Volume")) PlayerPrefs.SetFloat("Volume", 50f);
        AudioListener.volume = 0.5f;
        if (!PlayerPrefs.HasKey("Music")) PlayerPrefs.SetInt("Music", 1);
        if (!PlayerPrefs.HasKey("Retro")) PlayerPrefs.SetInt("Retro", 0);
        if (!PlayerPrefs.HasKey("showCursor")) PlayerPrefs.SetInt("showCursor", 0);
    }
}