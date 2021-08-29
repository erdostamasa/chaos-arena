using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour {
    [SerializeField] SoundClip sound;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerEnergy>().ActivateShield();
            AudioManager.instance.PlaySound(sound, transform.position, 0.2f);
            Destroy(gameObject);
        }
    }
}