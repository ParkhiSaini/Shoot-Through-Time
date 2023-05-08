using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Load the volume setting from player prefs
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        audioSource.volume = savedVolume;

        // Set the slider value to the saved volume
        volumeSlider.value = savedVolume;
    }

    // Called when the slider value is changed
    public void OnVolumeChanged()
    {
        audioSource.volume = volumeSlider.value;

        // Save the volume setting to player prefs
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
