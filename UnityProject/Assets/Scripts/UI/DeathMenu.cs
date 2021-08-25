using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] GameObject deathMenuUi;

    void Awake()
    {
        EventManager.instance.onPlayerDied += LoadDeathMenu;
    }

    void LoadDeathMenu()
    {
        deathMenuUi.SetActive(true);
        GameManager.instance.StopGame();
    }

    public void LoadMenu()
    {
        deathMenuUi.SetActive(false);
        GameManager.instance.StartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void LoadShop()
    {
        deathMenuUi.SetActive(false);
        GameManager.instance.StartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RestartGame()
    {
        GameManager.instance.RestartGame();
        
    }
}