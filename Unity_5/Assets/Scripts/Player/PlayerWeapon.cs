using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
    // Variable to hold reference to bullet prefab. Set in Inspector.
    private GameObject bulletPrefab;

    // Variable to hold reference to AudioClip which will be played when weapon is fired
    private AudioClip fireClip;

    // Shoot horizontally? Default : false (shoot vertically)
    public bool shootHorizontal;

    // Weapon trigger signal
    private bool triggerFire;

    // Delay to limit player input until ready again
    public float cooldown = .1f;
    private bool ready = true;

    // Bullet properties
    public float bulletVelocity = 35f;
    public float bulletLifeSpan = 2f;

    // Variable to hold reference to AudioClip component attached to this GameObject   
    private AudioSource audioSource;

    void Start()
    {
        // Find AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Load these from Resources folders so that the are accessible to prefabs as well
        bulletPrefab = Resources.Load("PlayerBullet") as GameObject;
        fireClip = Resources.Load("Player_Shoot") as AudioClip;
    }

    void Update()
    {

        
        if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire2"))
        {
            triggerFire = true;
        }
        else
        {
            triggerFire = false;
        }


        // Get input. Set this in Input Manager
        if (triggerFire)
        {
            // If ready to fire...
            if (ready)
            {
                // Disable firing until this is reset
                ready = false;

                // Fire weapon
                StartCoroutine(Fire());
            }
        }
    }

    // Fire player weapon
    IEnumerator Fire()
    {
        // Trigger audio clip
        audioSource.PlayOneShot(fireClip);

        // Create a clone of the bullet prefab in a way that allows us to access its properties
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

        // Get the clone's Rigidbody2D component
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();

        // Shoot in the selected direction
        if (shootHorizontal)
        {
            // Shoot the bullet relative to this GameObject's up
            rb2D.velocity = transform.right * bulletVelocity;
        }
        else
        {
            // Shoot the bullet relative to this GameObject's up
            rb2D.velocity = transform.up * bulletVelocity;
        }

        // Destroy bullet clone after delay
        Destroy(bullet, bulletLifeSpan);

        // Wait before resetting weapon ready variable
        yield return new WaitForSeconds(cooldown);

        // This makes it possible to fire again
        ready = true;
    }
}
