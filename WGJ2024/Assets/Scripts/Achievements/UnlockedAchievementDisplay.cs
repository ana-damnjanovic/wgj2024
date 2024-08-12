using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockedAchievementDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_title;

    [SerializeField]
    private TextMeshProUGUI m_description;

    public void SetTitle(string title)
    {
        m_title.text = title;
    }

    public void SetDescription(string description)
    {
        m_description.text = description;
    }
}
