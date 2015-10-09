using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    // How long to keep this GameObject alive
    public float duration = .2f;

    void Start()
    {
        // Start explode IEnumerator
        StartCoroutine(Explode());
    }

    // Simple delay and destroy coroutine
    IEnumerator Explode()
    {
        // Alive and waiting
        yield return new WaitForSeconds(duration);

        // Dead
        Destroy(gameObject);
    }
}
