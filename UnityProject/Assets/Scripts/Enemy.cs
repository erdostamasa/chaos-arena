using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {
    public EnemyType type;
    public Platform owner;
    public bool active = false;
    [SerializeField] Transform energyOrbPrefab;
    [SerializeField] Transform moneyOrbPrefab;
    [SerializeField] Transform explosionPrefab;
    [SerializeField] protected float baseShootSpeedMultiplier = 1f;
    protected float shootFrequency;
    protected int energyDrop;
    protected int moneyDrop;

    public enum EnemyType {
        BASIC,
        ROCKET,
        LASER
    }
    
    protected void Start() {
        Stage currentStage = GameManager.instance.currentStage;
        shootFrequency = 1f / (currentStage.enemyShotsPerSecond * baseShootSpeedMultiplier);
//        Debug.Log(currentStage);
        int r = currentStage.randomDropOffset;
        energyDrop = currentStage.energyDropRate + Random.Range(-r, r);
        moneyDrop = currentStage.moneyDropRate + Random.Range(-r, r);
    }


    void OnDestroy() {
        if (owner) {
            owner.aliveEnemies.Remove(this);    
        }
    }

    public void DestroyThisEnemy(bool dropLoot) {
        if (dropLoot) {
            for (int i = 0; i < moneyDrop; i++) {
                Instantiate(moneyOrbPrefab, transform.position, Quaternion.identity);
            }

            for (int i = 0; i < energyDrop; i++) {
                Instantiate(energyOrbPrefab, transform.position, Quaternion.identity);
            }
        }
        
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        EventManager.instance.EnemyDied(type);
        Destroy(gameObject);
    }
}