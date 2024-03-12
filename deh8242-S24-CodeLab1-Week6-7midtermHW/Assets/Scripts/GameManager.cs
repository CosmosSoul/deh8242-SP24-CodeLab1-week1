using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;
using File = System.IO.File;
using Input = UnityEngine.Input;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private ASCIILevelLoader _asciiLevelLoader;

    public int score = 0;
    private int highScore = 0;
    public int calculation;
    public int num1 = 0;
    public int num2 = 0;
    public int targetNum;
    public string operation;
    public string playerNameData;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI inputText;
    public TextMeshProUGUI targetNumText;
    public InputField playerNameInput;

    public bool gameOver;
    public bool timerOn;
    public Color standardBackground;

    private const string DATA_DIR = "/Data/";
    private const string DATA_HS_FILE = "hs.txt";
    private string DATA_FULL_HS_FILE_PATH;

    private float timer = 0;
    [SerializeField]
    public float maxTime = 15f;
    public float gameTime;

    public string highScoresString = "";

    
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            Debug.Log("Score update!");
            

            
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
                highScores = highScores.GetRange(0, 7);

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
    /*
    public void ReadTextInput()
    {
        foreach (char c in Input.inputString)
        {
            if ((c == '\n') || (c == '\r'))
            {
                print("Player has entered their name: " + playerName.text);
            }
            else
            {
                playerName.text += c;
            }

            //playerName = inputField.text;
            //Debug.Log(playerName);
        }
    }
    */


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
                    int currentScore = Int32.Parse(highScoresArray[i]);
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
                inputText.text = calculation.ToString();
                break;
            case "*":
                calculation = num1 * num2;
                inputText.text = calculation.ToString();
                break;
            case "/":
                calculation = num1 / num2;
                inputText.text = calculation.ToString();
                break;
        }

        if (calculation == targetNum)
        {
            inputText.text = "";
            Score++;
            RandomizeTargetNumberEasy();
            //_asciiLevelLoader.CurrentLevel++;
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

    public void StartGame()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {

        //gameOver = true;
        //make sure gameOverText does not display on Start
        gameOverText.gameObject.SetActive(false);
        
        //get relative application datapath, then append it to DATA_DIR and DATA_HS_FILE on the first frame
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;
        standardBackground = Camera.main.backgroundColor;
        RandomizeTargetNumberEasy();

        //Debug.Log(highScoresString + "okay");

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!gameOver && _asciiLevelLoader.CurrentLevel <= 4)
        {
            targetNumText.text = "Your target is: " + targetNum;
            
            if (timerOn)
            {
                maxTime -= Time.deltaTime;
            }

            if (maxTime <= 0f)
            {
                Debug.Log(playerNameInput.text);
                _asciiLevelLoader.CurrentLevel++;
                maxTime = 10f;
            }
            scoreText.text = "Score: " + Score + "\nTime: " + (int)maxTime + "\nLevel: " + _asciiLevelLoader.CurrentLevel+1;
        }
        
        else
        {
            timerOn = false;
            gameOver = true;
            Camera.main.backgroundColor = Color.red;
            gameOverText.gameObject.SetActive(true);
            scoreText.text = "Game Over! 🤣" + "\nYour score is: " + Score  +
                             "\nThe high scores are: \n" + highScoresString;
        }
        //inputText.text = "Your first number is: " + num1 + "\n Your second number is: " +  num2;
        //inputText.text;

        if (gameOver && Input.GetKeyDown(KeyCode.Return))
        {
            _asciiLevelLoader.CurrentLevel = 0;
            gameOverText.gameObject.SetActive(false);
            Score = 0;
            maxTime = 10f;
            Camera.main.backgroundColor = standardBackground;
            gameOver = false;
            _asciiLevelLoader.LoadLevel();
        }
        
    }
    public void Btn0()
    {
        if (inputText.text == Convert.ToString("0"))
        {
            inputText.text = "0";
        }
        else
        {
            inputText.text += "0";
        }
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

    public void RandomizeTargetNumberEasy()
    {
        targetNum = Random.Range(1, 99);
    }
    
    public void RandomizeTargetNumberMedium()
    {
        targetNum = Random.Range(1, 500);
    }

    public void RandomizeTargetNumberHard()
    {
        targetNum = Random.Range(1, 1000);
    }
    public void Addition()
    {
        num1 = int.Parse(inputText.text);
        operation = "+";
        inputText.text = "";

    }
    
    public void Subtract()
    {
        num1 = int.Parse(inputText.text);
        operation = "-";
        inputText.text = "";

    }
    
    public void Multiply()
    {
        num1 = int.Parse(inputText.text);
        operation = "*";
        inputText.text = "";

    }
    
    public void Divide()
    {
        num1 = int.Parse(inputText.text);
        operation = "/";
        inputText.text = "";

    }

    public void Clear()
    {
        num1 = 0;
        num2 = 0;
        inputText.text = "0";
        _asciiLevelLoader.CurrentLevel+= 0;
    }
    
}
