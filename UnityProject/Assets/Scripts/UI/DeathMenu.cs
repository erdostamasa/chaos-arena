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

    void LoadDeathMenu() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        deathMenuUi.SetActive(true);
        GameManager.instance.StopGame();
    }

    public void LoadMenu() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        deathMenuUi.SetActive(false);
        GameManager.instance.StartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void LoadShop()
    {
        deathMenuUi.SetActive(false);
        GameManager.instance.StartGame();
        PlayerPrefs.SetInt("ShopMenuVariable",1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RestartGame()
    {
        GameManager.instance.RestartGame();
    }
}