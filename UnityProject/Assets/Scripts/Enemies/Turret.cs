using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Turret : Enemy {
    public Transform player;

    [SerializeField] protected Transform bulletPrefab;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Transform gun;

    [SerializeField] Transform head;

    // Angular speed in radians per sec.
    public float speed = 1.0f;
    
    void Start() {
        InvokeRepeating(nameof(Shoot), 0f, Random.Range(1f, 3f));
    }

    protected void Update() {
        if (active) {
            //gun.LookAt(player);
            
            // Determine which direction to rotate towards
            // anticipate player movement
            /*float distance = (player.transform.position - transform.position).magnitude;
            Vector3 targetDirection = (player.position + player.GetComponent<Rigidbody>().velocity * distance/10f) - transform.position;*/

            // Determine which direction to rotate towards
            Vector3 targetDirection = player.position - transform.position;
            
            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Vector3 newHeadDirection = Vector3.RotateTowards(head.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            //Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
            head.localRotation = Quaternion.LookRotation(newHeadDirection);

            Vector3 rot = transform.rotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(new Vector3(0, rot.y, 0));

            Vector3 headRot = head.transform.eulerAngles;
            head.localRotation = Quaternion.Euler(new Vector3(headRot.x, 0, 0));
        }
    }

    protected void Shoot() {
        if (active) {
            Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.forward = firePoint.forward;
            //bullet.LookAt(player);
        }
    }
}