using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using VolumetricLines;

public class LaserTurret : Turret {
    [SerializeField] VolumetricLineBehavior laserLine;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform targetingBall;
    [SerializeField] float laserDistance = 10f;
    [SerializeField] GameObject laserObject;

    new void Update() {
        if (!active) {
            laserObject.SetActive(false);
        }
        else {
            laserObject.SetActive(true);
            RaycastHit hit;
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 50f, playerLayer, QueryTriggerInteraction.Ignore)) {
                targetingBall.position = hit.point;
                float dist = (targetingBall.position - firePoint.position).magnitude;
                laserLine.EndPos = new Vector3(0, 0, dist);
            }
            else {
                laserLine.EndPos = new Vector3(0, 0, 10);
            }
        }


        if (active) {
            Vector3 targetDirection = (player.position - firePoint.position);
            targetDirection = new Vector3(targetDirection.x, 0, targetDirection.z);

            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            
            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);

            Vector3 rot = transform.rotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(new Vector3(0, rot.y, 0));
            
        }
    }

    new void Shoot() {
    }
}