using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        
        //normalize player movement so player velocity can't go above a certain threshold
        if (playerRB.velocity.magnitude > playerMaxVelocity)
        {
            Vector2 normalizedVelocity = playerRB.velocity.normalized;
            normalizedVelocity *= playerMaxVelocity;
            playerRB.velocity = normalizedVelocity;
        }
        // player can only jump when pressing spacebar and grounded check is true; player is not allowed to double jump...maybe they can do other tricks though ;)
        if (Input.GetKeyDown(KeyCode.Space) && (playerIsGrounded))
        {
            playerRB.AddForce(new Vector2(playerRB.velocity.x, playerJumpForce * 15));
            playerIsGrounded = false;
            Debug.Log("boing!");
        }
    }

    //while player is in contact with ground, they are considered grounded (jumping while in mid-ar prevention measure)
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            playerIsGrounded = true;
        }

        /*
        string target = "";

        switch (target)
        {
            case "targetA":
                gameManager.instance.letterBank.Push("a");
                Debug.Log(gameManager.instance.letterBank.Count);
                gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
                break;
            case "targetB":
                gameManager.instance.letterBank.Push("b");
                Debug.Log(gameManager.instance.letterBank.Count);
                gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
                break;
            case "targetC":
                gameManager.instance.letterBank.Push("c");
                Debug.Log(gameManager.instance.letterBank.Count);
                gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
                break;
            case "targetD":
                gameManager.instance.letterBank.Push("d");
                Debug.Log(gameManager.instance.letterBank.Count);
                gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
                break;
            default:
                break;
                
    }
    */
        
        //ran of out time to experiment and find a way to combine a switch statement with a compare tag check
        // checks for tag of gameObject and adds the appropriate letter to the letterBank Stack and then immediately removes that letter with a pop and adds it to letterBankText.text
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
        
        if (other.gameObject.CompareTag("targetD"))
        {
            gameManager.instance.letterBank.Push("d");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        if (other.gameObject.CompareTag("targetE"))
        {
            gameManager.instance.letterBank.Push("e");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetF"))
        {
            gameManager.instance.letterBank.Push("f");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetG"))
        {
            gameManager.instance.letterBank.Push("g");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetH"))
        {
            gameManager.instance.letterBank.Push("h");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetI"))
        {
            gameManager.instance.letterBank.Push("i");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetJ"))
        {
            gameManager.instance.letterBank.Push("j");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetK"))
        {
            gameManager.instance.letterBank.Push("k");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetL"))
        {
            gameManager.instance.letterBank.Push("l");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetM"))
        {
            gameManager.instance.letterBank.Push("m");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetN"))
        {
            gameManager.instance.letterBank.Push("n");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetO"))
        {
            gameManager.instance.letterBank.Push("o");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetP"))
        {
            gameManager.instance.letterBank.Push("p");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetQ"))
        {
            gameManager.instance.letterBank.Push("q");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetR"))
        {
            gameManager.instance.letterBank.Push("r");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetS"))
        {
            gameManager.instance.letterBank.Push("s");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetT"))
        {
            gameManager.instance.letterBank.Push("t");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetU"))
        {
            gameManager.instance.letterBank.Push("u");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetV"))
        {
            gameManager.instance.letterBank.Push("v");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetW"))
        {
            gameManager.instance.letterBank.Push("w");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetX"))
        {
            gameManager.instance.letterBank.Push("x");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetY"))
        {
            gameManager.instance.letterBank.Push("y");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        if (other.gameObject.CompareTag("targetZ"))
        {
            gameManager.instance.letterBank.Push("z");
            Debug.Log(gameManager.instance.letterBank.Count);
            gameManager.instance.letterBankText.text += gameManager.instance.letterBank.Pop();
        }
        
        
        //when player collides with gameObject that has goalBloc tag, if letterBankText matches one of the words in the wordBank Dictionary then letterBankText resets to empty string and level incremenets
        if (other.gameObject.CompareTag("goalBlock"))
        {
            if (gameManager.instance.wordBank.ContainsKey(gameManager.instance.letterBankText.text))
            {
                Debug.Log("Job Nice! Next Level Get!");
                Debug.Log(gameManager.instance.wordBank["cab"]);
                //gameManager.instance.levelNum++;
                gameManager.instance.letterBankText.text = "";

                asciLevelLoader.instance.CurrentLevel++;
            }
            //if letterBankText Stack does not match a key in the wordBank Dictionary then the current level resets, letterBankText also resets
            else
            {
                Debug.Log("no no that's not it!");
                asciLevelLoader.instance.LoadLevel();
                gameManager.instance.letterBankText.text = "";
            }
        }

        
    }
}
