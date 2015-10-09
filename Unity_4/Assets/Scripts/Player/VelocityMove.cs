using UnityEngine;
using System.Collections;

public class VelocityMove : MonoBehaviour {

    // UPDATED: Now Vector2 variables
	public Vector2 velocity = new Vector2(15f, 15f); // Used to store velocity
	private Vector2 direction; // Used to store input directions (-1, 0, or 1)

    private bool boost; // Keep track of boost state (true or false)
    public float boostScaler = 3f; // Multiplies the velocity to create the boost effect
    public float boostDuration = 2f; // Length of boost

    private Rigidbody2D rb2D; // This gameObject's Rigidbody2D component

	// Use this for initialization
	void Start ()
    {
		// Store reference to the Rigidbody 2D attached to this gameObject
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		// More responsive input in Update()
		// Use Input Manager for input (-1 for left, 1 for right, 0 for no movement)
		direction.x = Input.GetAxisRaw ("Horizontal");
		direction.y = Input.GetAxisRaw ("Vertical");
	}

    // Update used for physics
    void FixedUpdate()
    {
        // If boost is set...
        if (boost)
        {
            // Adjust the gameObject's velocity by multiplying the two Vector2 variables (using Scale)
            rb2D.velocity = Vector2.Scale(velocity, direction) * boostScaler;
        }
        else
        {
            // Adjust the gameObject's velocity by multiplying the two Vector2 variables (using Scale)
            rb2D.velocity = Vector2.Scale(velocity, direction);
        }
        
    }

    // Temporary boost using delays. Set to public so that it can be called from other scripts.
    public IEnumerator PowerUp()
    {
        boost = true;
        // Keep boost true for this long...
        yield return new WaitForSeconds(boostDuration);
        // Then set back to false.
        boost = false;
    }
}
