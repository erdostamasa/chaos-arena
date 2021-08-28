using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponController : MonoBehaviour {
    [SerializeField] Transform targeter;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform player;
    [SerializeField] PlayerEnergy energy;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] float energyCost = 0.05f;
    float fireFrequency;
    [SerializeField] float shotPerSecond = 1;
    [SerializeField] float spreadAmount;
    [SerializeField] SoundClip shootingSound;
    
    float timer;
    bool canFire = false;

    [SerializeField] float angularSpeed = 1f;

    Vector3 GenerateSpread() {
        return new Vector3(Random.Range(-spreadAmount, spreadAmount), Random.Range(-spreadAmount, spreadAmount)/5, Random.Range(-spreadAmount, spreadAmount));
    }

    void Start() {
        shotPerSecond = PlayerPrefs.GetFloat("shootingSpeedLevel",1f);
        fireFrequency = 1 / shotPerSecond;
    }

    void LateUpdate() {
        timer += Time.deltaTime;
        if (timer >= fireFrequency && energy.energy > energyCost) {
            canFire = true;
        }
        
        Plane plane = new Plane(Vector3.up, -1);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        plane.Raycast(ray, out var distance);
        if (plane.Raycast(ray, out distance)) {
            targeter.position = ray.GetPoint(distance);
            
            // Determine which direction to rotate towards
            Vector3 targetDirection = targeter.position - transform.position;
            
            // The step size is equal to speed times frame time.
            float singleStep = angularSpeed * Time.deltaTime;
            
            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            
            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
            
            //transform.LookAt(targeter.position);
        }

        if (Input.GetMouseButton(0) && canFire && Math.Abs(Time.timeScale - 1f) < 0.01f) {
            energy.ChangeEnergy(-energyCost);
            AudioManager.instance.PlaySound(shootingSound, transform.position);
            Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            //bullet.LookAt(targeter);
            bullet.forward = firePoint.forward + GenerateSpread();
            timer = 0;
            canFire = false;
        }
    }
}