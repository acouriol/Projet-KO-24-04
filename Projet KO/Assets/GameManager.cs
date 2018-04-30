using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

	[SyncVar] int numplayers;
	public GameObject Bot;

	public SyncListString SyncListPlayers =  new SyncListString();
	public SyncListString SyncListPlayOrder =  new SyncListString();

	[SyncVar] public int turnindex;
	[SyncVar] public bool onminigame = false;

	private bool arereadyplayers = false;



	void Start () {


		turnindex = 0;
		numplayers = NetworkManager.singleton.numPlayers;



		for (int i = numplayers; i < 4; i++) {

			GameObject temp = Instantiate (Bot, NetworkManager.singleton.GetStartPosition().position, NetworkManager.singleton.GetStartPosition().localRotation);
			NetworkServer.Spawn (temp);

		}
	

	}

	void AleaPlayOrder()
	{
		List<int> Ltemp = new List<int> (){0, 1, 2, 3};
		int temp;

		while (SyncListPlayOrder.Count != 4) {
			temp = Random.Range (0, 4);

			if (Ltemp.Contains(temp)) {
				SyncListPlayOrder.Add (SyncListPlayers [temp]);
				Ltemp.RemoveAt(Ltemp.IndexOf(temp));
			}
		}

	}
		

	void Update()
	{
		if (!arereadyplayers) {
			SyncListPlayers.Clear ();
			for (int i = 1; SyncListPlayers.Count < 4 && i <= 9; i++) {
				GameObject player = GameObject.FindGameObjectWithTag ("Player" + i);

				if (player != null)
					SyncListPlayers.Add ("Player" + i);
			}

			if (SyncListPlayers.Count == 4) {
				for (int j = 0; j < 4; j++) {
					GameObject player = GameObject.FindGameObjectWithTag (SyncListPlayers [j]);
					player.transform.position = GameObject.Find ("Square 0").transform.GetChild (j).transform.position;
				}
				arereadyplayers = true;
				AleaPlayOrder();
			}
		}



		if (!onminigame)
		{
			if (turnindex < 4 && !GameObject.FindGameObjectWithTag (SyncListPlayOrder [turnindex]).GetComponent<Character> ().ishisturn) {
				Character currentplayer = GameObject.FindGameObjectWithTag (SyncListPlayOrder [turnindex]).GetComponent<Character> ();
				currentplayer.ishisturn = true;
				currentplayer.arediceslaunched = false;
			
			} 

			else if (turnindex == 4) {
				onminigame = true;
				//launch mini-game
			}




		}
			
	}

}
