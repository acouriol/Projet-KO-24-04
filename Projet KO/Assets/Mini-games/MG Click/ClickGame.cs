using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ClickGame : Score {

	void Start() {
		score = 0;
	}


	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			score += 1;
			print (score);
		}	
	}
}
