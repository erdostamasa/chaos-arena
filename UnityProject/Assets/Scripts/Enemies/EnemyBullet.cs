using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet {
    [SerializeField] float energyDamage = 1;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<PlayerEnergy>() != null) {
            other.gameObject.GetComponent<PlayerEnergy>().ChangeEnergy(-energyDamage * GameManager.instance.currentStage.enemyDamageMultiplier);
        }
        
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}