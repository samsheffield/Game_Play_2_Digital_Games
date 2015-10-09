using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    // Add slider ranges in Inspector
    [Range(0f, 10f)] // IMPORTANT : No semicolons!
    public float duration = 5f;

    [Range(0f, 2f)]
    public float strength = 1f;

    private Vector3 startPosition;
	
	// Update is called once per frame
	void Update ()
    {

        // Test. Remove if not needed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Use this with IEnumerators!
            StartCoroutine ( Shake() );
        }
	}

    // Make this 'public' so that it can be called from other GameObjects
    public IEnumerator Shake()
    {
        // Reset a counter
        int count = 0;

        // Store camera position before shaking
        startPosition = transform.position;
        
        // Shake loop
        while(count < duration)
        {
            // Add to count so that we can eventually leave te while loop
            count++;

            // Reposition camera by adding a random position. 
            transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), startPosition.z);

            // Shake as fast as possible
            yield return null;

            // EXAMPLE: Reset position when done. Not necessary if the camera is following Player
            transform.position = startPosition;
        }
    }
}
