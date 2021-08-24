using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour {

    [SerializeField] float damage = 1f;
    
    void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerEnergy>().ChangeEnergy(-damage * Time.fixedDeltaTime);
        }
    }
}