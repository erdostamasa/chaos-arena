using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAggro : MonoBehaviour {
    [SerializeField] Platform owner;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            owner.ToggleEnemies(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            owner.ToggleEnemies(false);
        }
    }
}
