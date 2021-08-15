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

    private void Update()
    {
        float HInput = Input.GetAxis("Horizontal");
        m_Rigidbody.AddForce(new Vector3(HInput*m_BallHorizontalSpeed, 0f, 1f) * m_BallSpeed);
    }
    #endregion
}
