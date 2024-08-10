using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetector : MonoBehaviour
{
    private RaycastHit m_hit;

    private bool m_enabled = true;

    [SerializeField]
    private LayerMask m_nuggetLayer;

    [SerializeField]
    private LayerMask m_backgroundLayer;

    public void DisableClicks()
    {
        m_enabled = false;
    }

    public void EnableClicks()
    {
        m_enabled = true;
    }

    public void OnSingleClick(InputAction.CallbackContext context)
    {
        if (m_enabled && context.performed)
        {
            Debug.Log("single click detected");
        }
    }

    public void OnDoubleClick(InputAction.CallbackContext context)
    {
        if (m_enabled && context.performed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out m_hit, 100.0f))
            {
                GameObject clickedObject = m_hit.transform.gameObject;
                if (((1<<clickedObject.layer) & m_nuggetLayer) != 0)
                {
                    // scale down nugget
                    clickedObject.transform.localScale *= 0.95f;
                }
                else if (((1 << clickedObject.layer) & m_backgroundLayer) != 0)
                {
                    Debug.Log("double clicked on background");
                }
            }
        }
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (m_enabled && context.performed)
        {
            Debug.Log("right click detected");
        }
    }

    public void OnDoubleRightClick(InputAction.CallbackContext context)
    {
        if (m_enabled && context.performed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out m_hit, 100.0f))
            {
                GameObject clickedObject = m_hit.transform.gameObject;
                if (((1 << clickedObject.layer) & m_nuggetLayer) != 0)
                {
                    // scale up nugget
                    clickedObject.transform.localScale *= 1.05f;
                }
                else if (((1 << clickedObject.layer) & m_backgroundLayer) != 0)
                {
                    Debug.Log("double right clicked on background");
                }
            }
        }
    }
}
