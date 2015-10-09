using UnityEngine;
using System.Collections;

public class MoveTowardTarget : MonoBehaviour
{

    public Transform target;
    public float velocity = 10f;
    public float rotationSpeed = 5f;

    void Update()
    {
        FaceTarget();
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target.position, velocity * Time.deltaTime);
    }

    void FaceTarget()
    {
        Vector3 newRotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position).eulerAngles;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), rotationSpeed * Time.deltaTime);
    }
}
