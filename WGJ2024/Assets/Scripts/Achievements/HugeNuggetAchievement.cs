using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeNuggetAchievement : Achievement
{
    [SerializeField]
    private float m_nuggetScaleRequirement = 950f;

    public override void StartTrackingAchievement()
    {
        m_nuggetClickHandler.MultiRightClicked += OnNuggetClicked;
    }

    private void OnNuggetClicked()
    {
        m_nuggetModelController.ScaleModel(1.05f);
        m_nuggetClickHandler.ScaleCollider(1.05f);
        if (m_nuggetModelController.GetActiveModel().transform.localScale.x >= m_nuggetScaleRequirement)
        {
            m_nuggetClickHandler.MultiRightClicked -= OnNuggetClicked;
            InvokeCompletedEvent(this);
        }
    }
}
