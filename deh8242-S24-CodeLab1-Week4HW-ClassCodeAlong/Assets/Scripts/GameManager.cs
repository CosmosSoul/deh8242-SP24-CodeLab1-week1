using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI display;
    public int score;
    private float timer = 0;
    public int maxTime = 10;

    private bool isInGame = true;

    List<int> highScores;

    public List<int> HighScores
    {
        get
        {
            if (highScores == null)
            {
                highScores = new List<int>();
                
                highScores.Add(0);
                highScores.Insert(0, 3);
                highScores.Insert(1, 2);
                HighScores.Insert(2, 1);
            }
            
        }
        set
        {
            
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

                string scoreBoardText = "";

                foreach (var highScore in highScores)
                {
                    
                }
            }
        }
    }

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInGame)
        {
            display.text = "Score: " + score + "\nTime:" + (maxTime - (int)timer);
        }
        else
        {
            display.text = "Game Over\n Final Score: " + score;
        }

        //add the fraction of a second between frames to timer
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    bool isHighScore(int score)
    {
        bool result = false;

        for (int i = 0; i < HighScores.Count; i++)
        {
            if (highScores[i] < score)
            {
                return true;
            }
        }

        return false;
    }


}
