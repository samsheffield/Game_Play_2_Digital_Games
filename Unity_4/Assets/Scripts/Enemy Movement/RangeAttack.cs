using UnityEngine;
using System.Collections;

public class RangeAttack : MonoBehaviour
{
    // Reference to the Transform of the GameObject
    public Transform target;

    // If target is within range, attack
    public float range = 10f;
    private bool inRange;

    // How quickly to face target
    public float rotationSpeed = 5f;

    // Reference to the RangeEnemyWeapon weapon attached to a child GameObject
    private RangeEnemyWeapon weapon;

    // Store a reference to the weapon's coroutine so that it can be stopped
    private IEnumerator fire;

    void Start()
    {
        // Get weapon
        weapon = GetComponentInChildren<RangeEnemyWeapon>();

        // Set the IEnumerator variable to the weapon's Fire coroutine
        fire = weapon.Fire();
    }

    void Update()
    {
        // Check the distance between this and the target's position. If it is less than the range...
        if (Vector2.Distance(transform.position, target.position) < range)
        {
            // Check if the weapon is already in use. If not..
            if (!inRange)
            {
                // Start the weapon.
                inRange = true;
                StartCoroutine(fire);
            }

            // Face target
            FaceTarget(target);
        }
        else
        {
            // If the target is not in range, stop firing and reset weapon
            inRange = false;
            StopCoroutine(fire);

            // OPTIONAL : Return to original rotation
            //FaceTarget(transform);
        }
    }

    // Face a target's Transform
    void FaceTarget(Transform t)
    {
        Vector3 newRotation = Quaternion.LookRotation(Vector3.forward,  transform.position - t.position).eulerAngles;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), rotationSpeed * Time.deltaTime);
    }
}
