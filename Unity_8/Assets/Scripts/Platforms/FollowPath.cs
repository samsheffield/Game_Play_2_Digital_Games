// Script from here: https://www.youtube.com/watch?v=ZkGPoZOQE5Q&list=PLt_Y3Hw1v3QSFdh-evJbfkxCK_bjUD37n&index=4
// Modified to use Rigidbody2D movement

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour
{
    public PathDefinition path;
    public float speed = 1;
    public float maxDistanceToGoal = .1f;
    private IEnumerator<Transform> currentPoint;
    private Rigidbody2D rb2D;

    void Start()
    {
        if (path == null)
        {
            Debug.LogError("Path cannot be null");
            return;
        }

        rb2D = GetComponent<Rigidbody2D>();
        currentPoint = path.GetPathsEnumerator();
        currentPoint.MoveNext();
        //print(currentPoint.Current.position);

        if (currentPoint.Current == null)
            return;

        transform.position = currentPoint.Current.position;
    }

    void FixedUpdate()
    {
        if (currentPoint == null || currentPoint.Current == null)
            return;

        rb2D.MovePosition(Vector3.MoveTowards(transform.position, currentPoint.Current.position, Time.fixedDeltaTime * speed));

        float distanceSquared = (transform.position - currentPoint.Current.position).sqrMagnitude;
        if (distanceSquared < maxDistanceToGoal * maxDistanceToGoal)
            currentPoint.MoveNext();
    }
}
