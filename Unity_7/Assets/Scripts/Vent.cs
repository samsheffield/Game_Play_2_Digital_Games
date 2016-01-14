using UnityEngine;
using System.Collections;

public class Vent : MonoBehaviour
{
    private AreaEffector2D ae2D;

    void Start()
    {
        // Find the attached component
        ae2D = GetComponent<AreaEffector2D>();

        // Turn off area effector component
        ae2D.enabled = false;
    }

    public void TurnOn()
    {
        // Turn on area effector component
        ae2D.enabled = true;

        // OTHER IDEAS:
        /*
           - Trigger animation
           - Turn off vent using IEnumerator after a small amount of time
        */
    }
}
