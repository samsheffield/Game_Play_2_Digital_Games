using UnityEngine;
using System.Collections;

public class PlayRandomPitch : MonoBehaviour {
	
	// "private" makes this variable available only to this script
	private AudioSource a;
	
	void Start () {
		// Store a reference to the AudioSource component attached to this GameObject
		a = GetComponent<AudioSource>();
	}
	
	// Collision method
	void OnCollisionEnter2D(Collision2D other){
		
		a.pitch = Random.Range(.25f, 3f); // Set the pitch of the audio to a random number in a range
		
		// Play the AudioClip set in the AudioSource component
		a.Play();
	}
}
