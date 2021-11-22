using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleAI : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] private float _personSpeed;
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;
    public float jumpForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PersonMovement();
    }

    private void PersonMovement()
    {
        Vector3 forwardMove = transform.forward * Time.fixedDeltaTime * forwardSpeed;
        _rigidbody.MovePosition(transform.position + forwardMove);
    }

    private void AvoidObstacle()
    {
        // private void OnTriggerEnter(Collider collision)
        // {
        //     if (collision.CompareTag("Obstacle"))
        //     {
        //         Debug.Log(collision.transform.position.x);
        //     }
        // }
    }

    void OnCollisionEnter(Collision other)
    {
        // detect obstacle
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(other.transform.position.x);
        }
    }

}
