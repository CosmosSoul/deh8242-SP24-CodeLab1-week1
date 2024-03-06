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
        if (gameObject.CompareTag("clear"))
        {
            Debug.Log("You cleared the board");
        }
        
        else if (gameObject.CompareTag("calculate"))
        {
            Destroy(gameObject);
            Debug.Log("you calculated");
            GameManager.instance.score++;
        }
        else if (gameObject.CompareTag("target1"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked one");
            GameManager.instance.inputText.text += 1;
        }
          else if (gameObject.CompareTag("target2"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked two");
            GameManager.instance.score++;
        }
          else if (gameObject.CompareTag("target3"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked three");
            GameManager.instance.score++;
        }
          else if (gameObject.CompareTag("target4"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked four");
            GameManager.instance.score++;
        }
         else if (gameObject.CompareTag("target5"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked five");
            GameManager.instance.score++;
        }
          else if (gameObject.CompareTag("target6"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked six");
            GameManager.instance.score++;
        }
        else if (gameObject.CompareTag("target7"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked seven");
            GameManager.instance.score++;
        }
         else if (gameObject.CompareTag("target8"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked eight");
            GameManager.instance.score++;
        }
         else if (gameObject.CompareTag("target9"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked nine");
            GameManager.instance.score++;
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
