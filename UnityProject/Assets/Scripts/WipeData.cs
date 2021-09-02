using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeData : MonoBehaviour {
    [SerializeField] DefaultValueSetter def;
    public void WipePlayerPrefs() {
        PlayerPrefs.DeleteAll();
        def.SetValues();
    }
}