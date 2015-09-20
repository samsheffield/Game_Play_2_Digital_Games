using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		// Winning & losing conditions
		if( Input.GetKeyUp (KeyCode.A) ){
			// Load next Scene. Name must match the name of a scene added to your Build settings
			Application.LoadLevel("Win");
		}
		else if( Input.GetKeyUp (KeyCode.D) ){
			Application.LoadLevel("Lose");
		}


		// Alternative method: Use axis via Input Manager 
		/*
		if( Input.GetAxisRaw ("Horizontal") == -1 ){
			Application.LoadLevel("Win");
		}
		else if( Input.GetAxisRaw ("Horizontal") == 1 ){
			Application.LoadLevel("Lose");
		}
		*/

	}
}
