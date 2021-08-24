using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnergyOrb : MonoBehaviour {
    Transform target;
    [SerializeField] float speed = 10f;
    [SerializeField] float pickupDistance = 10f;
    [SerializeField] AnimationCurve pickupSpeedCurve;
    
    void Start() {
        target = GameObject.Find("Player").transform;
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-2f,2f), 0, Random.Range(-2f, 2f)), ForceMode.Impulse);
    }

    float timer = 0f;
    [SerializeField] float timeToPickup = 1f;
    
    void Update() {
        timer += Time.deltaTime;
        Vector3 direction = (target.position - transform.position).normalized;
        float distance = (target.position - transform.position).magnitude;
        if (distance <= pickupDistance && timer > timeToPickup) {
            float modifier = pickupSpeedCurve.Evaluate(distance / pickupDistance);
            transform.position += direction * speed * modifier * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerEnergy>().ChangeEnergy(1);
            Destroy(gameObject);
        }
    }
}