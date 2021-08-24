using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour {
    [SerializeField] Transform platformPrefab;
    [SerializeField] List<PlatformSpawnPoint> spawnPoints;

    void Start() {
        for (int i = 0; i < transform.childCount; i++) {
            spawnPoints.Add(transform.GetChild(i).GetComponent<PlatformSpawnPoint>());
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            SpawnPlatform();
        }
    }


    public void SpawnPlatform() {
        spawnPoints.Shuffle();
        
        //bool spawned = false;
        foreach (PlatformSpawnPoint point in spawnPoints) {
            if (point.CanSpawn()) {
                //spawned = true;
                Transform plat = Instantiate(platformPrefab, point.transform.position, Quaternion.identity);
                plat.GetComponent<Rigidbody>().AddTorque(Vector3.up * Random.Range(-2000f, 2000f), ForceMode.Impulse);
                break;
            }
        }

        /*if (!spawned) {
            Debug.Log("Can't spawn!");
        }*/
    }
}