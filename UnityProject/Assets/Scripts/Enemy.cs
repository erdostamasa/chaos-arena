using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Platform owner;
    public bool active = false;

    void OnDestroy() {
        owner.aliveEnemies.Remove(this);
    }
}
