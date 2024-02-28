using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using System.IO;

public class ASCIILevelLoader : MonoBehaviour
{
    int currentLevel = 0;

    private GameObject level;

    public static ASCIILevelLoader instance;

    private string FILE_PATH;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            //LoadLevel();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        FILE_PATH = Application.dataPath + "/Levels/LevelsNum.txt";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        Destroy(level);

        level = new GameObject("Level Components");

        string[] lines = File.ReadAllLines(FILE_PATH.Replace("Num", currentLevel + ""));

        for (int yPos = 0; yPos < lines.Length ; yPos++)
        {
            string line = lines[yPos].ToUpper();

            char[] characters = line.ToCharArray();

            for (int xPos = 0; xPos < characters.Length; xPos++)
            {
                char c = characters[xPos];

                GameObject newObject = null;
            }
        }
    }
}
