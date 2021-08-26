using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {
    [SerializeField] Transform player;

    void LateUpdate() {
        transform.position = player.position;
//        transform.Translate(player.position - transform.position);
        
    }
}
