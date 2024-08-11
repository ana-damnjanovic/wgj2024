using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyNuggetAchievement : Achievement
{
    [SerializeField]
    private float m_nuggetScaleRequirement = 6f;

    public override void StartTrackingAchievement()
    {
        m_nuggetClickHandler.MultiLeftClicked += OnNuggetClicked;
    }

    private void OnNuggetClicked()
    {
        m_nuggetModelController.ScaleModel(0.9f);
        if (m_nuggetModelController.GetActiveModel().transform.localScale.x <= m_nuggetScaleRequirement)
        {
            m_nuggetClickHandler.MultiLeftClicked -= OnNuggetClicked;
            InvokeCompletedEvent(this);
        }
    }
}
