using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class battleShipScript : MonoBehaviour
{
    public int width = 7;
    public int height = 7;

    public int[,] gameGrid;

    public GameObject p1Piece, p2Piece;
    
    // Start is called before the first frame update
    void Start()
    {
        gameGrid = new int[width, height];
        Instantiate(p1Piece);
        p1Piece.transform.position = new Vector3(0, 1);
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
