using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour {
    public float energy;
    public float maxEnergy;
    [SerializeField] float recoverSpeed = 1f;
    [SerializeField] float recoverPercent = 10f;
    [SerializeField] Transform explosionPrefab;
    void Update() {
        float percent = energy / maxEnergy * 100f;
        if (percent < recoverPercent) {
            energy += recoverSpeed * Time.deltaTime;
            EventManager.instance.PlayerDamaged(percent);    
        }
    }

    public void ChangeEnergy(float delta) {
        energy += delta;
        if (energy > maxEnergy) energy = maxEnergy;
        float percent = energy / maxEnergy * 100f;
        EventManager.instance.PlayerDamaged(percent);
        if (energy <= 0) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            EventManager.instance.PlayerDied();
            //Destroy(gameObject);
        }
    }
}
