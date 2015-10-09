using UnityEngine;
using System.Collections;

public class ScrollBackgroundTexture : MonoBehaviour {

    // For information on how to set this up in Unity, check here: https://www.youtube.com/watch?v=HrDxnMI7pCc
    // Can't see your sprites? Move this GameObject's transform Z to 1
    // Scrolling speed
    public float speed = 0.5f;

    // Get the attached Renderer component
    private Renderer rr;

	void Start () {
        rr = GetComponent<Renderer>();
	}
	
	void Update () {
        // Offset the texture (move the image) at a set rate * speed
        Vector2 offset = new Vector2(0, Time.time * speed);
        rr.material.mainTextureOffset = offset;
	}
}
