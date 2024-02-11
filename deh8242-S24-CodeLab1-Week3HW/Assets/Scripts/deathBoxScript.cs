using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
}
