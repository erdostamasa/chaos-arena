using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : EnemyBullet {

    Transform target;
    public float turnSpeed = 1.0f;
    [SerializeField] Transform model;
    
    protected new void Start() {
        target = GameObject.Find("Player").transform;
        Invoke(nameof(DestroyBullet), timeOut);
        GetComponent<Rigidbody>().velocity = model.forward * speed;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
            Destroy(other.gameObject);
            DestroyBullet();
        }
    }

    void FixedUpdate() {
//        transform.LookAt(target);
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;
            
        // The step size is equal to speed times frame time.
        float singleStep = turnSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(model.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        model.rotation = Quaternion.LookRotation(newDirection);
            
        /*Vector3 rot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(0, rot.y, 0));*/
        
        
        GetComponent<Rigidbody>().velocity = model.forward * speed;
    }
}