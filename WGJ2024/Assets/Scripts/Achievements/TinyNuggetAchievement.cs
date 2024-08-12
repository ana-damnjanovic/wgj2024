using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyNuggetAchievement : Achievement
{
    [SerializeField]
    private float m_nuggetScaleRequirement = 6f;

    public override void StartTrackingAchievement()
    {
        m_nuggetClickHandler.RightClicked += OnNuggetClicked;
    }

    private void OnNuggetClicked()
    {
        if (m_nuggetClickHandler.transform.localScale.x <= m_nuggetScaleRequirement)
        {
            m_nuggetClickHandler.RightClicked -= OnNuggetClicked;
            InvokeCompletedEvent(this);
        }
    }
}
