using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour
{

    // Variable to hold reference to bullet prefab.
    private GameObject bulletPrefab;

    // Initial delay and firing rate. Delay will be set using the delay property of GameControl.Instance
    private float delay;
    public float rate = 2f;

    // Bullet properties
    public float bulletVelocity = 15f;
    public float bulletLifeSpan = 2f;

    // Variable to hold reference to AudioClip component attached to this GameObject
    private AudioSource audioSource;

    // Variable to hold reference to AudioClip which will be played when weapon is fired
    public AudioClip fireClip;

    public GameControl gameControl;

    void Start()
    {
        // Find AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // *** Set the delay using GameControl's delay
        delay = gameControl.delay;

        // Load bullet prefab from Resources here
        bulletPrefab = Resources.Load("EnemyBullet") as GameObject;
        // Begin firing IEnumerator method
        StartCoroutine(Fire());
    }

    // Fire the enemy weapon 
    IEnumerator Fire()
    {
        // Delayed start
        yield return new WaitForSeconds(delay);

        // Keep firing...
        while (true)
        {
            // Trigger audio clip
            audioSource.PlayOneShot(fireClip);

            // Create a clone of the bullet prefab in a way that allows us to access its properties
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

            // Get the clone's Rigidbody2D component
            Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();

            // Shoot the bullet. Multiply the direction * velocity by -1 so that it shoots downward, relative to this rotation
            rb2D.velocity = transform.up * bulletVelocity * -1;

            // Destroy the clone after a specified amount of time
            Destroy(bullet, bulletLifeSpan);

            // Wait, and then start firing again
            yield return new WaitForSeconds(rate);
        }
    }
}
