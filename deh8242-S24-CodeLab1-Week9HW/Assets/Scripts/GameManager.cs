using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI locationDescriptionUI;

    public LocationScriptableObject currentLocation;
    [FormerlySerializedAs("LocationsArray")] public LocationScriptableObject[] locationsArray;
    public LocationScriptableObject bossLocation;
     

    public Button buttonNorth;
    public Button buttonSouth;
    public Button buttonEast;
    public Button buttonWest;

    public bool gameOver = false;
   
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        int randomLocation = UnityEngine.Random.Range(0, locationsArray.Length);
        bossLocation = locationsArray[randomLocation];
        Debug.Log(bossLocation);
        
        locationDescriptionUI.text = currentLocation.locationName + "\n" + currentLocation.locationDesc;
        currentLocation.PrintLocation();
        currentLocation.UpdateCurrentLocation(this);
       
    }

    public void bossLocationChange()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLocation == bossLocation && !gameOver)
        {
            gameOver = true;
            Debug.Log("You have to work this weekend!");
            gameOver = false;
        }
    }
    

    public void MoveDir(string direction)
    {
        switch (direction)
        {
            case "N":
                currentLocation = currentLocation.north;
                break;
            case "S":
                currentLocation = currentLocation.south;
                break;
            case "E":
                currentLocation = currentLocation.east;
                break;
            case "W":
                currentLocation = currentLocation.west;
                break;
            default:
                Debug.Log("Invalid direction detected! Please try again");
                break;
        }
        
        currentLocation.UpdateCurrentLocation(this);
    }
}
