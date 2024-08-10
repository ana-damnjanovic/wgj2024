using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField]
    private Achievement[] m_achievements;

    private List<Achievement> m_completedAchievements;

    private AchievementPopupUiController m_uiController;

    private NuggetClickHandler m_nuggetClickHandler;
    private BackgroundClickHandler m_backgroundClickHandler;
    private ClickDetector m_clickDetector;

    private void Start()
    {
        m_uiController = GameObject.FindObjectOfType<AchievementPopupUiController>();
        m_uiController.AchievementPopupCompleted += OnAchievementPopupCompleted;

        m_nuggetClickHandler = GameObject.FindObjectOfType<NuggetClickHandler>();
        m_backgroundClickHandler = GameObject.FindObjectOfType<BackgroundClickHandler>();
        m_clickDetector = GameObject.FindObjectOfType<ClickDetector>();
        Achievement.SetNuggetClickHandler(m_nuggetClickHandler);
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
        achievement.MarkAsCompleted();
        m_uiController.ShowAchievement(achievement.AchievementTitle, achievement.AchievementDescription);
    }

    private void OnAchievementPopupCompleted()
    {
        m_clickDetector.EnableClicks();
        m_nuggetClickHandler.Reset();
        m_backgroundClickHandler.Reset();
    }
}
