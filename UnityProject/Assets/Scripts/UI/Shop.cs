using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Animator transition;

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
