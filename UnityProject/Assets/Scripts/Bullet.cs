using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float timeOut = 10f;
    
    void Start() {
        Destroy(gameObject, timeOut);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

}