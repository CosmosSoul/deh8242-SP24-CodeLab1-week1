using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = Unity.Mathematics.Random;

public class GameManager : MonoBehaviour
{
    
    public int gridWidth = 7;
    public int gridHeight = 7;

    public int[,] gameGrid;

    public GameObject enemyPiece, p2Piece;

    public int[,] enemyOne;
    //QUESTION! Why is UnityEngine call needed here when already using?!
    // int randomLight = Random.Range(1, 3);
    
    //public int randomMid = UnityEngine.Random.Range(4, 6);
    //public int randomHeavy = UnityEngine.Random.Range(7, 9);


    
    
    // Start is called before the first frame update
    void Start()
    {
        //setup game board on a new grid
        gameGrid = new int[gridWidth, gridHeight];
        
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
        gameGrid[4, 4] = 5;
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
        
        Instantiate(enemyPiece,new Vector3(randomPos, randomPos), Quaternion.identity);
        Instantiate(enemyPiece,new Vector3(randomPos+1, randomPos), Quaternion.identity);
        Instantiate(enemyPiece,new Vector3(randomPos+2, randomPos), Quaternion.identity);

        
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
        int randomPos = UnityEngine.Random.Range(0, gridHeight);
        int randomMid = UnityEngine.Random.Range(4, 7);

        Instantiate(enemyPiece, new Vector3(randomPos, randomPos), Quaternion.identity);
        Instantiate(enemyPiece, new Vector3(randomPos, randomPos+1), Quaternion.identity);
        Instantiate(enemyPiece, new Vector3(randomPos, randomPos+2), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //Reset button using spacebar
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    /*
      void OnMouseDown(){
     
        Debug.Log("you clicked!");
        Destroy(gameObject);
    }
    */
   
}
