using UnityEngine;
using System.Collections;

public class VelocityMove : MonoBehaviour
{

    // UPDATED: Now Vector2 variables
    public Vector2 velocity = new Vector2(15f, 15f); // Used to store velocity
    private Vector2 direction; // Used to store input directions (-1, 0, or 1)

    private Rigidbody2D rb2D; // This GameObject's Rigidbody2D component

    public float deadZone = .19f; // Controller deadzone. Set in Input Manager.

    // Add Animator here
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        // Store reference to the Rigidbody 2D attached to this gameObject
        rb2D = GetComponent<Rigidbody2D>();

        // Store a reference to the Animator component here
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // More responsive input in Update()
        // Use Input Manager for input (-1 for left, 1 for right, 0 for no movement)
        direction.x = Input.GetAxisRaw("Horizontal");

        // Filter x movement
        if (direction.x > deadZone)
        {
            direction.x = 1;
        }
        else if (direction.x < -deadZone)
        {
            direction.x = -1;
        }
        else
        {
            direction.x = 0;
        }

        direction.y = Input.GetAxisRaw ("Vertical");
        // Filter y movement
        if (direction.y > deadZone)
        {
            direction.y = 1;
        }
        else if (direction.y < -deadZone)
        {
            direction.y = -1;
        }
        else
        {
            direction.y = 0;
        }

        // Sometimes you need to flip direction...
        Flip();

        // Set the isMoving int parameter to the Animator component attached to this GameObject
        // direction.x is a float so (int) is used to cast it to an int
        // Int animator parameters offer more options than float 

        // Add animator setinteger here
        anim.SetInteger("isMoving", (int)direction.x);
    }

    // Update used for physics
    void FixedUpdate()
    {
        // Adjust the gameObject's velocity by multiplying the two Vector2 variables (using Scale)
        rb2D.velocity = Vector2.Scale(velocity, direction);
    }

    // Flip the GameObject
    void Flip()
    {
        // Use direction's x property to set facing direction 
        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Reset rotation
        }
        else if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Rotate 180 on the y axis
        }
    }
}
