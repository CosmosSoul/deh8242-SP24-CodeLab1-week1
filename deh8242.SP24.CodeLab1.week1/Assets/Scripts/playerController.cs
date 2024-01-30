using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public float maxVelocity = 10;
    private Rigidbody playerRB;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKey((KeyCode.D)))
        {
            playerRB.AddForce( moveSpeed * Vector3.forward);
        }
        if (Input.GetKey((KeyCode.A)))
        {
            playerRB.AddForce( moveSpeed * Vector3.back);
        }
        */
      float horizontalInput = Input.GetAxis(("Horizontal"));
      
      playerRB.AddForce(moveSpeed * horizontalInput * Vector3.forward);
      
        if (Input.GetKey((KeyCode.Space)))
        {
            playerRB.AddForce( jumpForce * Vector3.up);
        }

        if (playerRB.velocity.magnitude > maxVelocity)
        {
            Vector3 newVelocity = playerRB.velocity.normalized;
            newVelocity *= maxVelocity;
            playerRB.velocity = newVelocity;
        }
        
        Debug.Log(message:"Current Velocity: " + playerRB.velocity);
        
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
}
