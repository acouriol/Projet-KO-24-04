using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class perso_sc: NetworkBehaviour {

    public int points;
    private float vitesse = 0.10F;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        Deplacement();
    }

    void Deplacement()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * vitesse);
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.back * vitesse);
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up * 1.2F);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.down * 1.2F);

        if (Input.GetKeyDown(KeyCode.Space)) //le saut
            GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
    }


    

    void OnCollisionEnter(Collision col)
    {
        if (isLocalPlayer)
        {
            GameObject obj = col.gameObject;
            if (col.gameObject.tag == "Item1")
            {
                CmdDestrOnCol(obj);
                points = points + col.gameObject.GetComponent<Item1_sc>().itemvalue;
            }
            if (col.gameObject.tag == "Item2")
            {
                CmdDestrOnCol(obj);
                points = points + col.gameObject.GetComponent<Item2_sc>().itemvalue;
            }
            if (col.gameObject.tag == "Item3")
            {
                CmdDestrOnCol(obj);
                points = points + col.gameObject.GetComponent<Item3_sc>().itemvalue;
            }
            Debug.Log(points);
        }
        
        
    }

    [Command]
    public void CmdDestrOnCol(GameObject objet)
    {
        Destroy(objet);
    }

}

