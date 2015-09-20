using UnityEngine;
using System.Collections;

public class Thrust : MonoBehaviour {

	public float turnForce = 40f;
	public float thrustForce = 400f;

	private float turnDirection; // Used to store input directions (-1, 0, or 1)
	private Rigidbody2D rb2D; // This gameObject's Rigidbody2D component
	private bool thrust;

	// Use this for initialization
	void Start () {
		// Store reference to the Rigidbody 2D attached to this gameObject
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		// More responsive input in Update()
		// Use horizontal input for rotation direction
		turnDirection = Input.GetAxisRaw ("Horizontal");

		// Use button press for thrust input. Change in Input Manager
		// GetButton vs. GetButtonDown : The former is continuous
		if( Input.GetButton("Jump") ){
			thrust = true;
		}

	}

	// Use this for physics
	void FixedUpdate(){

		// If the thrust button is pressed
		if(thrust){
			thrust = false; // reset the variable

			// Add force using the gameObject's transform.up
			// This allows movement toward the gameObject's top, regardless of rotation.
			rb2D.AddForce ( transform.up * thrustForce );
		}

		// 
		rb2D.angularVelocity = turnDirection * -turnForce;
	}
}
