using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deathBoxScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.instance.gameOver = true;
        GameManager.instance.gameOverText.gameObject.SetActive(true);
    }
}
