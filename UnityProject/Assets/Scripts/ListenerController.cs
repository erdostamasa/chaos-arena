using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerController : MonoBehaviour {
    

    void Start() {
        EventManager.instance.onVolumeChanged += ChangeVolume;
    }

    void ChangeVolume() {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume") / 100f;
    }
}
