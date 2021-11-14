using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLimits : MonoBehaviour
{
    PlayerInputs _playerInputs;

    [Header("X Movement Limits")]
    public float leftSide;
    public float rightSide;

    private float _distToGround;

    void Start()
    {
        _playerInputs = GetComponent<PlayerInputs>();
        _distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
    }

    public bool IsPlayerInBoundary()
    {
        if (this.gameObject.transform.position.x >= leftSide &&
        this.gameObject.transform.position.x <= rightSide)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsPlayerAllowedToMove()
    {
        if (this.gameObject.transform.position.x <= leftSide && _playerInputs.horizontalInput.x > 0)
        {
            return true;

        }
        // check if player in right boundary and press left direction then allow to player move
        else if (this.gameObject.transform.position.x >= rightSide && _playerInputs.horizontalInput.x < 0)
        {
            return true;

        }
        else
        {
            return false;
        }
    }
    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _distToGround + 0.1f);
    }
}
