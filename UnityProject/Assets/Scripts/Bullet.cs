using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float timeOut = 5f;
    [SerializeField] protected Transform explosionPrefab;
    void Start()
    {
        Invoke("DestroyBullet", timeOut);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void DestroyBullet()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

}