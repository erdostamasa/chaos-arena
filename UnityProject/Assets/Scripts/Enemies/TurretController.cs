using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurretController : Enemy {
    public Transform player;

    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform gun;


    void Start() {
        InvokeRepeating(nameof(Shoot), 0f, Random.Range(1f, 3f));
    }

    void Update() {
        if (active) {
            gun.LookAt(player);
        }
    }

    void Shoot() {
        if (active) {
            Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.LookAt(player);
        }
    }
}