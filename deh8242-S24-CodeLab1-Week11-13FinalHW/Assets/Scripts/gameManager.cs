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
    [FormerlySerializedAs("displayText")] public TextMeshProUGUI letterBankText;
    public TextMeshProUGUI targetWordText;

    public bool gameOverCheck;

    public AudioSource gameAudio;

    private const string DATA_DIR = "/Data/";
    private const string DATA_HS_FILE = "hs.txt";

    private string DATA_FULL_HS_FILE_PATH;

    private float timer;

    public int maxTime;

    public float gameTime;
    public Stack<string> letterBank = new Stack<string>();
    public Dictionary<string, string> wordBank = new Dictionary<string, string>();
    
    //A dictionary to hold the player's obtained words
    //private Dictionary<string, string> wordBank = new Dictionary<string, string>();
    //a dictionary to hold the target words
    //private Dictionary<string, string> targetWord = new Dictionary<string, string>();
    
    
    
    //manages score and high scores
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            Debug.Log("Score Update!");

            if (isHighScore(score))
            {
                int highScoreSlot = -1;

                for (int i = 0; i < HighScores.Count; i++)
                {
                    if (score > _highscores[i])
                    {
                        highScoreSlot = i;
                        break;
                    }
                }
                _highscores.Insert(highScoreSlot, score);
                _highscores = _highscores.GetRange(0, 7);

                string scoreBoardText = "";

                foreach (var highScore in _highscores)
                {
                    scoreBoardText += highScore + "\n";
                }

                highScoreString = scoreBoardText;
                File.WriteAllText(DATA_FULL_HS_FILE_PATH, highScoreString);
            }
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

    
    // makes sure instance exists and if not, sets instance
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
    
    
    //system datapath is appended to DATA_DIR and DATA_HS_FILE and set to DATA_FULL_HS_FILE_PATH
    void Start()
    {
        //gameOverText.gameObject.SetActive(false);
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;
        wordBank.Add("cab", "a car that you can ride in!");
    }

    // Update is called once per frame
    void Update()
    {
        //letterBankText.text = letterBank
    }

    //Easy word list for beginner level, should be called from level 2
    public void EasyWordL1()
    {
        wordBank.Add("Dog", "an animal that goes woof!");
        wordBank.Add("God", "who knows?");
        wordBank.Add("Go", "move towards something!");
        wordBank.Add("Do", "make action, have at them!");
    }

    //medium word list for medium level, should be called from level 3 
    public void MediumWordL1()
    {
        wordBank.Add("Red", "the color of passion and of apples!");
        wordBank.Add("Dire", "serious things!");
        wordBank.Add("Tie", "the long thing on your chest, nice suit!");
        wordBank.Add("Rite", "to be accepted you must...");
        wordBank.Add("Dirt", "its usually on the ground and makes things unclean :(");
        wordBank.Add("tire", "V - run of out energy, N - the wheels on the bus go round and round!");
        wordBank.Add("Rid", "Remove it from sight!");
    }

    //difficult word list for harder level, should be called late game
    public void DifficultWordL1()
    {
        
        
    }

    public void BTNA()
    {
        
    }
}
