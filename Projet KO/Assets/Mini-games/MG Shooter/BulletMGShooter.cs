using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMGShooter : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		Destroy (this.gameObject);	
	}
}
