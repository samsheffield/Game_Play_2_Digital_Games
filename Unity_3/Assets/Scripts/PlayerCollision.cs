using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	// Store a reference to a GameObject with a ScoreKeeper component. Set this in the Inspector.
	public ScoreKeeper scoreKeeper;

	// Store a reference to the AudioSource component attached to this gameObject. "private" makes this variable available only to this script
	private AudioSource a;

	// Used to store a reference to the VelocityMove component on this GameObject. Use private so that it won't be shared in the Inspector.
	private VelocityMove vMove;

	// The point value for fruit
	public int fruitPoints = 1;

	// Array of available sound clips. Set in Inspector.
	public AudioClip[] clips;


	void Start(){
		// Get the referenced components and store in variables.
		vMove = GetComponent<VelocityMove>();
		a = GetComponent<AudioSource>();
	}

	// Be sure to set on of the collider's as Is Trigger
	void OnTriggerEnter2D (Collider2D other){

		// Filter triggers by tag
		if (other.gameObject.tag == "Fruit"){
			// Play the 1st sound clip
			a.PlayOneShot (clips[0]);

			// Increase score
			scoreKeeper.SetScore(fruitPoints);

			// BONUS: RESPAWN IN RANDOM LOCATION
			other.gameObject.transform.position = new Vector2(Random.Range (-9, 9), Random.Range (-5, 5));

			// OPTIONAL: Remove other
			//Destroy(other.gameObject);
		}
		else if(other.gameObject.tag == "Power"){
			// Play the 1st sound clip
			a.PlayOneShot (clips[0]);

			// VelocityMove's public PowerUp() method is an IEnumerator, so StartCroutine is needed to run it.
			StartCoroutine( vMove.PowerUp() );
		}
	}
}
