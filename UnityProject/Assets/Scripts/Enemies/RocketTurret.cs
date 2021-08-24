using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTurret : Turret {
    [SerializeField] List<Transform> firePoints;
    [SerializeField] Vector2 fireFrequency;
    
    void Start() {
        InvokeRepeating(nameof(Shoot), 0f, Random.Range(fireFrequency.x, fireFrequency.y));
    }
    
    protected new void Shoot() {
        if (active) {
            StartCoroutine(ShootRockets());
        }
    }
    
    
    IEnumerator ShootRockets() {
        foreach (Transform point in firePoints) {
            Transform bullet = Instantiate(bulletPrefab, point.position, Quaternion.identity);
            bullet.forward = point.forward;
            yield return new WaitForSeconds(0.5f);
        }
    }
}