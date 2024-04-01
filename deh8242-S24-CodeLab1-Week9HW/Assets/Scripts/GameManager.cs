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
    public bool metBoss = false;
    public string bossHand;
    
    
   
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        bossEncounterOff();
        bossLocationChange();
        randomizeItemLocation();
        randomizeBossHand();
        
        
        locationDescriptionUI.text = currentLocation.locationName + "\n" + currentLocation.locationDesc;
        currentLocation.PrintLocation();
        currentLocation.UpdateCurrentLocation(this);
        search.gameObject.SetActive(true);

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

    public void playS()
    {
        if (bossHand == "Paper")
        {
            bossText.text = "You're so smart. See you later!";
            bossEncounterOff();
        }
        else if (bossHand == "Scissors")
        {
            bossText.text = "Great minds think alike! One more!";
            randomizeBossHand();
        }
        else
        {
            bossText.text = "I got you this time! Why don't come in this weekend";
        }
    } 
    
    public void playR()
    {
        if (bossHand == "Scissors")
        {
            bossText.text = "You're so smart. See you later!";
            bossEncounterOff();
            
        }
        else if (bossHand == "Rock")
        {
            bossText.text = "Great minds think alike! One more!";
            randomizeBossHand();
        }
        else
        {
            bossText.text = "I got you this time! Why don't come in this weekend";
        }
    }
    public void playP()
    {
        if (bossHand == "Rock")
        {
            bossText.text = "You're so smart. See you later!";
            bossEncounterOff();
        }
        else if (bossHand == "Paper")
        {
            bossText.text = "Great minds think alike! One more!";
            randomizeBossHand();
        }
        else
        {
            bossText.text = "I got you this time! Why don't come in this weekend";
        }
    }
    
    
    
    

    public void bossEncounterOn()
    {
        metBoss = true;
        rock.gameObject.SetActive(true);
        paper.gameObject.SetActive(true);
        scissors.gameObject.SetActive(true);
        bossText.gameObject.SetActive(true);
        bossText.text = "Oh hey, I was just looking for you!";
        
        
        
    }

    public void randomizeBossHand()
    {
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
                Debug.Log("uhh, what is that?!");
                break;
        }
    }
    public void bossEncounterOff()
    {
        metBoss = false;
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
            locationDescriptionUI.text = "You've found what you were looking for!";
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
        if (currentLocation == bossLocation && !metBoss)
        {
            
            bossEncounterOn();
            metBoss = false; 
            //metBoss = false;

            //WHY is this throwing an Error?!?
            //int randomHand = Random.Range(0, 2);
        }
        
  

        if (currentLocation == locationsArray[1] && hasItem)
        {
            gameOver = true;
            locationDescriptionUI.text = "You made it out! Enjoy the weekend!";
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
