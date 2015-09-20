using UnityEngine;
using System.Collections;

public class Flap : MonoBehaviour {

	// BE SURE TO ADD GRAVITY TO THIS GAMEOBJECT!

	public float xForce = 40f;
	public float yForce = 400f;
	public float angleLimit = 45f;

	private Rigidbody2D rb2D;
	private float xDirection;
	private bool flap;

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

		// Use button press for flap input. Change in Input Manager
		if( Input.GetButtonDown("Jump") ){
			flap = true;
		}

	}

	// Update used for physics
	void FixedUpdate(){

		// Has the flap button been pressed?
		if(flap == true){
			flap = false; // Reset the variable

			// Add flappy force on y axis
			rb2D.AddForce ( new Vector2(0, yForce) );
			//rb2D.AddForce ( Vector2.up * yForce );
		}

		// Add force to x axis
		rb2D.AddForce( new Vector2(xForce * xDirection, 0) );
		//rb2D.AddForce( Vector2.right * xForce * xDirection ); // ALTERNATIVE : Use Vector math

		// Add rotation velocity
		rb2D.angularVelocity = xDirection * -xForce;
		//rb2D.angularVelocity = Mathf.Clamp ( xDirection * -xForce, -angleLimit, angleLimit ); // ALTERNATIVE : Limit rotation with Mathf.Clamp()
	}
}
