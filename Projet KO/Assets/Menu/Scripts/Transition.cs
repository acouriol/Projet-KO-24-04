using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour {

	private float startTime = 0.0f;

	public int index;
	public Image black;
	public Animator anim;


	void Start () {
		startTime = Time.time;
		StartCoroutine (Fading());

	}


	IEnumerator Fading()
	{
		yield return new WaitForSeconds (2f);
		anim.SetBool ("Fade", true);
		//yield return new WaitUntil (() => black.color.a == 1);
		SceneManager.LoadScene (index);
	}
}
