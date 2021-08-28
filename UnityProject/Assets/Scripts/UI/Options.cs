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
    [SerializeField] GameObject halfImage;
    [SerializeField] GameObject image;

    void Start()
    {
        if (!PlayerPrefs.HasKey("FXAAVariable"))
        {
            PlayerPrefs.SetInt("FXAAVariable", toggle.isOn ? 1 : 0);
        }
        else
        {
            toggle.isOn = (PlayerPrefs.GetInt("FXAAVariable")==1) ? true : false;
        }

        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetInt("Volume", (int) slider.value);
        }
        else
        {
            slider.value = PlayerPrefs.GetInt("Volume");
        }
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
        PlayerPrefs.SetInt("Volume", (int) slider.value);
    }

    public void OnFXAACheckBoxValueChanged()
    {
        PlayerPrefs.SetInt("FXAAVariable", toggle.isOn ? 1 : 0);
    }

    public void Back()
    {
        StartCoroutine(BackHelp());
    }
    
    IEnumerator BackHelp()
    {
        optionsMenuUi.SetActive(false);
        image.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        mainMenuUi.SetActive(true);
        halfImage.SetActive(true);
    }
}
