using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    [Header("Player's Speed")]
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;
    [Header("Player's Force")]
    public float jumpForce = 20f;

    public bool isGrounded = true; 

    private Vector3 _horizontalInput;
    public bool _jumpInput;
    private bool _isInBoundary;
    private bool _isPlayerCanMove;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _horizontalInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        _jumpInput = Input.GetButton("Jump");

        _isInBoundary = IsPlayerInBoundary();
        _isPlayerCanMove = IsPlayerAllowedToMove();
    }

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * Time.fixedDeltaTime * forwardSpeed;
        Vector3 horizontalMove = _horizontalInput * sideSpeed * Time.fixedDeltaTime;

        if (_jumpInput & isGrounded)
        {
            m_Rigidbody.AddForce(transform.up * jumpForce);
        }

        if (_isInBoundary)
        {
            m_Rigidbody.MovePosition(transform.position + forwardMove + horizontalMove);

        }

        // Check player is allowed to move again if it is then move
        else if (_isPlayerCanMove)
        {
            m_Rigidbody.MovePosition(transform.position + forwardMove + horizontalMove);

        }

        // if neither one of them only allow to only forward movement
        else
        {
            m_Rigidbody.MovePosition(transform.position + forwardMove);
        }
    }

    bool IsPlayerInBoundary()
    {
        if (this.gameObject.transform.position.x >= -3f &&
        this.gameObject.transform.position.x <= 3f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsPlayerAllowedToMove()
    {
        if (this.gameObject.transform.position.x <= -3f && _horizontalInput.x > 0)
        {
            return true;

        }
        // check if player in right boundary and press left direction then allow to player move
        else if (this.gameObject.transform.position.x >= 3f && _horizontalInput.x < 0)
        {
            return true;

        }
        else
        {
            return false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
