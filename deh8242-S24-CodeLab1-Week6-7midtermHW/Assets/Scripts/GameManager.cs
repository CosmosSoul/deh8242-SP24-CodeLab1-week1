using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    private int highScore = 0;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    public bool gameOver;

    private const string DATA_DIR = "/Data/";

    private const string DATA_HS_FILE = "hs.txt";

    private string DATA_FULL_HS_FILE_PATH;

    private float timer = 0;

    public int maxTime = 30;

    public float gameTime; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
