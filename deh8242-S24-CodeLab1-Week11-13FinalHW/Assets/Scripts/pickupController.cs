using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupController : MonoBehaviour
{
    //GameObject letterPrefab; 
    // Start is called before the first frame update
    void Start()
    {
       // Instantiate(letterPrefab);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when pickup collides with something, it should be destroyed, the score should increment and highScoreString should update
    private void OnCollisionEnter2D(Collision2D col)
    {
      
        Destroy(gameObject);
       // gameManager.instance.Score++;
        Debug.Log(gameManager.instance.highScoreString);
    }
}
