using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gamePiece : MonoBehaviour
{
    public GameObject gridSpace;
    private SpriteRenderer piece_SpriteRenderer;
    public GameManager gameManager;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //get sprite renderer for manipulation later
        piece_SpriteRenderer = GetComponent<SpriteRenderer>();
        //gameManager = GameObject.Find("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("enemy"))
        {
            //if gameObject exists, change color on click, reduce enemy health by 1, and log a message to the console
            Debug.Log("you got a HIT!" + gameObject.transform.position);
            piece_SpriteRenderer.color = new Color(0.1f, 0.5339f, 1f);
            gameManager.enemyHealth--;
            Debug.Log(gameManager.enemyHealth);
            //gameObject.SetActive(false); 
            //= Color.red;
        }
        else
        {
            piece_SpriteRenderer.color = Color.red;
        }
 
        //Destroy(gameObject);
    }
}
