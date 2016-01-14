using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{

    // UPDATED: Now Vector2 variables
    public Vector2 velocity = new Vector2(15f, 15f); // Used to store velocity

    public int totalJumps = 2; // How many jumps
    private int jumpCount; // Keep track of the number of times player has jumped
    public float jumpForce = 900f; // Set this to jump. Needs to be pretty high to overcome gravity!
    private bool jumpNow; // Time for jumping?

    public bool isGrounded; // Currently touching the ground (GameObject tagged as "Ground")?

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
        direction.y = Input.GetAxisRaw("Vertical");

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

        // NEW FOR JUMP!
        // Check if button has been bressed and if there are remaining jumps left
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCount < totalJumps)
            {
                jumpNow = true; // Signal that it is time to jump
                jumpCount++; // Increment jump count
            }
        }

        // Sometimes you need to flip horizontAL direction...
        Flip();

        // Set the isMoving int parameter to the Animator component attached to this GameObject
        // direction.x is a float so (int) is used to cast it to an int
        // Int animator parameters offer more options than float 

        // Add animator setinteger here
        anim.SetInteger("isMoving", (int)direction.x);
        // Use this component's isGrounded bool to choose animation state (jumping or standing/moving)
        anim.SetBool("isGrounded", isGrounded);
    }

    // Update used for physics
    void FixedUpdate()
    {
        // UPDATED FOR JUMP!
        // Adjust the gameObject's x velocity and leave the y velocity as it is (for jumping)
        rb2D.velocity = new Vector2(direction.x * velocity.x, rb2D.velocity.y);

        // If jump signal is set...
        if (jumpNow)
        {
            Jump(); // Jump!
        }
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

    void Jump()
    {
        // Stop velocity on y axis for more consistent jumping. Keep x velocity the same.
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        // Add a momentary push upward
        rb2D.AddForce(Vector2.up * jumpForce);
        // Reset jumping boolean
        jumpNow = false;
    }

    // Trigger collider is on the child. Since we have only one trigger collider, it's easy to detect collision with ground
    // We'll discuss using a Linecast2d/Layer Mask combo in the future.
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true; // Touching ground
            jumpCount = 0; // reset the jump count when touching the ground
        }
    }

    // Reset isGrounded to false when exiting ground collision
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false; // Not touching ground
        }
    }

}
