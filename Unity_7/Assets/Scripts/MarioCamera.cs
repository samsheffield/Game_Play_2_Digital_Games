using UnityEngine;
using System.Collections;

public class MarioCamera : MonoBehaviour
{
    // TO DO: NEED TO ADJUST Y BASED ON VELOCITY TO LEAD FALLS. AVOID LARGE DROPS LARGE Y SMOOTHING FOR NOW

    // Move the camera to follow a specified target. 
    // Includes a "dead zone" in which the target can move without causing the camera to follow.
    // No smoothing. Reaching the edge of the dead zone allows the player to drag around the camera
    // Platform snapping on y axis.

    public GameObject target; // Add the GameObject you want to follow through the Inspector

    // Access these components
    private MovePlayer movePlayer;
    private Rigidbody2D rb2D;

    // Set limits to camera movement
    public float xThreshold; // "Dead zone" in which there is no camera movement
    public float xOffset = 3f; // Look ahead by this amount
    public Vector2 smoothing = new Vector2(2f, .5f); // Camera tracking smoothing. Higher=faster

    public bool limitCamera;
    public Vector2 min, max;

    void Start()
    {
        movePlayer = target.GetComponent<MovePlayer>();
        rb2D = target.GetComponent<Rigidbody2D>();

        // Warning if you forget to set the camera limits
        if (limitCamera)
        {
            if (min.x == max.x || min.y == max.y)
            {
                Debug.LogWarning("Camera limits are the same on at least one axis. Camera will not move on that axis.");
            }
        }
    }

    void FixedUpdate()
    {
        // Check if the target exists before trying to follow it
        if (target != null)
        {
            Vector3 position = transform.position; // Temporary variable to set position
            
            Vector3 targetPosition = target.transform.position; // Temporary variable to hold taarget position
            targetPosition.x = targetPosition.x + (target.transform.right.x * xOffset); // Modify x property to include an offset in the direction the player is facing

            // Compare the absolute (non-negative) position of the camera and the target
            float xDifference = Mathf.Abs(targetPosition.x - position.x);
            if (xDifference > xThreshold)
            {
                position.x = targetPosition.x;
            }

            // Snap to platform
            if (movePlayer.isGrounded && rb2D.velocity.y < Mathf.Epsilon)
            {
                position.y = targetPosition.y;
            }

            // Limit the minimum and maximum positioning of the camera using Mathf.Clamp
            if (limitCamera)
            {
                position.x = Mathf.Clamp(position.x, min.x, max.x);
                position.y = Mathf.Clamp(position.y, min.y, max.y);
            }

            // Use two different lerped numbers so that each axis can have different smoothing
            float lerpedXPosition = Mathf.Lerp(transform.position.x, position.x, smoothing.x * Time.fixedDeltaTime);
            float lerpedYPosition = Mathf.Lerp(transform.position.y, position.y, smoothing.y * Time.fixedDeltaTime);

            // Apply transformations
            transform.position = new Vector3(lerpedXPosition, lerpedYPosition, position.z);
        }

    }
}
