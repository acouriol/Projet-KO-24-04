using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SquareTypes : NetworkBehaviour {

	public enum SquareType
	{
		BONUS,
		MALUS,
		ALEA,
		NEUTRAL,
		OTHER
	}
		
}