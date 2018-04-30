using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SpawnItems : NetworkBehaviour
{

    Vector3 position = new Vector3(500,5,500);
    Quaternion rotation = new Quaternion(0, 0, 0, 0);
    //Spawn this object
    private GameObject Item;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;

    public int numero = 1;

    public float maxTime = 3;
    public float minTime = 1;
    public float minX = 460;
    public float maxX = 490;
    public float minZ = 460;
    public float maxZ = 490;
	private int randomValue;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    void Start()
    {
        SetRandomTime();
        SetRandomLocation();
        SetRandomValue();
        time = minTime;
    }

    void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
            SetRandomLocation();
            SetRandomValue();
        }

    }


    //Spawns the object and resets the time
    void SpawnObject()
    {
        GameObject item = Instantiate(Item, position, rotation);
        NetworkServer.Spawn(item);
        time = 0;
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    void SetRandomLocation()
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        position = new Vector3(x, 5, z);
    }

    void SetRandomValue()
    {
        if (Random.Range(0, 100) < 60)
        {
            Item = Item1;
        }
        else if (Random.Range(0, 100) < 90)
        {
            Item = Item2;
        }
        else
        {
            Item = Item3;
        }
    }

}