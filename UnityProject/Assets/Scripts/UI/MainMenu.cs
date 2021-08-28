using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsMenuUi;
    [SerializeField] GameObject mainMenuUi;
    [SerializeField] GameObject shopMenuUi;

    public void Awake()
    {
        if (PlayerPrefs.GetInt("ShopMenuVariable")==1)
        {
            shopMenuUi.SetActive(true);
            mainMenuUi.SetActive(false);
            PlayerPrefs.SetInt("ShopMenuVariable",0);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame() {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        optionsMenuUi.SetActive(true);
        mainMenuUi.SetActive(false);
    }
    
    public void Shop()
    {
        shopMenuUi.SetActive(true);
        mainMenuUi.SetActive(false);
    }
}
