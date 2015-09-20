using UnityEngine;
using System.Collections;

public class PlayCollisionSound : MonoBehaviour {

	// "private" makes this variable available only to this script
	private AudioSource a;

	void Start () {
		// Store a reference to the AudioSource component attached to this GameObject
		a = GetComponent<AudioSource>();
	}

	// Collision method
	void OnCollisionEnter2D(Collision2D other){

		// Play the AudioClip set in the AudioSource component
		a.Play();
	}
}
