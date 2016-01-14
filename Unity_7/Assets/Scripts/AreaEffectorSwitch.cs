using UnityEngine;
using System.Collections;

public class AreaEffectorSwitch : MonoBehaviour
{
    // Set this to the gameobject with a Vent component attached
    public Vent vent;

    // Set switch when touched by player
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            vent.TurnOn(); // run Vent.TurnOn() method
            Destroy(transform.parent.gameObject); // Get rid of this switch (which is the parent)
        }
    }

}
