using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;

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
    }

    // Update is called once per frame
    void LoadLevel()
    {
        Destroy(level);

        level = new GameObject("Level Block");
        
    }
}
