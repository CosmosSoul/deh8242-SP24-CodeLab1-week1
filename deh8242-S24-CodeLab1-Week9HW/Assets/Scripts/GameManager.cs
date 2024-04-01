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
    public TextMeshProUGUI bossText;

    public LocationScriptableObject currentLocation;
    [FormerlySerializedAs("LocationsArray")] public LocationScriptableObject[] locationsArray;
    public LocationScriptableObject bossLocation;
    public LocationScriptableObject itemLocation;
     

    public Button buttonNorth;
    public Button buttonSouth;
    public Button buttonEast;
    public Button buttonWest;
    
    public Button search;
    public Button rock;
    public Button paper;
    public Button scissors;

    public bool gameOver = false;
    public bool hasItem = false;
    private string bossHand;
    
    
   
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        bossEncounterOff();
        bossLocationChange();
        randomizeItemLocation();
        
        
        locationDescriptionUI.text = currentLocation.locationName + "\n" + currentLocation.locationDesc;
        currentLocation.PrintLocation();
        currentLocation.UpdateCurrentLocation(this);
       
    }

    public void bossLocationChange()
    {
        int randomBossLocation = UnityEngine.Random.Range(0, locationsArray.Length);
        bossLocation = locationsArray[randomBossLocation];
        Debug.Log("the Boss is in" + bossLocation);
    }

    public void randomizeItemLocation()
    {
        int randomItemLocation = UnityEngine.Random.Range(0, locationsArray.Length);
        itemLocation = locationsArray[randomItemLocation];
        Debug.Log("The item is in" + itemLocation);
        
    }

    public void bossEncounterOn()
    {
        rock.gameObject.SetActive(true);
        paper.gameObject.SetActive(true);
        scissors.gameObject.SetActive(true);
        bossText.text = "What will you throw?";
    }

    public void bossEncounterOff()
    {
        rock.gameObject.SetActive(false);
        paper.gameObject.SetActive(false);
        scissors.gameObject.SetActive(false);
        bossText.gameObject.SetActive(false);
    }

    public void searchArea()
    {
        if (currentLocation == itemLocation)
        {
            hasItem = true;
            Debug.Log("You've found it!");
        }
        else
        {
            hasItem = false;
            Debug.Log("No, I don't see it here");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currentLocation == bossLocation)
        {
            bossEncounterOn();
            //WHY is this throwing an Error?!?
            //int randomHand = Random.Range(0, 2);

            int randomHand = UnityEngine.Random.Range(0, 2);

            switch (randomHand)
            {
                case 0:
                    bossHand = "Rock";
                    break;
                case 1:
                    bossHand = "Paper";
                    break;
                case 2:
                    bossHand = "Scissor";
                    break;
                default:
                    Debug.Log("uhh, what is that?");
                    break;
            }
        }
        if (currentLocation == bossLocation && !gameOver)
        {
            gameOver = true;
            Debug.Log("You have to work this weekend!");
            gameOver = false;
        }

        if (currentLocation == locationsArray[1] && hasItem)
        {
            gameOver = true;
            Debug.Log("You made it out! Enjoy your weekend!");
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
