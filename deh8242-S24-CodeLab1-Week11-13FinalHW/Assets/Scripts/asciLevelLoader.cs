using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            
        }
    }

    public string FILE_PATH;

    public static asciLevelLoader instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
