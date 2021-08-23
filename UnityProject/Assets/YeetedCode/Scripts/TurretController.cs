using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurretController : MonoBehaviour {
    public Transform player;

    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform firePoint;
    

    void Start() {
        InvokeRepeating(nameof(Shoot), 0f, Random.Range(1f, 3f));
    }

    void Update() {
        transform.LookAt(player);
    }

    void Shoot() {
        Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.LookAt(player);
    }
}