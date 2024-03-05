using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class clickAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("gameOver"))
        {
            Debug.Log("Your game is now over!");
        }
        
        Destroy(gameObject);
        Debug.Log("you clicked me!");
        GameManager.instance.score++;
    }
}
