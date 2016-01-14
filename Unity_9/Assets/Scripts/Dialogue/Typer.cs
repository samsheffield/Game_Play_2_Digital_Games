using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Text))]
public class Typer : MonoBehaviour
{
    // Original code from here: https://gist.github.com/DarkDesire/fac180105122348fb1ab

    // To do: Add sound
    [Tooltip ("Arrays of text to display.")]
    public string[] msg;

    [Tooltip ("Delay before showing text.")]
    public float startDelay = 2f;

    [Tooltip("Rate of typewriter effect.")]
    public float typeDelay = 0.01f;

    [Tooltip("Loop the conversation. Otherwise, stay at last message until reset.")]
    public bool loop;

    [Tooltip("The sound to play when displaying characters.")]
    public AudioClip typeSound;

    private AudioSource audioSource;
    private Text dialogueText;

    // Has the typing finished?
    private bool ready = true;

    // Current message in array
    private int current;

    // Check if player is within range of the NPC
    private bool playerInRange;

    void Start()
    {
        dialogueText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for input and that player is in range of NPC.
        if (Input.GetButtonDown("Fire1") && playerInRange)
        {  

            // If the typing has finished, display next message.
            if (ready)
                Talk();
        }
    }

    // Type the message text
    public void Talk()
    {
        playerInRange = true;
        ready = false;
        StartCoroutine(TypeIn());
    }

    // Reset message
    public void Reset()
    {
        // Clear text.
        dialogueText.text = "";
        playerInRange = false;
        ready = true;
        current = 0;
    }

    // Display text like a typewriter
    public IEnumerator TypeIn()
    {
        // Clear text first.
        dialogueText.text = "";

        // Wait for a brief period before typing.
        yield return new WaitForSeconds(startDelay);

        // Go through each character in a message, and display one-by-one.
        for (int i = 0; i < msg[current].Length; i++)
        {
            dialogueText.text = msg[current].Substring(0, i + 1);
            audioSource.PlayOneShot(typeSound);
            yield return new WaitForSeconds(typeDelay);
        }

        // Iterate through the msg array.
        if (current < msg.Length - 1)
        {
            current++;
        }
        else
        {
            // Loop messages, if desired.
            if (loop)
                current = 0;
        }

        // Signal that it's time for a new message.
        ready = true;
    }
}