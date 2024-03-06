using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

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
        
        else if (gameObject.CompareTag("target"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked me!");
            GameManager.instance.score++;
        }
        else if (gameObject.CompareTag("target1"))
        {
            
        }
          else if (gameObject.CompareTag("target1"))
        {
            
        }
          else if (gameObject.CompareTag("target1"))
        {
            
        }
          else if (gameObject.CompareTag("target1"))
        {
            
        }
         else if (gameObject.CompareTag("target1"))
        {
            
        }
          else if (gameObject.CompareTag("target1"))
        {
            
        }
        else if (gameObject.CompareTag("target1"))
        {
            
        }
         else if (gameObject.CompareTag("target1"))
        {
            
        }
         else if (gameObject.CompareTag("target1"))
        {
            
        }
         else if (gameObject.CompareTag("target1"))
        {
            
        }
          else if (gameObject.CompareTag("target1"))
        {
            
        }

       // string tag = gameObject.tag;
       /* 
        switch (gameObject.CompareTag(c))
        {
            case 'target0':
                Debug.Log("You clicked a 0");
                break;
                
        }
        */
    }
}
