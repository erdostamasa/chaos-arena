using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopMenuUi;
    [SerializeField] GameObject mainMenuUi;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && shopMenuUi.activeSelf)
        {
            Back();
        }
    }
    
    public void Back()
    {
        shopMenuUi.SetActive(false);
        mainMenuUi.SetActive(true);
    }
}
