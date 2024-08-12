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

    private List<GameObject> m_instantiatedPrefabs;

    private void OnEnable()
    {
        
    }
}
