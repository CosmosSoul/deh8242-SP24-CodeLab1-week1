using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    private float spawnDelay = 2;
    private float spawnInterval = 1;
    //public float randomPos = Random.Range(1, 2);
    public GameObject obstacle;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
       // Vector3.spawnLocation = new Vector3(30, randomPos, 0);

        Instantiate(obstacle, new Vector3(0,2,0), obstacle.transform.rotation);
        

    }
}
