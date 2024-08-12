using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SceneLoader m_sceneLoader;

    private MainMenuUiController m_mainMenuUiController;
    private ClickDetector m_clickDetector;
    private AudioSource m_bgmSource;
    private AchievementManager m_achievementManager;

    private void Awake()
    {
        m_sceneLoader.LoadRequiredScenes();   
    }

    private void Start()
    {
        m_mainMenuUiController = GameObject.FindObjectOfType<MainMenuUiController>();
        m_mainMenuUiController.StartGameRequested += OnStartGameRequested;

        m_clickDetector = GameObject.FindObjectOfType<ClickDetector>();
        m_bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        m_achievementManager = GameObject.FindObjectOfType<AchievementManager>();
    }

    private void OnStartGameRequested()
    {
        m_mainMenuUiController.StartGameRequested -= OnStartGameRequested;
        m_achievementManager.Initialize();
        m_clickDetector.EnableClicks();
        m_bgmSource.Play();
    }
}
