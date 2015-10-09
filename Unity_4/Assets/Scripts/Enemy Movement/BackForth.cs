using UnityEngine;
using System.Collections;

public class BackForth : MonoBehaviour
{

    // Store a reference to the Rigidbody2D component attached to the GameObject
    private Rigidbody2D rb2D;

    // How frequently should this change direction
    public float interval = 1f;

    // Velocity and direction properties
    public Vector2 velocity = new Vector2(20f, 0);
    public Vector2 direction = new Vector2(1, 0); // Set to -1, 0, or 1 to choose direction

    void Start()
    {
        // Find component
        rb2D = GetComponent<Rigidbody2D>();

        // Begin moving
        StartCoroutine(ChangeDirection());
    }

    void FixedUpdate()
    {
        // Multiply velocity and direction vectors to create movement
        rb2D.velocity = Vector2.Scale(velocity, direction);
    }

    // Changes direction at a set interval
    IEnumerator ChangeDirection()
    {
        // Don't stop...
        while (true)
        {
            // Wait and then reverse direction
            yield return new WaitForSeconds(interval);
            direction = direction * -1;
        }
    }
}
