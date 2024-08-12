using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLoopAchievement : Achievement
{
    private ClickSfxPlayer sfxPlayer;

    public override void StartTrackingAchievement()
    {
        sfxPlayer = GameObject.FindObjectOfType<ClickSfxPlayer>();
        m_nuggetClickHandler.LeftClickHeld += OnClickHeldOnce;
    }

    private void OnClickHeldOnce()
    {
        m_nuggetClickHandler.LeftClickHeld -= OnClickHeldOnce;

        m_nuggetModelController.ShowModel(NuggetModelController.NuggetModelType.NUMBER3);

        sfxPlayer.PlayLeftClickNuggetHoldSfx();

        m_nuggetClickHandler.LeftClickHeld += OnClickHeldTwice;
    }

    private void OnClickHeldTwice()
    {
        m_nuggetClickHandler.LeftClickHeld -= OnClickHeldTwice;

        m_nuggetModelController.ShowModel(NuggetModelController.NuggetModelType.NUMBER1);
        sfxPlayer.PlayLeftClickNuggetHoldSfx();

        m_nuggetClickHandler.LeftClickHeld += OnClickHeldThrice;
    }

    private void OnClickHeldThrice()
    {
        m_nuggetClickHandler.LeftClickHeld -= OnClickHeldThrice;

        m_nuggetModelController.ShowModel(NuggetModelController.NuggetModelType.NUMBER4);
        sfxPlayer.PlayLeftClickNuggetHoldSfx();

        m_nuggetClickHandler.LeftClickHeld += OnClickHeldFourTimes;
    }

    private void OnClickHeldFourTimes()
    {
        m_nuggetClickHandler.LeftClickHeld -= OnClickHeldFourTimes;

        m_nuggetModelController.ShowModel(NuggetModelController.NuggetModelType.DEFAULT);
        sfxPlayer.PlayLeftClickNuggetHoldSfx();

        StartCoroutine(WaitAndReset());
    }

    private IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(3f);
        StartTrackingAchievement();
    }
}
