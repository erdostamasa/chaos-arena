using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour {

    void Start() {
        if (SceneInfoPasser.exitedGame) {
            GetComponent<Animator>().Play("gameOut");
            SceneInfoPasser.exitedGame = false;
        }
    }
    
    public void ZoomShop() {
        GetComponent<Animator>().Play("shopIn");
    }

    public void BackToMenu() {
        GetComponent<Animator>().Play("shopOut");
    }

    public void GameIn() {
        GetComponent<Animator>().Play("gameIn");
    }

    public void OptionsIn() {
        GetComponent<Animator>().Play("optionsIn");
    }
    
    public void OptionsOut() {
        GetComponent<Animator>().Play("optionsOut");
    }

    public void HelpIn() {
        GetComponent<Animator>().Play("helpIn");
    }

    public void HelpOut() {
        GetComponent<Animator>().Play("helpOut");
    }

}