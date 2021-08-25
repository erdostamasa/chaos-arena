using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject pauseMenuUi;
    [SerializeField] GameObject deathMenuUi;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !deathMenuUi.activeSelf)
        {
            if (GameManager.instance.GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

	 public void Resume()
    {
        pauseMenuUi.SetActive(false);
        GameManager.instance.StartGame();
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        GameManager.instance.StopGame();
    }

    public void LoadMenu()
    {
        pauseMenuUi.SetActive(false);
        GameManager.instance.StartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
