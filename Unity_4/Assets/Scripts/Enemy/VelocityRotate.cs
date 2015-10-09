using UnityEngine;
using System.Collections;

public class VelocityRotate : MonoBehaviour {

	// How fast to spin
    public float spinVelocity = 30f;

    // Variable to hold refernce to the Rigidbody2D component attached to this GameObject
    private Rigidbody2D rb2D;

    void Start()
    {
    	// Find component
        rb2D = GetComponent<Rigidbody2D>();

        // Start spinning by setting angular velocity
        rb2D.angularVelocity = spinVelocity;
    }
}
