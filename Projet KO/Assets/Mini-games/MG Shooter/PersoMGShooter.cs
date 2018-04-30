using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PersoMGShooter : NetworkBehaviour {


	public GameObject bullet;
	public Transform bulletSpawn;
	public int life = 5;

	void Start()
	{
	}

	void FixedUpdate()
	{
		if (isLocalPlayer)
		{
			Deplacement();

			if (Input.GetKeyDown (KeyCode.Space)) {
				CmdFire ();
			}
		}

	}

	void Deplacement()
	{
		

		float y = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		float x = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate (0, y, 0);
		transform.Translate (x, 0, 0);
	}

	[Command]
	void CmdFire()
	{
		GameObject tempbullet = Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
		tempbullet.GetComponent<Rigidbody> ().velocity = tempbullet.transform.forward * 10;

		NetworkServer.Spawn (tempbullet);

	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "BulletMGShooter")
		{
			

			if (life > 0) {
				life--;

				if (life == 0)
					Destroy (this.gameObject);
			}	
		}
	}
}
