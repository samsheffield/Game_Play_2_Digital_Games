using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    // Reference to the transform component of the GameObject the camera will follow
    public Transform targetTransform;

    // Must use Vector3 to store offset position of camera
    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        // Get position of target relative to the camera
        offset = transform.position - targetTransform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Check if target exists or not before trying to access it
        if (targetTransform != null)
        {
            // Update the camera position to the position of the offset target
            transform.position = targetTransform.position + offset;
        }
    }
}
