using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    
    [Header("Player's Speed")]
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * Time.fixedDeltaTime * forwardSpeed;

        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 horizontalMove = m_Input * sideSpeed * Time.fixedDeltaTime;

        m_Rigidbody.MovePosition(transform.position + forwardMove + horizontalMove);
    }
}
