using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
