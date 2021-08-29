using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXAAswitcher : MonoBehaviour {
    FXAA f;

    void Start() {
        f = GetComponent<FXAA>();
        EventManager.instance.onFXAAchanged += ChangeFXAA;
        if (PlayerPrefs.GetInt("FXAAVariable") == 1 && PlayerPrefs.GetInt("Retro") == 0) {
            f.enabled = true;
        }
        else {
            f.enabled = false;
        }
    }

    void ChangeFXAA() {
        if (PlayerPrefs.GetInt("FXAAVariable") == 1) {
            f.enabled = true;
        }
        else {
            f.enabled = false;
        }
    }
}
