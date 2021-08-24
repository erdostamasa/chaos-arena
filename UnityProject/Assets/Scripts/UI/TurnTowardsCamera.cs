using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowardsCamera : MonoBehaviour {
    void LateUpdate() {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(Vector3.up * 180);
    }
}