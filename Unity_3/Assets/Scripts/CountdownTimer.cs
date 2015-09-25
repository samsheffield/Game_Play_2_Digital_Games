using UnityEngine;
using System.Collections;

// NEED TO ADD THIS TO USE UI!
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public Text timerText; // Set this to your UI Text through the Inspector
	public GameControl gameControl; // Set this to the GameObject containing the CameControl component.

	public int duration = 10; // Length of timer
	public float rate = 1f; // Rate of timer
	public float delay = 2f; // How long to wait before starting the timer

	// Use this for initialization
	void Start () {
		// Convert the duration to a String and set the text.
		timerText.text = "TIME: " + duration.ToString();
		//timerText.text = "TIME: " + duration.ToString("00"); // ALTERNATIVE : Force the formatting to a specified number of digits.

		// Begin the IEnumerator timer.
		StartCoroutine(Countdown());
	}
	
	// This kind of function runs in a different thread so it won't interfere with your other code.
	IEnumerator Countdown(){

		// while() continues to run while its condition is true.
		while(duration > 0){

			// Wait for a number of seconds.
			yield return new WaitForSeconds(rate);

			// Reduce the duration.
			duration--;

			// Convert the duration to a String and set the text.
			timerText.text = "TIME: " + duration.ToString();
			//timerText.text = "TIME: " + duration.ToString("00"); // ALTERNATIVE : Force the formatting to a specified number of digits.
		}

		// When done, call the public EndGame() method in gameControl
		gameControl.EndGame();
	}
}
