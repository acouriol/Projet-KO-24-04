using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Map : NetworkBehaviour {

	public static List<Square> map;


	void Start () {

		Square square0 = GameObject.Find("Square 0").GetComponent<Square> ();

		Square square1 = GameObject.Find("Square 1").GetComponent<Square> ();
		Square square2 = GameObject.Find("Square 2").GetComponent<Square> ();
		Square square3 = GameObject.Find("Square 3").GetComponent<Square> ();
		Square square4 = GameObject.Find("Square 4").GetComponent<Square> ();
		Square square5 = GameObject.Find("Square 5").GetComponent<Square> ();
		Square square6 = GameObject.Find("Square 6").GetComponent<Square> ();
		Square square7 = GameObject.Find("Square 7").GetComponent<Square> ();
		Square square8 = GameObject.Find("Square 8").GetComponent<Square> ();
		Square square9 = GameObject.Find("Square 9").GetComponent<Square> ();
		Square square10 = GameObject.Find("Square 10").GetComponent<Square> ();

		Square square11 = GameObject.Find("Square 11").GetComponent<Square> ();
		Square square12 = GameObject.Find("Square 12").GetComponent<Square> ();
		Square square13 = GameObject.Find("Square 13").GetComponent<Square> ();
		Square square14 = GameObject.Find("Square 14").GetComponent<Square> ();
		Square square15 = GameObject.Find("Square 15").GetComponent<Square> ();
		Square square16 = GameObject.Find("Square 16").GetComponent<Square> ();
		Square square17 = GameObject.Find("Square 17").GetComponent<Square> ();
		Square square18 = GameObject.Find("Square 18").GetComponent<Square> ();
		Square square19 = GameObject.Find("Square 19").GetComponent<Square> ();
		Square square20 = GameObject.Find("Square 20").GetComponent<Square> ();


		Square square21 = GameObject.Find("Square 21").GetComponent<Square> ();
		Square square22 = GameObject.Find("Square 22").GetComponent<Square> ();
		Square square23 = GameObject.Find("Square 23").GetComponent<Square> ();
		Square square24 = GameObject.Find("Square 24").GetComponent<Square> ();
		Square square25 = GameObject.Find("Square 25").GetComponent<Square> ();
		Square square26 = GameObject.Find("Square 26").GetComponent<Square> ();
		Square square27 = GameObject.Find("Square 27").GetComponent<Square> ();
		Square square28 = GameObject.Find("Square 28").GetComponent<Square> ();
		Square square29 = GameObject.Find("Square 29").GetComponent<Square> ();
		Square square30 = GameObject.Find("Square 30").GetComponent<Square> ();


		Square square31 = GameObject.Find("Square 31").GetComponent<Square> ();
		Square square32 = GameObject.Find("Square 32").GetComponent<Square> ();
		Square square33 = GameObject.Find("Square 33").GetComponent<Square> ();
		Square square34 = GameObject.Find("Square 34").GetComponent<Square> ();
		Square square35 = GameObject.Find("Square 35").GetComponent<Square> ();
		Square square36 = GameObject.Find("Square 36").GetComponent<Square> ();
		Square square37 = GameObject.Find("Square 37").GetComponent<Square> ();
		Square square38 = GameObject.Find("Square 38").GetComponent<Square> ();
		Square square39 = GameObject.Find("Square 39").GetComponent<Square> ();
		Square square40 = GameObject.Find("Square 40").GetComponent<Square> ();

		map = new List<Square>(){square0, square1, square2, square3, square4, square5, square6, square7,square8,square9,square10,  square11, square12, square13, square14, square15, square16, square17,square18,square19,square20,  square21, square22, square23, square24, square25, square26, square27,square28,square29,square30};

	}



}
