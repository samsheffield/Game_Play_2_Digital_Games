using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndManager : MonoBehaviour {

	// Store a reference to the Text GameObject
	public Text displayText;

	private int finalScore;

	// Use this for initialization
	void Start () {

		// Load the int previously saved in PlayerPrefs using the "score" key.
		finalScore = PlayerPrefs.GetInt("score");
		displayText.text = "Final Score: " + finalScore.ToString("0000");

	}

}
