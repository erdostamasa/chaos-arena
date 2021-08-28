using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopMenuUi;
    [SerializeField] GameObject mainMenuUi;
    [SerializeField] GameObject image;
    [SerializeField] GameObject halfImage;
    
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
        shopMenuUi.SetActive(false);
        image.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        mainMenuUi.SetActive(true);
        halfImage.SetActive(true);
    }
}
