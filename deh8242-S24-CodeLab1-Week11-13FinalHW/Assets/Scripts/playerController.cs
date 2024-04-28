using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (other.gameObject.CompareTag("targetA"))
        {
            gameManager.instance.letterBank.Push("a");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetB"))
        {
            gameManager.instance.letterBank.Push("b");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        } 
        
        if (other.gameObject.CompareTag("targetC"))
        {
            gameManager.instance.letterBank.Push("c");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }


        if (other.gameObject.CompareTag("goalBlock"))
        {
            if (gameManager.instance.wordBank.ContainsKey(gameManager.instance.letterBankText.text))
            {
                Debug.Log("Job Nice! Next Level Get!");
                Debug.Log(gameManager.instance.wordBank["cab"]);
                //gameManager.instance.levelNum++;
                asciLevelLoader.instance.CurrentLevel++;
            }

            else
            {
                Debug.Log("no no that's not it!");
            }
        }

        
    }
}
