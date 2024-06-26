using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Empty Location", menuName = "Empty Location", order = 0)]
public class LocationScriptableObject : ScriptableObject
{
  public string locationName;
  public string locationDesc;
  public int hasKeyItem;
  

  public LocationScriptableObject north;
  public LocationScriptableObject south;
  public LocationScriptableObject west;
  public LocationScriptableObject east;
  
  
  
  

  public void PrintLocation()
  {
    string printStr = "Location Name: " + locationName + "\nLocation Description: " + locationDesc;
    
    //Debug.Log(printStr);
  }

  public void UpdateCurrentLocation(GameManager gm)
  {
    gm.locationDescriptionUI.text = locationName + "\n" + locationDesc;

    if (north == null)
    {
      gm.buttonNorth.gameObject.SetActive(false);
    }
    else
    {
      gm.buttonNorth.gameObject.SetActive(true);
      north.south = this;
    }

    
    if (south == null)
    {
      gm.buttonSouth.gameObject.SetActive(false);
    }
    else
    {
      gm.buttonSouth.gameObject.SetActive(true);
      south.north = this;
    }

    
    if (east == null)
    {
      gm.buttonEast.gameObject.SetActive(false);
    }
    else
    {
      gm.buttonEast.gameObject.SetActive(true);
      east.west = this;
    }
    
    
    if (west == null)
    {
      gm.buttonWest.gameObject.SetActive(false);
    }
    else
    {
      gm.buttonWest.gameObject.SetActive(true);
      west.east = this;
    }
/*
    string direction;

    switch (ScriptableObject)
    {
      case north:
        gm.buttonNorth.gameObject.SetActive(false);
        break;
      case 
    }
    
    */
  }
  
}
