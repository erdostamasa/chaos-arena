using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet {
    [SerializeField] float energyDamage = 1;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<PlayerEnergy>() != null) {
            other.gameObject.GetComponent<PlayerEnergy>().ChangeEnergy(-energyDamage * GameManager.instance.currentStage.enemyDamageMultiplier);
        }
        
        DestroyBullet();
    }

    void FixedUpdate() {
        /*if (transform.position.y < 1f) {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }*/
    }

    protected new void Start() {
       base.Start();
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
            Destroy(other.gameObject);
            DestroyBullet();
        }
    }
}