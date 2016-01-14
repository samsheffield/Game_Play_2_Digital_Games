using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    private float killDelay = 1f;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DelayKill(other.gameObject));
            //Application.LoadLevel(Application.loadedLevel);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DelayKill(other.gameObject));
            //Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator DelayKill(GameObject player)
    {
        yield return new WaitForSeconds(killDelay);
        Destroy(player);
        yield return new WaitForSeconds(killDelay);
        Application.LoadLevel(Application.loadedLevel);
    }
}
