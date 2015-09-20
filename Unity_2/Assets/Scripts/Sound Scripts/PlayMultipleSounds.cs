using UnityEngine;
using System.Collections;

public class PlayMultipleSounds : MonoBehaviour {

	// "private" makes this variable available only to this script
	private AudioSource a;

	// Create an Array[] to hold many AudioClip variables. This can be filled through the Inspector
	public AudioClip[] clips;

	void Start () {
		// Store a reference to the AudioSource component attached to this GameObject
		a = GetComponent<AudioSource>();
	}

	// Collision method
	void OnCollisionEnter2D(Collision2D other){

		// Filter collisions by tag
		if(other.gameObject.tag == "Fruit"){

			// Play the first AudioClip in the clips[] array
			a.PlayOneShot(clips[0]);
		}
		else if(other.gameObject.tag == "Car"){

			// Play the second AudioClip in the clips[] array
			a.PlayOneShot(clips[1]);
		}



	}
}
