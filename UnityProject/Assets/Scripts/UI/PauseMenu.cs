using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject pauseMenuUi;
    [SerializeField] GameObject deathMenuUi;
    [SerializeField] Animator transition;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !deathMenuUi.activeSelf)
        {
            if (GameManager.instance.GameIsPaused)
            {
                Resume();
                if (PlayerPrefs.GetInt("showCursor") == 0) {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Confined;
                }
            }
            else
            {
                Pause();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

	 public void Resume()
    {
        pauseMenuUi.SetActive(false);
        GameManager.instance.StartGame();
        if (PlayerPrefs.GetInt("showCursor") == 0) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        GameManager.instance.StopGame();
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadHelp());
    }

    IEnumerator LoadHelp() {
        GameManager.instance.StartGame();
        SceneInfoPasser.exitedGame = true;
        transition.SetTrigger("Start");
        pauseMenuUi.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
