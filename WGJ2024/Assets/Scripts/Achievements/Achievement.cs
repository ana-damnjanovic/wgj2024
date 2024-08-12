using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Achievement : MonoBehaviour
{
    [SerializeField]
    private string m_achievementTitle;

    [SerializeField]
    private string m_achievementDescription;

    private bool m_completed = false;

    protected static NuggetClickHandler m_nuggetClickHandler;
    protected static NuggetModelController m_nuggetModelController;
    protected static BackgroundClickHandler m_backgroundClickHandler;

    public abstract void StartTrackingAchievement();

    public bool IsCompleted => m_completed;

    public event System.Action<Achievement> AchievementCompleted = delegate { };

    public string AchievementTitle => m_achievementTitle;

    public string AchievementDescription => m_achievementDescription;


    public static void SetNuggetClickHandler(NuggetClickHandler nuggetClickHandler)
    {
        m_nuggetClickHandler = nuggetClickHandler;
    }

    public static void SetNuggetModelController(NuggetModelController nuggetModelController)
    {
        m_nuggetModelController = nuggetModelController;
    }

    public static void SetBackgroundClickHandler(BackgroundClickHandler backgroundClickHandler)
    {
        m_backgroundClickHandler = backgroundClickHandler;
    }

    public void MarkAsCompleted()
    {
        m_completed = true;
    }

    public void InvokeCompletedEvent(Achievement achievement)
    {
        AchievementCompleted.Invoke(achievement);
    }
}

