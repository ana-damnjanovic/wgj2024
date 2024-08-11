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

    private void Awake()
    {
        m_sceneLoader.LoadRequiredScenes();   
    }

    private void Start()
    {
        m_mainMenuUiController = GameObject.FindObjectOfType<MainMenuUiController>();
        m_mainMenuUiController.StartGameRequested += OnStartGameRequested;

        m_clickDetector = GameObject.FindObjectOfType<ClickDetector>();
    }

    private void OnStartGameRequested()
    {
        m_mainMenuUiController.StartGameRequested -= OnStartGameRequested;
        m_clickDetector.EnableClicks();
    }
}
