using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveLetterAchievement : Achievement
{
    [SerializeField]
    private int m_numMiddleClicksRequired = 20;

    [SerializeField]
    private GameObject m_heartParticlePrefab;

    [SerializeField]
    private AudioClip m_romanceAudioClip;

    [SerializeField]
    private Button m_resetButton;

    [SerializeField]
    private Button m_loveLetterButton;

    [SerializeField]
    private Color m_pinkBgColor;

    private ParticleSystem m_heartParticleSystem;

    private AudioClip m_originalBgm;

    private AudioSource m_bgmSource;

    private int m_numTimesClicked = 0;

    private LoveLetterUiController m_loveLetterUiController;

    private MeshRenderer m_bgRenderer;

    private ClickDetector m_clickDetector;

    public override void StartTrackingAchievement()
    {
        m_numTimesClicked = 0;
        m_bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        m_originalBgm = m_bgmSource.clip;
        m_nuggetClickHandler.MiddleClicked += OnNuggetClicked;
        m_loveLetterUiController = GameObject.FindObjectOfType<LoveLetterUiController>();
        m_clickDetector = GameObject.FindObjectOfType<ClickDetector>();
        m_bgRenderer = GameObject.Find("BG").GetComponent<MeshRenderer>();
    }

    private void OnNuggetClicked()
    {
        if (null == m_heartParticleSystem)
        {
            m_heartParticleSystem = GameObject.Instantiate(m_heartParticlePrefab, m_nuggetClickHandler.transform).GetComponent<ParticleSystem>();
        }
        m_heartParticleSystem.Play();
        m_numTimesClicked++;
        if (m_numTimesClicked >= m_numMiddleClicksRequired)
        {
            Destroy(m_heartParticleSystem);
            m_nuggetClickHandler.MiddleClicked -= OnNuggetClicked;
            m_nuggetModelController.ShowModel(NuggetModelController.NuggetModelType.HEART);
            m_bgmSource.Stop();
            m_bgmSource.clip = m_romanceAudioClip;
            m_bgmSource.Play();
            m_resetButton.gameObject.SetActive(false);
            m_loveLetterButton.onClick.AddListener(OnLoveLetterButtonPressed);
            m_loveLetterButton.gameObject.SetActive(true);
        }
    }

    private void OnLoveLetterButtonPressed()
    {
        m_loveLetterButton.onClick.RemoveListener(OnLoveLetterButtonPressed);
        m_loveLetterUiController.LoveLetterFailed += OnLoveLetterFailed;
        m_loveLetterUiController.LoveLetterSucceeded += OnLoveLetterSucceeded;
        m_loveLetterUiController.ShowLoveNotePanel();
    }

    private void OnLoveLetterFailed()
    {
        m_loveLetterUiController.LoveLetterFailed -= OnLoveLetterFailed;
        m_bgmSource.Stop();
        m_bgmSource.clip = m_originalBgm;
        m_bgmSource.Play();
        m_loveLetterButton.gameObject.SetActive(false);
        m_resetButton.gameObject.SetActive(true);
        m_nuggetClickHandler.Reset();
        m_backgroundClickHandler.Reset();

        StartTrackingAchievement();
    }

    private void OnLoveLetterSucceeded()
    {
        m_clickDetector.DisableClicks();
        StartCoroutine(FadeBGToPink(3f));
    }

    private IEnumerator FadeBGToPink(float fadeTime)
    {
        float timer = 0f;
        Color originalColor = m_bgRenderer.material.color;
        while (timer < fadeTime)
        {
            float timeProgress = timer / fadeTime;
            Color color = Color.Lerp(originalColor, m_pinkBgColor, timeProgress);
            m_bgRenderer.material.color = color;
            timer += Time.deltaTime;
            yield return null;
        }
        m_clickDetector.EnableClicks();
        m_loveLetterButton.gameObject.SetActive(false);
        m_resetButton.gameObject.SetActive(true);
        InvokeCompletedEvent(this);
    }
}
