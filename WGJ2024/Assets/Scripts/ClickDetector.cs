using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetector : MonoBehaviour
{
    private RaycastHit m_hit;

    private bool m_enabled = false;

    private IClickHandler m_lastMiddleClickedHandler;

    [SerializeField]
    private ClickSfxPlayer m_clickSfxPlayer;

    [SerializeField]
    private LayerMask m_uiLayer;

    [SerializeField]
    private Camera m_raycastCamera;

    public void DisableClicks()
    {
        m_enabled = false;
    }

    public void EnableClicks()
    {
        m_enabled = true;
    }

    public void OnSingleLeftClick(InputAction.CallbackContext context)
    {
        if (m_enabled && context.performed)
        {
            Ray ray = m_raycastCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out m_hit, 100.0f))
            {
                GameObject clickedObject = m_hit.transform.gameObject;
                if (clickedObject.TryGetComponent<IClickHandler>(out IClickHandler clickHandler))
                {
                    clickHandler.HandleSingleLeftClick();
                }
            }
            m_clickSfxPlayer.PlayClickSfx();
        }
    }

    public void OnMultiLeftClick(InputAction.CallbackContext context)
    {
        if (m_enabled && context.performed)
        {
            Ray ray = m_raycastCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out m_hit, 100.0f))
            {
                GameObject clickedObject = m_hit.transform.gameObject;
                if (clickedObject.TryGetComponent<IClickHandler>(out IClickHandler clickHandler))
                {
                    clickHandler.HandleMultiLeftClick();
                }
            }

            m_clickSfxPlayer.PlayClickSfx();
        }
    }

    public void OnSingleRightClick(InputAction.CallbackContext context)
    {
        if (m_enabled && context.performed)
        {
            Ray ray = m_raycastCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out m_hit, 100.0f))
            {
                GameObject clickedObject = m_hit.transform.gameObject;
                if (clickedObject.TryGetComponent<IClickHandler>(out IClickHandler clickHandler))
                {
                    clickHandler.HandleSingleRightClick();
                }
            }

            m_clickSfxPlayer.PlayClickSfx();
        }
    }

    public void OnMultiRightClick(InputAction.CallbackContext context)
    {
        if (m_enabled && context.performed)
        {
            Ray ray = m_raycastCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out m_hit, 100.0f))
            {
                GameObject clickedObject = m_hit.transform.gameObject;
                if (clickedObject.TryGetComponent<IClickHandler>(out IClickHandler clickHandler))
                {
                    clickHandler.HandleMultiRightClick();
                }
            }
            m_clickSfxPlayer.PlayClickSfx();
        }
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        if (m_enabled && context.performed)
        {
            Debug.Log("middle click detected");
        }
        m_clickSfxPlayer.PlayClickSfx();
    }

    public void OnMiddleClickHold(InputAction.CallbackContext context)
    {
        if (m_enabled)
        {
            if (context.performed)
            {
                Ray ray = m_raycastCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out m_hit, 100.0f))
                {
                    GameObject clickedObject = m_hit.transform.gameObject;
                    if (clickedObject.TryGetComponent<IClickHandler>(out IClickHandler clickHandler))
                    {
                        m_lastMiddleClickedHandler = clickHandler;
                        clickHandler.HandleMiddleClickHold();
                    }
                }
            }
            else if (context.canceled)
            {
                if (null != m_lastMiddleClickedHandler)
                {
                    m_lastMiddleClickedHandler.HandleMiddleClickHoldReleased();
                    m_lastMiddleClickedHandler = null;
                }
            }
        }
    }
}
