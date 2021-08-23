using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    void LateUpdate() {
        transform.position = target.transform.position + offset;
    }
}