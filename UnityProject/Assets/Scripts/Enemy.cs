using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Platform owner;
    [SerializeField] protected float aggroDistance = 10f;
    
    
    
    void OnDestroy() {
        owner.aliveEnemies.Remove(this);
    }
}
