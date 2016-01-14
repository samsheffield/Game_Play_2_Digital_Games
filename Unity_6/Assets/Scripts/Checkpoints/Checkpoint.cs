using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{

    // Give each checkpoint a unique ID. These numbers should by in sequential order
    public int checkPointID;

    // Send GameControl the ID number when triggered by the player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Only set checkpoint if its rank is higher than the last one. Remove this if() should you want to save any checkpoint, regardless of rank
            if (checkPointID > GameControl.Instance.currentCheckpoint)
            {
                GameControl.Instance.SetCheckPoint(checkPointID);
                //print("Checkpoint set to " + checkPointID);
            }
        }
    }
}
