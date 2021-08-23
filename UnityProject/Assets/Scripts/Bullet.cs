using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] float speed = 5f;
    public bool playerBullet = false;
    
    void Start() {
        Invoke(nameof(DestroySelf), 5f);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void FixedUpdate() {
        //transform.Translate(transform.forward * (speed * Time.deltaTime), Space.World);
    }


    void DestroySelf() {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy") && playerBullet) {
            Destroy(other.gameObject);
        }
        DestroySelf();
    }

}