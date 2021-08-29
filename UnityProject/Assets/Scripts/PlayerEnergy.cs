using System;
using System.Collections;
using System.Collections.Generic;
using MilkShake;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour {
    public float energy;
    public float maxEnergy;
    [SerializeField] float recoverSpeed = 1f;
    [SerializeField] float recoverPercent = 10f;
    [SerializeField] Transform explosionPrefab;
    public bool shielded = false;
    float shieldTimeout;
    float shieldTimer;
    [SerializeField] ShakePreset shakePreset;
    [SerializeField] bool invincible = false;
    [SerializeField] SoundClip damageSound;

    float damageTimer;
    float damageTime = 0.5f;
    bool canDamage = false;
    [SerializeField] GameObject shield;

    void Start() {
        maxEnergy = PlayerPrefs.GetFloat("maxHealthLevel", 1f) * 100f;
        shieldTimeout = PlayerPrefs.GetFloat("shieldLevel", 5f);
        energy = maxEnergy;
    }

    void Update() {
        damageTimer += Time.deltaTime;
        if (damageTimer >= damageTime) {
            damageTimer = 0;
            canDamage = true;
        }

        float percent = energy / maxEnergy * 100f;
        if (percent < recoverPercent) {
            energy += recoverSpeed * Time.deltaTime;
            EventManager.instance.PlayerDamaged(percent);
        }

        if (shielded) {
            shieldTimer += Time.deltaTime;
            if (shieldTimer >= shieldTimeout) {
                shielded = false;
                shield.SetActive(false);
            }
        }
    }

    public void ActivateShield() {
        shieldTimer = 0f;
        shielded = true;
        shield.SetActive(true);
    }

    public void ShootEnergy(float amount) {
        energy -= amount;
        if (energy > maxEnergy) energy = maxEnergy;
        float percent = energy / maxEnergy * 100f;
        EventManager.instance.PlayerDamaged(percent);
        if (energy <= 0) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            EventManager.instance.PlayerDied();
            //Destroy(gameObject);
        }
    }

    public void ChangeEnergy(float delta) {
        if (invincible) return;
        
        if (delta < 0 && shielded) return;

        if (delta < 0 && canDamage) {
            canDamage = false;
            damageTimer = 0;
            AudioManager.instance.PlayStatic(damageSound, 0.4f);
            Camera.main.transform.parent.GetComponent<Shaker>().Shake(shakePreset);
        }

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