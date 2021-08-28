using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] GameObject mainMenuUi;
    [SerializeField] GameObject image;
    
    public void Back()
    {
        StartCoroutine(BackHelp());
    }
    
    IEnumerator BackHelp()
    {
        transition.SetTrigger("ShopOut");
        yield return new WaitForSeconds(0.5f);
        mainMenuUi.SetActive(true);
        image.SetActive(true);
        transition.SetTrigger("MainIn");
    }
}
