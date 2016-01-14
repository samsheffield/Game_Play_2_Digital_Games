using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    // Reference to the PlayerReset component on the gameObject
    private PlayerReset playerReset;

    void Start()
    {
        // Find the component
        playerReset = GetComponent<PlayerReset>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Example: Use the ResetPosition() method to reset the player's position to the last checkpoint reached
        if (other.gameObject.tag == "Bad")
        {
            playerReset.ResetPosition();
        }
    }
}
