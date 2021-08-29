using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class ContactDamager : MonoBehaviour {
    [SerializeField] float damage = 1f;
    float damageMultiplier;
    AudioSource source;
    [SerializeField] float lavaVolume = 0.6f;

    void Start() {
        damageMultiplier = PlayerPrefs.GetFloat("lavaDamageMultiplier", 1);
        source = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerEnergy>().ChangeEnergy(-damage * damageMultiplier * Time.fixedDeltaTime * GameManager.instance.currentStage.lavaDamageMultiplier);
        }
    }

    Coroutine fader;

    IEnumerator FadeVolume(float target) {
        if (source.volume < target) {
            while (source.volume < target) {
                source.volume += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        else {
            while (source.volume > target) {
                source.volume -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            MovingSphere controller = other.gameObject.GetComponent<MovingSphere>();
            controller.maxSpeed = controller.slowSpeed;
            controller.jumpHeight = controller.slowJump;
            if (fader != null) StopCoroutine(fader);
            fader = StartCoroutine(FadeVolume(lavaVolume));
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            MovingSphere controller = other.gameObject.GetComponent<MovingSphere>();
            controller.maxSpeed = controller.normalSpeed;
            controller.jumpHeight = controller.normalJump;
            if (fader != null) StopCoroutine(fader);
            fader = StartCoroutine(FadeVolume(0));
        }
    }
}