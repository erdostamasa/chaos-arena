using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour {
    [SerializeField] float moveSpeed = 3f;


    Vector3 direction;

    void ChangeDirection() {
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        direction.Normalize();
        GetComponent<Rigidbody>().velocity = direction * moveSpeed * Random.Range(0.5f, 1.5f); 
    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 3f;
    }

    void Start() {
        //InvokeRepeating(nameof(ChangeDirection), Random.Range(0f, 2f), Random.Range(3f, 6f));
        ChangeDirection();
    }
}