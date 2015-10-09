using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    // Variable to hold reference to explosion prefab. Set in Inspector.
    public GameObject explosionPrefab;

    // Variable to hold reference to GameObject with CameraShake component.
    private CameraShake cameraShake;

    // 
    private PlayerHealth playerHealth;

	void Start () {
        // Find component
        playerHealth = GetComponent<PlayerHealth>();

        // Find this in the Hierarchy. Name must match EXACTLY and must have a CameraShake component attached to it.
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
	}

    // When hit by EnemyBullet, shake the camera, create clone of explosion prefab, lose health, and destroy bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            // Shake the camera
            StartCoroutine(cameraShake.Shake());

            // Add an explosion prefab to the Scene in the same position as this GameObject
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Call the LoseHealth method from the EnemyHealth cpmponenet
            playerHealth.LoseHealth(1);

            // Deatroy bullet
            Destroy(other.gameObject);
        }
    }
	
}
