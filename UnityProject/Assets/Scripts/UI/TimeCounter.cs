using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour {
    [SerializeField] TextMeshProUGUI display;
    
    void Update() {
        display.text = Mathf.Round(GameManager.instance.timeSinceStart) + "s";
    }
}