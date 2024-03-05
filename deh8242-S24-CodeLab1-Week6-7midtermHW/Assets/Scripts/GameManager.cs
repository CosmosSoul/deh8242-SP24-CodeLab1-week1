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

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;

    public bool gameOver;

    private const string DATA_DIR = "/Data/";
    private const string DATA_HS_FILE = "hs.txt";
    private string DATA_FULL_HS_FILE_PATH;

    private float timer = 0;
    public int maxTime = 30;
    public float gameTime;

    public string highScoresString = "";
    
    
    private List<int> highScores;

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

            if (isHighScore(score))
            {
                int highScoreSlot = -1;
                for (int i = 0; i < HighScores.Count; i++)
                {
                    if (score > highScores[i])
                    {
                        highScoreSlot = i;
                        break;
                    }
                }

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
