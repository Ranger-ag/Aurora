using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerControler : MonoBehaviour
{
    #region Variables

    [Header("Ball Settings")]
    [SerializeField] private float m_BallSpeed;
    [SerializeField] private float m_BallHorizontalSpeed;

    private Rigidbody m_Rigidbody;

    #endregion

    #region UnityCallbacks

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private Vector3 GetWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    private void Update()
    {
        float HInput = Input.GetAxis("Horizontal");
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        mousePos = GetWorldPos();
        if (mousePos != Vector3.zero)
        {
            transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
            Vector3 forceVector = mousePos - transform.position;
            m_Rigidbody.AddForce(new Vector3(forceVector.x * m_BallHorizontalSpeed, 0, m_BallSpeed));
        }
    }
    #endregion
}
