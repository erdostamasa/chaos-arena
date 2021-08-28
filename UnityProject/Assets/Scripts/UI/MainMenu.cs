using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUi;
    [SerializeField] GameObject shopMenuUi;
    [SerializeField] Animator transition;
    
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
        transition.SetTrigger("MainOut");
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        StartCoroutine(OptionsHelp());
    }

    IEnumerator OptionsHelp()
    {
        transition.SetTrigger("MainOut");
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("OptionsIn");
    }
    
    public void Shop()
    {
        StartCoroutine(ShopHelp());
    }
    
    IEnumerator ShopHelp()
    {
        transition.SetTrigger("MainOut");
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("ShopIn");
    }
}
