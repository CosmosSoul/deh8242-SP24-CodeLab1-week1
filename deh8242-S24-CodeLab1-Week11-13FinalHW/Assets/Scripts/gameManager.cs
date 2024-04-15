using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int score = 0;

    private int highScore = 0;

    public int levelNum = 1;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    public bool gameOverCheck;

    public AudioSource gameAudio;

    private const string DATA_DIR = "/Data/";
    private const string DATA_HS_FILE = "hs.txt";

    private string DATA_FULL_HS_FILE_PATH;

    private float timer;

    public int maxTime;

    public float gameTime;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            Debug.Log("Score Update!");
        }
    }

    [FormerlySerializedAs("highscorestring")] public string highScoreString = "";
    private const string KEY_HIGH_SCORE = "High Score";

    private List<int> _highscores;

    public List<int> HighScores
    {
        get
        {
            if (_highscores == null)
            {
                _highscores = new List<int>();

                highScoreString = File.ReadAllText(DATA_FULL_HS_FILE_PATH);

                highScoreString = highScoreString.Trim();

                string[] highScoresArray = highScoreString.Split("\n");

                for (int i = 0; i < highScoresArray.Length; i++)
                {
                    int currentScore = Int32.Parse(highScoresArray[i]);
                    _highscores.Add(currentScore);
                }
            }
            return _highscores;
        }
        //set { }
    }
    bool isHighScore(int score)
    {
        for (int i = 0; i < HighScores.Count; i++)
        {
            if (_highscores[i] < score)
            {
                return true;
            }
        }

        return false;
    }

    private void Awake()
    {
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
        gameOverText.gameObject.SetActive(false);
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}