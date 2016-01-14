using UnityEngine;
using System.Collections;

public class PlatformerCamera : MonoBehaviour
{
    // Move the camera to follow a specified target. Place this script on the Main Camera in your scene.

    [Tooltip("Set camera target")]
    public GameObject target; // Add the GameObject you want to follow through the Inspector

    [Tooltip("Toggle camera gizmo in Scene view")]
    public bool showGizmo = true;

    // Set limits to camera movement
    [Tooltip("Amount to shift the camera ahead of player")]
    public float xLead = 2f;

    [Tooltip("Amount of y movement allowed before camera adjusts")]
    public float yThreshold; // "Dead zone" in which there is no camera movement

    [Tooltip("Adjust the speed of camera tracking. Can smooth jerky camera movement")]
    // Add slider...
    [Range(0.25f, 3f)]
    public float smoothing = 2f; // Camera tracking smoothing. Higher=faster

    [Tooltip("If Limit Camera is checked, be sure to set Min & Max camera bounds below")]
    public bool limitCamera;
    public Vector2 min, max;

    void Start()
    {
        // Display error if no target has been set
        if (target == null)
            Debug.LogError("No camera target set!");

        // Display warning if you forget to set the camera limits
        if (limitCamera)
        {
            if (min.x == max.x || min.y == max.y)
                Debug.LogWarning("Camera limits are the same on at least one axis. Camera will not move on that axis.");
        }
    }

    // NEW: LateUpdate runs after all movement has been applied. This + Rigidbody2D interpolate will help smooth movement
    void LateUpdate()
    {
        // If there is no target, don't allow code after return; to run
        if (target == null)
            return;

        // Temp variables because writing target.transform.position over & over is a drag...
        Vector3 pos = transform.position;
        Vector3 tPos = target.transform.position;

        // Modify target x property to include an offset in the direction the player is facing that is the size of the lead (lead * 2)
        tPos.x = tPos.x + (target.transform.right.x * (xLead * 2));

        // Compare the absolute (non-negative) position of the camera and the target
        float yDifference = Mathf.Abs(tPos.y - pos.y);
        float xDifference = Mathf.Abs(tPos.x - pos.x);

        // Check if the player has exceeded the X and Y thresholds
        if (xDifference > xLead)
            pos.x = Mathf.Lerp(pos.x, tPos.x, smoothing * Time.deltaTime); // Gradually move

        if (yDifference > yThreshold)
            pos.y = Mathf.Lerp(pos.y, tPos.y, smoothing * (Mathf.Abs(pos.y - tPos.y) * Time.deltaTime)); // Multiply smoothing by relative y distance between this and target

        // Limit the minimum and maximum positioning of the camera using Mathf.Clamp
        if (limitCamera)
        {
            pos.x = Mathf.Clamp(pos.x, min.x, max.x);
            pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        }

        // Apply new position using lerp, so that the change is smoothed
        transform.position = pos;

    }

    // Draw a gizmo in the Scene view
    void OnDrawGizmos()
    {
        if (showGizmo)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(xLead * 2, yThreshold * 2, 1));
        }
    }
}
