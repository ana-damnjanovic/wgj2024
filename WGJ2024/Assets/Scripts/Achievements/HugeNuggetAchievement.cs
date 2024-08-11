using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeNuggetAchievement : Achievement
{
    [SerializeField]
    private float m_nuggetScaleRequirement = 1000f;

    public override void StartTrackingAchievement()
    {
        m_nuggetClickHandler.LeftClicked += OnNuggetClicked;
    }

    private void OnNuggetClicked()
    {
        if (m_nuggetClickHandler.transform.localScale.x >= m_nuggetScaleRequirement)
        {
            m_nuggetClickHandler.LeftClicked -= OnNuggetClicked;
            InvokeCompletedEvent(this);
        }
    }
}
