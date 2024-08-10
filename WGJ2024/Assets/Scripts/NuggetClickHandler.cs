using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetClickHandler : MonoBehaviour, IClickHandler
{
    //TODO: detect when achievement is reached and stop handling that click type

    private Coroutine m_mouseDragCoroutine;
    private BobAndRotate m_bobbingAndRotation;
    private Vector3 m_originalPosition;

    public event System.Action LeftClicked = delegate { };

    public event System.Action RightClicked = delegate { };
   
    public event System.Action MiddleClicked = delegate { };

    private void Start()
    {
        m_bobbingAndRotation = GetComponent<BobAndRotate>();
        m_originalPosition = transform.position;
    }

    public void Reset()
    {
        transform.localScale = Vector3.one * 100f;
        transform.position = m_originalPosition;
    }

    public void HandleSingleLeftClick()
    {
        LeftClicked.Invoke();
    }

    public void HandleMultiLeftClick()
    {
        transform.localScale *= 1.05f;
    }

    public void HandleSingleRightClick()
    {
        RightClicked.Invoke();
    }

    public void HandleMultiRightClick()
    {
        transform.localScale *= 0.9f;
    }

    public void HandleMiddleClick()
    {
        MiddleClicked.Invoke();
    }

    public void HandleMiddleClickHold()
    {
        m_bobbingAndRotation.enabled = false;
        m_mouseDragCoroutine = StartCoroutine(MouseDrag());

    }

    public void HandleMiddleClickHoldReleased()
    {
        StopCoroutine(m_mouseDragCoroutine);
        m_mouseDragCoroutine = null;
        m_bobbingAndRotation.enabled = true;
    }

    private IEnumerator MouseDrag()
    {
        while(true)
        {
            float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Mathf.Max(Input.mousePosition.y, 0f), distanceToScreen));
            yield return null;
        }

    }
}
