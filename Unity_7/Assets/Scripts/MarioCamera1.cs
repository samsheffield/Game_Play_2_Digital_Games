using UnityEngine;
using System.Collections;

public class MarioCamera1 : MonoBehaviour
{

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
    public float ySmoothing = .5f; // Camera tracking smoothing. Higher=faster
    public bool limitCamera;
    public Vector2 min, max;

    void Start()
    {
        movePlayer = target.GetComponent<MovePlayer>();
        rb2D = target.GetComponent<Rigidbody2D>();

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
            Vector3 position = transform.position;

            if (target.transform.position.x < transform.position.x - xThreshold)
            {
                position.x = target.transform.position.x + xThreshold;
            }
            else if (target.transform.position.x > transform.position.x + xThreshold)
            {
                position.x = target.transform.position.x - xThreshold;
            }

            if(movePlayer.isGrounded && rb2D.velocity.y < Mathf.Epsilon)
            {
                position.y = target.transform.position.y;
            }

            // Limit the minimum and maximum positioning of the camera using Mathf.Clamp
            if (limitCamera)
            {
                position.x = Mathf.Clamp(position.x, min.x, max.x);
                position.y = Mathf.Clamp(position.y, min.y, max.y);
            }

 
            transform.position = new Vector3(position.x, Mathf.Lerp(transform.position.y, position.y, ySmoothing * Time.fixedDeltaTime), transform.position.z);
        }

    }
}
