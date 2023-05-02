using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void changeSound(float sound)
    {
        audioMixer.SetFloat("sound", sound);
    }
}
