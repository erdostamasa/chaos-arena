using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour {
    public float energy;
    public float maxEnergy;

    public void ChangeEnergy(float delta) {
        energy += delta;
        if (energy > maxEnergy) energy = maxEnergy;
        float percent = energy / maxEnergy * 100f;
        EventManager.instance.PlayerDamaged(percent);
        if (energy <= 0) {
            EventManager.instance.PlayerDied();
            Destroy(gameObject);
        }
    }
}
