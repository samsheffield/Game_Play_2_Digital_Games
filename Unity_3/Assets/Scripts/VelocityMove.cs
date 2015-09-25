using UnityEngine;
using System.Collections;

public class VelocityMove : MonoBehaviour {

	// Velocity variables
	public float xVelocity = 20f;
	public float yVelocity = 20f;
	
	// Used to store input directions (-1, 0, or 1)
	private float xDirection, yDirection; 

	private Rigidbody2D rb2D; // This gameObject's Rigidbody2D component. Use private since this does not need to be shared

	private bool boost; // Keep track of boost state (true or false)
	public float boostScaler = 3f; // Multiplies the velocity to create the boost effect
	public float boostDuration = 2f; // Length of boost

	// Use this for initialization
	void Start () {
		// Store reference to the Rigidbody 2D attached to this gameObject
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// More responsive input in Update()
		// Use Input Manager for input (-1 for left, 1 for right, 0 for no movement)
		xDirection = Input.GetAxisRaw ("Horizontal");
		yDirection = Input.GetAxisRaw ("Vertical");
	}

	// Update used for physics
	void FixedUpdate(){

		// If boost is set...
		if(boost){
			// Adjust the gameObject's velocity x boostScaler
			rb2D.velocity = new Vector2(xVelocity * xDirection * boostScaler, yVelocity * yDirection * boostScaler);
		}
		else {
			// Adjust the gameObject's velocity
			rb2D.velocity = new Vector2(xVelocity * xDirection, yVelocity * yDirection);
		}
	}

	// Temporary boost using delays. Set to public so that it can be called from other scripts.
	public IEnumerator PowerUp(){
		boost = true;

		// Keep boost true for this long...
		yield return new WaitForSeconds(boostDuration);

		// Then set back to false.
		boost = false;
	}
}
