using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int healthPoints = 1;
    [SerializeField] EnemyHealthDisplay display;
    
    public void TakeDamage(int dmg) {
        healthPoints -= dmg;
        display.UpdateDisplay();
        if (healthPoints <= 0) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
    
}
