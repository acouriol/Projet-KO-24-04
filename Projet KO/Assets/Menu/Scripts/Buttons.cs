using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void OnlineGame()
	{
		
		SceneManager.LoadScene (2);
	}

	public void LocalGame()
	{
		SceneManager.LoadScene (3);
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
