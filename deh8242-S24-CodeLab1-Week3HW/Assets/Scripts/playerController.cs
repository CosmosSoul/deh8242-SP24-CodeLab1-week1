using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public static playerController isntance;
    public float moveSpeed = 5.0f;

    public float jumpForce = 35.0f;

    public float maxVelocity = 10.0f;

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

        if (playerRB.velocity.magnitude > maxVelocity)
        {
            Vector2 newVelocity = playerRB.velocity.normalized;
            newVelocity *= maxVelocity;
            playerRB.velocity = newVelocity;
        }
        
        if ((Input.GetKeyDown(KeyCode.Space)) && (isGrounded) && (GameManager.instance.gameOver == false))
        {
            
            playerRB.AddForce(new Vector2(playerRB.velocity.x, jumpForce * 20));
            isGrounded = false;
            Debug.Log("Jump!");
            
        }

    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }

    }
    
   /* private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }

    }
    */
}
