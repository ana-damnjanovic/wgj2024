using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSfxPlayer : MonoBehaviour
{
    [SerializeField]
    AudioClip[] m_clicks;

    [SerializeField]
    private AudioSource m_audioSource;

    public void PlayClickSfx()
    {
        m_audioSource.pitch = Random.Range(1f, 1.25f);
        m_audioSource.PlayOneShot(m_clicks[Random.Range(0, m_clicks.Length)], 1.0f);
    }
    
}
