using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurretController : Enemy {
    public Transform player;

    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform firePoint;


    void Start() {
        InvokeRepeating(nameof(Shoot), 0f, Random.Range(1f, 3f));
    }

    void Update() {
        if ((player.position - transform.position).magnitude <= aggroDistance) {
            transform.LookAt(player);
        }
    }

    void Shoot() {
        if ((player.position - transform.position).magnitude <= aggroDistance) {
            Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.LookAt(player);
        }
    }
}