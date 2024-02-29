using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class ASCIILevelLoader : MonoBehaviour
{
    int currentLevel = 0;

    private GameObject level;

   

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
            LoadLevel();
        }
    }
    
    public static ASCIILevelLoader instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        
        LoadLevel();
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

                switch (c)
                {
                    case 'B':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/groundBlock"));
                        break;
                    case '0':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target0"));
                        break;
                    case '1':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target1"));
                        break;
                }

                if (newObject != null)
                {
                    newObject.transform.parent = level.transform;

                    newObject.transform.position = new Vector2(xPos, -yPos);
                }
            }
        }
    }
}
