using UnityEngine;
using System.Collections;

public class ForceMove : MonoBehaviour {

	public float xForce = 15f;
	public float yForce = 15f;

	private float xDirection, yDirection; // Used to store input directions (-1, 0, or 1)

	private Rigidbody2D rb2D; // This gameObject's Rigidbody2D component

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

		// Apply forces on x & y axes
		rb2D.AddForce( new Vector2(xForce * xDirection, yForce * yDirection) );
	}
}
