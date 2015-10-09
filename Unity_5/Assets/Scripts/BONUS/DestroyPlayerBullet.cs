using UnityEngine;
using System.Collections;

public class DestroyPlayerBullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
        }
    }
}
