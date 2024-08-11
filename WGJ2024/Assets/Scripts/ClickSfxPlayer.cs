using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSfxPlayer : MonoBehaviour
{
    [SerializeField]
    AudioClip[] m_regularClicks;

    [SerializeField]
    AudioClip m_leftClickNuggetHoldSfx;

    [SerializeField]
    private AudioSource m_audioSource;

    public void PlayClickSfx()
    {
        m_audioSource.pitch = Random.Range(1f, 1.25f);
        m_audioSource.PlayOneShot(m_regularClicks[Random.Range(0, m_regularClicks.Length)], 1.0f);
    }

    public void PlayLeftClickNuggetHoldSfx()
    {
        m_audioSource.pitch = Random.Range(1f, 1.25f);
        m_audioSource.PlayOneShot(m_leftClickNuggetHoldSfx, 1.5f);
    }
    
}
