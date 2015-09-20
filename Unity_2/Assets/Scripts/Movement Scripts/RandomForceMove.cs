using UnityEngine;
using System.Collections;

public class RandomForceMove : MonoBehaviour {

	public float xForce = 15f;
	public float yForce = 15f;
	
	private Rigidbody2D rb2D; // This gameObject's Rigidbody2D component

	// Use this for initialization
	void Start () {
		// Store reference to the Rigidbody 2D attached to this gameObject
		rb2D = GetComponent<Rigidbody2D>();

		// Apply forces at start
		rb2D.AddForce( new Vector2( Random.Range(-1f, 2f) * xForce, Random.Range(-1f, 2f) * yForce) ); // Add random force between -1 and 1 on both axes
	}
}
