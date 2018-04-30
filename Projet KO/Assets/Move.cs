using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Move : NetworkBehaviour {

	float y;
	float x;


	void Start()
	{
		y = 0;
		x= 0;

	}

	void Update () {

		if (!isLocalPlayer) {
			return;
		}
		y = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		x = Input.GetAxis ("Vertical") * Time.deltaTime * 15.0f;

		transform.Rotate (0, y, 0);
		transform.Translate (x, 0, 0);
	}
}
