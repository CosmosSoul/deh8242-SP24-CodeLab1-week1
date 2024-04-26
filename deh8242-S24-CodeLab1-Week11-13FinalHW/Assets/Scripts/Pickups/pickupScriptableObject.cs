using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
    fileName = "New Letter",
    menuName = "New Letter",
    order = 0)]
public class pickupScriptableObject : ScriptableObject
{
    public string letterName;
    public string letterValue;
}
