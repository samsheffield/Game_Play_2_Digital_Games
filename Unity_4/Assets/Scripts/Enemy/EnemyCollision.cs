using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

    // Variable to hold reference to explosion prefab. Set in Inspector.
    public GameObject explosionPrefab;

    // Variable to hold reference to EnemyHealth component attached to this GameObject
    private EnemyHealth enemyHealth;

    void Start()
    {
        // Find component
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // When hit by PlayerBullet, create clone of explosion prefab, lose health, and destroy bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            // Add an explosion prefab to the Scene in the same position as this GameObject
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Call the LoseHealth method from the EnemyHealth cpmponenet
            enemyHealth.LoseHealth(1);

            // Destroy bullet
            Destroy(other.gameObject);
        }
    }
}
