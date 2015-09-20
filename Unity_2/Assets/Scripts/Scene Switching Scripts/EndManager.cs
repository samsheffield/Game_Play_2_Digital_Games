using UnityEngine;
using System.Collections;

public class EndManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		// "Jump" = space. Use Input Manager to switch.
		if( Input.GetButtonUp("Jump") ){
			
			// Load next Scene. Name must match the name of a scene added to your Build settings
			Application.LoadLevel("Start");
		}

	}
}
