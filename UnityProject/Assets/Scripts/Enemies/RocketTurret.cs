using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTurret : Turret {
    //[SerializeField] Vector2 fireFrequency;
    [SerializeField] int volleyLength = 3;

    new void Start() { 
        base.Start();
        InvokeRepeating(nameof(Shoot), 0f, shootFrequency);
    }
    
    protected new void Shoot() {
        if (active) {
            StartCoroutine(ShootRockets());
        }
    }

    IEnumerator ShootRockets() {
        for(int i = 0; i < volleyLength; i++) {
            Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.Find("model").forward = firePoint.forward + GenerateSpread();
            yield return new WaitForSeconds(Random.Range(0.2f,0.8f));
        }
    }
}