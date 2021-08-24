using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet {
    [SerializeField] int damage = 1;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<Health>() != null) {
            other.gameObject.GetComponent<Health>().ChangeHealth(-damage);
        }

        Destroy(gameObject);
    }
}