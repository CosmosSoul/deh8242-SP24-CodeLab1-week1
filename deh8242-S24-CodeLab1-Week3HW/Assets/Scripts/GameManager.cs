using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    private int highScore = 0;
    public int levelNum = 1;
    
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool gameOver = false;
    public AudioSource gameAudio;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            Debug.Log("score update!");

            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }

   
    private const string KEY_HIGH_SCORE = "The Current High Score is: ";

    int HighScore
    {
        get
        {
            highScore = PlayerPrefs.GetInt(KEY_HIGH_SCORE);
            return highScore;
        }
        set
        {
            Debug.Log("We Have a New High Score!");
            highScore = value;
            PlayerPrefs.SetInt(KEY_HIGH_SCORE, highScore);
        }

    }

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
        scoreText.text = "Current Level: " + levelNum + "\n Score: " + Score;
    }
}
