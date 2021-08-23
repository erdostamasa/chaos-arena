using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int healthPoints = 1;

    public void TakeDamage(int dmg) {
        healthPoints -= dmg;
        if (healthPoints <= 0) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
    
}
