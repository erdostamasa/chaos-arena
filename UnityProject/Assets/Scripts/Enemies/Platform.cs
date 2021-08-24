using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour {
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] List<GameObject> mountPoints;

    [SerializeField] float slowdownMultiplier = 0.25f;
    [SerializeField] Transform turretPrefab;
    public List<Enemy> aliveEnemies = new List<Enemy>();

    [Range(0f, 1f), SerializeField] float spawnChance = 0.5f;

    //[SerializeField] float sinkSeconds = 5f;

    Vector3 direction;
    Rigidbody platformBody;

    void ChangeDirection() {
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        direction.Normalize();
        GetComponent<Rigidbody>().velocity = direction;
    }

    void FixedUpdate() {
        if (destroying) {
            //slowdown
            platformBody.velocity += -platformBody.velocity * Time.fixedDeltaTime * slowdownMultiplier;
        }
        else {
            Vector3 normalizedHorizontalVelocity = new Vector3(platformBody.velocity.x, 0, platformBody.velocity.z).normalized * moveSpeed;
            platformBody.velocity = new Vector3(normalizedHorizontalVelocity.x, platformBody.velocity.y, normalizedHorizontalVelocity.z);
            //GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 2f;    
        }
        
    }

    void Start() {
        platformBody = GetComponent<Rigidbody>();
        //InvokeRepeating(nameof(ChangeDirection), Random.Range(0f, 2f), Random.Range(3f, 6f));
        ChangeDirection();

        FillMountPoints();
    }

    bool destroying = false;

    void Update() {
        if (aliveEnemies.Count == 0 && !destroying) {
            destroying = true;

            StartCoroutine(DestroyPlatform());

            /*platformBody.constraints = RigidbodyConstraints.None;
            platformBody.AddForce(Vector3.down * 300f, ForceMode.Impulse);
            platformBody.AddTorque(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * 200f, ForceMode.Impulse);
            platformBody.drag = 0.2f;
            platformBody.angularDrag = 0.2f;
            
            
            Invoke(nameof(DestroyPlatform), sinkSeconds);*/
        }
    }

    IEnumerator DestroyPlatform() {
        //1. slow down to a halt
        /*while (platformBody.velocity.magnitude >= 0.1f) {
            platformBody.velocity += -platformBody.velocity * Time.fixedDeltaTime * slowdownMultiplier;
            yield return new WaitForFixedUpdate();
        }*/

        //2.sink into ground
        //platformBody.constraints = RigidbodyConstraints.None;
        //transform.DOMoveY(-1.1f, 15f);
        platformBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        while (transform.position.y > -1.3f) {
            //platformBody.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * 0.1f, transform.position.z);
            platformBody.velocity = new Vector3(platformBody.velocity.x, -0.1f, platformBody.velocity.z);
            yield return new WaitForFixedUpdate();
        }
        

        //yield return new WaitForSeconds(20f);
            
        //destroy
        Destroy(gameObject);

        //yield return null;
    }
    

    public void ToggleEnemies(bool toggle) {
        foreach (Enemy enemy in aliveEnemies) {
            enemy.active = toggle;
        }
    }

    void FillMountPoints() {
        for (int i = 0; i < mountPoints.Count; i++) {
            if (spawnChance <= Random.Range(0f, 1f)) continue;
            Transform turret = Instantiate(turretPrefab, mountPoints[i].transform.position, Quaternion.identity);
            turret.GetComponent<TurretController>().player = GameObject.Find("Player").transform;
            ConstraintSource source = new ConstraintSource();
            source.sourceTransform = mountPoints[i].transform;
            source.weight = 1f;
            turret.GetComponent<PositionConstraint>().AddSource(source);
            turret.GetComponent<Enemy>().owner = this;
            aliveEnemies.Add(turret.GetComponent<Enemy>());
        }
    }
}