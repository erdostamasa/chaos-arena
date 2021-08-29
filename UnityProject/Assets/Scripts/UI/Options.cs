using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class Options : MonoBehaviour {
    [SerializeField] Slider slider;
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle toggle;
    [SerializeField] Toggle retroToggle;
    [SerializeField] Toggle cursorToggle;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] Animator transition;

    void Start() {
        if (!PlayerPrefs.HasKey("FXAAVariable")) {
            PlayerPrefs.SetInt("FXAAVariable", toggle.isOn ? 1 : 0);
        }
        else {
            toggle.isOn = (PlayerPrefs.GetInt("FXAAVariable") == 1) ? true : false;
        }

        if (!PlayerPrefs.HasKey("Volume")) {
            PlayerPrefs.SetInt("Volume", (int)slider.value);
        }
        else {
            slider.value = PlayerPrefs.GetFloat("Volume");
        }

        if (PlayerPrefs.GetInt("Retro") == 1) {
            retroToggle.isOn = true;
        }
        else {
            retroToggle.isOn = false;
        }

        if (PlayerPrefs.GetInt("showCursor") == 1) {
            cursorToggle.isOn = true;
        }
        else {
            cursorToggle.isOn = false;
        }
    }

    public void CursorToggled() {
        PlayerPrefs.SetInt("showCursor", cursorToggle.isOn ? 1 : 0);
    }

    public void MusicToggled() {
        PlayerPrefs.SetInt("Music", musicToggle.isOn ? 1 : 0);
    }

    public void RetroToggled() {
        PlayerPrefs.SetInt("Retro", retroToggle.isOn ? 1 : 0);
    }

    public void OnVolumeSliderValueChanged() {
        volumeText.text = slider.value.ToString("0");
        PlayerPrefs.SetFloat("Volume", (int)slider.value);
        EventManager.instance.VolumeChanged();
    }

    public void OnFXAACheckBoxValueChanged() {
        PlayerPrefs.SetInt("FXAAVariable", toggle.isOn ? 1 : 0);
        EventManager.instance.FXAAchanged();
    }

    public void Back() {
        StartCoroutine(BackHelp());
    }

    IEnumerator BackHelp() {
        transition.SetTrigger("OptionsOut");
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("MainIn");
    }

    public void HelpBack() {
        StartCoroutine(HelpMenuBack());
    }

    IEnumerator HelpMenuBack() {
        transition.SetTrigger("HelpOut");
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("MainIn");
    }
}