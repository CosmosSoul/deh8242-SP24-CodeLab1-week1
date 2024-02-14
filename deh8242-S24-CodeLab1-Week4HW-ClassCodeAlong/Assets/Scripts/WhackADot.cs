using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackADot : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        Debug.Log(("You whacked a dot"));
        transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));

        GameManager.instance.score++;

    }
}
