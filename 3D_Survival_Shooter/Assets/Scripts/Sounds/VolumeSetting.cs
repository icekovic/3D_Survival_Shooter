using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;

    private AudioSource mainMenuMusic;

    private void Awake()
    {
        mainMenuMusic = GetComponent<AudioSource>();
        volumeSlider.value = 1;
    }

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    void Update()
    {
        mainMenuMusic.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("MainMenuMusicVolume", mainMenuMusic.volume);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
