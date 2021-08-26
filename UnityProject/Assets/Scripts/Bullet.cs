using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float timeOut = 5f;
    [SerializeField] protected Transform explosionPrefab;

    protected void Start() {
        Invoke(nameof(DestroyBullet), timeOut);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    protected void DestroyBullet() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}