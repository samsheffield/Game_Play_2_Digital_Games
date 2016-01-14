using UnityEngine;
using System.Collections;

public class DrawBoxColliderGizmo : MonoBehaviour
{
    private BoxCollider2D bc2D;

    void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();
    }

    // Draw a gizmo in the Scene view
    void OnDrawGizmos()
    {
        // If collider doesn't exist, don't draw gizmo
        if (bc2D == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(bc2D.size.x, bc2D.size.y, 1));
    }
}
