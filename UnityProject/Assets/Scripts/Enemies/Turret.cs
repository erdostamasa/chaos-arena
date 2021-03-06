using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

public class Turret : Enemy {
    public Transform player;

    [SerializeField] protected Transform bulletPrefab;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Transform gun;

    [SerializeField] protected Transform head;
    [SerializeField] Vector3 spreadAmountMin;
    [SerializeField] Vector3 spreadAmountMax;
    [SerializeField] Vector3 targetOffset;
    [SerializeField] SoundClip shootingSound;
    
    // Angular speed in radians per sec.
    public float speed = 1.0f;
    
    protected Vector3 idleDirection;
    protected float idleTimer = 0;
    protected float idleWait;
    
    protected new void Start() {
        base.Start();
        InvokeRepeating(nameof(Shoot), 0f, Random.Range(shootFrequency-0.1f, shootFrequency+0.1f));
        idleDirection = Vector3.zero;
        idleWait = Random.Range(3f, 5f);
    }

    protected Vector3 GenerateSpread() {
        return new Vector3(Random.Range(spreadAmountMin.x, spreadAmountMax.x), Random.Range(spreadAmountMin.y, spreadAmountMax.y), Random.Range(spreadAmountMin.z, spreadAmountMax.z));
    }


    
    protected void Update() {
        if (active) {
            Vector3 targetDirection = (player.position - firePoint.position) + targetOffset;

            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Vector3 newHeadDirection = Vector3.RotateTowards(head.forward, targetDirection, singleStep, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
            head.localRotation = Quaternion.LookRotation(newHeadDirection);

            Vector3 rot = transform.rotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(new Vector3(0, rot.y, 0));
            //GetComponent<ParentConstraint>().SetRotationOffset(1,new Vector3(0, rot.y, 0));
            
            
            Vector3 headRot = head.transform.eulerAngles;
            head.localRotation = Quaternion.Euler(new Vector3(headRot.x, 0, 0));
        }
        else {
            //idle rotating
            IdleRotation();
        }
    }


    protected void IdleRotation() {
        idleTimer += Time.deltaTime;
        if (idleTimer >= idleWait) {
            idleDirection = new Vector3(Random.Range(-1f,1f), Random.Range(-0.3f,0.3f), Random.Range(-1f,1f));
            idleTimer = 0f;
        }
        Vector3 targetDirection = idleDirection;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        

        Vector3 rot = transform.rotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(new Vector3(0, rot.y, 0));
        //GetComponent<ParentConstraint>().SetRotationOffset(1,new Vector3(0, rot.y, 0));
            
        
        if (head != null) {
            Vector3 newHeadDirection = Vector3.RotateTowards(head.forward, targetDirection, singleStep, 0.0f);
            head.localRotation = Quaternion.LookRotation(newHeadDirection);
            Vector3 headRot = head.transform.eulerAngles;
            head.localRotation = Quaternion.Euler(new Vector3(headRot.x, 0, 0));
        }
        
        
    }

    protected void Shoot() {
        if (active) {
            AudioManager.instance.PlaySound(shootingSound, transform.position, 0.2f);
            Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.forward = firePoint.forward + GenerateSpread();
            //bullet.LookAt(player);
        }
    }
}