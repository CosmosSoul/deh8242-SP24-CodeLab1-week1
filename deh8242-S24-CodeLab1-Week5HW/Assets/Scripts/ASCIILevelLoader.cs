using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using TMPro;
using File = System.IO.File;

public class ASCIILevelLoader : MonoBehaviour
{
    private int currentLevel = 0;

    private GameObject level;

    public int CurrenLevel
    {
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    public string FILE_PATH;

    
    public static ASCIILevelLoader instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        
        LoadLevel();
    }

    // Update is called once per frame
    void LoadLevel()
    {
        Destroy(level);

        level = new GameObject("Level Container");

        string[] lines = File.ReadAllLines(FILE_PATH.Replace("Num", currentLevel + ""));

        for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
        {
            string line = lines[yLevelPos].ToUpper();

            char[] characters = line.ToCharArray();

            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {
                char c = characters[xLevelPos];
                
                GameObject newObject = null;

                switch (c)
                {
                    case 'B':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Block"));
                        break;
                    
                }

                if (newObject != null)
                {
                    newObject.transform.parent = level.transform;

                    newObject.transform.position = new Vector2(xLevelPos, -yLevelPos);
                }
            }
        }
    }
}
