using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterColor : NetworkBehaviour {

	[SyncVar]
	private Color color;

	public Color Color
	{
		get{return color;}
		set{color = value;}
	}

	MeshRenderer[] rends;


	void Start () {
		rends = GetComponentsInChildren<MeshRenderer> ();
		for (int i = 0; i < rends.Length; i++)
			rends [i].material.color = color;
	}
	

}
