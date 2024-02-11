using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class deathBoxScript : MonoBehaviour
{

    

    public AudioClip fireSound;
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.instance.gameOver = true;
        GameManager.instance.gameOverText.gameObject.SetActive(true);
        GameManager.instance.gameAudio.PlayOneShot(fireSound, 1.5f);
        
        //add restart button here
   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && (GameManager.instance.gameOverText))
        {
            SceneManager.LoadScene(0);
            
        }
    }
}
