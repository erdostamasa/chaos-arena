using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopMenuUi;
    [SerializeField] Animator transition;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && shopMenuUi.activeSelf)
        {
            Back();
        }
    }
    
    public void Back()
    {
        StartCoroutine(BackHelp());
    }
    
    IEnumerator BackHelp()
    {
        transition.SetTrigger("ShopOut");
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("MainIn");
    }
}
