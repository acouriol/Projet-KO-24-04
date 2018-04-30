using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;


public class CharacterColorHook : LobbyHook {

	public override void OnLobbyServerSceneLoadedForPlayer (NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
	{
		LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer> ();
		CharacterColor character = gamePlayer.GetComponent<CharacterColor> ();

		character.Color = lobby.playerColor;
	} 
}
