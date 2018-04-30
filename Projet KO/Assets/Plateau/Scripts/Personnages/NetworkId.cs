using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkId : NetworkBehaviour {

	[SyncVar] public string playerId;
	private NetworkInstanceId playerNetId;

	public override void OnStartServer ()
	{
		GetNetPlayerId ();
		RpcSetTag ();
	}

	[Client]
	void GetNetPlayerId ()
	{
		playerNetId = GetComponent<NetworkIdentity> ().netId;
		CmdTellServerMyId ("Player" + playerNetId.ToString());
	}

	[Command]
	void CmdTellServerMyId(string playerid)
	{
		playerId = playerid;
		this.gameObject.tag = playerId;

	}

	[ClientRpc]
	void RpcSetTag()
	{
		if (!isLocalPlayer)
			this.gameObject.tag = playerId;
		else
			gameObject.tag = "Player" + playerNetId.ToString ();
	}
}
