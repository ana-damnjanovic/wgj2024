using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyNuggetAchievement : Achievement
{
    [SerializeField]
    private float m_nuggetScaleRequirement = 6f;

    public override void StartTrackingAchievement()
    {
        m_nuggetClickHandler.LeftClicked += OnNuggetClicked;
    }

    private void OnNuggetClicked()
    {
        m_nuggetModelController.ScaleModel(0.8f);
        m_nuggetClickHandler.ScaleCollider(0.95f);
        if (m_nuggetModelController.GetActiveModel().transform.localScale.x <= m_nuggetScaleRequirement)
        {
            m_nuggetModelController.ScaleModel(0f);
            m_nuggetClickHandler.LeftClicked -= OnNuggetClicked;
            InvokeCompletedEvent(this);
        }
    }
}
