using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndManager : MonoBehaviour {

    // Variable for the final score
    private int savedScore;

    // Set this UI Text variable in the Inspector
    public Text scoreText;

	void Start () {
        // Load final score and save it into a variable
        savedScore = PlayerPrefs.GetInt("score");

        // Set UI Text with string + formatted score
        scoreText.text = "FINAL SCORE: " + savedScore.ToString("0000");
	}
	
}
