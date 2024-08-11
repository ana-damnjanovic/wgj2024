using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetClickHandler : MonoBehaviour, IClickHandler
{
    //TODO: detect when achievement is reached and stop handling that click type

    [SerializeField]
    private Camera m_raycastCamera;

    private Coroutine m_mouseDragCoroutine;
    private BobAndRotate m_bobbingAndRotation;
    private Vector3 m_originalPosition;
    private NuggetModelController m_modelController;

    public event System.Action LeftClicked = delegate { };

    public event System.Action MultiLeftClicked = delegate { };

    public event System.Action RightClicked = delegate { };

    public event System.Action MultiRightClicked = delegate { };
   
    public event System.Action MiddleClicked = delegate { };

    private void Start()
    {
        m_bobbingAndRotation = GetComponent<BobAndRotate>();
        m_modelController = GetComponent<NuggetModelController>();
        m_originalPosition = transform.position;
    }

    public void Reset()
    {
        transform.position = m_originalPosition;
        m_modelController.ResetModels();
    }

    public void HandleSingleLeftClick()
    {
        LeftClicked.Invoke();
    }

    public void HandleMultiLeftClick()
    {
        MultiLeftClicked.Invoke();
    }

    public void HandleSingleRightClick()
    {
        RightClicked.Invoke();
    }

    public void HandleMultiRightClick()
    {
        MultiRightClicked.Invoke();
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
            float distanceToScreen = m_raycastCamera.WorldToScreenPoint(gameObject.transform.position).z;
            transform.position = m_raycastCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Mathf.Max(Input.mousePosition.y, 0f), distanceToScreen));
            yield return null;
        }

    }
}
