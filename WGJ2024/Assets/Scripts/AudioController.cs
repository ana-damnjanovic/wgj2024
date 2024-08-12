using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float slidevalue)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(slidevalue) * 20);
    }
}
