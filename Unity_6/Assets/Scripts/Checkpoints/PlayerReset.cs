using UnityEngine;
using System.Collections;

public class PlayerReset : MonoBehaviour
{

    // This method is public so that PlayerCollision can use it
    // Reset the player's position
    public void ResetPosition()
    {
        // Check GameControl for the current checkpoint number. Move to the appropriate position
        if (GameControl.Instance.currentCheckpoint == 1)
        {
            transform.position = GameObject.Find("Checkpoint 1").transform.position; // Find "Checkpoint 1" in the Hierarchy and get its position. Set this object's position to that.
        }
        else if (GameControl.Instance.currentCheckpoint == 2)
        {
            transform.position = GameObject.Find("Checkpoint 2").transform.position;
        }
    }
}
