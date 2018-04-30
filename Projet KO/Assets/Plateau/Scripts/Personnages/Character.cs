using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Character : NetworkBehaviour {

	public bool isabot = false;

	public bool arediceslaunched = false;


	[SyncVar] public int movesquares = 0;
	[SyncVar] public int positioninmap = 0;

	private Vector3 nextsquarepos;
	private bool adjustedpos = true;

	//public int lastpositioninlb;
	[SyncVar] public bool ishisturn = false;

	public GameObject BonusTpParticle;
	public GameObject MalusTpParticle;
	private GameObject tempParticle;


	private bool startCount = false;
	private float startTime = 0.0f;
	private GameObject squarecolided;

	public bool AdjustedPos
	{
		get{return adjustedpos;}
		set{adjustedpos = value;}
	}


	void Start () {
		//pos on the square


	}
		
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Square") {

			positioninmap = col.gameObject.GetComponent<Square> ().squarenumber;
			col.gameObject.GetComponent<Square> ().playerson += 1;
			this.squarecolided = col.gameObject;

			if (col.gameObject.GetComponent<Square>().type != Square.SquareType.NEUTRAL && movesquares == 0) {

				startTime = Time.time;
				startCount = true;

				if (isLocalPlayer)
					CmdInstantiateSquareParticles ();
			}
		}
	}

	[Command]
	void CmdInstantiateSquareParticles()
	{
		if (squarecolided.GetComponent<Square> ().type == Square.SquareType.BONUS) {
			tempParticle = Instantiate (BonusTpParticle, new Vector3 (squarecolided.transform.position.x, squarecolided.transform.position.y + 0.15f, squarecolided.transform.position.z), squarecolided.transform.localRotation);
			NetworkServer.Spawn (tempParticle);
			Destroy (tempParticle, 3.0f);

		} 

		else if (squarecolided.GetComponent<Square> ().type == Square.SquareType.MALUS) {
			tempParticle = Instantiate (MalusTpParticle, new Vector3 (squarecolided.transform.position.x, squarecolided.transform.position.y + 0.15f, squarecolided.transform.position.z) , squarecolided.transform.localRotation );
			NetworkServer.Spawn (tempParticle);

			Destroy (tempParticle, 3.0f);

		}



	
	}

	void FixedUpdate(){

		if (ishisturn) {
			
			if (isLocalPlayer) {
				if (Input.GetKeyDown (KeyCode.Return) && adjustedpos) {
					movesquares = Random.Range (1, 7);
					arediceslaunched = true;
				} else if (Input.GetKeyDown (KeyCode.KeypadPlus) && adjustedpos) {
					movesquares = 1;
					arediceslaunched = true;
				}



				if (movesquares > 0) {
					Square nextsquare = Map.map [positioninmap + 1]; // add condition here for the end of the map
					int numplayersonsquare = nextsquare.playerson;
					nextsquarepos = new Vector3 (nextsquare.transform.GetChild (numplayersonsquare).transform.position.x, this.transform.position.y, nextsquare.transform.GetChild (numplayersonsquare).transform.position.z);
					adjustedpos = false;

					this.transform.position = Vector3.MoveTowards (transform.position, nextsquarepos, 10 * Time.deltaTime);

					//this.transform.rotation = Quaternion.LookRotation
				} else if (movesquares == 0 && !adjustedpos) {
					this.transform.position = Vector3.MoveTowards (transform.position, nextsquarepos, 10 * Time.deltaTime);

					if (this.transform.position == nextsquarepos) {
						adjustedpos = true;

					}
				}
			} 
			/*
			else if (isabot) {

				if (!arediceslaunched) {
					arediceslaunched = true;
					movesquares = Random.Range (1, 7);
				}

				if (movesquares > 0) {
					Square nextsquare = Map.map [positioninmap + 1]; // add condition here for the end of the map
					int numplayersonsquare = nextsquare.playerson;
					nextsquarepos = new Vector3 (nextsquare.transform.GetChild (numplayersonsquare).transform.position.x, this.transform.position.y, nextsquare.transform.GetChild (numplayersonsquare).transform.position.z);
					adjustedpos = false;

					this.transform.position = Vector3.MoveTowards (transform.position, nextsquarepos, 10 * Time.deltaTime);

					//this.transform.rotation = Quaternion.LookRotation
				} 

				else if (movesquares == 0 && !adjustedpos) {
					this.transform.position = Vector3.MoveTowards (transform.position, nextsquarepos, 10 * Time.deltaTime);

					if (this.transform.position == nextsquarepos) {
						adjustedpos = true;
						ishisturn = false;

					}
				}
			}*/
		}

		if (startCount && squarecolided.tag == "Square") {

			if (startTime + 3.0f < Time.time) {
				startCount = false;

				if (squarecolided.GetComponent<Square> ().type == Square.SquareType.BONUS) {
					Square newsquarepos = Map.map [positioninmap + squarecolided.GetComponent<Square> ().bonusmove];
					int numplayersonsquare = newsquarepos.playerson;
					this.transform.position = new Vector3 (newsquarepos.transform.GetChild(numplayersonsquare).transform.position.x, this.transform.position.y, newsquarepos.transform.GetChild(numplayersonsquare).transform.position.z);

				}

				else if (squarecolided.GetComponent<Square> ().type == Square.SquareType.MALUS) {
					Square newsquarepos = Map.map [positioninmap - squarecolided.GetComponent<Square> ().malusmove];
					int numplayersonsquare = newsquarepos.playerson;
					this.transform.position = new Vector3 (newsquarepos.transform.GetChild(numplayersonsquare).transform.position.x, this.transform.position.y, newsquarepos.transform.GetChild(numplayersonsquare).transform.position.z);

				}

			}
		}

		
	}


	void OnCollisionExit (Collision col)
	{
		
		if (col.gameObject.tag == "Square") {
			
			if (movesquares > 0) {
				movesquares -= 1;
			}
			col.gameObject.GetComponent<Square> ().playerson -= 1;
		}

	}
}
