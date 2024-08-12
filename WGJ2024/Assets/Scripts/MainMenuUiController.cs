using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUiController : MonoBehaviour
{
    [SerializeField]
    private Canvas m_canvas;

    [SerializeField]
    private Button m_startGameButton;

    public event System.Action StartGameRequested = delegate { };

    private void Awake()
    {
        m_startGameButton.onClick.AddListener(OnStartButtonPressed);
    }

    private void OnStartButtonPressed()
    {
        m_startGameButton.onClick.RemoveListener(OnStartButtonPressed);
        m_canvas.enabled = false;
        StartGameRequested.Invoke();
    }

    //private IEnumerator WaitForTimerAndStartGame()
    //{
    //    yield return new WaitForSeconds(3f);
    //    OnStartButtonPressed();
    //}
}
