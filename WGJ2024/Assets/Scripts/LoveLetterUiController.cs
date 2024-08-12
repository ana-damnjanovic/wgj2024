using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveLetterUiController : MonoBehaviour
{
    [Header("First Panel")]
    [SerializeField]
    private GameObject m_firstLoveNotePanel;
    [SerializeField]
    private Button m_yesButton;
    [SerializeField]
    private Button m_noButton;

    [Header("Second Panel")]
    [SerializeField]
    private GameObject m_secondLoveNotePanel;
    [SerializeField]
    private Button m_wrongOption1;
    [SerializeField]
    private Button m_wrongOption2;
    [SerializeField]
    private Button m_correctOption;

    public event System.Action LoveLetterFailed = delegate { };
    public event System.Action LoveLetterSucceeded = delegate { };
    public void ShowLoveNotePanel()
    {
        m_firstLoveNotePanel.SetActive(true);
        m_yesButton.onClick.AddListener(OnYesButtonClicked);
        m_noButton.onClick.AddListener(OnNoButtonClicked);
    }

    private void OnNoButtonClicked()
    {
        m_yesButton.onClick.RemoveListener(OnYesButtonClicked);
        m_noButton.onClick.RemoveListener(OnNoButtonClicked);
        m_firstLoveNotePanel.SetActive(false);

        LoveLetterFailed.Invoke();
    }

    private void OnYesButtonClicked()
    {
        m_yesButton.onClick.RemoveListener(OnYesButtonClicked);
        m_noButton.onClick.RemoveListener(OnNoButtonClicked);

        m_wrongOption1.onClick.AddListener(OnWrongOptionClicked);
        m_wrongOption2.onClick.AddListener(OnWrongOptionClicked);
        m_correctOption.onClick.AddListener(OnCorrectOptionClicked);
        m_firstLoveNotePanel.SetActive(false);
        m_secondLoveNotePanel.SetActive(true);
    }

    private void OnWrongOptionClicked()
    {
        HideSecondPanel();
        LoveLetterFailed.Invoke();
    }

    private void OnCorrectOptionClicked()
    {
        HideSecondPanel();
        LoveLetterSucceeded.Invoke();
    }

    private void HideSecondPanel()
    {
        m_wrongOption1.onClick.RemoveListener(OnWrongOptionClicked);
        m_wrongOption2.onClick.RemoveListener(OnWrongOptionClicked);
        m_correctOption.onClick.RemoveListener(OnCorrectOptionClicked);

        m_secondLoveNotePanel.SetActive(false);
    }
}
