using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour {
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] List<GameObject> mountPoints;

    [SerializeField] Transform turretPrefab;
    public List<Enemy> aliveEnemies = new List<Enemy>(); 

    Vector3 direction;

    void ChangeDirection() {
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        direction.Normalize();
        GetComponent<Rigidbody>().velocity = direction * moveSpeed * Random.Range(0.5f, 1.5f); 
    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 3f;
    }

    void Start() {
        //InvokeRepeating(nameof(ChangeDirection), Random.Range(0f, 2f), Random.Range(3f, 6f));
        ChangeDirection();
        
        FillMountPoints();
    }

    void Update() {
        if (aliveEnemies.Count == 0) {
            Destroy(gameObject);
        }
    }

    void FillMountPoints() {
        for (int i = 0; i < mountPoints.Count; i++) {
            if(0.5f <= Random.Range(0f, 1f)) continue;
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