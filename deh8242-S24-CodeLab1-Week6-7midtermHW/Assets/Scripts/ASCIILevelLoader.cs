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
        //instance = this;
        //GameManager.instance.gameOn = false;
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        //GameManager.instance.playerName.text;
        //LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        GameManager.instance.startButton.gameObject.SetActive(false);
        GameManager.instance.playerNameInput.gameObject.SetActive(false);
        GameManager.instance.timerOn = true;
        GameManager.instance.playerNameData = GameManager.instance.playerNameInput.text;
        Debug.Log(GameManager.instance.playerNameData);
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
                    case '2':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target2"));
                        break;
                    case '3':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target3"));
                        break;
                    case '4':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target4"));
                        break;
                    case '5':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target5"));
                        break;
                    case '6':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target6"));
                        break;
                    case '7':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target7"));
                        break;
                    case '8':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target8"));
                        break;
                    case '9':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/target9"));
                        break;
                    case 'E':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/targetCalc"));
                        break;
                    case 'C':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/targetClear"));
                        break;
                    case 'P':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/targetPlus"));
                        break;
                    case 'S':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/targetMinus"));
                        break;
                    case 'M':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/targetMultiply"));
                        break;
                    case 'D':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/targetDivide"));
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
