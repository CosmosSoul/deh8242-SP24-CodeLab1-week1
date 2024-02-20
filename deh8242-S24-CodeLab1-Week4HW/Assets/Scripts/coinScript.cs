using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class coinScript : MonoBehaviour
{

   
    private void OnCollisionEnter2D(Collision2D col)
    {   
        //score increments by one and new coin position randomized in the y, always ahead of the player
        GameManager.instance.Score++;
        transform.position = new Vector2((transform.position.x + 11f), Random.Range(2f, 3f));
        
        //add additional speed bonus on coin pickup
    }
}
