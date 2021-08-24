using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    [SerializeField] Transform targeter;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform player;
    [SerializeField] PlayerEnergy energy;
    
    [SerializeField] Transform bulletPrefab;
    [SerializeField] float energyCost = 0.05f;
    
    [SerializeField] float fireFrequency = 0.1f;

    [SerializeField] LayerMask targetingMask;
    
    float timer;

    bool canFire = false;
    
    void Update() {
        timer += Time.deltaTime;
        if (timer >= fireFrequency && energy.energy > energyCost) {
            canFire = true;
        }
        
        
        //Plane plane = new Plane(Vector3.up, -player.position.y);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.DrawRay(ray.origin, ray.direction * 50f, Color.blue);
        if (Physics.Raycast(ray, out hit, 100f, targetingMask)) {
            //targeter.position = ray.GetPoint(distance);

            Debug.Log(hit.collider.name);
            //Smoothly move to mouse position
            Vector3 directionToMove = hit.point;
            //float distanceToMove = (directionToMove - targeter.position).sqrMagnitude;
            targeter.position += (directionToMove - targeter.position) * Time.deltaTime * 50f;
            //targeter.position = new Vector3(targeter.position.x, player.position.y, targeter.position.z);

            
            transform.LookAt(targeter.position);
        }

        if (Input.GetMouseButton(0) && canFire) {
            energy.ChangeEnergy(-energyCost);
            Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            //bullet.LookAt(targeter);
            bullet.forward = firePoint.forward;
            timer = 0;
            canFire = false;
        }
    }
}