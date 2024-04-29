using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

//I tried to use a scriptable object for managing letters as items to pickup, but couldn't figure it out in time :(
[CreateAssetMenu(
    fileName = "New Letter",
    menuName = "New Letter",
    order = 0)]
public class pickupScriptableObject : ScriptableObject
{
    public string letterName;
    public string letterValue;
    public Sprite letterImage;
    public GameObject pickup;
}
