using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Platform owner;
    public bool active = false;
    [SerializeField] Transform energyOrbPrefab;
    [SerializeField] Transform moneyOrbPrefab;
    
    [SerializeField] Transform explosionPrefab;
    
    
    void OnDestroy() {
        owner.aliveEnemies.Remove(this);
    }

    public void DestroyThisEnemy() {
        for (int i = 0; i < 10; i++) {
            Instantiate(energyOrbPrefab, transform.position, Quaternion.identity);
            Instantiate(moneyOrbPrefab, transform.position, Quaternion.identity);
        }
        EventManager.instance.EnemyDied();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
