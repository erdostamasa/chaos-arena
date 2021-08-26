using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    void Awake() {
        instance = this;
    }

    [SerializeField] PlatformSpawner platformSpawner;
    bool gameIsPaused;
    public List<Stage> stages;
    public Stage currentStage;
    public int currentStageIndex = 0;

    public float timeSinceStart = 0f;
    [SerializeField] float spawnFrequency = 5f;
    float timer;

    public int platformsAlive = 0;

    void LateUpdate() {
        timeSinceStart += Time.deltaTime;
    }

    void IncreasePlatformCount() {
        platformsAlive++;
    }

    void DecreasePlatformCount() {
        platformsAlive--;
    }

    void Update() {
        if (currentStageIndex < stages.Count-1 && timeSinceStart >= stages[currentStageIndex+1].activationSecond) {
            currentStage = stages[currentStageIndex+1];
            currentStageIndex++;
            platformSpawner.ReadStageData(currentStage);
        }
        
        timer += Time.deltaTime;
        if (timer >= currentStage.platformSpawnFrequency && platformsAlive < currentStage.maxPlatformsOnMap) {
            platformSpawner.SpawnPlatform();
            timer = 0;
        }
    }

    void Start() {
        //Cursor.visible = false;
        currentStage = stages[0];
        gameIsPaused = false;
        //EventManager.instance.onEnemyDied += IncreaseMoney;
        EventManager.instance.onPlatformSpawned += IncreasePlatformCount;
        EventManager.instance.onPlatformDestroyed += DecreasePlatformCount;

        /*for (int i = 0; i < 10; i++) {
            platformSpawner.SpawnPlatform();
        }*/
        platformSpawner.ReadStageData(currentStage);
    }
    

    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*void IncreaseMoney() {
        int money = PlayerPrefs.GetInt("money");
        money++;
        PlayerPrefs.SetInt("money", money);
        EventManager.instance.MoneyChanged(money);
    }*/

    public void StopGame()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    
    public void StartGame()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    
    public bool GameIsPaused => gameIsPaused;
}