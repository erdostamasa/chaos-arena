using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerup : MonoBehaviour {
    [SerializeField] SoundClip sound;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<MovingSphere>().ActivateBoost();
            AudioManager.instance.PlaySound(sound, transform.position, 0.2f);
            Destroy(gameObject);
        }
    }
}