using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetClickHandler : MonoBehaviour, IClickHandler
{
 
    [SerializeField]
    private Camera m_raycastCamera;

    private Coroutine m_mouseDragCoroutine;
    private BobAndRotate m_bobbingAndRotation;
    private Vector3 m_originalPosition;
    private NuggetModelController m_modelController;
    private CapsuleCollider m_collider;
    private float m_originalColliderRadius;
    private float m_originalColliderHeight;

    public event System.Action LeftClicked = delegate { };

    public event System.Action LeftClickHeld = delegate { };
    public event System.Action LeftClickHoldReleased = delegate { };

    public event System.Action MultiLeftClicked = delegate { };

    public event System.Action RightClicked = delegate { };

    public event System.Action MultiRightClicked = delegate { };
   
    public event System.Action MiddleClicked = delegate { };

    private void Start()
    {
        m_bobbingAndRotation = GetComponent<BobAndRotate>();
        m_modelController = GetComponent<NuggetModelController>();
        m_originalPosition = transform.position;
        m_collider = GetComponent<CapsuleCollider>();
        m_originalColliderRadius = m_collider.radius;
        m_originalColliderHeight = m_collider.height;
    }

    public void ScaleCollider(float scaleMultiplier)
    {
        m_collider.radius *= scaleMultiplier;
        m_collider.height *= scaleMultiplier;
    }

    public void Reset()
    {
        transform.position = m_originalPosition;
        m_collider.radius = m_originalColliderRadius;
        m_collider.height = m_originalColliderHeight;
        m_modelController.ResetModels();
        m_modelController.ShowModel(NuggetModelController.NuggetModelType.DEFAULT);
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
        if (null != m_mouseDragCoroutine)
        {
            StopCoroutine(m_mouseDragCoroutine);
            m_mouseDragCoroutine = null;
            m_bobbingAndRotation.enabled = true;
        }
    }

    public void HandleLeftClickHold()
    {
        LeftClickHeld.Invoke();
    }

    public void HandleLeftClickHoldReleased()
    {
        LeftClickHoldReleased.Invoke();
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
