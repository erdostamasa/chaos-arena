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
        if (OptionsController.ShopMenuVariable)
        {
            shopMenuUi.SetActive(true);
            mainMenuUi.SetActive(false);
            OptionsController.ShopMenuVariable = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
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
