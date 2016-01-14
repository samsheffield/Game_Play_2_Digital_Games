using UnityEngine;
using System.Collections;

public class MeatBoyCamera : MonoBehaviour
{

    // Move the camera to follow a specified target. 
    // Includes a "dead zone" in which the target can move without causing the camera to follow.

    public GameObject target; // Add the GameObject you want to follow through the Inspector

    // Set limits to camera movement
    public float xThreshold, yThreshold; // "Dead zone" in which there is no camera movement
    public float smoothing = .5f; // Camera tracking smoothing. Higher=faster
    public bool limitCamera;
    public Vector2 min, max;

    void Start()
    {
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
            Vector3 position = transform.position;
            // Compare the absolute (non-negative) position of the camera and the target
            float xDifference = Mathf.Abs(target.transform.position.x - transform.position.x);
            float yDifference = Mathf.Abs(target.transform.position.y - transform.position.y);

            // Check if player's position to the camera has changed enough and set position to new target position
            if (xDifference >= xThreshold)
            {
                position.x = target.transform.position.x;
            }
            if (yDifference >= yThreshold)
            {
                position.y = target.transform.position.y;
            }

            // Limit the minimum and maximum positioning of the camera using Mathf.Clamp
            if (limitCamera)
            {
                position.x = Mathf.Clamp(position.x, min.x, max.x);
                position.y = Mathf.Clamp(position.y, min.y, max.y);
            }

            // Apply new position using lerp, so that the change is smoothed
            transform.position = Vector3.Lerp(transform.position, position, smoothing * Time.fixedDeltaTime);
        }

    }
}
