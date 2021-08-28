using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAggro : MonoBehaviour {
    [SerializeField] Enemy owner;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            owner.active = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            owner.active = false;
        }
    }
}
