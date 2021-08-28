using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUi;
    [SerializeField] GameObject image;
    [SerializeField] Animator transition;
    [SerializeField] Animator camera;
    
    public void Awake()
    {
        if (PlayerPrefs.GetInt("ShopMenuVariable")==1)
        {
            mainMenuUi.SetActive(false);
            image.SetActive(false);
            StartCoroutine(AwakeHelp());
            PlayerPrefs.SetInt("ShopMenuVariable",0);
        }
    }

    IEnumerator AwakeHelp()
    {
        camera.Play("gameOut");
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(0.5f);
        camera.Play("shopIn");
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("ShopIn");
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
