using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Platform owner;
    public bool active = false;
    [SerializeField] Transform energyOrbPrefab;
    
    
    void OnDestroy() {
        owner.aliveEnemies.Remove(this);
    }

    public void DestroyThisEnemy() {
        Instantiate(energyOrbPrefab, transform.position, Quaternion.identity);
        EventManager.instance.EnemyDied();
        Destroy(gameObject);
    }
}
