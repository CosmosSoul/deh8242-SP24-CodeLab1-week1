using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;


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
