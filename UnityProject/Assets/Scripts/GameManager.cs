using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private bool gameIsPaused;
    
    void Awake() {
        instance = this;
    }

    [SerializeField] PlatformSpawner platformSpawner;
    public int money = 0;

    [SerializeField] float spawnFrequency = 5f;
    float timer;
    void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnFrequency) {
            platformSpawner.SpawnPlatform();
            timer = 0;
        }
    }

    void Start()
    {
        gameIsPaused = false;
        EventManager.instance.onEnemyDied += IncreaseMoney;

        for (int i = 0; i < 10; i++) {
            platformSpawner.SpawnPlatform();
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void IncreaseMoney() {
        money++;
        EventManager.instance.MoneyChanged(money);
    }

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