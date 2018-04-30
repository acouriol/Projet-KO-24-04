using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Timer : NetworkBehaviour {

	private float time = 10.0f;

	void Start () {
		StartCoroutine (timer ());
		time +=1;
	}

	IEnumerator timer()
	{
		while (time > 0) {
			time --;
			yield return new WaitForSeconds (1f);
			GameObject.Find ("Timer").GetComponent<Text>().text = string.Format("{0}",Mathf.Floor(time));
		}

	}
}
