using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Item3_sc : NetworkBehaviour
{

    public int itemvalue;
    // Use this for initialization
    void Start()
    {
        itemvalue = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
