using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    Rigidbody _rigidbody;
    PlayerInputs _playerInputs;
    PlayerMovementLimits _playerMovementLimits;

    [Header("Player's Speed")]
    public float forwardSpeed;
    public float sideSpeed;
    [Header("Player's Force")]
    public float jumpForce;

    // Player's Speed
    private float _forwardSpeed;
    private float _sideSpeed;
    private float _jumpForce;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInputs = GetComponent<PlayerInputs>();
        _playerMovementLimits = GetComponent<PlayerMovementLimits>();

        _forwardSpeed = forwardSpeed;
        _sideSpeed = sideSpeed;
        _jumpForce = jumpForce;
    }
    void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 forwardMove = transform.forward * Time.fixedDeltaTime * _forwardSpeed;
        Vector3 horizontalMove = _playerInputs.horizontalInput * _sideSpeed * Time.fixedDeltaTime;

        if (_playerInputs.jumpInput & _playerMovementLimits.isGrounded())
        {
            _rigidbody.AddForce(transform.up * _jumpForce);
        }

        // Check player is in the level boundaries
        if (_playerMovementLimits.IsPlayerInBoundary())
        {
            _rigidbody.MovePosition(transform.position + forwardMove + horizontalMove);

        }

        // Check player is allowed to move again if it is, then move
        else if (_playerMovementLimits.IsPlayerAllowedToMove())
        {
            _rigidbody.MovePosition(transform.position + forwardMove + horizontalMove);

        }

        // if neither one of them only allow to only forward movement
        else
        {
            _rigidbody.MovePosition(transform.position + forwardMove);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Obstacle") || col.collider.CompareTag("Person"))
        {
            _forwardSpeed = forwardSpeed * 0.2f;
            _sideSpeed = sideSpeed * 0.2f;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.CompareTag("Obstacle") || col.collider.CompareTag("Person"))
        {
            _forwardSpeed = forwardSpeed;
            _sideSpeed = sideSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other);
        }
    }
}
