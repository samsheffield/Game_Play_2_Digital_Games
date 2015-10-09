using UnityEngine;
using System.Collections;

public class TrackingEnemyWeapon : MonoBehaviour {

    // Variable to hold reference to bullet prefab.
    private GameObject bulletPrefab;

    // Initial delay and firing rate
    public float delay = .5f;
    public float rate = 2f;

    // Bullet properties
    public float bulletVelocity = 15f;
    public float bulletLifeSpan = 2f;

    // Variable to hold reference to AudioClip component attached to this GameObject
    private AudioSource audioSource;

    // Variable to hold reference to AudioClip which will be played when weapon is fired
    private AudioClip fireClip;

	void Start ()
    {
        // Find AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // *** Load prefab from Resources
        bulletPrefab = Resources.Load("EnemyBullet") as GameObject;
        // *** Load sound clip from Resources
        fireClip = Resources.Load("Enemy_Shoot") as AudioClip;


        // Begin firing IEnumerator method
        StartCoroutine(Fire());
	}

    // Fire the enemy weapon 
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(delay);

        // *** Keep firing until game is over switch to instance
        while (GameControl.Instance.gameOver == false)
        {
            // Trigger audio clip
            audioSource.PlayOneShot(fireClip);

            // Create a clone of the bullet prefab in a way that allows us to access its properties
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

            // Get the clone's Rigidbody2D component
            Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();

            // Shoot the bullet. Multiply the direction * velocity so that it shoots upward
            rb2D.velocity = transform.up * bulletVelocity;

            // Destroy the clone after a specified amount of time
            Destroy(bullet, bulletLifeSpan);

            // Wait, and then start firing again
            yield return new WaitForSeconds(rate);
        }
    }
}
