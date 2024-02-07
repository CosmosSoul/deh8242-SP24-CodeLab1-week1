using System.Collections;
using Random = UnityEngine.Random;

using System.Collections.Generic;
using UnityEngine;
public class coinScript : MonoBehaviour
{

   
    private void OnCollisionEnter2D(Collision2D col)
    {   
        //score increments by one and new coin position randomized onn y-axis, always ahead of the player nn x-axis
        GameManager.instance.score++;
        transform.position = new Vector2((transform.position.x + 11), Random.Range(2, 3.5f));
        
        //add additional speed bonus on coin pickup
        
        /*add sound on coin pickup*/
    }
}
