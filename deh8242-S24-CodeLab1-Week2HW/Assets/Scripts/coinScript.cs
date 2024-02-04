using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{

    private Rigidbody2D playerPos;
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.instance.score++;
        transform.position = new Vector2((transform.position.x + 5), Random.Range(-5, 5));
    }
}
