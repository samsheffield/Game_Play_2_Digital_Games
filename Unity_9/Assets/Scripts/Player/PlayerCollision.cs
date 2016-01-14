using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    // Access these components
    private Rigidbody2D rb2D;
    private Animator anim;
    private MovePlayer movePlayer;

    // *****
    //private PlayerLife playerLife;

    // Strength and duration of knockback
    public float knockbackForce = 350f;
    public float knockbackDuration = .45f;
    public float knockbackYScaler = 1.5f;

    private AudioSource audioSource;
    public AudioClip hitSound;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        movePlayer = GetComponent<MovePlayer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // *****
        //playerLife = GetComponent<PlayerLife>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Remember, it's possible to check for multiple tags using ||
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
        {
            rb2D.isKinematic = false;
            // Check the player's x position against the enemy's position and set the knockback in the right direction
            if (transform.position.x >= other.gameObject.transform.position.x)
            {
                StartCoroutine(Knockback(1)); // Knock back right
            }
            else
            {
                StartCoroutine(Knockback(-1)); // Knock back left
            }
        }
    }

    // Using a coroutine because our knockback includes a timer
    IEnumerator Knockback(float knockbackDirection)
    {
        // *****
        /*if(playerLife != null)
            playerLife.LoseHealth(1);*/

        //
        if (hitSound != null)
            audioSource.PlayOneShot(hitSound);

        // Disable player movement temporarily and trigger the hit animation
        movePlayer.enabled = false;
        anim.SetBool("isHit", true);

        // reset velocity to zero so that the knockback is consistent
        rb2D.velocity = Vector2.zero;

        // Add temporary force on both axes. Y will be scaled to provide an arc.
        rb2D.AddForce(new Vector2(knockbackDirection * knockbackForce, knockbackForce/knockbackYScaler));

        // Wait for a moment ant then reset animation parameter and player control
        yield return new WaitForSeconds(knockbackDuration);
        anim.SetBool("isHit", false);
        movePlayer.enabled = true;

        // *****
        /*if(playerLife != null && playerLife.health == 0)
        {
            playerLife.Die();
        }*/
    }
}
