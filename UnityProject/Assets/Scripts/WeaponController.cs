using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    [SerializeField] Transform targeter;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform player;
    
    [SerializeField] Transform bulletPrefab;

    [SerializeField] float fireFrequency = 0.1f;
    float timer;

    bool canFire = false;
    
    void Update() {
        timer += Time.deltaTime;
        if (timer >= fireFrequency) {
            canFire = true;
        }
        
        
        Plane plane = new Plane(Vector3.up, -player.position.y);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 50f, Color.blue);
        if (plane.Raycast(ray, out distance)) {
            //targeter.position = ray.GetPoint(distance);

            //Smoothly move to mouse position
            Vector3 directionToMove = ray.GetPoint(distance);
            float distanceToMove = (directionToMove - targeter.position).sqrMagnitude;
            targeter.position += (directionToMove - targeter.position) * (distance * Time.deltaTime * 0.9f);

            
            transform.LookAt(targeter.position);
        }

        if (Input.GetMouseButton(0) && canFire) {
            Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.LookAt(targeter);
            timer = 0;
            canFire = false;
        }
    }
}