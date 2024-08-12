using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundClickHandler : MonoBehaviour, IClickHandler
{
    public event System.Action LeftClicked = delegate { };

    public event System.Action RightClicked = delegate { };

    public event System.Action MiddleClicked = delegate { };

    private MeshRenderer m_meshRenderer;
    private Material m_originalMaterial;

    private void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_originalMaterial = new Material(m_meshRenderer.material);
    }

    public void HandleMiddleClick()
    {
        
    }

    public void HandleMiddleClickHold()
    {
        
    }

    public void HandleMiddleClickHoldReleased()
    {
        
    }

    public void HandleMultiLeftClick()
    {
        
    }

    public void HandleMultiRightClick()
    {
        
    }

    public void HandleSingleLeftClick()
    {
        LeftClicked.Invoke();
    }

    public void HandleSingleRightClick()
    {
        RightClicked.Invoke();
    }

    public void Reset()
    {
        m_meshRenderer.material = m_originalMaterial;
        m_originalMaterial = new Material(m_meshRenderer.material);
    }

    public void HandleLeftClickHold()
    {
        
    }

    public void HandleLeftClickHoldReleased()
    {
        
    }
}
