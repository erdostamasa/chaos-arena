using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int healthPoints = 1;
    [SerializeField] EnemyHealthDisplay display;
    
    public void TakeDamage(int dmg) {
        healthPoints -= dmg;
        if (healthPoints <= 0) {
            Die();
        }
        display.UpdateDisplay();
    }

    void Die() {
        Destroy(gameObject);
    }
    
}
