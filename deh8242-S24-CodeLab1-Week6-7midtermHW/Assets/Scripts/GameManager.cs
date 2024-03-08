using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using File = System.IO.File;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    private int highScore = 0;
    public int calculation;
    public int num1 = 0;
    public int num2 = 0;
    public int targetNum;
    public int clickNum;
    public string operation;

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

    public void Calculate()
    {
        
        num2 = int.Parse(inputText.text);
        
        switch (operation)
        {
            case "+":
                calculation = num1 + num2;
                inputText.text = calculation.ToString();
                break;
            case "-":
                calculation = num1 - num2;
                break;
            case "*":
                calculation = num1 * num2;
                break;
            case "/":
                calculation = num1 / num2;
                break;
        }

        



    }

    public void NumSet1()
    {
        num1 = clickNum;
    }

    public void NumSet2()
    {
        num2 = clickNum;
    }
   /* public void GetNum1()
    {
        Debug.Log("GetNum1 Function CALL!");

        clickAction.instance.OnMouseDown();

        num1 = clickNum;
        
        
    }
    */
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

        //inputText.text = "Your first number is: " + num1 + "\n Your second number is: " +  num2;

        //inputText.text;
    }

    public void Btn1()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "1";
        }
        else
        {
            inputText.text += "1";
        }
    }
    
    public void Btn2()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "2";
        }
        else
        {
            inputText.text += "2";
        }
    }
    
    public void Btn3()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "3";
        }
        else
        {
            inputText.text += "3";
        }
    }
    
    public void Btn4()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "4";
        }
        else
        {
            inputText.text += "4";
        }
    }
    
    public void Btn5()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "5";
        }
        else
        {
            inputText.text += "5";
        }
    }
    
    public void Btn6()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "6";
        }
        else
        {
            inputText.text += "6";
        }
    }
    
    public void Btn7()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "7";
        }
        else
        {
            inputText.text += "7";
        }
    }
    public void Btn8()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "8";
        }
        else
        {
            inputText.text += "8";
        }
    }
    public void Btn9()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "9";
        }
        else
        {
            inputText.text += "9";
        }
    }
    
    
    

    public void Addtion()
    {
        num1 = int.Parse(inputText.text);
        operation = "+";
        inputText.text = "";

    }
    
}
