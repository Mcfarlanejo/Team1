using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    
    public AudioClip backgroundMusic;
    public AudioClip inGameMusic;
    public AudioClip btnClick;
    public AudioClip backBtnClick;

    public static soundManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void PlayInGameBGM()
    {
        musicSource.clip = inGameMusic;
        musicSource.Play();
    }

    public void PlayMenuBGM()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void ButtonClick()
    {
        sfxSource.clip = btnClick;
        sfxSource.Play();
        sfxSource.loop = false;
    }

    public void BackBtnClick()
    {
        sfxSource.clip = backBtnClick;
        sfxSource.Play();
        sfxSource.loop = false;
    }
}
