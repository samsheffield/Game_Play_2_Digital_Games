using UnityEngine;
using System.Collections;

public class JumpBehavior : MonoBehaviour
{
    public float delay = 1f;
    public float jumpInterval = 2f;
    public float jumpForce = 100f;
    private bool isJumping;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(KeepJumping());
    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            Jump();
        }
    }

    IEnumerator KeepJumping()
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {
            yield return new WaitForSeconds(jumpInterval);
            isJumping = true;
        }
    }

    void Jump()
    {
        // Add a momentary push upward
        rb2D.AddForce(Vector2.up * jumpForce);
        // Reset jumping boolean
        isJumping = false;
    }
}
