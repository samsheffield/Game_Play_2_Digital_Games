using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance = null;
    public int currentCheckpoint;

    void Awake()
    {
        // *** Set up instance
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            // Run Start() again!
            GameControl.Instance.Start();
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        currentCheckpoint = 0; // Reset checkpoint count
    }

    // Used by Checkpoint to save the last 
    public void SetCheckPoint (int newCheckPoint)
    {
        currentCheckpoint = newCheckPoint;
    }
}
