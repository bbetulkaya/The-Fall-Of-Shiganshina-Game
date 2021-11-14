using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{ 
    public Vector3 horizontalInput;
    public bool jumpInput;

    void Update()
    {
        horizontalInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        jumpInput = Input.GetButton("Jump");
    }
}
