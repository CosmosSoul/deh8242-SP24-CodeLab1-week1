using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool gameOver = false;
    


    void Awake()
    {
        //QUESTION: Does instance mean we are setting this newly created gameManager to be persistent throughout scenes?
        //I dont fully understand this logic :( 😢
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //gameOverText made invisible on the first frame. 
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
