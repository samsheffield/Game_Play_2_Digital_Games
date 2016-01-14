using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use "Jump" button (space) to toggle volume of background music on (1.0f) and off (0)
        if (Input.GetButtonUp("Jump"))
        {
            if(audioSource.volume == 1.0f)
            {
                audioSource.volume = 0;
            }
            else
            {
                audioSource.volume = 1.0f;
            }
        }
    }
}
