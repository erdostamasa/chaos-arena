using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Toggle toggle;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] GameObject optionsMenuUi;
    [SerializeField] GameObject mainMenuUi;

    void Start()
    {
        OptionsController.FXAAVariable = toggle.isOn;
        OptionsController.Volume = (int) slider.value;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && optionsMenuUi.activeSelf)
        {
            Back();
        }
    }

    public void OnVolumeSliderValueChanged()
    {
        volumeText.text = slider.value.ToString("0");
        OptionsController.Volume = (int) slider.value;
    }

    public void OnFXAACheckBoxValueChanged()
    {
        OptionsController.FXAAVariable = toggle.isOn;
    }

    public void Back()
    {
        optionsMenuUi.SetActive(false);
        mainMenuUi.SetActive(true);
        Debug.Log(OptionsController.FXAAVariable);
        Debug.Log(OptionsController.Volume);
    }
    
}
