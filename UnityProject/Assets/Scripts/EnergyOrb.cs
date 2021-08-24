using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyOrb : MonoBehaviour {
    Transform target;
    [SerializeField] float speed = 10f;
    [SerializeField] float pickupDistance = 10f;
    [SerializeField] AnimationCurve pickupSpeedCurve;
    
    void Start() {
        target = GameObject.Find("Player").transform;
    }
    
    void Update() {
        Vector3 direction = (target.position - transform.position).normalized;
        float distance = (target.position - transform.position).magnitude;
        if (distance <= pickupDistance) {
            float modifier = pickupSpeedCurve.Evaluate(distance / pickupDistance);
            transform.position += direction * this.speed * modifier * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerEnergy>().ChangeEnergy(1);
            Destroy(gameObject);
        }
    }
}