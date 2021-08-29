using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXAAswitcher : MonoBehaviour {
    FXAA f;

    void Start() {
        f = GetComponent<FXAA>();
        EventManager.instance.onFXAAchanged += ChangeFXAA;
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
