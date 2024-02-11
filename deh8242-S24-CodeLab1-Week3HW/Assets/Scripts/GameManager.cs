using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using System;
using UnityEngine.SceneManagement;
using File = System.IO.File;


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

    private const string DATA_DIR = "/Data/";
    private const string DATA_HS_FILE = "hs.txt";
    private string DATA_FULL_HS_FILE_PATH;
    public int Score
    {
        get
        {
            //QUESTION: Does every getter require something to be returned?
            return score;
        }
        set
        {
            //QUESTION: Does every setter require a value assignment?
            score = value;
            Debug.Log("score update!");

            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }

   
    private const string KEY_HIGH_SCORE = "High Score";

    int HighScore
    {
        get
        {
            //highScore = PlayerPrefs.GetInt(KEY_HIGH_SCORE);

            if (File.Exists(DATA_FULL_HS_FILE_PATH))
            {
                string fileContents = File.ReadAllText(DATA_FULL_HS_FILE_PATH);
                highScore = Int32.Parse(fileContents);
            }
 
            //QUESTION: Does every getter require something to be returned?
            return highScore;
        }
        set
        {
            Debug.Log("We Have a New High Scorer" +
                      "!");
            //QUESTION: Does every setter require a value assignment?
            highScore = value;
            
            // PlayerPrefs.SetInt(KEY_HIGH_SCORE, highScore);
            string fileContent = "" + highScore;

            if (!Directory.Exists(Application.dataPath + DATA_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + DATA_DIR);
            }
            
            File.WriteAllText(DATA_FULL_HS_FILE_PATH, fileContent);
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
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;

    }

    // Update is called once per frame
    void Update()
    {
        //can reset high score to zero by resetting PlayersPrefer for testing purposes
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            //PlayerPrefs.DeleteKey(KEY_HIGH_SCORE);
        
        }
        
        if (Input.GetKeyDown(KeyCode.Return) && (gameOverText))
        {
            gameOverText.gameObject.SetActive(false);
            gameOver = false;
            SceneManager.LoadScene(0);
            
        }
        
        scoreText.text = "Level: " + levelNum + "\nScore: " + Score + "\nCurrent High Score is: " + HighScore;
    }
}
