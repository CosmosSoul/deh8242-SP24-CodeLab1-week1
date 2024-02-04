using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class coinScript : MonoBehaviour
{

   
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.instance.score++;
        transform.position = new Vector2((transform.position.x + 11), Random.Range(1, 5));
    }
}
