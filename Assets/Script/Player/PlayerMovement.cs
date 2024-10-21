using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // Speed of the player
    public float jumpHeight = 2f;   // Jump height
    public Camera playerCamera;

    private CharacterController controller;
    private Vector3 velocity = new Vector3(0, 0, 0);
    public bool isGrounded;

    Rigidbody rb;

    GameObject _camera;

    bool _isPaused = false;

    [SerializeField]
    private GameObject _pauseMenu;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            if (_isPaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Time.timeScale = 1;
                _pauseMenu.SetActive(false);

                _isPaused = false;
            }
            else if (!_isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0;
                _pauseMenu.SetActive(true);

                _isPaused = true;
            }
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
        rb.AddForce(transform.forward.normalized * moveSpeed * 10f * Time.deltaTime, ForceMode.Force);

        //transform.position += transform.forward * moveSpeed * Time.deltaTime;  
    }

    public void MoveLeft()
    {
        rb.AddForce(-transform.right.normalized * moveSpeed * 10f * Time.deltaTime, ForceMode.Force);

        //transform.position -= transform.right * moveSpeed * Time.deltaTime;

    }

    public void MoveRight()
    {
        //transform.position += transform.right * moveSpeed * Time.deltaTime;

        rb.AddForce(transform.right.normalized * moveSpeed * 10f * Time.deltaTime, ForceMode.Force);


    }

    public void MoveBackwards()
    {
        //transform.position -= transform.forward * moveSpeed * Time.deltaTime;

        rb.AddForce(-transform.forward.normalized * moveSpeed * 10f * Time.deltaTime, ForceMode.Force);

    }

    public void Shoot()
    {

    }

    public void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.AddForce(transform.up.normalized * jumpHeight * 200f, ForceMode.Force);
        }

    }
}

