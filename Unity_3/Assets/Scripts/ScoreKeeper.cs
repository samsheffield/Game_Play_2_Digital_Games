using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	
	public Text scoreText; // Text which displays score. Set through the Inspector.
	public int score; // Keep track of score


	// Create a function to update the score and set the Text
	// "public" allows this function to be called from other scripts
	// This function expects one int argument
	public void SetScore(int value){
		score += value;
		scoreText.text = "SCORE: " + score.ToString("0000");
	}
}
