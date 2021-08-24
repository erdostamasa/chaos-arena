using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void SpawnPlatform() {
        spawnPoints.Shuffle();
        
        bool spawned = false;
        foreach (PlatformSpawnPoint point in spawnPoints) {
            if (point.CanSpawn()) {
                spawned = true;
                Instantiate(platformPrefab, point.transform.position, Quaternion.identity);
                break;
            }
        }

        /*if (!spawned) {
            Debug.Log("Can't spawn!");
        }*/
    }
}