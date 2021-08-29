using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroSwitcher : MonoBehaviour {
    [SerializeField] GameObject pixelTexture;

    void Start() {
        if (PlayerPrefs.GetInt("Retro") == 1) {
            pixelTexture.SetActive(true);
        }
        else {
            pixelTexture.SetActive(false);
        }
            
    }
}
