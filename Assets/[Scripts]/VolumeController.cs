using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    public TMP_Text volumeValueTextUI ;

    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeValueTextUI.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("GameVolumeValue", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("GameVolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
