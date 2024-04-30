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
            
            if (CurrentLevel == 1)
            {
                gameManager.instance.EasyWordL1();
                Debug.Log(gameManager.instance.wordBank.Count);
                gameManager.instance.letterBankText.text = "";
                LoadLevel();
            }
            else if (CurrentLevel == 2)
            {
                gameManager.instance.EasyWordL2();
                Debug.Log(gameManager.instance.wordBank.Count);
                gameManager.instance.letterBankText.text = "";
                LoadLevel();
            }
            else if (CurrentLevel == 3)
            {
                gameManager.instance.MediumWordL1();
                Debug.Log(gameManager.instance.wordBank.Count);
                gameManager.instance.letterBankText.text = "";
                LoadLevel();
            }
            else if(CurrentLevel == 4)
            {
                gameManager.instance.MediumWordL2();
                Debug.Log(gameManager.instance.wordBank.Count);
                gameManager.instance.letterBankText.text = "";
                LoadLevel();
            }
            
            
        }
    }

    public string FILE_PATH;

    public static asciLevelLoader instance;
    // Start is called before the first frame update
   
    //just before the first frame update, FILE_PATH is get to system dependent data path, appended to Unity specific file path
    //also LoadLevel() is called to load the first level
    void Start()
    {
        instance = this;
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        LoadLevel();
        
    }

    
    //this nested for loops checks .txt file for specific characters along the x, and y axes and then instantiates a corresponding gameObject accordingly
    //also creates a container in the Unity hierarchy to hold all the newly instantiated gameObjects
    //letters a-z, plus player, goal and enemy gameObjects should be accounted for in the switch statement
   public void LoadLevel()
   {
       gameManager.instance.timerOn = true;
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
                    case 'D':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupD"));
                        break;
                    case 'E':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupE"));
                        break;
                    case 'F':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupF"));
                        break;
                    case 'G':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupG"));
                        break;
                    case 'H':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupH"));
                        break;
                    case 'I':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupI"));
                        break;
                    case 'J':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupJ"));
                        break;
                    case 'K':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupK"));
                        break;
                    case 'L':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupL"));
                        break;
                    case 'M':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupM"));
                        break;
                    case 'N':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupN"));
                        break;
                    case 'O':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupO"));
                        break;
                    case 'P':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupP"));
                        break;
                    case 'Q':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupQ"));
                        break;
                    case 'R':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupR"));
                        break;
                    case 'S':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupS"));
                        break;
                    case 'T':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupT"));
                        break;
                    case 'U':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupU"));
                        break;
                    case 'V':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupV"));
                        break;
                    case 'W':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupW"));
                        break;
                    case 'X':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupX"));
                        break;
                    case 'Y':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupY"));
                        break;
                    case 'Z':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterPickupZ"));
                        break;
                    case '-':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/playerEnemy"));
                        break;
                    case '8':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/groundBlock"));
                        break;
                    case '0':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/letterEnemy"));
                        break;
                    case '=':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/goalBlock"));
                        break;
                    //wherever the player is instantiated. the main Camera is childed to the player's position for easy viewing pleasure ;)
                    case '1':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/player"));
                        Camera.main.transform.parent = newObject.transform;
                        Camera.main.transform.position = new Vector3(0, 0, -10);
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
