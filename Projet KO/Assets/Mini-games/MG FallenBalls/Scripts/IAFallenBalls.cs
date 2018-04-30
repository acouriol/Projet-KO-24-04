using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;


public class IAFallenBalls : NetworkBehaviour
{
    private float speed;
    [SyncVar] public int points;
    private Transform targetTransform;
    private GameObject closest;
    private GameObject obj;
    
    void Start()
    {
        speed = 4f;
    }

    void Update()
    {
        
        obj = FindClosestItem();
        
        if (obj != null)
        {
            targetTransform = obj.transform;
            Vector3 target = targetTransform.position;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
    public GameObject FindClosestItem()
    {
        List<GameObject> Positions = new List<GameObject>();
        foreach (GameObject pos in GameObject.FindGameObjectsWithTag("Item1"))
        {
            Positions.Add(pos);
        }
        foreach (GameObject pos in GameObject.FindGameObjectsWithTag("Item2"))
        {
            Positions.Add(pos);
        }
        foreach (GameObject pos in GameObject.FindGameObjectsWithTag("Item3"))
        {
            Positions.Add(pos);
        }
        
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject pos in Positions)
        {
            
            Vector3 diff = pos.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                
                closest = pos;
                distance = curDistance;
            }
        }
        return closest;
    }



    void OnCollisionEnter(Collision col)
    {


        GameObject objet = col.gameObject;
        if (col.gameObject.tag == "Item1")
        {
            CmdDestrOnCol(objet);
            points = points + col.gameObject.GetComponent<Item1_sc>().itemvalue;
        }
        if (col.gameObject.tag == "Item2")
        {
            CmdDestrOnCol(objet);
            points = points + col.gameObject.GetComponent<Item2_sc>().itemvalue;
        }
        if (col.gameObject.tag == "Item3")
        {
            CmdDestrOnCol(objet);
            points = points + col.gameObject.GetComponent<Item3_sc>().itemvalue;
        }



    }

    [Command]
    public void CmdDestrOnCol(GameObject objet)
    {
        Destroy(objet);
    }
}
