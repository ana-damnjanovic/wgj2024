using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField]
    private Achievement[] m_achievements;

    [SerializeField]
    private TextMeshProUGUI m_achievementNumDisplay;

    [SerializeField]
    private AudioClip m_bgm;

    private List<Achievement> m_completedAchievements = new();

    private AchievementPopupUiController m_uiController;

    private NuggetClickHandler m_nuggetClickHandler;
    private NuggetModelController m_nuggetModelController;
    private BackgroundClickHandler m_backgroundClickHandler;
    private ClickDetector m_clickDetector;
    private AudioSource m_bgmSource;

    private int m_numCompleted = 0;

    public List<Achievement> GetCompletedAchievements => m_completedAchievements;

    public int NumTotalAchievements => m_achievements.Length - 1;

    public void Initialize()
    {
        m_uiController = GameObject.FindObjectOfType<AchievementPopupUiController>();
        m_uiController.AchievementPopupCompleted += OnAchievementPopupCompleted;

        m_nuggetClickHandler = GameObject.FindObjectOfType<NuggetClickHandler>();
        m_nuggetModelController = GameObject.FindObjectOfType<NuggetModelController>();
        m_backgroundClickHandler = GameObject.FindObjectOfType<BackgroundClickHandler>();
        m_clickDetector = GameObject.FindObjectOfType<ClickDetector>();
        m_bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        Achievement.SetNuggetClickHandler(m_nuggetClickHandler);
        Achievement.SetNuggetModelController(m_nuggetModelController);
        Achievement.SetBackgroundClickHandler(m_backgroundClickHandler);

        int numAchievements = m_achievements.Length;
        for (int iAchievement = 0; iAchievement < numAchievements; ++iAchievement)
        {
            if (!m_achievements[iAchievement].IsCompleted)
            {
                m_achievements[iAchievement].AchievementCompleted += OnAchievementCompleted;
                m_achievements[iAchievement].StartTrackingAchievement();
            }
        }
    }

    private void OnAchievementCompleted(Achievement achievement)
    {
        m_clickDetector.DisableClicks();
        achievement.AchievementCompleted -= OnAchievementCompleted;
        if (!achievement.IsCompleted)
        {
            m_bgmSource.Stop();
            Time.timeScale = 0f;
            achievement.MarkAsCompleted();
            m_numCompleted++;
            m_completedAchievements.Add(achievement);
            m_uiController.ShowAchievement(achievement.AchievementTitle, achievement.AchievementDescription);
            m_achievementNumDisplay.text = m_numCompleted.ToString();
        }
        achievement.StartTrackingAchievement();
    }

    private void OnAchievementPopupCompleted()
    {
        m_bgmSource.PlayOneShot(m_bgm);
        Time.timeScale = 1f;
        m_clickDetector.EnableClicks();
        m_nuggetClickHandler.Reset();
        m_backgroundClickHandler.Reset();
    }
}
