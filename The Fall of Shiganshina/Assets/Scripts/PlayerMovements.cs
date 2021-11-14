using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    Rigidbody _rigidbody;
    PlayerInputs _playerInputs;
    PlayerMovementLimits _playerMovementLimits;

    [Header("Player's Speed")]
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;
    [Header("Player's Force")]
    public float jumpForce = 20f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInputs = GetComponent<PlayerInputs>();
        _playerMovementLimits = GetComponent<PlayerMovementLimits>();
    }
    void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 forwardMove = transform.forward * Time.fixedDeltaTime * forwardSpeed;
        Vector3 horizontalMove = _playerInputs.horizontalInput * sideSpeed * Time.fixedDeltaTime;

        if (_playerInputs.jumpInput & _playerMovementLimits.isGrounded())
        {
            _rigidbody.AddForce(transform.up * jumpForce);
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
}
