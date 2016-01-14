// Script from here: https://www.youtube.com/watch?v=ZkGPoZOQE5Q&list=PLt_Y3Hw1v3QSFdh-evJbfkxCK_bjUD37n&index=4

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathDefinition : MonoBehaviour
{
    public Transform[] points;

    public enum FollowType
    {
        PingPong,
        Loop
    }

    public FollowType followType = FollowType.PingPong;

    public IEnumerator<Transform> GetPathsEnumerator()
    {
        if (points == null || points.Length < 1)
            yield break;

        int direction = 1;
        int index = 0;

        while (true)
        {
            yield return points[index];

            if (followType == FollowType.PingPong)
            {
                if (index <= 0)
                    direction = 1;
                else if (index >= points.Length - 1)
                    direction = -1;
            }
            else if (followType == FollowType.Loop)
            {
                if (index >= points.Length - 1)
                    index = -1;
            }

            index = index + direction;
        }
    }

    public void OnDrawGizmos()
    {
        if (points == null || points.Length < 2)
            return;
        if (followType == FollowType.PingPong)
        {
            for (int i = 1; i < points.Length; i++)
            {
                Gizmos.DrawLine(points[i - 1].position, points[i].position);
            }
        }
        else if (followType == FollowType.Loop)
        {
            for (int i = 1; i < points.Length; i++)
            {
                Gizmos.DrawLine(points[i - 1].position, points[i].position);
                if(i == points.Length - 1)
                {
                    Gizmos.DrawLine(points[0].position, points[i].position);
                }
            }
        }
    }
}
