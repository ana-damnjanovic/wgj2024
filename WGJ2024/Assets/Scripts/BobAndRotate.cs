using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobAndRotate : MonoBehaviour
{
    [SerializeField]
    private float m_bobDistance = 1f;

    [SerializeField]
    private float m_bobSpeed = 0.5f;

    [SerializeField]
    private float m_rotationSpeed = 0.5f;

    private float m_initialHeight;

    private void Start()
    {
        m_initialHeight = transform.position.y;   
    }

    void Update()
    {
        float height = m_initialHeight +  Mathf.Sin( Time.time * m_bobSpeed ) * m_bobDistance;
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
        transform.Rotate(Vector3.forward * m_rotationSpeed * Time.deltaTime);
    }
}
