using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTurret : Turret {
    //[SerializeField] Vector2 fireFrequency;
    //[SerializeField] int volleyLength = 3;
    [SerializeField] SoundClip missileLaunch;
    [SerializeField] Transform missileEffect;

    int volley;
    
    new void Start() {
        //base.Start();
        Stage currentStage = GameManager.instance.currentStage;
        shootFrequency = 1f / (currentStage.enemyShotsPerSecond * baseShootSpeedMultiplier);
//        Debug.Log(currentStage);
        int r = currentStage.randomDropOffset;
        energyDrop = currentStage.energyDropRate + Random.Range(-r, r);
        moneyDrop = currentStage.moneyDropRate + Random.Range(-r, r);
        idleDirection = Vector3.zero;
        idleWait = Random.Range(2f, 4f);
        InvokeRepeating(nameof(Shoot), 0f, shootFrequency);
        volley = GameManager.instance.currentStage.rocketVolleyAmount;
    }

    protected new void Shoot() {
        if (active) {
            StartCoroutine(ShootRockets());
        }
    }

    IEnumerator ShootRockets() {
        Instantiate(missileEffect, firePoint.position, firePoint.rotation).parent = transform;
        yield return new WaitForSeconds(0.6f);
        for (int v = 0; v < volley; v++) {
            Transform bullet = Instantiate(bulletPrefab, head.position, Quaternion.identity);
            bullet.Find("model").forward = firePoint.forward + GenerateSpread();
            AudioManager.instance.PlaySound(missileLaunch, transform.position);
            yield return new WaitForSeconds(Random.Range(0.4f, 0.5f));
        }
    }
}