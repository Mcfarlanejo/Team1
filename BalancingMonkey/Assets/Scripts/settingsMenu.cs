using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public float music;
    public float sfx;

    public void Start() {
        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("sfxVolume")) {
            LoadSoundSettings();

        } else {
            changeMusicSound(music);
            changeSFXSound(sfx);
        }
    }

    public void changeMusicSound(float sound)
    {
        music = sound;
        musicSlider.value = sound;
        audioMixer.SetFloat("music", sound);
        PlayerPrefs.SetFloat("musicVolume", sound);
    }

    public void changeSFXSound(float sound)
    {
        sfx = sound;
        sfxSlider.value = sound;
        audioMixer.SetFloat("sfx", sound);
        PlayerPrefs.SetFloat("sfxVolume", sound);
    }

    public void LoadSoundSettings()
    {
        music = PlayerPrefs.GetFloat("musicVolume");
        sfx = PlayerPrefs.GetFloat("sfxVolume");
        changeMusicSound(music);
        changeSFXSound(sfx);
    }
}
