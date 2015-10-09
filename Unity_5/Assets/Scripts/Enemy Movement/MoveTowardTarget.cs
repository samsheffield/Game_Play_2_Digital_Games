using UnityEngine;
using System.Collections;

public class MoveTowardTarget : MonoBehaviour
{

    private Transform target;
    public float velocity = 10f;
    public float rotationSpeed = 5f;

    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        // Check if the target is still available...
        if (target != null)
        {
            // Turn to face
            FaceTarget();

            // Move towards
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target.position, velocity * Time.deltaTime);
        }
    }

    // Turn to face
    void FaceTarget()
    {
        Vector3 newRotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position).eulerAngles;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), rotationSpeed * Time.deltaTime);
    }
}
