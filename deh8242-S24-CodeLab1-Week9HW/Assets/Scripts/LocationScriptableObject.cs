using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Empty Location", menuName = "Empty Location", order = 0)]
public class LocationScriptableObject : ScriptableObject
{
  public string locationName;
  public string locationDesc;

  public LocationScriptableObject north;
  public LocationScriptableObject south;
  public LocationScriptableObject west;
  public LocationScriptableObject east;
  
  
  
  

  public void PrintLocation()
  {
    string printStr = "\nLocation Name: " + locationName + "\nLocation Description: " + locationDesc;
    
    Debug.Log(printStr);
  }
}
