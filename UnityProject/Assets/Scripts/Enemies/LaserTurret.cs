using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;
using VolumetricLines;

public class LaserTurret : Turret {
    [SerializeField] VolumetricLineBehavior laserLine;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform targetingBall;
    [SerializeField] float laserDistance = 10f;
    float currentDistance;
    [SerializeField] GameObject laserObject;
    bool extending = false;
    bool retracting = false;
    [SerializeField] float laserGrowSpeed = 5f;
    [SerializeField] float damagePerSecond = 1f;
    [SerializeField] ParticleSystem particles;
    
    new void Start() {
        base.Start();
        currentDistance = 0f;
        if (laserLine) {
            laserLine.EndPos = Vector3.zero;    
        }
        
    }
    
    new void Update() {
        if (particles) {
            particles.transform.localPosition = new Vector3(0, 0, currentDistance);    
        }
        
        
        if (!active) {
            if (!retracting && !extending) {
                StartCoroutine(RetractLaser());
            }
        }
        else {
            if (!extending && !retracting) {
                StartCoroutine(ExtendLaser());
            }

            //laserObject.SetActive(true);
            RaycastHit hit;
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, currentDistance, playerLayer, QueryTriggerInteraction.Ignore)) {
                if (hit.collider.gameObject.CompareTag("Player")) {
                    hit.collider.gameObject.GetComponent<PlayerEnergy>().ChangeEnergy(-damagePerSecond * GameManager.instance.currentStage.enemyDamageMultiplier * Time.deltaTime);
                }
                targetingBall.position = hit.point;
                float dist = (targetingBall.position - firePoint.position).magnitude;
                laserLine.EndPos = new Vector3(0, 0, dist);
            }
            else {
                //laserLine.EndPos = new Vector3(0, 0, currentDistance);
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
        else {
            IdleRotation();
        }
    }


    IEnumerator ExtendLaser() {
        particles.Play();
        extending = true;
        laserObject.SetActive(true);
        while (laserLine.EndPos.z < laserDistance) {
            currentDistance = laserLine.EndPos.z;
            laserLine.EndPos = new Vector3(0, 0, laserLine.EndPos.z + Time.deltaTime * laserGrowSpeed);
            yield return new WaitForEndOfFrame();
        }

        extending = false;
    }

    IEnumerator RetractLaser() {
        if (laserLine == null) yield break;
        retracting = true;
        while (laserLine.EndPos.z > 0) {
            currentDistance = laserLine.EndPos.z;
            laserLine.EndPos = new Vector3(0, 0, laserLine.EndPos.z - Time.deltaTime * laserGrowSpeed);
            yield return new WaitForEndOfFrame();
        }
        laserObject.SetActive(false);
        retracting = false;
        particles.Pause();
        particles.Clear();
    }

    new void Shoot() {
        
    }
}