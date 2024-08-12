using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementListUiController : MonoBehaviour
{
    [SerializeField]
    private AchievementManager m_achievementManager;

    [SerializeField]
    private GameObject m_unlockedAchievementPrefab;

    [SerializeField]
    private GameObject m_lockedAchievementPrefab;

    [SerializeField]
    private Transform m_contentTransform;

    private List<GameObject> m_instantiatedPrefabs = new();

    private void OnEnable()
    {
        int numTotalAchievements = m_achievementManager.NumTotalAchievements;
        List<Achievement> completedAchievements = m_achievementManager.GetCompletedAchievements;
        int numIncomplete = numTotalAchievements - completedAchievements.Count;
        for(int iCompleted = 0; iCompleted < completedAchievements.Count; ++iCompleted)
        {
            UnlockedAchievementDisplay achievementDisplay = GameObject.Instantiate(m_unlockedAchievementPrefab, m_contentTransform).GetComponent<UnlockedAchievementDisplay>();
            Achievement achievement = completedAchievements[iCompleted];
            achievementDisplay.SetTitle(achievement.AchievementTitle);
            achievementDisplay.SetDescription(achievement.AchievementDescription);
            m_instantiatedPrefabs.Add(achievementDisplay.gameObject);
        }
        for (int iLocked = 0; iLocked < numIncomplete; ++iLocked)
        {
            GameObject lockedAchievement = GameObject.Instantiate(m_lockedAchievementPrefab, m_contentTransform);
            m_instantiatedPrefabs.Add(lockedAchievement);
        }

    }

    private void OnDisable()
    {
        ClearInstances();
    }

    private void ClearInstances()
    {
        int numInstances = m_instantiatedPrefabs.Count;
        if (numInstances > 0)
        {
            for (int iInstance = 0; iInstance < numInstances; ++iInstance)
            {
                GameObject.Destroy(m_instantiatedPrefabs[iInstance]);
            }
            m_instantiatedPrefabs.Clear();
        }
    }
}
