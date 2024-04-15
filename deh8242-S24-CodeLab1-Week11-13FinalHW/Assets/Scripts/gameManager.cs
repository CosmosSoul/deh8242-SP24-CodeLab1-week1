using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public string highscorestring = "";

    private List<int> _highscores;

    public List<int> HighScores
    {
        get { return _highscores; }
        set { }
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
