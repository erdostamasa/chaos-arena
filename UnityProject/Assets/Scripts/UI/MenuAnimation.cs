using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour {
    Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
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

}