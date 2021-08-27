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
    [SerializeField] List<Transform> powerupSpawnLocations;

    [SerializeField] float slowdownMultiplier = 0.25f;

    public List<Enemy> aliveEnemies = new List<Enemy>();
    WeightedRandomBag<Transform> enemyBag;
    WeightedRandomBag<Transform> powerupBag;

    [SerializeField] bool hasTimer = false;
    [SerializeField] float timeToSink = 0f;

    Stage stage;
    Vector3 direction;
    Rigidbody platformBody;
    Transform spawnedPowerup;

    bool destroying = false;
    bool rising = false;

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
        else if (rising) {
        }
        else {
            Vector3 normalizedHorizontalVelocity = new Vector3(platformBody.velocity.x, 0, platformBody.velocity.z).normalized * moveSpeed;
            platformBody.velocity = new Vector3(normalizedHorizontalVelocity.x, platformBody.velocity.y, normalizedHorizontalVelocity.z);
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            //GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 2f;    
        }

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }


    void Start() {
        //EventManager.instance.onEnemyDied += CheckMountPoints;
        platformBody = GetComponent<Rigidbody>();
        
    }

    public void SetupPlatform(Stage s) {
        stage = s;
        enemyBag = new WeightedRandomBag<Transform>();
        foreach (WeightedRandomBag<Transform>.Entry enemy in stage.enemies) {
            enemyBag.AddEntry(enemy.item, enemy.accumulatedWeight);
        }
        powerupBag = new WeightedRandomBag<Transform>();
        foreach (WeightedRandomBag<Transform>.Entry powerup in stage.powerups) {
            powerupBag.AddEntry(powerup.item, powerup.accumulatedWeight);
        }


        //InvokeRepeating(nameof(ChangeDirection), Random.Range(0f, 2f), Random.Range(3f, 6f));
        ChangeDirection();

        FillMountPoints();

        transform.position -= Vector3.up * 1.3f;
        //felemelkedés föld alól

        EventManager.instance.PlatformSpawned();
        StartCoroutine(RiseFromBelow());
    }

    IEnumerator RiseFromBelow() {
        rising = true;
        yield return new WaitForSeconds(0.01f);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        while (transform.position.y < 0f) {
            Vector3 normalizedHorizontalVelocity = new Vector3(platformBody.velocity.x, 0, platformBody.velocity.z).normalized * moveSpeed;
            platformBody.velocity = new Vector3(normalizedHorizontalVelocity.x, platformBody.velocity.y, normalizedHorizontalVelocity.z);
            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);


            platformBody.velocity = new Vector3(platformBody.velocity.x, 0.2f, platformBody.velocity.z);


            yield return new WaitForFixedUpdate();
            //yield return null;
        }

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        platformBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rising = false;
    }


    float timer = 0f;

    float checkTimer = 0f;
    float timePerCheck = 1f;

    void Update() {
        checkTimer += Time.deltaTime;
        if (checkTimer >= timePerCheck) {
            CheckMountPoints();
            checkTimer = 0;
        }


        if (hasTimer) {
            timer += Time.deltaTime;
            if (timer >= timeToSink) {
                destroying = true;
                StartCoroutine(DestroyPlatform());
            }
        }
    }

    void CheckMountPoints() {
        if (hasTimer) return;
        if (aliveEnemies.Count == 0 && !destroying) {
            destroying = true;
            StartCoroutine(DestroyPlatform());
        }
    }

    IEnumerator DestroyPlatform() {
        platformBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        while (transform.position.y > -1.3f) {
            //platformBody.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * 0.1f, transform.position.z);
            platformBody.velocity = new Vector3(platformBody.velocity.x, -0.1f, platformBody.velocity.z);
            yield return new WaitForFixedUpdate();
        }

        if (spawnedPowerup != null) {
            Destroy(spawnedPowerup.gameObject);
        }
        Destroy(gameObject);
    }

    void OnDestroy() {
        EventManager.instance.PlatformDestroyed();
    }


    public void ToggleEnemies(bool toggle) {
        foreach (Enemy enemy in aliveEnemies) {
            enemy.active = toggle;
        }
    }


    void FillMountPoints() {
        bool spawnedOne = false;
        Transform turret;
        ConstraintSource source;
        
        if (powerupSpawnLocations.Count > 0 && Random.Range(0f, 1f) <= stage.powerupSpawnChance) {
            //choose a random location from list
            int randomIndex = Random.Range(0, powerupSpawnLocations.Count);
            
            spawnedPowerup = Instantiate(powerupBag.GetRandom(), powerupSpawnLocations[randomIndex].position, Quaternion.identity);
            source = new ConstraintSource();
            source.sourceTransform = powerupSpawnLocations[randomIndex];
            source.weight = 1f;
            spawnedPowerup.GetComponent<PositionConstraint>().AddSource(source);
        }

        
        for (int i = 0; i < mountPoints.Count; i++) {
            if (!spawnedOne) {
                turret = Instantiate(enemyBag.GetRandom(), mountPoints[i].transform.position, Quaternion.identity);
                turret.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0));
                turret.GetComponent<Turret>().player = GameObject.Find("Player").transform;
                source = new ConstraintSource();
                source.sourceTransform = mountPoints[i].transform;
                source.weight = 1f;
                turret.GetComponent<PositionConstraint>().AddSource(source);
                turret.GetComponent<Enemy>().owner = this;
                aliveEnemies.Add(turret.GetComponent<Enemy>());
                //turret.parent = transform;
                
                spawnedOne = true;
            }
            else {
                if (stage.enemySpawnChance <= Random.Range(0f, 1f)) continue;

                turret = Instantiate(enemyBag.GetRandom(), mountPoints[i].transform.position, Quaternion.identity);
                turret.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0));
                turret.GetComponent<Turret>().player = GameObject.Find("Player").transform;
                source = new ConstraintSource();
                source.sourceTransform = mountPoints[i].transform;
                source.weight = 1f;
                turret.GetComponent<PositionConstraint>().AddSource(source);
                //turret.parent = transform;
                
                turret.GetComponent<Enemy>().owner = this;
                aliveEnemies.Add(turret.GetComponent<Enemy>());
            }
        }
    }
}