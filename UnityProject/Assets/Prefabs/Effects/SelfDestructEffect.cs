using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructEffect : MonoBehaviour {
    [SerializeField] float timeOut = 2f;

    void Start() {
        Destroy(gameObject, timeOut);
    }
}