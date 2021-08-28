using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {
    [SerializeField] float retractedHeight = -1f;
    [SerializeField] float moveSpeed = 5f;

    void Start() {
        Retract();
    }


    public void Retract() {
        transform.DOMoveY(retractedHeight, moveSpeed);
    }
}