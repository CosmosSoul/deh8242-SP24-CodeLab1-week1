using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;
using File = System.IO.File;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    private int highScore = 0;
    public int calculation;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI inputText;

    public bool gameOver;

    private const string DATA_DIR = "/Data/";
    private const string DATA_HS_FILE = "hs.txt";
    private string DATA_FULL_HS_FILE_PATH;

    private float timer = 0;
    public int maxTime = 30;
    public float gameTime;

    public string highScoresString = "";
    
    
    private List<int> highScores;

    //isHighScore function iterates through highScores array and returns true if one of the current game score is higher than any of the scores on the list 
    bool isHighScore(int score)
    {
        for (int i = 0; i < HighScores.Count; i++)
        {
            if (highScores[i] < score)
            {
                return true;
            }
        }

        return false;
    }
    
    //HighScores list first checks if highscores list exists. If not, a new list is created and set to highScores. 
    //Also, hs.txt (via full file path) is read and then assigned to highScoresString
    //Also, highScoresString is trimmed to remove excess characters, then iterated through, split at each line break, converted to int and finally added to highScores array. 
    public List<int> HighScores
    {
        get
        {
            if (highScores == null)
            {
                highScores = new List<int>();
                highScoresString = File.ReadAllText(DATA_FULL_HS_FILE_PATH);

                highScoresString = highScoresString.Trim();
                string[] highScoresArray = highScoresString.Split("\n");

                for (int i = 0; i < highScoresArray.Length; i++)
                {
                    int currentScore = int.Parse(highScoresArray[i]);
                    highScores.Add(currentScore);
                }
            }

            return highScores;
        }
        
    }
        
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;

            //
            if (isHighScore(score))
            {
                //placeholder is set to -1 for highScoreSlot
                int highScoreSlot = -1;
                for (int i = 0; i < HighScores.Count; i++)
                {
                    //if the game score is greater than the current highScore in the array highScoreSlot placeholder get an updated assignment to i
                    if (score > highScores[i])
                    {
                        highScoreSlot = i;
                        break;
                    }
                }

                //whatever the confirmed score is in highScoreSlot is inserted at the highScoreSlot position and set within a range of 0-5 
                highScores.Insert(highScoreSlot, score);
                highScores = highScores.GetRange(0, 5);

                string scoreBoardText = "";

                foreach (var highScore in highScores)
                {
                    scoreBoardText += highScore + "\n";
                }

                highScoresString = scoreBoardText;

                File.WriteAllText(DATA_FULL_HS_FILE_PATH, highScoresString);
            }
        }
    }

    //setting gameManager to be a singleton that will persist between scenes and level, so score and time tracking remains consistent
    void Awake()
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
        //make sure gameOverText does not display on Start
        gameOverText.gameObject.SetActive(false);
        
        //get relative application datapath, then append it to DATA_DIR and DATA_HS_FILE on the first frame
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        scoreText.text = "Score: " + Score + "\nTime: " + timer;

        inputText.text = "Your input: " + calculation;

    }
}
