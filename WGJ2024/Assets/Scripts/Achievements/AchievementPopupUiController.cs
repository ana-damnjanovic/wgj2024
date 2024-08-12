using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementPopupUiController : MonoBehaviour
{
    [SerializeField]
    private Canvas m_canvas;

    [SerializeField]
    private TextMeshProUGUI m_achievementTitle;

    [SerializeField]
    private TextMeshProUGUI m_achievementDescription;

    [SerializeField]
    private float m_displayTime = 5f;

    public event System.Action AchievementPopupCompleted = delegate { };

    public void ShowAchievement(string achievementTitle, string achievementDescription)
    {
        m_achievementTitle.text = achievementTitle;
        m_achievementDescription.text = achievementDescription;
        m_canvas.enabled = true;

        StartCoroutine(WaitForTimerAndHide());
    }

    private IEnumerator WaitForTimerAndHide()
    {
        yield return new WaitForSecondsRealtime(m_displayTime);
        m_canvas.enabled = false;
        AchievementPopupCompleted.Invoke();
    }
}
