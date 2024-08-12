using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BackgroundVideoAchievement : Achievement
{
    [SerializeField]
    private int m_numClicksToFadeOutBG = 50;

    [SerializeField]
    private int m_numClicksToFadeInVideo = 50;

    private int m_numFadeOutClicks = 0;
    private bool m_canRightClick = false;
    private int m_numFadeInClicks = 0;

    private VideoPlayer m_videoPlayer;
    private Canvas m_canvas;
    private RawImage m_videoRenderTexture;

    private MeshRenderer m_bgRenderer;

    public override void StartTrackingAchievement()
    {
        m_backgroundClickHandler.LeftClicked += OnLeftClicked;
        m_backgroundClickHandler.RightClicked += OnRightClicked;
        m_bgRenderer = m_backgroundClickHandler.GetComponent<MeshRenderer>();

        GameObject videoParent = GameObject.Find("Secret Video");
        m_videoPlayer = videoParent.GetComponentInChildren<VideoPlayer>(true);
        m_canvas = videoParent.GetComponentInChildren<Canvas>(true);
        m_videoRenderTexture = videoParent.GetComponentInChildren<RawImage>(true);
        Color renderTextureColor = m_videoRenderTexture.color;
        renderTextureColor.a = 0f;
        m_videoRenderTexture.color = renderTextureColor;
    }

    private void OnLeftClicked()
    {
        m_numFadeOutClicks++;
        float fadeProgress = (float)m_numFadeOutClicks / (float)m_numClicksToFadeOutBG;
        float opacity = Mathf.Lerp(100f, 0f, fadeProgress);
        if (m_numFadeOutClicks >= m_numClicksToFadeOutBG)
        {
            m_backgroundClickHandler.LeftClicked -= OnLeftClicked;
            opacity = 0f;
            m_canRightClick = true;
        }


        Color fadedColor = m_bgRenderer.material.color;
        fadedColor.a = opacity / 100f;
        m_bgRenderer.material.color = fadedColor;
    }

    private void OnRightClicked()
    {
        if (m_canRightClick)
        {
            m_numFadeInClicks++;
            if (m_numFadeInClicks == 1)
            {
                m_canvas.enabled = true;
                m_videoPlayer.enabled = true;
            }

            Color fadedColor = m_videoRenderTexture.color;
            float fadeProgress = (float)m_numFadeInClicks / (float)m_numClicksToFadeInVideo;
            float opacity = Mathf.Lerp(0f, 100f, fadeProgress);

            fadedColor.a = opacity / 100f;
            m_videoRenderTexture.color = fadedColor;

            if (m_numFadeInClicks >= m_numClicksToFadeInVideo)
            {
                m_backgroundClickHandler.RightClicked -= OnRightClicked;
                InvokeCompletedEvent(this);
            }
        }

    }
}
