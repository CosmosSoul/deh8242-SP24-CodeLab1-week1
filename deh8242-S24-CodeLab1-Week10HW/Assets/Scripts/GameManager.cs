using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = Unity.Mathematics.Random;

public class GameManager : MonoBehaviour
{
    
    public int gridWidth = 7;
    public int gridHeight = 7;

    public TextMeshPro gameOverText;

    public int[,] gameGrid;
    public int[,] lightEnemy;
    public int[,] midEnemy;
    
    
    public int enemyHealth;

    public GameObject enemyPiece, p2Piece;
    public static GameManager instance;

    public int[,] enemyOne;
    //QUESTION! Why is UnityEngine call needed here when already using?!
    // int randomLight = Random.Range(1, 3);
    
    //public int randomMid = UnityEngine.Random.Range(4, 6);
    //public int randomHeavy = UnityEngine.Random.Range(7, 9);


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        /*else
        {
            Destroy(gameObject);
        }
        */
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //setup game board on a new grid, disable gameOverText
        gameGrid = new int[gridWidth, gridHeight];
        gameOverText.gameObject.SetActive(false);
        
        
        //Debug.Log(gameGrid[4,5]);

        for (int i = 0; i < gridWidth; i++)
        {
           // new GameObject p1Piece = Instantiate(p1Piece, gridWidth, gridHeight);
           // Instantiate(p1Piece,new Vector3(0, i), quaternion.identity);
            //p1Piece.transform.position = new Vector2(gridWidth, gridHeight);

            for (int j = 0; j < gridHeight; j++)
            {
                Instantiate(p2Piece, new Vector3(j, i), quaternion.identity);
                gameGrid[j, i] = 0;
                
            }
        }
    
        //testing array position
        //gameGrid[4, 4] = 5;
        Debug.Log(gameGrid[4, 4]);
        
        spawnLightShip();
        spawnMidShip();
    }

    
    //spawns light sized ship
    void spawnLightShip()
    {
        int randomPos = UnityEngine.Random.Range(0, gridHeight-1);
        int randomLight = UnityEngine.Random.Range(3, 5);
        int randomStartPos = gameGrid[randomPos, randomPos];
        
        //Instantiate(enemyPiece,new Vector3(randomPos, randomPos), Quaternion.identity);
        //gameGrid[randomPos, randomPos] = 1;
        //enemyHealth++;
        Instantiate(enemyPiece,new Vector3(randomPos+1, randomPos), Quaternion.identity);
        //gameGrid[randomPos+1, randomPos] = 1;
        enemyHealth++;
        Instantiate(enemyPiece,new Vector3(randomPos+2, randomPos), Quaternion.identity);
        //gameGrid[randomPos+2, randomPos] = 1;
        enemyHealth++;
        
        Debug.Log(gameGrid); 
        
        

        
       /* for (int i = 0; i < randomLight; i++)
        {

            for (int j = 0; j < randomLight; j++)
            {
            }
        }
        */
    }

    //spawns medium sized ship
    void spawnMidShip()
    {
        int randomPos = UnityEngine.Random.Range(0, gridHeight-1);
        int randomMid = UnityEngine.Random.Range(4, 7);

        Instantiate(enemyPiece, new Vector3(randomPos, randomPos), Quaternion.identity);
        enemyHealth++;
        Instantiate(enemyPiece, new Vector3(randomPos, randomPos+1), Quaternion.identity);
        enemyHealth++;
        Instantiate(enemyPiece, new Vector3(randomPos, randomPos+2), Quaternion.identity);
        enemyHealth++;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            gameOverText.gameObject.SetActive(true);
        }
        //Reset button using spacebar
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            spawnLightShip();
            spawnMidShip();
            gameOverText.gameObject.SetActive(false);
        }

     
        
        /*
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                if (gameGrid[i, j] == 1)
                {
                    Debug.Log("the game is live!");
                }
                else
                {
                    Debug.Log("You sunk all the ships!");
                }
            }
            
            
        }
        */
    }
    
    /*
      void OnMouseDown(){
     
        Debug.Log("you clicked!");
        Destroy(gameObject);
    }
    */
   
}
