using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 5.0F;
    private Rigidbody playerRB;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey((KeyCode.D)))
        {
            playerRB.AddForce( moveSpeed * Vector3.forward);
        }
        
        if (Input.GetKey((KeyCode.A)))
        {
            playerRB.AddForce( moveSpeed * Vector3.back);
        }
        
        if (Input.GetKey((KeyCode.Space)))
        {
            playerRB.AddForce( jumpForce * Vector3.up);
        }
    }
}
