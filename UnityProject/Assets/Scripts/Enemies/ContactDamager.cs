using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour {

    [SerializeField] float damage = 1f;
    float damageMultiplier;

    void Start() {
        damageMultiplier = PlayerPrefs.GetFloat("lavaDamageMultiplier", 1);
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerEnergy>().ChangeEnergy(-damage * damageMultiplier * Time.fixedDeltaTime * GameManager.instance.currentStage.lavaDamageMultiplier);
        }
    }

    /*void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            MovingSphere controller = other.gameObject.GetComponent<MovingSphere>();
            controller.maxSpeed = controller.slowSpeed;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            MovingSphere controller = other.gameObject.GetComponent<MovingSphere>();
            controller.maxSpeed = controller.normalSpeed;
        }
    }*/
}