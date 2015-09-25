using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextTest : MonoBehaviour {

	public Text displayText; // Set in inspector

	// Update is called once per frame
	void Update () {

		if(Input.GetKey (KeyCode.A )){
			displayText.text = "YES!"; // use string with text property
		}
		else{
			displayText.text = "NO?";
		}

	}
}
