using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //onCollision with goal sprite, the next level loads and levelNum increments by 1
        GameManager.instance.levelNum++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ASCIILevelLoader.instance.CurrenLevel++;
    }
}
