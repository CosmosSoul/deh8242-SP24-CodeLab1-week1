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
        
        /*
        string tagString = "";
        
        switch(tagString)
        {
            case "targetClear":
                Debug.Log("Your input is clear, but you lost points! 😬");
                break;
            case "target1":
                Debug.Log("you clicked one");
                break;
            case "target2":
                Debug.Log("you clicked two");
                break;
            case "target3":
                Debug.Log("you clicked three");
                break;
            case "target4":
                Debug.Log("you clicked four");
                break;
            case "target5":
                Debug.Log("you clicked six");
                break;
            case "target7":
                Debug.Log("you clicked seven");
                break;
            case "target8":
                Debug.Log("you clicked eight");
                break;
            case "target9":
                Debug.Log("you clicked nine");
                break;
            case "calculate":
                Debug.Log("you clicked one");
                GameManager.instance.Calculaute();
                break;
            case "targetPlus":
                Debug.Log("you clicked one");
                break;
            case "targetMinus":
                Debug.Log("you clicked one");
                break;
            case "targetMultiply":
                Debug.Log("you clicked one");
                break;
            case "targetDivide":
                Debug.Log("you clicked one");
                break;
        }
        */
        if (gameObject.CompareTag("clear"))
        {
            Debug.Log("You cleared the board but you lost points! 😬");
            GameManager.instance.score -= 5;
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
            GameManager.instance.calculation += 1;
        }
        else if (gameObject.CompareTag("target2"))
        {
            Destroy(gameObject);
            Debug.Log("you clicked two");
            GameManager.instance.calculation += 2;
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
        else if (gameObject.CompareTag("targetPlus"))
        {
             Destroy(gameObject);
             Debug.Log("you clicked plus");
             GameManager.instance.score++;
        }
        else if (gameObject.CompareTag("targetMinus"))
        {
             Destroy(gameObject);
             Debug.Log("you clicked minus");
             GameManager.instance.score++;
        }
        else if (gameObject.CompareTag("targetMultiply"))
        {
             Destroy(gameObject);
             Debug.Log("you clicked multiply");
             GameManager.instance.score++;
        }
        else if (gameObject.CompareTag("targetDivide"))
        {
             Destroy(gameObject);
             Debug.Log("you clicked divide");
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
