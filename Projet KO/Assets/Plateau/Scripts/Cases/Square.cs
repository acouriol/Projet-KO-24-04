using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Square : SquareTypes {

	public SquareType type;

	public int squarenumber;

	public int bonusmove = 0;
	public int malusmove = 0;

	public int playerson = 0;    //players on the square


	void Start()
	{


		if (this.type==SquareType.NEUTRAL)
		{
			GetComponent<Renderer>().material.color = Color.white;
		}

		else if (this.type==SquareType.MALUS)
		{
			GetComponent<Renderer>().material.color = Color.red;
		}

		else if (this.type==SquareType.BONUS)
		{
			GetComponent<Renderer>().material.color = Color.green;
		}

		else if (this.type==SquareType.ALEA)
		{
			GetComponent<Renderer>().material.color = Color.yellow;
		}

		else if (this.type==SquareType.OTHER)
		{
			GetComponent<Renderer>().material.color = Color.cyan;
		}
	}
		
}
