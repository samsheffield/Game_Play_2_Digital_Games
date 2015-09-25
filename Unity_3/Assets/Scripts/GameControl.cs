using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public ScoreKeeper scoreKeeper; // Set to the GameObject containing ScoreKeeper component. Use the Inspector to set.
	public int scoreLimit = 5;
	public int badScoreLimit = 2;

	void Update () {

		// Example of switching a scene when a maximum score is reached or exceeded
		if(scoreKeeper.score >= scoreLimit){
			Application.LoadLevel ("End"); // Load the End scene added to your Build Settings
		}
	}

	// Example method used when the game is over. Set to public so that it can be called from outside this script
	public void EndGame(){
		
		// BONUS: PlayerPrefs can be used to share data between scenes and is even persistent between play sessions
		// SetInt() will save an int to the key (first argument in quotes). The second argumet is the int to save.
		PlayerPrefs.SetInt("score", scoreKeeper.score);

		// Example conditional endings
		if (scoreKeeper.score < badScoreLimit){
			Application.LoadLevel ("Bad"); // Load the Bad scene added to your Build Settings
		}
		else{
			Application.LoadLevel ("Good");
		}
	}
}
