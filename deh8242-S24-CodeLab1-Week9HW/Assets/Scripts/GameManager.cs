using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI locationDescriptionUI;

    public LocationScriptableObject currentLocation;

    public Button buttonNorth;
    public Button buttonSouth;
    public Button buttonEast;
    public Button buttonWest;
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        locationDescriptionUI.text = currentLocation.locationName + "\n" + currentLocation.locationDesc;
        currentLocation.PrintLocation();
        currentLocation.UpdateCurrentLocation(this);
    }

    // Update is called once per frame
    void Update()
    {
        
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
