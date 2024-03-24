using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class JSONTest : MonoBehaviour
{
    [TextArea (5, 20)] public string json;
    // DEMO ( Array of Objects ) 
    /* 
    [
    { "name":"Matt", "age":25 },
    { "name":"Wylie", "age":7 },
    { "name":"Tuna", "age":4 }
    ]
*/

   [TextArea(5, 20)] public string simpleObjectJson ;
   // DEMO ( Simple Objects ) 
   /*
    {
        "pos":
        {
            "x":1,
            "y":2,
            "z":3,
        },
        "rot":
        {
            "x":90,
            "y":45,
            "z":0
        }
    }
*/
    // Start is called before the first frame update
/*
    private void Awake()
    {
       // JSONNode transformNode = new JSONObject();

       // JSONObject posObj = new JSONObject();
    }

    void Start()
    {
        SimpleObjectParsing();
    }

    // Update is called once per frame
    void Update()
    {
        // JSONNode transformNode = new JSONObject();

        // JSONObject posObj = new JSONObject();
    }

    public void ArrayOfObjectParsing()
    {
        JSONNode node = JSON.Parse(json);

        JSONArray allPersons = node.AsArray;
    }

    public void SimpleObjectParsing()
    {
        JSONNode transformNode = JSON.Parse(simpleObjectJson);

        JSONNode positionNode = transformNode["pos"];

        JSONObject positionObject = positionNode.AsObject;

        Vector3 jsonPos = new Vector3();

        jsonPos.x = positionObject["x"].AsInt;
        jsonPos.y = positionObject["y"].AsInt;
        jsonPos.z = positionObject["z"].AsInt;

        transform.position = jsonPos;
        
        Debug.Log(positionObject.ToString());

    }
    
    */
}
