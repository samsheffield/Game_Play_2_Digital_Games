using UnityEngine;
using System.Collections;

// Need this to use UI elements
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	
	public Text scoreText; // Text which displays score. Set through the Inspector.
	public int score; // Keep track of score


	// Create a function to update the score and set the Text
	// "public" allows this function to be called from other scripts
	// This function expects one int argument
	public void SetScore(int value){
		// Add to score
		score += value;

		// Set text to string + formatted score
		scoreText.text = "SCORE: " + score.ToString("0000");
	}
}
