using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // Speed of the player
    public float jumpHeight = 2f;   // Jump height
    public Camera playerCamera;

    private CharacterController controller;
    private Vector3 velocity;
    public bool isGrounded;

    Rigidbody rb;

    GameObject _camera;

    KeyCode forward = KeyCode.W;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;
    KeyCode back = KeyCode.S;
    KeyCode jump = KeyCode.Space;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {

        

        // DO NOT KEEP HEREEEEEEEEE!!!!!!!!!!!
        if (Input.GetKey(forward))
        {
            //Debug.Log("pressing forward");
            MoveForward();
        }
        else
        {
            //Debug.Log("Not pressing forward");
        }

        if (Input.GetKey(back))
        {
            MoveBackwards();
        }

        if (Input.GetKey(left))
        {
            MoveLeft();
        }

        if (Input.GetKey(right))
        {
            MoveRight();
        }

        if (Input.GetKey(jump))
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public void MoveForward()
    {
        //rb.velocity = transform.forward * moveSpeed;
        //rb.AddForce(transform.forward.normalized * moveSpeed * 3f, ForceMode.Force);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void MoveLeft()
    {
        transform.position -= transform.right * moveSpeed * Time.deltaTime;

    }

    public void MoveRight()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;

    }

    public void MoveBackwards()
    {
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;


    }

    public void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.AddForce(transform.up * jumpHeight * 200f, ForceMode.Force);
        }

    }
}

