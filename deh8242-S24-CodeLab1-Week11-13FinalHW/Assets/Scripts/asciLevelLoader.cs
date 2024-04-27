using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.XR;
using File = System.IO.File;

public class asciLevelLoader : MonoBehaviour
{
    private int currentLevel = 0;

    private GameObject level;

    public int CurrentLevel
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

    public static asciLevelLoader instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        LoadLevel();
        
    }

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
                    case 'A':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupA"));
                        break;
                    case 'B':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupB"));
                        break;
                    case 'C':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupC"));
                        break;
                    case '8':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/groundBlock"));
                        break;
                    case 'K':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickup"));
                        break;
             
                    default:
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
