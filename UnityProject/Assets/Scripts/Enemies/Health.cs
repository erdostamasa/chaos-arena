using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int healthPoints = 1;
    [SerializeField] EnemyHealthDisplay display;

    void Setup(int hp) {
        healthPoints = hp;
        display.UpdateDisplay();
    }

    void Start() {
        Setup((int)(healthPoints * GameManager.instance.currentStage.enemyHealthMultiplier));
    }

    public void ChangeHealth(int delta) {
        healthPoints += delta;
        if (healthPoints <= 0) {
            GetComponent<Enemy>().DestroyThisEnemy();
        }

        display.UpdateDisplay();
    }
}