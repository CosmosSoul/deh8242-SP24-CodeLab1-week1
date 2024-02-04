using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float jumpForce = 5.0f;

    public float maxVelocity = 15.0f;

    private Rigidbody2D playerRB;

    public bool isGrounded = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRB.AddForce(moveSpeed * horizontalInput * Vector2.right);

        if ((Input.GetKey(KeyCode.Space)) && (isGrounded))
        {
            
            playerRB.AddForce(jumpForce * Vector2.up);
            //isGrounded = false;
            Debug.Log("Jump!");
            
        }
    }

    void onCollisionEnter2D(Collision2D col)
    {
        //GameManager.instance.score++;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
           // isGrounded = true;
    }
}
