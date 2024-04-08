using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public int gridWidth = 7;
    public int gridHeight = 7;

    public int[,] gameGrid;

    public GameObject p1Piece, p2Piece;
    
    // Start is called before the first frame update
    void Start()
    {
        gameGrid = new int[gridWidth, gridHeight];

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
