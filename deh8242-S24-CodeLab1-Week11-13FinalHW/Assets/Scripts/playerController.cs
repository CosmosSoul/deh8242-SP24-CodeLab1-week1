using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float playerMoveSpeed = 4.0f;

    public float playerJumpForce = 25.0f;

    public float playerMaxVelocity = 8.0f;

    private Rigidbody2D playerRB;

    public bool playerIsGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRB.AddForce(playerMoveSpeed * horizontalInput * Vector2.right);

        if (playerRB.velocity.magnitude > playerMaxVelocity)
        {
            Vector2 normalizedVelocity = playerRB.velocity.normalized;
            normalizedVelocity *= playerMaxVelocity;
            playerRB.velocity = normalizedVelocity;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (playerIsGrounded))
        {
            playerRB.AddForce(new Vector2(playerRB.velocity.x, playerJumpForce * 15));
            playerIsGrounded = false;
            Debug.Log("boing!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            playerIsGrounded = true;
        }
    }
}