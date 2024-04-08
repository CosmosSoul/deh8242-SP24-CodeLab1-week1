using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
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
            }
        }
        
        spawnLightShip();
    }

    void spawnLightShip()
    {
        int randomPos = UnityEngine.Random.Range(0, gridHeight-1);
        int randomLight = UnityEngine.Random.Range(3, 5);
        int randomStartPos = gameGrid[randomPos, randomPos];
        for (int i = 0; i < randomLight; i++)
        {
            Instantiate(enemyPiece,new Vector3( randomPos, i), Quaternion.identity);

            for (int j = 0; j < randomLight; j++)
            {
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    void OnMouseDown(){
        Debug.Log("you clicked!");
        Destroy(gameObject);
    }
   
}